namespace HospitalManagement.Pages
{
    partial class HospiReportViewer
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
            this.gboxReportName = new System.Windows.Forms.GroupBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.hospiRPTViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gboxProduct = new System.Windows.Forms.GroupBox();
            this.drpProducts = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grpSupplier = new System.Windows.Forms.GroupBox();
            this.drpSupplier = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.gboxReportName.SuspendLayout();
            this.gboxProduct.SuspendLayout();
            this.grpSupplier.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxReportName
            // 
            this.gboxReportName.Controls.Add(this.dtToDate);
            this.gboxReportName.Controls.Add(this.dtFromDate);
            this.gboxReportName.Controls.Add(this.label2);
            this.gboxReportName.Controls.Add(this.label1);
            this.gboxReportName.Location = new System.Drawing.Point(166, 12);
            this.gboxReportName.Name = "gboxReportName";
            this.gboxReportName.Size = new System.Drawing.Size(331, 59);
            this.gboxReportName.TabIndex = 1;
            this.gboxReportName.TabStop = false;
            this.gboxReportName.Text = "Range";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd/MM/yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(230, 22);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(85, 20);
            this.dtToDate.TabIndex = 3;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(83, 22);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(88, 20);
            this.dtFromDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Location = new System.Drawing.Point(1053, 25);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 27);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // hospiRPTViewer
            // 
            this.hospiRPTViewer.Location = new System.Drawing.Point(110, 83);
            this.hospiRPTViewer.Name = "hospiRPTViewer";
            this.hospiRPTViewer.Size = new System.Drawing.Size(1135, 523);
            this.hospiRPTViewer.TabIndex = 6;
            // 
            // gboxProduct
            // 
            this.gboxProduct.Controls.Add(this.drpProducts);
            this.gboxProduct.Controls.Add(this.label9);
            this.gboxProduct.Location = new System.Drawing.Point(519, 12);
            this.gboxProduct.Name = "gboxProduct";
            this.gboxProduct.Size = new System.Drawing.Size(208, 59);
            this.gboxProduct.TabIndex = 11;
            this.gboxProduct.TabStop = false;
            this.gboxProduct.Text = "Products";
            // 
            // drpProducts
            // 
            this.drpProducts.FormattingEnabled = true;
            this.drpProducts.Location = new System.Drawing.Point(75, 19);
            this.drpProducts.Name = "drpProducts";
            this.drpProducts.Size = new System.Drawing.Size(121, 21);
            this.drpProducts.TabIndex = 13;
           // this.drpProducts.SelectedIndexChanged += new System.EventHandler(this.drpProducts_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Products";
            // 
            // grpSupplier
            // 
            this.grpSupplier.Controls.Add(this.drpSupplier);
            this.grpSupplier.Controls.Add(this.lblSupplier);
            this.grpSupplier.Location = new System.Drawing.Point(743, 12);
            this.grpSupplier.Name = "grpSupplier";
            this.grpSupplier.Size = new System.Drawing.Size(208, 59);
            this.grpSupplier.TabIndex = 12;
            this.grpSupplier.TabStop = false;
            this.grpSupplier.Text = "Supplier";
            // 
            // drpSupplier
            // 
            this.drpSupplier.FormattingEnabled = true;
            this.drpSupplier.Location = new System.Drawing.Point(81, 16);
            this.drpSupplier.Name = "drpSupplier";
            this.drpSupplier.Size = new System.Drawing.Size(121, 21);
            this.drpSupplier.TabIndex = 13;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(17, 25);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(45, 13);
            this.lblSupplier.TabIndex = 13;
            this.lblSupplier.Text = "Supplier";
            // 
            // HospiReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1314, 645);
            this.Controls.Add(this.grpSupplier);
            this.Controls.Add(this.gboxProduct);
            this.Controls.Add(this.hospiRPTViewer);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.gboxReportName);
            this.Name = "HospiReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Viewer";
            this.Load += new System.EventHandler(this.HospiReportViewer_Load);
            this.gboxReportName.ResumeLayout(false);
            this.gboxReportName.PerformLayout();
            this.gboxProduct.ResumeLayout(false);
            this.gboxProduct.PerformLayout();
            this.grpSupplier.ResumeLayout(false);
            this.grpSupplier.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxReportName;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private Microsoft.Reporting.WinForms.ReportViewer hospiRPTViewer;
        private System.Windows.Forms.GroupBox gboxProduct;
        private System.Windows.Forms.ComboBox drpProducts;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpSupplier;
        private System.Windows.Forms.ComboBox drpSupplier;
        private System.Windows.Forms.Label lblSupplier;
    }
}