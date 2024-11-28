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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NetStudy
{
    public partial class VerifyOtp : Form
    {
        private readonly UserService userService;
        public VerifyOtp()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            btnVerify.Enabled = false;
            if(string.IsNullOrEmpty(txtOTP.Text))
            {
                MessageBox.Show("Vui lòng nhập OTP!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var OTP = new
            {
                otp = txtOTP.Text.Trim(),
            };
            var response = await userService.VerifyOtp(OTP);
            if (response.IsSuccessStatusCode)
            {
                this.Hide();
                MessageBox.Show($"Đăng kí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormLogin login = new FormLogin();
                login.ShowDialog();
                this.Close();
            }
            else 
            {
                MessageBox.Show(response.StatusCode.ToString());
            }
        }
    }
}
