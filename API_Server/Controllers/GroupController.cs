using API_Server.Models;
using API_Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Security.Claims;

namespace API_Server.Controllers
{
    [ApiController]
    [Route("/api/groups")]
    public class GroupController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ChatGroupService _chatGroupService;
        private readonly MongoDbService _context;
        
        private readonly JwtService _jwtService;
        public GroupController(UserService userService, ChatGroupService cgs, MongoDbService context, JwtService jwtService)
        {
            _userService = userService;
            _chatGroupService = cgs;
            _context = context;
            _jwtService = jwtService;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<ActionResult<ChatGroup>> CreateGroup([FromBody] ChatGroup group)
        {
            if (!Request.Cookies.TryGetValue("accessToken", out var accessToken))
            {
                return BadRequest("Yêu cầu không hợp lệ.");
            }

            // Xác minh token và lấy username
            var claimsPrincipal = _jwtService.ValidateToken(accessToken);//Trả về giá trị người dùng của token
            if (claimsPrincipal == null)
            {
                return Unauthorized("Access token không hợp lệ!");
            }

            var userNameClaim = claimsPrincipal.FindFirst("userName");//Tìm username của token
            if (userNameClaim == null || string.IsNullOrEmpty(userNameClaim.Value))
            {
                return Unauthorized("Access token không hợp lệ !");
            }
            var user = await _context.Users.Find(u => u.Username == userNameClaim.Value).FirstOrDefaultAsync();
            // var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = user.Id.ToString();
            if (userId == null)
            {
                return NotFound("Không tìm thấy người dùng.");
            }
            group.Creator = userId;
            if (!group.Members.Contains(group.Creator))
            {
                group.Members.Add(group.Creator);
            }    

            var createdGroup = await _chatGroupService.CreateGroup(group);
            return Ok(createdGroup);
        }

        [Authorize]
        [HttpPost("{groupId}/add-user/{userId}")]
        public async Task<IActionResult> AddUserToGroup(string groupId, string userId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var group = await _chatGroupService.GetGroupById(groupId);
            if (group == null)
            {
                return NotFound("Group not found");
            }

            await _chatGroupService.AddUserToGroup(groupId, userId);
            await _userService.AddGroupToUser(userId, groupId);

            return Ok("Add usser successfully!");
        }
    }
}
