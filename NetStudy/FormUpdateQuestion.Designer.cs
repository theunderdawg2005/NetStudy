namespace NetStudy
{
    partial class FormUpdateQuestion
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
            btn_clear = new Button();
            btn_update = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // tB_title
            // 
            tB_title.Location = new Point(230, 99);
            tB_title.Multiline = true;
            tB_title.Name = "tB_title";
            tB_title.Size = new Size(632, 34);
            tB_title.TabIndex = 1;
            // 
            // tB_content
            // 
            tB_content.Location = new Point(230, 177);
            tB_content.Multiline = true;
            tB_content.Name = "tB_content";
            tB_content.Size = new Size(632, 68);
            tB_content.TabIndex = 2;
            // 
            // tB_correctanswer
            // 
            tB_correctanswer.Location = new Point(230, 289);
            tB_correctanswer.Multiline = true;
            tB_correctanswer.Name = "tB_correctanswer";
            tB_correctanswer.Size = new Size(632, 34);
            tB_correctanswer.TabIndex = 3;
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.BackColor = Color.White;
            lbl_title.Font = new Font("Cambria", 15F, FontStyle.Bold);
            lbl_title.ForeColor = Color.FromArgb(0, 117, 214);
            lbl_title.Location = new Point(118, 99);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(76, 30);
            lbl_title.TabIndex = 4;
            lbl_title.Text = "Topic";
            // 
            // lbl_content
            // 
            lbl_content.AutoSize = true;
            lbl_content.BackColor = Color.White;
            lbl_content.Font = new Font("Cambria", 15F, FontStyle.Bold);
            lbl_content.ForeColor = Color.FromArgb(0, 117, 214);
            lbl_content.Location = new Point(109, 177);
            lbl_content.Name = "lbl_content";
            lbl_content.Size = new Size(102, 30);
            lbl_content.TabIndex = 5;
            lbl_content.Text = "Content";
            // 
            // lbl_correctanswer
            // 
            lbl_correctanswer.AutoSize = true;
            lbl_correctanswer.BackColor = Color.White;
            lbl_correctanswer.Font = new Font("Cambria", 15F, FontStyle.Bold);
            lbl_correctanswer.ForeColor = Color.FromArgb(0, 117, 214);
            lbl_correctanswer.Location = new Point(33, 289);
            lbl_correctanswer.Name = "lbl_correctanswer";
            lbl_correctanswer.Size = new Size(191, 30);
            lbl_correctanswer.TabIndex = 6;
            lbl_correctanswer.Text = "Correct Answer";
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.FromArgb(0, 117, 214);
            btn_clear.Font = new Font("Impact", 9F);
            btn_clear.ForeColor = Color.White;
            btn_clear.Location = new Point(633, 371);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(99, 40);
            btn_clear.TabIndex = 8;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // btn_update
            // 
            btn_update.BackColor = Color.FromArgb(0, 117, 214);
            btn_update.Font = new Font("Impact", 9F);
            btn_update.ForeColor = Color.White;
            btn_update.Location = new Point(751, 371);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(111, 40);
            btn_update.TabIndex = 9;
            btn_update.Text = "Update";
            btn_update.UseVisualStyleBackColor = false;
            btn_update.Click += btn_update_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Bahnschrift SemiBold", 24F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 117, 214);
            label1.Location = new Point(325, 22);
            label1.Name = "label1";
            label1.Size = new Size(400, 48);
            label1.TabIndex = 10;
            label1.Text = "Update your question";
            // 
            // FormUpdateQuestion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(902, 444);
            Controls.Add(label1);
            Controls.Add(btn_update);
            Controls.Add(btn_clear);
            Controls.Add(lbl_correctanswer);
            Controls.Add(lbl_content);
            Controls.Add(lbl_title);
            Controls.Add(tB_correctanswer);
            Controls.Add(tB_content);
            Controls.Add(tB_title);
            Name = "FormUpdateQuestion";
            Text = "FormUpdateQuestion";
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
        private Button btn_clear;
        private Button btn_update;
        private Label label1;
    }
}