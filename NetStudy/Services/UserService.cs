using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetStudy.Services
{
    
    public class UserService
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        //private string accessToken;
        public UserService() {
            
        }    

        public async Task<string> Login(dynamic loginModel)
        {
            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/user/login", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Register(dynamic registerModel)
        {
            try
            {
                var json = JsonConvert.SerializeObject(registerModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("api/user/register", content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public async Task<HttpResponseMessage> VerifyOtp(dynamic otpModel)
        {
     
                var json = JsonConvert.SerializeObject(otpModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                return await httpClient.PostAsync("api/user/Verify-Otp", content);
        }

        public async Task SendFriendRequest(string username,string targetUsername, Button btn, string token)
        {
            if(!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }    
            else
            {
                MessageBox.Show("Bad Request", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                var response = await httpClient.PostAsync($"api/user/add-friend/{username}/{targetUsername}", null);
                if(response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Gửi yêu cầu kết bạn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn.Text = "Đã gửi";
                    btn.Enabled = false;
                    btn.BackColor = Color.LightYellow;
                }    
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi: {error}", "Thông báo 123", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi yêu cầu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
            
    }
}
