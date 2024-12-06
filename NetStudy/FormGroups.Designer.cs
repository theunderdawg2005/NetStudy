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
            linkCreateGroup = new LinkLabel();
            panel2 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(26, 25, 62);
            panel1.Controls.Add(linkCreateGroup);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1205, 68);
            panel1.TabIndex = 0;
            // 
            // linkCreateGroup
            // 
            linkCreateGroup.AutoSize = true;
            linkCreateGroup.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkCreateGroup.LinkColor = Color.FromArgb(128, 128, 255);
            linkCreateGroup.Location = new Point(1010, 19);
            linkCreateGroup.Name = "linkCreateGroup";
            linkCreateGroup.Size = new Size(192, 26);
            linkCreateGroup.TabIndex = 0;
            linkCreateGroup.TabStop = true;
            linkCreateGroup.Text = "Create new group";
            linkCreateGroup.LinkClicked += linkCreateGroup_LinkClicked;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(26, 25, 62);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 621);
            panel2.Name = "panel2";
            panel2.Size = new Size(1205, 74);
            panel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
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
            Text = "FormGroups";
            Load += FormGroups_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private LinkLabel linkCreateGroup;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}