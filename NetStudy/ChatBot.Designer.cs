namespace NetStudy
{
    partial class ChatBot
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
            btn_send = new Button();
            tB_respones = new TextBox();
            btn_clear2 = new Button();
            btn_upload = new Button();
            tB_filepath = new TextBox();
            tB_message = new TextBox();
            lbl_username = new Label();
            SuspendLayout();
            // 
            // btn_send
            // 
            btn_send.Location = new Point(708, 12);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(94, 29);
            btn_send.TabIndex = 2;
            btn_send.Text = "Send";
            btn_send.UseVisualStyleBackColor = true;
            btn_send.Click += btn_send_Click;
            // 
            // tB_respones
            // 
            tB_respones.Location = new Point(25, 98);
            tB_respones.Multiline = true;
            tB_respones.Name = "tB_respones";
            tB_respones.ScrollBars = ScrollBars.Vertical;
            tB_respones.Size = new Size(883, 552);
            tB_respones.TabIndex = 5;
            // 
            // btn_clear2
            // 
            btn_clear2.Location = new Point(814, 12);
            btn_clear2.Name = "btn_clear2";
            btn_clear2.Size = new Size(94, 29);
            btn_clear2.TabIndex = 6;
            btn_clear2.Text = "Clear";
            btn_clear2.UseVisualStyleBackColor = true;
            btn_clear2.Click += btn_clear2_Click;
            // 
            // btn_upload
            // 
            btn_upload.Location = new Point(708, 51);
            btn_upload.Name = "btn_upload";
            btn_upload.Size = new Size(94, 29);
            btn_upload.TabIndex = 7;
            btn_upload.Text = "Upload";
            btn_upload.UseVisualStyleBackColor = true;
            btn_upload.Click += btn_upload_Click;
            // 
            // tB_filepath
            // 
            tB_filepath.Location = new Point(137, 51);
            tB_filepath.Name = "tB_filepath";
            tB_filepath.Size = new Size(538, 27);
            tB_filepath.TabIndex = 8;
            // 
            // tB_message
            // 
            tB_message.Location = new Point(137, 12);
            tB_message.Name = "tB_message";
            tB_message.Size = new Size(538, 27);
            tB_message.TabIndex = 9;
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.Location = new Point(37, 15);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(78, 20);
            lbl_username.TabIndex = 10;
            lbl_username.Text = "UserName";
            // 
            // ChatBot
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 673);
            Controls.Add(lbl_username);
            Controls.Add(tB_message);
            Controls.Add(tB_filepath);
            Controls.Add(btn_upload);
            Controls.Add(btn_clear2);
            Controls.Add(tB_respones);
            Controls.Add(btn_send);
            Name = "ChatBot";
            Text = "ChatBot";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_send;
        private TextBox tB_respones;
        private Button btn_clear2;
        private Button btn_upload;
        private TextBox tB_filepath;
        private TextBox tB_message;
        private Label lbl_username;
    }
}