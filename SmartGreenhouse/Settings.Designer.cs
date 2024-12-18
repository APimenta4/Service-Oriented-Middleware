namespace SmartGreenhouse {
    partial class Settings {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericLightsThreshold = new System.Windows.Forms.NumericUpDown();
            this.numericTemperatureThreshold = new System.Windows.Forms.NumericUpDown();
            this.numericWateringThreshold = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLightsThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTemperatureThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWateringThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.65009F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.84871F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.54613F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericLightsThreshold, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericTemperatureThreshold, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericWateringThreshold, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(542, 198);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Lato", 16.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(476, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 66);
            this.label6.TabIndex = 26;
            this.label6.Text = "lux";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Lato", 16.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(476, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 66);
            this.label5.TabIndex = 25;
            this.label5.Text = "ºC";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Lato", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(3, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 66);
            this.label4.TabIndex = 19;
            this.label4.Text = "Lights Threshhold";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Lato", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 66);
            this.label2.TabIndex = 17;
            this.label2.Text = "Watering Threshhold";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Lato", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 66);
            this.label1.TabIndex = 20;
            this.label1.Text = "Temperature Threshold";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericLightsThreshold
            // 
            this.numericLightsThreshold.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericLightsThreshold.Font = new System.Drawing.Font("Lato", 16.2F, System.Drawing.FontStyle.Bold);
            this.numericLightsThreshold.Location = new System.Drawing.Point(364, 145);
            this.numericLightsThreshold.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericLightsThreshold.Name = "numericLightsThreshold";
            this.numericLightsThreshold.Size = new System.Drawing.Size(106, 40);
            this.numericLightsThreshold.TabIndex = 23;
            this.numericLightsThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericLightsThreshold.ValueChanged += new System.EventHandler(this.numericLightsThreshold_ValueChanged);
            // 
            // numericTemperatureThreshold
            // 
            this.numericTemperatureThreshold.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericTemperatureThreshold.BackColor = System.Drawing.Color.White;
            this.numericTemperatureThreshold.Font = new System.Drawing.Font("Lato", 16.2F, System.Drawing.FontStyle.Bold);
            this.numericTemperatureThreshold.Location = new System.Drawing.Point(364, 79);
            this.numericTemperatureThreshold.Name = "numericTemperatureThreshold";
            this.numericTemperatureThreshold.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericTemperatureThreshold.Size = new System.Drawing.Size(106, 40);
            this.numericTemperatureThreshold.TabIndex = 21;
            this.numericTemperatureThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericTemperatureThreshold.ValueChanged += new System.EventHandler(this.numericTemperatureThreshold_ValueChanged);
            // 
            // numericWateringThreshold
            // 
            this.numericWateringThreshold.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericWateringThreshold.Font = new System.Drawing.Font("Lato", 16.2F, System.Drawing.FontStyle.Bold);
            this.numericWateringThreshold.Location = new System.Drawing.Point(364, 13);
            this.numericWateringThreshold.Name = "numericWateringThreshold";
            this.numericWateringThreshold.Size = new System.Drawing.Size(106, 40);
            this.numericWateringThreshold.TabIndex = 22;
            this.numericWateringThreshold.Tag = "";
            this.numericWateringThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericWateringThreshold.ValueChanged += new System.EventHandler(this.numericWateringThreshold_ValueChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Lato", 16.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(476, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 66);
            this.label3.TabIndex = 24;
            this.label3.Text = "%";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(131)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(542, 198);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Settings";
            this.Text = "Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLightsThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTemperatureThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWateringThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericTemperatureThreshold;
        private System.Windows.Forms.NumericUpDown numericWateringThreshold;
        private System.Windows.Forms.NumericUpDown numericLightsThreshold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}