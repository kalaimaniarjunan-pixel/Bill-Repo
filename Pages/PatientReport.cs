using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HospitalManagement.Map;
using HospitalManagement.Process;
using Microsoft.Reporting.WinForms;

namespace HospitalManagement.Pages
{
    public partial class PatientReport : Form
    {
        private int _billID = 0;
        public PatientReport()
        {
            InitializeComponent();
        }
        public PatientReport(int billID)
        {
            _billID = billID;
            InitializeComponent();
        }
        private void PatientReport_Load(object sender, EventArgs e)
        {
            PatientRPTViewer.LocalReport.DataSources.Clear();
            PatientRPTViewer.ProcessingMode = ProcessingMode.Local;

            PatientRPTViewer.LocalReport.ReportPath = "Reports/PatientReport.rdlc";
            PatientRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ReportProcess.GenerateReport(_billID).Tables[0]));
            PatientRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", ReportProcess.getCompany().Tables[0]));
            PatientRPTViewer.LocalReport.SetParameters(new ReportParameter("BillID", Convert.ToString(_billID)));

            this.PatientRPTViewer.RefreshReport();
        }
    }
}
