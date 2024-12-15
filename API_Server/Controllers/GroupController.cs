using API_Server.Models;
using API_Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System.Net.WebSockets;
using System.Security.Claims;

namespace API_Server.Controllers
{
    [ApiController]
    [Route("/api/groups")]
    public class GroupController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly GroupService _chatGroupService;
        
        private readonly MongoDbService _context;
        
        private readonly JwtService _jwtService;
        public GroupController(UserService userService, GroupService cgs, MongoDbService context, JwtService jwtService)
        {
            _userService = userService;
            _chatGroupService = cgs;
            _context = context;
            _jwtService = jwtService;
        }

        //POST METHOD
        [Authorize]
        [HttpPost("{username}/create")]
        public async Task<ActionResult<Group>> CreateGroup(string username,[FromBody] CreateGroup groupModel)
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
                var creator = new MemberRole
                {
                    Username = username,
                    Role = "001"
                };
                groupModel.Members.Add(creator);
                var group = new Group
                {
                    Name = groupModel.Name,
                    Description = groupModel.Description,
                    Creator = username,
                    Members = groupModel.Members,   
                };

                var createdGroup = await _chatGroupService.CreateGroup(group);

                return Ok(new
                {
                    message = "Create group sucessfully!",
                    info = createdGroup
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("{groupId}/add-user")]
        public async Task<IActionResult> AddUserToGroup(string groupId, [FromBody] AddUserRequest userReq)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var username = await _jwtService.GetUsernameFromToken(authorizationHeader);
            if(username == null)
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }    
            try
            {
                var checkJoined = await _chatGroupService.IsInGroup(username, groupId);
                if (!checkJoined)
                {
                    return BadRequest(new
                    {
                        message = "Bạn chưa tham gia vào nhóm này!"
                    });
                }
                    
                var user = await _userService.GetUserByUserName(userReq.Username);
                if (user == null)
                {
                    return NotFound(new
                    {
                        message = "Không tìm thấy người dùng!"
                    });
                }
                var checkFriend = await _userService.IsFriend(username, userReq.Username);
                if (!checkFriend)
                {
                    return BadRequest(new
                    {
                        message = "Hai bạn chưa là bạn bè nên không thể thêm vào nhóm!"
                    });
                }
                var group = await _chatGroupService.GetGroupById(groupId);
                if (group == null)
                {
                    return NotFound(new
                    {
                        message = "Không tìm thấy nhóm"
                    });
                }
                var callerRole = group.Members.FirstOrDefault(m => m.Username == username)?.Role;
                if(callerRole == "002")
                {
                    return StatusCode(403, new
                    {
                        message = "Chỉ Admin có thể thêm thành viên!"
                    });
                }    
                await _chatGroupService.AddUserToGroup(groupId, userReq.Username, userReq.Role);
                await _userService.AddGroupToUser(userReq.Username, groupId);

                return Ok(new
                {
                    message = "Thêm người dùng thành công!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }

        [Authorize]
        [HttpPost("{groupId}/add-user-request")]
        public async Task<IActionResult> AddUserToGroupRequest(string groupId, [FromBody] AddUserRequest userReq)
        {
            
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var username = await _jwtService.GetUsernameFromToken(authorizationHeader);
            if (username == null)
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }

            try
            {
                var checkJoined = await _chatGroupService.IsInGroup(username, groupId);
                if (!checkJoined)
                {
                    return BadRequest(new
                    {
                        message = "Bạn chưa tham gia vào nhóm này!"
                    });
                }
                var user = await _userService.GetUserByUserName(userReq.Username);
                if (user == null)
                {
                    return NotFound(new
                    {
                        message = "Không tìm thấy người dùng!"
                    });
                }
                var checkFriend = await _userService.IsFriend(username, userReq.Username);
                if (!checkFriend)
                {
                    return BadRequest(new
                    {
                        message = "Hai bạn chưa là bạn bè nên không thể thêm vào nhóm!"
                    });
                }
                var check = await _chatGroupService.AddUserToGroupRequest(groupId, userReq.Username);
                if(!check)
                {
                    return BadRequest(new
                    {
                        message = "Người dùng đã là thành viên!"
                    });
                }    
                return Ok(new
                {
                    message = "Đã gửi request tới admin!"
                });

            }
            catch (Exception ex) 
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }

        [Authorize]
        [HttpPost("{groupId}/accept-join-req/{reqUsername}")]
        public async Task<IActionResult> AcptJoinReq(string groupId,string reqUsername)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var username = await _jwtService.GetUsernameFromToken(authorizationHeader);
            if (username == null)
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }
            try
            {
                var checkJoined = await _chatGroupService.IsInGroup(username, groupId);
                if (!checkJoined)
                {
                    return BadRequest(new
                    {
                        message = "Bạn chưa tham gia vào nhóm này!"
                    });
                }
                
                var acpt = await _chatGroupService.AcptJoinReq(groupId, reqUsername);
                if (acpt)
                {
                    return Ok(new
                    {
                        message = "Đã thêm thành viên!"
                    });
                }    
                else
                {
                    return BadRequest(new
                    {
                        message = "Không thể chấp nhận người dùng này!"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }

        [Authorize]
        [HttpPost("{groupId}/remove-join-req/{reqUsername}")]
        public async Task<IActionResult> DelJoinReq(string groupId, string reqUsername)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var username = await _jwtService.GetUsernameFromToken(authorizationHeader);
            if (username == null)
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }
            try
            {
                var checkJoined = await _chatGroupService.IsInGroup(username, groupId);
                if (!checkJoined)
                {
                    return BadRequest(new
                    {
                        message = "Bạn chưa tham gia vào nhóm này!"
                    });
                }

                var acpt = await _chatGroupService.DelJoinReq(groupId, reqUsername);
                if (acpt)
                {
                    return Ok(new
                    {
                        message = "Đã xóa yêu cầu vào nhóm!"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        message = "Không thể chấp nhận người dùng này!"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }

        //GET METHOD
        [Authorize]
        [HttpGet("get-group/{groupId}")]
        public async Task<IActionResult> GetGroupByGroupId(string groupId)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }
            var group = await _chatGroupService.GetGroupById(groupId);
            if (group == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy nhóm"
                });
            }

            return Ok(new
            {
                id = group.Id.ToString(),
                name = group.Name,
                description = group.Description,
                members = group.Members,
            });
        }

        [Authorize]
        [HttpGet("get-join-list/{groupId}")]
        public async Task<IActionResult> GetJoinList(string groupId)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var username = await _jwtService.GetUsernameFromToken(authorizationHeader);
            if (username == null)
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }
            try
            {
                var checkJoined = await _chatGroupService.IsInGroup(username, groupId);
                if (!checkJoined)
                {
                    return BadRequest(new
                    {
                        message = "Bạn chưa tham gia vào nhóm này!"
                    });
                }
                var joinReq = await _chatGroupService.GetJoinList(groupId);
                if(joinReq == null)
                {
                    return BadRequest(new
                    {
                        message = "Không tìm thấy nhóm"
                    });
                }
                return Ok(new
                {
                    message = "Lấy danh sách yêu cầu thành công!",
                    total = joinReq.Count,
                    data = joinReq
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message,
                });
            }
        }

        //DELETE METHOD
        [Authorize]
        [HttpDelete("leave-group/{groupId}")]
        public async Task<IActionResult> LeaveGroup(string groupId)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var username = await _jwtService.GetUsernameFromToken(authorizationHeader);
            if (username == null)
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }
            try
            {
                var checkJoined = await _chatGroupService.IsInGroup(username, groupId);
                if (!checkJoined)
                {
                    return BadRequest(new
                    {
                        message = "Bạn chưa tham gia vào nhóm này!"
                    });
                }
                var group = await GetGroupByGroupId(groupId);
                if (group == null)
                {
                    return NotFound(new { message = "Nhóm không tồn tại!" });
                }
                await _chatGroupService.LeaveGroup(groupId, username);
                return Ok(new
                {
                    message = "Đã rời khỏi nhóm!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {
                    message = "Internal Server Error",
                    detail = ex.Message
                });
            }
        }

    }
}
