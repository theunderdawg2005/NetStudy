using API_Server.Models;
using MongoDB.Driver;

namespace API_Server.Services
{
    public class GroupService
    {
        private readonly IMongoCollection<Group> _chatGroups;
        private readonly UserService _userService;
        public GroupService(MongoDbService db, UserService userService)
        {
            _chatGroups = db.ChatGroup;
            _userService = userService;
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

        public async Task<bool> IsInGroup(string username, string groupId)
        {
            var group = await GetGroupById(groupId);
            if (group == null)
            {
                return false;
            }
            if (!group.Members.Contains(username))
            {
                return false;
            }
            return true;
        }
        // thêm user vào group
        public async Task<bool> AddUserToGroup(string groupId, string userName)
        {
            
            var isJoined = await IsInGroup(userName, groupId);
            if (isJoined)
            {
                return false;
            }
            var update = Builders<Group>.Update.AddToSet(g => g.Members, userName);
            await _chatGroups.UpdateOneAsync(g => g.Id.ToString() == groupId, update);
            return true;
        }

    }
}
