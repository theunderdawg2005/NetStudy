using FontAwesome.Sharp;
using NetStudy.Models;
using NetStudy.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetStudy
{
    public partial class AcceptFriends : Form
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        private JObject UserInfo;
        private string accessToken;
        private UserService userService;
        public AcceptFriends(JObject info, string token)
        {
            InitializeComponent();
            UserInfo = info;
            accessToken = token;
            userService = new UserService(accessToken);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }
        private async void AcceptFriends_Load(object sender, EventArgs e)
        {
            await LoadUser();
        }
        private void CreatePanel(List<User> users, string username)
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

                IconButton btnAcptFriend = new IconButton
                {
                    Location = new Point(400, 5),
                    Size = new Size(150, 30),
                    Font = new Font("Arial", 9, FontStyle.Regular),
                    BackColor = Color.FromArgb(0, 117, 214),
                    Text = "Chấp nhận",

                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    ForeColor = Color.Gainsboro,
                };
                btnAcptFriend.Click += async (sender, e) =>
                {
                    await userService.AcceptRequest(username, user.Username, btnAcptFriend, accessToken);

                };
                IconButton btnDelReq = new IconButton
                {
                    Location = new Point(400, 60),
                    Size = new Size(150, 30),
                    Font = new Font("Arial", 9, FontStyle.Regular),
                    BackColor = Color.FromArgb(0, 117, 214),
                    Text = "Xóa",
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    ForeColor = Color.Gainsboro
                };
                btnDelReq.Click += async (sender, e) =>
                {
                    await userService.RemoveRequest(username, user.Username, btnDelReq, accessToken);
                };
                userPanel.Controls.Add(lblName);
                lblName.Location = new Point(10, 10);
                userPanel.Controls.Add(lblEmail);
                lblEmail.Location = new Point(10, 40);
                userPanel.Controls.Add(btnAcptFriend);
                userPanel.Controls.Add(btnDelReq);
                flowLayoutPanel1.Controls.Add(userPanel);
            }
        }

        public async Task LoadUser()
        {
            string username = UserInfo["username"].ToString();

            try
            {
                var (list, total) = await userService.GetReqList(username, accessToken);
                List<User> users = new List<User>();
                foreach (var u in list) {
                    var user = await userService.GetUserByUsername(u);
                    users.Add(user);
                }
                CreatePanel(users, username);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...567", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
