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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExam));
            lbl_username = new Label();
            btn_createquestion = new Button();
            btn_review = new Button();
            btn_listquestion = new Button();
            btn_clear = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tB_topic = new TextBox();
            btn_AI = new Button();
            SuspendLayout();
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.BackColor = Color.FromArgb(26, 25, 62);
            lbl_username.FlatStyle = FlatStyle.Popup;
            lbl_username.Font = new Font("Cambria", 11F);
            lbl_username.ForeColor = Color.Gainsboro;
            lbl_username.Location = new Point(35, 512);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(92, 22);
            lbl_username.TabIndex = 0;
            lbl_username.Text = "Username";
            // 
            // btn_createquestion
            // 
            btn_createquestion.BackColor = Color.Indigo;
            btn_createquestion.FlatStyle = FlatStyle.Flat;
            btn_createquestion.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btn_createquestion.ForeColor = Color.Gainsboro;
            btn_createquestion.Location = new Point(861, 20);
            btn_createquestion.Name = "btn_createquestion";
            btn_createquestion.Size = new Size(114, 30);
            btn_createquestion.TabIndex = 1;
            btn_createquestion.Text = "Tạo câu hỏi";
            btn_createquestion.UseVisualStyleBackColor = false;
            btn_createquestion.Click += btn_createquestion_Click;
            // 
            // btn_review
            // 
            btn_review.BackColor = Color.Indigo;
            btn_review.FlatStyle = FlatStyle.Flat;
            btn_review.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btn_review.ForeColor = Color.Gainsboro;
            btn_review.Location = new Point(517, 20);
            btn_review.Name = "btn_review";
            btn_review.Size = new Size(114, 30);
            btn_review.TabIndex = 2;
            btn_review.Text = "Ôn tập";
            btn_review.UseVisualStyleBackColor = false;
            btn_review.Click += btn_review_Click;
            // 
            // btn_listquestion
            // 
            btn_listquestion.BackColor = Color.Indigo;
            btn_listquestion.FlatStyle = FlatStyle.Flat;
            btn_listquestion.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btn_listquestion.ForeColor = Color.Gainsboro;
            btn_listquestion.Location = new Point(667, 20);
            btn_listquestion.Name = "btn_listquestion";
            btn_listquestion.Size = new Size(157, 30);
            btn_listquestion.TabIndex = 3;
            btn_listquestion.Text = "Danh sách câu hỏi";
            btn_listquestion.UseVisualStyleBackColor = false;
            btn_listquestion.Click += btn_listquestion_Click;
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.Indigo;
            btn_clear.FlatStyle = FlatStyle.Flat;
            btn_clear.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btn_clear.ForeColor = Color.Gainsboro;
            btn_clear.Location = new Point(861, 505);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(114, 38);
            btn_clear.TabIndex = 6;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(34, 33, 74);
            flowLayoutPanel1.Location = new Point(1, 64);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(986, 429);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // tB_topic
            // 
            tB_topic.Location = new Point(109, 20);
            tB_topic.Name = "tB_topic";
            tB_topic.Size = new Size(389, 27);
            tB_topic.TabIndex = 8;
            // 
            // btn_AI
            // 
            btn_AI.BackColor = Color.FromArgb(0, 117, 214);
            btn_AI.Font = new Font("Impact", 9F);
            btn_AI.ForeColor = Color.White;
            btn_AI.Image = (Image)resources.GetObject("btn_AI.Image");
            btn_AI.Location = new Point(12, 4);
            btn_AI.Name = "btn_AI";
            btn_AI.Size = new Size(84, 46);
            btn_AI.TabIndex = 9;
            btn_AI.Text = "AI";
            btn_AI.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_AI.UseVisualStyleBackColor = false;
            btn_AI.Click += btn_AI_Click;
            // 
            // FormExam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 25, 62);
            ClientSize = new Size(987, 556);
            Controls.Add(btn_AI);
            Controls.Add(btn_createquestion);
            Controls.Add(btn_review);
            Controls.Add(tB_topic);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btn_clear);
            Controls.Add(btn_listquestion);
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
        private Button btn_clear;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox tB_topic;
        private Button btn_AI;
    }
}