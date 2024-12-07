using Microsoft.AspNetCore.SignalR.Client;
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
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        public FormGroupDetails(string token, JObject info, JObject groupInfo)
        {
            InitializeComponent();
            accessToken = token;
            UserInfo = info;
            groupId = groupInfo["id"].ToString();
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7070/groupChatHub", opts =>
                {
                    opts.AccessTokenProvider = async () => await Task.FromResult(accessToken);
                })
                .Build();
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Invoke(() =>
                {
                    listMsg.Items.Add($"{user}: {message}");
                });
            });
            GroupInfo = groupInfo;
            lblTitle.Text = groupInfo["name"].ToString();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {

            await connection.InvokeAsync("SendMessageGroup", groupId, UserInfo["name"].ToString(), txtMessage.Text);
            txtMessage.Clear();
        }

        private async void FormGroupDetails_Load(object sender, EventArgs e)
        {

            await connection.StartAsync();
            await connection.SendAsync("JoinGroup", groupId);
        }

        private void linkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAddUser formAdd = new FormAddUser(accessToken, GroupInfo["name"].ToString(), GroupInfo["id"].ToString());
            formAdd.ShowDialog();
        }
    }
}
