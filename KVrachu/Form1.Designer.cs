namespace KVrachu
{
    partial class MainForm
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
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.lbBusy = new System.Windows.Forms.ListBox();
            this.lbRest = new System.Windows.Forms.ListBox();
            this.cmbDocTypes = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cmbDocsForType = new System.Windows.Forms.ComboBox();
            this.btnSelectType = new System.Windows.Forms.Button();
            this.btnSelectDoctor = new System.Windows.Forms.Button();
            this.txtDocDesc = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtDocId = new System.Windows.Forms.TextBox();
            this.btnCheckInfinit = new System.Windows.Forms.Button();
            this.numBestTime = new System.Windows.Forms.NumericUpDown();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtHospId = new System.Windows.Forms.TextBox();
            this.txtHostUnitId = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblHospCode = new System.Windows.Forms.Label();
            this.lblDoc = new System.Windows.Forms.Label();
            this.lblUsefullHour = new System.Windows.Forms.Label();
            this.lblDocCode = new System.Windows.Forms.Label();
            this.lblDocDesc = new System.Windows.Forms.Label();
            this.lblBusy = new System.Windows.Forms.Label();
            this.lblRest = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numBestTime)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(12, 288);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(488, 51);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(28, 22);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 1;
            this.btnInit.Text = "Запустить";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // lbBusy
            // 
            this.lbBusy.ForeColor = System.Drawing.Color.Red;
            this.lbBusy.FormattingEnabled = true;
            this.lbBusy.Location = new System.Drawing.Point(12, 174);
            this.lbBusy.Name = "lbBusy";
            this.lbBusy.Size = new System.Drawing.Size(180, 108);
            this.lbBusy.TabIndex = 5;
            // 
            // lbRest
            // 
            this.lbRest.ForeColor = System.Drawing.Color.Green;
            this.lbRest.FormattingEnabled = true;
            this.lbRest.Location = new System.Drawing.Point(194, 174);
            this.lbRest.Name = "lbRest";
            this.lbRest.Size = new System.Drawing.Size(180, 108);
            this.lbRest.TabIndex = 6;
            // 
            // cmbDocTypes
            // 
            this.cmbDocTypes.FormattingEnabled = true;
            this.cmbDocTypes.Location = new System.Drawing.Point(12, 54);
            this.cmbDocTypes.Name = "cmbDocTypes";
            this.cmbDocTypes.Size = new System.Drawing.Size(177, 21);
            this.cmbDocTypes.TabIndex = 9;
            this.cmbDocTypes.SelectedIndexChanged += new System.EventHandler(this.cmbDocTypes_SelectedIndexChanged);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(195, 54);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(137, 20);
            this.txtId.TabIndex = 11;
            // 
            // cmbDocsForType
            // 
            this.cmbDocsForType.FormattingEnabled = true;
            this.cmbDocsForType.Location = new System.Drawing.Point(12, 99);
            this.cmbDocsForType.Name = "cmbDocsForType";
            this.cmbDocsForType.Size = new System.Drawing.Size(215, 21);
            this.cmbDocsForType.TabIndex = 12;
            this.cmbDocsForType.SelectedIndexChanged += new System.EventHandler(this.cmbDocsForType_SelectedIndexChanged);
            // 
            // btnSelectType
            // 
            this.btnSelectType.Location = new System.Drawing.Point(338, 52);
            this.btnSelectType.Name = "btnSelectType";
            this.btnSelectType.Size = new System.Drawing.Size(162, 23);
            this.btnSelectType.TabIndex = 13;
            this.btnSelectType.Text = "Выбрать эту специальность";
            this.btnSelectType.UseVisualStyleBackColor = true;
            this.btnSelectType.Click += new System.EventHandler(this.btnSelectType_Click);
            // 
            // btnSelectDoctor
            // 
            this.btnSelectDoctor.Location = new System.Drawing.Point(233, 98);
            this.btnSelectDoctor.Name = "btnSelectDoctor";
            this.btnSelectDoctor.Size = new System.Drawing.Size(110, 23);
            this.btnSelectDoctor.TabIndex = 14;
            this.btnSelectDoctor.Text = "Выбрать этого";
            this.btnSelectDoctor.UseVisualStyleBackColor = true;
            this.btnSelectDoctor.Click += new System.EventHandler(this.btnSelectDoctor_Click);
            // 
            // txtDocDesc
            // 
            this.txtDocDesc.Location = new System.Drawing.Point(99, 137);
            this.txtDocDesc.Name = "txtDocDesc";
            this.txtDocDesc.Size = new System.Drawing.Size(275, 20);
            this.txtDocDesc.TabIndex = 15;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(387, 200);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 43);
            this.btnRegister.TabIndex = 16;
            this.btnRegister.Text = "Записать на выбранное";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtDocId
            // 
            this.txtDocId.Location = new System.Drawing.Point(12, 137);
            this.txtDocId.Name = "txtDocId";
            this.txtDocId.Size = new System.Drawing.Size(80, 20);
            this.txtDocId.TabIndex = 17;
            // 
            // btnCheckInfinit
            // 
            this.btnCheckInfinit.Location = new System.Drawing.Point(387, 122);
            this.btnCheckInfinit.Name = "btnCheckInfinit";
            this.btnCheckInfinit.Size = new System.Drawing.Size(113, 49);
            this.btnCheckInfinit.TabIndex = 18;
            this.btnCheckInfinit.Text = "Пытаться записаться до удачи";
            this.btnCheckInfinit.UseVisualStyleBackColor = true;
            this.btnCheckInfinit.Click += new System.EventHandler(this.btnCheckInfinit_Click);
            // 
            // numBestTime
            // 
            this.numBestTime.Location = new System.Drawing.Point(395, 99);
            this.numBestTime.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numBestTime.Name = "numBestTime";
            this.numBestTime.Size = new System.Drawing.Size(83, 20);
            this.numBestTime.TabIndex = 20;
            this.numBestTime.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(124, 24);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(80, 20);
            this.txtLogin.TabIndex = 21;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(210, 24);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(80, 20);
            this.txtPass.TabIndex = 22;
            // 
            // txtHospId
            // 
            this.txtHospId.Location = new System.Drawing.Point(296, 24);
            this.txtHospId.Name = "txtHospId";
            this.txtHospId.Size = new System.Drawing.Size(80, 20);
            this.txtHospId.TabIndex = 23;
            // 
            // txtHostUnitId
            // 
            this.txtHostUnitId.Location = new System.Drawing.Point(382, 24);
            this.txtHostUnitId.Name = "txtHostUnitId";
            this.txtHostUnitId.Size = new System.Drawing.Size(80, 20);
            this.txtHostUnitId.TabIndex = 24;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(147, 9);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(33, 13);
            this.lblLogin.TabIndex = 25;
            this.lblLogin.Text = "Login";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(227, 9);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 26;
            this.lblPassword.Text = "Password";
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(301, 8);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(70, 13);
            this.lblRegion.TabIndex = 27;
            this.lblRegion.Text = "Код региона";
            // 
            // lblHospCode
            // 
            this.lblHospCode.AutoSize = true;
            this.lblHospCode.Location = new System.Drawing.Point(386, 9);
            this.lblHospCode.Name = "lblHospCode";
            this.lblHospCode.Size = new System.Drawing.Size(68, 13);
            this.lblHospCode.TabIndex = 28;
            this.lblHospCode.Text = "Код поликл.";
            // 
            // lblDoc
            // 
            this.lblDoc.AutoSize = true;
            this.lblDoc.Location = new System.Drawing.Point(106, 83);
            this.lblDoc.Name = "lblDoc";
            this.lblDoc.Size = new System.Drawing.Size(31, 13);
            this.lblDoc.TabIndex = 29;
            this.lblDoc.Text = "Врач";
            // 
            // lblUsefullHour
            // 
            this.lblUsefullHour.AutoSize = true;
            this.lblUsefullHour.Location = new System.Drawing.Point(380, 83);
            this.lblUsefullHour.Name = "lblUsefullHour";
            this.lblUsefullHour.Size = new System.Drawing.Size(123, 13);
            this.lblUsefullHour.TabIndex = 30;
            this.lblUsefullHour.Text = "Наиболее удобный час";
            // 
            // lblDocCode
            // 
            this.lblDocCode.AutoSize = true;
            this.lblDocCode.Location = new System.Drawing.Point(25, 123);
            this.lblDocCode.Name = "lblDocCode";
            this.lblDocCode.Size = new System.Drawing.Size(58, 13);
            this.lblDocCode.TabIndex = 31;
            this.lblDocCode.Text = "Код врача";
            // 
            // lblDocDesc
            // 
            this.lblDocDesc.AutoSize = true;
            this.lblDocDesc.Location = new System.Drawing.Point(207, 124);
            this.lblDocDesc.Name = "lblDocDesc";
            this.lblDocDesc.Size = new System.Drawing.Size(57, 13);
            this.lblDocDesc.TabIndex = 32;
            this.lblDocDesc.Text = "Описание";
            // 
            // lblBusy
            // 
            this.lblBusy.AutoSize = true;
            this.lblBusy.Location = new System.Drawing.Point(79, 160);
            this.lblBusy.Name = "lblBusy";
            this.lblBusy.Size = new System.Drawing.Size(43, 13);
            this.lblBusy.TabIndex = 33;
            this.lblBusy.Text = "Занято";
            // 
            // lblRest
            // 
            this.lblRest.AutoSize = true;
            this.lblRest.Location = new System.Drawing.Point(258, 160);
            this.lblRest.Name = "lblRest";
            this.lblRest.Size = new System.Drawing.Size(56, 13);
            this.lblRest.TabIndex = 34;
            this.lblRest.Text = "Свободно";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 343);
            this.Controls.Add(this.lblRest);
            this.Controls.Add(this.lblBusy);
            this.Controls.Add(this.lblDocDesc);
            this.Controls.Add(this.lblDocCode);
            this.Controls.Add(this.lblUsefullHour);
            this.Controls.Add(this.lblDoc);
            this.Controls.Add(this.lblHospCode);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtHostUnitId);
            this.Controls.Add(this.txtHospId);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.numBestTime);
            this.Controls.Add(this.btnCheckInfinit);
            this.Controls.Add(this.txtDocId);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtDocDesc);
            this.Controls.Add(this.btnSelectDoctor);
            this.Controls.Add(this.btnSelectType);
            this.Controls.Add(this.cmbDocsForType);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.cmbDocTypes);
            this.Controls.Add(this.lbRest);
            this.Controls.Add(this.lbBusy);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.rtbLog);
            this.Name = "MainForm";
            this.Text = "Запись";
            ((System.ComponentModel.ISupportInitialize)(this.numBestTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.ListBox lbBusy;
        private System.Windows.Forms.ListBox lbRest;
        private System.Windows.Forms.ComboBox cmbDocTypes;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cmbDocsForType;
        private System.Windows.Forms.Button btnSelectType;
        private System.Windows.Forms.Button btnSelectDoctor;
        private System.Windows.Forms.TextBox txtDocDesc;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtDocId;
        private System.Windows.Forms.Button btnCheckInfinit;
        private System.Windows.Forms.NumericUpDown numBestTime;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtHospId;
        private System.Windows.Forms.TextBox txtHostUnitId;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label lblHospCode;
        private System.Windows.Forms.Label lblDoc;
        private System.Windows.Forms.Label lblUsefullHour;
        private System.Windows.Forms.Label lblDocCode;
        private System.Windows.Forms.Label lblDocDesc;
        private System.Windows.Forms.Label lblBusy;
        private System.Windows.Forms.Label lblRest;
    }
}

