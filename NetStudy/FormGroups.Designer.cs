namespace NetStudy
{
    partial class FormGroups
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
            btnSearch = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            txtSearchGroup = new TextBox();
            linkCreateGroup = new LinkLabel();
            panel2 = new Panel();
            lblName = new Label();
            comboBox1 = new ComboBox();
            lblPage = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(26, 25, 62);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtSearchGroup);
            panel1.Controls.Add(linkCreateGroup);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1205, 68);
            panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.BackColor = Color.FromArgb(192, 0, 192);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderColor = Color.Gainsboro;
            btnSearch.FlatAppearance.BorderSize = 2;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnSearch.IconColor = Color.Gainsboro;
            btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSearch.IconSize = 35;
            btnSearch.Location = new Point(705, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(45, 45);
            btnSearch.TabIndex = 3;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiBold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(26, 19);
            label1.Name = "label1";
            label1.Size = new Size(114, 27);
            label1.TabIndex = 2;
            label1.Text = "Tìm nhóm:";
            // 
            // txtSearchGroup
            // 
            txtSearchGroup.Location = new Point(146, 17);
            txtSearchGroup.Name = "txtSearchGroup";
            txtSearchGroup.Size = new Size(544, 31);
            txtSearchGroup.TabIndex = 1;
            txtSearchGroup.TextChanged += txtSearchGroup_TextChanged;
            // 
            // linkCreateGroup
            // 
            linkCreateGroup.AutoSize = true;
            linkCreateGroup.Cursor = Cursors.Hand;
            linkCreateGroup.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkCreateGroup.LinkColor = Color.FromArgb(128, 128, 255);
            linkCreateGroup.Location = new Point(1010, 19);
            linkCreateGroup.Name = "linkCreateGroup";
            linkCreateGroup.Size = new Size(196, 26);
            linkCreateGroup.TabIndex = 0;
            linkCreateGroup.TabStop = true;
            linkCreateGroup.Text = "Tạo nhóm của bạn";
            linkCreateGroup.LinkClicked += linkCreateGroup_LinkClicked;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(26, 25, 62);
            panel2.Controls.Add(lblName);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(lblPage);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 621);
            panel2.Name = "panel2";
            panel2.Size = new Size(1205, 74);
            panel2.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Bahnschrift SemiBold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.Gainsboro;
            lblName.Location = new Point(26, 22);
            lblName.Name = "lblName";
            lblName.Size = new Size(179, 27);
            lblName.TabIndex = 5;
            lblName.Text = "{user's fullname}";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1000, 21);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Font = new Font("Bahnschrift SemiBold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPage.ForeColor = Color.Gainsboro;
            lblPage.Location = new Point(917, 22);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(77, 27);
            lblPage.TabIndex = 3;
            lblPage.Text = "Pages:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 68);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1205, 553);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // FormGroups
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(1205, 695);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FormGroups";
            Text = " Hội nhóm";
            Load += FormGroups_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private LinkLabel linkCreateGroup;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private TextBox txtSearchGroup;
        private Label lblName;
        private ComboBox comboBox1;
        private Label lblPage;
        private FontAwesome.Sharp.IconButton btnSearch;
    }
}