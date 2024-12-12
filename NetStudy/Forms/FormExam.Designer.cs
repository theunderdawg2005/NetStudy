namespace NetStudy.Forms
{
    partial class FormExam
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
            lbl_username = new Label();
            btn_createquestion = new Button();
            btn_review = new Button();
            btn_listquestion = new Button();
            tB_data = new TextBox();
            btn_next = new Button();
            btn_clear = new Button();
            btn_option1 = new Button();
            btn_option2 = new Button();
            btn_option3 = new Button();
            btn_option4 = new Button();
            SuspendLayout();
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.BackColor = SystemColors.ActiveCaption;
            lbl_username.BorderStyle = BorderStyle.Fixed3D;
            lbl_username.FlatStyle = FlatStyle.Popup;
            lbl_username.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_username.Location = new Point(35, 512);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(89, 25);
            lbl_username.TabIndex = 0;
            lbl_username.Text = "Username";
            // 
            // btn_createquestion
            // 
            btn_createquestion.Location = new Point(35, 20);
            btn_createquestion.Name = "btn_createquestion";
            btn_createquestion.Size = new Size(114, 38);
            btn_createquestion.TabIndex = 1;
            btn_createquestion.Text = "Tạo câu hỏi";
            btn_createquestion.UseVisualStyleBackColor = true;
            btn_createquestion.Click += btn_createquestion_Click;
            // 
            // btn_review
            // 
            btn_review.Location = new Point(178, 20);
            btn_review.Name = "btn_review";
            btn_review.Size = new Size(114, 38);
            btn_review.TabIndex = 2;
            btn_review.Text = "Ôn tập";
            btn_review.UseVisualStyleBackColor = true;
            btn_review.Click += btn_review_Click;
            // 
            // btn_listquestion
            // 
            btn_listquestion.Location = new Point(789, 12);
            btn_listquestion.Name = "btn_listquestion";
            btn_listquestion.Size = new Size(142, 55);
            btn_listquestion.TabIndex = 3;
            btn_listquestion.Text = "Danh sách câu hỏi";
            btn_listquestion.UseVisualStyleBackColor = true;
            btn_listquestion.Click += btn_listquestion_Click;
            // 
            // tB_data
            // 
            tB_data.Font = new Font("Segoe UI", 14F);
            tB_data.Location = new Point(35, 87);
            tB_data.Multiline = true;
            tB_data.Name = "tB_data";
            tB_data.ScrollBars = ScrollBars.Vertical;
            tB_data.Size = new Size(896, 322);
            tB_data.TabIndex = 4;
            // 
            // btn_next
            // 
            btn_next.Location = new Point(789, 436);
            btn_next.Name = "btn_next";
            btn_next.Size = new Size(114, 38);
            btn_next.TabIndex = 5;
            btn_next.Text = "Next question";
            btn_next.UseVisualStyleBackColor = true;
            btn_next.Click += btn_next_Click;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(789, 499);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(114, 38);
            btn_clear.TabIndex = 6;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = true;
            btn_clear.Click += btn_clear_Click;
            // 
            // btn_option1
            // 
            btn_option1.Location = new Point(55, 436);
            btn_option1.Name = "btn_option1";
            btn_option1.Size = new Size(114, 38);
            btn_option1.TabIndex = 7;
            btn_option1.UseVisualStyleBackColor = true;
            btn_option1.Click += btn_option1_Click;
            // 
            // btn_option2
            // 
            btn_option2.Location = new Point(235, 436);
            btn_option2.Name = "btn_option2";
            btn_option2.Size = new Size(114, 38);
            btn_option2.TabIndex = 8;
            btn_option2.UseVisualStyleBackColor = true;
            btn_option2.Click += btn_option2_Click;
            // 
            // btn_option3
            // 
            btn_option3.Location = new Point(422, 436);
            btn_option3.Name = "btn_option3";
            btn_option3.Size = new Size(114, 38);
            btn_option3.TabIndex = 9;
            btn_option3.UseVisualStyleBackColor = true;
            btn_option3.Click += btn_option3_Click;
            // 
            // btn_option4
            // 
            btn_option4.Location = new Point(609, 436);
            btn_option4.Name = "btn_option4";
            btn_option4.Size = new Size(114, 38);
            btn_option4.TabIndex = 10;
            btn_option4.UseVisualStyleBackColor = true;
            btn_option4.Click += btn_option4_Click;
            // 
            // FormExam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 556);
            Controls.Add(btn_option4);
            Controls.Add(btn_option3);
            Controls.Add(btn_option2);
            Controls.Add(btn_option1);
            Controls.Add(btn_clear);
            Controls.Add(btn_next);
            Controls.Add(tB_data);
            Controls.Add(btn_listquestion);
            Controls.Add(btn_review);
            Controls.Add(btn_createquestion);
            Controls.Add(lbl_username);
            Name = "FormExam";
            Text = "FormExam";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_username;
        private Button btn_createquestion;
        private Button btn_review;
        private Button btn_listquestion;
        private TextBox tB_data;
        private Button btn_next;
        private Button btn_clear;
        private Button btn_option1;
        private Button btn_option2;
        private Button btn_option3;
        private Button btn_option4;
    }
}