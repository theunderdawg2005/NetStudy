namespace NetStudy
{
    partial class FormCreateQuestion
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
            tB_title = new TextBox();
            tB_content = new TextBox();
            tB_correctanswer = new TextBox();
            lbl_title = new Label();
            lbl_content = new Label();
            lbl_correctanswer = new Label();
            btn_create = new Button();
            btn_clear = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // tB_title
            // 
            tB_title.Location = new Point(211, 85);
            tB_title.Multiline = true;
            tB_title.Name = "tB_title";
            tB_title.Size = new Size(632, 34);
            tB_title.TabIndex = 0;
            // 
            // tB_content
            // 
            tB_content.Location = new Point(211, 152);
            tB_content.Multiline = true;
            tB_content.Name = "tB_content";
            tB_content.Size = new Size(632, 68);
            tB_content.TabIndex = 1;
            // 
            // tB_correctanswer
            // 
            tB_correctanswer.Location = new Point(211, 246);
            tB_correctanswer.Multiline = true;
            tB_correctanswer.Name = "tB_correctanswer";
            tB_correctanswer.Size = new Size(632, 34);
            tB_correctanswer.TabIndex = 2;
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.BackColor = Color.White;
            lbl_title.Font = new Font("Cambria", 15F, FontStyle.Bold);
            lbl_title.ForeColor = Color.FromArgb(0, 117, 214);
            lbl_title.Location = new Point(119, 80);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(76, 30);
            lbl_title.TabIndex = 3;
            lbl_title.Text = "Topic";
            // 
            // lbl_content
            // 
            lbl_content.AutoSize = true;
            lbl_content.BackColor = Color.White;
            lbl_content.Font = new Font("Cambria", 15F, FontStyle.Bold);
            lbl_content.ForeColor = Color.FromArgb(0, 117, 214);
            lbl_content.Location = new Point(93, 147);
            lbl_content.Name = "lbl_content";
            lbl_content.Size = new Size(102, 30);
            lbl_content.TabIndex = 4;
            lbl_content.Text = "Content";
            // 
            // lbl_correctanswer
            // 
            lbl_correctanswer.AutoSize = true;
            lbl_correctanswer.BackColor = Color.White;
            lbl_correctanswer.Font = new Font("Cambria", 15F, FontStyle.Bold);
            lbl_correctanswer.ForeColor = Color.FromArgb(0, 117, 214);
            lbl_correctanswer.Location = new Point(14, 246);
            lbl_correctanswer.Name = "lbl_correctanswer";
            lbl_correctanswer.Size = new Size(191, 30);
            lbl_correctanswer.TabIndex = 5;
            lbl_correctanswer.Text = "Correct Answer";
            // 
            // btn_create
            // 
            btn_create.BackColor = Color.FromArgb(0, 117, 214);
            btn_create.Font = new Font("Impact", 9F);
            btn_create.ForeColor = Color.White;
            btn_create.Location = new Point(732, 298);
            btn_create.Name = "btn_create";
            btn_create.Size = new Size(111, 40);
            btn_create.TabIndex = 6;
            btn_create.Text = "Create";
            btn_create.UseVisualStyleBackColor = false;
            btn_create.Click += btn_create_Click;
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.FromArgb(0, 117, 214);
            btn_clear.Font = new Font("Impact", 9F);
            btn_clear.ForeColor = Color.White;
            btn_clear.Location = new Point(602, 298);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(99, 40);
            btn_clear.TabIndex = 7;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Bahnschrift SemiBold", 24F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 117, 214);
            label1.Location = new Point(268, 18);
            label1.Name = "label1";
            label1.Size = new Size(393, 48);
            label1.TabIndex = 8;
            label1.Text = "Create your question";
            // 
            // FormCreateQuestion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(885, 362);
            Controls.Add(label1);
            Controls.Add(btn_clear);
            Controls.Add(btn_create);
            Controls.Add(lbl_correctanswer);
            Controls.Add(lbl_content);
            Controls.Add(lbl_title);
            Controls.Add(tB_correctanswer);
            Controls.Add(tB_content);
            Controls.Add(tB_title);
            Name = "FormCreateQuestion";
            Text = "FormCreateQuestion";
            FormClosed += FormCreateQuestion_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tB_title;
        private TextBox tB_content;
        private TextBox tB_correctanswer;
        private Label lbl_title;
        private Label lbl_content;
        private Label lbl_correctanswer;
        private Button btn_create;
        private Button btn_clear;
        private Label label1;
    }
}