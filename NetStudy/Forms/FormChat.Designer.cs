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
            textBox_myusrname = new TextBox();
            textBox_otherusrname = new TextBox();
            textBox_showmsg = new TextBox();
            textBox_msg = new TextBox();
            button_send = new Button();
            comboBox_mystatus = new ComboBox();
            textBox_otherstatus = new TextBox();
            SuspendLayout();
            // 
            // groupBox_doanchat
            // 
            groupBox_doanchat.BackColor = Color.FromArgb(34, 33, 74);
            groupBox_doanchat.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox_doanchat.ForeColor = SystemColors.Control;
            groupBox_doanchat.Location = new Point(12, 51);
            groupBox_doanchat.Name = "groupBox_doanchat";
            groupBox_doanchat.Size = new Size(371, 632);
            groupBox_doanchat.TabIndex = 4;
            groupBox_doanchat.TabStop = false;
            groupBox_doanchat.Text = "Đoạn chat";
            groupBox_doanchat.Paint += groupBox_doanchat_Paint;
            // 
            // textBox_myusrname
            // 
            textBox_myusrname.BackColor = Color.Indigo;
            textBox_myusrname.BorderStyle = BorderStyle.None;
            textBox_myusrname.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_myusrname.ForeColor = SystemColors.Control;
            textBox_myusrname.Location = new Point(12, 12);
            textBox_myusrname.Name = "textBox_myusrname";
            textBox_myusrname.ReadOnly = true;
            textBox_myusrname.Size = new Size(150, 23);
            textBox_myusrname.TabIndex = 0;
            // 
            // textBox_otherusrname
            // 
            textBox_otherusrname.BackColor = Color.Indigo;
            textBox_otherusrname.BorderStyle = BorderStyle.None;
            textBox_otherusrname.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_otherusrname.ForeColor = SystemColors.Control;
            textBox_otherusrname.Location = new Point(389, 12);
            textBox_otherusrname.Name = "textBox_otherusrname";
            textBox_otherusrname.ReadOnly = true;
            textBox_otherusrname.Size = new Size(150, 23);
            textBox_otherusrname.TabIndex = 2;
            // 
            // textBox_showmsg
            // 
            textBox_showmsg.BackColor = Color.FromArgb(34, 33, 74);
            textBox_showmsg.BorderStyle = BorderStyle.FixedSingle;
            textBox_showmsg.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_showmsg.ForeColor = SystemColors.Control;
            textBox_showmsg.Location = new Point(389, 51);
            textBox_showmsg.Multiline = true;
            textBox_showmsg.Name = "textBox_showmsg";
            textBox_showmsg.Size = new Size(804, 595);
            textBox_showmsg.TabIndex = 5;
            // 
            // textBox_msg
            // 
            textBox_msg.BackColor = Color.FromArgb(34, 33, 74);
            textBox_msg.BorderStyle = BorderStyle.FixedSingle;
            textBox_msg.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_msg.ForeColor = SystemColors.Control;
            textBox_msg.Location = new Point(389, 654);
            textBox_msg.Name = "textBox_msg";
            textBox_msg.Size = new Size(648, 30);
            textBox_msg.TabIndex = 6;
            textBox_msg.TextChanged += textBox_msg_TextChanged;
            // 
            // button_send
            // 
            button_send.BackColor = Color.FromArgb(34, 33, 74);
            button_send.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_send.ForeColor = SystemColors.Control;
            button_send.Location = new Point(1043, 652);
            button_send.Name = "button_send";
            button_send.Size = new Size(150, 31);
            button_send.TabIndex = 7;
            button_send.Text = "Gửi";
            button_send.UseVisualStyleBackColor = false;
            button_send.Click += button_send_Click;
            // 
            // comboBox_mystatus
            // 
            comboBox_mystatus.BackColor = SystemColors.Control;
            comboBox_mystatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_mystatus.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_mystatus.ForeColor = SystemColors.WindowText;
            comboBox_mystatus.FormattingEnabled = true;
            comboBox_mystatus.Items.AddRange(new object[] { "Đang hoạt động", "Không hoạt động" });
            comboBox_mystatus.Location = new Point(201, 12);
            comboBox_mystatus.Name = "comboBox_mystatus";
            comboBox_mystatus.Size = new Size(182, 31);
            comboBox_mystatus.TabIndex = 1;
            comboBox_mystatus.SelectedIndexChanged += comboBox_mystatus_SelectedIndexChanged;
            // 
            // textBox_otherstatus
            // 
            textBox_otherstatus.BackColor = Color.Indigo;
            textBox_otherstatus.BorderStyle = BorderStyle.None;
            textBox_otherstatus.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_otherstatus.ForeColor = SystemColors.Control;
            textBox_otherstatus.Location = new Point(1043, 12);
            textBox_otherstatus.Name = "textBox_otherstatus";
            textBox_otherstatus.ReadOnly = true;
            textBox_otherstatus.Size = new Size(150, 23);
            textBox_otherstatus.TabIndex = 3;
            // 
            // FormChat
            // 
            AcceptButton = button_send;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 25, 62);
            ClientSize = new Size(1205, 695);
            Controls.Add(textBox_otherstatus);
            Controls.Add(comboBox_mystatus);
            Controls.Add(button_send);
            Controls.Add(textBox_myusrname);
            Controls.Add(textBox_msg);
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
        private TextBox textBox_myusrname;
        private TextBox textBox_otherusrname;
        private TextBox textBox_showmsg;
        private TextBox textBox_msg;
        private Button button_send;
        private ComboBox comboBox_mystatus;
        private TextBox textBox_otherstatus;
    }
}