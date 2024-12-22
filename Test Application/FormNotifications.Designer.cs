namespace Test_Application
{
    partial class FormNotifications
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbEventType = new System.Windows.Forms.ComboBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtEndpoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxCreate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblContainerName = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblEnableFill = new System.Windows.Forms.Label();
            this.lblEndpointFill = new System.Windows.Forms.Label();
            this.lblEnable = new System.Windows.Forms.Label();
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.lblEventFill = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblCreationDateFill = new System.Windows.Forms.Label();
            this.lblIdFill = new System.Windows.Forms.Label();
            this.lblCreationDate = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbEventType);
            this.groupBox1.Controls.Add(this.chkEnabled);
            this.groupBox1.Controls.Add(this.txtEndpoint);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBoxCreate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Location = new System.Drawing.Point(363, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 213);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // cmbEventType
            // 
            this.cmbEventType.FormattingEnabled = true;
            this.cmbEventType.Location = new System.Drawing.Point(88, 88);
            this.cmbEventType.Name = "cmbEventType";
            this.cmbEventType.Size = new System.Drawing.Size(106, 21);
            this.cmbEventType.TabIndex = 24;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(32, 144);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 23;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtEndpoint
            // 
            this.txtEndpoint.Location = new System.Drawing.Point(88, 116);
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.Size = new System.Drawing.Size(106, 20);
            this.txtEndpoint.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Endpoint:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Event:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(25, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Insert all the filds to add a notification";
            // 
            // txtBoxCreate
            // 
            this.txtBoxCreate.Location = new System.Drawing.Point(88, 62);
            this.txtBoxCreate.Name = "txtBoxCreate";
            this.txtBoxCreate.Size = new System.Drawing.Size(106, 20);
            this.txtBoxCreate.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Add Notification";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(28, 167);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(221, 25);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(30, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(204, 31);
            this.lblTitle.TabIndex = 28;
            this.lblTitle.Text = "Notification of:";
            // 
            // lblContainerName
            // 
            this.lblContainerName.AutoSize = true;
            this.lblContainerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContainerName.Location = new System.Drawing.Point(30, 70);
            this.lblContainerName.Name = "lblContainerName";
            this.lblContainerName.Size = new System.Drawing.Size(211, 31);
            this.lblContainerName.TabIndex = 29;
            this.lblContainerName.Text = "containerName";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(22, 124);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(250, 290);
            this.listBox1.TabIndex = 30;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblEnableFill);
            this.groupBox2.Controls.Add(this.lblEndpointFill);
            this.groupBox2.Controls.Add(this.lblEnable);
            this.groupBox2.Controls.Add(this.lblEndpoint);
            this.groupBox2.Controls.Add(this.lblEvent);
            this.groupBox2.Controls.Add(this.lblEventFill);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.lblCreationDateFill);
            this.groupBox2.Controls.Add(this.lblIdFill);
            this.groupBox2.Controls.Add(this.lblCreationDate);
            this.groupBox2.Controls.Add(this.lblID);
            this.groupBox2.Controls.Add(this.lblName);
            this.groupBox2.Location = new System.Drawing.Point(363, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 202);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // lblEnableFill
            // 
            this.lblEnableFill.AutoSize = true;
            this.lblEnableFill.Location = new System.Drawing.Point(145, 149);
            this.lblEnableFill.Name = "lblEnableFill";
            this.lblEnableFill.Size = new System.Drawing.Size(35, 13);
            this.lblEnableFill.TabIndex = 33;
            this.lblEnableFill.Text = "label3";
            // 
            // lblEndpointFill
            // 
            this.lblEndpointFill.AutoSize = true;
            this.lblEndpointFill.Location = new System.Drawing.Point(145, 127);
            this.lblEndpointFill.Name = "lblEndpointFill";
            this.lblEndpointFill.Size = new System.Drawing.Size(35, 13);
            this.lblEndpointFill.TabIndex = 32;
            this.lblEndpointFill.Text = "label3";
            // 
            // lblEnable
            // 
            this.lblEnable.AutoSize = true;
            this.lblEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnable.Location = new System.Drawing.Point(8, 149);
            this.lblEnable.Name = "lblEnable";
            this.lblEnable.Size = new System.Drawing.Size(57, 13);
            this.lblEnable.TabIndex = 31;
            this.lblEnable.Text = "Enabled:";
            // 
            // lblEndpoint
            // 
            this.lblEndpoint.AutoSize = true;
            this.lblEndpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndpoint.Location = new System.Drawing.Point(8, 127);
            this.lblEndpoint.Name = "lblEndpoint";
            this.lblEndpoint.Size = new System.Drawing.Size(61, 13);
            this.lblEndpoint.TabIndex = 30;
            this.lblEndpoint.Text = "Endpoint:";
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(6, 103);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(55, 13);
            this.lblEvent.TabIndex = 29;
            this.lblEvent.Text = "Content:";
            // 
            // lblEventFill
            // 
            this.lblEventFill.AutoSize = true;
            this.lblEventFill.Location = new System.Drawing.Point(145, 103);
            this.lblEventFill.Name = "lblEventFill";
            this.lblEventFill.Size = new System.Drawing.Size(35, 13);
            this.lblEventFill.TabIndex = 28;
            this.lblEventFill.Text = "label3";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(6, 173);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(309, 23);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblCreationDateFill
            // 
            this.lblCreationDateFill.AutoSize = true;
            this.lblCreationDateFill.Location = new System.Drawing.Point(145, 79);
            this.lblCreationDateFill.Name = "lblCreationDateFill";
            this.lblCreationDateFill.Size = new System.Drawing.Size(35, 13);
            this.lblCreationDateFill.TabIndex = 20;
            this.lblCreationDateFill.Text = "label4";
            // 
            // lblIdFill
            // 
            this.lblIdFill.AutoSize = true;
            this.lblIdFill.Location = new System.Drawing.Point(145, 55);
            this.lblIdFill.Name = "lblIdFill";
            this.lblIdFill.Size = new System.Drawing.Size(35, 13);
            this.lblIdFill.TabIndex = 19;
            this.lblIdFill.Text = "label3";
            // 
            // lblCreationDate
            // 
            this.lblCreationDate.AutoSize = true;
            this.lblCreationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreationDate.Location = new System.Drawing.Point(8, 79);
            this.lblCreationDate.Name = "lblCreationDate";
            this.lblCreationDate.Size = new System.Drawing.Size(89, 13);
            this.lblCreationDate.TabIndex = 18;
            this.lblCreationDate.Text = "Creation Date:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(8, 55);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(24, 13);
            this.lblID.TabIndex = 17;
            this.lblID.Text = "ID:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(6, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 25);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "label2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(197, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 14);
            this.label6.TabIndex = 25;
            this.label6.Text = "Must start with http://";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblInfo.Location = new System.Drawing.Point(20, 101);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(229, 14);
            this.lblInfo.TabIndex = 34;
            this.lblInfo.Text = "Click in any notification to perform any action";
            // 
            // FormNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 445);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblContainerName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormNotifications";
            this.Text = "Notifications";
            this.Load += new System.EventHandler(this.FormNotifications_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblContainerName;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.Label lblEventFill;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCreationDateFill;
        private System.Windows.Forms.Label lblIdFill;
        private System.Windows.Forms.Label lblCreationDate;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEnableFill;
        private System.Windows.Forms.Label lblEndpointFill;
        private System.Windows.Forms.Label lblEnable;
        private System.Windows.Forms.Label lblEndpoint;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtEndpoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEventType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblInfo;
    }
}