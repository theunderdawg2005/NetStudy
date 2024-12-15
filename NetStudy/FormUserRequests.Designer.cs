namespace NetStudy
{
    partial class FormUserRequests
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
            labelTitle = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Bahnschrift", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.FromArgb(0, 117, 214);
            labelTitle.Location = new Point(118, 19);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(361, 53);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Joining Requests";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(12, 90);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(559, 491);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // FormUserRequests
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(583, 604);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(labelTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormUserRequests";
            Text = "FormUserRequests";
            Load += FormUserRequests_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}