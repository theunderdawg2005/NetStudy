namespace NetStudy.Forms
{
    partial class FormChat
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
            groupBox_doanchat = new GroupBox();
            comboBox_mystatus = new ComboBox();
            textBox_myusrname = new TextBox();
            textBox_otherusrname = new TextBox();
            textBox_showmsg = new TextBox();
            textBox_otherstatus = new TextBox();
            textBox_msg = new TextBox();
            button_send = new Button();
            SuspendLayout();
            // 
            // groupBox_doanchat
            // 
            groupBox_doanchat.Location = new Point(12, 51);
            groupBox_doanchat.Name = "groupBox_doanchat";
            groupBox_doanchat.Size = new Size(371, 632);
            groupBox_doanchat.TabIndex = 0;
            groupBox_doanchat.TabStop = false;
            groupBox_doanchat.Text = "Đoạn chat";
            // 
            // comboBox_mystatus
            // 
            comboBox_mystatus.FormattingEnabled = true;
            comboBox_mystatus.Items.AddRange(new object[] { "Đang hoạt động", "Ẩn hoạt động" });
            comboBox_mystatus.Location = new Point(201, 12);
            comboBox_mystatus.Name = "comboBox_mystatus";
            comboBox_mystatus.Size = new Size(182, 33);
            comboBox_mystatus.TabIndex = 1;
            comboBox_mystatus.SelectedIndexChanged += comboBox_status_SelectedIndexChanged;
            // 
            // textBox_myusrname
            // 
            textBox_myusrname.Location = new Point(12, 12);
            textBox_myusrname.Name = "textBox_myusrname";
            textBox_myusrname.ReadOnly = true;
            textBox_myusrname.Size = new Size(150, 31);
            textBox_myusrname.TabIndex = 0;
            // 
            // textBox_otherusrname
            // 
            textBox_otherusrname.Location = new Point(389, 12);
            textBox_otherusrname.Name = "textBox_otherusrname";
            textBox_otherusrname.ReadOnly = true;
            textBox_otherusrname.Size = new Size(150, 31);
            textBox_otherusrname.TabIndex = 1;
            // 
            // textBox_showmsg
            // 
            textBox_showmsg.Location = new Point(389, 49);
            textBox_showmsg.Multiline = true;
            textBox_showmsg.Name = "textBox_showmsg";
            textBox_showmsg.Size = new Size(804, 597);
            textBox_showmsg.TabIndex = 2;
            // 
            // textBox_otherstatus
            // 
            textBox_otherstatus.Location = new Point(1043, 9);
            textBox_otherstatus.Name = "textBox_otherstatus";
            textBox_otherstatus.ReadOnly = true;
            textBox_otherstatus.Size = new Size(150, 31);
            textBox_otherstatus.TabIndex = 3;
            // 
            // textBox_msg
            // 
            textBox_msg.Location = new Point(389, 652);
            textBox_msg.Name = "textBox_msg";
            textBox_msg.Size = new Size(648, 31);
            textBox_msg.TabIndex = 4;
            // 
            // button_send
            // 
            button_send.Location = new Point(1043, 652);
            button_send.Name = "button_send";
            button_send.Size = new Size(150, 31);
            button_send.TabIndex = 5;
            button_send.Text = "Gửi";
            button_send.UseVisualStyleBackColor = true;
            button_send.Click += button_send_Click;
            // 
            // FormChat
            // 
            AcceptButton = button_send;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1205, 695);
            Controls.Add(comboBox_mystatus);
            Controls.Add(button_send);
            Controls.Add(textBox_myusrname);
            Controls.Add(textBox_msg);
            Controls.Add(textBox_otherstatus);
            Controls.Add(textBox_showmsg);
            Controls.Add(textBox_otherusrname);
            Controls.Add(groupBox_doanchat);
            Margin = new Padding(4);
            Name = "FormChat";
            Text = "FormChat";
            Load += FormChat_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox_doanchat;
        private ComboBox comboBox_mystatus;
        private TextBox textBox_myusrname;
        private TextBox textBox_otherusrname;
        private TextBox textBox_showmsg;
        private TextBox textBox_otherstatus;
        private TextBox textBox_msg;
        private Button button_send;
    }
}