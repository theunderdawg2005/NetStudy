using FontAwesome.Sharp;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.VisualBasic.ApplicationServices;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NetStudy
{
    public partial class FormUserRequests : Form
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        private readonly string accessToken;
        private GroupService groupService;
        private readonly string groupId;
        private List<string> reqList;
        private HubConnection connection;
        private string admin;
        public FormUserRequests(string token, string id, List<string> list, string userAdmin)
        {
            InitializeComponent();
            reqList = list;
            accessToken = token;
            groupId = id;
            groupService = new GroupService(accessToken);
            admin = userAdmin;
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7070/groupChatHub", opts =>
                {
                    opts.AccessTokenProvider = async () => await Task.FromResult(accessToken);
                })
                .Build();
        }

        public async void CreatePanel()
        {
            flowLayoutPanel1.Controls.Clear();
            var (reqList, total) = await groupService.GetJoinListByGroupId(groupId);
            foreach (string mem in reqList)
            {
                Panel memPanel = new Panel
                {
                    Width = flowLayoutPanel1.Width - 10,
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10),
                    Margin = new Padding(5),
                    BackColor = Color.Indigo
                };
                Label lblName = new Label
                {
                    Text = $"Username: {mem}",
                    AutoSize = true,
                    Font = new Font("Cambria", 12, FontStyle.Bold),
                    ForeColor = Color.Gainsboro
                };
                Label lblRole = new Label
                {
                    Text = $"Role: User",
                    AutoSize = true,
                    Font = new Font("Cambria", 10),
                    ForeColor = Color.Gainsboro
                };
                IconButton btnAcpt = new IconButton
                {
                    Location = new Point(390, 5),
                    Size = new Size(150, 30),
                    Font = new Font("Arial", 9, FontStyle.Regular),
                    BackColor = Color.FromArgb(0, 117, 214),
                    Text = "Chấp nhận",
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    ForeColor = Color.Gainsboro,
                };
                btnAcpt.Click += async (sender, e) =>
                {
                    var result = MessageBox.Show("Bạn muốn chấp nhận yêu cầu tham gia của người dùng này?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await groupService.AcptJoinReq(groupId, mem);
                        btnAcpt.Text = "Đã thêm";
                        btnAcpt.ForeColor = Color.Brown;
                        btnAcpt.BackColor = Color.LightGreen;
                        await connection.InvokeAsync("SendMessageGroup", groupId, "Thông báo", $"{admin} (admin) đã thêm {mem} là User");
                        await groupService.SendMessage(groupId, "Thông báo", $"{admin} (admin) đã thêm {mem} là User", DateTime.UtcNow);
                        CreatePanel();
                    }

                };
                IconButton btnDel = new IconButton
                {
                    Location = new Point(390, 60),
                    Size = new Size(150, 30),
                    Font = new Font("Arial", 9, FontStyle.Regular),
                    BackColor = Color.FromArgb(0, 117, 214),
                    Text = "Xóa",
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    ForeColor = Color.Gainsboro
                };
                btnDel.Click += async (sender, e) =>
                {
                    var result = MessageBox.Show("Bạn muốn xóa yêu cầu tham gia của người dùng này?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await groupService.DelJoinReq(groupId, mem);
                        btnDel.Text = "Đã xóa";
                        btnDel.ForeColor = Color.White;
                        btnDel.BackColor = Color.Red;
                        CreatePanel();
                    }


                };

                memPanel.Controls.Add(lblName);
                lblName.Location = new Point(10, 10);
                memPanel.Controls.Add(lblRole);
                lblRole.Location = new Point(10, 40);
                memPanel.Controls.Add(btnAcpt);
                memPanel.Controls.Add(btnDel);
                flowLayoutPanel1.Controls.Add(memPanel);
            }
        }


        private async void FormUserRequests_Load(object sender, EventArgs e)
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
