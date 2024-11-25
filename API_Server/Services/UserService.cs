using API_Server.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API_Server.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> users;
        private readonly IMongoCollection<ChatGroup> chatGroups;    
        public UserService(MongoDbService db) {
            users = db.Users;
            chatGroups = db.ChatGroup;
        }
         
        public async Task<List<User>> GetAllUserAsync() => await users.Find(_ =>  true).ToListAsync();

        public async Task<List<User>> SearchUserAsync(string query)
        {
            var filter = Builders<User>.Filter.Or(
                    Builders<User>.Filter.Regex("Name", new BsonRegularExpression(query, "i")),
                    Builders<User>.Filter.Regex("Username", new BsonRegularExpression(query,"i")),
                    Builders<User>.Filter.Regex("Email", new BsonRegularExpression(query, "i"))
            ); 

            return await users.Find(filter).ToListAsync();
        }

        public async Task<List<User>> GetUserByGroupId(string id)
        {
            return await users.Find(u => u.ChatGroup.Contains(id)).ToListAsync();
        }
        public async Task<User> GetUserById(string id)
        {
            return await users.Find(u => u.Id.ToString() == id).FirstOrDefaultAsync();
        }
        public async Task<User> GetUserByUserName(string userName)
        {
            return await users.Find(u => u.Username == userName).FirstOrDefaultAsync();
        }
        public async Task<List<ChatGroup>> GetGroupByUserId(string userId)
        {
            return await chatGroups.Find(group => group.Members.Contains(userId)).ToListAsync();
        }

        public async Task AddGroupToUser(string userId, string groupId)
        {
            var update = Builders<User>.Update.AddToSet(u => u.ChatGroup, groupId);
            await users.UpdateOneAsync(u => u.Id.ToString() == userId, update);
        }
        public async Task<List<User>> SuggestFriendAsync(string userId)
        {
            var userFound = await users.Find(u => u.Id.ToString() == userId).FirstOrDefaultAsync();
            if (userFound == null) { return null; }

            var userGroups = userFound.ChatGroup;
            var members = await chatGroups
                .Find(g => userGroups.Contains(g.Id.ToString()))
                .Project(g => g.Members)
                .ToListAsync();
            var allMembers = members.SelectMany(m => m).Distinct().ToList();

            allMembers.Remove(userId);
            allMembers.RemoveAll(m => userFound.Friends.Contains(m));

            var suggestFriends = await users.Find(u => allMembers.Contains(u.Id.ToString())).ToListAsync();

            return suggestFriends;
        }
        public async Task<bool> AddFriend(string userId, string friendId)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id.ToString(), userId);
            var update = Builders<User>.Update.AddToSet(u => u.Friends, friendId);

            var res = await users.UpdateOneAsync(filter, update);

            return res.ModifiedCount > 0;
        }
    }
}
