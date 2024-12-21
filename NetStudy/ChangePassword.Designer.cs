namespace NetStudy
{
    partial class ChangePassword
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
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            tB_otp = new TextBox();
            tB_currentPass = new TextBox();
            tB_newPass = new TextBox();
            tB_confirmPass = new TextBox();
            btn_confirm = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 117, 214);
            label1.Location = new Point(60, 52);
            label1.Name = "label1";
            label1.Size = new Size(59, 23);
            label1.TabIndex = 4;
            label1.Text = "OTP: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 117, 214);
            label3.Location = new Point(60, 156);
            label3.Name = "label3";
            label3.Size = new Size(150, 23);
            label3.TabIndex = 6;
            label3.Text = "New Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 117, 214);
            label2.Location = new Point(60, 211);
            label2.Name = "label2";
            label2.Size = new Size(183, 23);
            label2.TabIndex = 7;
            label2.Text = "Confirm Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(0, 117, 214);
            label4.Location = new Point(60, 104);
            label4.Name = "label4";
            label4.Size = new Size(180, 23);
            label4.TabIndex = 8;
            label4.Text = "Current Password:";
            // 
            // tB_otp
            // 
            tB_otp.Location = new Point(252, 52);
            tB_otp.Name = "tB_otp";
            tB_otp.Size = new Size(557, 27);
            tB_otp.TabIndex = 9;
            // 
            // tB_currentPass
            // 
            tB_currentPass.Location = new Point(252, 104);
            tB_currentPass.Name = "tB_currentPass";
            tB_currentPass.Size = new Size(557, 27);
            tB_currentPass.TabIndex = 10;
            // 
            // tB_newPass
            // 
            tB_newPass.Location = new Point(252, 156);
            tB_newPass.Name = "tB_newPass";
            tB_newPass.Size = new Size(557, 27);
            tB_newPass.TabIndex = 11;
            // 
            // tB_confirmPass
            // 
            tB_confirmPass.Location = new Point(252, 207);
            tB_confirmPass.Name = "tB_confirmPass";
            tB_confirmPass.Size = new Size(557, 27);
            tB_confirmPass.TabIndex = 12;
            // 
            // btn_confirm
            // 
            btn_confirm.BackColor = Color.FromArgb(0, 117, 214);
            btn_confirm.FlatAppearance.BorderSize = 0;
            btn_confirm.FlatStyle = FlatStyle.Flat;
            btn_confirm.ForeColor = Color.White;
            btn_confirm.Location = new Point(687, 262);
            btn_confirm.Name = "btn_confirm";
            btn_confirm.Size = new Size(122, 27);
            btn_confirm.TabIndex = 13;
            btn_confirm.Text = "Xác nhận";
            btn_confirm.UseVisualStyleBackColor = false;
            btn_confirm.Click += btn_confirm_Click;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(858, 320);
            Controls.Add(btn_confirm);
            Controls.Add(tB_confirmPass);
            Controls.Add(tB_newPass);
            Controls.Add(tB_currentPass);
            Controls.Add(tB_otp);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "ChangePassword";
            Text = "ChangePassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox tB_otp;
        private TextBox tB_currentPass;
        private TextBox tB_newPass;
        private TextBox tB_confirmPass;
        private Button btn_confirm;
    }
}