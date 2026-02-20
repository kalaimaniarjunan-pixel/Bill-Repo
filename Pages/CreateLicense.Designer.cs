namespace HospitalManagement.Pages
{
    partial class CreateLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateLicense));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ddlPoduct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rdo36Months = new System.Windows.Forms.RadioButton();
            this.rdo24Months = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoOnemonth = new System.Windows.Forms.RadioButton();
            this.rdo12months = new System.Windows.Forms.RadioButton();
            this.rdo3Months = new System.Windows.Forms.RadioButton();
            this.rdo6Months = new System.Windows.Forms.RadioButton();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(201)))), ((int)(((byte)(62)))));
            this.toolStrip1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.btnCancel,
            this.toolStripSeparator3,
            this.btnSave,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(419, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(3);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(106, 19);
            this.toolStripLabel1.Text = "License Creation";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 22);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSave
            // 
            this.btnSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // ddlPoduct
            // 
            this.ddlPoduct.FormattingEnabled = true;
            this.ddlPoduct.Location = new System.Drawing.Point(275, 22);
            this.ddlPoduct.Name = "ddlPoduct";
            this.ddlPoduct.Size = new System.Drawing.Size(121, 21);
            this.ddlPoduct.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Package *";
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(98, 24);
            this.dtStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(90, 20);
            this.dtStartDate.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start Date *";
            // 
            // rdo36Months
            // 
            this.rdo36Months.AutoSize = true;
            this.rdo36Months.Location = new System.Drawing.Point(268, 119);
            this.rdo36Months.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo36Months.Name = "rdo36Months";
            this.rdo36Months.Size = new System.Drawing.Size(75, 17);
            this.rdo36Months.TabIndex = 5;
            this.rdo36Months.TabStop = true;
            this.rdo36Months.Text = "36 Months";
            this.rdo36Months.UseVisualStyleBackColor = true;
            // 
            // rdo24Months
            // 
            this.rdo24Months.AutoSize = true;
            this.rdo24Months.Location = new System.Drawing.Point(162, 119);
            this.rdo24Months.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo24Months.Name = "rdo24Months";
            this.rdo24Months.Size = new System.Drawing.Size(75, 17);
            this.rdo24Months.TabIndex = 4;
            this.rdo24Months.TabStop = true;
            this.rdo24Months.Text = "24 Months";
            this.rdo24Months.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddlPoduct);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtStartDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdo36Months);
            this.groupBox1.Controls.Add(this.rdo24Months);
            this.groupBox1.Controls.Add(this.rdoOnemonth);
            this.groupBox1.Controls.Add(this.rdo12months);
            this.groupBox1.Controls.Add(this.rdo3Months);
            this.groupBox1.Controls.Add(this.rdo6Months);
            this.groupBox1.Location = new System.Drawing.Point(7, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(403, 161);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "License";
            // 
            // rdoOnemonth
            // 
            this.rdoOnemonth.AutoSize = true;
            this.rdoOnemonth.Location = new System.Drawing.Point(52, 65);
            this.rdoOnemonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoOnemonth.Name = "rdoOnemonth";
            this.rdoOnemonth.Size = new System.Drawing.Size(64, 17);
            this.rdoOnemonth.TabIndex = 0;
            this.rdoOnemonth.TabStop = true;
            this.rdoOnemonth.Text = "1 Month";
            this.rdoOnemonth.UseVisualStyleBackColor = true;
            // 
            // rdo12months
            // 
            this.rdo12months.AutoSize = true;
            this.rdo12months.Location = new System.Drawing.Point(52, 119);
            this.rdo12months.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo12months.Name = "rdo12months";
            this.rdo12months.Size = new System.Drawing.Size(75, 17);
            this.rdo12months.TabIndex = 3;
            this.rdo12months.TabStop = true;
            this.rdo12months.Text = "12 Months";
            this.rdo12months.UseVisualStyleBackColor = true;
            // 
            // rdo3Months
            // 
            this.rdo3Months.AutoSize = true;
            this.rdo3Months.Location = new System.Drawing.Point(162, 65);
            this.rdo3Months.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo3Months.Name = "rdo3Months";
            this.rdo3Months.Size = new System.Drawing.Size(69, 17);
            this.rdo3Months.TabIndex = 1;
            this.rdo3Months.TabStop = true;
            this.rdo3Months.Text = "3 Months";
            this.rdo3Months.UseVisualStyleBackColor = true;
            // 
            // rdo6Months
            // 
            this.rdo6Months.AutoSize = true;
            this.rdo6Months.Location = new System.Drawing.Point(268, 65);
            this.rdo6Months.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo6Months.Name = "rdo6Months";
            this.rdo6Months.Size = new System.Drawing.Size(69, 17);
            this.rdo6Months.TabIndex = 2;
            this.rdo6Months.TabStop = true;
            this.rdo6Months.Text = "6 Months";
            this.rdo6Months.UseVisualStyleBackColor = true;
            // 
            // CreateLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(419, 201);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateLicense";
            this.Load += new System.EventHandler(this.CreateLicense_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ComboBox ddlPoduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdo36Months;
        private System.Windows.Forms.RadioButton rdo24Months;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoOnemonth;
        private System.Windows.Forms.RadioButton rdo12months;
        private System.Windows.Forms.RadioButton rdo3Months;
        private System.Windows.Forms.RadioButton rdo6Months;
    }
}