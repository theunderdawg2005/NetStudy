using API_Server.Models;
using API_Server.Services;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
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

        public async Task SendMessage(string sender, string receiver, string message)
        {
            var chatMessage = new SingleChat
            {
                Sender = sender,
                Receiver = receiver,
                Content = message,
                Timestamp = DateTime.UtcNow
            };

            await _chatService.SendMessageAsync(chatMessage);
            await Clients.User(receiver).SendAsync("ReceiveMessage", sender, message);
        }
        public async Task<List<SingleChat>> GetChatHistory(string user1, string user2)
        {
            return await _chatService.GetMessagesAsync(user1, user2);
        }

        public async Task UpdateStatus(string username, string status)
        {
            await Clients.All.SendAsync("ReceiveStatusdate", username, status);
        }
    }
}