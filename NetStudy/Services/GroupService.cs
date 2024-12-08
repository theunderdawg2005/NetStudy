using NetStudy.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        


        public async Task AddUserToGroup(string groupId, string username)
        {
            try
            {
                var reqBody = new
                {
                    Username = username
                };
                var json = JsonConvert.SerializeObject(reqBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"api/groups/{groupId}/add-user", content);
                var res = await response.Content.ReadAsStringAsync();
                if(response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }  
                else
                {
                    var errorMessage = JObject.Parse(res)["message"]?.ToString();
                    MessageBox.Show(errorMessage ?? "Failed to add user to group.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public async Task<GroupMessage> SendMessage(string groupId, StringContent content)
        //{
        //    try
        //    {
        //        var response = await _httpClient.PostAsync($"api/group-chat-message/send", content);
        //        var res = await response.Content.ReadAsStringAsync();
        //        JObject message = JObject.Parse(res);
                

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public async Task<List<GroupMessage>> LoadMessageByGroupId(string groupId)
        {

            try
            {
                var response = await _httpClient.GetAsync($"api/group-chat-message/get-messages?groupId={groupId}");
                var res = await response.Content.ReadAsStringAsync();
                JObject messageInfo = JObject.Parse(res);
                var message = messageInfo["data"].ToObject<List<GroupMessage>>();
                return message;
            }
            catch (Exception ex)
            {

                return new List<GroupMessage>();
            }
        }
    }
}
