using API_Server.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using API_Server.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.JsonPatch;

namespace API_Server.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MongoDbService _context;
        private readonly EmailService _emailService;
        private readonly JwtService _jwtService;
        private readonly UserService _userService;
        private readonly IMongoCollection<User> users;
        public UserController(MongoDbService context, EmailService emailService, JwtService jwtService, UserService userService)
        {
            _context = context;
            _emailService = emailService;
            _jwtService = jwtService;
            _userService = userService;
            users = _context.Users;
        }

        private static readonly ConcurrentDictionary<string, User> _users = new ConcurrentDictionary<string, User>();
        private static string? currentEmail;
        private static string? curentOtp;

        //POST METHOD
        //API cho Registration
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register registerModel)
        {
            //Kiểm tra 2 mật khẩu được nhập vào
            if (registerModel.Password != registerModel.ConfirmPassword)
            {
                return BadRequest("Mật khẩu xác nhận không hợp lệ.");
            }
            //Kiểm tra xem tên người dùng hoặc mail đã tồn tại hay chưa
            var filter = Builders<User>.Filter.Or(
                Builders<User>.Filter.Eq(u => u.Username, registerModel.Username),
                Builders<User>.Filter.Eq(u => u.Email, registerModel.Email)
            );
            //Luu kết quả tìm trong database 
            var existingUser = await _context.Users.Find(filter).FirstOrDefaultAsync();

            if (existingUser != null)
            {
                return BadRequest("Tên người dùng hoặc email đã tồn tại.");
            }

            //Tạo mã otp và gắn cho biến tạm để dùng so sánh trong hàm xác minh otp
            var otp = new Random().Next(000000, 999999).ToString();
            curentOtp = otp;
            //Hash password bằng framework
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerModel.Password);
            //Tạo user nhận dữ liệu được vào
            var user = new User
            {
                Name = registerModel.Name,
                Username = registerModel.Username,
                Password = registerModel.Password,
                PasswordHash = hashedPassword,
                DateOfBirth = registerModel.DateOfBirth,
                Email = registerModel.Email,
                CreatedAt = DateTime.UtcNow
            };

            _users[registerModel.Email] = user;
            //Gửi otp với mail được nhập
            currentEmail = user.Email;
            _emailService.SendOtpEmail(user.Email, otp);

            return Ok("Đăng kí thành công. Kiếm tra mã OTP trong email của bạn.");
        }
        //API cho Verify Otp
        [HttpPost("Verify-Otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] Otp otpModel)
        {
            //Kiểm tra xem email đã được dùng để đăng kí chưa
            if (string.IsNullOrEmpty(currentEmail))
                return BadRequest(new
                {
                    message = "Email này chưa được dùng để đăng kí."
                });
            //Lưu email đã có từ api registration
            var tempUser = _users[currentEmail];
            //So sánh OTP
            if (curentOtp != otpModel.OTP)
            {
                return BadRequest(new
                {
                    message = "OTP không hợp lệ"
                });
            }
            //Kiểm tra xem email đã đăng kí cho user nào chưa
            //Có thể xem xét bỏ đoạn này
            var filter = Builders<User>.Filter.Eq(x => x.Email, tempUser.Email);
            var existingUser = await _context.Users.Find(filter).FirstOrDefaultAsync();

            if (existingUser != null)
            {
                return BadRequest("Người dùng đã được đăng kí.");
            }
            //Tạo user để thêm dữ liệu vào database
            var newUser = new User
            {

                Name = tempUser.Name,
                Username = tempUser.Username,
                PasswordHash = tempUser.PasswordHash,
                DateOfBirth = tempUser.DateOfBirth,
                Email = tempUser.Email,
                CreatedAt = DateTime.UtcNow,
                IsEmailVerified = true
            };
            newUser.IsEmailVerified = true;
            await _context.Users.InsertOneAsync(newUser);
            return Ok(new
            {
                message = "Đăng kí thành công!",
                info = newUser
            });
        }
        //API cho Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login loginModel)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.Username) || string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest(new
                {
                    message = "Yêu cầu đăng nhập thất bại."
                });
            }

            var filter = Builders<User>.Filter.Eq(u => u.Username, loginModel.Username);
            var user = await users.Find(filter).FirstOrDefaultAsync();

            if (user == null || string.IsNullOrEmpty(user.PasswordHash))
            {
                return Unauthorized(new
                {
                    message = "Tên người dùng không hợp lệ."
                });
            }

            if (!BCrypt.Net.BCrypt.Verify(loginModel.Password, user.PasswordHash))
            {
                return Unauthorized(new
                {
                    message = "Mật khẩu không hợp lệ."
                });
            }

            var accessToken = _jwtService.GenerateAccessToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();
            var jti = _jwtService.GetJtiFromAccessToken(accessToken);
            // Lưu refresh token vào database
            var tokenData = new TokenData
            {
                RefreshToken = refreshToken,
                RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7),
                Username = user.Username,
                Jti = jti
            };

            await _context.Tokens.InsertOneAsync(tokenData);
            //Lưu access token vào cookies
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7),
                Secure = true,
                SameSite = SameSiteMode.Strict
            };
            Response.Cookies.Append("accessToken", accessToken, cookieOptions);
            //Trả về refresh token và access token

            return Ok(new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Id = user.Id.ToString(),
                Name = user.Name,
                Username = user.Username,
                Email = user.Email
            });
        }
        //API cho logout
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            // Lấy access token từ cookies
            if (!Request.Cookies.TryGetValue("accessToken", out var accessToken))
            {
                return BadRequest("Yêu cầu không hợp lệ.");
            }

            // Xác minh token và lấy username
            var claimsPrincipal = _jwtService.ValidateToken(accessToken);//Trả về giá trị người dùng của token
            if (claimsPrincipal == null)
            {
                return Unauthorized("Access token không hợp lệ 1.");
            }

            var usernameClaim = claimsPrincipal.FindFirst("userName");//Tìm username của token
            if (usernameClaim == null || string.IsNullOrEmpty(usernameClaim.Value))
            {
                return Unauthorized("Access token không hợp lệ 2");
            }
            var username = usernameClaim.Value;

            // Tìm user trong database
            var user = await _context.Users.Find(u => u.Username == username).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound("Không tìm thấy người dùng.");
            }

            // Xóa refresh token từ database
            var filter = Builders<TokenData>.Filter.Eq(t => t.Username, username);
            await _context.Tokens.DeleteManyAsync(filter);

            // Xóa access token từ cookies
            if (Request.Cookies.ContainsKey("accessToken"))
            {
                Response.Cookies.Delete("accessToken");
            }

            return Ok(new
            {
                status = 200,
                message = "Đăng xuất thành công."
            });
        }

        //PATCH METHOD
        //Chỉnh sửa thông tin người dùng (chưa hoàn thiện)
        [HttpPatch("{username}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(string username, [FromBody] JsonPatchDocument<User> patchDoc)
        {

            var user = await _context.Users.Find(u => u.Username == username).FirstOrDefaultAsync();
            var filter = Builders<User>.Filter.Eq(u => u.Username, username);

            if (user == null)
            {
                return NotFound("Không tìm thấy người dùng.");
            }

            patchDoc.ApplyTo(user, ModelState);
            ModelState.Remove("password");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Users.ReplaceOneAsync(filter, user);

            return Ok(user);
        }

        //POST METHOD
        [Authorize]
        [HttpPost("{username}/add-friend/{targetUsername}")]
        public async Task<IActionResult> SendFriendRequest(string targetUsername, string username)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }
            try
            {
                await _userService.SendRequest(username, targetUsername);
                return Ok(new
                {
                    message = "Gửi yêu cầu thành công!"

                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("{username}/accept-request/{requestUsername}")]
        public async Task<IActionResult> AcceptFriendRequest(string username, string requestUsername)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }
            try
            {
                await _userService.AcceptFriendRequest(username, requestUsername);
                return Ok(new
                {
                    message = "Đã chấp nhận kết bạn!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET METHOD
        //Lấy data của người dùng
        [HttpGet("{username}")]
        [Authorize]
        public async Task<IActionResult> GetUser(string username)
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            if(!_jwtService.IsValidate(authHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }    
            //Tìm thông tin người dùng
            var user = await _userService.GetUserByUserName(username);

            if (user == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy người dùng."
                });
            }
            var userResponse = new
            {
                name = user.Name,
                username = user.Username,
                email = user.Email
            };
            return Ok(new
            {
                message = "Lấy người dùng thành công!",
                userFound = userResponse
            });
        }
        [Authorize]
        [HttpGet("{username}/search")]
        public async Task<ActionResult<List<User>>> SearchUsers(string username,[FromQuery] string query, [FromQuery] int page=1, [FromQuery] int pageSize = 5)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }
            try 
            {
                var (users, totalPages) = await _userService.SearchUserAsync(query, page, pageSize,username);
                if (users == null || users.Count == 0)
                {
                    return NotFound(new
                    {
                        total = 0,
                        message = "Không tìm thấy người dùng"
                    });
                }

                var res = users.Select(user => new
                {
                    id = user.Id.ToString(),
                    name = user.Name,
                    username = user.Username,
                    email = user.Email,
                    dateOfBirth = user.DateOfBirth

                });
                return Ok(new
                {
                    total = users.Count,
                    totalPages,
                    currentPage = page,
                    data = res
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    details = ex.Message
                });
            }

        }

        [Authorize]
        [HttpGet("{username}/suggest-friends")]
        public async Task<ActionResult<List<User>>> SuggestFriends(string username)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }
            var friends = await _userService.SuggestFriendAsync(username);

            if (friends == null || friends.Count == 0)
            {
                return NotFound(new
                {
                    total = 0,
                    message = "Không tìm thấy bạn bè!"
                });
            }

            var result = friends.Select(user => new
            {
                id = user.Id.ToString(),
                name = user.Name,
                username = user.Username,
                email = user.Email
            }
            );

            return Ok(new
            {
                total = friends.Count,
                data = result
            });
        }

        [Authorize]
        [HttpGet("get-friend-list/{username}")]
        public async Task<ActionResult<List<string>>> GetListFriend(string username)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }
            try
            {
                var friends = await _userService.GetListFriendIdByUsername(username);
                return Ok(new
                {
                    total = friends.Count,
                    data = friends
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    details = ex.Message
                });
            }
        }

        [Authorize]
        [HttpGet("get-request-list/{username}")]
        public async Task<IActionResult> GetReqList(string username)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }
            try
            {
                var reqList = await _userService.GetRequestList(username);
                
                if (reqList.Count == 0)
                {
                    return NotFound(new
                    {
                        message = "Không có lời mời kết bạn!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        message = "Lấy danh sách lời mời thành công!",
                        total = reqList.Count,
                        data = reqList
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    details = ex.Message
                });
            }
        }

        [Authorize]
        [HttpGet("{username}/get-groups")]
        public async Task<IActionResult> GetGroupsByUsername(string username)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }

            try
            {
                var groups = await _userService.GetGroupsByUsername(username);
                if(groups == null || groups.Count == 0)
                {
                    return NotFound(new
                    {
                        message = "Không tìm được nhóm của người dùng này!"
                    });
                }
                return Ok(new
                {
                    data = groups
                }); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    details = ex.Message
                });
            }
        }

        // DELETE METHOD
        [Authorize]
        [HttpDelete("{username}/remove-request/{reqUsername}")]
        public async Task<IActionResult> RemoveRequest(string reqUsername,string username)
        {
            
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if(!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }    

            try
            {
                var res = await _userService.DeleteRequest(username, reqUsername);
                if (res)
                {
                    return Ok(new
                    {
                        message = "Xóa yêu cầu kết bạn thành công!"
                    });

                }
                return BadRequest(new
                {
                    message = "Không thể xóa yêu cầu kết bạn!"
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    details = ex.Message
                });
            }

        }

        [Authorize]
        [HttpDelete("delete-friend/{friendName}")]
        public async Task<IActionResult> DeleteFriend(string friendName)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var accessToken = authorizationHeader.Substring("Bearer ".Length).Trim();

            // Xác minh token và lấy username
            var claimsPrincipal = _jwtService.ValidateToken(accessToken);//Trả về giá trị người dùng của token
            if (claimsPrincipal == null)
            {
                return Unauthorized(new
                {
                    message = "Access token không hợp lệ"
                });
            }

            var usernameClaim = claimsPrincipal.FindFirst("userName");//Tìm username của token
            if (usernameClaim == null || string.IsNullOrEmpty(usernameClaim.Value))
            {
                return Unauthorized(new
                {
                    message = "Access token không hợp lệ"
                });
            }
            var username = usernameClaim.Value;

            try
            {
                await _userService.DeleteFriend(username, friendName);
                return Ok(new
                {
                    message = "Xóa bạn thành công!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        [Authorize]
        [HttpDelete("delete-sending-request/{reqUsername}")]
        public async Task<IActionResult> RemoveSendingRequest(string reqUsername)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var accessToken = authorizationHeader.Substring("Bearer ".Length).Trim();

            // Xác minh token và lấy username
            var claimsPrincipal = _jwtService.ValidateToken(accessToken);//Trả về giá trị người dùng của token
            if (claimsPrincipal == null)
            {
                return Unauthorized("Access token không hợp lệ");
            }

            var usernameClaim = claimsPrincipal.FindFirst("userName");//Tìm username của token
            if (usernameClaim == null || string.IsNullOrEmpty(usernameClaim.Value))
            {
                return Unauthorized("Access token không hợp lệ");
            }
            var username = usernameClaim.Value;

            try
            {
                var check = await _userService.DeleteSendingRequest(username, reqUsername);
                if (!check)
                {
                    return BadRequest(new
                    {
                        message = "Lỗi không thể xóa lời mời!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        message = "Đã xóa lời mời!"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    details = ex.Message
                });
            }
        }

        //Xóa người dùng
        [HttpDelete("{username}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(string username)
        {
            // Lấy access token từ cookies
            if (!Request.Cookies.TryGetValue("accessToken", out var accessToken))
            {
                return BadRequest("Yêu cầu không hợp lệ.");
            }


            // Xác minh token và lấy username
            var claimsPrincipal = _jwtService.ValidateToken(accessToken);//Trả về giá trị người dùng của token
            if (claimsPrincipal == null)
            {
                return Unauthorized("Access token không hợp lệ 1.");
            }

            //Tìm thông tin người dùng
            var user = await _context.Users.Find(u => u.Username == username).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("Không tìm thấy người dùng.");
            }
            //Xóa người dùng
            await _context.Users.DeleteOneAsync(u => u.Username == username);

            return Ok("Xóa người dùng thành công.");
        }
    }
}
