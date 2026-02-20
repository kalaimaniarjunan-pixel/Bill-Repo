namespace HospitalManagement.Pages
{
    partial class HospitalViewer
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
            this.billRPTViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtBillId = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblBillId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // billRPTViewer
            // 
            this.billRPTViewer.Location = new System.Drawing.Point(3, 37);
            this.billRPTViewer.Name = "billRPTViewer";
            this.billRPTViewer.Size = new System.Drawing.Size(987, 463);
            this.billRPTViewer.TabIndex = 0;
            // 
            // txtBillId
            // 
            this.txtBillId.Location = new System.Drawing.Point(63, 10);
            this.txtBillId.Name = "txtBillId";
            this.txtBillId.Size = new System.Drawing.Size(115, 20);
            this.txtBillId.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(184, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Refresh";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblBillId
            // 
            this.lblBillId.AutoSize = true;
            this.lblBillId.Location = new System.Drawing.Point(25, 13);
            this.lblBillId.Name = "lblBillId";
            this.lblBillId.Size = new System.Drawing.Size(32, 13);
            this.lblBillId.TabIndex = 3;
            this.lblBillId.Text = "Bill Id";
            // 
            // HospitalViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1009, 512);
            this.Controls.Add(this.lblBillId);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtBillId);
            this.Controls.Add(this.billRPTViewer);
            this.Name = "HospitalViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Viewer";
            this.Load += new System.EventHandler(this.HospitalViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer billRPTViewer;
        private System.Windows.Forms.TextBox txtBillId;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblBillId;

    }
}