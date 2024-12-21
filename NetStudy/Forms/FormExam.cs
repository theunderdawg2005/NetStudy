using NetStudy.Services;
using Newtonsoft.Json.Linq;
using NetStudy.Models;
using Newtonsoft.Json;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.ApplicationServices;

namespace NetStudy.Forms
{
    public partial class FormExam : Form
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        private JObject UserInfo;
        private string accessToken;
        private QuestionService questionService;
        private ChatBotService chatBotService;
        string correctAnswer;

        public FormExam(JObject info, string token)
        {
            InitializeComponent();
            UserInfo = info;
            accessToken = token;
            lbl_username.Text = UserInfo["username"].ToString();
            questionService = new QuestionService(accessToken);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }


        private async void btn_listquestion_Click(object sender, EventArgs e)
        {
            string topic = tB_topic.Text;
            if(topic == "")
            {
                await LoadListQuestion();
            }
            else
            {
                await LoadListQuestionByTopic(topic);
            }
        }

        private void btn_createquestion_Click(object sender, EventArgs e)
        {
            FormCreateQuestion formCreateQuestion = new FormCreateQuestion(UserInfo, accessToken, this);
            formCreateQuestion.Show();
            this.Hide();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
        }

        private void btn_review_Click(object sender, EventArgs e)
        {
            ReviewQuestion reviewQuestion = new ReviewQuestion(UserInfo, accessToken, this);
            reviewQuestion.Show();
            this.Hide();
        }

        private void btn_AI_Click(object sender, EventArgs e)
        {
            ChatBot chatBot = new ChatBot(UserInfo, accessToken, this);
            chatBot.Show();
            this.Hide();
        }

        private async Task LoadListQuestion()
        {
            try
            {
                var questions = await questionService.GetAllQuestionAsync(UserInfo["username"].ToString());

                if (questions.Data != null && questions.Data.Any())
                {
                    flowLayoutPanel1.Controls.Clear();

                    foreach (var question in questions.Data)
                    {
                        AddQuestionToPanel(question);
                    }
                }
                else
                {
                    MessageBox.Show("No questions found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadListQuestionByTopic(string topic)
        {
            try
            {
                var questions = await questionService.GetAllQuestionByTopicAsync(UserInfo["username"].ToString(), topic);

                if (questions.Data != null && questions.Data.Any())
                {
                    flowLayoutPanel1.Controls.Clear();

                    foreach (var question in questions.Data)
                    {
                        AddQuestionToPanel(question);
                    }
                }
                else
                {
                    MessageBox.Show("No questions found for this topic.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddQuestionToPanel(QuestionDto question)
        {   
            Panel questionPanel = new Panel
            {
                Width = flowLayoutPanel1.Width - 20,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
                Margin = new Padding(5),
                BackColor = Color.Indigo,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            Label lblData = new Label
            {
                Text = $"Topic: {question.Topic}\nContent: {question.Content}\nCorrect Answer: {question.CorrectAnswer}",
                AutoSize = true,
                Font = new Font("Cambria", 12, FontStyle.Bold),
                ForeColor = Color.Gainsboro,
                MaximumSize = new Size(flowLayoutPanel1.Width - 40, 0),
                Margin = new Padding(0, 0, 0, 5)
            };

            Button editButton = new Button
            {
                Text = "Sửa",
                Size = new Size(60, 30),
                BackColor = Color.Blue,
                ForeColor = Color.White
            };

            Button deleteButton = new Button
            {
                Text = "Xóa",
                Size = new Size(60, 30),
                BackColor = Color.Red,
                ForeColor = Color.White
            };

            editButton.Click += (s, e) => EditQuestion(question);
            deleteButton.Click += (s, e) => DeleteQuestion(question, UserInfo["username"].ToString());

            Panel buttonPanel = new Panel
            {
                AutoSize = true,
                Location = new Point(questionPanel.Width - 140, 10)
            };

            buttonPanel.Controls.Add(editButton);
            buttonPanel.Controls.Add(deleteButton);

            editButton.Location = new Point(0, 0);
            deleteButton.Location = new Point(editButton.Width + 10, 0);

            questionPanel.Controls.Add(lblData);

            questionPanel.Controls.Add(buttonPanel);

            flowLayoutPanel1.Controls.Add(questionPanel);

            flowLayoutPanel1.AutoScroll = true;
        }

        private async void EditQuestion(QuestionDto question)
        {
            FormUpdateQuestion formUpdateQuestion = new FormUpdateQuestion(UserInfo, accessToken, question);
            formUpdateQuestion.Show();
            this.Hide();
        }

        private async void DeleteQuestion(QuestionDto question, string username)
        {
            username = UserInfo["username"].ToString();
            try
            {
                var result = await questionService.DeleteQuestionAsync(question, username);

                if (result)
                {
                    MessageBox.Show("Question deleted successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadListQuestion();
                }
                else
                {
                    MessageBox.Show("Failed to delete question.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
