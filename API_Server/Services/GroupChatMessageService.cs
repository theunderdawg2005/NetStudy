using API_Server.Models;
using MongoDB.Driver;

namespace API_Server.Services
{
    public class GroupChatMessageService
    {
        private readonly IMongoCollection<GroupChatMessage> groupChatMessage;
        public GroupChatMessageService(MongoDbService db)
        {
            groupChatMessage = db.GroupChatMessage;
        }

        public async Task SendMessage(GroupChatMessage message)
        {
            await groupChatMessage.InsertOneAsync(message);
        }
          
        public async Task<List<GroupChatMessage>> GetMessageByGroupId(string groupId)
        {
            var filter = Builders<GroupChatMessage>.Filter.Eq(gr => gr.GroupId, groupId);
            return await groupChatMessage.Find(filter).SortBy(msg => msg.TimeStamp).ToListAsync();
        }
        
    }
}
