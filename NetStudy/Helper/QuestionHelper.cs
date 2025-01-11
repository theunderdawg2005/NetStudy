using Microsoft.Win32.SafeHandles;
using NetStudy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudy.Helper
{
    public class QuestionHelper
    {

        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7103/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        private string accesstoken;
        private ChatBotService _chatBotService;
        public QuestionHelper(string token) 
        {
            accesstoken = token;
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accesstoken);
            _chatBotService = new ChatBotService(accesstoken);
        }

        public async Task<List<string>> GenerateFakeAnswers(string content)
        {
            try
            {
                string prompt = $"Tạo 3 câu trả lời sai liên quan đến: {content}. " +
                "Nếu đáp án đúng là số, sinh ra số ngẫu nhiên gần với đáp án đúng. " +
                "Nếu đáp án đúng là chữ cái, sinh ra chữ cái ngẫu nhiên gần với đáp án đúng. " +
                "Lưu ý đặc biệt: Nếu là số, không sinh ra chữ. Nếu là chữ, không sinh ra số. " +
                "Chỉ trả về kết quả, không giải thích, không chấm câu, không đánh số, không trùng với đáp án đúng.";

                var response = await _chatBotService.Chat(prompt);
                {
                    var fakeAnswers = response.Response
                        .Trim()
                        .Split('\n')
                        .Select(answer => answer.Trim())
                        .Where(answer => !string.IsNullOrWhiteSpace(answer))
                        .ToList();

                    return fakeAnswers;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate fake answers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
    }
}
