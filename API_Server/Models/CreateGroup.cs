using System.ComponentModel.DataAnnotations;

namespace API_Server.Models
{
    public class CreateGroup
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
