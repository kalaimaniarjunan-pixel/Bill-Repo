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
    public partial class HospiReportViewer : Form
    {
        public string strReportName = "";
        ReportMap _rptMap = new ReportMap();

        public HospiReportViewer()
        {
            InitializeComponent();
        }

        private void HospiReportViewer_Load(object sender, EventArgs e)
        {
            this.hospiRPTViewer.RefreshReport();
            gboxReportName.Enabled = false;
            gboxProduct.Enabled = false;
            grpSupplier.Enabled = false;
            loadDropDownValues();

            switch (strReportName)
            {
                case "BillwiseReport":
                    gboxReportName.Text = "Billwise Sales Report Criteria";
                    gboxReportName.Enabled = true;
                    break;
                case "CancelledBillReport":
                    gboxReportName.Text = "Cancelled Bill Report Criteria";
                    gboxReportName.Enabled = true;
                    break;
                case "DaywiseReport":
                    gboxReportName.Text = "Daywise Sales Report Criteria";
                    gboxReportName.Enabled = true;
                    break;
                case "ClosingStockReport":
                    gboxReportName.Text = "Closing Stock Report Criteria";
                    gboxReportName.Enabled = false;
                    break;
                case "StockSummaryReport":
                    gboxReportName.Enabled = true;
                    gboxReportName.Text = "Stock Summary Report Criteria";
                    break;
                case "ProductSolds":
                    gboxReportName.Enabled = true;
                    gboxProduct.Enabled = true;
                    gboxReportName.Text = "Product Solds Report Criteria";
                    break;
                case "AllBillsContainingProducts":
                    gboxReportName.Enabled = true;
                    gboxProduct.Enabled = true;
                    gboxReportName.Text = "All Bills Containing Products Report Criteria";
                    break;
                case "SupplierBillDetailsReport":
                    gboxReportName.Text = "Supplier Bill Details Report Criteria";
                    gboxReportName.Enabled = true;
                    break;
                case "SupplierWiseBillReport":
                    gboxReportName.Text = "SupplierWise Bill Details Report Criteria";
                    gboxReportName.Enabled = true;
                    grpSupplier.Enabled = true;
                    break;
                case "SupplierWiseClosingStockReport":
                    gboxReportName.Text = "Supplier Wise Closing Stock Report Criteria";
                    gboxReportName.Enabled = false;
                    grpSupplier.Enabled = true;
                    break;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            hospiRPTViewer.LocalReport.DataSources.Clear();
            DataSet oDataset;
            switch (strReportName)
            {
                case "BillwiseReport":
                    _rptMap.FromDate = Common.GetDateTime(dtFromDate.Text);
                    _rptMap.ToDate = Common.GetDateTime(dtToDate.Text);

                    oDataset = ReportProcess.BillWiseReport(_rptMap);
                    hospiRPTViewer.ProcessingMode = ProcessingMode.Local;
                    hospiRPTViewer.LocalReport.ReportPath = "Reports/Billwise.rdlc";
                    hospiRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", oDataset.Tables[0]));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("FromDate", _rptMap.FromDate.ToShortDateString()));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("ToDate", _rptMap.ToDate.ToShortDateString()));
                    hospiRPTViewer.RefreshReport();
                    break;
                case "CancelledBillReport":
                    _rptMap.FromDate = Common.GetDateTime(dtFromDate.Text);
                    _rptMap.ToDate = Common.GetDateTime(dtToDate.Text);

                    oDataset = ReportProcess.CancelledBillReport(_rptMap);
                    hospiRPTViewer.ProcessingMode = ProcessingMode.Local;
                    hospiRPTViewer.LocalReport.ReportPath = "Reports/CancelledBills.rdlc";
                    hospiRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", oDataset.Tables[0]));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("FromDate", _rptMap.FromDate.ToShortDateString()));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("ToDate", _rptMap.ToDate.ToShortDateString()));
                    hospiRPTViewer.RefreshReport();
                    break;
                case "DaywiseReport":
                    _rptMap.FromDate = Common.GetDateTime(dtFromDate.Text);
                    _rptMap.ToDate = Common.GetDateTime(dtToDate.Text);

                    oDataset = ReportProcess.DayWiseReport(_rptMap);
                    hospiRPTViewer.ProcessingMode = ProcessingMode.Local;
                    hospiRPTViewer.LocalReport.ReportPath = "Reports/Daywise.rdlc";
                    hospiRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", oDataset.Tables[0]));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("FromDate", _rptMap.FromDate.ToShortDateString()));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("ToDate", _rptMap.ToDate.ToShortDateString()));
                    hospiRPTViewer.RefreshReport();
                    break;
                case "ClosingStockReport":
                    oDataset = ReportProcess.ClosingStock();
                    hospiRPTViewer.ProcessingMode = ProcessingMode.Local;
                    hospiRPTViewer.LocalReport.ReportPath = "Reports/Closingstock.rdlc";
                    hospiRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", oDataset.Tables[0]));
                    hospiRPTViewer.RefreshReport();
                    break;
                case "StockSummaryReport":
                    _rptMap.FromDate = Common.GetDateTime(dtFromDate.Text);
                    _rptMap.ToDate = Common.GetDateTime(dtToDate.Text);
                    oDataset = ReportProcess.StockSummaryReport(_rptMap);
                    hospiRPTViewer.ProcessingMode = ProcessingMode.Local;
                    hospiRPTViewer.LocalReport.ReportPath = "Reports/StockSummary.rdlc";
                    hospiRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", oDataset.Tables[0]));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("FromDate", _rptMap.FromDate.ToShortDateString()));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("ToDate", _rptMap.ToDate.ToShortDateString()));
                    hospiRPTViewer.RefreshReport();
                    break;
                case "ProductSolds":
                    _rptMap.FromDate = Common.GetDateTime(dtFromDate.Text);
                    _rptMap.ToDate = Common.GetDateTime(dtToDate.Text);
                    _rptMap.strProduct = Convert.ToString(drpProducts.SelectedValue);

                    oDataset = ReportProcess.ProductSolds(_rptMap);
                    hospiRPTViewer.ProcessingMode = ProcessingMode.Local;
                    hospiRPTViewer.LocalReport.ReportPath = "Reports/ProductSolds.rdlc";
                    hospiRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", oDataset.Tables[0]));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("FromDate", _rptMap.FromDate.ToShortDateString()));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("ToDate", _rptMap.ToDate.ToShortDateString()));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("ProductID", _rptMap.strProduct));
                    hospiRPTViewer.RefreshReport();
                    break;
                case "AllBillsContainingProducts":
                    _rptMap.FromDate = Common.GetDateTime(dtFromDate.Text);
                    _rptMap.ToDate = Common.GetDateTime(dtToDate.Text);
                    _rptMap.strProduct = Convert.ToString(drpProducts.SelectedValue);

                    oDataset = ReportProcess.ProductSoldBills(_rptMap);
                    hospiRPTViewer.ProcessingMode = ProcessingMode.Local;
                    hospiRPTViewer.LocalReport.ReportPath = "Reports/ProductsSoldBills.rdlc";
                    hospiRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", oDataset.Tables[0]));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("FromDate", _rptMap.FromDate.ToShortDateString()));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("ToDate", _rptMap.ToDate.ToShortDateString()));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("ProductID", _rptMap.strProduct));
                    hospiRPTViewer.RefreshReport();
                    break;
                case "SupplierBillDetailsReport":
                    _rptMap.FromDate = Common.GetDateTime(dtFromDate.Text);
                    _rptMap.ToDate = Common.GetDateTime(dtToDate.Text);

                    oDataset = ReportProcess.SupplierBillDetails(_rptMap);
                    hospiRPTViewer.ProcessingMode = ProcessingMode.Local;
                    hospiRPTViewer.LocalReport.ReportPath = "Reports/SupplierBillDetail.rdlc";
                    hospiRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", oDataset.Tables[0]));
                    hospiRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", ReportProcess.getCompany().Tables[0]));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("FromDate", _rptMap.FromDate.ToShortDateString()));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("ToDate", _rptMap.ToDate.ToShortDateString()));
                    hospiRPTViewer.RefreshReport();
                    break;
                case "SupplierWiseBillReport":
                    _rptMap.FromDate = Common.GetDateTime(dtFromDate.Text);
                    _rptMap.ToDate = Common.GetDateTime(dtToDate.Text);
                    _rptMap.intSupplier = Convert.ToInt32(drpSupplier.SelectedValue);

                    oDataset = ReportProcess.SupplierWiseBillReport(_rptMap);
                    hospiRPTViewer.ProcessingMode = ProcessingMode.Local;
                    hospiRPTViewer.LocalReport.ReportPath = "Reports/Billwise.rdlc";
                    hospiRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", oDataset.Tables[0]));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("FromDate", _rptMap.FromDate.ToShortDateString()));
                    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("ToDate", _rptMap.ToDate.ToShortDateString()));
                    hospiRPTViewer.RefreshReport();
                    break;
                case "SupplierWiseClosingStockReport":
                    _rptMap.intSupplier = Convert.ToInt32(drpSupplier.SelectedValue);
                    oDataset = ReportProcess.SupplierWiseClosingStock(_rptMap);
                    hospiRPTViewer.ProcessingMode = ProcessingMode.Local;
                    hospiRPTViewer.LocalReport.ReportPath = "Reports/Closingstock.rdlc";
                    hospiRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", oDataset.Tables[0]));
                    hospiRPTViewer.RefreshReport();
                    break;
                //case "BillwisePatientReport":
                //    _rptMap.FromDate = Common.GetDateTime(dtFromDate.Text);
                //    _rptMap.ToDate = Common.GetDateTime(dtToDate.Text);

                //    oDataset = ReportProcess.BillwisepatientReport(_rptMap);
                //    hospiRPTViewer.ProcessingMode = ProcessingMode.Local;
                //    hospiRPTViewer.LocalReport.ReportPath = "Reports/BillwisePatient.rdlc";
                //    hospiRPTViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", oDataset.Tables[0]));
                //    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("FromDate", _rptMap.FromDate.ToShortDateString()));
                //    hospiRPTViewer.LocalReport.SetParameters(new ReportParameter("ToDate", _rptMap.ToDate.ToShortDateString()));
                //    hospiRPTViewer.RefreshReport();
                //    break;
            }

        }
        private void loadDropDownValues()
        {
            Common.BindDropDownValues(drpProducts, "Product", "");
            Common.BindDropDownValues(drpSupplier, "Supplier", "");
        }


    }
}
