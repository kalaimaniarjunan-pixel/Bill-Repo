using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalManagement.Map;
using System.Data;
using SalonFazia.Helper;
using System.Data.SqlClient;

namespace HospitalManagement.Process
{
    class UserDefinedTestProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void saveProcess(ref UserDefinedOptionMap _OptionProp)
        {
            try
            {
                SqlParameter[] sqlParam = {new SqlParameter("@UDTestId", _OptionProp.UDId),
                                           new SqlParameter("@UDTestDescription", _OptionProp.UDDescription),
                                           new SqlParameter("@UDDiseasesID", _OptionProp.UDCategoryID),
                                           new SqlParameter("@Normal", _OptionProp.Normal),
                                           new SqlParameter("@Amount", _OptionProp.amount),
                                           new SqlParameter("@NetAmount", _OptionProp.netAmount)
                                          };
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Save_UserDefinedTest", sqlParam);
                _OptionProp.UDId = Convert.ToInt32(sqlParam[0].Value);
                _OptionProp.strErrorMsg = "Sucessfuly Saved!";
                _OptionProp.isError = false;
            }
            catch (Exception ex)
            {
                _OptionProp.strErrorMsg = "Error.. " + ex.Message;
                _OptionProp.isError = true;
            }
        }
        public static DataSet selectProcess(int UDTestID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@UDTestID", UDTestID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_UserDefinedTest", sqlParam);
        }
        public static DataSet selectProcessLookup(int UDDiseasesID)
        {
            string strSQL = "SELECT UDDiseasesID,UDTestDescription,'' AS Report,Normal,Amount,NetAmount FROM s_UserDefinedTest WHERE RecordStatus <> 1 AND UDDiseasesID='" + UDDiseasesID + "'";
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, strSQL);
        }
        public static void DeleteTest(int UDTestID)
        {
            string strSQL = "UPDATE s_UserDefinedTest SET RecordStatus=1 WHERE UDTestId='" + UDTestID + "'";
            SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.Text, strSQL);
        }
    }
}
