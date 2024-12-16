using NetStudy.Services;
using Newtonsoft.Json.Linq;
using NetStudy.Helper;

namespace NetStudy
{
    public partial class ReviewQuestion : Form
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };

        private JObject UserInfo;
        private string accessToken;
        private QuestionService questionService;
        string correctAnswer;
        private QuestionHelper questionHelper;

        public ReviewQuestion(JObject info, string token)
        {
            InitializeComponent();
            UserInfo = info;
            accessToken = token;
            lbl_username.Text = UserInfo["username"].ToString();
            questionService = new QuestionService(accessToken);
            questionHelper = new QuestionHelper(accessToken);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }

        private void btn_option1_Click(object sender, EventArgs e)
        {
            CheckAnswer(btn_option1.Text);
        }

        private void btn_option2_Click(object sender, EventArgs e)
        {
            CheckAnswer(btn_option2.Text);
        }

        private void btn_option3_Click(object sender, EventArgs e)
        {
            CheckAnswer(btn_option3.Text);
        }

        private void btn_option4_Click(object sender, EventArgs e)
        {
            CheckAnswer(btn_option4.Text);
        }

        private async void btn_next_Click(object sender, EventArgs e)
        {
            if (tB_topic.Text == "")
            {
                await LoadRandomQuestionAsync();
            }
            else
            {
                await LoadRandomQuestionByTopic();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tB_data.Text = "";
        }

        private async void btn_review_Click(object sender, EventArgs e)
        {
            if (tB_topic.Text == "")
            {
                await LoadRandomQuestionAsync();
            }
            else
            {
                await LoadRandomQuestionByTopic();
            }
        }

        private void CheckAnswer(string selectedAnswer)
        {
            if (selectedAnswer == correctAnswer)
            {
                MessageBox.Show("Câu trả lời chính xác", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã chọn sai!. Hãy thử lại!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private async Task LoadRandomQuestionAsync()
        //{
        //    try
        //    {
        //        var randomQuestion = await questionService.GetRandomQuestionsAsync(UserInfo["username"].ToString());
        //        if (randomQuestion.Data != null)
        //        {
        //            tB_data.Text = $"Topic: {randomQuestion.Data.Topic}{Environment.NewLine}Content: {randomQuestion.Data.Content}";
        //            correctAnswer = randomQuestion.Data.CorrectAnswer;
        //            List<string> fakeAnswers = new List<string>
        //            {
        //                "Answer A",
        //                "Answer B",
        //                "Answer C",
        //                "Answer D"
        //            };

        //            Random random = new Random();
        //            int correctAnswerIndex = random.Next(0, 4);
        //            Button[] buttons = { btn_option1, btn_option2, btn_option3, btn_option4 };
        //            buttons[correctAnswerIndex].Text = correctAnswer;

        //            int fakeAnswerIndex = 0;
        //            for (int i = 0; i < 4; i++)
        //            {
        //                if (i != correctAnswerIndex)
        //                {
        //                    buttons[i].Text = fakeAnswers[fakeAnswerIndex];
        //                    fakeAnswerIndex++;
        //                }
        //            }

        //        }
        //        else
        //        {
        //            tB_data.Text = "No questions found.";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private async Task LoadRandomQuestionByTopic()
        //{
        //    string topic = tB_topic.Text;
        //    try
        //    {
        //        var randomQuestion = await questionService.GetRandomQuestionByTopic(UserInfo["username"].ToString(), topic);
        //        if (randomQuestion.Data != null)
        //        {
        //            tB_data.Text = $"Topic: {randomQuestion.Data.Topic}{Environment.NewLine}Content: {randomQuestion.Data.Content}";
        //            correctAnswer = randomQuestion.Data.CorrectAnswer;
        //            List<string> fakeAnswers = new List<string>
        //            {
        //                "Answer A",
        //                "Answer B",
        //                "Answer C",
        //                "Answer D"
        //            };

        //            Random random = new Random();
        //            int correctAnswerIndex = random.Next(0, 4);
        //            Button[] buttons = { btn_option1, btn_option2, btn_option3, btn_option4 };
        //            buttons[correctAnswerIndex].Text = correctAnswer;

        //            int fakeAnswerIndex = 0;
        //            for (int i = 0; i < 4; i++)
        //            {
        //                if (i != correctAnswerIndex)
        //                {
        //                    buttons[i].Text = fakeAnswers[fakeAnswerIndex];
        //                    fakeAnswerIndex++;
        //                }
        //            }

        //        }
        //        else
        //        {
        //            tB_data.Text = "No questions found.";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private async Task LoadRandomQuestionAsync()
        {
            try
            {
                var randomQuestion = await questionService.GetRandomQuestionsAsync(UserInfo["username"].ToString());
                if (randomQuestion.Data != null)
                {
                    tB_data.Text = $"Topic: {randomQuestion.Data.Topic}{Environment.NewLine}Content: {randomQuestion.Data.Content}";
                    correctAnswer = randomQuestion.Data.CorrectAnswer;

                    var fakeAnswers = await questionHelper.GenerateFakeAnswers(randomQuestion.Data.Content);

                    if (fakeAnswers == null || fakeAnswers.Count < 3)
                    {
                        MessageBox.Show("Failed to generate fake answers. Using default fake answers.");
                        fakeAnswers = new List<string> { "Answer A", "Answer B", "Answer C", "Answer D" };
                    }

                    Random random = new Random();
                    int correctAnswerIndex = random.Next(0, 4);
                    Button[] buttons = { btn_option1, btn_option2, btn_option3, btn_option4 };
                    buttons[correctAnswerIndex].Text = correctAnswer;

                    int fakeAnswerIndex = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (i != correctAnswerIndex)
                        {
                            buttons[i].Text = fakeAnswers[fakeAnswerIndex];
                            fakeAnswerIndex++;
                        }
                    }
                }
                else
                {
                    tB_data.Text = "No questions found.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadRandomQuestionByTopic()
        {
            string topic = tB_topic.Text;
            try
            {
                var randomQuestion = await questionService.GetRandomQuestionByTopic(UserInfo["username"].ToString(), topic);
                if (randomQuestion.Data != null)
                {
                    tB_data.Text = $"Topic: {randomQuestion.Data.Topic}{Environment.NewLine}Content: {randomQuestion.Data.Content}";
                    correctAnswer = randomQuestion.Data.CorrectAnswer;

                    var fakeAnswers = await questionHelper.GenerateFakeAnswers(randomQuestion.Data.Content);

                    if (fakeAnswers == null || fakeAnswers.Count < 3)
                    {
                        MessageBox.Show("Failed to generate fake answers. Using default fake answers.");
                        fakeAnswers = new List<string> { "Answer A", "Answer B", "Answer C", "Answer D" };
                    }

                    Random random = new Random();
                    int correctAnswerIndex = random.Next(0, 4);
                    Button[] buttons = { btn_option1, btn_option2, btn_option3, btn_option4 };
                    buttons[correctAnswerIndex].Text = correctAnswer;

                    int fakeAnswerIndex = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (i != correctAnswerIndex)
                        {
                            buttons[i].Text = fakeAnswers[fakeAnswerIndex];
                            fakeAnswerIndex++;
                        }
                    }
                }
                else
                {
                    tB_data.Text = "No questions found.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
