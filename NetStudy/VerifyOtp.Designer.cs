namespace NetStudy
{
    partial class VerifyOtp
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
            txtOTP = new TextBox();
            label2 = new Label();
            btnVerify = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 117, 214);
            label1.Location = new Point(64, 106);
            label1.Name = "label1";
            label1.Size = new Size(70, 28);
            label1.TabIndex = 0;
            label1.Text = "OTP: ";
            label1.Click += label1_Click;
            // 
            // txtOTP
            // 
            txtOTP.BorderStyle = BorderStyle.FixedSingle;
            txtOTP.Font = new Font("Calibri", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOTP.Location = new Point(140, 106);
            txtOTP.Name = "txtOTP";
            txtOTP.Size = new Size(368, 32);
            txtOTP.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cambria", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 117, 214);
            label2.Location = new Point(79, 34);
            label2.Name = "label2";
            label2.Size = new Size(410, 33);
            label2.TabIndex = 2;
            label2.Text = "Vui lòng nhập OTP để xác nhận";
            // 
            // btnVerify
            // 
            btnVerify.BackColor = Color.FromArgb(0, 117, 214);
            btnVerify.FlatAppearance.BorderSize = 0;
            btnVerify.FlatStyle = FlatStyle.Flat;
            btnVerify.ForeColor = Color.White;
            btnVerify.Location = new Point(221, 182);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(137, 47);
            btnVerify.TabIndex = 3;
            btnVerify.Text = "Xác nhận";
            btnVerify.UseVisualStyleBackColor = false;
            btnVerify.Click += btnVerify_Click;
            // 
            // VerifyOtp
            // 
            AutoScaleDimensions = new SizeF(11F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(574, 260);
            Controls.Add(btnVerify);
            Controls.Add(label2);
            Controls.Add(txtOTP);
            Controls.Add(label1);
            Font = new Font("Calibri", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VerifyOtp";
            Text = "VerifyOtp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtOTP;
        private Label label2;
        private Button btnVerify;
    }
}