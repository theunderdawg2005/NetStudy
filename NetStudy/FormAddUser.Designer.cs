namespace NetStudy
{
    partial class FormAddUser
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
            txtUsername = new TextBox();
            label1 = new Label();
            btnAdd = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            lblName = new Label();
            label3 = new Label();
            comboRole = new ComboBox();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(191, 129);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(272, 31);
            txtUsername.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiBold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(61, 130);
            label1.Name = "label1";
            label1.Size = new Size(124, 27);
            label1.TabIndex = 1;
            label1.Text = "Username: ";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(34, 33, 74);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.Cornsilk;
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnAdd.IconColor = Color.Gainsboro;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.Location = new Point(469, 120);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(47, 54);
            btnAdd.TabIndex = 2;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(84, 9);
            label2.Name = "label2";
            label2.Size = new Size(418, 53);
            label2.TabIndex = 3;
            label2.Text = "ADD YOUR FRIENDS";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Bahnschrift SemiBold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.Gainsboro;
            lblName.Location = new Point(230, 74);
            lblName.Name = "lblName";
            lblName.Size = new Size(145, 27);
            lblName.TabIndex = 4;
            lblName.Text = "{GroupName}";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift SemiBold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gainsboro;
            label3.Location = new Point(118, 171);
            label3.Name = "label3";
            label3.Size = new Size(67, 27);
            label3.TabIndex = 5;
            label3.Text = "Role: ";
            // 
            // comboRole
            // 
            comboRole.FormattingEnabled = true;
            comboRole.Location = new Point(191, 170);
            comboRole.Name = "comboRole";
            comboRole.Size = new Size(182, 33);
            comboRole.TabIndex = 6;
            // 
            // FormAddUser
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(603, 229);
            Controls.Add(comboRole);
            Controls.Add(label3);
            Controls.Add(lblName);
            Controls.Add(label2);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            Controls.Add(txtUsername);
            Name = "FormAddUser";
            Text = "FormAddUser";
            Load += FormAddUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnAdd;
        private Label label2;
        private Label lblName;
        private Label label3;
        private ComboBox comboRole;
    }
}