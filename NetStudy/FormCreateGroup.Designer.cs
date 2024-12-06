namespace NetStudy
{
    partial class FormCreateGroup
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
            groupBox1 = new GroupBox();
            linkExit = new LinkLabel();
            label4 = new Label();
            label3 = new Label();
            txtDescription = new RichTextBox();
            linkClear = new LinkLabel();
            txtName = new TextBox();
            btnCreate = new Button();
            panel2 = new Panel();
            PicPassword = new FontAwesome.Sharp.IconPictureBox();
            panel1 = new Panel();
            PicUser = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            label1 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(linkExit);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(linkClear);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(PicPassword);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(PicUser);
            groupBox1.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(0, 117, 214);
            groupBox1.Location = new Point(12, 161);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(599, 520);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create your group";
            // 
            // linkExit
            // 
            linkExit.AutoSize = true;
            linkExit.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkExit.LinkColor = Color.FromArgb(0, 117, 214);
            linkExit.Location = new Point(274, 480);
            linkExit.Name = "linkExit";
            linkExit.Size = new Size(52, 26);
            linkExit.TabIndex = 24;
            linkExit.TabStop = true;
            linkExit.Text = "Exit";
            linkExit.LinkClicked += linkExit_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(0, 117, 214);
            label4.Location = new Point(107, 139);
            label4.Name = "label4";
            label4.Size = new Size(116, 23);
            label4.TabIndex = 23;
            label4.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 117, 214);
            label3.Location = new Point(107, 37);
            label3.Name = "label3";
            label3.Size = new Size(64, 23);
            label3.TabIndex = 22;
            label3.Text = "Name";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(161, 174);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(326, 180);
            txtDescription.TabIndex = 21;
            txtDescription.Text = "";
            // 
            // linkClear
            // 
            linkClear.AutoSize = true;
            linkClear.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkClear.LinkColor = Color.FromArgb(0, 117, 214);
            linkClear.Location = new Point(378, 374);
            linkClear.Name = "linkClear";
            linkClear.Size = new Size(127, 26);
            linkClear.TabIndex = 20;
            linkClear.TabStop = true;
            linkClear.Text = "Clear fields";
            linkClear.LinkClicked += linkClear_LinkClicked;
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtName.ForeColor = Color.FromArgb(0, 117, 214);
            txtName.Location = new Point(161, 81);
            txtName.Name = "txtName";
            txtName.Size = new Size(326, 29);
            txtName.TabIndex = 18;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(0, 117, 214);
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(107, 413);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(380, 55);
            btnCreate.TabIndex = 17;
            btnCreate.Text = "CREATE";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 117, 214);
            panel2.Location = new Point(161, 360);
            panel2.Name = "panel2";
            panel2.Size = new Size(326, 1);
            panel2.TabIndex = 16;
            // 
            // PicPassword
            // 
            PicPassword.BackColor = Color.White;
            PicPassword.ForeColor = Color.FromArgb(0, 117, 214);
            PicPassword.IconChar = FontAwesome.Sharp.IconChar.PenRuler;
            PicPassword.IconColor = Color.FromArgb(0, 117, 214);
            PicPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            PicPassword.IconSize = 48;
            PicPassword.Location = new Point(107, 174);
            PicPassword.Name = "PicPassword";
            PicPassword.Size = new Size(48, 48);
            PicPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            PicPassword.TabIndex = 15;
            PicPassword.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 117, 214);
            panel1.Location = new Point(107, 125);
            panel1.Name = "panel1";
            panel1.Size = new Size(380, 1);
            panel1.TabIndex = 14;
            // 
            // PicUser
            // 
            PicUser.BackColor = Color.White;
            PicUser.ForeColor = Color.FromArgb(0, 117, 214);
            PicUser.IconChar = FontAwesome.Sharp.IconChar.Tag;
            PicUser.IconColor = Color.FromArgb(0, 117, 214);
            PicUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            PicUser.IconSize = 48;
            PicUser.Location = new Point(107, 71);
            PicUser.Name = "PicUser";
            PicUser.Size = new Size(48, 48);
            PicUser.SizeMode = PictureBoxSizeMode.StretchImage;
            PicUser.TabIndex = 13;
            PicUser.TabStop = false;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.White;
            iconPictureBox1.ForeColor = Color.FromArgb(0, 117, 214);
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            iconPictureBox1.IconColor = Color.FromArgb(0, 117, 214);
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 118;
            iconPictureBox1.Location = new Point(45, 23);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(119, 118);
            iconPictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            iconPictureBox1.TabIndex = 1;
            iconPictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiBold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 117, 214);
            label1.Location = new Point(170, 23);
            label1.Name = "label1";
            label1.Size = new Size(414, 58);
            label1.TabIndex = 2;
            label1.Text = "Create your group";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift SemiBold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 117, 214);
            label2.Location = new Point(170, 83);
            label2.Name = "label2";
            label2.Size = new Size(356, 58);
            label2.TabIndex = 3;
            label2.Text = "for your friends";
            // 
            // FormCreateGroup
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(623, 693);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(iconPictureBox1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCreateGroup";
            Text = "FormCreateGroup";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PicPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Label label1;
        private Label label2;
        private RichTextBox txtDescription;
        private LinkLabel linkClear;
        private TextBox txtName;
        private Button btnCreate;
        private Panel panel2;
        private FontAwesome.Sharp.IconPictureBox PicPassword;
        private Panel panel1;
        private FontAwesome.Sharp.IconPictureBox PicUser;
        private Label label4;
        private Label label3;
        private LinkLabel linkExit;
    }
}