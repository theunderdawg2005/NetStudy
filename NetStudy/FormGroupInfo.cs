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
        public FormGroupInfo(string token, JObject info)
        {
            InitializeComponent();
            accessToken = token;
            groupInfo = info;
            groupService = new GroupService(accessToken);
        }

        private void linkExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private async void FormGroupInfo_Load(object sender, EventArgs e)
        {
            txtName.Text = groupInfo["name"].ToString();
            txtDescription.Text = groupInfo["description"].ToString() ?? "Chưa có mô tả về nhóm này";
        }
    }
}
