using NetStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetStudy.Services
{
    public class TokenService
    {
        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        private string accessToken;
        private string refreshToken;
        private string username;

        public TokenService(HttpClient httpClient)
        {
            this.httpClient = httpClient;   
        }

        public void SetTokens(string accessToken)
        {
            this.accessToken = accessToken;
            
        }
        public void AddAuthorizationHeader(HttpRequestMessage request)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            }
        }
        public async Task<bool> HandleToken()
        {
            var refreshRequest = new
            {
                RefreshToken = refreshToken,
                Username = username
            };
            var content = new StringContent(JsonSerializer.Serialize(refreshRequest), Encoding.UTF8, "application/json");
            try
            {
                var response = await httpClient.PostAsync("api/refreshToken/handle-token", content);
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    var tokenData = JsonSerializer.Deserialize<TokenData>(res);
                    if (tokenData != null)
                    {
                        accessToken = tokenData.AccessToken;
                        
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

               
            }
            return false;
        }
        public string GetAccessToken() => accessToken;
    }
}
