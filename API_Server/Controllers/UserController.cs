﻿using API_Server.Models;
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register registerModel)
        {
            var (success, message) = await _userService.RegisterAsync(registerModel);
            if (!success)
            {
                return BadRequest(message);
            }

            return Ok(message);
        }

        [HttpPost("Verify-Otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] Otp otpModel)
        {
            var (success, message, user) = await _userService.VerifyOtpAsync(otpModel);

            if (!success)
            {
                return BadRequest(new { message });
            }

            return Ok(new
            {
                message,
                info = user
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login loginModel)
        {
            var (success, message, data) = await _userService.LoginAsync(loginModel, Response);
            if (!success)
            {
                return BadRequest(new { message });
            }

            var accessToken = _jwtService.GenerateAccessToken(data);
            var refreshToken = _jwtService.GenerateRefreshToken();
            var jti = _jwtService.GetJtiFromAccessToken(accessToken);

            var tokenData = new TokenData
            {
                RefreshToken = refreshToken,
                RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7),
                Username = data.Username,
                Jti = jti
            };

            await _context.Tokens.InsertOneAsync(tokenData);

            return Ok(new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Id = data.Id.ToString(),
                Name = data.Name,
                Username = data.Username,
                Email = data.Email,
            });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                authorizationHeader = authorizationHeader.Substring("Bearer ".Length).Trim();
            }

            var claimsPrincipal = _jwtService.ValidateToken(authorizationHeader);

            var usernameClaim = claimsPrincipal?.FindFirst("userName");

            var username = usernameClaim?.Value;
            if (username == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy thông tin người dùng"
                });
            }

            var user = await users.Find(u => u.Username == username).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy người dùng."
                });
            }

            var filter = Builders<TokenData>.Filter.Eq(t => t.Username, username);
            await _context.Tokens.DeleteManyAsync(filter);

            return Ok("Đăng xuất thành công");
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
        [HttpGet("get-friend-list-for-chat/{username}")]
        public async Task<ActionResult<List<string>>> GetFriendListForChat(string username)
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
                return Ok(friends);
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

        [Authorize]
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }

            var user = await _context.Users.Find(u => u.Username == username).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("Không tìm thấy người dùng.");
            }

            await _context.Users.DeleteOneAsync(u => u.Username == username);

            return Ok("Xóa người dùng thành công.");
        }

    }
}
