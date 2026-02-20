namespace HospitalManagement.Pages
{
    partial class PatientInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientInformation));
            this.txtAge = new System.Windows.Forms.TextBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gBoxPatientDetails = new System.Windows.Forms.GroupBox();
            this.rtbAddress = new System.Windows.Forms.TextBox();
            this.chktin = new System.Windows.Forms.CheckBox();
            this.txttin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEmpId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtEmailId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtReferedBy = new System.Windows.Forms.TextBox();
            this.dtpRegDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox3.SuspendLayout();
            this.gBoxPatientDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(134, 102);
            this.txtAge.Margin = new System.Windows.Forms.Padding(2);
            this.txtAge.MaxLength = 3;
            this.txtAge.Multiline = true;
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(115, 23);
            this.txtAge.TabIndex = 18;
            this.txtAge.Visible = false;
            this.txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAge_KeyPress);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(194, 24);
            this.rbFemale.Margin = new System.Windows.Forms.Padding(2);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(61, 17);
            this.rbFemale.TabIndex = 16;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(136, 25);
            this.rbMale.Margin = new System.Windows.Forms.Padding(2);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(50, 17);
            this.rbMale.TabIndex = 15;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 109;
            this.label1.Text = "Age ";
            this.label1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label4.Location = new System.Drawing.Point(41, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 18);
            this.label4.TabIndex = 112;
            this.label4.Text = "City *";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCity);
            this.groupBox3.Controls.Add(this.txtAge);
            this.groupBox3.Controls.Add(this.rbFemale);
            this.groupBox3.Controls.Add(this.rbMale);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(352, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 115);
            this.groupBox3.TabIndex = 168;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Customer Other Details";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(134, 63);
            this.txtCity.Margin = new System.Windows.Forms.Padding(2);
            this.txtCity.MaxLength = 100;
            this.txtCity.Multiline = true;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(115, 23);
            this.txtCity.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label3.Location = new System.Drawing.Point(41, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 113;
            this.label3.Text = "Gender *";
            // 
            // gBoxPatientDetails
            // 
            this.gBoxPatientDetails.Controls.Add(this.rtbAddress);
            this.gBoxPatientDetails.Controls.Add(this.chktin);
            this.gBoxPatientDetails.Controls.Add(this.txttin);
            this.gBoxPatientDetails.Controls.Add(this.label5);
            this.gBoxPatientDetails.Controls.Add(this.lblEmpId);
            this.gBoxPatientDetails.Controls.Add(this.txtId);
            this.gBoxPatientDetails.Controls.Add(this.txtEmailId);
            this.gBoxPatientDetails.Controls.Add(this.label12);
            this.gBoxPatientDetails.Controls.Add(this.txtMobile);
            this.gBoxPatientDetails.Controls.Add(this.label13);
            this.gBoxPatientDetails.Controls.Add(this.label11);
            this.gBoxPatientDetails.Controls.Add(this.txtName);
            this.gBoxPatientDetails.Controls.Add(this.label14);
            this.gBoxPatientDetails.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxPatientDetails.Location = new System.Drawing.Point(25, 45);
            this.gBoxPatientDetails.Margin = new System.Windows.Forms.Padding(2);
            this.gBoxPatientDetails.Name = "gBoxPatientDetails";
            this.gBoxPatientDetails.Padding = new System.Windows.Forms.Padding(2);
            this.gBoxPatientDetails.Size = new System.Drawing.Size(322, 296);
            this.gBoxPatientDetails.TabIndex = 167;
            this.gBoxPatientDetails.TabStop = false;
            this.gBoxPatientDetails.Text = "Customer Main Details";
            // 
            // rtbAddress
            // 
            this.rtbAddress.Location = new System.Drawing.Point(132, 163);
            this.rtbAddress.MaxLength = 50000000;
            this.rtbAddress.Multiline = true;
            this.rtbAddress.Name = "rtbAddress";
            this.rtbAddress.Size = new System.Drawing.Size(185, 92);
            this.rtbAddress.TabIndex = 112;
            // 
            // chktin
            // 
            this.chktin.AutoSize = true;
            this.chktin.Location = new System.Drawing.Point(108, 275);
            this.chktin.Name = "chktin";
            this.chktin.Size = new System.Drawing.Size(15, 14);
            this.chktin.TabIndex = 111;
            this.chktin.UseVisualStyleBackColor = true;
            this.chktin.CheckedChanged += new System.EventHandler(this.chktin_CheckedChanged);
            // 
            // txttin
            // 
            this.txttin.Location = new System.Drawing.Point(130, 270);
            this.txttin.Name = "txttin";
            this.txttin.Size = new System.Drawing.Size(115, 22);
            this.txttin.TabIndex = 110;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label5.Location = new System.Drawing.Point(35, 273);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 109;
            this.label5.Text = "GST Number";
            // 
            // lblEmpId
            // 
            this.lblEmpId.AutoSize = true;
            this.lblEmpId.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.lblEmpId.Location = new System.Drawing.Point(35, 33);
            this.lblEmpId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpId.Name = "lblEmpId";
            this.lblEmpId.Size = new System.Drawing.Size(82, 18);
            this.lblEmpId.TabIndex = 36;
            this.lblEmpId.Text = "Customer Id *";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(130, 30);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Multiline = true;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(115, 23);
            this.txtId.TabIndex = 10;
            // 
            // txtEmailId
            // 
            this.txtEmailId.Location = new System.Drawing.Point(130, 135);
            this.txtEmailId.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailId.Multiline = true;
            this.txtEmailId.Name = "txtEmailId";
            this.txtEmailId.Size = new System.Drawing.Size(115, 23);
            this.txtEmailId.TabIndex = 13;
            this.txtEmailId.Leave += new System.EventHandler(this.txtEmailId_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label12.Location = new System.Drawing.Point(35, 138);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 18);
            this.label12.TabIndex = 4;
            this.label12.Text = "Email Id";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(130, 99);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(2);
            this.txtMobile.MaxLength = 10;
            this.txtMobile.Multiline = true;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(115, 23);
            this.txtMobile.TabIndex = 12;
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobile_KeyPress);
            this.txtMobile.Leave += new System.EventHandler(this.txtMobile_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label13.Location = new System.Drawing.Point(35, 102);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 18);
            this.label13.TabIndex = 2;
            this.label13.Text = "Mobile *";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label11.Location = new System.Drawing.Point(35, 175);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 18);
            this.label11.TabIndex = 108;
            this.label11.Text = "Address";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 65);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(115, 23);
            this.txtName.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label14.Location = new System.Drawing.Point(35, 68);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 18);
            this.label14.TabIndex = 0;
            this.label14.Text = "Customer Name *";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtReferedBy);
            this.groupBox1.Controls.Add(this.dtpRegDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpDOB);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(352, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 160);
            this.groupBox1.TabIndex = 169;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Other Details";
            // 
            // txtReferedBy
            // 
            this.txtReferedBy.Location = new System.Drawing.Point(133, 31);
            this.txtReferedBy.Margin = new System.Windows.Forms.Padding(2);
            this.txtReferedBy.Multiline = true;
            this.txtReferedBy.Name = "txtReferedBy";
            this.txtReferedBy.Size = new System.Drawing.Size(115, 23);
            this.txtReferedBy.TabIndex = 19;
            // 
            // dtpRegDate
            // 
            this.dtpRegDate.CustomFormat = "dd/MM/yyyy";
            this.dtpRegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRegDate.Location = new System.Drawing.Point(134, 104);
            this.dtpRegDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpRegDate.Name = "dtpRegDate";
            this.dtpRegDate.Size = new System.Drawing.Size(114, 22);
            this.dtpRegDate.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label8.Location = new System.Drawing.Point(41, 107);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 18);
            this.label8.TabIndex = 109;
            this.label8.Text = "Register Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label2.Location = new System.Drawing.Point(41, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 113;
            this.label2.Text = "Refered By";
            // 
            // dtpDOB
            // 
            this.dtpDOB.CustomFormat = "dd/MM/yyyy";
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOB.Location = new System.Drawing.Point(134, 67);
            this.dtpDOB.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(114, 22);
            this.dtpDOB.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label9.Location = new System.Drawing.Point(41, 71);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 18);
            this.label9.TabIndex = 112;
            this.label9.Text = "Date of Birth";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.toolStripLabel1.Size = new System.Drawing.Size(119, 22);
            this.toolStripLabel1.Text = "Customer Details";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(201)))), ((int)(((byte)(62)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.bttnCancel,
            this.toolStripSeparator2,
            this.bttnSave,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 343);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(670, 25);
            this.toolStrip1.TabIndex = 169;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bttnCancel
            // 
            this.bttnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bttnCancel.Image = ((System.Drawing.Image)(resources.GetObject("bttnCancel.Image")));
            this.bttnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.bttnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bttnCancel.Size = new System.Drawing.Size(77, 22);
            this.bttnCancel.Text = "Cancel";
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bttnSave
            // 
            this.bttnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bttnSave.Image = ((System.Drawing.Image)(resources.GetObject("bttnSave.Image")));
            this.bttnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnSave.Name = "bttnSave";
            this.bttnSave.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.bttnSave.Size = new System.Drawing.Size(68, 22);
            this.bttnSave.Text = "Save";
            this.bttnSave.Click += new System.EventHandler(this.bttnSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(201)))), ((int)(((byte)(62)))));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.toolStripSeparator5});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(670, 25);
            this.toolStrip2.TabIndex = 170;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // PatientInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(670, 368);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gBoxPatientDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "PatientInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Information";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PatientInformation_FormClosed);
            this.Load += new System.EventHandler(this.PatientInformation_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gBoxPatientDetails.ResumeLayout(false);
            this.gBoxPatientDetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gBoxPatientDetails;
        private System.Windows.Forms.Label lblEmpId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtEmailId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtReferedBy;
        private System.Windows.Forms.DateTimePicker dtpRegDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bttnCancel;
        private System.Windows.Forms.ToolStripButton bttnSave;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txttin;
        private System.Windows.Forms.CheckBox chktin;
        private System.Windows.Forms.TextBox rtbAddress;
    }
}