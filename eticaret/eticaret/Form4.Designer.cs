namespace eticaret
{
    partial class Form4
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
            label1 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            domainUpDown1 = new DomainUpDown();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(37, 30);
            label1.Name = "label1";
            label1.Size = new Size(250, 28);
            label1.TabIndex = 0;
            label1.Text = "silinicek adet sayısını giriniz";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            radioButton1.Location = new Point(37, 129);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(108, 24);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "tamamını sil";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            radioButton2.Location = new Point(236, 131);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(163, 22);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "seçilen adet kadar sil";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // domainUpDown1
            // 
            domainUpDown1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            domainUpDown1.Location = new Point(417, 126);
            domainUpDown1.Margin = new Padding(1);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new Size(144, 27);
            domainUpDown1.TabIndex = 3;
            domainUpDown1.Text = "domainUpDown1";
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft PhagsPa", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(236, 238);
            button1.Name = "button1";
            button1.Size = new Size(75, 31);
            button1.TabIndex = 4;
            button1.Text = "sil";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(5F, 11F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(594, 321);
            Controls.Add(button1);
            Controls.Add(domainUpDown1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(2);
            Name = "Form4";
            Text = "+";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private DomainUpDown domainUpDown1;
        private Button button1;
    }
}