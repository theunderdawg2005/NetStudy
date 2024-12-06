using API_Server.Models;
using MongoDB.Driver;

namespace API_Server.Services
{
    public class GroupService
    {
        private readonly IMongoCollection<Group> _chatGroups;
        public GroupService(MongoDbService db)
        {
            _chatGroups = db.ChatGroup;
        }

        public async Task<Group> CreateGroup(Group chatGroup)
        {
             await _chatGroups.InsertOneAsync(chatGroup);
            return chatGroup;
        }

        public async Task<Group> GetGroupById(string groupId)
        {
            return await _chatGroups.Find(g => g.Id.ToString() == groupId).FirstOrDefaultAsync();
        }

        public async Task<Group> GetGroupByName(string groupName)
        {
            return await _chatGroups.Find(g => g.Name == groupName).FirstOrDefaultAsync();
        }

        // thêm user vào group
        public async Task AddUserToGroup(string groupId, string userName)
        {
            var update = Builders<Group>.Update.AddToSet(g => g.Members, userName);
            await _chatGroups.UpdateOneAsync(g => g.Id.ToString() == groupId, update);
        }

    }
}
