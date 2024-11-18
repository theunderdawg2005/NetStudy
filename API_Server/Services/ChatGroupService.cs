using API_Server.Models;
using MongoDB.Driver;

namespace API_Server.Services
{
    public class ChatGroupService
    {
        private readonly IMongoCollection<ChatGroup> _chatGroups;
        public ChatGroupService(MongoDbService db)
        {
            _chatGroups = db.ChatGroup;
        }

        public async Task<ChatGroup> CreateGroup(ChatGroup chatGroup)
        {
             await _chatGroups.InsertOneAsync(chatGroup);
            return chatGroup;
        }

        public async Task<ChatGroup> GetGroupById(string groupId)
        {
            return await _chatGroups.Find(g => g.Id.ToString() == groupId).FirstOrDefaultAsync();
        }

        // thêm user vào group
        public async Task AddUserToGroup(string groupId, string userId)
        {
            var update = Builders<ChatGroup>.Update.AddToSet(g => g.Members, userId);
            await _chatGroups.UpdateOneAsync(g => g.Id.ToString() == groupId, update);
        }

    }
}
