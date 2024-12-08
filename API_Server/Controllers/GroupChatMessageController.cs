using API_Server.Models;
using API_Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Server.Controllers
{
    [ApiController]
    [Route("/api/group-chat-message")]
    public class GroupChatMessageController : ControllerBase
    {
        private readonly GroupChatMessageService groupChatMsgService;
        private readonly JwtService _jwtService;
        public GroupChatMessageController(GroupChatMessageService gcms, JwtService jt) 
        {
            groupChatMsgService = gcms;
            _jwtService = jt;
        }

        [Authorize]
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendGroupMessage msgModel)
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
                
                var message = new GroupChatMessage
                {
                    Sender = msgModel.Sender,
                    GroupId = msgModel.GroupId,
                    Content = msgModel.Content,
                    TimeStamp = DateTime.UtcNow
                };

                await groupChatMsgService.SendMessage(message);
                return Ok(new
                {
                    message = "Gửi tin nhắn thành công!",
                    data = message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Gửi tin nhắn thất bại!"
                });
            }


        }

        [Authorize]
        [HttpGet("get-messages")]
        public async Task<IActionResult> GetMessageByGroupId([FromQuery]string groupId)
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
                var msgs = await groupChatMsgService.GetMessageByGroupId(groupId);
                
                var res = msgs.Select(m => new
                {
                    id = m.Id.ToString(),
                    sender = m.Sender,
                    groupId = m.GroupId,
                    content = m.Content,
                    timeStamp = m.TimeStamp
                }
                );

                return Ok(new
                {
                    message = "Lấy tin nhắn thành công!",
                    total = msgs.Count,
                    data = res
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
    }
}
