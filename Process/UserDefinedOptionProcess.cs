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
    class UserDefinedOptionProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void saveProcess(ref UserDefinedOptionMap _OptionProp)
        {
            try
            {
                SqlParameter[] sqlParam = {new SqlParameter("@UDId", _OptionProp.UDId),
                                           new SqlParameter("@UDDescription", _OptionProp.UDDescription),
                                           new SqlParameter("@UDCategoryID", _OptionProp.UDCategoryID),
                                           new SqlParameter("@Normal", _OptionProp.Normal),
                                           new SqlParameter("@Amount", _OptionProp.amount)
                                           //new SqlParameter("@AmountinPercent", _OptionProp.amountInPercent)
                                          };
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Save_UserDefinedOptions", sqlParam);
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
        public static DataSet selectProcess(int UDCategoryID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@UDCategoryID", UDCategoryID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_UserDefinedOptions", sqlParam);
        }
        public static void DeleteOption(int UDId)
        {
            string strSQL = "UPDATE s_UserDefinedOptions SET RecordStatus=1 WHERE UDId='" + UDId + "'";
            SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.Text, strSQL);
        }
    }
}
