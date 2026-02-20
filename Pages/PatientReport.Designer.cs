namespace HospitalManagement.Pages
{
    partial class PatientReport
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
            this.PatientRPTViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // PatientRPTViewer
            // 
            this.PatientRPTViewer.Location = new System.Drawing.Point(1, 1);
            this.PatientRPTViewer.Name = "PatientRPTViewer";
            this.PatientRPTViewer.Size = new System.Drawing.Size(1199, 487);
            this.PatientRPTViewer.TabIndex = 0;
            // 
            // PatientReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1227, 500);
            this.Controls.Add(this.PatientRPTViewer);
            this.Name = "PatientReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient Report";
            this.Load += new System.EventHandler(this.PatientReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer PatientRPTViewer;
    }
}