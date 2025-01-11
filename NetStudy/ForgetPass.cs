using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetStudy.Services;

namespace NetStudy
{
    public partial class ForgetPass : Form
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7103/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        private UserService userService;

        public ForgetPass(UserService userService)
        {
            this.userService = userService;
            InitializeComponent();
        }

        private void lbl_email_Click(object sender, EventArgs e)
        {

        }

        private async void btn_send_Click(object sender, EventArgs e)
        {
            string email = tB_email.Text;
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập email!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var response = await ForgetPassword(email);

            if (response.Contains("đã được gửi"))
            {
                MessageBox.Show("Mã xác nhận đã được gửi đến email của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetPassword resetPassword = new ResetPassword(email);
                resetPassword.Show();
            }
            else
            {
                MessageBox.Show("Email không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public async Task<string> ForgetPassword(string email)
        {
            try
            {
                var response = await httpClient.PostAsync($"api/user/forget-password/{email}", null);
                var res = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return "OTP xác nhận đã được gửi đến email của bạn!";
                }
                return "Email không tồn tại!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

    }
}
