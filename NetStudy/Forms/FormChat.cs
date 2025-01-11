using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetStudy.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NetStudy.Services;
using Org.BouncyCastle.Tls;

namespace NetStudy.Forms
{
    public partial class FormChat : Form
    {
        private HubConnection _hubConnection;
        private string _currentUser;
        private string _currentChatUser;
        private string _accessToken;
        private string _key;
        private readonly AesService _aesService;
        private readonly RsaService _rsaService;
        private readonly UserService _userService;
        private readonly SingleChatService singleChatService;
        private string aesKey;

        public FormChat(string accessToken, string username, string key)
        {
            InitializeComponent();
            CustomizeGroupBox();
            _accessToken = accessToken;
            singleChatService = new SingleChatService(accessToken);
            _aesService = new AesService();
            _rsaService = new RsaService();
            _userService = new UserService();
            _currentUser = username;
            _key = key;
            aesKey = _aesService.GenerateAesKey();
            textBox_myusrname.Text = _currentUser;
            InitializeSignalR();
            LoadFriends();
            comboBox_mystatus.SelectedItem = "Đang hoạt động";
        }

        private async void FormChat_Load(object sender, EventArgs e)
        {
            await LoadChatHistory();
        }

        private async void InitializeSignalR()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl($"https://localhost:7103/chatHub?username={_currentUser}", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(_accessToken);
                })
                .Build();

            _hubConnection.On<string, SingleChat>("ReceiveMessage", (user, message) =>
            {
                Invoke((Action)(() =>
                {
                    string deKey = _rsaService.Decrypt(message.SessionKeyEncrypted[_currentUser], _key);
                    var content = _aesService.DecryptMessage(message.Content, deKey);
                    var timestamp = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
                    textBox_showmsg.AppendText($"{timestamp}: {user}: {content}{Environment.NewLine}");
                }));
            });

            _hubConnection.On<string, string>("ReceiveStatusUpdate", (username, status) =>
            {
                Invoke((Action)(() =>
                {
                    // Cập nhật trạng thái bạn bè
                    LoadFriends();
                }));
            });

            _hubConnection.Closed += async (error) =>
            {
                await Task.Delay(1000);
                await _hubConnection.StartAsync();
            };

            await _hubConnection.StartAsync();
        }


        private async void button_send_Click(object sender, EventArgs e)
        {
            if (_hubConnection.State != HubConnectionState.Connected)
            {
                MessageBox.Show("Không thể gửi tin nhắn. Kết nối đang bị gián đoạn.");
                return;
            }

            var message = textBox_msg.Text;
            
            var content = _aesService.EncryptMessage(message, aesKey);
            var senderUser = await _userService.GetUserByUsername(_currentUser);
            var receiverUser = await _userService.GetUserByUsername(_currentChatUser);
            var senderKey = _rsaService.Encrypt(aesKey, senderUser.PublicKey);
            var receiverKey = _rsaService.Encrypt(aesKey, receiverUser.PublicKey);
            await _hubConnection.InvokeAsync("SendMessage", _currentUser, _currentChatUser, content, senderKey, receiverKey);
            //await singleChatService.SendMessage(_currentUser , _currentChatUser , message);
            textBox_msg.Clear();
        }

        private async Task LoadChatHistory()
        {
            if (string.IsNullOrEmpty(_currentChatUser))
            {
                return;
            }

            var messages = await _hubConnection.InvokeAsync<List<SingleChat>>("GetChatHistory", _currentUser, _currentChatUser);
            
            foreach (var message in messages)
            {

                var localTime = message.Timestamp.AddHours(7);
                var timestamp = localTime.ToString("HH:mm:ss - dd/MM/yyyy");
                var enKey = message.SessionKeyEncrypted[_currentUser];
                var key = _rsaService.Decrypt(enKey, _key);
                var contentMSG = _aesService.DecryptMessage(message.Content, key);
                textBox_showmsg.AppendText($"{timestamp}: {message.Sender}: {contentMSG}{Environment.NewLine}");
            }
        }

        private async void LoadFriends()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                var url = $"https://localhost:7103/api/user/get-friend-list/{_currentUser}";
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return;
                }
                var responseBody = await response.Content.ReadAsStringAsync();
                //MessageBox.Show(responseBody);

                var jsonResponse = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(responseBody);
                var friends = jsonResponse.GetProperty("data").EnumerateArray().Select(f => f.GetString()).ToList();
                var totalFriends = jsonResponse.GetProperty("total").GetInt32();

                if (friends == null || friends.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy người nào trong danh sách bạn bè của bạn.");
                    return;
                }

                int yOffset = 30;
                int labelHeight = 45;

                var totalLabel = new Label
                {
                    Text = $"Số lượng bạn bè: {totalFriends}",
                    ForeColor = Color.FromArgb(255, 255, 255),
                    AutoSize = true,
                    Location = new Point(10, yOffset),
                    Font = new Font("Arial", 12)
                };
                groupBox_doanchat.Controls.Add(totalLabel);

                yOffset += labelHeight;

                foreach (var friend in friends)
                {
                    var friendStatus = await GetFriendStatus(friend);
                    var labelColor = friendStatus ? Color.FromArgb(0, 255, 0) : Color.FromArgb(255, 255, 255);

                    var label = new Label
                    {
                        Text = friend,
                        ForeColor = labelColor,
                        AutoSize = true,
                        Location = new Point(10, yOffset),
                        Font = new Font("Arial", 12)
                    };
                    label.Click += (s, e) => LoadChatWithUser(_currentUser, friend);
                    groupBox_doanchat.Controls.Add(label);

                    yOffset += labelHeight;
                }
            }
        }

        private async Task<bool> GetFriendStatus(string username)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                var url = $"https://localhost:7103/api/user/get-status/{username}";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var jsonResponse = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(responseBody);
                    return jsonResponse.GetProperty("opStatus").GetBoolean();
                }
                return false;
            }
        }

        private async void LoadChatWithUser(string username, string friend)
        {
            _currentChatUser = friend;
            textBox_otherusrname.Text = friend;
            textBox_showmsg.Clear();
            await LoadChatHistory();

            var friendStatus = await GetFriendStatus(friend);
            textBox_otherstatus.Text = friendStatus ? "Đang hoạt động" : "Không hoạt động";
        }

        private async void comboBox_mystatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var statusString = comboBox_mystatus.SelectedItem.ToString();
            bool status = statusString == "Đang hoạt động";
            await UpdateUserStatus(status);
        }

        private async Task UpdateUserStatus(bool opstatus)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                var url = $"https://localhost:7103/api/user/updateStatus";
                var json = JsonConvert.SerializeObject(new { Username = _currentUser, OpStatus = opstatus });
                var content = new StringContent(json, Encoding.UTF8 , "application/json");
                var response = await client.PostAsync(url, content);
                var res = await response.Content.ReadAsStringAsync();
                string msg = JObject.Parse(res)["message"].ToString();
                //if (!response.IsSuccessStatusCode)
                //{
                //    MessageBox.Show($"Error: {msg}");
                //}
            }
        }

        private void CustomizeGroupBox()
        {
            groupBox_doanchat.FlatStyle = FlatStyle.Flat;
            groupBox_doanchat.Paint += (sender, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, groupBox_doanchat.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);
            };
        }

        private void textBox_msg_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox_doanchat_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}