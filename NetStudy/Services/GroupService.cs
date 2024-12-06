﻿using NetStudy.Models;
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
            BaseAddress = new Uri("https://localhost:7070/")
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
    }
}
