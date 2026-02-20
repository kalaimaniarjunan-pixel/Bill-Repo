using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HospitalManagement.Map;
using System.Data.SqlClient;
using SalonFazia.Helper;

namespace HospitalManagement.Process
{
    class UserDefinedDiseasesProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void saveProcess(ref UserDefinedCategoryMap _categoryProp)
        {
            try
            {
                SqlParameter[] sqlParam = {
                                          new SqlParameter("@UDDiseasesID", _categoryProp.intCategoryID),
                                          new SqlParameter("@UDDiseases", _categoryProp.strCategory),
                                          new SqlParameter("@Tax", _categoryProp.Tax)
                                          };
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Save_UserDefinedDiseases", sqlParam);
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
        public static DataSet selectProcess(int diseasesID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@UDDiseasesID", diseasesID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_UserDefinedDiseases", sqlParam);
        }
        public static DataSet selectProcessLookup(int UDDiseaseID)
        {
            string strSQL = "SELECT UDDiseasesID,UDDiseases,Tax FROM m_UserDefinedDiseases WHERE UDDiseasesID='" + UDDiseaseID + "'";
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, strSQL);
        }
    }
}
