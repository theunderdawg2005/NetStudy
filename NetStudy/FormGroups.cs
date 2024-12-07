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

namespace NetStudy
{
    public partial class FormGroups : Form
    {
        private string accessToken;
        private readonly JObject UserInfo;
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        private GroupService groupService;
        public FormGroups(string token, JObject info)
        {
            InitializeComponent();
            accessToken = token;
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            UserInfo = info;
            groupService = new GroupService(accessToken);
        }

        private void linkCreateGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormCreateGroup formCreate = new FormCreateGroup(UserInfo, accessToken);
            formCreate.ShowDialog();
        }

        private async Task LoadGroups()
        {
            var groups = await groupService.LoadGroups(UserInfo["username"].ToString());
            if (groups != null && groups.Any())
            {
                PopulateGroupPanel(flowLayoutPanel1, groups);
            }

        }
        private void PopulateGroupPanel(FlowLayoutPanel flpanel, List<Group> groups)
        {
            flpanel.Controls.Clear();
            foreach (var group in groups)
            {
                Panel panel = new Panel
                {
                    Width = flowLayoutPanel1.Width - 100,
                    Tag = group.Id.ToString(),
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10),
                    Margin = new Padding(5),
                    BackColor = Color.Indigo
                };
                Label lblName = new Label
                {
                    Text = group.Name,
                    Location = new Point(10,10),
                    AutoSize = true,
                    Font = new Font("Cambria", 12, FontStyle.Bold),
                    ForeColor = Color.Gainsboro
                };

                Label lblId = new Label
                {
                    Text = $"ID: {group.Id.ToString()}",
                    AutoSize = true,
                    Location = new Point(10, 40),
                    Font = new Font("Cambria", 10),
                    ForeColor = Color.Gainsboro
                };
                panel.Click += Group_Panel_Click;
                panel.Controls.Add(lblName);

                panel.Controls.Add(lblId);
                flpanel.Controls.Add(panel);
            }
           
        }

        private async void Group_Panel_Click(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            var groupId = panel.Tag ;
            var response = await httpClient.GetAsync($"api/groups/get-group/{groupId}");
            var res = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {

                MessageBox.Show($"Lỗi {res}", response.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var info = JObject.Parse(res);
            var groupDetails = new FormGroupDetails(accessToken, UserInfo, info);
            groupDetails.ShowDialog();
        }

        private async void FormGroups_Load(object sender, EventArgs e)
        {
            await LoadGroups();
        }
    }
}
