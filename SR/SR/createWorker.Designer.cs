namespace SR
{
    partial class createWorker
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_createWorker = new System.Windows.Forms.Button();
            this.btn_Main4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Име на работник";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(170, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 24);
            this.textBox1.TabIndex = 1;
            // 
            // btn_createWorker
            // 
            this.btn_createWorker.Location = new System.Drawing.Point(435, 27);
            this.btn_createWorker.Name = "btn_createWorker";
            this.btn_createWorker.Size = new System.Drawing.Size(106, 24);
            this.btn_createWorker.TabIndex = 2;
            this.btn_createWorker.Text = "Създай";
            this.btn_createWorker.UseVisualStyleBackColor = true;
            // 
            // btn_Main4
            // 
            this.btn_Main4.Location = new System.Drawing.Point(16, 69);
            this.btn_Main4.Name = "btn_Main4";
            this.btn_Main4.Size = new System.Drawing.Size(148, 28);
            this.btn_Main4.TabIndex = 3;
            this.btn_Main4.Text = "Главно меню";
            this.btn_Main4.UseVisualStyleBackColor = true;
            this.btn_Main4.Click += new System.EventHandler(this.btn_Main4_Click);
            // 
            // createWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 115);
            this.Controls.Add(this.btn_Main4);
            this.Controls.Add(this.btn_createWorker);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "createWorker";
            this.Text = "createWorker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_createWorker;
        private System.Windows.Forms.Button btn_Main4;
    }
}