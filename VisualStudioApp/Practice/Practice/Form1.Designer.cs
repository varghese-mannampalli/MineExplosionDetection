namespace Practice
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
            this.Add = new System.Windows.Forms.Button();
            this.Num1 = new System.Windows.Forms.TextBox();
            this.Answer = new System.Windows.Forms.TextBox();
            this.Num2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(104, 54);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(100, 31);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Num1
            // 
            this.Num1.Location = new System.Drawing.Point(104, 213);
            this.Num1.Name = "Num1";
            this.Num1.Size = new System.Drawing.Size(100, 22);
            this.Num1.TabIndex = 1;
            // 
            // Answer
            // 
            this.Answer.Location = new System.Drawing.Point(282, 318);
            this.Answer.Name = "Answer";
            this.Answer.Size = new System.Drawing.Size(100, 22);
            this.Answer.TabIndex = 2;
            this.Answer.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Num2
            // 
            this.Num2.Location = new System.Drawing.Point(465, 212);
            this.Num2.Name = "Num2";
            this.Num2.Size = new System.Drawing.Size(100, 22);
            this.Num2.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Num2);
            this.Controls.Add(this.Answer);
            this.Controls.Add(this.Num1);
            this.Controls.Add(this.Add);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox Num1;
        private System.Windows.Forms.TextBox Answer;
        private System.Windows.Forms.TextBox Num2;
    }
}

