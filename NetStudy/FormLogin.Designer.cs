namespace NetStudy
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            LoginTitle = new Label();
            PicUser = new FontAwesome.Sharp.IconPictureBox();
            panel1 = new Panel();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            panel2 = new Panel();
            PicPassword = new FontAwesome.Sharp.IconPictureBox();
            btnLogin = new Button();
            linkRegister = new LinkLabel();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            linkClear = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)PicUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicPassword).BeginInit();
            SuspendLayout();
            // 
            // LoginTitle
            // 
            LoginTitle.AutoSize = true;
            LoginTitle.Font = new Font("Bahnschrift", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginTitle.ForeColor = Color.FromArgb(0, 117, 214);
            LoginTitle.Location = new Point(158, 175);
            LoginTitle.Name = "LoginTitle";
            LoginTitle.Size = new Size(173, 58);
            LoginTitle.TabIndex = 1;
            LoginTitle.Text = "LOG IN";
            // 
            // PicUser
            // 
            PicUser.BackColor = Color.White;
            PicUser.ForeColor = Color.FromArgb(0, 117, 214);
            PicUser.IconChar = FontAwesome.Sharp.IconChar.User;
            PicUser.IconColor = Color.FromArgb(0, 117, 214);
            PicUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            PicUser.IconSize = 48;
            PicUser.Location = new Point(45, 270);
            PicUser.Name = "PicUser";
            PicUser.Size = new Size(48, 48);
            PicUser.SizeMode = PictureBoxSizeMode.StretchImage;
            PicUser.TabIndex = 2;
            PicUser.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 117, 214);
            panel1.Location = new Point(45, 324);
            panel1.Name = "panel1";
            panel1.Size = new Size(380, 1);
            panel1.TabIndex = 3;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.BackColor = Color.White;
            iconPictureBox2.ForeColor = Color.FromArgb(0, 117, 214);
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            iconPictureBox2.IconColor = Color.FromArgb(0, 117, 214);
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.IconSize = 109;
            iconPictureBox2.Location = new Point(188, 50);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(116, 109);
            iconPictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            iconPictureBox2.TabIndex = 4;
            iconPictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 117, 214);
            panel2.Location = new Point(45, 418);
            panel2.Name = "panel2";
            panel2.Size = new Size(380, 1);
            panel2.TabIndex = 5;
            // 
            // PicPassword
            // 
            PicPassword.BackColor = Color.White;
            PicPassword.ForeColor = Color.FromArgb(0, 117, 214);
            PicPassword.IconChar = FontAwesome.Sharp.IconChar.Lock;
            PicPassword.IconColor = Color.FromArgb(0, 117, 214);
            PicPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            PicPassword.IconSize = 48;
            PicPassword.Location = new Point(45, 364);
            PicPassword.Name = "PicPassword";
            PicPassword.Size = new Size(48, 48);
            PicPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            PicPassword.TabIndex = 4;
            PicPassword.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 117, 214);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(45, 477);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(380, 55);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "LOG IN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // linkRegister
            // 
            linkRegister.AutoSize = true;
            linkRegister.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkRegister.LinkColor = Color.FromArgb(0, 117, 214);
            linkRegister.Location = new Point(326, 579);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(85, 26);
            linkRegister.TabIndex = 7;
            linkRegister.TabStop = true;
            linkRegister.Text = "Sign up";
            linkRegister.LinkClicked += linkRegister_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(0, 117, 214);
            label2.Location = new Point(63, 582);
            label2.Name = "label2";
            label2.Size = new Size(268, 23);
            label2.TabIndex = 9;
            label2.Text = "Do not you have an account ?";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.FromArgb(0, 117, 214);
            txtUsername.Location = new Point(99, 280);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(326, 29);
            txtUsername.TabIndex = 10;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.FromArgb(0, 117, 214);
            txtPassword.Location = new Point(99, 375);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(326, 29);
            txtPassword.TabIndex = 11;
            // 
            // linkClear
            // 
            linkClear.AutoSize = true;
            linkClear.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkClear.LinkColor = Color.FromArgb(0, 117, 214);
            linkClear.Location = new Point(316, 438);
            linkClear.Name = "linkClear";
            linkClear.Size = new Size(127, 26);
            linkClear.TabIndex = 12;
            linkClear.TabStop = true;
            linkClear.Text = "Clear fields";
            linkClear.LinkClicked += linkClear_LinkClicked_1;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(471, 644);
            Controls.Add(linkClear);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(linkRegister);
            Controls.Add(btnLogin);
            Controls.Add(panel2);
            Controls.Add(PicPassword);
            Controls.Add(iconPictureBox2);
            Controls.Add(panel1);
            Controls.Add(PicUser);
            Controls.Add(LoginTitle);
            Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 3, 5, 3);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập vào NetStudy";
            Load += FormLogin_Load;
            ((System.ComponentModel.ISupportInitialize)PicUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicPassword).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label LoginTitle;
        private FontAwesome.Sharp.IconPictureBox PicUser;
        private Panel panel1;
        private Panel panel2;
        private FontAwesome.Sharp.IconPictureBox PicPassword;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private Button btnLogin;
        private LinkLabel linkRegister;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private LinkLabel linkClear;
    }
}