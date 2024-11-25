namespace NetStudy
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
            btnmatch = new FontAwesome.Sharp.IconButton();
            btnexam = new FontAwesome.Sharp.IconButton();
            btnclass = new FontAwesome.Sharp.IconButton();
            btnchat = new FontAwesome.Sharp.IconButton();
            btndocument = new FontAwesome.Sharp.IconButton();
            btndashboard = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(31, 30, 68);
            panelMenu.Controls.Add(btnmatch);
            panelMenu.Controls.Add(btnexam);
            panelMenu.Controls.Add(btnclass);
            panelMenu.Controls.Add(btnchat);
            panelMenu.Controls.Add(btndocument);
            panelMenu.Controls.Add(btndashboard);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 631);
            panelMenu.TabIndex = 0;
            // 
            // btnmatch
            // 
            btnmatch.Dock = DockStyle.Top;
            btnmatch.FlatAppearance.BorderSize = 0;
            btnmatch.FlatStyle = FlatStyle.Flat;
            btnmatch.ForeColor = Color.Gainsboro;
            btnmatch.IconChar = FontAwesome.Sharp.IconChar.Handshake;
            btnmatch.IconColor = Color.Gainsboro;
            btnmatch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnmatch.IconSize = 32;
            btnmatch.ImageAlign = ContentAlignment.MiddleLeft;
            btnmatch.Location = new Point(0, 440);
            btnmatch.Name = "btnmatch";
            btnmatch.Padding = new Padding(10, 0, 20, 0);
            btnmatch.Size = new Size(220, 60);
            btnmatch.TabIndex = 6;
            btnmatch.Text = "Bạn học";
            btnmatch.TextAlign = ContentAlignment.MiddleLeft;
            btnmatch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnmatch.UseVisualStyleBackColor = true;
            btnmatch.Click += this.btnmatch_Click;
            // 
            // btnexam
            // 
            btnexam.Dock = DockStyle.Top;
            btnexam.FlatAppearance.BorderSize = 0;
            btnexam.FlatStyle = FlatStyle.Flat;
            btnexam.ForeColor = Color.Gainsboro;
            btnexam.IconChar = FontAwesome.Sharp.IconChar.PenRuler;
            btnexam.IconColor = Color.Gainsboro;
            btnexam.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnexam.IconSize = 32;
            btnexam.ImageAlign = ContentAlignment.MiddleLeft;
            btnexam.Location = new Point(0, 380);
            btnexam.Name = "btnexam";
            btnexam.Padding = new Padding(10, 0, 20, 0);
            btnexam.Size = new Size(220, 60);
            btnexam.TabIndex = 5;
            btnexam.Text = "Ôn tập";
            btnexam.TextAlign = ContentAlignment.MiddleLeft;
            btnexam.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnexam.UseVisualStyleBackColor = true;
            btnexam.Click += this.btnexam_Click;
            // 
            // btnclass
            // 
            btnclass.Dock = DockStyle.Top;
            btnclass.FlatAppearance.BorderSize = 0;
            btnclass.FlatStyle = FlatStyle.Flat;
            btnclass.ForeColor = Color.Gainsboro;
            btnclass.IconChar = FontAwesome.Sharp.IconChar.UsersRectangle;
            btnclass.IconColor = Color.Gainsboro;
            btnclass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnclass.IconSize = 32;
            btnclass.ImageAlign = ContentAlignment.MiddleLeft;
            btnclass.Location = new Point(0, 320);
            btnclass.Name = "btnclass";
            btnclass.Padding = new Padding(10, 0, 20, 0);
            btnclass.Size = new Size(220, 60);
            btnclass.TabIndex = 4;
            btnclass.Text = "Lớp học";
            btnclass.TextAlign = ContentAlignment.MiddleLeft;
            btnclass.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnclass.UseVisualStyleBackColor = true;
            btnclass.Click += this.btnclass_Click;
            // 
            // btnchat
            // 
            btnchat.Dock = DockStyle.Top;
            btnchat.FlatAppearance.BorderSize = 0;
            btnchat.FlatStyle = FlatStyle.Flat;
            btnchat.ForeColor = Color.Gainsboro;
            btnchat.IconChar = FontAwesome.Sharp.IconChar.Comment;
            btnchat.IconColor = Color.Gainsboro;
            btnchat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnchat.IconSize = 32;
            btnchat.ImageAlign = ContentAlignment.MiddleLeft;
            btnchat.Location = new Point(0, 260);
            btnchat.Name = "btnchat";
            btnchat.Padding = new Padding(10, 0, 20, 0);
            btnchat.Size = new Size(220, 60);
            btnchat.TabIndex = 3;
            btnchat.Text = "Đoạn chat";
            btnchat.TextAlign = ContentAlignment.MiddleLeft;
            btnchat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnchat.UseVisualStyleBackColor = true;
            btnchat.Click += this.btnchat_Click;
            // 
            // btndocument
            // 
            btndocument.Dock = DockStyle.Top;
            btndocument.FlatAppearance.BorderSize = 0;
            btndocument.FlatStyle = FlatStyle.Flat;
            btndocument.ForeColor = Color.Gainsboro;
            btndocument.IconChar = FontAwesome.Sharp.IconChar.File;
            btndocument.IconColor = Color.Gainsboro;
            btndocument.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btndocument.IconSize = 32;
            btndocument.ImageAlign = ContentAlignment.MiddleLeft;
            btndocument.Location = new Point(0, 200);
            btndocument.Name = "btndocument";
            btndocument.Padding = new Padding(10, 0, 20, 0);
            btndocument.Size = new Size(220, 60);
            btndocument.TabIndex = 2;
            btndocument.Text = "Tài liệu";
            btndocument.TextAlign = ContentAlignment.MiddleLeft;
            btndocument.TextImageRelation = TextImageRelation.ImageBeforeText;
            btndocument.UseVisualStyleBackColor = true;
            btndocument.Click += this.btndocument_Click;
            // 
            // btndashboard
            // 
            btndashboard.Dock = DockStyle.Top;
            btndashboard.FlatAppearance.BorderSize = 0;
            btndashboard.FlatStyle = FlatStyle.Flat;
            btndashboard.ForeColor = Color.Gainsboro;
            btndashboard.IconChar = FontAwesome.Sharp.IconChar.Star;
            btndashboard.IconColor = Color.Gainsboro;
            btndashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btndashboard.IconSize = 32;
            btndashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btndashboard.Location = new Point(0, 140);
            btndashboard.Name = "btndashboard";
            btndashboard.Padding = new Padding(10, 0, 20, 0);
            btndashboard.Size = new Size(220, 60);
            btndashboard.TabIndex = 1;
            btndashboard.Text = "Tổng quan";
            btndashboard.TextAlign = ContentAlignment.MiddleLeft;
            btndashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btndashboard.UseVisualStyleBackColor = true;
            btndashboard.Click += this.btndashboard_Click;
            // 
            // panelLogo
            // 
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 140);
            panelLogo.TabIndex = 0;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1121, 631);
            Controls.Add(panelMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainMenu";
            Text = "NETSTUDY";
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private FontAwesome.Sharp.IconButton btndashboard;
        private Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnmatch;
        private FontAwesome.Sharp.IconButton btnexam;
        private FontAwesome.Sharp.IconButton btnclass;
        private FontAwesome.Sharp.IconButton btnchat;
        private FontAwesome.Sharp.IconButton btndocument;
    }
}