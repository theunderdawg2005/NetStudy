using NetStudy.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudy.Services
{
    public class ChatBotService
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7103/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        private string accessToken;
        public ChatBotService(string token)
        {
            accessToken = token;
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }
        public async Task<ResponseData> Chat(string message)
        {
            var response = await httpClient.PostAsync("api/chatbot/chat", new StringContent(JsonConvert.SerializeObject(new { message }), Encoding.UTF8, "application/json"));
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var responseData = JsonConvert.DeserializeObject<ResponseData>(content);
                return responseData;
            }
            else
            {
                var errorResponse = JsonConvert.DeserializeObject<ResponseData>(content);
                return errorResponse;
            }
        }
    }
}
