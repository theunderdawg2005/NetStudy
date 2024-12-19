namespace NetStudy
{
    partial class FormGroupDetails
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
            panel1 = new Panel();
            btnMemberList = new FontAwesome.Sharp.IconButton();
            btnAddUser = new FontAwesome.Sharp.IconButton();
            btnSend = new FontAwesome.Sharp.IconButton();
            txtMessage = new TextBox();
            panelTop = new Panel();
            btnLeave = new FontAwesome.Sharp.IconButton();
            lblTitle = new Label();
            listMsg = new ListBox();
            btnInfo = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(26, 25, 62);
            panel1.Controls.Add(btnInfo);
            panel1.Controls.Add(btnMemberList);
            panel1.Controls.Add(btnAddUser);
            panel1.Controls.Add(btnSend);
            panel1.Controls.Add(txtMessage);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 610);
            panel1.Name = "panel1";
            panel1.Size = new Size(1032, 85);
            panel1.TabIndex = 0;
            // 
            // btnMemberList
            // 
            btnMemberList.BackColor = Color.FromArgb(192, 0, 192);
            btnMemberList.Cursor = Cursors.Hand;
            btnMemberList.FlatAppearance.BorderSize = 2;
            btnMemberList.FlatStyle = FlatStyle.Flat;
            btnMemberList.ForeColor = Color.Gainsboro;
            btnMemberList.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            btnMemberList.IconColor = Color.Gainsboro;
            btnMemberList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMemberList.ImageAlign = ContentAlignment.TopCenter;
            btnMemberList.Location = new Point(148, 16);
            btnMemberList.Name = "btnMemberList";
            btnMemberList.Size = new Size(52, 52);
            btnMemberList.TabIndex = 3;
            btnMemberList.UseVisualStyleBackColor = false;
            btnMemberList.Click += btnMemberList_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.FromArgb(192, 0, 192);
            btnAddUser.Cursor = Cursors.Hand;
            btnAddUser.FlatAppearance.BorderSize = 2;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.ForeColor = Color.Gainsboro;
            btnAddUser.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            btnAddUser.IconColor = Color.Gainsboro;
            btnAddUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddUser.IconSize = 45;
            btnAddUser.Location = new Point(79, 16);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(52, 52);
            btnAddUser.TabIndex = 2;
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnSend
            // 
            btnSend.AutoSize = true;
            btnSend.BackColor = Color.FromArgb(192, 0, 192);
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderColor = Color.Gainsboro;
            btnSend.FlatAppearance.BorderSize = 2;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            btnSend.IconColor = Color.Gainsboro;
            btnSend.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSend.Location = new Point(958, 15);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(58, 58);
            btnSend.TabIndex = 1;
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.BackColor = Color.White;
            txtMessage.BorderStyle = BorderStyle.FixedSingle;
            txtMessage.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMessage.Location = new Point(370, 27);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(565, 33);
            txtMessage.TabIndex = 0;
            txtMessage.TextChanged += txtMessage_TextChanged;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(26, 25, 62);
            panelTop.Controls.Add(btnLeave);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Font = new Font("Bahnschrift SemiBold", 9F, FontStyle.Bold);
            panelTop.ForeColor = Color.Gainsboro;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1032, 73);
            panelTop.TabIndex = 1;
            // 
            // btnLeave
            // 
            btnLeave.AutoSize = true;
            btnLeave.BackColor = Color.FromArgb(192, 0, 192);
            btnLeave.Cursor = Cursors.Hand;
            btnLeave.FlatAppearance.BorderSize = 2;
            btnLeave.FlatStyle = FlatStyle.Flat;
            btnLeave.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            btnLeave.IconColor = Color.Gainsboro;
            btnLeave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLeave.IconSize = 35;
            btnLeave.Location = new Point(975, 13);
            btnLeave.Name = "btnLeave";
            btnLeave.Size = new Size(45, 45);
            btnLeave.TabIndex = 3;
            btnLeave.UseVisualStyleBackColor = false;
            btnLeave.Click += btnLeave_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Cursor = Cursors.Hand;
            lblTitle.Font = new Font("Bahnschrift SemiBold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Gainsboro;
            lblTitle.Location = new Point(21, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(201, 34);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "{GroupName}  ";
            lblTitle.Click += lblTitle_Click;
            // 
            // listMsg
            // 
            listMsg.BorderStyle = BorderStyle.None;
            listMsg.FormattingEnabled = true;
            listMsg.ItemHeight = 25;
            listMsg.Location = new Point(12, 88);
            listMsg.Name = "listMsg";
            listMsg.Size = new Size(1009, 500);
            listMsg.TabIndex = 2;
            // 
            // btnInfo
            // 
            btnInfo.BackColor = Color.FromArgb(192, 0, 192);
            btnInfo.Cursor = Cursors.Hand;
            btnInfo.FlatAppearance.BorderSize = 2;
            btnInfo.FlatStyle = FlatStyle.Flat;
            btnInfo.ForeColor = Color.Gainsboro;
            btnInfo.IconChar = FontAwesome.Sharp.IconChar.Info;
            btnInfo.IconColor = Color.Gainsboro;
            btnInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnInfo.IconSize = 38;
            btnInfo.ImageAlign = ContentAlignment.TopCenter;
            btnInfo.Location = new Point(12, 16);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(52, 52);
            btnInfo.TabIndex = 4;
            btnInfo.UseVisualStyleBackColor = false;
            btnInfo.Click += btnInfo_Click;
            // 
            // FormGroupDetails
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(1032, 695);
            Controls.Add(listMsg);
            Controls.Add(panelTop);
            Controls.Add(panel1);
            Name = "FormGroupDetails";
            Text = "Hội nhóm";
            Load += FormGroupDetails_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtMessage;
        private FontAwesome.Sharp.IconButton btnSend;
        private Panel panelTop;
        private Label lblTitle;
        private ListBox listMsg;
        private FontAwesome.Sharp.IconButton btnAddUser;
        private FontAwesome.Sharp.IconButton btnLeave;
        private FontAwesome.Sharp.IconButton btnMemberList;
        private FontAwesome.Sharp.IconButton btnInfo;
    }
}