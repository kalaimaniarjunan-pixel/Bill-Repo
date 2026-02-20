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
    class SalesReturnProcess
    {
        static HospitalSessionObjects sObj = new HospitalSessionObjects();
        public static void saveProcess(ref SalesReturnMap _SalesReturnMap)
        {
            SqlConnection _oCon = new SqlConnection(sObj.connectionString);
            _oCon.Open();
            SqlTransaction _oTran = _oCon.BeginTransaction();
            SqlCommand _oCmd;
            try
            {
                SqlParameter[] sqlParam = { new SqlParameter("@SalesReturnID", _SalesReturnMap.intSalesReturnID), 
                                          new SqlParameter("@BillID",_SalesReturnMap.intBillID),
                                          new SqlParameter("@ReturnDate", _SalesReturnMap.ReturnDate),
                                          new SqlParameter("@PaymentType", _SalesReturnMap.intPaymentType),
                                          new SqlParameter("@UserID",sObj.userID)};
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(_oTran, CommandType.StoredProcedure, "USP_Save_SalesReturn", sqlParam);
                _SalesReturnMap.intSalesReturnID = Convert.ToInt16(sqlParam[0].Value);
                string strSalesReturnDetail = "";
                foreach (SalesReturnDetailMap _detailMap in _SalesReturnMap.DetailsMap)
                {
                    if (_detailMap.intSalesReturnDetailID != 0)
                        strSalesReturnDetail += _detailMap.intSalesReturnDetailID + ",";
                }
                if (!string.IsNullOrEmpty(strSalesReturnDetail))
                {
                    strSalesReturnDetail = strSalesReturnDetail.Substring(0, strSalesReturnDetail.Length - 1);
                    _oCmd = new SqlCommand();
                    _oCmd.CommandText = "DELETE FROM c_SalesReturn_Details Where SalesReturnID =" + _SalesReturnMap.intSalesReturnID + " AND SalesReturnDetailID NOT IN (" + strSalesReturnDetail + ")";
                    _oCmd.Connection = _oCon;
                    _oCmd.Transaction = _oTran;
                    _oCmd.ExecuteNonQuery();
                }
                foreach (SalesReturnDetailMap _detailMap in _SalesReturnMap.DetailsMap)
                {
                    SqlParameter[] newsqlParam = { new SqlParameter("@SalesReturnDetailID", _detailMap.intSalesReturnDetailID), 
                                                new SqlParameter("@SalesReturnID", _SalesReturnMap.intSalesReturnID),
                                                new SqlParameter("@ProductID", _detailMap.strProductID),
                                                 new SqlParameter("@ProductName", _detailMap.strProductName),
                                                new SqlParameter("@Price", _detailMap.Price),
                                                new SqlParameter("@Quantity",_detailMap.intQunatity),
                                                new SqlParameter("@UserID",_SalesReturnMap.intUserId)};
                    newsqlParam[0].Direction = ParameterDirection.InputOutput;
                    SqlHelper.ExecuteNonQuery(_oTran, CommandType.StoredProcedure, "USP_Save_SalesReturnDetails", newsqlParam);
                    _detailMap.intSalesReturnDetailID = Convert.ToInt16(newsqlParam[0].Value);
                }
                _oTran.Commit();
                _oCon.Close();
                _SalesReturnMap.strErrorMsg = "Successfully Saved!";
                _SalesReturnMap.isError = false;
                //if (sObj.isWebPageEnabled)
                //    createJSONObject(_SalesReturnMap);
            }
            catch (Exception ex)
            {
                _SalesReturnMap.strErrorMsg = "Error.. " + ex.Message;
                _SalesReturnMap.isError = true;
                _oTran.Rollback();
                if (ConnectionState.Open == _oCon.State)
                    _oCon.Close();
            }
        }
        public static DataSet selectProcess(int SalesReturnID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@SalesReturnID", SalesReturnID) };
            return SqlHelper.ExecuteDataset(sObj.connectionString, CommandType.StoredProcedure, "USP_Select_SalesReturn", sqlParam);
        }
        public static DataSet selectDetailProcess(int SalesReturnID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@SalesReturnID", SalesReturnID) };
            return SqlHelper.ExecuteDataset(sObj.connectionString, CommandType.StoredProcedure, "USP_Select_SalesReturnDetails", sqlParam);
        }
        public static DataSet selectSalesReturnBillId(int BillID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@BillID", BillID) };
            return SqlHelper.ExecuteDataset(sObj.connectionString, CommandType.StoredProcedure, "USP_Select_BillDetails_SalesReturn", sqlParam);
        }
        public static int checkExistingSaleReturn(int BillID)
        {
            string strQry = "select BillID from c_SalesReturn where BillID='" + BillID + "'";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sObj.connectionString, CommandType.Text, strQry));
        }
        //public static DataSet getProductName(string Id)
        //{
        //    string strQry = "select ProductName from s_products where productId='" + Id + "'";
        //    return SqlHelper.ExecuteDataset(sObj.connectionString, CommandType.Text, strQry);
        //}
        //public static int getProductId(string ProductName)
        //{
        //    string strQry = "select ProductId from s_products where productname='" + ProductName + "'";
        //    return Convert.ToInt32(SqlHelper.ExecuteScalar(sObj.connectionString, CommandType.Text, strQry));
        //}
    }
}
