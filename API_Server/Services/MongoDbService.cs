using API_Server.Models;
using MongoDB.Driver;

namespace API_Server.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _db;

        public MongoDbService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("DB_AWS"));
            _db = client.GetDatabase("Net_Study");
        }

        public IMongoCollection<User> Users => _db.GetCollection<User>("User");
        public IMongoCollection<TokenData> Tokens => _db.GetCollection<TokenData>("TokenData");
        public IMongoCollection<Group> ChatGroup => _db.GetCollection<Group>("ChatGroup");
        public IMongoCollection<SingleChat> Messages => _db.GetCollection<SingleChat>("Messages");
        public IMongoCollection<GroupChatMessage> GroupChatMessage => _db.GetCollection<GroupChatMessage>("GroupChatMessage");
        public IMongoCollection<Question> Questions => _db.GetCollection<Question>("Questions");
    }
}
