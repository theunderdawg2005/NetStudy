namespace NetStudy
{
    partial class ForgetPass
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
            lbl_email = new Label();
            tB_email = new TextBox();
            btn_send = new Button();
            SuspendLayout();
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_email.ForeColor = Color.FromArgb(0, 117, 214);
            lbl_email.Location = new Point(32, 34);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(69, 23);
            lbl_email.TabIndex = 1;
            lbl_email.Text = "Email:";
            lbl_email.Click += lbl_email_Click;
            // 
            // tB_email
            // 
            tB_email.Location = new Point(107, 34);
            tB_email.Name = "tB_email";
            tB_email.Size = new Size(464, 27);
            tB_email.TabIndex = 2;
            // 
            // btn_send
            // 
            btn_send.BackColor = Color.FromArgb(0, 117, 214);
            btn_send.FlatAppearance.BorderSize = 0;
            btn_send.FlatStyle = FlatStyle.Flat;
            btn_send.ForeColor = Color.White;
            btn_send.Location = new Point(449, 89);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(122, 27);
            btn_send.TabIndex = 4;
            btn_send.Text = "Xác nhận";
            btn_send.UseVisualStyleBackColor = false;
            btn_send.Click += btn_send_Click;
            // 
            // ForgetPass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(627, 128);
            Controls.Add(btn_send);
            Controls.Add(tB_email);
            Controls.Add(lbl_email);
            Name = "ForgetPass";
            Text = "ForgetPass";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_email;
        private TextBox tB_email;
        private Button btn_send;
    }
}