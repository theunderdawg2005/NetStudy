using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudy.Services
{
    public class SingleChatService
    {
        public static HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7103/")
        };
        private readonly AesService _aesService;
        private readonly RsaService _rsaService;
        private readonly UserService _userService;
        private string accessToken;
        public SingleChatService(string token) {
            _aesService = new AesService();
            _rsaService = new RsaService();
            accessToken = token;
            _userService = new UserService(accessToken);
        }
        
        public async Task SendMessage(string sendername, string receivername, string message)
        {
            try
            {
                string aesKey = _aesService.GenerateAesKey();
                var content = _aesService.EncryptMessage(message, aesKey);
                var sender = await _userService.GetUserByUsername(sendername);
                var senderKey = _rsaService.Encrypt(aesKey, sender.PublicKey);
                //MessageBox.Show(sender.PublicKey);
                var receiver = await _userService.GetUserByUsername(receivername);
                var receiverKey = _rsaService.Encrypt(aesKey, receiver.PublicKey);
                //MessageBox.Show(receiver.PublicKey);
                var contentMsg = new
                {
                    Sender = sendername,
                    Receiver = receivername,
                    Content = content,
                    SessionKeyEncrypted = new Dictionary<string, string>
                    {
                        {   sendername, senderKey },
                        {   receivername, receiverKey }
                    }
                };
                var json = JsonConvert.SerializeObject(contentMsg);
                var contentReq = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/chat/send", contentReq);
                if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                {
                    MessageBox.Show("Đã có lỗi gì đó! Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var res = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(res))
                {
                    MessageBox.Show("Phản hồi từ server rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //var msg = JObject.Parse(res)["message"].ToString();
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(res, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task<JObject> GetMessage(string user1, string user2)
        {
            try
            {
                
                
                var response = await _httpClient.GetAsync($"api/chat/history?user1={user1}&user2={user2}");
                if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                {
                    MessageBox.Show("Đã có lỗi gì đó! Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                var res = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(res))
                {
                    MessageBox.Show("Phản hồi từ server rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                var msgs = JObject.Parse(res);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(res, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return msgs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
