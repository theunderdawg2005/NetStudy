namespace NetStudy.Forms
{
    partial class FormMatch
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
            panelPage = new Panel();
            panelBottom = new Panel();
            btnRequest = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            labelUsername = new Label();
            comboPage = new ComboBox();
            labelPage = new Label();
            panelTop = new Panel();
            btnSearch = new FontAwesome.Sharp.IconButton();
            labeltitle = new Label();
            txtSearch = new TextBox();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panelPage.SuspendLayout();
            panelBottom.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelPage
            // 
            panelPage.BackColor = Color.FromArgb(26, 25, 62);
            panelPage.Controls.Add(panelBottom);
            panelPage.Controls.Add(labelUsername);
            panelPage.Controls.Add(comboPage);
            panelPage.Controls.Add(labelPage);
            panelPage.Dock = DockStyle.Bottom;
            panelPage.Location = new Point(0, 514);
            panelPage.Margin = new Padding(2, 2, 2, 2);
            panelPage.Name = "panelPage";
            panelPage.Size = new Size(964, 42);
            panelPage.TabIndex = 1;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(26, 25, 62);
            panelBottom.Controls.Add(btnRequest);
            panelBottom.Controls.Add(label1);
            panelBottom.Controls.Add(comboBox1);
            panelBottom.Controls.Add(label2);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 0);
            panelBottom.Margin = new Padding(2, 2, 2, 2);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(964, 42);
            panelBottom.TabIndex = 3;
            // 
            // btnRequest
            // 
            btnRequest.BackColor = Color.SlateBlue;
            btnRequest.FlatAppearance.BorderSize = 0;
            btnRequest.FlatStyle = FlatStyle.Flat;
            btnRequest.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRequest.ForeColor = Color.Gainsboro;
            btnRequest.Location = new Point(553, 4);
            btnRequest.Margin = new Padding(2, 2, 2, 2);
            btnRequest.Name = "btnRequest";
            btnRequest.Size = new Size(157, 34);
            btnRequest.TabIndex = 4;
            btnRequest.Text = "Friend Request (0)";
            btnRequest.UseVisualStyleBackColor = false;
            btnRequest.Click += btnRequest_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(23, 10);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(92, 22);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(781, 9);
            comboBox1.Margin = new Padding(2, 2, 2, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(168, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(730, 10);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(48, 22);
            label2.TabIndex = 0;
            label2.Text = "Page";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUsername.ForeColor = Color.Gainsboro;
            labelUsername.Location = new Point(23, 10);
            labelUsername.Margin = new Padding(2, 0, 2, 0);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(92, 22);
            labelUsername.TabIndex = 2;
            labelUsername.Text = "Username";
            // 
            // comboPage
            // 
            comboPage.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboPage.FormattingEnabled = true;
            comboPage.Location = new Point(781, 9);
            comboPage.Margin = new Padding(2, 2, 2, 2);
            comboPage.Name = "comboPage";
            comboPage.Size = new Size(168, 28);
            comboPage.TabIndex = 1;
            // 
            // labelPage
            // 
            labelPage.AutoSize = true;
            labelPage.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPage.ForeColor = Color.Gainsboro;
            labelPage.Location = new Point(730, 10);
            labelPage.Margin = new Padding(2, 0, 2, 0);
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(48, 22);
            labelPage.TabIndex = 0;
            labelPage.Text = "Page";
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(26, 25, 62);
            panelTop.Controls.Add(btnSearch);
            panelTop.Controls.Add(labeltitle);
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(panel1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(2, 2, 2, 2);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(964, 53);
            panelTop.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Indigo;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.Gainsboro;
            btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnSearch.IconColor = Color.Gainsboro;
            btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSearch.IconSize = 35;
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(744, 10);
            btnSearch.Margin = new Padding(2, 2, 2, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 34);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "SEARCH";
            btnSearch.TextAlign = ContentAlignment.MiddleLeft;
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // labeltitle
            // 
            labeltitle.AutoSize = true;
            labeltitle.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labeltitle.ForeColor = Color.Gainsboro;
            labeltitle.Location = new Point(79, 16);
            labeltitle.Margin = new Padding(2, 0, 2, 0);
            labeltitle.Name = "labeltitle";
            labeltitle.Size = new Size(135, 22);
            labeltitle.TabIndex = 2;
            labeltitle.Text = "Find user here";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(26, 25, 62);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.Gainsboro;
            txtSearch.Location = new Point(211, 16);
            txtSearch.Margin = new Padding(2, 2, 2, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(520, 22);
            txtSearch.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Indigo;
            panel1.Location = new Point(211, 40);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(520, 2);
            panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(34, 33, 74);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 53);
            flowLayoutPanel1.Margin = new Padding(2, 2, 2, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(964, 461);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.WrapContents = false;
            // 
            // FormMatch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 556);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panelTop);
            Controls.Add(panelPage);
            Name = "FormMatch";
            Text = "FormMatch";
            Load += FormMatch_Load;
            panelPage.ResumeLayout(false);
            panelPage.PerformLayout();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelPage;
        private ComboBox comboPage;
        private Label labelPage;
        private Label labelUsername;
        private Panel panelBottom;
        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private Panel panelTop;
        private Panel panel1;
        private TextBox txtSearch;
        private FontAwesome.Sharp.IconButton btnSearch;
        private Label labeltitle;
        private Button btnRequest;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}