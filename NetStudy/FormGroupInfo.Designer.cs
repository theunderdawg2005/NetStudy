namespace NetStudy
{
    partial class FormGroupInfo
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
            lblTitle = new Label();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            txtDescription = new RichTextBox();
            txtName = new TextBox();
            panel2 = new Panel();
            PicPassword = new FontAwesome.Sharp.IconPictureBox();
            panel1 = new Panel();
            PicUser = new FontAwesome.Sharp.IconPictureBox();
            btnExit = new FontAwesome.Sharp.IconButton();
            linkDelGroup = new LinkLabel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicUser).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Bahnschrift", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(0, 117, 214);
            lblTitle.Location = new Point(182, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(222, 58);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Thông tin";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(PicPassword);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(PicUser);
            groupBox1.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(0, 117, 214);
            groupBox1.Location = new Point(12, 94);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(558, 520);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giới thiệu về nhóm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(0, 117, 214);
            label4.Location = new Point(86, 139);
            label4.Name = "label4";
            label4.Size = new Size(60, 23);
            label4.TabIndex = 23;
            label4.Text = "Mô tả";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 117, 214);
            label3.Location = new Point(86, 37);
            label3.Name = "label3";
            label3.Size = new Size(102, 23);
            label3.TabIndex = 22;
            label3.Text = "Tên nhóm";
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.White;
            txtDescription.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(140, 174);
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(326, 257);
            txtDescription.TabIndex = 21;
            txtDescription.Text = "";
            // 
            // txtName
            // 
            txtName.BackColor = Color.White;
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtName.ForeColor = Color.FromArgb(0, 117, 214);
            txtName.Location = new Point(140, 81);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(326, 29);
            txtName.TabIndex = 18;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 117, 214);
            panel2.Location = new Point(140, 437);
            panel2.Name = "panel2";
            panel2.Size = new Size(326, 1);
            panel2.TabIndex = 16;
            // 
            // PicPassword
            // 
            PicPassword.BackColor = Color.White;
            PicPassword.ForeColor = Color.FromArgb(0, 117, 214);
            PicPassword.IconChar = FontAwesome.Sharp.IconChar.PenRuler;
            PicPassword.IconColor = Color.FromArgb(0, 117, 214);
            PicPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            PicPassword.IconSize = 48;
            PicPassword.Location = new Point(86, 174);
            PicPassword.Name = "PicPassword";
            PicPassword.Size = new Size(48, 48);
            PicPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            PicPassword.TabIndex = 15;
            PicPassword.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 117, 214);
            panel1.Location = new Point(86, 125);
            panel1.Name = "panel1";
            panel1.Size = new Size(380, 1);
            panel1.TabIndex = 14;
            // 
            // PicUser
            // 
            PicUser.BackColor = Color.White;
            PicUser.ForeColor = Color.FromArgb(0, 117, 214);
            PicUser.IconChar = FontAwesome.Sharp.IconChar.Tag;
            PicUser.IconColor = Color.FromArgb(0, 117, 214);
            PicUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            PicUser.IconSize = 48;
            PicUser.Location = new Point(86, 71);
            PicUser.Name = "PicUser";
            PicUser.Size = new Size(48, 48);
            PicUser.SizeMode = PictureBoxSizeMode.StretchImage;
            PicUser.TabIndex = 13;
            PicUser.TabStop = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.IndianRed;
            btnExit.FlatAppearance.BorderColor = Color.Gainsboro;
            btnExit.FlatAppearance.BorderSize = 2;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnExit.IconColor = Color.Black;
            btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnExit.IconSize = 30;
            btnExit.Location = new Point(543, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(36, 34);
            btnExit.TabIndex = 4;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // linkDelGroup
            // 
            linkDelGroup.AutoSize = true;
            linkDelGroup.LinkColor = Color.FromArgb(192, 0, 192);
            linkDelGroup.Location = new Point(12, 9);
            linkDelGroup.Name = "linkDelGroup";
            linkDelGroup.Size = new Size(123, 25);
            linkDelGroup.TabIndex = 5;
            linkDelGroup.TabStop = true;
            linkDelGroup.Text = "Giải tán nhóm";
            linkDelGroup.LinkClicked += linkDelGroup_LinkClicked;
            // 
            // FormGroupInfo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(582, 626);
            Controls.Add(linkDelGroup);
            Controls.Add(btnExit);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormGroupInfo";
            Text = "Thông tin nhóm";
            Load += FormGroupInfo_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PicPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private RichTextBox txtDescription;
        private TextBox txtName;
        private Panel panel2;
        private FontAwesome.Sharp.IconPictureBox PicPassword;
        private Panel panel1;
        private FontAwesome.Sharp.IconPictureBox PicUser;
        private FontAwesome.Sharp.IconButton btnExit;
        private LinkLabel linkDelGroup;
    }
}