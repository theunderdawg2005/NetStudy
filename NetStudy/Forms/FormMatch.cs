﻿using FontAwesome.Sharp;
using NetStudy.Models;
using NetStudy.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace NetStudy.Forms
{
    public partial class FormMatch : Form
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7103/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        private JObject UserInfo;
        private string accessToken;
        private List<string> friendsList = new List<string>();

        private int total;
        private int totalPages = 1;
        private int currPage = 1;
        private const int pageSize = 5;
        private UserService userService;

        public FormMatch(JObject info, string token)
        {
            InitializeComponent();
            UserInfo = info;
            accessToken = token;
            label1.Text = info["name"].ToString();
            userService = new UserService(accessToken);
            
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }
        private async void FormMatch_Load(object sender, EventArgs e)
        {
            friendsList = await LoadFriendList();
            var (user, total) = await userService.GetReqList(UserInfo["username"].ToString(), accessToken);
            btnRequest.Text = $"Friend Request ({total})";
            //await LoadFriendsRequest();
        }


        public async Task<(List<User>, int)> GetFriendRequest()
        {


            try
            {
                string username = UserInfo["username"].ToString();
                var response = await httpClient.GetAsync($"api/user/{username}/suggest-friends");
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    JObject info = JObject.Parse(res);
                    total = int.Parse(info["total"].ToString());
                    totalPages = (int)Math.Ceiling((double)total / pageSize);
                    List<User> friends = info["data"].ToObject<List<User>>();

                    return (friends, totalPages);
                }
                else
                {
                    throw new Exception($"Lỗi khi gọi API: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (new List<User>(), 0);
            }
        }
        public async Task<(List<User>, int)> GetFriendSearching(string searchString, int page = 1 ,int pageSize=5)
        {
            var username = UserInfo["username"].ToString();
            try
            {

                var response = await httpClient.GetAsync($"api/user/{username}/search?query={searchString}&page={page}&pageSize={pageSize}");
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    JObject info = JObject.Parse(res);
                    total = int.Parse(info["total"].ToString());
                    totalPages = int.Parse(info["totalPages"].ToString());
                    List<User> users = info["data"].ToObject<List<User>>();

                    return (users, totalPages);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Không tìm thấy người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return (new List<User>(), 0);
                }
                else
                {
                    throw new Exception($"Lỗi khi gọi API: {response.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (new List<User>(), 0);
            }
        }

        private async void CreatePanel(List<User> users, string username)
        {
            flowLayoutPanel1.Controls.Clear();
            

            foreach (var user in users)
            {

                var (list, total) = await userService.GetReqList(user.Username, accessToken);
                
                Panel userPanel = new Panel
                {
                    Width = flowLayoutPanel1.Width - 20,
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10),
                    Margin = new Padding(5),
                    BackColor = Color.Indigo
                };

                Label lblName = new Label
                {
                    Text = $"Tên: {user.Name}",
                    AutoSize = true,
                    Font = new Font("Cambria", 12, FontStyle.Bold),
                    ForeColor = Color.Gainsboro
                };

                Label lblEmail = new Label
                {
                    Text = $"Email: {user.Email}",
                    AutoSize = true,
                    Font = new Font("Cambria", 10),
                    ForeColor = Color.Gainsboro
                };

                IconButton btnFriend = new IconButton
                {
                    Location = new Point(1024, 20),
                    Size = new Size(150, 40),
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    BackColor = Color.FromArgb(0, 117, 214),


                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    ForeColor = Color.Gainsboro,
                };

                IconButton delBtn = new IconButton
                {
                    Location = new Point(1024, 60),
                    Size = new Size(150, 35),
                    Font = new Font("Arial", 9, FontStyle.Regular),
                    BackColor = Color.FromArgb(0, 117, 214),
                    Text = "Xóa",

                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    ForeColor = Color.Gainsboro,
                };

                LinkLabel linkDelFriend = new LinkLabel
                {
                    Location = new Point(1070, 75),
                    Size = new Size(150, 35),
                    Font = new Font("Arial", 9, FontStyle.Regular),
                    LinkColor = Color.IndianRed,
                    Text = "Xóa bạn bè",
                    Cursor = Cursors.Hand
                };

                if (IsFriend(user.Username))
                {
                    btnFriend.Text = "Đã kết bạn";

                    btnFriend.TextAlign = ContentAlignment.MiddleLeft;
                    btnFriend.TextImageRelation = TextImageRelation.ImageBeforeText;
                    btnFriend.IconChar = IconChar.Check;
                    btnFriend.IconSize = 30;
                    btnFriend.IconColor = Color.Gainsboro;
                    btnFriend.ImageAlign = ContentAlignment.MiddleLeft;
                    btnFriend.Enabled = true;
                    btnFriend.BackColor = Color.FromArgb(26, 25, 62);
                    btnFriend.ForeColor = Color.Gainsboro;
                    linkDelFriend.Click += async (sender, e) =>
                    {
                        await userService.DeleteFriend(user.Username);
                    };
                    userPanel.Controls.Add(linkDelFriend);
                }
                else if (list.Contains(username))
                {
                    btnFriend.Text = "Đã gửi";
                    btnFriend.Location = new Point(1024, 5);
                    btnFriend.Size = new Size(150, 35);
                    btnFriend.Font = new Font("Arial", 9, FontStyle.Regular);
                    btnFriend.Enabled = false;
                    btnFriend.BackColor = Color.LightYellow;
                    delBtn.Enabled = true;
                    delBtn.Click += async (sender, e) =>
                    {
                        await userService.RemoveRequest(user.Username, username, delBtn, accessToken);
                    };
                    userPanel.Controls.Add(delBtn);
                }
                else
                {
                    btnFriend.Text = "Kết bạn";
                    btnFriend.Cursor = Cursors.Hand;
                    btnFriend.Click += async (sender, e) =>
                    {
                        await userService.SendFriendRequest(username, user.Username, btnFriend, accessToken);

                    };
                }
                userPanel.Controls.Add(lblName);
                lblName.Location = new Point(10, 10);
                userPanel.Controls.Add(lblEmail);
                lblEmail.Location = new Point(10, 40);
                userPanel.Controls.Add(btnFriend);
                flowLayoutPanel1.Controls.Add(userPanel);
            }
            
        }
        private void UpdatePage(int newTotalPages)
        {
            
                comboBox1.Items.Clear();
                for (int i = 1; i <= newTotalPages; i++)
                {
                    comboBox1.Items.Add(i);
                }
                comboBox1.Enabled = newTotalPages > 1;
         
        }
        public async Task<List<string>> LoadFriendList()
        {
            string username = UserInfo["username"].ToString();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Không tìm thấy người dùng", $"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                var response = await httpClient.GetAsync($"api/user/get-friend-list/{username}");
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    var friendData = JObject.Parse(res);
                    List<string> friendList = friendData["data"].ToObject<List<string>>();

                    return friendList;
                }
                else
                {
                    MessageBox.Show("Không thể tải danh sách bạn bè.", $"Thông báo: {response.StatusCode}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<string>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bạn bè: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }
        private async Task LoadUsersSearching()
        {
            string username = UserInfo["username"].ToString();
            try
            {

                string searchString = txtSearch.Text;

                var (users, totalPages) = await GetFriendSearching(searchString, currPage ,pageSize);

                this.totalPages = totalPages;

                 CreatePanel(users, username);
                //MessageBox.Show($"totalPages: {totalPages}");

                UpdatePage(totalPages);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách người dùng: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadFriendsRequest()
        {
            string username = UserInfo["username"].ToString();
            var (friends, totalPages) = await GetFriendRequest();
            this.totalPages = totalPages;
            CreatePanel(friends, username);
            UpdatePage(totalPages);
            comboBox1.SelectedIndex = currPage;
        }
        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex >= 0)
            {
                currPage = comboBox1.SelectedIndex+1;
                await LoadUsersSearching();
            }    
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            currPage = 1;
            await LoadUsersSearching();
        }
        private bool IsFriend(string username)
        {

            if (string.IsNullOrEmpty(username) || friendsList == null)
            {
                return false;
            }

            
            return friendsList.Any(f => string.Equals(f.Trim(), username.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            AcceptFriends acpt = new AcceptFriends(UserInfo, accessToken);
            acpt.ShowDialog();
        }
    }
}
