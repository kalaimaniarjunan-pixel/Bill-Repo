using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalManagement.Map;
using System.Data.SqlClient;
using System.Data;
using SalonFazia.Helper;
using System.Drawing;
using System.IO;

namespace HospitalManagement.Process
{
    class HospitalProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();
        public static void saveProcess(ref CompanyMap _companyMap)
        {
            try
            {

                SqlParameter[] sqlParam = {new SqlParameter("@Output",""),
                                      new SqlParameter("@CompanyID", _companyMap.intCompanyID),
                                      new SqlParameter("@CompanyName", _companyMap.strCompanyName), 
                                      new SqlParameter("@EmailId", _companyMap.strEmail),
                                      new SqlParameter("@Mobile",_companyMap.Mobileno),
                                      new SqlParameter("@Address",_companyMap.strAddress),
                                      new SqlParameter("@City", _companyMap.strCity),
                                      new SqlParameter("@State",_companyMap.strState),
                                      new SqlParameter("@ZipCode",_companyMap.intZipcode),
                                      new SqlParameter("@Logo",_companyMap.companyLogo),
                                      new SqlParameter("@Tin",_companyMap.strVatno)
                                          };
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Save_HospitlDetails", sqlParam);
                _companyMap.intCompanyID = Convert.ToInt32(sqlParam[0].Value);
                _companyMap.strErrorMsg = "Sucessfuly Saved!";
                _companyMap.isError = false;
            }
            catch (Exception ex)
            {
                _companyMap.strErrorMsg = "Error.. " + ex.Message;
                _companyMap.isError = true;
            }
        }
        public static DataSet selectProcss(int companyID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@CompanyID", companyID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_Hospital", sqlParam);
        }
        public static string getCompanyCode()
        {
            string strSQL = "SELECT ISNULL(CompanyID,'') As CompanyID FROM m_HospitalDetails";
            string strCompanyCode = string.Empty;
            strCompanyCode = Convert.ToString(SqlHelper.ExecuteScalar(hObj.connectionString, CommandType.Text, strSQL));
            return strCompanyCode;
        }
        public static Bitmap RetrieveImage()
        {
            string strSQL = "SELECT CompanyLogo FROM m_HospitalDetails WHERE S_NO = (SELECT MAX(S_NO) FROM m_HospitalDetails)";
            byte[] strCompanyLogo = null;Bitmap homeImage = null;
            strCompanyLogo = (byte[])(SqlHelper.ExecuteScalar(hObj.connectionString, CommandType.Text, strSQL));
            if (strCompanyLogo != null)
            {
                MemoryStream memoryStream = new MemoryStream(strCompanyLogo);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(memoryStream);
                if (memoryStream.CanRead)
                   homeImage = bmp;
            }
            return homeImage;
        }
    }
}
