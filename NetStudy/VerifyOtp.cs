using NetStudy.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NetStudy
{
    public partial class VerifyOtp : Form
    {
        
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"http://localhost:7103/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        private string _email;
        public VerifyOtp(string email)
        {
            InitializeComponent();
            _email = email;
        }

        public async Task<string> VeriOtp(dynamic otpModel)
        {
            try
            {
                var json = JsonConvert.SerializeObject(otpModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var res = await httpClient.PostAsync("api/auth/Verify-Otp", content);
                return await res.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            btnVerify.Enabled = true;
            if(string.IsNullOrEmpty(txtOTP.Text))
            {
                MessageBox.Show("Vui lòng nhập OTP!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var OTP = new
            {
                Email = _email,
                Code = txtOTP.Text.Trim(),
            };
            var response = await VeriOtp(OTP);
            if (response.Contains("thành công", StringComparison.OrdinalIgnoreCase))
            {
                this.Hide();
                MessageBox.Show($"Đăng kí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormLogin login = new FormLogin();
                login.ShowDialog();
                this.Close();
            }
            else 
            {
                MessageBox.Show(response);
            }
        }
    }
}
