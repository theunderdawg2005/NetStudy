using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetStudyMessage = NetStudy.Models.Message;
using NetStudy.Models;

namespace NetStudy.Forms
{
    public partial class FormChat : Form
    {
        private HubConnection _hubConnection;
        private string _currentUser;
        private string _currentChatUser;
        private string _accessToken;

        public FormChat(string accessToken, string username)
        {
            InitializeComponent();
            _accessToken = accessToken;
            _currentUser = username;
            textBox_myusrname.Text = _currentUser;
            InitializeSignalR();
            LoadFriends();
        }

        private async void FormChat_Load(object sender, EventArgs e)
        {
            await LoadChatHistory();
        }

        private async void InitializeSignalR()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7070/chatHub", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(_accessToken);
                })
                .Build();

            _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Invoke((Action)(() =>
                {
                    var timestamp = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
                    textBox_showmsg.AppendText($"{timestamp}: {user}: {message}{Environment.NewLine}");
                }));
            });

            _hubConnection.On<string, string>("ReceiveStatusUpdate", (username, status) =>
            {
                Invoke((Action)(() =>
                {
                    UpdateFriendStatus(username, status);
                }));
            });

            await _hubConnection.StartAsync();
        }

        private void UpdateFriendStatus(string username, string status)
        {
            foreach (Control control in groupBox_doanchat.Controls)
            {
                if (control is Label label && label.Text == username)
                {
                    label.ForeColor = status == "Đang hoạt động" ? Color.FromArgb(0, 255, 0) : Color.FromArgb(190, 190, 190);
                }
            }
        }

        private async void button_send_Click(object sender, EventArgs e)
        {
            var message = textBox_msg.Text;
            await _hubConnection.InvokeAsync("SendMessage", _currentUser, message);
            textBox_msg.Clear();
        }

        private async Task LoadChatHistory()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                var url = $"https://localhost:7070/api/chat/history?user1={_currentUser}&user2={_currentChatUser}";
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return;
                }
                var responseBody = await response.Content.ReadAsStringAsync();
                var messages = JsonSerializer.Deserialize<List<NetStudyMessage>>(responseBody);

                foreach (var message in messages)
                {
                    var timestamp = message.Timestamp.ToString("HH:mm:ss - dd/MM/yyyy");
                    textBox_showmsg.AppendText($"{timestamp}: {message.Sender}: {message.Content}{Environment.NewLine}");
                }
            }
        }

        private void LoadFriends()
        {
            // Danh sách bạn bè để test (Cần lấy từ Database ra)
            var friends = new List<(string Username, string Status)>
            {
                ("Friend1", "Đang hoạt động"),
                ("Friend2", "Ẩn hoạt động")
            };

            int yOffset = 20;
            int labelHeight = 25;

            foreach (var friend in friends)
            {
                var label = new Label
                {
                    Text = friend.Username,
                    ForeColor = friend.Status == "Đang hoạt động" ? Color.FromArgb(0, 255, 0) : Color.FromArgb(190, 190, 190),
                    AutoSize = true,
                    Location = new Point(10, yOffset)
                };
                label.Click += (s, e) => LoadChatWithUser(friend.Username, friend.Status);
                groupBox_doanchat.Controls.Add(label);

                yOffset += labelHeight;
            }
        }

        private async void LoadChatWithUser(string username, string status)
        {
            _currentChatUser = username;
            textBox_otherusrname.Text = username; // Tên của người đang chat
            textBox_otherstatus.Text = status;    // Trạng thái hoạt động của người đang chat
            textBox_showmsg.Clear();
            await LoadChatHistory();
        }

        private async void comboBox_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            var status = comboBox_mystatus.SelectedItem.ToString();
            await UpdateUserStatus(status);
        }

        private async Task UpdateUserStatus(string status)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                var url = $"https://localhost:7070/api/user/updateStatus";
                var content = new StringContent(JsonSerializer.Serialize(new { Username = _currentUser, Status = status }), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }
    }
}