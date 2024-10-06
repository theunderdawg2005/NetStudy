namespace NetStudy
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Lexend", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button1.Location = new Point(539, 33);
            button1.Name = "button1";
            button1.Size = new Size(121, 38);
            button1.TabIndex = 0;
            button1.Text = "Trang chủ";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Lexend", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button2.Location = new Point(313, 35);
            button2.Name = "button2";
            button2.Size = new Size(48, 38);
            button2.TabIndex = 1;
            button2.Text = "TKB";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Lexend", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button3.Location = new Point(367, 35);
            button3.Name = "button3";
            button3.Size = new Size(70, 38);
            button3.TabIndex = 2;
            button3.Text = "Tài liệu";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Lexend", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button4.Location = new Point(443, 35);
            button4.Name = "button4";
            button4.Size = new Size(90, 38);
            button4.TabIndex = 3;
            button4.Text = "Flashcard";
            // 
            // button5
            // 
            button5.Font = new Font("Lexend", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button5.Location = new Point(664, 33);
            button5.Name = "button5";
            button5.Size = new Size(82, 38);
            button5.TabIndex = 4;
            button5.Text = "Tin nhắn";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("Lexend", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button6.Location = new Point(752, 33);
            button6.Name = "button6";
            button6.Size = new Size(77, 38);
            button6.TabIndex = 5;
            button6.Text = "Bạn học";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Font = new Font("Lexend", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button7.Location = new Point(835, 33);
            button7.Name = "button7";
            button7.Size = new Size(93, 38);
            button7.TabIndex = 6;
            button7.Text = "Tài khoản";
            button7.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(933, 530);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Menu";
            Text = "NetStudy - Hệ thống học tập chia sẻ từ xa";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}
