namespace NetStudy.Forms
{
    partial class FormDocument
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
            textBox_myusrname = new TextBox();
            button_mydcm = new Button();
            button_search = new Button();
            textBox_search = new TextBox();
            panel_top = new Panel();
            panel_body = new Panel();
            panel_bottom = new Panel();
            button_edit = new Button();
            button_delete = new Button();
            button_download = new Button();
            button_upload = new Button();
            comboBox_page = new ComboBox();
            label_page = new Label();
            panel_top.SuspendLayout();
            panel_bottom.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_myusrname
            // 
            textBox_myusrname.BackColor = Color.Indigo;
            textBox_myusrname.BorderStyle = BorderStyle.None;
            textBox_myusrname.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_myusrname.ForeColor = SystemColors.Control;
            textBox_myusrname.Location = new Point(3, 31);
            textBox_myusrname.Name = "textBox_myusrname";
            textBox_myusrname.Size = new Size(150, 23);
            textBox_myusrname.TabIndex = 1;
            // 
            // button_mydcm
            // 
            button_mydcm.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_mydcm.Location = new Point(177, 19);
            button_mydcm.Name = "button_mydcm";
            button_mydcm.Size = new Size(148, 47);
            button_mydcm.TabIndex = 2;
            button_mydcm.Text = "Kho của tôi";
            button_mydcm.UseVisualStyleBackColor = true;
            button_mydcm.Click += button_mydcm_Click;
            // 
            // button_search
            // 
            button_search.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_search.Location = new Point(1030, 19);
            button_search.Name = "button_search";
            button_search.Size = new Size(148, 47);
            button_search.TabIndex = 3;
            button_search.Text = "Tìm kiếm";
            button_search.UseVisualStyleBackColor = true;
            button_search.Click += button_search_Click;
            // 
            // textBox_search
            // 
            textBox_search.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_search.Location = new Point(365, 28);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(659, 30);
            textBox_search.TabIndex = 4;
            textBox_search.TextChanged += textBox_search_TextChanged;
            // 
            // panel_top
            // 
            panel_top.Controls.Add(textBox_myusrname);
            panel_top.Controls.Add(button_search);
            panel_top.Controls.Add(textBox_search);
            panel_top.Controls.Add(button_mydcm);
            panel_top.Location = new Point(8, 12);
            panel_top.Name = "panel_top";
            panel_top.Size = new Size(1185, 84);
            panel_top.TabIndex = 5;
            // 
            // panel_body
            // 
            panel_body.Location = new Point(8, 102);
            panel_body.Name = "panel_body";
            panel_body.Size = new Size(1185, 511);
            panel_body.TabIndex = 6;
            // 
            // panel_bottom
            // 
            panel_bottom.Controls.Add(button_edit);
            panel_bottom.Controls.Add(button_delete);
            panel_bottom.Controls.Add(button_download);
            panel_bottom.Controls.Add(button_upload);
            panel_bottom.Controls.Add(comboBox_page);
            panel_bottom.Controls.Add(label_page);
            panel_bottom.Location = new Point(8, 619);
            panel_bottom.Name = "panel_bottom";
            panel_bottom.Size = new Size(1185, 64);
            panel_bottom.TabIndex = 7;
            // 
            // button_edit
            // 
            button_edit.Font = new Font("Arial", 10F);
            button_edit.Location = new Point(313, 8);
            button_edit.Name = "button_edit";
            button_edit.Size = new Size(148, 47);
            button_edit.TabIndex = 6;
            button_edit.Text = "Chỉnh sửa";
            button_edit.UseVisualStyleBackColor = true;
            button_edit.Click += button_edit_Click;
            // 
            // button_delete
            // 
            button_delete.Font = new Font("Arial", 10F);
            button_delete.Location = new Point(467, 8);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(148, 47);
            button_delete.TabIndex = 5;
            button_delete.Text = "Xóa";
            button_delete.UseVisualStyleBackColor = true;
            button_delete.Click += button_delete_Click;
            // 
            // button_download
            // 
            button_download.Font = new Font("Arial", 10F);
            button_download.Location = new Point(159, 8);
            button_download.Name = "button_download";
            button_download.Size = new Size(148, 47);
            button_download.TabIndex = 5;
            button_download.Text = "Tải xuống";
            button_download.UseVisualStyleBackColor = true;
            button_download.Click += button_download_Click;
            // 
            // button_upload
            // 
            button_upload.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_upload.Location = new Point(5, 8);
            button_upload.Name = "button_upload";
            button_upload.Size = new Size(148, 47);
            button_upload.TabIndex = 4;
            button_upload.Text = "Tải lên";
            button_upload.UseVisualStyleBackColor = true;
            button_upload.Click += button_upload_Click;
            // 
            // comboBox_page
            // 
            comboBox_page.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_page.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_page.FormattingEnabled = true;
            comboBox_page.Location = new Point(969, 17);
            comboBox_page.Margin = new Padding(2);
            comboBox_page.Name = "comboBox_page";
            comboBox_page.Size = new Size(209, 31);
            comboBox_page.TabIndex = 3;
            // 
            // label_page
            // 
            label_page.AutoSize = true;
            label_page.BackColor = SystemColors.Control;
            label_page.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_page.ForeColor = Color.Gainsboro;
            label_page.Location = new Point(909, 20);
            label_page.Margin = new Padding(2, 0, 2, 0);
            label_page.Name = "label_page";
            label_page.Size = new Size(56, 23);
            label_page.TabIndex = 2;
            label_page.Text = "Page";
            // 
            // FormDocument
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1205, 695);
            Controls.Add(panel_bottom);
            Controls.Add(panel_body);
            Controls.Add(panel_top);
            Margin = new Padding(4);
            Name = "FormDocument";
            Text = "FormDocument";
            Load += FormDocument_Load;
            panel_top.ResumeLayout(false);
            panel_top.PerformLayout();
            panel_bottom.ResumeLayout(false);
            panel_bottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox_myusrname;
        private Button button_mydcm;
        private Button button_search;
        private TextBox textBox_search;
        private Panel panel_top;
        private Panel panel_body;
        private Panel panel_bottom;
        private ComboBox comboBox_page;
        private Label label_page;
        private Button button_upload;
        private Button button_edit;
        private Button button_delete;
        private Button button_download;
    }
}