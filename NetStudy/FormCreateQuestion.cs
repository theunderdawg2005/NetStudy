using NetStudy.Services;
using Newtonsoft.Json.Linq;
using NetStudy.Models;
using Newtonsoft.Json;
using NetStudy.Forms;

namespace NetStudy
{
    public partial class FormCreateQuestion : Form
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };

        private string accessToken;
        private QuestionService questionService;
        private JObject UserInfo;
        private FormExam FormExam;

        public FormCreateQuestion(JObject info, string token, FormExam formExam)
        {
            InitializeComponent();
            accessToken = token;
            UserInfo = info;
            questionService = new QuestionService(accessToken);
            this.FormClosed += FormCreateQuestion_FormClosed;
            FormExam = formExam;
        }

        private async void btn_create_Click(object sender, EventArgs e)
        {
            string topic = tB_title.Text.Trim();
            string content = tB_content.Text.Trim();
            string correctAnswer = tB_correctanswer.Text.Trim();

            if (string.IsNullOrWhiteSpace(topic) || string.IsNullOrWhiteSpace(content) || string.IsNullOrWhiteSpace(correctAnswer))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var question = new Question
            {
                Topic = topic,
                Content = content,
                CorrectAnswer = correctAnswer,
                Owner = UserInfo["username"].ToString()
            };

            var response = await questionService.CreateQuestion(question, UserInfo["username"].ToString());

            if (response.Message.Contains("thành công"))
            {
                MessageBox.Show("Tạo câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tB_content.Clear();
                tB_correctanswer.Clear();
                tB_title.Clear();
            }
            else
            {
                MessageBox.Show($"Lỗi khi tạo câu hỏi: {response.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tB_content.Clear();
            tB_correctanswer.Clear();
            tB_title.Clear();
        }

        private void FormCreateQuestion_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormExam.Show();
        }
    }
}
