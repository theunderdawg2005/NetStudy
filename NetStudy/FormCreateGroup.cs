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
    public partial class FormCreateGroup : Form
    {
        private string accessToken;
        private GroupService groupService;
        private JObject UserInfo;
        private HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7070/")
        };
        public FormCreateGroup(JObject info, string token)
        {
            InitializeComponent();
            accessToken = token;
            UserInfo = info;
            groupService = new GroupService(accessToken);
        }

        private void linkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtDescription.Clear();
            txtName.Clear();
        }

        private void linkExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string username = UserInfo["username"].ToString();
                string groupDesc = txtDescription.Text;
                string groupName = txtName.Text;
                if(groupDesc == null || groupName == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    return;
                }    
                var response = await groupService.CreateGroup(username, groupName, groupDesc);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Tạo nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    this.Close();
                }
                else
                {
                    var res = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(res, "Lỗi" , MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
