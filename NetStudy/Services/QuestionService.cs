using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using NetStudy.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetStudy.Services
{
    public class QuestionService
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        private string accessToken;
        public QuestionService(string token)
        {
            accessToken = token;
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }

        public async Task<ApiResponse<Question>> CreateQuestion(Question question, string username)
        {
            try
            {
                var response = await httpClient.PostAsync($"api/questions/{username}/create-question", new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json"));
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var createdQuestion = JsonConvert.DeserializeObject<Question>(content);
                    return new ApiResponse<Question>
                    {
                        Message = "Tạo câu hỏi thành công!",
                        Data = createdQuestion
                    };
                }
                else
                {
                    return new ApiResponse<Question>
                    {
                        Message = content
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<Question>
                {
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        public async Task<string> GetQuestions(string username, string content)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/question/{username}/get-question/{content}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return error;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<ApiResponse<List<QuestionDto>>> GetAllQuestionAsync(string username)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/questions/{username}/get-all-questions");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseWrapper<List<QuestionDto>>>(content);

                    if (apiResponse != null && apiResponse.Info != null)
                    {
                        return new ApiResponse<List<QuestionDto>>
                        {
                            Message = apiResponse.Message,
                            Data = apiResponse.Info
                        };
                    }

                    return new ApiResponse<List<QuestionDto>>
                    {
                        Message = "No questions found.",
                        Data = new List<QuestionDto>()
                    };
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return new ApiResponse<List<QuestionDto>>
                    {
                        Message = $"Error: {errorContent}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<QuestionDto>>
                {
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<QuestionDto>> GetRandomQuestionsAsync(string username)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/questions/{username}/get-random-question");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseWrapper<QuestionDto>>(content);

                    return new ApiResponse<QuestionDto>
                    {
                        Message = apiResponse.Message,
                        Data = apiResponse.Info
                    };
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {errorContent}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<ApiResponse<QuestionDto>> GetRandomQuestionByTopic(string username, string topic)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/questions/{username}/get-random-question/{topic}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseWrapper<QuestionDto>>(content);

                    return new ApiResponse<QuestionDto>
                    {
                        Message = apiResponse.Message,
                        Data = apiResponse.Info
                    };
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {errorContent}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<ApiResponse<List<QuestionDto>>> GetAllQuestionByTopicAsync(string username, string topic)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/questions/{username}/get-all-questions/{topic}");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseWrapper<List<QuestionDto>>>(content);

                    if (apiResponse != null && apiResponse.Info != null)
                    {
                        return new ApiResponse<List<QuestionDto>>
                        {
                            Message = apiResponse.Message,
                            Data = apiResponse.Info
                        };
                    }

                    return new ApiResponse<List<QuestionDto>>
                    {
                        Message = "No questions found.",
                        Data = new List<QuestionDto>()
                    };
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return new ApiResponse<List<QuestionDto>>
                    {
                        Message = $"Error: {errorContent}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<QuestionDto>>
                {
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<string> GetCorrectAnswer(string username, string content)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/question/{username}/get-correct-answer/{content}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return error;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public class ApiResponse<T>
        {
            public T Data  { get; set; }
            public string Message { get; set; } 
        }

        public class ApiResponseWrapper<T>
        {
            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("info")]
            public T Info { get; set; }
        }

    }
}
