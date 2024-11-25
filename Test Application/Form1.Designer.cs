namespace Test_Application {
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
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.comboBoxMethodValue = new System.Windows.Forms.ComboBox();
            this.textBoxLocalHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxBody = new System.Windows.Forms.RichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxStatusCode = new System.Windows.Forms.TextBox();
            this.richTextBoxResponseBody = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxHeaderValue = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxIncludeHeader = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBodyType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxUrl.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUrl.Location = new System.Drawing.Point(163, 73);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(823, 40);
            this.textBoxUrl.TabIndex = 0;
            this.textBoxUrl.Text = "/api/somiod";
            // 
            // comboBoxMethodValue
            // 
            this.comboBoxMethodValue.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboBoxMethodValue.Font = new System.Drawing.Font("Yu Gothic", 14.8F);
            this.comboBoxMethodValue.FormattingEnabled = true;
            this.comboBoxMethodValue.Location = new System.Drawing.Point(12, 72);
            this.comboBoxMethodValue.Name = "comboBoxMethodValue";
            this.comboBoxMethodValue.Size = new System.Drawing.Size(139, 41);
            this.comboBoxMethodValue.TabIndex = 1;
            this.comboBoxMethodValue.Text = "Method";
            // 
            // textBoxLocalHost
            // 
            this.textBoxLocalHost.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxLocalHost.Font = new System.Drawing.Font("Yu Gothic", 10F);
            this.textBoxLocalHost.Location = new System.Drawing.Point(368, 23);
            this.textBoxLocalHost.MaxLength = 5;
            this.textBoxLocalHost.Name = "textBoxLocalHost";
            this.textBoxLocalHost.Size = new System.Drawing.Size(115, 34);
            this.textBoxLocalHost.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Body Type:";
            // 
            // richTextBoxBody
            // 
            this.richTextBoxBody.Font = new System.Drawing.Font("Yu Gothic", 10F);
            this.richTextBoxBody.Location = new System.Drawing.Point(18, 251);
            this.richTextBoxBody.Name = "richTextBoxBody";
            this.richTextBoxBody.Size = new System.Drawing.Size(366, 221);
            this.richTextBoxBody.TabIndex = 5;
            this.richTextBoxBody.Text = "";
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Yu Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.Location = new System.Drawing.Point(412, 251);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(139, 51);
            this.buttonSend.TabIndex = 6;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.sendRequestClick);
            // 
            // textBoxStatusCode
            // 
            this.textBoxStatusCode.Location = new System.Drawing.Point(734, 222);
            this.textBoxStatusCode.Name = "textBoxStatusCode";
            this.textBoxStatusCode.ReadOnly = true;
            this.textBoxStatusCode.Size = new System.Drawing.Size(114, 22);
            this.textBoxStatusCode.TabIndex = 8;
            // 
            // richTextBoxResponseBody
            // 
            this.richTextBoxResponseBody.Font = new System.Drawing.Font("Yu Gothic", 10F);
            this.richTextBoxResponseBody.Location = new System.Drawing.Point(575, 251);
            this.richTextBoxResponseBody.Name = "richTextBoxResponseBody";
            this.richTextBoxResponseBody.ReadOnly = true;
            this.richTextBoxResponseBody.Size = new System.Drawing.Size(411, 221);
            this.richTextBoxResponseBody.TabIndex = 9;
            this.richTextBoxResponseBody.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(570, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Status Code:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(570, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "Response Body:";
            // 
            // comboBoxHeaderValue
            // 
            this.comboBoxHeaderValue.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboBoxHeaderValue.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxHeaderValue.FormattingEnabled = true;
            this.comboBoxHeaderValue.Location = new System.Drawing.Point(389, 136);
            this.comboBoxHeaderValue.Name = "comboBoxHeaderValue";
            this.comboBoxHeaderValue.Size = new System.Drawing.Size(162, 34);
            this.comboBoxHeaderValue.TabIndex = 12;
            this.comboBoxHeaderValue.Text = "Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(312, 48);
            this.label6.TabIndex = 13;
            this.label6.Text = "Test Application";
            // 
            // checkBoxIncludeHeader
            // 
            this.checkBoxIncludeHeader.AutoSize = true;
            this.checkBoxIncludeHeader.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkBoxIncludeHeader.Font = new System.Drawing.Font("Yu Gothic", 12F);
            this.checkBoxIncludeHeader.Location = new System.Drawing.Point(12, 136);
            this.checkBoxIncludeHeader.Name = "checkBoxIncludeHeader";
            this.checkBoxIncludeHeader.Size = new System.Drawing.Size(330, 30);
            this.checkBoxIncludeHeader.TabIndex = 16;
            this.checkBoxIncludeHeader.Text = "Include header \"somiod-locate:\"";
            this.checkBoxIncludeHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxIncludeHeader.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(503, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Local IIS Port";
            // 
            // comboBoxBodyType
            // 
            this.comboBoxBodyType.Font = new System.Drawing.Font("Yu Gothic", 12F);
            this.comboBoxBodyType.FormattingEnabled = true;
            this.comboBoxBodyType.Location = new System.Drawing.Point(151, 201);
            this.comboBoxBodyType.Name = "comboBoxBodyType";
            this.comboBoxBodyType.Size = new System.Drawing.Size(147, 34);
            this.comboBoxBodyType.TabIndex = 17;
            this.comboBoxBodyType.SelectedIndexChanged += new System.EventHandler(this.comboBoxBodyType_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 490);
            this.Controls.Add(this.comboBoxBodyType);
            this.Controls.Add(this.checkBoxIncludeHeader);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxHeaderValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBoxResponseBody);
            this.Controls.Add(this.textBoxStatusCode);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.richTextBoxBody);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLocalHost);
            this.Controls.Add(this.comboBoxMethodValue);
            this.Controls.Add(this.textBoxUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.ComboBox comboBoxMethodValue;
        private System.Windows.Forms.TextBox textBoxLocalHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxBody;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxStatusCode;
        private System.Windows.Forms.RichTextBox richTextBoxResponseBody;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxHeaderValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxIncludeHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBodyType;
    }
}

