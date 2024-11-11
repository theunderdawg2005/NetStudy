namespace API_Server.Models
{
    public class Register
    {
        public string? Name { get; set; }
        public string? Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }   
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
