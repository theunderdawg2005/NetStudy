namespace NetStudy
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(60, 142);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(321, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(60, 245);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(321, 27);
            textBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("#9Slide03 BoosterNextFYThin", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button1.Location = new Point(300, 293);
            button1.Name = "button1";
            button1.Size = new Size(140, 35);
            button1.TabIndex = 2;
            button1.Text = "Quên mật khẩu";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("#9Slide03 Cabin Bold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(141, 359);
            button2.Name = "button2";
            button2.Size = new Size(164, 39);
            button2.TabIndex = 3;
            button2.Text = "ĐĂNG NHẬP";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("#9Slide03 BoosterNextFYThin", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button3.Location = new Point(60, 293);
            button3.Name = "button3";
            button3.Size = new Size(72, 35);
            button3.TabIndex = 4;
            button3.Text = "Đăng kí";
            button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(468, 560);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Đăng nhập vào NetStudy";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}