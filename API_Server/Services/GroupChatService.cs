using API_Server.Models;
using MongoDB.Driver;

namespace API_Server.Services
{
    public class GroupChatService
    {
        private readonly IMongoCollection<GroupChat> groupChatMessage;
        public GroupChatService(MongoDbService db)
        {
            groupChatMessage = db.GroupChatMessage;
        }

        private async Task SendMessage(GroupChat message)
        {
            await groupChatMessage.InsertOneAsync(message);
        }

        private async Task<List<GroupChat>> GetMessage(string sender, string receiver)
        {
            var filter = Builders<GroupChat>.Filter.Or(
                Builders<GroupChat>.Filter.And(
                    Builders<GroupChat>.Filter.Eq(msg => msg.Sender, sender),
                    Builders<GroupChat>.Filter.Eq(msg => msg.Receiver, receiver)
                ),
                Builders<GroupChat>.Filter.And(
                    Builders<GroupChat>.Filter.Eq(msg => msg.Sender, receiver),
                    Builders<GroupChat>.Filter.Eq(msg => msg.Receiver, sender)
                )
            );
            return await groupChatMessage.Find(filter).SortBy(msg => msg.TimeStamp).ToListAsync();
        }
    }
}
