using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NetStudy.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetStudy.Forms
{
    public partial class FormDocument : Form
    {
        private readonly HttpClient _httpClient;
        private string _currentUser;
        private string _selectedDocumentId;
        private string _accessToken;

        public FormDocument(string accessToken, string username)
        {
            InitializeComponent();
            _currentUser = username;
            _accessToken = accessToken;
            textBox_myusrname.Text = _currentUser;

            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7070/") };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
        }

        private void FormDocument_Load(object sender, EventArgs e)
        {

        }

        private async void button_mydcm_Click(object sender, EventArgs e)
        {
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button_search_Click(object sender, EventArgs e)
        {
            await SearchAndUpdateDocumentsAsync();
        }

        private async Task SearchAndUpdateDocumentsAsync()
        {
            string keyword = textBox_search.Text;
            var documents = await SearchDocumentsAsync(keyword);
            DisplayDocuments(documents);
        }

        private async Task<List<Document>> SearchDocumentsAsync(string keyword)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/documents/search?keyword={keyword}&username={_currentUser}");
                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<Document>>(jsonResponse);
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode}\n{jsonResponse}", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<Document>();
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Request error: {ex.Message}", "Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Document>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Document>();
            }
        }
        private void DisplayDocuments(List<Document> documents)
        {
            panel_body.Controls.Clear();
            int yOffset = 0;

            foreach (var doc in documents)
            {
                var label = new Label
                {
                    Text = $"Title: {doc.Title}, Tag: {doc.Tag}, Uploader: {doc.UploaderName}",
                    AutoSize = true,
                    Tag = doc.Id,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    Location = new Point(0, yOffset)
                };
                label.Click += Label_Click;
                panel_body.Controls.Add(label);

                yOffset += 45;
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                _selectedDocumentId = label.Tag.ToString();
            }
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            var uploadForm = new DocumentUpload(_currentUser, _accessToken);
            uploadForm.ShowDialog();
        }

        private async void button_download_Click(object sender, EventArgs e)
        {
            string documentId = GetSelectedDocumentId();
            if (!string.IsNullOrEmpty(documentId))
            {
                DownloadDocument(documentId);
            }
        }

        private async void DownloadDocument(string documentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/documents/download/{documentId}?username={_currentUser}");
                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();

                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "All files (*.*)|*.*";
                        saveFileDialog.Title = "Save Document";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                            {
                                await stream.CopyToAsync(fileStream);
                            }
                            MessageBox.Show("Document downloaded successfully.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode}\n{jsonResponse}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Request error: {ex.Message}\nUsername: {_currentUser}", "Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}\nUsername: {_currentUser}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button_edit_Click(object sender, EventArgs e)
        {
            string documentId = GetSelectedDocumentId();
            if (!string.IsNullOrEmpty(documentId))
            {
                var document = await GetDocumentDetailsAsync(documentId);
                if (document != null && document.UploaderName == _currentUser)
                {
                    var editForm = new DocumentEdit(documentId, _accessToken);
                    editForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You can only edit documents that you have uploaded.");
                }
            }
            else
            {
                MessageBox.Show("Please select a document to edit.");
            }
        }

        private async Task<UploadResponse> GetDocumentDetailsAsync(string documentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/documents/{documentId}");
                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<UploadResponse>(jsonResponse);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Document not found. It may have been deleted.", "Get Document Details Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode}\n{jsonResponse}", "Get Document Details Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Request error: {ex.Message}\nDocument ID: {documentId}", "Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}\nDocument ID: {documentId}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private async void button_delete_Click(object sender, EventArgs e)
        {
            string documentId = GetSelectedDocumentId();
            if (!string.IsNullOrEmpty(documentId))
            {
                var document = await GetDocumentDetailsAsync(documentId);
                if (document != null && document.UploaderName == _currentUser)
                {
                    await DeleteDocumentAsync(documentId);
                }
                else if (document == null)
                {
                    MessageBox.Show($"Document not found or you do not have permission to delete it.\nDocument ID: {documentId}\nUploader: {document?.UploaderName}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"You can only delete documents that you have uploaded.\nDocument ID: {documentId}\nUploader: {document.UploaderName}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a document to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task DeleteDocumentAsync(string documentId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/documents/delete/{documentId}");
                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Document deleted successfully.\nDocument ID: {documentId}");
                    await SearchAndUpdateDocumentsAsync();
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode}\n{jsonResponse}\nDocument ID: {documentId}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Request error: {ex.Message}\nDocument ID: {documentId}", "Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}\nDocument ID: {documentId}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSelectedDocumentId()
        {
            return _selectedDocumentId;
        }
    }
}