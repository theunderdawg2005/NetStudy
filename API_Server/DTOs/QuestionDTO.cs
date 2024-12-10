using API_Server.Models;

namespace API_Server.DTOs
{
    public class QuestionDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CorrectAnswer { get; set; }

    }
}
