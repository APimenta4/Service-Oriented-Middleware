﻿namespace Switch {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.btn_on = new System.Windows.Forms.Button();
            this.btn_off = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Switch";
            // 
            // btn_on
            // 
            this.btn_on.Font = new System.Drawing.Font("Yu Gothic Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_on.Location = new System.Drawing.Point(93, 282);
            this.btn_on.Name = "btn_on";
            this.btn_on.Size = new System.Drawing.Size(200, 100);
            this.btn_on.TabIndex = 2;
            this.btn_on.Text = "ON";
            this.btn_on.UseVisualStyleBackColor = true;
            // 
            // btn_off
            // 
            this.btn_off.Font = new System.Drawing.Font("Yu Gothic Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_off.Location = new System.Drawing.Point(93, 176);
            this.btn_off.Name = "btn_off";
            this.btn_off.Size = new System.Drawing.Size(200, 100);
            this.btn_off.TabIndex = 3;
            this.btn_off.Text = "OFF";
            this.btn_off.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 545);
            this.Controls.Add(this.btn_off);
            this.Controls.Add(this.btn_on);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_on;
        private System.Windows.Forms.Button btn_off;
    }
}

