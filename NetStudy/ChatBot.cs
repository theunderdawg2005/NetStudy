using NetStudy.Services;
using Newtonsoft.Json.Linq;
using NetStudy.Models;
using System.Text;
using NetStudy.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using DocumentFormat.OpenXml.Packaging;

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
        private FormExam FormExam;

        public ChatBot(JObject info, string token, FormExam formExam)
        {
            InitializeComponent();
            FormExam = formExam;
            UserInfo = info;
            accessToken = token;
            lbl_username.Text = UserInfo["username"].ToString();
            chatBotService = new ChatBotService(accessToken);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }

        private async void btn_send_Click(object sender, EventArgs e)
        {
            string message = tB_message.Text;
            string filePath = tB_filepath.Text; 

            if (string.IsNullOrWhiteSpace(message) && string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Please enter a message or upload a file.");
                return;
            }

            try
            {
                string userName = UserInfo["username"].ToString();
                string messageWithLabel = $"{userName}: {message}{Environment.NewLine}";

                AppendColoredText(tB_respones, userName + ": ", Color.Green);
                AppendColoredText(tB_respones, message + Environment.NewLine, Color.Black);

                string contentToSend = message;

                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    string fileContent = readData(filePath);
                    contentToSend += $"\n\n[File Content]:\n{fileContent}";
                }

                var responseData = await chatBotService.Chat(contentToSend);
                if (responseData != null && !string.IsNullOrEmpty(responseData.Response))
                {
                    //string formattedResponse = string.Join(Environment.NewLine, responseData.Response
                    //    .Trim()
                    //    .Split('\n')
                    //    .Select(sentence => sentence.Trim().Length > 0 ? char.ToUpper(sentence.Trim()[0]) + sentence.Trim().Substring(1) + '.' : string.Empty)
                    //    .Where(line => !string.IsNullOrWhiteSpace(line))
                    //);
                    string formattedResponse = string.Join(Environment.NewLine, responseData.Response
                            .Trim()
                            .Split('\n')
                            .Select(sentence => sentence.Trim()
                            .Replace("*", "")
                            .Trim())
                            .Where(line => !string.IsNullOrWhiteSpace(line))
                            .Select(line => line.Length > 0 ? char.ToUpper(line[0]) + line.Substring(1) + '.' : string.Empty)
                     );

                    AppendColoredText(tB_respones, "NetStudy: ", Color.Blue);
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
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "All Files (*.*)|*.*",
                Title = "Select a File"
            };

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

        private string readData(string filePath)
        {
            const int MaxFileSizeInBytes = 20 * 1024 * 1024; 
            const int MaxContentLength = 900000; 

            StringBuilder text = new StringBuilder();
            string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Length > MaxFileSizeInBytes)
                {
                    MessageBox.Show("The file is too large to process. Maximum size allowed is 20 MB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return string.Empty;
                }

                switch (fileExtension)
                {
                    case ".txt":
                        text.Append(File.ReadAllText(filePath));
                        break;

                    case ".pdf":
                        PdfReader pdfReader = new PdfReader(filePath);
                        for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                        {
                            text.Append(PdfTextExtractor.GetTextFromPage(pdfReader, page));
                        }
                        pdfReader.Close();
                        break;

                    case ".docx":
                        using (var wordDocument = WordprocessingDocument.Open(filePath, false))
                        {
                            var body = wordDocument.MainDocumentPart.Document.Body;
                            text.Append(body.InnerText);
                        }
                        break;

                    default:
                        text.Append($"Unsupported file type: {fileExtension}");
                        break;
                }

                if (text.Length > MaxContentLength)
                {
                    MessageBox.Show("The file content is too large to process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                text.Append($"Error reading file: {ex.Message}");
            }

            return text.ToString();
        }

        private void ChatBot_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormExam.Show();
        }

    }
}
