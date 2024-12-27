namespace NetStudy
{
    partial class FormUpdateUser
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
            avaPic = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtEmail = new TextBox();
            panel3 = new Panel();
            iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            txtUsername = new TextBox();
            panel2 = new Panel();
            iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            txtFullName = new TextBox();
            panel1 = new Panel();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            btnSelectImg = new Button();
            btnUpdate = new Button();
            linkChangePass = new LinkLabel();
            linkLogOut = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)avaPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            SuspendLayout();
            // 
            // avaPic
            // 
            avaPic.Location = new Point(218, 25);
            avaPic.Margin = new Padding(2);
            avaPic.Name = "avaPic";
            avaPic.Size = new Size(111, 111);
            avaPic.SizeMode = PictureBoxSizeMode.StretchImage;
            avaPic.TabIndex = 0;
            avaPic.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift SemiBold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 117, 214);
            label3.Location = new Point(25, 418);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(117, 27);
            label3.TabIndex = 34;
            label3.Text = "Your Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift SemiBold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 117, 214);
            label2.Location = new Point(26, 311);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(162, 27);
            label2.TabIndex = 33;
            label2.Text = "Your Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiBold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 117, 214);
            label1.Location = new Point(26, 205);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(161, 27);
            label1.TabIndex = 32;
            label1.Text = "Your Full Name";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = SystemColors.MenuHighlight;
            txtEmail.Location = new Point(90, 465);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(425, 26);
            txtEmail.TabIndex = 31;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 117, 214);
            panel3.Location = new Point(26, 508);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(489, 1);
            panel3.TabIndex = 30;
            // 
            // iconPictureBox4
            // 
            iconPictureBox4.BackColor = Color.White;
            iconPictureBox4.ForeColor = Color.FromArgb(0, 117, 214);
            iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Envelope;
            iconPictureBox4.IconColor = Color.FromArgb(0, 117, 214);
            iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox4.IconSize = 58;
            iconPictureBox4.Location = new Point(26, 448);
            iconPictureBox4.Margin = new Padding(2);
            iconPictureBox4.Name = "iconPictureBox4";
            iconPictureBox4.Size = new Size(58, 58);
            iconPictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPictureBox4.TabIndex = 29;
            iconPictureBox4.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = SystemColors.MenuHighlight;
            txtUsername.Location = new Point(90, 356);
            txtUsername.Margin = new Padding(2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(425, 26);
            txtUsername.TabIndex = 28;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 117, 214);
            panel2.Location = new Point(26, 400);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(489, 1);
            panel2.TabIndex = 27;
            // 
            // iconPictureBox3
            // 
            iconPictureBox3.BackColor = Color.White;
            iconPictureBox3.ForeColor = Color.FromArgb(0, 117, 214);
            iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.UserPen;
            iconPictureBox3.IconColor = Color.FromArgb(0, 117, 214);
            iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox3.IconSize = 58;
            iconPictureBox3.Location = new Point(26, 341);
            iconPictureBox3.Margin = new Padding(2);
            iconPictureBox3.Name = "iconPictureBox3";
            iconPictureBox3.Size = new Size(58, 58);
            iconPictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPictureBox3.TabIndex = 26;
            iconPictureBox3.TabStop = false;
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.None;
            txtFullName.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFullName.ForeColor = SystemColors.MenuHighlight;
            txtFullName.Location = new Point(90, 252);
            txtFullName.Margin = new Padding(2);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(425, 26);
            txtFullName.TabIndex = 25;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 117, 214);
            panel1.Location = new Point(26, 294);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(489, 1);
            panel1.TabIndex = 24;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.BackColor = Color.White;
            iconPictureBox2.ForeColor = Color.FromArgb(0, 117, 214);
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Tags;
            iconPictureBox2.IconColor = Color.FromArgb(0, 117, 214);
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.IconSize = 58;
            iconPictureBox2.Location = new Point(26, 235);
            iconPictureBox2.Margin = new Padding(2);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(58, 58);
            iconPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPictureBox2.TabIndex = 23;
            iconPictureBox2.TabStop = false;
            // 
            // btnSelectImg
            // 
            btnSelectImg.BackColor = Color.FromArgb(0, 117, 214);
            btnSelectImg.Cursor = Cursors.Hand;
            btnSelectImg.FlatAppearance.BorderSize = 0;
            btnSelectImg.FlatStyle = FlatStyle.Flat;
            btnSelectImg.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSelectImg.ForeColor = Color.White;
            btnSelectImg.Location = new Point(218, 152);
            btnSelectImg.Margin = new Padding(2);
            btnSelectImg.Name = "btnSelectImg";
            btnSelectImg.Size = new Size(111, 32);
            btnSelectImg.TabIndex = 44;
            btnSelectImg.Text = "Đổi ảnh";
            btnSelectImg.UseVisualStyleBackColor = false;
            btnSelectImg.Click += btnSelectImg_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(0, 117, 214);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(164, 538);
            btnUpdate.Margin = new Padding(2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(220, 55);
            btnUpdate.TabIndex = 45;
            btnUpdate.Text = "CẬP NHẬT";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // linkChangePass
            // 
            linkChangePass.AutoSize = true;
            linkChangePass.LinkColor = Color.FromArgb(192, 0, 192);
            linkChangePass.Location = new Point(424, 598);
            linkChangePass.Margin = new Padding(2, 0, 2, 0);
            linkChangePass.Name = "linkChangePass";
            linkChangePass.Size = new Size(119, 25);
            linkChangePass.TabIndex = 46;
            linkChangePass.TabStop = true;
            linkChangePass.Text = "Đổi mật khẩu";
            linkChangePass.LinkClicked += linkChangePass_LinkClicked;
            // 
            // linkLogOut
            // 
            linkLogOut.AutoSize = true;
            linkLogOut.LinkColor = Color.FromArgb(192, 0, 192);
            linkLogOut.Location = new Point(441, 9);
            linkLogOut.Margin = new Padding(2, 0, 2, 0);
            linkLogOut.Name = "linkLogOut";
            linkLogOut.Size = new Size(93, 25);
            linkLogOut.TabIndex = 47;
            linkLogOut.TabStop = true;
            linkLogOut.Text = "Đăng xuất";
            linkLogOut.LinkClicked += linkLogOut_LinkClicked;
            // 
            // FormUpdateUser
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(546, 632);
            Controls.Add(linkLogOut);
            Controls.Add(linkChangePass);
            Controls.Add(btnUpdate);
            Controls.Add(btnSelectImg);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(panel3);
            Controls.Add(iconPictureBox4);
            Controls.Add(txtUsername);
            Controls.Add(panel2);
            Controls.Add(iconPictureBox3);
            Controls.Add(txtFullName);
            Controls.Add(panel1);
            Controls.Add(iconPictureBox2);
            Controls.Add(avaPic);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(2);
            Name = "FormUpdateUser";
            Text = "Thông tin người dùng";
            FormClosing += FormUpdateUser_FormClosing;
            Load += FormUpdateUser_Load;
            ((System.ComponentModel.ISupportInitialize)avaPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox avaPic;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtEmail;
        private Panel panel3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private TextBox txtUsername;
        private Panel panel2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private TextBox txtFullName;
        private Panel panel1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private Button btnSelectImg;
        private Button btnUpdate;
        private LinkLabel linkChangePass;
        private LinkLabel linkLogOut;
    }
}