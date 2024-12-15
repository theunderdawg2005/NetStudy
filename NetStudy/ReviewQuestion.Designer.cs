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
            SuspendLayout();
            // 
            // tB_data
            // 
            tB_data.Font = new Font("Segoe UI", 14F);
            tB_data.Location = new Point(42, 57);
            tB_data.Multiline = true;
            tB_data.Name = "tB_data";
            tB_data.ScrollBars = ScrollBars.Vertical;
            tB_data.Size = new Size(794, 324);
            tB_data.TabIndex = 5;
            // 
            // btn_option1
            // 
            btn_option1.Location = new Point(42, 407);
            btn_option1.Name = "btn_option1";
            btn_option1.Size = new Size(114, 38);
            btn_option1.TabIndex = 8;
            btn_option1.UseVisualStyleBackColor = true;
            btn_option1.Click += btn_option1_Click;
            // 
            // btn_option2
            // 
            btn_option2.Location = new Point(211, 407);
            btn_option2.Name = "btn_option2";
            btn_option2.Size = new Size(114, 38);
            btn_option2.TabIndex = 9;
            btn_option2.UseVisualStyleBackColor = true;
            btn_option2.Click += btn_option2_Click;
            // 
            // btn_option3
            // 
            btn_option3.Location = new Point(394, 407);
            btn_option3.Name = "btn_option3";
            btn_option3.Size = new Size(114, 38);
            btn_option3.TabIndex = 10;
            btn_option3.UseVisualStyleBackColor = true;
            btn_option3.Click += btn_option3_Click;
            // 
            // btn_option4
            // 
            btn_option4.Location = new Point(579, 407);
            btn_option4.Name = "btn_option4";
            btn_option4.Size = new Size(114, 38);
            btn_option4.TabIndex = 11;
            btn_option4.UseVisualStyleBackColor = true;
            btn_option4.Click += btn_option4_Click;
            // 
            // tB_topic
            // 
            tB_topic.Location = new Point(42, 12);
            tB_topic.Name = "tB_topic";
            tB_topic.Size = new Size(383, 27);
            tB_topic.TabIndex = 12;
            // 
            // btn_review
            // 
            btn_review.Location = new Point(444, 9);
            btn_review.Name = "btn_review";
            btn_review.Size = new Size(114, 33);
            btn_review.TabIndex = 13;
            btn_review.Text = "Ôn tập";
            btn_review.UseVisualStyleBackColor = true;
            btn_review.Click += btn_review_Click;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(722, 462);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(114, 38);
            btn_clear.TabIndex = 14;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = true;
            btn_clear.Click += btn_clear_Click;
            // 
            // btn_next
            // 
            btn_next.Location = new Point(722, 407);
            btn_next.Name = "btn_next";
            btn_next.Size = new Size(114, 38);
            btn_next.TabIndex = 15;
            btn_next.Text = "Next question";
            btn_next.UseVisualStyleBackColor = true;
            btn_next.Click += btn_next_Click;
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.Font = new Font("Segoe UI", 14F);
            lbl_username.Location = new Point(42, 468);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(125, 32);
            lbl_username.TabIndex = 16;
            lbl_username.Text = "UserName";
            // 
            // ReviewQuestion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 512);
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
    }
}