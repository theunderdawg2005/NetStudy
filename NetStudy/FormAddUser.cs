using Microsoft.AspNetCore.SignalR.Client;
using NetStudy.Services;
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
    public partial class FormAddUser : Form
    {

        private readonly GroupService groupService;
        private string accessToken;
        private string groupName;
        private string groupId;
        private HubConnection connection;
        private string name;
        private DateTime timeStamp = DateTime.Now;
        public FormAddUser(string token, string name, string id, string username)
        {
            InitializeComponent();
            accessToken = token;
            groupName = name;
            groupId = id;
            lblName.Text = groupName;
            groupService = new GroupService(accessToken);
            this.name = username;

            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7070/groupChatHub", opts =>
                {
                    opts.AccessTokenProvider = async () => await Task.FromResult(accessToken);
                })
                .Build();

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;         // Username from a TextBox

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng điền tên người dùng!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await connection.InvokeAsync("SendMessageGroup", groupId, name, $"đã thêm {username}");
            await groupService.AddUserToGroup(groupId, username);
            await groupService.SendMessage(groupId, name, $"đã thêm {username}", timeStamp);
        }

        private async void FormAddUser_Load(object sender, EventArgs e)
        {
            await connection.StartAsync();
        }
    }
}
