using FontAwesome.Sharp;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.VisualBasic.ApplicationServices;
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
using System.Windows.Forms;

namespace NetStudy
{
    public partial class FormGroupDetails : Form
    {
        private HubConnection connection;
        private string accessToken;
        private readonly JObject UserInfo;
        private readonly JObject GroupInfo;
        private string groupId;
        private readonly GroupService groupService;
        private readonly List<MemberRole> members;
        private List<string> memReq;
        private string roleUser;
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        public FormGroupDetails(string token, JObject info, JObject groupInfo)
        {
            InitializeComponent();
            btnSend.Enabled = false;
            accessToken = token;
            UserInfo = info;
            GroupInfo = groupInfo;
            groupId = groupInfo["id"].ToString();
            members = GroupInfo["members"].ToObject<List<MemberRole>>();
            var user = members.FirstOrDefault(u => u.Username == UserInfo["username"].ToString());
            roleUser = user.Role;
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7070/groupChatHub", opts =>
                {
                    opts.AccessTokenProvider = async () => await Task.FromResult(accessToken);
                })
                .Build();
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Invoke(async () =>
                {
                    DateTime timeStamp = DateTime.Now;

                    listMsg.Items.Add(" ");
                    listMsg.Items.Add(timeStamp.ToString("dd/MM/yyyy hh:mm tt"));
                    listMsg.Items.Add($"{user}: {message}");
                });
            });

            lblTitle.Text = GroupInfo["name"].ToString();
            groupService = new GroupService(accessToken);
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            DateTime timeStamp = DateTime.UtcNow;
            await connection.InvokeAsync("SendMessageGroup", groupId, UserInfo["name"].ToString(), txtMessage.Text);
            await groupService.SendMessage(groupId, UserInfo["name"].ToString(), txtMessage.Text, timeStamp);
            txtMessage.Clear();
        }

        private async void FormGroupDetails_Load(object sender, EventArgs e)
        {
            int total;
            (memReq, total) = await groupService.GetJoinListByGroupId(groupId);
            if(roleUser == "001")
            {
                IconButton btnUserRequest = new IconButton
                {
                     
                    FlatStyle = FlatStyle.Flat,
                    Text = $"User Requests ({total})",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Bahnschrift",9, FontStyle.Bold),
                    BackColor = Color.FromArgb(192, 0, 192),
                    IconChar = IconChar.PersonWalkingArrowRight,
                    IconSize = 35,
                    IconColor = Color.Gainsboro,
                    ImageAlign = ContentAlignment.MiddleLeft,
                    TextImageRelation = TextImageRelation.ImageBeforeText,
                    Location = new Point(729,12),
                    Size = new Size(203,44)
                };
                btnUserRequest.Click += async (sender, e) =>
                {
                    btnUserReq_Click(sender, e);
                };
                panelTop.Controls.Add(btnUserRequest);
            }    
            await connection.StartAsync();
            await connection.SendAsync("JoinGroup", groupId);
            var data = await groupService.LoadMessageByGroupId(groupId);
            listMsg.Items.Clear();
            foreach (var message in data)
            {
                var time = message.TimeStamp;
                TimeZoneInfo gmtPlus7 = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                DateTime gmt7Time = TimeZoneInfo.ConvertTimeFromUtc(time, gmtPlus7);
                listMsg.Items.Add(" ");
                listMsg.Items.Add($"{gmt7Time.ToString("dd/MM/yyyy hh:mm tt")}");
                listMsg.Items.Add($"{message.Sender}: {message.Content}");
            }
        }
        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            btnSend.Enabled = !string.IsNullOrWhiteSpace(txtMessage.Text);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            
            FormAddUser formAdd = new FormAddUser(
                accessToken, 
                GroupInfo["name"].ToString(), 
                GroupInfo["id"].ToString(), 
                UserInfo["name"].ToString(), 
                roleUser
            );
            formAdd.ShowDialog();
        }

        private async void btnLeave_Click(object sender, EventArgs e)
        {
            string username = UserInfo["username"].ToString();
            string name = UserInfo["name"].ToString();
            await connection.InvokeAsync("LeaveGroup", groupId);
            await connection.InvokeAsync("SendMessageGroup", groupId, "Thông báo", $"{name} đã rời khỏi nhóm");
            await groupService.LeaveGroup(groupId, username);
            await groupService.SendMessage(groupId, "Thông báo", $"{name} đã rời khỏi nhóm", DateTime.UtcNow);
        }

        private void btnUserReq_Click(object sender, EventArgs e)
        {
            FormUserRequests formReq = new FormUserRequests(accessToken, groupId, memReq, UserInfo["name"].ToString());
            formReq.ShowDialog();
        }
    }
}
