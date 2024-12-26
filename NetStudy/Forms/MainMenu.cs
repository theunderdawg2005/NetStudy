using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using FontAwesome.Sharp;
using NetStudy.Forms;
using NetStudy.Services;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NetStudy.Forms
{
    public partial class MainMenu : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private JObject UserInfo;
        private string accessToken;
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7070/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        private TokenService _tokenService;
        //Constructor
        public MainMenu(string accessToken, JObject info)
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.accessToken = accessToken;
            var tokenService = new TokenService(httpClient);
            _tokenService = tokenService;

            _tokenService.SetTokens(accessToken);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            UserInfo = info;
        }
        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }
        //Events
        //Reset
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }
        //Menu Button_Clicks
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormDashboard(UserInfo, accessToken));
        }
        private void btnDocument_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            string username = UserInfo["username"].ToString();
            OpenChildForm(new FormDocument(accessToken, username));
        }
        private void btnChat_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            string username = UserInfo["username"].ToString();
            OpenChildForm(new FormChat(accessToken, username));
        }
        private void btnClass_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FormClass());
        }
        private void btnExam_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new FormExam(UserInfo, accessToken));
        }
        private void btnMatch_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);

            OpenChildForm(new FormMatch(UserInfo, accessToken));
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
        public void DrawCircular(PictureBox pictureBox)
        {
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, width, height);
            pictureBox.Region = new Region(path);
        }

        private async void LoadImage(string imgUrl)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(imgUrl) ||
                !Uri.TryCreate(imgUrl, UriKind.Absolute, out var uriRes) ||
                !(uriRes.Scheme == Uri.UriSchemeHttp || uriRes.Scheme == Uri.UriSchemeHttps))
                {
                    avaPic.Image = LoadDefaultImg();
                    return;
                }
                var imageBytes = await httpClient.GetByteArrayAsync(imgUrl);
                using (var ms = new MemoryStream(imageBytes))
                {
                    if (ms != null && ms.CanRead)
                    {
                        ms.Seek(0, SeekOrigin.Begin);
                        Image image = Image.FromStream(ms);
                        avaPic.Image = image;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image LoadDefaultImg()
        {
            string defaultUrl = "https://i.pinimg.com/736x/62/ee/b3/62eeb37155f0df95a708586aed9165c5.jpg";
            using (var client = new HttpClient())
            {
                var bytes = client.GetByteArrayAsync(defaultUrl).Result;
                using (var ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
        }

        private void btnGroupChat_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new FormGroups(accessToken, UserInfo));
        }
        private void setUserInfo()
        {
            lblName.Text = UserInfo["name"].ToString();
            LoadImage(UserInfo["avatar"].ToString());
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            setUserInfo();
            DrawCircular(avaPic);
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {
            FormUpdateUser formUpdateUser = new FormUpdateUser(accessToken, UserInfo);
            formUpdateUser.Show();
        }

        private void btnSettingUser_Click(object sender, EventArgs e)
        {
            FormUpdateUser formUpdateUser = new FormUpdateUser(accessToken, UserInfo);
            formUpdateUser.Show();
        }
    }
}
