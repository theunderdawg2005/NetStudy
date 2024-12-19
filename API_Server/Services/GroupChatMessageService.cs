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
        public async Task<bool> DeleteAllMessageByGroupId(string groupId)
        {
            try
            {
                var filter = Builders<GroupChatMessage>.Filter.Eq(msg => msg.GroupId, groupId);
                var result = await groupChatMessage.DeleteManyAsync(filter);

                return result.DeletedCount > 0; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa tin nhắn: {ex.Message}");
            }
        }
    }
}
