using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HospitalManagement.Map;
using System.Drawing.Printing;
using System.IO;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.Drawing.Imaging;
using HospitalManagement.Process;

namespace HospitalManagement.Pages
{
    public partial class HospitalViewer : Form
    {
        private int _billID = 0;
        private int _orginalBillId = 0;
        public HospitalViewer()
        {
            InitializeComponent();
        }
        public HospitalViewer(int billID, int OrginalBillId = 0)
        {
            _billID = billID;
           _orginalBillId = OrginalBillId;
            InitializeComponent();
        }

        private void HospitalViewer_Load(object sender, EventArgs e)
        {
            txtBillId.Text = "" + _orginalBillId;
            billRPTViewer.LocalReport.DataSources.Clear();
            billRPTViewer.ProcessingMode = ProcessingMode.Local;
            if (Common.isThermalPrinter())
                billRPTViewer.LocalReport.ReportPath = "Reports/PrintBill_Thermal.rdlc";
            else
                billRPTViewer.LocalReport.ReportPath = "Reports/PrintBill.rdlc";
            //billRPTViewer.LocalReport.ReportPath = "Reports/PrintBill.rdlc";
            billRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ReportProcess.GenerateBill(_billID).Tables[0]));
            billRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", ReportProcess.getCompany().Tables[0]));
            billRPTViewer.LocalReport.SetParameters(new ReportParameter("BillID", Convert.ToString(_billID)));
            billRPTViewer.LocalReport.SetParameters(new ReportParameter("ModifiedBillId", txtBillId.Text));

            this.billRPTViewer.RefreshReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            billRPTViewer.LocalReport.DataSources.Clear();
            billRPTViewer.ProcessingMode = ProcessingMode.Local;

            billRPTViewer.LocalReport.ReportPath = "Reports/PrintBill.rdlc";
            billRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ReportProcess.GenerateBill(_billID).Tables[0]));
            billRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", ReportProcess.getCompany().Tables[0]));
            billRPTViewer.LocalReport.SetParameters(new ReportParameter("BillID", Convert.ToString(_billID)));
            billRPTViewer.LocalReport.SetParameters(new ReportParameter("ModifiedBillId", txtBillId.Text));

            this.billRPTViewer.RefreshReport();
        }
    }
}
