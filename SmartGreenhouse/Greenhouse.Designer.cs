namespace SmartGreenhouse {
    partial class Greenhouse {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Greenhouse));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lightsLabel = new System.Windows.Forms.Label();
            this.temperatureLabel = new System.Windows.Forms.Label();
            this.humidityLabel = new System.Windows.Forms.Label();
            this.btnHistoryLight = new System.Windows.Forms.Button();
            this.btnHistoryTemperature = new System.Windows.Forms.Button();
            this.btnHistoryHumidity = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxLights = new System.Windows.Forms.PictureBox();
            this.pictureBoxTemperature = new System.Windows.Forms.PictureBox();
            this.pictureBoxHumidity = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMountApplication = new System.Windows.Forms.Button();
            this.labelApplicationName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHumidity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(62)))), ((int)(((byte)(69)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 300);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.lightsLabel, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.temperatureLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.humidityLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnHistoryLight, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnHistoryTemperature, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnHistoryHumidity, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxLights, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxTemperature, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxHumidity, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(816, 300);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lightsLabel
            // 
            this.lightsLabel.AutoSize = true;
            this.lightsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightsLabel.Font = new System.Drawing.Font("Lato", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lightsLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lightsLabel.Location = new System.Drawing.Point(547, 195);
            this.lightsLabel.Name = "lightsLabel";
            this.lightsLabel.Size = new System.Drawing.Size(266, 45);
            this.lightsLabel.TabIndex = 24;
            this.lightsLabel.Text = "Latest Value: ———lux";
            this.lightsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // temperatureLabel
            // 
            this.temperatureLabel.AutoSize = true;
            this.temperatureLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.temperatureLabel.Font = new System.Drawing.Font("Lato", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperatureLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.temperatureLabel.Location = new System.Drawing.Point(275, 195);
            this.temperatureLabel.Name = "temperatureLabel";
            this.temperatureLabel.Size = new System.Drawing.Size(266, 45);
            this.temperatureLabel.TabIndex = 23;
            this.temperatureLabel.Text = "Latest Value: ——ºC";
            this.temperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // humidityLabel
            // 
            this.humidityLabel.AutoSize = true;
            this.humidityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.humidityLabel.Font = new System.Drawing.Font("Lato", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.humidityLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.humidityLabel.Location = new System.Drawing.Point(3, 195);
            this.humidityLabel.Name = "humidityLabel";
            this.humidityLabel.Size = new System.Drawing.Size(266, 45);
            this.humidityLabel.TabIndex = 22;
            this.humidityLabel.Text = "Latest Value: ——%";
            this.humidityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHistoryLight
            // 
            this.btnHistoryLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHistoryLight.Font = new System.Drawing.Font("Lato", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoryLight.Location = new System.Drawing.Point(547, 243);
            this.btnHistoryLight.Name = "btnHistoryLight";
            this.btnHistoryLight.Size = new System.Drawing.Size(266, 54);
            this.btnHistoryLight.TabIndex = 21;
            this.btnHistoryLight.Text = "Light History";
            this.btnHistoryLight.UseVisualStyleBackColor = true;
            this.btnHistoryLight.Click += new System.EventHandler(this.btnHistoryLight_Click);
            // 
            // btnHistoryTemperature
            // 
            this.btnHistoryTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHistoryTemperature.Font = new System.Drawing.Font("Lato", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoryTemperature.Location = new System.Drawing.Point(275, 243);
            this.btnHistoryTemperature.Name = "btnHistoryTemperature";
            this.btnHistoryTemperature.Size = new System.Drawing.Size(266, 54);
            this.btnHistoryTemperature.TabIndex = 20;
            this.btnHistoryTemperature.Text = "Temperature History";
            this.btnHistoryTemperature.UseVisualStyleBackColor = true;
            this.btnHistoryTemperature.Click += new System.EventHandler(this.btnHistoryTemperature_Click);
            // 
            // btnHistoryHumidity
            // 
            this.btnHistoryHumidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHistoryHumidity.Font = new System.Drawing.Font("Lato", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoryHumidity.Location = new System.Drawing.Point(3, 243);
            this.btnHistoryHumidity.Name = "btnHistoryHumidity";
            this.btnHistoryHumidity.Size = new System.Drawing.Size(266, 54);
            this.btnHistoryHumidity.TabIndex = 19;
            this.btnHistoryHumidity.Text = "Humidity History";
            this.btnHistoryHumidity.UseVisualStyleBackColor = true;
            this.btnHistoryHumidity.Click += new System.EventHandler(this.btnHistoryHumidity_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Lato", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(547, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 60);
            this.label4.TabIndex = 18;
            this.label4.Text = "Lights";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Lato", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(275, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 60);
            this.label3.TabIndex = 17;
            this.label3.Text = "Air Conditioning";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLights
            // 
            this.pictureBoxLights.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxLights.Image = global::SmartGreenhouse.Properties.Resources.off;
            this.pictureBoxLights.Location = new System.Drawing.Point(547, 153);
            this.pictureBoxLights.Name = "pictureBoxLights";
            this.pictureBoxLights.Size = new System.Drawing.Size(266, 39);
            this.pictureBoxLights.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLights.TabIndex = 15;
            this.pictureBoxLights.TabStop = false;
            // 
            // pictureBoxTemperature
            // 
            this.pictureBoxTemperature.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxTemperature.Image = global::SmartGreenhouse.Properties.Resources.off;
            this.pictureBoxTemperature.Location = new System.Drawing.Point(275, 153);
            this.pictureBoxTemperature.Name = "pictureBoxTemperature";
            this.pictureBoxTemperature.Size = new System.Drawing.Size(266, 39);
            this.pictureBoxTemperature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTemperature.TabIndex = 14;
            this.pictureBoxTemperature.TabStop = false;
            // 
            // pictureBoxHumidity
            // 
            this.pictureBoxHumidity.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxHumidity.Image = global::SmartGreenhouse.Properties.Resources.off;
            this.pictureBoxHumidity.Location = new System.Drawing.Point(3, 153);
            this.pictureBoxHumidity.Name = "pictureBoxHumidity";
            this.pictureBoxHumidity.Size = new System.Drawing.Size(266, 39);
            this.pictureBoxHumidity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxHumidity.TabIndex = 13;
            this.pictureBoxHumidity.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox4.Image = global::SmartGreenhouse.Properties.Resources.light;
            this.pictureBox4.Location = new System.Drawing.Point(547, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(266, 84);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox3.Image = global::SmartGreenhouse.Properties.Resources.windy;
            this.pictureBox3.Location = new System.Drawing.Point(275, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(266, 84);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = global::SmartGreenhouse.Properties.Resources.plant;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(266, 84);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Lato", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 60);
            this.label2.TabIndex = 16;
            this.label2.Text = "Watering";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Lato", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dateLabel.Location = new System.Drawing.Point(176, 121);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(575, 45);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "Thursday, 13th of December 2024";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SmartGreenhouse.Properties.Resources.greenhouse;
            this.pictureBox1.Location = new System.Drawing.Point(11, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = global::SmartGreenhouse.Properties.Resources.setting;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSettings.Location = new System.Drawing.Point(738, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(66, 61);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.settings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lato", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(178, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Application Name:";
            // 
            // btnMountApplication
            // 
            this.btnMountApplication.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMountApplication.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMountApplication.Location = new System.Drawing.Point(12, 9);
            this.btnMountApplication.Name = "btnMountApplication";
            this.btnMountApplication.Size = new System.Drawing.Size(158, 44);
            this.btnMountApplication.TabIndex = 6;
            this.btnMountApplication.Text = "Mount";
            this.btnMountApplication.UseVisualStyleBackColor = true;
            this.btnMountApplication.Click += new System.EventHandler(this.btnMountApplication_Click);
            // 
            // labelApplicationName
            // 
            this.labelApplicationName.AutoSize = true;
            this.labelApplicationName.Font = new System.Drawing.Font("Lato", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApplicationName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.labelApplicationName.Location = new System.Drawing.Point(176, 76);
            this.labelApplicationName.Name = "labelApplicationName";
            this.labelApplicationName.Size = new System.Drawing.Size(573, 45);
            this.labelApplicationName.TabIndex = 7;
            this.labelApplicationName.Text = "Please Mount the application first";
            // 
            // Greenhouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(131)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(816, 472);
            this.Controls.Add(this.labelApplicationName);
            this.Controls.Add(this.btnMountApplication);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Greenhouse";
            this.Text = "Greenhouse";
            this.Load += new System.EventHandler(this.Greenhouse_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHumidity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxLights;
        private System.Windows.Forms.PictureBox pictureBoxTemperature;
        private System.Windows.Forms.PictureBox pictureBoxHumidity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHistoryLight;
        private System.Windows.Forms.Button btnHistoryTemperature;
        private System.Windows.Forms.Button btnHistoryHumidity;
        private System.Windows.Forms.Label lightsLabel;
        private System.Windows.Forms.Label temperatureLabel;
        private System.Windows.Forms.Label humidityLabel;
        private System.Windows.Forms.Button btnMountApplication;
        private System.Windows.Forms.Label labelApplicationName;
    }
}

