﻿namespace SR
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.newOrder = new System.Windows.Forms.Button();
            this.allOrders = new System.Windows.Forms.Button();
            this.calcHours = new System.Windows.Forms.Button();
            this.btn_createWorker = new System.Windows.Forms.Button();
            this.btn_deleteWorker = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1202, 785);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // newOrder
            // 
            this.newOrder.Location = new System.Drawing.Point(45, 158);
            this.newOrder.Name = "newOrder";
            this.newOrder.Size = new System.Drawing.Size(108, 57);
            this.newOrder.TabIndex = 1;
            this.newOrder.Text = "Нова поръчка";
            this.newOrder.UseVisualStyleBackColor = true;
            this.newOrder.Click += new System.EventHandler(this.newOrder_Click);
            // 
            // allOrders
            // 
            this.allOrders.Location = new System.Drawing.Point(45, 221);
            this.allOrders.Name = "allOrders";
            this.allOrders.Size = new System.Drawing.Size(108, 57);
            this.allOrders.TabIndex = 3;
            this.allOrders.Text = "Всички поръчки";
            this.allOrders.UseVisualStyleBackColor = true;
            this.allOrders.Click += new System.EventHandler(this.allOrders_Click);
            // 
            // calcHours
            // 
            this.calcHours.Location = new System.Drawing.Point(45, 284);
            this.calcHours.Name = "calcHours";
            this.calcHours.Size = new System.Drawing.Size(108, 57);
            this.calcHours.TabIndex = 4;
            this.calcHours.Text = "Изчисляване на работни часове и манипулации";
            this.calcHours.UseVisualStyleBackColor = true;
            this.calcHours.Click += new System.EventHandler(this.calcHours_Click);
            // 
            // btn_createWorker
            // 
            this.btn_createWorker.Location = new System.Drawing.Point(45, 347);
            this.btn_createWorker.Name = "btn_createWorker";
            this.btn_createWorker.Size = new System.Drawing.Size(108, 57);
            this.btn_createWorker.TabIndex = 6;
            this.btn_createWorker.Text = "Създай работник";
            this.btn_createWorker.UseVisualStyleBackColor = true;
            // 
            // btn_deleteWorker
            // 
            this.btn_deleteWorker.Location = new System.Drawing.Point(45, 410);
            this.btn_deleteWorker.Name = "btn_deleteWorker";
            this.btn_deleteWorker.Size = new System.Drawing.Size(108, 57);
            this.btn_deleteWorker.TabIndex = 7;
            this.btn_deleteWorker.Text = "Изтрий работник";
            this.btn_deleteWorker.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 781);
            this.Controls.Add(this.btn_deleteWorker);
            this.Controls.Add(this.btn_createWorker);
            this.Controls.Add(this.calcHours);
            this.Controls.Add(this.allOrders);
            this.Controls.Add(this.newOrder);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Main";
            this.Text = "Главно меню";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button newOrder;
        private System.Windows.Forms.Button allOrders;
        private System.Windows.Forms.Button calcHours;
        private System.Windows.Forms.Button btn_createWorker;
        private System.Windows.Forms.Button btn_deleteWorker;
    }
}