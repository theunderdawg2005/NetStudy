using API_Server.Models;
using API_Server.Services;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace API_Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly SingleChatService _chatService;

        public ChatHub(SingleChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(string user, string message)
        {
            var chatMessage = new SingleChat
            {
                Sender = user,
                Receiver = "ReceiverUser",
                Content = message,
                Timestamp = DateTime.UtcNow
            };

            await _chatService.SendMessageAsync(chatMessage);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task UpdateStatus(string username, string status)
        {
            await Clients.All.SendAsync("ReceiveStatusUpdate", username, status);
        }
    }
}