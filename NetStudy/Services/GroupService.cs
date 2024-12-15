using NetStudy.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetStudy.Services
{

    public class GroupService
    {
        private HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/")
        };
        private string accessToken;
        public GroupService(string token)
        {
            accessToken = token;
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }
        public async Task<List<Group>> LoadGroups(string username)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/user/{username}/get-groups");
                var res = await response.Content.ReadAsStringAsync();
                JObject info = JObject.Parse(res);
                if (response.IsSuccessStatusCode)
                {
                    var groups = info["data"].ToObject<List<Group>>();
                    if(groups != null && groups.Any())
                    {
                        var teamGroups = groups.ToList();
                        return teamGroups;
                    }    
                    else
                    {
                        MessageBox.Show("Bạn chưa tham gia vào nhóm nào!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }    
                else
                {
                    var errorMessage = JObject.Parse(res)["message"]?.ToString();
                    MessageBox.Show(errorMessage ?? "Không thể tải nhóm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        
        public async Task<HttpResponseMessage> CreateGroup(string username, string groupName, string description)
        {
            try
            {
                var group = new Group
                {
                    Name = groupName,
                    Description = description
                };
                var json = JsonConvert.SerializeObject(group);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                return await _httpClient.PostAsync($"api/groups/{username}/create", content);
                
                       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        


        public async Task<bool> AddUserToGroup(string groupId, string username, string role)
        {
            try
            {
                  
                var reqBody = new
                {
                    Username = username,
                    Role = role
                };
                var json = JsonConvert.SerializeObject(reqBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"api/groups/admin/{groupId}/add-user", content);
                var res = await response.Content.ReadAsStringAsync();
                if(response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }  
                else
                {
                    var errorMessage = JObject.Parse(res)["message"]?.ToString();
                    MessageBox.Show(errorMessage ?? "Failed to add user to group.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public async Task<bool> AddUserToGroupRequest(string groupId, string username)
        {
            try
            {
                var reqBody = new
                {
                    Username = username,
                    Role = "User"
                };
                var json = JsonConvert.SerializeObject(reqBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"api/groups/{groupId}/add-user-request", content);
                var res = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã gửi yêu cầu thêm thành viên!", "Thông báo" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    var errorMessage = JObject.Parse(res)["message"]?.ToString();
                    MessageBox.Show(errorMessage ?? "Failed to add user to group.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public async Task SendMessage(string groupId, string user, string message, DateTime timestamp)
        {
            try
            {
                
                var newMsg = new GroupMessage
                {
                    Sender = user,
                    GroupId = groupId,
                    Content = message,
                    TimeStamp = DateTime.UtcNow
                };
                var json = JsonConvert.SerializeObject(newMsg);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"api/group-chat-message/send", content);
                var res = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    var error = JObject.Parse(res)["message"]?.ToString();   
                    MessageBox.Show(error, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public async Task<List<GroupMessage>> LoadMessageByGroupId(string groupId)
        {

            try
            {
                var response = await _httpClient.GetAsync($"api/group-chat-message/get-messages?groupId={groupId}");
                var res = await response.Content.ReadAsStringAsync();
                JObject messageInfo = JObject.Parse(res);
                var messages = messageInfo["data"].ToObject<List<GroupMessage>>();
                return messages;
            }
            catch (Exception ex)
            {

                return new List<GroupMessage>();
            }
        }

        public async Task<(List<string>, int)> GetJoinListByGroupId(string groupId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/groups/get-join-list/{groupId}");
                var res = await response.Content.ReadAsStringAsync();
                JObject info = JObject.Parse(res);
                var reqs = info["data"].ToObject<List<string>>();
                var total = int.Parse(info["total"].ToString());
                if (response.IsSuccessStatusCode)
                {
                    return (reqs,total);
                }
                else
                {
                    var error = info["message"].ToString();
                    MessageBox.Show(error, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (new List<string>(),0);
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (new List<string>(), 0);
            }
        }
        public async Task AcptJoinReq(string groupId, string reqUser)
        {
            try
            {
                var response = await _httpClient.PostAsync($"api/groups/{groupId}/accept-join-req/{reqUser}", null);
                var res = await response.Content.ReadAsStringAsync();
                JObject msg = JObject.Parse(res);
                MessageBox.Show(msg["message"].ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public async Task DelJoinReq(string groupId, string reqUser)
        {
            try
            {
                var response = await _httpClient.PostAsync($"api/groups/{groupId}/remove-join-req/{reqUser}", null);
                var res = await response.Content.ReadAsStringAsync();
                JObject msg = JObject.Parse(res);
                MessageBox.Show(msg["message"].ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
            public async Task LeaveGroup(string groupId, string username)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/groups/leave-group/{groupId}");
                var res = await response.Content.ReadAsStringAsync();
                JObject obj = JObject.Parse(res);
                var msg = obj["message"].ToString();
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
