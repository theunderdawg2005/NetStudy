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
    public partial class ChangePassword : Form
    {
        string _username;
        string accessToken;
        private UserService _userService;

        public ChangePassword(string username, string token, UserService userService)
        {
            InitializeComponent();
            _username = username;
            accessToken = token;
            _userService = userService;
        }

        private async void btn_confirm_Click(object sender, EventArgs e)
        {
            string otp = tB_otp.Text;
            string newPass = tB_newPass.Text;
            string confirmPass = tB_confirmPass.Text;
            string currentPass = tB_currentPass.Text;
            if (string.IsNullOrEmpty(otp) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass) || string.IsNullOrEmpty(currentPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu mới không khớp!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentPass == newPass)
            {
                MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var res = await _userService.ChangePasswordWithOtp(_username, otp, currentPass, newPass, confirmPass);

            if (res)
            {
                this.Close();
            }

            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
