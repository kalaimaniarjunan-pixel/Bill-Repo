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
    class VendorProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();
        public static void saveProcess(ref VendorMap _VendorMap)
        {
            try
            {
                SqlParameter[] sqlParam = {new SqlParameter("@VendorID", _VendorMap.intVendorID),
                                      new SqlParameter("@VendorName", _VendorMap.strVendorName), 
                                      new SqlParameter("@Address",_VendorMap.strAddress),
                                      new SqlParameter("@City", _VendorMap.strCity),
                                      new SqlParameter("@State",_VendorMap.strState),
                                      new SqlParameter("@ZipCode",_VendorMap.intZipcode),
                                      new SqlParameter("@MobileNumber",_VendorMap.strMobilePhone),
                                      new SqlParameter("@Email", _VendorMap.strEmail),
                                      new SqlParameter("@Details",_VendorMap.strDetails),
                                      new SqlParameter("@UserID",hObj.userID)};
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Save_Vendor", sqlParam);
                _VendorMap.intVendorID = Convert.ToInt32(sqlParam[0].Value);
                _VendorMap.strErrorMsg = "Sucessfuly Saved!";
                _VendorMap.isError = false;
            }
            catch (Exception ex)
            {
                _VendorMap.strErrorMsg = "Error.. " + ex.Message;
                _VendorMap.isError = true;
            }
        }
        public static DataSet selectProcess(int VendorID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@VendorID", VendorID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_Vendors", sqlParam);
        }
        public static int number()
        {
            string strSQL = "SELECT COUNT(*) FROM s_Vendors";
            string strCompanyCode = string.Empty;
            string result = Convert.ToString(SqlHelper.ExecuteScalar(hObj.connectionString, CommandType.Text, strSQL));
            return Convert.ToInt32(result);
        }
    }
}
