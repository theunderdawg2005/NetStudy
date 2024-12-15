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
            if (message == "")
            {
                MessageBox.Show("Please enter a message");
                return;
            }
            try
            {
                string UserName = UserInfo["username"].ToString();
                string messageWithLabel = UserName + ": " + message + Environment.NewLine;
                tB_respones.AppendText(messageWithLabel);

                var responseData = await chatBotService.Chat(message);
                if (responseData != null && !string.IsNullOrEmpty(responseData.Response))
                {
                    string formattedResponse = string.Join(Environment.NewLine, responseData.Response
                        .Trim()
                        .Split('\n')
                        .Select(sentence => sentence.Trim().Length > 0 ? char.ToUpper(sentence.Trim()[0]) + sentence.Trim().Substring(1) + '.' : string.Empty)
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                    );

                    string botResponse = "Gemini: " + Environment.NewLine + formattedResponse + Environment.NewLine;
                    tB_respones.AppendText(botResponse);
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

                string pdfContentBase64 = ReadPdfFileAsBase64(filePath);

                if (!string.IsNullOrEmpty(pdfContentBase64))
                {
                    string storedPdfContent = pdfContentBase64;

                    MessageBox.Show("File uploaded and content encoded to Base64.");
                }
            }
        }

        private string ReadPdfFileAsBase64(string filePath)
        {
            try
            {
                byte[] fileContent = File.ReadAllBytes(filePath);

                string base64Content = Convert.ToBase64String(fileContent);

                return base64Content;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
                return null;
            }
        }
    }
}
