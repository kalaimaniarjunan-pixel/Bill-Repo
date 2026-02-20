using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalonFazia.Helper;
using System.Data;
using HospitalManagement.Map;
using System.Data.SqlClient;

namespace HospitalManagement.Process
{
    class LoginProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static bool isValidLogin(LoginMap _loginMap)
        {
            string sql = "SELECT 1 AS Record FROM m_LoginTable WHERE UserId='" + _loginMap.strUserId + "' AND [PassWord]='" + Common.encryptForpassword(_loginMap.strPassword) + "'";
            int returnVal = Convert.ToInt32(SqlHelper.ExecuteScalar(hObj.connectionString, CommandType.Text, sql));
            if (returnVal == 1)
                return true;
            else
                return false;
        }
        public static int CheckPassWord(LoginMap _loginMap)
        {
            Int32 rowFound = 0;
            SqlParameter[] sqlParam = {new SqlParameter("@Output",""),
                                      new SqlParameter("@EmpId", _loginMap.strUserId),
                                      new SqlParameter("@PassWord", Common.encryptForpassword(_loginMap.strPassword))};
            sqlParam[0].Direction = ParameterDirection.InputOutput;
            SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_CheckPassword", sqlParam);
            return rowFound = Convert.ToInt32(sqlParam[0].Value);
        }
        public static void UpdatePassword(LoginMap _loginMap)
        {
            try
            {
                string sql = "Update m_LoginTable SET [Password]='" + Common.encryptForpassword(_loginMap.strPassword) + "' WHERE UserId='" + _loginMap.strUserId + "' ";
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.Text, sql);
                _loginMap.strErrorMsg = "Sucessfuly Updated!";
                _loginMap.isError = false;
            }
            catch (Exception ex)
            {
                _loginMap.strErrorMsg = "Error.. " + ex.Message;
                _loginMap.isError = true;
            }
        }
        public static DataSet selectProcssForLogin()
        {
            LoginMap _loginMap = new LoginMap();            
            string qry = "SELECT UserId,UserName FROM m_LoginTable  WHERE  RecordStatus<>1";
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, qry);
        }
    }
}
