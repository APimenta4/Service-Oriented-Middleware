namespace Switch {
    partial class SwitchForm {
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
            this.btnOn = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
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
            // btnOn
            // 
            this.btnOn.Font = new System.Drawing.Font("Yu Gothic Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOn.Location = new System.Drawing.Point(93, 282);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(200, 100);
            this.btnOn.TabIndex = 2;
            this.btnOn.Text = "ON";
            this.btnOn.UseVisualStyleBackColor = true;
            this.btnOn.Click += new System.EventHandler(this.btnOnClick);
            // 
            // btnOff
            // 
            this.btnOff.Font = new System.Drawing.Font("Yu Gothic Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOff.Location = new System.Drawing.Point(93, 176);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(200, 100);
            this.btnOff.TabIndex = 3;
            this.btnOff.Text = "OFF";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOffClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 545);
            this.Controls.Add(this.btnOff);
            this.Controls.Add(this.btnOn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Button btnOff;
    }
}

