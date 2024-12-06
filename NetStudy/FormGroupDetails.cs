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
        private string groupId;
        public FormGroupDetails(string token, JObject info, string id)
        {
            InitializeComponent();
            accessToken = token;
            UserInfo = info;
            groupId = id;
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
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            //var id = txtID.Text;
            await connection.InvokeAsync("SendMessageGroup", groupId, UserInfo["name"].ToString(), txtMessage.Text);
            txtMessage.Clear();
        }

        private async void FormGroupDetails_Load(object sender, EventArgs e)
        {
            //var groupId = txtID.Text;
            await connection.StartAsync();
            await connection.SendAsync("JoinGroup", groupId);
        }

    }
}
