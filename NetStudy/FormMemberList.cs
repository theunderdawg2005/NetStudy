using FontAwesome.Sharp;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.VisualBasic.ApplicationServices;
using NetStudy.Models;
using NetStudy.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetStudy
{
    public partial class FormMemberList : Form
    {
        private string accessToken;
        private readonly GroupService groupService;
        private string groupId;
        private HubConnection connection;
        public static HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/")
        };
        public FormMemberList(string token, string id)
        {
            InitializeComponent();
            accessToken = token;
            groupId = id;
            groupService = new GroupService(token);
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7070/groupChatHub", opts =>
                {
                    opts.AccessTokenProvider = async () => await Task.FromResult(accessToken);
                })
                .Build();
        }

        private async void CreatePanel()
        {
            flowLayoutPanel1.Controls.Clear();
            var memberList = await groupService.GetMemberList(groupId);
            foreach (var member in memberList)
            {
                Panel memPanel = new Panel
                {
                    Width = flowLayoutPanel1.Width - 20,
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10),
                    Margin = new Padding(5),
                    BackColor = Color.Indigo,
                    Cursor = Cursors.Hand
                };
                Label lblName = new Label
                {
                    Text = $"Tên: {member.Name}",
                    AutoSize = true,
                    Font = new Font("Cambria", 12, FontStyle.Bold),
                    ForeColor = Color.Gainsboro,
                    Location = new Point(10, 10)
                };
                Label lblUsername = new Label
                {
                    Text = $"Username: {member.Username}",
                    AutoSize = true,
                    Font = new Font("Cambria", 10),
                    ForeColor = Color.Gainsboro,
                    Location = new Point(10, 40)
                };
                string txtRole = (member.Role == "001") ? "Admin" : "User";
                Label lblRole = new Label
                {

                    Text = $"Role: {txtRole}",
                    AutoSize = true,
                    Font = new Font("Cambria", 10),
                    ForeColor = Color.Gainsboro,
                    Location = new Point(10, 65)
                };
                LinkLabel linkRemove = new LinkLabel
                {
                    Text = "Xóa thành viên",
                    AutoSize = true,
                    Font = new Font("Cambria", 10),
                    LinkColor = Color.IndianRed,
                    Location = new Point(400, 70)
                };
                linkRemove.Click += async (sender, e) =>
                {
                    var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa thành viên {member.Name}?",
                                 "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await groupService.RemoveMember(groupId, member.Username);
                        await connection.InvokeAsync("SendMessageGroup", groupId, "Thông báo", $"{member.Username} đã bị xóa khỏi nhóm");
                        await groupService.SendMessage(groupId, "Thông báo", $"{member.Username} đã bị xóa khỏi nhóm", DateTime.UtcNow);
                        CreatePanel();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa thành viên.", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                };
                memPanel.Controls.Add(lblName);
                memPanel.Controls.Add(lblUsername);
                memPanel.Controls.Add(lblRole);
                memPanel.Controls.Add(linkRemove);
                flowLayoutPanel1.Controls.Add(memPanel);
            }
        }

        private async void FormMemberList_Load(object sender, EventArgs e)
        {
            await connection.StartAsync();
            CreatePanel();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
