using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalManagement.Map;
using System.Data.SqlClient;
using System.Data;
using SalonFazia.Helper;

namespace HospitalManagement.Process
{
    public class ReportProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static DataSet BillWiseReport(ReportMap _rptMap)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@FromDate", _rptMap.FromDate),
                                        new SqlParameter("@ToDate", _rptMap.ToDate)};
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Report_BillWiseReport", sqlParam);
        }
        public static DataSet CancelledBillReport(ReportMap _rptMap)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@FromDate", _rptMap.FromDate),
                                        new SqlParameter("@ToDate", _rptMap.ToDate)};
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Report_CancelledBillReport", sqlParam);
        }
        public static DataSet DayWiseReport(ReportMap _rptMap)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@FromDate", _rptMap.FromDate),
                                        new SqlParameter("@ToDate", _rptMap.ToDate)};
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Report_DaywiseReport", sqlParam);
        }
        //public static DataSet BillwisepatientReport(ReportMap _rptMap)
        //{
        //    SqlParameter[] sqlParam = { new SqlParameter("@FromDate", _rptMap.FromDate),
        //                                new SqlParameter("@ToDate", _rptMap.ToDate)};
        //    return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Report_BillwisePatientDetails", sqlParam);
        //}

        #region New Report

        public static DataSet getCompany()
        {
            //return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, "Select CompanyName, Address, City, State, Zip, CompanyLogo,MobileNo FROM m_HospitalDetails");
           return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, "SELECT CompanyId,CompanyName,EmailId,MobileNo,[Address],City,[State],Zip,Tin,CompanyLogo,BackupFolder FROM m_HospitalDetails");
        }
        public static DataSet GenerateBill(int BillId)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@BillId", BillId) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Report_GenerateBill", sqlParam);
        }
        public static DataSet GenerateReport(int BillId)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@BillId", BillId) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Report_GenerateTestReport", sqlParam);
        }
        public static DataSet ClosingStock()
        {
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Report_ClosingStock");
        }

        public static DataSet StockSummaryReport(ReportMap _rptMap)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@FromDate", _rptMap.FromDate),
                                        new SqlParameter("@ToDate", _rptMap.ToDate)};
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Report_StockSummary", sqlParam);
        }
        public static DataSet ProductSolds(ReportMap _rptMap)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@FromDate", _rptMap.FromDate),
                                        new SqlParameter("@ToDate", _rptMap.ToDate),
                                        new SqlParameter("@ProductID", _rptMap.strProduct)};
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Report_Productsolds", sqlParam);
        }
        public static DataSet ProductSoldBills(ReportMap _rptMap)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@FromDate", _rptMap.FromDate),
                                        new SqlParameter("@ToDate", _rptMap.ToDate),
                                        new SqlParameter("@ProductID", _rptMap.strProduct)};
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Report_ProductsSoldBills", sqlParam);
        }
        public static DataSet SupplierBillDetails(ReportMap _rptMap)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@FromDate", _rptMap.FromDate),
                                        new SqlParameter("@ToDate", _rptMap.ToDate)};
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "usp_Report_SupplierBillDetails", sqlParam);
        }
        #endregion
        public static DataSet SupplierWiseBillReport(ReportMap _rptMap)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@FromDate", _rptMap.FromDate),
                                        new SqlParameter("@ToDate", _rptMap.ToDate),
                                        new SqlParameter("@SupplierID", _rptMap.intSupplier)};
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Report_SupplierWiseBillReport", sqlParam);
        }
        public static DataSet SupplierWiseClosingStock(ReportMap _rptMap)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@SupplierID", _rptMap.intSupplier)};
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Report_SupplierWiseClosingStock", sqlParam);
        }
    }
}
