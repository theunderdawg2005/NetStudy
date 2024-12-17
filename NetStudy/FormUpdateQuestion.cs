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
    public partial class FormUpdateQuestion : Form
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };

        private string accessToken;
        private QuestionService questionService;
        private JObject UserInfo;
        private QuestionDto _question;

        public FormUpdateQuestion(JObject info, string token, QuestionDto question)
        {
            InitializeComponent();
            LoadOldQuestion(question);
            accessToken = token;
            UserInfo = info;
            questionService = new QuestionService(accessToken);
            _question = question;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tB_content.Text = "";
            tB_title.Text = "";
            tB_correctanswer.Text = "";
        }

        private async void btn_update_Click(object sender, EventArgs e)
        {
            var newQuestion = new QuestionDto
            {
                Topic = tB_title.Text,
                Content = tB_content.Text,
                CorrectAnswer = tB_correctanswer.Text
            };

            var response = await questionService.UpdateQuestionAsync(_question, newQuestion, UserInfo["username"].ToString());

            if (response)
            {
                MessageBox.Show("Update question successfully");
            }
            else
            {
                MessageBox.Show("Update question failed");
            }
        }

        private void LoadOldQuestion(QuestionDto question)
        {
            tB_title.Text = question.Topic;
            tB_content.Text = question.Content;
            tB_correctanswer.Text = question.CorrectAnswer;
        }
    }
}
