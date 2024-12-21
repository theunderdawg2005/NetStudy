namespace NetStudy
{
    partial class ResetPassword
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btn_confirm = new Button();
            tB_email = new TextBox();
            tB_otp = new TextBox();
            tB_pass = new TextBox();
            tB_conPass = new TextBox();
            SuspendLayout();
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_email.ForeColor = Color.FromArgb(0, 117, 214);
            lbl_email.Location = new Point(76, 72);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(69, 23);
            lbl_email.TabIndex = 2;
            lbl_email.Text = "Email:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 117, 214);
            label1.Location = new Point(76, 125);
            label1.Name = "label1";
            label1.Size = new Size(59, 23);
            label1.TabIndex = 3;
            label1.Text = "OTP: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 117, 214);
            label2.Location = new Point(76, 244);
            label2.Name = "label2";
            label2.Size = new Size(183, 23);
            label2.TabIndex = 4;
            label2.Text = "Confirm Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 117, 214);
            label3.Location = new Point(76, 186);
            label3.Name = "label3";
            label3.Size = new Size(150, 23);
            label3.TabIndex = 5;
            label3.Text = "New Password:";
            // 
            // btn_confirm
            // 
            btn_confirm.BackColor = Color.FromArgb(0, 117, 214);
            btn_confirm.FlatAppearance.BorderSize = 0;
            btn_confirm.FlatStyle = FlatStyle.Flat;
            btn_confirm.ForeColor = Color.White;
            btn_confirm.Location = new Point(701, 301);
            btn_confirm.Name = "btn_confirm";
            btn_confirm.Size = new Size(122, 27);
            btn_confirm.TabIndex = 6;
            btn_confirm.Text = "Xác nhận";
            btn_confirm.UseVisualStyleBackColor = false;
            btn_confirm.Click += btn_confirm_Click;
            // 
            // tB_email
            // 
            tB_email.Location = new Point(266, 72);
            tB_email.Name = "tB_email";
            tB_email.Size = new Size(557, 27);
            tB_email.TabIndex = 7;
            // 
            // tB_otp
            // 
            tB_otp.Location = new Point(266, 125);
            tB_otp.Name = "tB_otp";
            tB_otp.Size = new Size(557, 27);
            tB_otp.TabIndex = 8;
            // 
            // tB_pass
            // 
            tB_pass.Location = new Point(266, 186);
            tB_pass.Name = "tB_pass";
            tB_pass.Size = new Size(557, 27);
            tB_pass.TabIndex = 9;
            // 
            // tB_conPass
            // 
            tB_conPass.Location = new Point(266, 244);
            tB_conPass.Name = "tB_conPass";
            tB_conPass.Size = new Size(557, 27);
            tB_conPass.TabIndex = 10;
            // 
            // ResetPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(922, 354);
            Controls.Add(tB_conPass);
            Controls.Add(tB_pass);
            Controls.Add(tB_otp);
            Controls.Add(tB_email);
            Controls.Add(btn_confirm);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbl_email);
            Name = "ResetPassword";
            Text = "ResetPassword";
            Load += ResetPassword_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_email;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btn_confirm;
        private TextBox tB_email;
        private TextBox tB_otp;
        private TextBox tB_pass;
        private TextBox tB_conPass;
    }
}