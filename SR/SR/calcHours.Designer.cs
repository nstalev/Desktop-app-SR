namespace SR
{
    partial class calcHours
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
            this.btn_Main6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Main6
            // 
            this.btn_Main6.Location = new System.Drawing.Point(12, 12);
            this.btn_Main6.Name = "btn_Main6";
            this.btn_Main6.Size = new System.Drawing.Size(148, 28);
            this.btn_Main6.TabIndex = 8;
            this.btn_Main6.Text = "Главно меню";
            this.btn_Main6.UseVisualStyleBackColor = true;
            this.btn_Main6.Click += new System.EventHandler(this.btn_Main6_Click);
            // 
            // calcHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 681);
            this.Controls.Add(this.btn_Main6);
            this.Name = "calcHours";
            this.Text = "calcHours";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Main6;
    }
}