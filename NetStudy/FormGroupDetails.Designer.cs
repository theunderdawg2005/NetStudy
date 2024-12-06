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
            btnSend = new FontAwesome.Sharp.IconButton();
            txtMessage = new TextBox();
            panel2 = new Panel();
            label1 = new Label();
            listMsg = new ListBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(26, 25, 62);
            panel1.Controls.Add(btnSend);
            panel1.Controls.Add(txtMessage);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 610);
            panel1.Name = "panel1";
            panel1.Size = new Size(1033, 85);
            panel1.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(192, 0, 192);
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            btnSend.IconColor = Color.Gainsboro;
            btnSend.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSend.Location = new Point(954, 15);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(60, 55);
            btnSend.TabIndex = 1;
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.BackColor = Color.White;
            txtMessage.BorderStyle = BorderStyle.FixedSingle;
            txtMessage.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMessage.Location = new Point(360, 27);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(565, 33);
            txtMessage.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(26, 25, 62);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1033, 73);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(25, 22);
            label1.Name = "label1";
            label1.Size = new Size(138, 26);
            label1.TabIndex = 0;
            label1.Text = "Welcome to,  ";
            // 
            // listMsg
            // 
            listMsg.FormattingEnabled = true;
            listMsg.ItemHeight = 25;
            listMsg.Location = new Point(12, 88);
            listMsg.Name = "listMsg";
            listMsg.Size = new Size(1009, 504);
            listMsg.TabIndex = 2;
            // 
            // FormGroupDetails
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(1033, 695);
            Controls.Add(listMsg);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FormGroupDetails";
            Text = "FormGroupDetails";
            Load += FormGroupDetails_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtMessage;
        private FontAwesome.Sharp.IconButton btnSend;
        private Panel panel2;
        private Label label1;
        private ListBox listMsg;
    }
}