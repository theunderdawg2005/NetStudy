using NetStudy.Models;
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
            BaseAddress = new Uri(@"https://localhost:7070/")
        };
        private JObject UserInfo;
        private string accessToken;
        private static JArray friends;
        private JArray userSearching;
        private int total;
        private int totalPages = 1;
        private int currPage = 1;
        private const int pageSize = 2;
        public FormMatch(JObject info, string token)
        {
            InitializeComponent();
            UserInfo = info;
            accessToken = token;
            label1.Text = info["name"].ToString();
        }

        public async Task<(List<User>, int)> GetFriendRequest()
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            }

            try
            {
                string userId = UserInfo["id"].ToString();
                var response = await httpClient.GetAsync($"api/user/{userId}/suggest-friends");
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
        public async Task<(List<User>, int)> GetFriendSearching(string searchString, int pageSize)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            }

            try
            {

                var response = await httpClient.GetAsync($"api/user/search?query={searchString}");
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    JObject info = JObject.Parse(res);
                    total = int.Parse(info["total"].ToString());
                    totalPages = (int)Math.Ceiling((double)total / pageSize);
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

        private void CreatePanel(List<User> users)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var user in users)
            {
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

                userPanel.Controls.Add(lblName);
                lblName.Location = new Point(10, 10);
                userPanel.Controls.Add(lblEmail);
                lblEmail.Location = new Point(10, 40);

                flowLayoutPanel1.Controls.Add(userPanel);
            }
        }
        private void UpdatePage(int totalPages)
        {
            comboPage.Items.Clear();
            for (int i = 1; i <= totalPages; i++)
            {
                comboPage.Items.Add(i);
            }

            comboPage.Enabled = totalPages > 1;
        }
        private async Task LoadUsers()
        {
            string searchString = txtSearch.Text;

            var (users, totalPages) = await GetFriendSearching(searchString, pageSize);

            this.totalPages = totalPages;

            CreatePanel(users);

            UpdatePage(totalPages);

            comboPage.SelectedIndex = currPage - 1;
        }

        private async Task LoadFriends()
        {
            var (friends, totalPages) = await GetFriendRequest();
            this.totalPages = totalPages;
            CreatePanel(friends);
            UpdatePage(totalPages);
            comboPage.SelectedIndex = currPage - 1;
        }
        private void panelDesk_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text.Length == 0)
            {
                if (comboPage.SelectedIndex >= 0)
                {
                    currPage = comboPage.SelectedIndex + 1;
                    await LoadFriends();
                }
            }
            else
            {
                if (comboPage.SelectedIndex >= 0)
                {
                    currPage = comboPage.SelectedIndex + 1;
                    await LoadUsers();
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            currPage = 1;
            await LoadUsers();
        }
    }
}
