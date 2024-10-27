namespace NetStudy
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            button2 = new Button();
            textBox7 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 148);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(197, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(259, 148);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(197, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(259, 240);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(197, 27);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 240);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(197, 27);
            textBox4.TabIndex = 2;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(259, 330);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(197, 27);
            textBox5.TabIndex = 5;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(12, 330);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(197, 27);
            textBox6.TabIndex = 4;
            // 
            // button2
            // 
            button2.Font = new Font("#9Slide03 Cabin Bold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(154, 491);
            button2.Name = "button2";
            button2.Size = new Size(164, 39);
            button2.TabIndex = 6;
            button2.Text = "ĐĂNG KÍ";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(174, 406);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(110, 27);
            textBox7.TabIndex = 7;
            // 
            // button1
            // 
            button1.Font = new Font("#9Slide03 Cabin Bold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button1.Location = new Point(320, 401);
            button1.Name = "button1";
            button1.Size = new Size(56, 43);
            button1.TabIndex = 8;
            button1.Text = "GỬI";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(468, 560);
            Controls.Add(button1);
            Controls.Add(textBox7);
            Controls.Add(button2);
            Controls.Add(textBox5);
            Controls.Add(textBox6);
            Controls.Add(textBox3);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            Text = "Đăng kí NetStudy";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button button2;
        private TextBox textBox7;
        private Button button1;
    }
}