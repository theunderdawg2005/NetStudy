using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Server.Models
{
    public class ChatGroup
    {
        [BsonId]
        
        public ObjectId Id { get; set; }


        public string Name { get; set; }
        public string Description { get; set; }

        
        public string Creator { get; set; }

        // Mảng lưu các thành viên (username) trong group
        public List<string> Members { get; set; } = new List<string>();
    }
}
