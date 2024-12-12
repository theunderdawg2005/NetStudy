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
                groupModel.Members.Add(username);
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
            var accessToken = authorizationHeader.Substring("Bearer ".Length).Trim();
            var claimsPrincipal = _jwtService.ValidateToken(accessToken);//Trả về giá trị người dùng của token
            if (claimsPrincipal == null)
            {
                return Unauthorized("Yêu cầu không hợp lệ!");
            }

            var usernameClaim = claimsPrincipal.FindFirst("userName");//Tìm username của token
            if (usernameClaim == null || string.IsNullOrEmpty(usernameClaim.Value))
            {
                return Unauthorized("Yêu cầu không hợp lệ!");
            }

            var username = usernameClaim.Value;


            try
            {
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

                await _chatGroupService.AddUserToGroup(groupId, userReq.Username);
                await _userService.AddGroupToUser(userReq.Username, groupId);

                return Ok(new
                {
                    message = "Thêm người dùng thành công!"
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
                description = group.Description
            });
        }

        //DELETE METHOD
        [Authorize]
        [HttpDelete("leave-group/{groupId}")]
        public async Task<IActionResult> LeaveGroup(string groupId)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var accessToken = authorizationHeader.Substring("Bearer ".Length).Trim();
            var claimsPrincipal = _jwtService.ValidateToken(accessToken);//Trả về giá trị người dùng của token
            if (claimsPrincipal == null)
            {
                return Unauthorized("Yêu cầu không hợp lệ!");
            }

            var usernameClaim = claimsPrincipal.FindFirst("userName");
            if (usernameClaim == null || string.IsNullOrEmpty(usernameClaim.Value))
            {
                return Unauthorized("Yêu cầu không hợp lệ!");
            }

            var username = usernameClaim.Value;

            try
            {
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
