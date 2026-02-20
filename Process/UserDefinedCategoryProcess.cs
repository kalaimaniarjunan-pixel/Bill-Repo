using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalManagement.Map;
using System.Data.SqlClient;
using SalonFazia.Helper;
using System.Data;

namespace HospitalManagement.Process
{
    class UserDefinedCategoryProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void saveProcess(ref UserDefinedCategoryMap _categoryProp)
        {
            try
            {
                SqlParameter[] sqlParam = {new SqlParameter("@UDCategoryID", _categoryProp.intCategoryID),
                                      new SqlParameter("@UDCategory", _categoryProp.strCategory)};
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Save_UserDefinedCategories", sqlParam);
                _categoryProp.intCategoryID = Convert.ToInt32(sqlParam[0].Value);
                _categoryProp.strErrorMsg = "Sucessfuly Saved!";
                _categoryProp.isError = false;
            }
            catch (Exception ex)
            {
                _categoryProp.strErrorMsg = "Error.. " + ex.Message;
                _categoryProp.isError = true;
            }
        }
        public static DataSet selectProcess(int categoryID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@UDCategoryID", categoryID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_UserDefinedCategories", sqlParam);
        }
        public static DataSet selectDefinedOptions(string Category)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@UDCategory", Category) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_SelectOptions_UserDefinedCategories", sqlParam);
        }
    }
}
