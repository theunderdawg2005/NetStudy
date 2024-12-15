using System.ComponentModel.DataAnnotations;

namespace API_Server.Models
{
    public class AddUserRequest
    {
        [Required]
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
