using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalManagement.Map;
using SalonFazia.Helper;
using System.Data.SqlClient;
using System.Data;

namespace HospitalManagement.Process
{
    class Expensesprocess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void saveProcess(ref ExpensesMap _expenseMap)
        {
            try
            {
                hObj = new HospitalSessionObjects();
                string strSQL = "SELECT COUNT(*) FROM s_Expenses Where CONVERT(VARCHAR(10),ExpensesDate,111)=CONVERT(VARCHAR(10),CONVERT(DATETIME,'" + _expenseMap.dtExpensesDate.ToShortDateString() + "',111),101)";
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(hObj.connectionString, CommandType.Text, strSQL));
                if (cnt == 0 || (_expenseMap.intExpensesID > 0 && Common.getRoleName(hObj.userID).ToLower() == "admin"))
                {
                    SqlConnection _oCon = new SqlConnection(hObj.connectionString);
                    _oCon.Open();
                    SqlTransaction _oTran = _oCon.BeginTransaction();
                    SqlCommand _oCmd;
                    SqlParameter[] sqlParam = {new SqlParameter("@ExpensesID", _expenseMap.intExpensesID),
                                      new SqlParameter("@ExpensesDate", _expenseMap.dtExpensesDate), 
                                      new SqlParameter("@ExpensesAmount", _expenseMap.ExpensesAmount),
                                      new SqlParameter("@ReceivedAmount", _expenseMap.ReceivedAmount),
                                      new SqlParameter("@intUserId",hObj.userID)};
                    sqlParam[0].Direction = ParameterDirection.InputOutput;
                    sqlParam[0].Size = 4;
                    SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Save_Expenses", sqlParam);
                    _expenseMap.intExpensesID = Convert.ToInt32(sqlParam[0].Value);

                    string strExpensesDetail = "";
                    foreach (ExpensesDetailsMap expenseDetailMap in _expenseMap.ExpenseDetails)
                    {
                        if (expenseDetailMap.intExpensesDetailsID != 0)
                            strExpensesDetail += expenseDetailMap.intExpensesDetailsID + ",";
                    }
                    if (!string.IsNullOrEmpty(strExpensesDetail))
                    {
                        strExpensesDetail = strExpensesDetail.Substring(0, strExpensesDetail.Length - 1);
                        _oCmd = new SqlCommand();
                        _oCmd.CommandText = "DELETE FROM s_ExpensesDetails Where ExpensesID =" + _expenseMap.intExpensesID + " AND ExpensesDetailID NOT IN (" + strExpensesDetail + ")";
                        _oCmd.Connection = _oCon;
                        _oCmd.Transaction = _oTran;
                        _oCmd.ExecuteNonQuery();
                    }
                    foreach (ExpensesDetailsMap expenseDetailMap in _expenseMap.ExpenseDetails)
                    {
                        SqlParameter[] newsqlParam = { new SqlParameter("@ExpensesDetailID", expenseDetailMap.intExpensesDetailsID), 
                                                new SqlParameter("@ExpensesID", _expenseMap.intExpensesID),
                                                new SqlParameter("@ExpensesDetails", expenseDetailMap.intExpensesDetails),
                                                new SqlParameter("@Amount", expenseDetailMap.Amount),
                                                new SqlParameter("@Other",expenseDetailMap.strOther),
                                                new SqlParameter("@UserID",hObj.userID)};
                        newsqlParam[0].Direction = ParameterDirection.InputOutput;
                        SqlHelper.ExecuteNonQuery(_oTran, CommandType.StoredProcedure, "USP_Save_ExpensesDetails", newsqlParam);
                        expenseDetailMap.intExpensesDetailsID = Convert.ToInt16(newsqlParam[0].Value);
                    }
                    _oTran.Commit();
                    _oCon.Close();
                    _expenseMap.strErrorMsg = "Sucessfuly Saved!";
                    _expenseMap.isError = false;
                }
                else
                {
                    _expenseMap.strErrorMsg = "Already Exists!";
                    _expenseMap.isError = true;
                }
            }
            catch (Exception ex)
            {
                _expenseMap.strErrorMsg = "Error.. " + ex.Message;
                _expenseMap.isError = true;
            }
        }
        public static DataSet selectProcess(int ExpensesID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@ExpensesID", ExpensesID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_Expenses", sqlParam);
        }
        public static DataSet selectDetailProcess(int ExpensesID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@ExpensesID", ExpensesID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_ExpensesDetails", sqlParam);
        }
    }
}
