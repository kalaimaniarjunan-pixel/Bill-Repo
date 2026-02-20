namespace HospitalManagement.Pages
{
    partial class HospitalInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HospitalInformation));
            this.gBoxCompanyDetails = new System.Windows.Forms.GroupBox();
            this.txttin = new System.Windows.Forms.TextBox();
            this.lbltin = new System.Windows.Forms.Label();
            this.txtZipcode = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCompanyAddress = new System.Windows.Forms.TextBox();
            this.txtHospitalName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompanyId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gBoxPhoto = new System.Windows.Forms.GroupBox();
            this.CompanyPicture = new System.Windows.Forms.PictureBox();
            this.txtCompanyLogo = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblHeader = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.gBoxContact = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMobileno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gBoxCompanyDetails.SuspendLayout();
            this.gBoxPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPicture)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.gBoxContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxCompanyDetails
            // 
            this.gBoxCompanyDetails.Controls.Add(this.txttin);
            this.gBoxCompanyDetails.Controls.Add(this.lbltin);
            this.gBoxCompanyDetails.Controls.Add(this.txtZipcode);
            this.gBoxCompanyDetails.Controls.Add(this.txtState);
            this.gBoxCompanyDetails.Controls.Add(this.txtCity);
            this.gBoxCompanyDetails.Controls.Add(this.txtCompanyAddress);
            this.gBoxCompanyDetails.Controls.Add(this.txtHospitalName);
            this.gBoxCompanyDetails.Controls.Add(this.label6);
            this.gBoxCompanyDetails.Controls.Add(this.label5);
            this.gBoxCompanyDetails.Controls.Add(this.label4);
            this.gBoxCompanyDetails.Controls.Add(this.label3);
            this.gBoxCompanyDetails.Controls.Add(this.label2);
            this.gBoxCompanyDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxCompanyDetails.Location = new System.Drawing.Point(26, 43);
            this.gBoxCompanyDetails.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gBoxCompanyDetails.Name = "gBoxCompanyDetails";
            this.gBoxCompanyDetails.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gBoxCompanyDetails.Size = new System.Drawing.Size(397, 300);
            this.gBoxCompanyDetails.TabIndex = 11;
            this.gBoxCompanyDetails.TabStop = false;
            this.gBoxCompanyDetails.Text = "Company Details";
            // 
            // txttin
            // 
            this.txttin.Location = new System.Drawing.Point(147, 199);
            this.txttin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txttin.MaxLength = 30;
            this.txttin.Name = "txttin";
            this.txttin.Size = new System.Drawing.Size(236, 23);
            this.txttin.TabIndex = 7;
            // 
            // lbltin
            // 
            this.lbltin.AutoSize = true;
            this.lbltin.Location = new System.Drawing.Point(89, 204);
            this.lbltin.Name = "lbltin";
            this.lbltin.Size = new System.Drawing.Size(28, 15);
            this.lbltin.TabIndex = 6;
            this.lbltin.Text = "GST";
            // 
            // txtZipcode
            // 
            this.txtZipcode.Location = new System.Drawing.Point(147, 270);
            this.txtZipcode.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtZipcode.MaxLength = 6;
            this.txtZipcode.Name = "txtZipcode";
            this.txtZipcode.Size = new System.Drawing.Size(236, 23);
            this.txtZipcode.TabIndex = 5;
            this.txtZipcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtZipcode_KeyPress);
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(147, 232);
            this.txtState.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtState.MaxLength = 30;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(236, 23);
            this.txtState.TabIndex = 4;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(147, 158);
            this.txtCity.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCity.MaxLength = 30;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(236, 23);
            this.txtCity.TabIndex = 3;
            // 
            // txtCompanyAddress
            // 
            this.txtCompanyAddress.Location = new System.Drawing.Point(147, 69);
            this.txtCompanyAddress.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCompanyAddress.MaxLength = 2000;
            this.txtCompanyAddress.Multiline = true;
            this.txtCompanyAddress.Name = "txtCompanyAddress";
            this.txtCompanyAddress.Size = new System.Drawing.Size(236, 79);
            this.txtCompanyAddress.TabIndex = 2;
            // 
            // txtHospitalName
            // 
            this.txtHospitalName.Location = new System.Drawing.Point(147, 31);
            this.txtHospitalName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtHospitalName.MaxLength = 100;
            this.txtHospitalName.Name = "txtHospitalName";
            this.txtHospitalName.Size = new System.Drawing.Size(236, 23);
            this.txtHospitalName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Zip (Postal) Code *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "State";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "City *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Company Address *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Company Name *";
            // 
            // txtCompanyId
            // 
            this.txtCompanyId.Enabled = false;
            this.txtCompanyId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyId.Location = new System.Drawing.Point(94, -13);
            this.txtCompanyId.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCompanyId.Name = "txtCompanyId";
            this.txtCompanyId.Size = new System.Drawing.Size(128, 23);
            this.txtCompanyId.TabIndex = 0;
            this.txtCompanyId.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, -8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Id";
            this.label1.Visible = false;
            // 
            // gBoxPhoto
            // 
            this.gBoxPhoto.Controls.Add(this.CompanyPicture);
            this.gBoxPhoto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxPhoto.Location = new System.Drawing.Point(444, 163);
            this.gBoxPhoto.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gBoxPhoto.Name = "gBoxPhoto";
            this.gBoxPhoto.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gBoxPhoto.Size = new System.Drawing.Size(290, 158);
            this.gBoxPhoto.TabIndex = 15;
            this.gBoxPhoto.TabStop = false;
            this.gBoxPhoto.Text = "Company Logo";
            // 
            // CompanyPicture
            // 
            this.CompanyPicture.Location = new System.Drawing.Point(17, 26);
            this.CompanyPicture.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.CompanyPicture.Name = "CompanyPicture";
            this.CompanyPicture.Size = new System.Drawing.Size(253, 115);
            this.CompanyPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CompanyPicture.TabIndex = 7;
            this.CompanyPicture.TabStop = false;
            // 
            // txtCompanyLogo
            // 
            this.txtCompanyLogo.Enabled = false;
            this.txtCompanyLogo.Location = new System.Drawing.Point(118, 359);
            this.txtCompanyLogo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCompanyLogo.Name = "txtCompanyLogo";
            this.txtCompanyLogo.Size = new System.Drawing.Size(312, 23);
            this.txtCompanyLogo.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBrowse.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(461, 354);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(76, 32);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(201)))), ((int)(((byte)(62)))));
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.lblHeader,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(787, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Margin = new System.Windows.Forms.Padding(3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(105, 19);
            this.lblHeader.Text = "Company Details";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(201)))), ((int)(((byte)(62)))));
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.btnCancel,
            this.toolStripSeparator4,
            this.btnSave,
            this.toolStripSeparator5});
            this.toolStrip2.Location = new System.Drawing.Point(0, 391);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(787, 29);
            this.toolStrip2.TabIndex = 17;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(49, 23);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // btnSave
            // 
            this.btnSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 23);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // gBoxContact
            // 
            this.gBoxContact.Controls.Add(this.txtEmail);
            this.gBoxContact.Controls.Add(this.txtMobileno);
            this.gBoxContact.Controls.Add(this.label9);
            this.gBoxContact.Controls.Add(this.label8);
            this.gBoxContact.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxContact.Location = new System.Drawing.Point(439, 43);
            this.gBoxContact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBoxContact.Name = "gBoxContact";
            this.gBoxContact.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBoxContact.Size = new System.Drawing.Size(295, 116);
            this.gBoxContact.TabIndex = 18;
            this.gBoxContact.TabStop = false;
            this.gBoxContact.Text = "Contact";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(107, 66);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.MaxLength = 30;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(177, 23);
            this.txtEmail.TabIndex = 8;
            // 
            // txtMobileno
            // 
            this.txtMobileno.Location = new System.Drawing.Point(107, 33);
            this.txtMobileno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMobileno.MaxLength = 10;
            this.txtMobileno.Name = "txtMobileno";
            this.txtMobileno.Size = new System.Drawing.Size(177, 23);
            this.txtMobileno.TabIndex = 7;
            this.txtMobileno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobileno_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Mobile No *";
            // 
            // HospitalInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(787, 420);
            this.Controls.Add(this.gBoxContact);
            this.Controls.Add(this.txtCompanyLogo);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gBoxPhoto);
            this.Controls.Add(this.gBoxCompanyDetails);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCompanyId);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "HospitalInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Information";
            this.Load += new System.EventHandler(this.HospitalInformation_Load);
            this.gBoxCompanyDetails.ResumeLayout(false);
            this.gBoxCompanyDetails.PerformLayout();
            this.gBoxPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPicture)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.gBoxContact.ResumeLayout(false);
            this.gBoxContact.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxCompanyDetails;
        private System.Windows.Forms.TextBox txtZipcode;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtCompanyAddress;
        private System.Windows.Forms.TextBox txtHospitalName;
        private System.Windows.Forms.TextBox txtCompanyId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gBoxPhoto;
        private System.Windows.Forms.PictureBox CompanyPicture;
        private System.Windows.Forms.TextBox txtCompanyLogo;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblHeader;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.GroupBox gBoxContact;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMobileno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txttin;
        private System.Windows.Forms.Label lbltin;
    }
}