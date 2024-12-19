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
    public partial class FormGroupInfo : Form
    {
        private readonly GroupService groupService;
        private string accessToken;
        private JObject groupInfo;
        private string roleUser;
        private string currUsername;
        public FormGroupInfo(string token, JObject info, string role, string username)
        {
            InitializeComponent();
            accessToken = token;
            groupInfo = info;
            roleUser = role;
            currUsername = username;
           
            groupService = new GroupService(accessToken);
        }



        private async void FormGroupInfo_Load(object sender, EventArgs e)
        {
            if(roleUser != "003")
            {
                linkDelGroup.Visible = false;
            }    

            txtName.Text = groupInfo["name"].ToString();
            txtDescription.Text = groupInfo["description"].ToString() ?? "Chưa có mô tả về nhóm này";
            if (roleUser == "003" || roleUser == "001")
            {
                Button btnUpdate = new Button
                {
                    Text = "UPDATE",
                    ForeColor = Color.White,
                    Font = new Font("Impact", 20, FontStyle.Bold),
                    Size = new Size(380, 55),
                    Location = new Point(107, 450),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(0, 117, 214),

                    Cursor = Cursors.Hand
                };
                btnUpdate.Click += async (sender, e) =>
                {
                    await groupService.UpdateGroupInfo(groupInfo["id"].ToString(), txtName.Text, txtDescription.Text);

                };
                LinkLabel linkEdit = new LinkLabel
                {
                    Text = "Chỉnh sửa",
                    LinkColor = Color.FromArgb(0, 117, 214),
                    Location = new Point(216, 476),
                    Font = new Font("Cambria", 11, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    AutoSize = true
                };
                linkEdit.Click += async (sender, e) =>
                {
                    txtName.ReadOnly = false;
                    txtDescription.ReadOnly = false;
                    linkEdit.Visible = false;
                    groupBox1.Controls.Add(btnUpdate);
                };
                groupBox1.Controls.Add(linkEdit);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private async void linkDelGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var res = MessageBox.Show("Bạn chắc chắn muốn giải tán nhóm không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                await groupService.DeleteGroup(groupInfo["id"].ToString(), currUsername);
                await groupService.DeleteAllMessage(groupInfo["id"].ToString());
                this.Hide();
                this.Close();
            }
        }
    }
}
