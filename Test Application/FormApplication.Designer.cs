namespace Test_Application
{
    partial class FormApplication
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
            this.btnCreateApplication = new System.Windows.Forms.Button();
            this.lblApplication = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnContainers = new System.Windows.Forms.Button();
            this.txtBoxCreateApp = new System.Windows.Forms.TextBox();
            this.lblAppName = new System.Windows.Forms.Label();
            this.txtBoxUpdateApp = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblCreationDate = new System.Windows.Forms.Label();
            this.lblAppID = new System.Windows.Forms.Label();
            this.lblCreationAppDAte = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateApplication
            // 
            this.btnCreateApplication.Location = new System.Drawing.Point(18, 85);
            this.btnCreateApplication.Name = "btnCreateApplication";
            this.btnCreateApplication.Size = new System.Drawing.Size(221, 25);
            this.btnCreateApplication.TabIndex = 0;
            this.btnCreateApplication.Text = "Create";
            this.btnCreateApplication.UseVisualStyleBackColor = true;
            this.btnCreateApplication.Click += new System.EventHandler(this.btnCreateApplication_Click);
            // 
            // lblApplication
            // 
            this.lblApplication.AutoSize = true;
            this.lblApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplication.Location = new System.Drawing.Point(33, 39);
            this.lblApplication.Name = "lblApplication";
            this.lblApplication.Size = new System.Drawing.Size(232, 42);
            this.lblApplication.TabIndex = 1;
            this.lblApplication.Text = "Applications";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(40, 148);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(283, 212);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(40, 97);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 31);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(423, 361);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 30);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete Application";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(356, 285);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(268, 30);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update Application Name";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnContainers
            // 
            this.btnContainers.Location = new System.Drawing.Point(84, 368);
            this.btnContainers.Name = "btnContainers";
            this.btnContainers.Size = new System.Drawing.Size(191, 23);
            this.btnContainers.TabIndex = 6;
            this.btnContainers.Text = "Check Application Containers";
            this.btnContainers.UseVisualStyleBackColor = true;
            this.btnContainers.Visible = false;
            this.btnContainers.Click += new System.EventHandler(this.btnContainers_Click);
            // 
            // txtBoxCreateApp
            // 
            this.txtBoxCreateApp.Location = new System.Drawing.Point(18, 62);
            this.txtBoxCreateApp.Name = "txtBoxCreateApp";
            this.txtBoxCreateApp.Size = new System.Drawing.Size(221, 20);
            this.txtBoxCreateApp.TabIndex = 7;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.Location = new System.Drawing.Point(351, 148);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(70, 25);
            this.lblAppName.TabIndex = 10;
            this.lblAppName.Text = "label2";
            this.lblAppName.Visible = false;
            // 
            // txtBoxUpdateApp
            // 
            this.txtBoxUpdateApp.Location = new System.Drawing.Point(356, 259);
            this.txtBoxUpdateApp.Name = "txtBoxUpdateApp";
            this.txtBoxUpdateApp.Size = new System.Drawing.Size(268, 20);
            this.txtBoxUpdateApp.TabIndex = 12;
            this.txtBoxUpdateApp.Visible = false;
            this.txtBoxUpdateApp.WordWrap = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblInfo.Location = new System.Drawing.Point(37, 131);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(193, 14);
            this.lblInfo.TabIndex = 13;
            this.lblInfo.Text = "Click in any app to perform any action";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Create Application";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBoxCreateApp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCreateApplication);
            this.groupBox1.Location = new System.Drawing.Point(385, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 116);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Insert the app name";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(353, 186);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(24, 13);
            this.lblID.TabIndex = 16;
            this.lblID.Text = "ID:";
            this.lblID.Visible = false;
            // 
            // lblCreationDate
            // 
            this.lblCreationDate.AutoSize = true;
            this.lblCreationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreationDate.Location = new System.Drawing.Point(353, 212);
            this.lblCreationDate.Name = "lblCreationDate";
            this.lblCreationDate.Size = new System.Drawing.Size(89, 13);
            this.lblCreationDate.TabIndex = 17;
            this.lblCreationDate.Text = "Creation Date:";
            this.lblCreationDate.Visible = false;
            // 
            // lblAppID
            // 
            this.lblAppID.AutoSize = true;
            this.lblAppID.Location = new System.Drawing.Point(500, 186);
            this.lblAppID.Name = "lblAppID";
            this.lblAppID.Size = new System.Drawing.Size(35, 13);
            this.lblAppID.TabIndex = 18;
            this.lblAppID.Text = "label3";
            this.lblAppID.Visible = false;
            // 
            // lblCreationAppDAte
            // 
            this.lblCreationAppDAte.AutoSize = true;
            this.lblCreationAppDAte.Location = new System.Drawing.Point(500, 212);
            this.lblCreationAppDAte.Name = "lblCreationAppDAte";
            this.lblCreationAppDAte.Size = new System.Drawing.Size(35, 13);
            this.lblCreationAppDAte.TabIndex = 19;
            this.lblCreationAppDAte.Text = "label4";
            this.lblCreationAppDAte.Visible = false;
            // 
            // FormApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 406);
            this.Controls.Add(this.lblCreationAppDAte);
            this.Controls.Add(this.lblAppID);
            this.Controls.Add(this.lblCreationDate);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtBoxUpdateApp);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.btnContainers);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblApplication);
            this.Name = "FormApplication";
            this.Text = "Application";
            this.Load += new System.EventHandler(this.FormApplication_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateApplication;
        private System.Windows.Forms.Label lblApplication;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnContainers;
        private System.Windows.Forms.TextBox txtBoxCreateApp;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.TextBox txtBoxUpdateApp;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblCreationDate;
        private System.Windows.Forms.Label lblAppID;
        private System.Windows.Forms.Label lblCreationAppDAte;
    }
}