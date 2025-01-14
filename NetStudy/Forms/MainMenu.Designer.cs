﻿namespace NetStudy.Forms
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            panelMenu = new Panel();
            linkRefresh = new LinkLabel();
            btnGroupChat = new FontAwesome.Sharp.IconButton();
            btnMatch = new FontAwesome.Sharp.IconButton();
            btnExam = new FontAwesome.Sharp.IconButton();
            btnClass = new FontAwesome.Sharp.IconButton();
            btnChat = new FontAwesome.Sharp.IconButton();
            btnDocument = new FontAwesome.Sharp.IconButton();
            btnDashboard = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            lblName = new Label();
            avaPic = new PictureBox();
            panelTitleBar = new Panel();
            btnSettingUser = new FontAwesome.Sharp.IconButton();
            lblTitleChildForm = new Label();
            iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            panelDesktop = new Panel();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)avaPic).BeginInit();
            panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(31, 30, 68);
            panelMenu.Controls.Add(linkRefresh);
            panelMenu.Controls.Add(btnGroupChat);
            panelMenu.Controls.Add(btnMatch);
            panelMenu.Controls.Add(btnExam);
            panelMenu.Controls.Add(btnClass);
            panelMenu.Controls.Add(btnChat);
            panelMenu.Controls.Add(btnDocument);
            panelMenu.Controls.Add(btnDashboard);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(275, 865);
            panelMenu.TabIndex = 0;
            // 
            // linkRefresh
            // 
            linkRefresh.AutoSize = true;
            linkRefresh.LinkColor = Color.FromArgb(192, 0, 192);
            linkRefresh.Location = new Point(15, 944);
            linkRefresh.Margin = new Padding(4, 0, 4, 0);
            linkRefresh.Name = "linkRefresh";
            linkRefresh.Size = new Size(113, 25);
            linkRefresh.TabIndex = 8;
            linkRefresh.TabStop = true;
            linkRefresh.Text = "Refresh Page";
            linkRefresh.LinkClicked += linkRefresh_LinkClicked;
            // 
            // btnGroupChat
            // 
            btnGroupChat.Cursor = Cursors.Hand;
            btnGroupChat.Dock = DockStyle.Top;
            btnGroupChat.FlatAppearance.BorderSize = 0;
            btnGroupChat.FlatStyle = FlatStyle.Flat;
            btnGroupChat.ForeColor = Color.Gainsboro;
            btnGroupChat.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            btnGroupChat.IconColor = Color.Gainsboro;
            btnGroupChat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGroupChat.IconSize = 32;
            btnGroupChat.ImageAlign = ContentAlignment.MiddleLeft;
            btnGroupChat.Location = new Point(0, 625);
            btnGroupChat.Margin = new Padding(4);
            btnGroupChat.Name = "btnGroupChat";
            btnGroupChat.Padding = new Padding(12, 0, 25, 0);
            btnGroupChat.Size = new Size(275, 75);
            btnGroupChat.TabIndex = 7;
            btnGroupChat.Text = "Hội nhóm";
            btnGroupChat.TextAlign = ContentAlignment.MiddleLeft;
            btnGroupChat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGroupChat.UseVisualStyleBackColor = true;
            btnGroupChat.Click += btnGroupChat_Click;
            // 
            // btnMatch
            // 
            btnMatch.Cursor = Cursors.Hand;
            btnMatch.Dock = DockStyle.Top;
            btnMatch.FlatAppearance.BorderSize = 0;
            btnMatch.FlatStyle = FlatStyle.Flat;
            btnMatch.ForeColor = Color.Gainsboro;
            btnMatch.IconChar = FontAwesome.Sharp.IconChar.Handshake;
            btnMatch.IconColor = Color.Gainsboro;
            btnMatch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMatch.IconSize = 32;
            btnMatch.ImageAlign = ContentAlignment.MiddleLeft;
            btnMatch.Location = new Point(0, 550);
            btnMatch.Margin = new Padding(4);
            btnMatch.Name = "btnMatch";
            btnMatch.Padding = new Padding(12, 0, 25, 0);
            btnMatch.Size = new Size(275, 75);
            btnMatch.TabIndex = 6;
            btnMatch.Text = "Bạn học";
            btnMatch.TextAlign = ContentAlignment.MiddleLeft;
            btnMatch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMatch.UseVisualStyleBackColor = true;
            btnMatch.Click += btnMatch_Click;
            // 
            // btnExam
            // 
            btnExam.Cursor = Cursors.Hand;
            btnExam.Dock = DockStyle.Top;
            btnExam.FlatAppearance.BorderSize = 0;
            btnExam.FlatStyle = FlatStyle.Flat;
            btnExam.ForeColor = Color.Gainsboro;
            btnExam.IconChar = FontAwesome.Sharp.IconChar.PenRuler;
            btnExam.IconColor = Color.Gainsboro;
            btnExam.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnExam.IconSize = 32;
            btnExam.ImageAlign = ContentAlignment.MiddleLeft;
            btnExam.Location = new Point(0, 475);
            btnExam.Margin = new Padding(4);
            btnExam.Name = "btnExam";
            btnExam.Padding = new Padding(12, 0, 25, 0);
            btnExam.Size = new Size(275, 75);
            btnExam.TabIndex = 5;
            btnExam.Text = "Ôn tập";
            btnExam.TextAlign = ContentAlignment.MiddleLeft;
            btnExam.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExam.UseVisualStyleBackColor = true;
            btnExam.Click += btnExam_Click;
            // 
            // btnClass
            // 
            btnClass.Cursor = Cursors.Hand;
            btnClass.Dock = DockStyle.Top;
            btnClass.FlatAppearance.BorderSize = 0;
            btnClass.FlatStyle = FlatStyle.Flat;
            btnClass.ForeColor = Color.Gainsboro;
            btnClass.IconChar = FontAwesome.Sharp.IconChar.UsersRectangle;
            btnClass.IconColor = Color.Gainsboro;
            btnClass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClass.IconSize = 32;
            btnClass.ImageAlign = ContentAlignment.MiddleLeft;
            btnClass.Location = new Point(0, 400);
            btnClass.Margin = new Padding(4);
            btnClass.Name = "btnClass";
            btnClass.Padding = new Padding(12, 0, 25, 0);
            btnClass.Size = new Size(275, 75);
            btnClass.TabIndex = 4;
            btnClass.Text = "Lớp học";
            btnClass.TextAlign = ContentAlignment.MiddleLeft;
            btnClass.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClass.UseVisualStyleBackColor = true;
            btnClass.Click += btnClass_Click;
            // 
            // btnChat
            // 
            btnChat.Cursor = Cursors.Hand;
            btnChat.Dock = DockStyle.Top;
            btnChat.FlatAppearance.BorderSize = 0;
            btnChat.FlatStyle = FlatStyle.Flat;
            btnChat.ForeColor = Color.Gainsboro;
            btnChat.IconChar = FontAwesome.Sharp.IconChar.Comment;
            btnChat.IconColor = Color.Gainsboro;
            btnChat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnChat.IconSize = 32;
            btnChat.ImageAlign = ContentAlignment.MiddleLeft;
            btnChat.Location = new Point(0, 325);
            btnChat.Margin = new Padding(4);
            btnChat.Name = "btnChat";
            btnChat.Padding = new Padding(12, 0, 25, 0);
            btnChat.Size = new Size(275, 75);
            btnChat.TabIndex = 3;
            btnChat.Text = "Đoạn chat";
            btnChat.TextAlign = ContentAlignment.MiddleLeft;
            btnChat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnChat.UseVisualStyleBackColor = true;
            btnChat.Click += btnChat_Click;
            // 
            // btnDocument
            // 
            btnDocument.Cursor = Cursors.Hand;
            btnDocument.Dock = DockStyle.Top;
            btnDocument.FlatAppearance.BorderSize = 0;
            btnDocument.FlatStyle = FlatStyle.Flat;
            btnDocument.ForeColor = Color.Gainsboro;
            btnDocument.IconChar = FontAwesome.Sharp.IconChar.File;
            btnDocument.IconColor = Color.Gainsboro;
            btnDocument.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDocument.IconSize = 32;
            btnDocument.ImageAlign = ContentAlignment.MiddleLeft;
            btnDocument.Location = new Point(0, 250);
            btnDocument.Margin = new Padding(4);
            btnDocument.Name = "btnDocument";
            btnDocument.Padding = new Padding(12, 0, 25, 0);
            btnDocument.Size = new Size(275, 75);
            btnDocument.TabIndex = 2;
            btnDocument.Text = "Tài liệu";
            btnDocument.TextAlign = ContentAlignment.MiddleLeft;
            btnDocument.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDocument.UseVisualStyleBackColor = true;
            btnDocument.Click += btnDocument_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = Color.Gainsboro;
            btnDashboard.IconChar = FontAwesome.Sharp.IconChar.Star;
            btnDashboard.IconColor = Color.Gainsboro;
            btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDashboard.IconSize = 32;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(0, 175);
            btnDashboard.Margin = new Padding(4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(12, 0, 25, 0);
            btnDashboard.Size = new Size(275, 75);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Tổng quan";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(lblName);
            panelLogo.Controls.Add(avaPic);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(4);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(275, 175);
            panelLogo.TabIndex = 0;
            panelLogo.Paint += panelLogo_Paint;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Cursor = Cursors.Hand;
            lblName.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.Gainsboro;
            lblName.Location = new Point(56, 135);
            lblName.Margin = new Padding(2, 0, 2, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(170, 28);
            lblName.TabIndex = 1;
            lblName.Text = "User Full Name";
            lblName.Click += lblName_Click;
            // 
            // avaPic
            // 
            avaPic.Location = new Point(81, 12);
            avaPic.Margin = new Padding(2);
            avaPic.Name = "avaPic";
            avaPic.Size = new Size(111, 111);
            avaPic.SizeMode = PictureBoxSizeMode.StretchImage;
            avaPic.TabIndex = 0;
            avaPic.TabStop = false;
            avaPic.Click += avaPic_Click;
            // 
            // panelTitleBar
            // 
            panelTitleBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelTitleBar.BackColor = Color.FromArgb(26, 25, 62);
            panelTitleBar.Controls.Add(btnSettingUser);
            panelTitleBar.Controls.Add(lblTitleChildForm);
            panelTitleBar.Controls.Add(iconCurrentChildForm);
            panelTitleBar.Location = new Point(275, 0);
            panelTitleBar.Margin = new Padding(4);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(1537, 92);
            panelTitleBar.TabIndex = 1;
            // 
            // btnSettingUser
            // 
            btnSettingUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettingUser.AutoSize = true;
            btnSettingUser.BackColor = Color.FromArgb(26, 25, 62);
            btnSettingUser.Cursor = Cursors.Hand;
            btnSettingUser.FlatAppearance.BorderColor = Color.Gainsboro;
            btnSettingUser.FlatAppearance.BorderSize = 2;
            btnSettingUser.FlatStyle = FlatStyle.Flat;
            btnSettingUser.IconChar = FontAwesome.Sharp.IconChar.Cog;
            btnSettingUser.IconColor = Color.Gainsboro;
            btnSettingUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSettingUser.IconSize = 35;
            btnSettingUser.Location = new Point(1441, 12);
            btnSettingUser.Margin = new Padding(2);
            btnSettingUser.Name = "btnSettingUser";
            btnSettingUser.Size = new Size(56, 56);
            btnSettingUser.TabIndex = 4;
            btnSettingUser.UseVisualStyleBackColor = false;
            btnSettingUser.Click += btnSettingUser_Click;
            // 
            // lblTitleChildForm
            // 
            lblTitleChildForm.AutoSize = true;
            lblTitleChildForm.ForeColor = Color.Gainsboro;
            lblTitleChildForm.Location = new Point(82, 36);
            lblTitleChildForm.Margin = new Padding(4, 0, 4, 0);
            lblTitleChildForm.Name = "lblTitleChildForm";
            lblTitleChildForm.Size = new Size(61, 25);
            lblTitleChildForm.TabIndex = 1;
            lblTitleChildForm.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            iconCurrentChildForm.BackColor = Color.FromArgb(26, 25, 62);
            iconCurrentChildForm.ForeColor = Color.MediumPurple;
            iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCurrentChildForm.IconSize = 40;
            iconCurrentChildForm.Location = new Point(35, 28);
            iconCurrentChildForm.Margin = new Padding(4);
            iconCurrentChildForm.Name = "iconCurrentChildForm";
            iconCurrentChildForm.Size = new Size(40, 40);
            iconCurrentChildForm.TabIndex = 0;
            iconCurrentChildForm.TabStop = false;
            // 
            // panelDesktop
            // 
            panelDesktop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDesktop.BackColor = Color.FromArgb(34, 33, 74);
            panelDesktop.Location = new Point(275, 85);
            panelDesktop.Margin = new Padding(4);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1537, 780);
            panelDesktop.TabIndex = 2;
            panelDesktop.Paint += panelDesktop_Paint;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1813, 865);
            Controls.Add(panelDesktop);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NETSTUDY";
            Load += MainMenu_Load;
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)avaPic).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnMatch;
        private FontAwesome.Sharp.IconButton btnExam;
        private FontAwesome.Sharp.IconButton btnClass;
        private FontAwesome.Sharp.IconButton btnChat;
        private FontAwesome.Sharp.IconButton btnDocument;
        private Panel panelTitleBar;
        private Label lblTitleChildForm;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private Panel panelDesktop;
        private FontAwesome.Sharp.IconButton btnGroupChat;
        private PictureBox avaPic;
        private Label lblName;
        private FontAwesome.Sharp.IconButton btnSettingUser;
        private LinkLabel linkRefresh;
    }
}