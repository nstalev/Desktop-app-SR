namespace SR
{
    partial class deleteWorker
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
            this.btn_deleteWorker = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_Main5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_deleteWorker
            // 
            this.btn_deleteWorker.Location = new System.Drawing.Point(472, 14);
            this.btn_deleteWorker.Name = "btn_deleteWorker";
            this.btn_deleteWorker.Size = new System.Drawing.Size(106, 26);
            this.btn_deleteWorker.TabIndex = 5;
            this.btn_deleteWorker.Text = "Изтрий";
            this.btn_deleteWorker.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(43, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Име на работник";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(201, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(255, 26);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btn_Main5
            // 
            this.btn_Main5.Location = new System.Drawing.Point(47, 56);
            this.btn_Main5.Name = "btn_Main5";
            this.btn_Main5.Size = new System.Drawing.Size(148, 28);
            this.btn_Main5.TabIndex = 7;
            this.btn_Main5.Text = "Главно меню";
            this.btn_Main5.UseVisualStyleBackColor = true;
            this.btn_Main5.Click += new System.EventHandler(this.btn_Main5_Click);
            // 
            // deleteWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 129);
            this.Controls.Add(this.btn_Main5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_deleteWorker);
            this.Controls.Add(this.label1);
            this.Name = "deleteWorker";
            this.Text = "deleteWorker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_deleteWorker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_Main5;
    }
}