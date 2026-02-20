namespace HospitalManagement.Pages
{
    partial class Vendor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vendor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblHeader = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtvendorName = new System.Windows.Forms.TextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.txtVendorID = new System.Windows.Forms.TextBox();
            this.txtvendorzipcode = new System.Windows.Forms.Label();
            this.txtvendorstate = new System.Windows.Forms.Label();
            this.txtvendoraddress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gBoxGeneral = new System.Windows.Forms.GroupBox();
            this.txtMobilePhone = new System.Windows.Forms.TextBox();
            this.txtmobilevendor = new System.Windows.Forms.Label();
            this.txtvendoremail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtvendordetail = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.txtvendorcity = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.gBoxGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(201)))), ((int)(((byte)(62)))));
            this.toolStrip1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblHeader,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(382, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Margin = new System.Windows.Forms.Padding(3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(53, 19);
            this.lblHeader.Text = "Vendors";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(147, 301);
            this.txtZipCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtZipCode.MaxLength = 10;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(122, 22);
            this.txtZipCode.TabIndex = 8;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(147, 272);
            this.txtState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtState.MaxLength = 50;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(180, 22);
            this.txtState.TabIndex = 7;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(147, 243);
            this.txtCity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCity.MaxLength = 50;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(180, 22);
            this.txtCity.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(147, 171);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.MaxLength = 2000;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(180, 58);
            this.txtAddress.TabIndex = 5;
            // 
            // txtvendorName
            // 
            this.txtvendorName.Location = new System.Drawing.Point(147, 63);
            this.txtvendorName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtvendorName.MaxLength = 100;
            this.txtvendorName.Name = "txtvendorName";
            this.txtvendorName.Size = new System.Drawing.Size(180, 22);
            this.txtvendorName.TabIndex = 2;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(201)))), ((int)(((byte)(62)))));
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.btnCancel,
            this.toolStripSeparator3,
            this.btnSave,
            this.toolStripSeparator4});
            this.toolStrip2.Location = new System.Drawing.Point(0, 424);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(382, 29);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // txtVendorID
            // 
            this.txtVendorID.Enabled = false;
            this.txtVendorID.Location = new System.Drawing.Point(147, 30);
            this.txtVendorID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVendorID.MaxLength = 50;
            this.txtVendorID.Name = "txtVendorID";
            this.txtVendorID.Size = new System.Drawing.Size(122, 22);
            this.txtVendorID.TabIndex = 1;
            // 
            // txtvendorzipcode
            // 
            this.txtvendorzipcode.AutoSize = true;
            this.txtvendorzipcode.Location = new System.Drawing.Point(62, 305);
            this.txtvendorzipcode.Name = "txtvendorzipcode";
            this.txtvendorzipcode.Size = new System.Drawing.Size(53, 13);
            this.txtvendorzipcode.TabIndex = 5;
            this.txtvendorzipcode.Text = "Zip Code";
            // 
            // txtvendorstate
            // 
            this.txtvendorstate.AutoSize = true;
            this.txtvendorstate.Location = new System.Drawing.Point(82, 276);
            this.txtvendorstate.Name = "txtvendorstate";
            this.txtvendorstate.Size = new System.Drawing.Size(33, 13);
            this.txtvendorstate.TabIndex = 4;
            this.txtvendorstate.Text = "State";
            // 
            // txtvendoraddress
            // 
            this.txtvendoraddress.AutoSize = true;
            this.txtvendoraddress.Location = new System.Drawing.Point(68, 175);
            this.txtvendoraddress.Name = "txtvendoraddress";
            this.txtvendoraddress.Size = new System.Drawing.Size(48, 13);
            this.txtvendoraddress.TabIndex = 2;
            this.txtvendoraddress.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vendor Name *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vendor ID";
            // 
            // gBoxGeneral
            // 
            this.gBoxGeneral.Controls.Add(this.txtMobilePhone);
            this.gBoxGeneral.Controls.Add(this.txtmobilevendor);
            this.gBoxGeneral.Controls.Add(this.txtvendoremail);
            this.gBoxGeneral.Controls.Add(this.txtEmail);
            this.gBoxGeneral.Controls.Add(this.txtvendordetail);
            this.gBoxGeneral.Controls.Add(this.txtDetails);
            this.gBoxGeneral.Controls.Add(this.txtZipCode);
            this.gBoxGeneral.Controls.Add(this.txtState);
            this.gBoxGeneral.Controls.Add(this.txtCity);
            this.gBoxGeneral.Controls.Add(this.txtAddress);
            this.gBoxGeneral.Controls.Add(this.txtvendorName);
            this.gBoxGeneral.Controls.Add(this.txtVendorID);
            this.gBoxGeneral.Controls.Add(this.txtvendorzipcode);
            this.gBoxGeneral.Controls.Add(this.txtvendorstate);
            this.gBoxGeneral.Controls.Add(this.txtvendorcity);
            this.gBoxGeneral.Controls.Add(this.txtvendoraddress);
            this.gBoxGeneral.Controls.Add(this.label2);
            this.gBoxGeneral.Controls.Add(this.label1);
            this.gBoxGeneral.Location = new System.Drawing.Point(17, 37);
            this.gBoxGeneral.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBoxGeneral.Name = "gBoxGeneral";
            this.gBoxGeneral.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBoxGeneral.Size = new System.Drawing.Size(348, 383);
            this.gBoxGeneral.TabIndex = 18;
            this.gBoxGeneral.TabStop = false;
            this.gBoxGeneral.Text = "Vendor Information";
            // 
            // txtMobilePhone
            // 
            this.txtMobilePhone.Location = new System.Drawing.Point(149, 99);
            this.txtMobilePhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMobilePhone.MaxLength = 10;
            this.txtMobilePhone.Name = "txtMobilePhone";
            this.txtMobilePhone.Size = new System.Drawing.Size(176, 22);
            this.txtMobilePhone.TabIndex = 3;
            this.txtMobilePhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobilePhone_KeyPress);
            // 
            // txtmobilevendor
            // 
            this.txtmobilevendor.AutoSize = true;
            this.txtmobilevendor.Location = new System.Drawing.Point(37, 103);
            this.txtmobilevendor.Name = "txtmobilevendor";
            this.txtmobilevendor.Size = new System.Drawing.Size(87, 13);
            this.txtmobilevendor.TabIndex = 22;
            this.txtmobilevendor.Text = "Mobile Phone *";
            // 
            // txtvendoremail
            // 
            this.txtvendoremail.AutoSize = true;
            this.txtvendoremail.Location = new System.Drawing.Point(69, 140);
            this.txtvendoremail.Name = "txtvendoremail";
            this.txtvendoremail.Size = new System.Drawing.Size(47, 13);
            this.txtvendoremail.TabIndex = 21;
            this.txtvendoremail.Text = "Email Id";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(147, 137);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(178, 22);
            this.txtEmail.TabIndex = 4;
            // 
            // txtvendordetail
            // 
            this.txtvendordetail.AutoSize = true;
            this.txtvendordetail.Location = new System.Drawing.Point(73, 338);
            this.txtvendordetail.Name = "txtvendordetail";
            this.txtvendordetail.Size = new System.Drawing.Size(42, 13);
            this.txtvendordetail.TabIndex = 19;
            this.txtvendordetail.Text = "Details";
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(147, 335);
            this.txtDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDetails.MaxLength = 15;
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(180, 40);
            this.txtDetails.TabIndex = 9;
            // 
            // txtvendorcity
            // 
            this.txtvendorcity.AutoSize = true;
            this.txtvendorcity.Location = new System.Drawing.Point(90, 247);
            this.txtvendorcity.Name = "txtvendorcity";
            this.txtvendorcity.Size = new System.Drawing.Size(26, 13);
            this.txtvendorcity.TabIndex = 3;
            this.txtvendorcity.Text = "City";
            // 
            // Vendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(382, 453);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gBoxGeneral);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Vendor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suppliers";
            this.Load += new System.EventHandler(this.Suppliers_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.gBoxGeneral.ResumeLayout(false);
            this.gBoxGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblHeader;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtvendorName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TextBox txtVendorID;
        private System.Windows.Forms.Label txtvendorzipcode;
        private System.Windows.Forms.Label txtvendorstate;
        private System.Windows.Forms.Label txtvendoraddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gBoxGeneral;
        private System.Windows.Forms.Label txtvendorcity;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label txtvendordetail;
        private System.Windows.Forms.Label txtvendoremail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMobilePhone;
        private System.Windows.Forms.Label txtmobilevendor;
    }
}