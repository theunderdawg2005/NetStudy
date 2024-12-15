using API_Server.DTOs;
using API_Server.Models;
using MongoDB.Driver;
using UglyToad.PdfPig;
using System.Text.Json;
using System.Net.Http;
using System.Collections.Concurrent;
using System.Net.WebSockets;


namespace API_Server.Services
{
    public class QuestionService
    {
        private readonly IMongoCollection<ListQuestion> _questions;

        public QuestionService(MongoDbService context, HttpClient httpClient)
        {
            _questions = context.ListQuestions;
        }

        public async Task<QuestionDTO> CreateQuestionAsync(Question _question, string owner)
        {
            var question = new Question
            {
                Title = _question.Title,
                Content = _question.Content,
                CorrectAnswer = _question.CorrectAnswer,
                Owner = owner,
            };

            var listQuestion = new ListQuestion
            {
                Owner = question.Owner,
                Questions = new List<Question> { question }
            };

            var filter = Builders<ListQuestion>.Filter.Eq(q => q.Owner, owner);
            var listQuestionExists = await _questions.Find(filter).FirstOrDefaultAsync();

            if (listQuestionExists != null)
            {
                var update = Builders<ListQuestion>.Update.PushEach(q => q.Questions, listQuestion.Questions);
                await _questions.UpdateOneAsync(filter, update);
            }
            else 
            {
                await _questions.InsertOneAsync(listQuestion);
            }

            var questionDto = new QuestionDTO
            {
                Title = question.Title,
                Content = question.Content,
                CorrectAnswer = question.CorrectAnswer
            };

            return questionDto;
        }

        public async Task<bool> IsTitleExistsAsync(string title, string owner)
        {
            var filter = Builders<ListQuestion>.Filter.And(
                        Builders<ListQuestion>.Filter.Eq(q => q.Owner, owner), 
                        Builders<ListQuestion>.Filter.ElemMatch(q => q.Questions, q => q.Title == title) 
            );

            var result = await _questions.Find(filter).FirstOrDefaultAsync();
            if(result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<QuestionDTO> GetQuestionAsync(string title, string owner)
        {
            //var filter = Builders<ListQuestion>.Filter.ElemMatch(q => q.Questions, q => q.Title == title);
            var filter = Builders<ListQuestion>.Filter.And(
                        Builders<ListQuestion>.Filter.Eq(q => q.Owner, owner),
                        Builders<ListQuestion>.Filter.ElemMatch(q => q.Questions, q => q.Title == title)
            );
            var listQuestion = await _questions.Find(filter).FirstOrDefaultAsync();
            if (listQuestion != null)
            {
                var questionDto = new QuestionDTO
                {
                    Title = listQuestion.Questions[0].Title,
                    Content = listQuestion.Questions[0].Content,
                    CorrectAnswer = listQuestion.Questions[0].CorrectAnswer
                };
                return questionDto;
            }
            return null;
        }

        public async Task<QuestionDTO> GetRandomQuestionAsync(string owner)
        {
            var filter = Builders<ListQuestion>.Filter.Eq(q => q.Owner, owner);
            var listQuestion = await _questions.Find(filter).FirstOrDefaultAsync();

            if (listQuestion != null && listQuestion.Questions.Any())
            {
                var random = new Random();
                var randomQuestion = listQuestion.Questions[random.Next(listQuestion.Questions.Count)];

                var questionDto = new QuestionDTO
                {
                    Title = randomQuestion.Title,
                    Content = randomQuestion.Content,
                    CorrectAnswer = randomQuestion.CorrectAnswer
                };

                return questionDto;
            }

            return null;

        }

        public async Task<List<QuestionDTO>> GetAllQuestionsAsync(string owner)
        {
            var filter = Builders<ListQuestion>.Filter.Eq(q => q.Owner, owner);

            var listQuestion = await _questions.Find(filter).FirstOrDefaultAsync();

            if (listQuestion?.Questions == null)
            {
                return new List<QuestionDTO>(); 
            }

            return listQuestion.Questions.Select(question => new QuestionDTO
            {
                Title = question.Title,
                Content = question.Content,
                CorrectAnswer = question.CorrectAnswer
            }).ToList();
        }

        public async Task<string> GetCorrectAnswer(string title, string owner)
        {
            var question = await GetQuestionAsync(title, owner);
            return question.CorrectAnswer;
        }

    }
}
