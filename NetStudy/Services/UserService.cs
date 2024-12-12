using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NetStudy.Models;
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
        private string accessToken;
        public UserService(string token) {
            accessToken = token;
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }    

        public async Task<string> Login(dynamic loginModel)
        {
            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/user/login", content);

            return await response.Content.ReadAsStringAsync();
        }

        

        public async Task<bool> SendFriendRequest(string username,string targetUsername,Button btnFriend, string token)
        {
            
            try
            {
                var response = await httpClient.PostAsync($"api/user/{username}/add-friend/{targetUsername}", null);
                if(response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Gửi yêu cầu kết bạn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnFriend.Text = "Đã gửi";
                    btnFriend.Enabled = false;
                    btnFriend.BackColor = Color.LightYellow;
                    return true;
                }    
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi: {error}", "Thông báo 123", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi yêu cầu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<User> GetUserByUsername(string username)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/user/{username}");
                var res = await response.Content.ReadAsStringAsync();
                JObject userInfo = JObject.Parse(res);

                if (response.IsSuccessStatusCode)
                {
                    var user = userInfo["userFound"].ToObject<User>();
                    return user;
                }
                else
                {
                    var error = userInfo["message"].ToString();
                    MessageBox.Show(error, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...GetUser", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<(List<string>,int)> GetReqList(string username, string token)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/user/get-request-list/{username}");
                var res = await response.Content.ReadAsStringAsync();
                var info = JObject.Parse(res);
                if (response.IsSuccessStatusCode)
                {
                    
                    List<string> reqList = info["data"].ToObject<List<string>>();
                    int total = int.Parse(info["total"].ToString());
                    return (reqList,total);
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return (new List<string>(), 0);
                }    
                else
                {
                    var error = info["message"].ToString();
                    MessageBox.Show(error, $"Thông báo: {response.StatusCode}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (new List<string>(), 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...GetReqList", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (new List<string>(), 0);
            }
        }

        public async Task AcceptRequest(string username, string requestUsername, Button btnAcptFriend, string accessToken)
        {
            try
            {
                var response = await httpClient.PostAsync($"api/user/{username}/accept-request/{requestUsername}", null);
                
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Chấp nhận kết bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnAcptFriend.Text = "Đã chấp nhận";
                    btnAcptFriend.ForeColor = Color.Gainsboro;
                    return;
                }
                else
                {
                    MessageBox.Show("Không được rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show($"Lỗi khi gửi yêu cầu: {e.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }
        }

        

        public async Task RemoveRequest(string username, string reqUsername, Button btn, string accessToken)
        {
            try
            {
                var res = await httpClient.DeleteAsync($"api/user/{username}/remove-request/{reqUsername}");
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn.Text = "Đã xóa";
                    btn.ForeColor = Color.Gainsboro;
                    return;
                }
                else if(res.StatusCode == System.Net.HttpStatusCode.Unauthorized) 
                {
                    MessageBox.Show("Không xác thực được rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show($"Lỗi: {res.StatusCode}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Lỗi khi gửi yêu cầu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        } 
        
        public async Task DeleteFriend( string friendName)
        {
            try
            {
                var res = await httpClient.DeleteAsync($"api/user/delete-friend/{friendName}");
                var resp = await res.Content.ReadAsStringAsync();
                JObject obj = JObject.Parse(resp);
                var msg = obj["message"].ToString();
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    
                    MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi yêu cầu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
    }
}
