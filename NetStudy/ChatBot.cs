using NetStudy.Services;
using Newtonsoft.Json.Linq;
using NetStudy.Models;
using System.Text;

namespace NetStudy
{
    public partial class ChatBot : Form
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        private JObject UserInfo;
        private string accessToken;
        private ChatBotService chatBotService;
        private RichTextBox tB_respones;

        public ChatBot(JObject info, string token)
        {
            InitializeComponent();
            UserInfo = info;
            accessToken = token;
            lbl_username.Text = UserInfo["username"].ToString();
            chatBotService = new ChatBotService(accessToken);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }

        private async void btn_send_Click(object sender, EventArgs e)
        {
            string message = tB_message.Text;
            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Please enter a message");
                return;
            }
            try
            {
                string userName = UserInfo["username"].ToString();
                string messageWithLabel = $"{userName}: {message}{Environment.NewLine}";

                AppendColoredText(tB_respones, userName + ": ", Color.Green);
                AppendColoredText(tB_respones, message + Environment.NewLine, Color.Black);

                var responseData = await chatBotService.Chat(message);
                if (responseData != null && !string.IsNullOrEmpty(responseData.Response))
                {
                    string formattedResponse = string.Join(Environment.NewLine, responseData.Response
                        .Trim()
                        .Split('\n')
                        .Select(sentence => sentence.Trim().Length > 0 ? char.ToUpper(sentence.Trim()[0]) + sentence.Trim().Substring(1) + '.' : string.Empty)
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                    );

                    AppendColoredText(tB_respones, "Gemini: ", Color.Blue);
                    AppendColoredText(tB_respones, formattedResponse + Environment.NewLine, Color.Black);

                    tB_message.Clear();
                }
                else
                {
                    MessageBox.Show("No response from bot");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AppendColoredText(RichTextBox richTextBox, string text, Color color)
        {
            richTextBox.SelectionStart = richTextBox.TextLength;
            richTextBox.SelectionLength = 0;
            richTextBox.SelectionColor = color;
            richTextBox.AppendText(text);
            richTextBox.SelectionColor = richTextBox.ForeColor;
        }

        private void btn_clear2_Click(object sender, EventArgs e)
        {
            tB_respones.Text = "";
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                tB_filepath.Text = filePath;

                if (!string.IsNullOrEmpty(filePath))
                {

                    MessageBox.Show("File uploaded.");
                }
            }
        }

    }
}
