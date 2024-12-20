namespace Test_Application
{
    partial class FormContainer
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
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.lblContainer = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxCreateContainer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateContainer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtBoxUpdate = new System.Windows.Forms.TextBox();
            this.lblCreationContDate = new System.Windows.Forms.Label();
            this.lblContID = new System.Windows.Forms.Label();
            this.lblCreationDate = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblContName = new System.Windows.Forms.Label();
            this.btnRecords = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnNotification = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationName.Location = new System.Drawing.Point(25, 62);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(138, 31);
            this.lblApplicationName.TabIndex = 0;
            this.lblApplicationName.Text = "appName";
            // 
            // lblContainer
            // 
            this.lblContainer.AutoSize = true;
            this.lblContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContainer.Location = new System.Drawing.Point(25, 19);
            this.lblContainer.Name = "lblContainer";
            this.lblContainer.Size = new System.Drawing.Size(228, 31);
            this.lblContainer.TabIndex = 2;
            this.lblContainer.Text = "Container(s) for:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(31, 116);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(222, 199);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBoxCreateContainer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCreateContainer);
            this.groupBox1.Location = new System.Drawing.Point(369, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 116);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Insert the container name";
            // 
            // txtBoxCreateContainer
            // 
            this.txtBoxCreateContainer.Location = new System.Drawing.Point(18, 62);
            this.txtBoxCreateContainer.Name = "txtBoxCreateContainer";
            this.txtBoxCreateContainer.Size = new System.Drawing.Size(221, 20);
            this.txtBoxCreateContainer.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Add Container";
            // 
            // btnCreateContainer
            // 
            this.btnCreateContainer.Location = new System.Drawing.Point(18, 85);
            this.btnCreateContainer.Name = "btnCreateContainer";
            this.btnCreateContainer.Size = new System.Drawing.Size(221, 25);
            this.btnCreateContainer.TabIndex = 0;
            this.btnCreateContainer.Text = "Create";
            this.btnCreateContainer.UseVisualStyleBackColor = true;
            this.btnCreateContainer.Click += new System.EventHandler(this.btnCreateContainer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.txtBoxUpdate);
            this.groupBox2.Controls.Add(this.lblCreationContDate);
            this.groupBox2.Controls.Add(this.lblContID);
            this.groupBox2.Controls.Add(this.lblCreationDate);
            this.groupBox2.Controls.Add(this.lblID);
            this.groupBox2.Controls.Add(this.lblContName);
            this.groupBox2.Location = new System.Drawing.Point(338, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 180);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(2, 138);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(268, 30);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Update Container Name";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtBoxUpdate
            // 
            this.txtBoxUpdate.Location = new System.Drawing.Point(2, 112);
            this.txtBoxUpdate.Name = "txtBoxUpdate";
            this.txtBoxUpdate.Size = new System.Drawing.Size(268, 20);
            this.txtBoxUpdate.TabIndex = 21;
            this.txtBoxUpdate.WordWrap = false;
            // 
            // lblCreationContDate
            // 
            this.lblCreationContDate.AutoSize = true;
            this.lblCreationContDate.Location = new System.Drawing.Point(145, 79);
            this.lblCreationContDate.Name = "lblCreationContDate";
            this.lblCreationContDate.Size = new System.Drawing.Size(35, 13);
            this.lblCreationContDate.TabIndex = 20;
            this.lblCreationContDate.Text = "label4";
            // 
            // lblContID
            // 
            this.lblContID.AutoSize = true;
            this.lblContID.Location = new System.Drawing.Point(145, 55);
            this.lblContID.Name = "lblContID";
            this.lblContID.Size = new System.Drawing.Size(35, 13);
            this.lblContID.TabIndex = 19;
            this.lblContID.Text = "label3";
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
            // lblContName
            // 
            this.lblContName.AutoSize = true;
            this.lblContName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContName.Location = new System.Drawing.Point(6, 16);
            this.lblContName.Name = "lblContName";
            this.lblContName.Size = new System.Drawing.Size(70, 25);
            this.lblContName.TabIndex = 11;
            this.lblContName.Text = "label2";
            // 
            // btnRecords
            // 
            this.btnRecords.Location = new System.Drawing.Point(31, 327);
            this.btnRecords.Name = "btnRecords";
            this.btnRecords.Size = new System.Drawing.Size(103, 23);
            this.btnRecords.TabIndex = 18;
            this.btnRecords.Text = "Check Records";
            this.btnRecords.UseVisualStyleBackColor = true;
            this.btnRecords.Visible = false;
            this.btnRecords.Click += new System.EventHandler(this.btnRecords_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(334, 327);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(268, 23);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete Container";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblInfo.Location = new System.Drawing.Point(28, 99);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(221, 14);
            this.lblInfo.TabIndex = 20;
            this.lblInfo.Text = "Click in any container to perform any action";
            // 
            // btnNotification
            // 
            this.btnNotification.Location = new System.Drawing.Point(140, 327);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(113, 23);
            this.btnNotification.TabIndex = 21;
            this.btnNotification.Text = "Check Notification";
            this.btnNotification.UseVisualStyleBackColor = true;
            this.btnNotification.Visible = false;
            this.btnNotification.Click += new System.EventHandler(this.btnNotification_Click);
            // 
            // FormContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 364);
            this.Controls.Add(this.btnNotification);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRecords);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblContainer);
            this.Controls.Add(this.lblApplicationName);
            this.Name = "FormContainer";
            this.Text = "Container";
            this.Load += new System.EventHandler(this.FormContainer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.Label lblContainer;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxCreateContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateContainer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblContName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblCreationDate;
        private System.Windows.Forms.Label lblContID;
        private System.Windows.Forms.Label lblCreationContDate;
        private System.Windows.Forms.TextBox txtBoxUpdate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRecords;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnNotification;
    }
}