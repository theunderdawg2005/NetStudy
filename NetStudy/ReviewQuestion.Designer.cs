namespace NetStudy
{
    partial class ReviewQuestion
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
            tB_data = new TextBox();
            btn_option1 = new Button();
            btn_option2 = new Button();
            btn_option3 = new Button();
            btn_option4 = new Button();
            tB_topic = new TextBox();
            btn_review = new Button();
            btn_clear = new Button();
            btn_next = new Button();
            lbl_username = new Label();
            lbl_topic = new Label();
            SuspendLayout();
            // 
            // tB_data
            // 
            tB_data.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tB_data.Font = new Font("Segoe UI", 14F);
            tB_data.Location = new Point(42, 68);
            tB_data.Multiline = true;
            tB_data.Name = "tB_data";
            tB_data.ReadOnly = true;
            tB_data.ScrollBars = ScrollBars.Vertical;
            tB_data.Size = new Size(858, 241);
            tB_data.TabIndex = 5;
            // 
            // btn_option1
            // 
            btn_option1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_option1.BackColor = Color.Indigo;
            btn_option1.FlatStyle = FlatStyle.Flat;
            btn_option1.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btn_option1.ForeColor = Color.Gainsboro;
            btn_option1.Location = new Point(43, 339);
            btn_option1.Name = "btn_option1";
            btn_option1.Size = new Size(857, 65);
            btn_option1.TabIndex = 8;
            btn_option1.UseVisualStyleBackColor = false;
            btn_option1.Click += btn_option1_Click;
            // 
            // btn_option2
            // 
            btn_option2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_option2.BackColor = Color.Indigo;
            btn_option2.FlatStyle = FlatStyle.Flat;
            btn_option2.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btn_option2.ForeColor = Color.Gainsboro;
            btn_option2.Location = new Point(42, 421);
            btn_option2.Name = "btn_option2";
            btn_option2.Size = new Size(857, 65);
            btn_option2.TabIndex = 9;
            btn_option2.UseVisualStyleBackColor = false;
            btn_option2.Click += btn_option2_Click;
            // 
            // btn_option3
            // 
            btn_option3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_option3.BackColor = Color.Indigo;
            btn_option3.FlatStyle = FlatStyle.Flat;
            btn_option3.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btn_option3.ForeColor = Color.Gainsboro;
            btn_option3.Location = new Point(43, 507);
            btn_option3.Name = "btn_option3";
            btn_option3.Size = new Size(857, 65);
            btn_option3.TabIndex = 10;
            btn_option3.UseVisualStyleBackColor = false;
            btn_option3.Click += btn_option3_Click;
            // 
            // btn_option4
            // 
            btn_option4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_option4.BackColor = Color.Indigo;
            btn_option4.FlatStyle = FlatStyle.Flat;
            btn_option4.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btn_option4.ForeColor = Color.Gainsboro;
            btn_option4.Location = new Point(43, 591);
            btn_option4.Name = "btn_option4";
            btn_option4.Size = new Size(857, 65);
            btn_option4.TabIndex = 11;
            btn_option4.UseVisualStyleBackColor = false;
            btn_option4.Click += btn_option4_Click;
            // 
            // tB_topic
            // 
            tB_topic.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tB_topic.Location = new Point(144, 15);
            tB_topic.Name = "tB_topic";
            tB_topic.Size = new Size(447, 27);
            tB_topic.TabIndex = 12;
            // 
            // btn_review
            // 
            btn_review.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_review.BackColor = Color.Indigo;
            btn_review.FlatStyle = FlatStyle.Flat;
            btn_review.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btn_review.ForeColor = Color.Gainsboro;
            btn_review.Location = new Point(597, 12);
            btn_review.Name = "btn_review";
            btn_review.Size = new Size(114, 33);
            btn_review.TabIndex = 13;
            btn_review.Text = "Ôn tập";
            btn_review.UseVisualStyleBackColor = false;
            btn_review.Click += btn_review_Click;
            // 
            // btn_clear
            // 
            btn_clear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_clear.BackColor = Color.Indigo;
            btn_clear.FlatStyle = FlatStyle.Flat;
            btn_clear.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btn_clear.ForeColor = Color.Gainsboro;
            btn_clear.Location = new Point(649, 677);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(114, 38);
            btn_clear.TabIndex = 14;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // btn_next
            // 
            btn_next.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_next.BackColor = Color.Indigo;
            btn_next.FlatStyle = FlatStyle.Flat;
            btn_next.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btn_next.ForeColor = Color.Gainsboro;
            btn_next.Location = new Point(786, 677);
            btn_next.Name = "btn_next";
            btn_next.Size = new Size(114, 38);
            btn_next.TabIndex = 15;
            btn_next.Text = "Next question";
            btn_next.UseVisualStyleBackColor = false;
            btn_next.Click += btn_next_Click;
            // 
            // lbl_username
            // 
            lbl_username.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_username.AutoSize = true;
            lbl_username.FlatStyle = FlatStyle.Popup;
            lbl_username.Font = new Font("Cambria", 11F);
            lbl_username.ForeColor = Color.Gainsboro;
            lbl_username.Location = new Point(761, 17);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(94, 22);
            lbl_username.TabIndex = 16;
            lbl_username.Text = "UserName";
            // 
            // lbl_topic
            // 
            lbl_topic.AutoSize = true;
            lbl_topic.FlatStyle = FlatStyle.Popup;
            lbl_topic.Font = new Font("Cambria", 11F);
            lbl_topic.ForeColor = Color.Gainsboro;
            lbl_topic.Location = new Point(64, 17);
            lbl_topic.Name = "lbl_topic";
            lbl_topic.Size = new Size(53, 22);
            lbl_topic.TabIndex = 17;
            lbl_topic.Text = "Topic";
            // 
            // ReviewQuestion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 25, 62);
            ClientSize = new Size(941, 748);
            Controls.Add(lbl_topic);
            Controls.Add(lbl_username);
            Controls.Add(btn_next);
            Controls.Add(btn_clear);
            Controls.Add(btn_review);
            Controls.Add(tB_topic);
            Controls.Add(btn_option4);
            Controls.Add(btn_option3);
            Controls.Add(btn_option2);
            Controls.Add(btn_option1);
            Controls.Add(tB_data);
            Name = "ReviewQuestion";
            Text = "ReviewQuestion";
            FormClosed += ReviewQuestion_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tB_data;
        private Button btn_option1;
        private Button btn_option2;
        private Button btn_option3;
        private Button btn_option4;
        private TextBox tB_topic;
        private Button btn_review;
        private Button btn_clear;
        private Button btn_next;
        private Label lbl_username;
        private Label lbl_topic;
    }
}