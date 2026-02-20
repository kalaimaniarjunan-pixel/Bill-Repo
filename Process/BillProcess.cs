using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalManagement.Map;
using System.Data;
using System.Data.SqlClient;
using SalonFazia.Helper;

namespace HospitalManagement.Process
{
    class BillProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void saveProcess(ref BillMap _billMap)
        {
            SqlConnection _oCon = new SqlConnection(hObj.connectionString);
            _oCon.Open();
            SqlTransaction _oTran = _oCon.BeginTransaction();
            SqlCommand _oCmd = new SqlCommand(); ;
            _oCmd.Transaction = _oTran;
            hObj = new HospitalSessionObjects();
            long BillDetailsID = 0;
            try
            {
                SqlParameter[] sqlParam = { 
                                                new SqlParameter("@BillId", _billMap.intBillID),
                                                new SqlParameter("@BillDate", _billMap.dtBillDate),
                                                new SqlParameter("@PatientID", _billMap.strPatientID),
                                                new SqlParameter("@ProductList",_billMap.UDDiseases),
                                                new SqlParameter("@Category",_billMap.intCategory),
                                                new SqlParameter("@Status",_billMap.intStatus),
                                                new SqlParameter("@TypeOfPayment",_billMap.intTypeOfPayment),
                                                new SqlParameter("@Bankname",_billMap.intBankname),
                                                new SqlParameter("@CardNo",_billMap.strCardNo),
                                                new SqlParameter("@ChequeNo",_billMap.strChequeNo),
                                                new SqlParameter("@DiscountName",_billMap.strDiscountName),
                                                new SqlParameter("@DiscountAmount",_billMap.DiscountAmount),
                                                new SqlParameter("@TenderAmount",_billMap.TenderAmount),
                                                new SqlParameter("@Amount",_billMap.Amount),
                                            //    new SqlParameter("@Tax",_billMap.Tax),
                                                new SqlParameter("@Tax",_billMap.Tax),
                                                new SqlParameter("@Change",_billMap.Change),
                                                new SqlParameter("@NetAmount",_billMap.NetAmount),
                                                new SqlParameter("@AmountPaid",_billMap.AmountPaid),
                                                new SqlParameter("@AddToAdvance",_billMap.AddToAdvance),
                                                new SqlParameter("@DiscountPercent",_billMap.DiscountPercent)
                                          };
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(_oTran, CommandType.StoredProcedure, "USP_Save_Bill", sqlParam);
                _billMap.intBillID = Convert.ToInt16(sqlParam[0].Value);
                foreach (BillDetailsMap _detailMap in _billMap._listBillDetail)
                {
                    SqlParameter[] newsqlParam = { new SqlParameter("@BillDetailID", _detailMap.intBillDetailID), 
                                                new SqlParameter("@BillId", _billMap.intBillID),
                                                new SqlParameter("@PatientID", _billMap.strPatientID),
                                                new SqlParameter("@DoctorID", _detailMap.strDoctorID),
                                                new SqlParameter("@ProductID", _detailMap.ProductID),
                                                new SqlParameter("@ProductName",_detailMap.strProductName),
                                                new SqlParameter("@Qty",_detailMap.intQty),
                                                new SqlParameter("@Price",_detailMap.price),
                                                new SqlParameter("@Tax",_detailMap.Tax),
                                                new SqlParameter("@StGST",_detailMap.StGST),
                                                new SqlParameter("@StGSTAmt",_detailMap.StGSTAmt),
                                                new SqlParameter("@CtGST",_detailMap.CtGST),
                                                new SqlParameter("@CtGSTAmt",_detailMap.CtGSTAmt),
                                                new SqlParameter("@DiscountAmount",_detailMap.DiscountAmount),
                                                new SqlParameter("@DiscountPercent ",_detailMap.DiscountPercent),
                                                new SqlParameter("@NetAmount",_detailMap.intNetAmount)
                                                 };
                    newsqlParam[0].Direction = ParameterDirection.InputOutput;
                    SqlHelper.ExecuteNonQuery(_oTran, CommandType.StoredProcedure, "USP_Save_BillDetails", newsqlParam);
                    BillDetailsID = Convert.ToInt64(newsqlParam[0].Value);
                }
                
                _oTran.Commit();
                _oCon.Close();
                _billMap.strErrorMsg = "Successfully Saved!";
                _billMap.isError = false;
            }
            catch (Exception ex)
            {
                _billMap.strErrorMsg = "Error.. " + ex.Message + " trace " + ex.StackTrace;
                _billMap.isError = true;
                _oTran.Rollback();
                if (ConnectionState.Open == _oCon.State)
                    _oCon.Close();
            }
        }
        public static DataSet selectCustomerPrev(string PatientID, int BillID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@ClientID", PatientID),
                                        new SqlParameter("@BillID", BillID)};
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_ClientPrev", sqlParam);
        }

        public static DataSet selectCustomerPrevAdvance(string PatientID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@ClientID", PatientID)
                                        //new SqlParameter("@BillID", BillID)
                                      };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_ClientPrev1", sqlParam);
        }

        public static int cashBackProcess(decimal tender, string customerID)
        {
            //SqlParameter[] sqlParam = { new SqlParameter("@customerID", customerID),
            //                          new SqlParameter("@Tender", tender)};
            string strSQL = "UPDATE f_Bill SET ChangeAmount='" + tender + "' WHERE BillID = (SELECT MAX(BillID) FROM f_Bill WHERE PatientID = '" + customerID + "')";
            return SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.Text, strSQL);
        }

        public static DataSet selectProcessByFilter(DateTime dtFromDate, DateTime dtToDate, int statusID, int intPageno, string strFilter)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@FromDate", dtFromDate), 
                                        new SqlParameter("@ToDate", dtToDate),
                                        new SqlParameter("@StatusID",statusID),
                                        new SqlParameter("@PageNo", intPageno),
                                        new SqlParameter("@filterValue",strFilter)};
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_SelectBillsByFilter", sqlParam);
        }
        public static void cancelBillProcess(int billID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@BillID", billID) };
            SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Update_Bill", sqlParam);
        }
        public static void completeBillProcess(int billID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@BillID", billID) };
            SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "usp_UpdateCompletedStatus_Bill", sqlParam);
        }
        public static DataSet selectProcess(int billID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@BillID", billID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_Bill", sqlParam);
        }
        public static DataSet selectDetailProcess(int billID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@BillID", billID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_BillDetails", sqlParam);
        }
        public static DataSet selectTestDetailProcess(int billDetailsID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@BillDetailsID", billDetailsID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_PatientReport", sqlParam);
        }
        public static DataSet selectServiceProductProcess(string FilterContents)
        {
            SqlParameter[] sqlParam = { //new SqlParameter("@category", category), 
                                        //new SqlParameter("@FilterBy", FilterBy),
                                        new SqlParameter("@FilterContents",FilterContents)
                                        //new SqlParameter("@UOM",UOM),
                                        //new SqlParameter("@ShortKey",strShortfilter),
                                        //new SqlParameter("@memberNo",memberno)
                                      };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_GetServicesorProducts_Bill", sqlParam);
        }

        public static DataSet SelectPieceofQuantity(string ProductId)
        {
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, "select PieceQuantity from s_Products where ProductId='" + ProductId + "'");
        }

    }
}
