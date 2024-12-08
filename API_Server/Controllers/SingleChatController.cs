using API_Server.Models;
using API_Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API_Server.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class SingleChatController : ControllerBase
    {
        private readonly SingleChatService _chatService;

        public SingleChatController(SingleChatService chatService)
        {
            _chatService = chatService;
        }

        // API to send a message
        [Authorize]
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessage chatMessage)
        {
            if (chatMessage == null || string.IsNullOrEmpty(chatMessage.Sender) || string.IsNullOrEmpty(chatMessage.Receiver) || string.IsNullOrEmpty(chatMessage.Content))
            {
                return BadRequest("Invalid message information.");
            }

            var message = new SingleChat
            {
                Sender = chatMessage.Sender,
                Receiver = chatMessage.Receiver,
                Content = chatMessage.Content,
                Timestamp = DateTime.UtcNow
            };

            await _chatService.SendMessageAsync(message);

            return Ok("Message sent successfully.");
        }

        // API to get chat history
        [HttpGet("history")]
        public async Task<IActionResult> GetChatHistory([FromQuery] string user1, [FromQuery] string user2)
        {
            var messages = await _chatService.GetMessagesAsync(user1, user2);
            return Ok(messages);
        }
    }
}