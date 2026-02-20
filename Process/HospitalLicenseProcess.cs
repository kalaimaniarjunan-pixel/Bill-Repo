using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalManagement.Map;
using SalonFazia.Helper;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagement.Process
{
    public class HospitalLicenseProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();
        public static void SaveProcess(HospitalLicenseMap _licenseMap)
        {
            try
            {
                string strSql = string.Empty;
                int rowCnt = 0;
                string connectionString = hObj.connectionString;
                _licenseMap.licenseKey = Common.encryptForLicense(licenseXML(_licenseMap));
                strSql = "Select COUNT(*) AS LicenseCount FROM m_HospitalLicense";
                rowCnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, CommandType.Text, strSql));
                if (rowCnt > 0)
                {
                    strSql = "DELETE FROM m_HospitalLicense";
                    SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, strSql);
                }
                strSql = "INSERT INTO m_HospitalLicense(LicenseStartDate,ExpireDate,NoOfDays,dayCounter,EncryptedKey) " +
                        " VALUES(@StartDate,@ExpiryDate,@NoofDays,@DayCounter,@licenseKey)";
                SqlParameter[] sqlParam = {new SqlParameter("@StartDate", _licenseMap.StartDate),
                                      new SqlParameter("@ExpiryDate", _licenseMap.ExpiryDate), 
                                      new SqlParameter("@NoofDays",_licenseMap.NoofDays),
                                      new SqlParameter("@DayCounter", _licenseMap.DayCounter),
                                      new SqlParameter("@licenseKey",_licenseMap.licenseKey)};
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, strSql, sqlParam);
                _licenseMap.strErrorMsg = "Sucessfuly Generated!";
                _licenseMap.isError = false;
            }
            catch (Exception ex)
            {
                _licenseMap.strErrorMsg = "Error.. " + ex.Message;
                _licenseMap.isError = true;
            }
        }
        public static void SaveSMSCount(HospitalSMSMap _smsMap)
        {
            try
            {
                string strSql = string.Empty;
                int rowCnt = 0;
                string connectionString = hObj.connectionString;

                strSql = "Select COUNT(*) AS SMSCount FROM S_SMSDETAILS";
                rowCnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, CommandType.Text, strSql));
                if (rowCnt == 0)
                {
                    strSql = "INSERT INTO s_SmsDetails VALUES(0)";
                    SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, strSql);
                }

                strSql = "UPDATE s_smsDetails SET SMSCOUNT=(select SMSCOUNT from s_Smsdetails)+@Count";
                SqlParameter[] sqlParam = { new SqlParameter("@Count", _smsMap.SMSCount) };
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, strSql, sqlParam);
                _smsMap.strErrorMsg = "Save Sucessfuly !";
                _smsMap.isError = false;
            }
            catch (Exception ex)
            {
                _smsMap.strErrorMsg = "Error.. " + ex.Message;
                _smsMap.isError = true;
            }
        }

        public static HospitalLicenseMap selectProcess()
        {
            string strSql = string.Empty;
            HospitalLicenseMap _licenseMap = new HospitalLicenseMap();
            strSql = "Select LicenseStartDate,ExpireDate,NoOfDays,dayCounter,EncryptedKey FROM m_HospitalLicense";



            DataTable dt = SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, strSql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                _licenseMap.StartDate = Convert.ToDateTime(dt.Rows[0]["LicenseStartDate"]);
                _licenseMap.ExpiryDate = Convert.ToDateTime(dt.Rows[0]["ExpireDate"]);
                _licenseMap.NoofDays = Convert.ToInt32(dt.Rows[0]["NoOfDays"]);
                _licenseMap.DayCounter = Convert.ToInt32(dt.Rows[0]["dayCounter"]);
                _licenseMap.licenseKey = Common.decryptForLicense(Convert.ToString(dt.Rows[0]["EncryptedKey"]));
            }
            return _licenseMap;
        }
        private static string licenseXML(HospitalLicenseMap _licenseMap)
        {
            StringBuilder returnXML = new StringBuilder();
            returnXML.Append("<SalonLicense>");
            returnXML.Append("<CompanyName>");
            returnXML.Append("<![CDATA[InterFazia]]>");
            returnXML.Append("</CompanyName>");
            returnXML.Append("<ProductName>");
            returnXML.Append("<![CDATA[Salon Fazia]]>");
            returnXML.Append("</ProductName>");
            returnXML.Append("<Package>");
            returnXML.Append("<![CDATA[" + _licenseMap.strProduct + "]]>");
            returnXML.Append("</Package>");
            returnXML.Append("<RegisterId>");
            returnXML.Append("<![CDATA[" + Common.getProductSetupKey() + "]]>");
            returnXML.Append("</RegisterId>");
            //returnXML.Append("<SystemIP>");
            //returnXML.Append("<![CDATA[" + Common.GetIP() + "]]>");
            //returnXML.Append("</SystemIP>");
            returnXML.Append("<StartDate>");
            returnXML.Append("<![CDATA[" + _licenseMap.StartDate.ToShortDateString() + "]]>");
            returnXML.Append("</StartDate>");
            returnXML.Append("<ExpiryDate>");
            returnXML.Append("<![CDATA[" + _licenseMap.ExpiryDate.ToShortDateString() + "]]>");
            returnXML.Append("</ExpiryDate>");
            returnXML.Append("<DayCounter>");
            returnXML.Append("<![CDATA[" + _licenseMap.DayCounter + "]]>");
            returnXML.Append("</DayCounter>");
            returnXML.Append("<Days>");
            returnXML.Append("<![CDATA[" + _licenseMap.NoofDays + "]]>");
            returnXML.Append("</Days>");
            returnXML.Append("<IsExpire>");
            returnXML.Append("<![CDATA[" + _licenseMap.isExpire + "]]>");
            returnXML.Append("</IsExpire>");
            returnXML.Append("</SalonLicense>");
            return returnXML.ToString();
        }
    }
}
