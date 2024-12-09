using API_Server.DTOs;
using API_Server.Models;
using MongoDB.Driver;

namespace API_Server.Services
{
    public class QuestionService
    {
        private readonly IMongoCollection<Question> _questions;

        public QuestionService(MongoDbService context)
        {
            _questions = context.Questions;
        }

        public async Task<QuestionDTO> CreateQuestionAsync(QuestionDTO questionDTO)
        {
            var question = new Question
            {
                Title = questionDTO.Title,
                Content = questionDTO.Content,
                CorrectAnswer = questionDTO.CorrectAnswer,
                Owner = questionDTO.Owner
            };

            await _questions.InsertOneAsync(question);

            var questionDto = new QuestionDTO
            {
                Title = question.Title,
                Content = question.Content,
                CorrectAnswer = question.CorrectAnswer,
                Owner = question.Owner
            };
            return questionDto;
        }

        public async Task<bool> IsTitleExistsAsync(string title)
        {
            var filter = Builders<Question>.Filter.Eq(q => q.Title, title);
            var existingQuestion = await _questions.Find(filter).FirstOrDefaultAsync();
            return existingQuestion != null;
        }

        public async Task<QuestionDTO> GetQuestionAsync(string title)
        {
            var question = await _questions.Find(q => q.Title.Equals(title)).FirstOrDefaultAsync();
            if (question == null)
            {
                return null;
            }

            var questionDto = new QuestionDTO
            {
                Title = question.Title,
                Content = question.Content,
            };
            return questionDto;
        }

        public async Task<string> GetCorrectAnswer(string title)
        {
            var question = await _questions.Find(q => q.Title.Equals(title)).FirstOrDefaultAsync();
            if (question == null)
            {
                return null;
            }

            return question.CorrectAnswer;
        }

    }
}
