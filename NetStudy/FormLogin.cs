﻿using Microsoft.VisualBasic;
using NetStudy.Forms;
using NetStudy.Services;
using Newtonsoft.Json;
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
    public partial class FormLogin : Form
    {
        private readonly UserService userService;
        private readonly AesService aesService;
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7103/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        public FormLogin()
        {
            InitializeComponent();
            aesService = new AesService();
        }
        public async void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var User = new
                {
                    username = username,
                    password = password
                };
                var json = JsonConvert.SerializeObject(User);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("api/user/login", content);
                var info = await response.Content.ReadAsStringAsync();
                JObject res = JObject.Parse(info);
                if (response.IsSuccessStatusCode)
                {
                    this.Hide();
                    var key = aesService.DecryptPrivateKey(res["privateKey"].ToString(), password, res["salt"].ToString());
                    var accessToken = res["accessToken"].ToString();
                    MainMenu menu = new MainMenu(accessToken, res, key);
                    //MessageBox.Show($"Access Token: {accessToken}", "Token");
                    menu.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace, "Error...");
            }
        }
        public void linkClear_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormRegister register = new FormRegister();
            register.ShowDialog();
            this.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = !string.IsNullOrWhiteSpace(txtUsername.Text);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = !string.IsNullOrWhiteSpace(txtPassword.Text);
        }

        private void linkForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPass forgetPass = new ForgetPass(userService);
            forgetPass.Show();
        }
    }
}
