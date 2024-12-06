using API_Server.Models;
using API_Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
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
        [HttpPost("{groupId}/add-user/{username}")]
        public async Task<IActionResult> AddUserToGroup(string groupId, string username)
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
                var user = await _userService.GetUserByUserName(username);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                var group = await _chatGroupService.GetGroupById(groupId);
                if (group == null)
                {
                    return NotFound("Group not found");
                }

                await _chatGroupService.AddUserToGroup(groupId, username);
                await _userService.AddGroupToUser(username, groupId);

                return Ok("Add usser successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
