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
        public FormAddUser(string token, string name, string id)
        {
            InitializeComponent();
            accessToken = token;
            groupName = name;
            groupId = id;
            lblName.Text = groupName;
            groupService = new GroupService(accessToken);
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;         // Username from a TextBox

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng điền tên người dùng!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await groupService.AddUserToGroup(groupId, username);
        }
    }
}
