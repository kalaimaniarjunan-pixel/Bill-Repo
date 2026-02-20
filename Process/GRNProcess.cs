using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SalonFazia.Helper;
using HospitalManagement.Map;

namespace HospitalManagement.Process
{
    class GRNProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void saveProcess(ref GRNMap _GRNMap)
        {
            SqlConnection _oCon = new SqlConnection(hObj.connectionString);
            _oCon.Open();
            SqlTransaction _oTran = _oCon.BeginTransaction();
            SqlCommand _oCmd;
            try
            {
                SqlParameter[] sqlParam = { new SqlParameter("@GRNNo", _GRNMap.intGRNNo), 
                                          new SqlParameter("@SupplierID",_GRNMap.intSupplierID),
                                          new SqlParameter("@ReceiveDate", _GRNMap.ReceiveDate),
                                          new SqlParameter("@TotalAmount", _GRNMap.TotalAmount),
                                          new SqlParameter("@ChangeAmount", _GRNMap.ChangeAmount),
                                          new SqlParameter("@TenderAmount", _GRNMap.TenderAmount),
                                          new SqlParameter("@AddToAdvance", _GRNMap.AddToAdvance),
                                          new SqlParameter("@TotalPaid", _GRNMap.TotalPaid),
                                           new SqlParameter("@supplierinvoiceno", _GRNMap.supplierinvoiceno),
                                          new SqlParameter("@UserID",hObj.userID)};
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(_oTran, CommandType.StoredProcedure, "USP_Save_GRN", sqlParam);
                _GRNMap.intGRNNo = Convert.ToInt16(sqlParam[0].Value);
                string strGRNDetail = "";
                foreach (GRNDetailsMap _detailMap in _GRNMap.DetailsMap)
                {
                    if (_detailMap.intGRNDetailsID != 0)
                        strGRNDetail += _detailMap.intGRNDetailsID + ",";
                }
                if (!string.IsNullOrEmpty(strGRNDetail))
                {
                    strGRNDetail = strGRNDetail.Substring(0, strGRNDetail.Length - 1);
                    _oCmd = new SqlCommand();
                    _oCmd.CommandText = "DELETE FROM c_GRN_Details Where GRNNo =" + _GRNMap.intGRNNo + " AND GRNDetailID NOT IN (" + strGRNDetail + ")";
                    _oCmd.Connection = _oCon;
                    _oCmd.Transaction = _oTran;
                    _oCmd.ExecuteNonQuery();
                }
                foreach (GRNDetailsMap _detailMap in _GRNMap.DetailsMap)
                {
                    SqlParameter[] newsqlParam = { new SqlParameter("@GRNDetailID", _detailMap.intGRNDetailsID), 
                                                 //new  SqlParameter("@ProductName",_detailMap.strProductName),
                                                new SqlParameter("@GRNNo", _GRNMap.intGRNNo),
                                                new SqlParameter("@ProductID", _detailMap.strProductID),
                                                new SqlParameter("@Quantity", _detailMap.intQty),
                                                new SqlParameter("@Price",_detailMap.Price),
                                                new SqlParameter("@TaxinPercentage",_detailMap.TaxinPercentage),
                                                new SqlParameter("@TotalAmount", _detailMap.TotalAmount),
                                                new SqlParameter("@UserID",hObj.userID)
                                                 };
                    newsqlParam[0].Direction = ParameterDirection.InputOutput;
                    SqlHelper.ExecuteNonQuery(_oTran, CommandType.StoredProcedure, "USP_Save_GRNDetails", newsqlParam);
                    _detailMap.intGRNDetailsID = Convert.ToInt16(newsqlParam[0].Value);
                }
                _oTran.Commit();
                _oCon.Close();
                _GRNMap.strErrorMsg = "Successfully Saved!";
                _GRNMap.isError = false;
                //if (hObj.isWebPageEnabled)
                //    createJSONObject(_GRNMap);
            }
            catch (Exception ex)
            {
                _GRNMap.strErrorMsg = "Error.. " + ex.Message;
                _GRNMap.isError = true;
                _oTran.Rollback();
                if (ConnectionState.Open == _oCon.State)
                    _oCon.Close();
            }
        }
        public static DataSet selectProcess(int GRNNo)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@GRNNo", GRNNo) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_GRN", sqlParam);
        }
        public static DataSet selectDetailProcess(int GRNNo)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@GRNNo", GRNNo) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_GRNDetails", sqlParam);
        }
        public static DataSet selectBalProcess(int SupplierID)
        {
            //string strSQL = "SELECT ChangeAmount  FROM c_GRN WHERE SupplierID='" + SupplierID + "' AND RecordStatus<>1 AND AddToAdvance<>1 AND GRNNo =(SELECT MAX(GRNNo) FROM c_GRN)";
            string strSQL = "SELECT ChangeAmount FROM c_GRN WHERE GRNNo IN (SELECT MAX(GRNNo) FROM c_GRN WHERE SupplierID='" + SupplierID + "' AND RecordStatus <> 1 AND AddToAdvance <> 1)";
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, strSQL);
        }
    }
}
