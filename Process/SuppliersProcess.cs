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
    class SuppliersProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();
        public static void saveProcess(ref SuppliersMap _supplierMap)
        {
            try
            {
                SqlParameter[] sqlParam = {new SqlParameter("@SupplierID", _supplierMap.intSupplierID),
                                      new SqlParameter("@SupplierName", _supplierMap.strSupplierName), 
                                      new SqlParameter("@Address",_supplierMap.strAddress),
                                      new SqlParameter("@City", _supplierMap.strCity),
                                      new SqlParameter("@State",_supplierMap.strState),
                                      new SqlParameter("@ZipCode",_supplierMap.intZipcode),
                                      new SqlParameter("@MobileNumber",_supplierMap.strMobilePhone),
                                      new SqlParameter("@Email", _supplierMap.strEmail),
                                      new SqlParameter("@Details",_supplierMap.strDetails),
                                      new SqlParameter("@UserID",hObj.userID)};
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Save_Suppliers", sqlParam);
                _supplierMap.intSupplierID = Convert.ToInt32(sqlParam[0].Value);
                _supplierMap.strErrorMsg = "Sucessfuly Saved!";
                _supplierMap.isError = false;
            }
            catch (Exception ex)
            {
                _supplierMap.strErrorMsg = "Error.. " + ex.Message;
                _supplierMap.isError = true;
            }
        }
        public static DataSet selectProcess(int suppliersID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@SupplierID", suppliersID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_Suppliers", sqlParam);
        }
        public static int number()
        {
            string strSQL = "SELECT COUNT(*) FROM s_Suppliers";
            string strCompanyCode = string.Empty;
            string result = Convert.ToString(SqlHelper.ExecuteScalar(hObj.connectionString, CommandType.Text, strSQL));
            return Convert.ToInt32(result);
        }
    }
}
