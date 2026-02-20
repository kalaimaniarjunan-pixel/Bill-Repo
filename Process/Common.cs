using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalManagement.Map;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using SalonFazia.Helper;
using System.IO;
using System.Configuration;
using Microsoft.Win32;

namespace HospitalManagement.Process
{
    class Common
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void BindDropDownControl(ComboBox ctrlCombo, string strCategoryName)
        {
            DataSet ds = UserDefinedCategoryProcess.selectDefinedOptions(strCategoryName);
            if (ds != null)
            {
                ctrlCombo.DataSource = ds.Tables[0];
                ctrlCombo.DisplayMember = "UdDescription";
                ctrlCombo.ValueMember = "UDID";
                ctrlCombo.SelectedIndex = 0;
            }
        }
        public static DataSet getAllFormList(int formID, int pageno, string filterValue)
        {
            SqlParameter[] sqlParam = {new SqlParameter("@FormID", formID),
                                      new SqlParameter("@PageNo",pageno), 
                                      new SqlParameter("@filterValue",filterValue)};
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_AllForm_List", sqlParam);
        }
        public static void DeleteRecord(ref DeleteMap _deleteMap)
        {
            try
            {
                SqlParameter[] sqlParam = {new SqlParameter("@PrimaryID", _deleteMap.strPrimaryID),
                                            new SqlParameter("@TableName", _deleteMap.strTableName)};
                SqlHelper.ExecuteNonQuery(_deleteMap.strConnectionString, CommandType.StoredProcedure, "USP_AllForm_Delete", sqlParam);
                _deleteMap.strErrorMsg = "Successfully Deleted!";
                _deleteMap.isError = false;
            }
            catch (Exception ex)
            {
                _deleteMap.strErrorMsg = "Error.. " + ex.Message;
                _deleteMap.isError = true;
            }
        }
        public static DataSet BindDropDownCategory()
        {
            string strSQL = "SELECT 0 AS UDDiseasesID, '-- Select Test--' AS UDDiseases UNION ALL SELECT UDDiseasesID,UDDiseases FROM m_UserDefinedDiseases WHERE REcordStatus <> 1";
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, strSQL);
        }
        public static DataSet BindDropDownSelectedDoctors(int Category)
        {
            string strSQL = "SELECT '0' AS DoctorID, '-- Select Doctor--' AS DoctorName UNION ALL SELECT DoctorID,DoctorName FROM m_DoctorDetails WHERE Categories ='" + Category + "'";
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, strSQL);
        }
        public static DataSet BindDropDownEmployeeId()
        {
            string strSQL = "SELECT '0' AS EmployeeID, '-- Select Employee--' AS EmployeeName UNION ALL SELECT EmployeeID,EmployeeName FROM m_EmployeeDetails WHERE REcordStatus <> 1";
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, strSQL);
        }
        public static void BindDropDownFromEmployeeForLogin(ComboBox cBoxUser, bool isLogin)
        {
            DataSet ds = new DataSet();
            if (isLogin)
                ds = LoginProcess.selectProcssForLogin();
            //else
                //ds = EmployeeProcess.selectProcssForChangePassowrd();
            if (ds != null)
            {
                DataTable oTable = new DataTable();
                oTable.Columns.Add("UserId");
                oTable.Columns.Add("UserName");
                DataRow oRow;
                oRow = oTable.NewRow();
                oRow["UserId"] = 0;
                oRow["UserName"] = "-- Select User --";
                oTable.Rows.Add(oRow);
                foreach (DataRow rRow in ds.Tables[0].Rows)
                {
                    oRow = oTable.NewRow();
                    oRow["UserId"] = rRow["UserId"];
                    oRow["UserName"] = rRow["UserName"];
                    oTable.Rows.Add(oRow);
                }
                cBoxUser.DataSource = oTable;
                cBoxUser.DisplayMember = "UserName";
                cBoxUser.ValueMember = "UserId";
                cBoxUser.SelectedIndex = 0;
            }
        }
        public static string encryptForpassword(string PlainText)
        {
            if (String.IsNullOrEmpty(PlainText)) return "";
            return HospitalCryptography.SalonEncrypt(PlainText, "Salon");
        }
        public static string decryptForpassword(string PlainText)
        {
            if (String.IsNullOrEmpty(PlainText)) return "";
            return HospitalCryptography.SalonDecrypt(PlainText, "Salon");
        }
        public static void insertLoginDetails(string UserId)
        {
            string strSQL = "INSERT INTO m_LogInfo(LoginDate,LoginTime,LoginUserID)Values(GETDATE(),GETDATE(),'" + UserId + "')";
            SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.Text, strSQL);
        }
        public static DataSet searchPatient(string SearchText)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@SearchText", SearchText) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Search_PatientDetails_ForBill", sqlParam);
        }
        public static DataSet getLoginDetails()
        {
            string strSQL = "SELECT LoginDate,LoginTime,LogoutTime,m_LoginTable.UserName FROM m_LogInfo " +
                "INNER JOIN m_LoginTable ON m_LogInfo.LoginUserID=m_LoginTable.UserId " +
                "WHERE CONVERT(VARCHAR(10),LoginDate,101) = CONVERT(VARCHAR(10),GETDATE(),101)";
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, strSQL);
        }
        public static DataSet getLoginDetails(DateTime seletedDate)
        {
            string strSQL = "SELECT LoginDate,LoginTime,LogoutTime,m_LoginTable.UserId FROM m_LogInfo " +
                "INNER JOIN m_LoginTable ON m_LogInfo.LoginUserID=m_LoginTable.UserId " +
                "WHERE DATEDIFF(day,CONVERT(VARCHAR, GETDATE(), 106), CONVERT(VARCHAR,'" + seletedDate + "',106))=0";
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, strSQL);
        }
        public static void UpdateLoginDetails()
        {
            string strSQL = "UPDATE m_LogInfo SET LogoutTime=GETDATE() WHERE LogInfoID=(SELECT MAX(LogInfoID) FROM m_LogInfo)";
            SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.Text, strSQL);
        }
        //public static void createBackUpDB()
        //{
        //    UpdateLoginDetails();
        //    DataSet oDs = HospitalProcess.selectProcss(0);
        //    if (oDs != null && oDs.Tables[0].Rows.Count > 0)
        //    {
        //        int strFolderName = Convert.ToInt32(oDs.Tables[0].Rows[0]["BackupFolder"]);
        //        int intCompanyId = Convert.ToInt32(oDs.Tables[0].Rows[0]["CompanyId"]);
        //        if (strFolderName > 0)
        //        {
        //            string strDBName = ConfigurationManager.AppSettings["DatabaseName"];
        //            //if (Directory.Exists(strBackupPath))
        //            //{
        //           // string strBackupPath = "C://BackupDBDontDeleteByApalisAdmin";
        //            string strBackupPath = "C://BackupDBDontDeleteByApalisAdmin";
        //            if (!Directory.Exists(strBackupPath))
        //            {
        //                Directory.CreateDirectory(strBackupPath);
        //            }
        //            strBackupPath = strBackupPath + "/" + strFolderName;
        //            if (!Directory.Exists(strBackupPath))
        //            {
        //                Directory.CreateDirectory(strBackupPath);
        //            }
        //            else
        //            {
        //                string[] filePaths = Directory.GetFiles(strBackupPath);
        //                foreach (string filePath in filePaths)
        //                    File.Delete(filePath);
        //            }
        //            strBackupPath = strBackupPath + "/HospitalProducts.Pages_" + DateTime.Now.Ticks + ".bak";
        //            string strSQL = "BACKUP DATABASE [" + strDBName + "] To Disk='" + strBackupPath + "'";
        //            SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.Text, strSQL);
        //            if (strFolderName == 5)
        //                strFolderName = 1;
        //            else
        //                strFolderName = strFolderName + 1;

        //            strSQL = "Update m_HospitalDetails SET BackupFolder=" + strFolderName + " WHERE CompanyId=" + intCompanyId;
        //            SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.Text, strSQL);
        //            //}
        //        }
        //    }
        //    //BackupDBDontDelete
        //}
        public static DateTime GetDateTime(string ipDate)
        {
            DateTime d = new DateTime();
            if (ipDate.IndexOf("/") > 0)
            {
                int intDayInd = ipDate.IndexOf("/");
                string strDay = ipDate.Substring(0, intDayInd);
                int intMonInd = ipDate.IndexOf("/", intDayInd + 1);
                string strMonth = ipDate.Substring(intDayInd + 1, intMonInd - (intDayInd + 1));
                string strYear = ipDate.Substring(intMonInd + 1);
                if (strYear != string.Empty && strMonth != string.Empty && strDay != string.Empty)
                {
                    d = new DateTime(Convert.ToInt32(strYear), Convert.ToInt32(strMonth), Convert.ToInt32(strDay));
                }
            }
            else if (ipDate.IndexOf("-") > 0)
            {
                int intDayInd = ipDate.IndexOf("-");
                string strDay = ipDate.Substring(0, intDayInd);
                int intMonInd = ipDate.IndexOf("-", intDayInd + 1);
                string strMonth = ipDate.Substring(intDayInd + 1, intMonInd - (intDayInd + 1));
                string strYear = ipDate.Substring(intMonInd + 1);
                d = new DateTime(Convert.ToInt32(strYear), Convert.ToInt32(strMonth), Convert.ToInt32(strDay));
            }
            return d;
        }
        public static DateTime GetDateTime(DateTime dtDate)
        {
            string lblDate = dtDate.Month + "/" + dtDate.Day + "/" + dtDate.Year;
            return Convert.ToDateTime(lblDate);
        }
        public static DataSet getAllFormExport(int formID, string filterValue)
        {
            SqlParameter[] sqlParam = {new SqlParameter("@FormID", formID),
                                      new SqlParameter("@filterValue",filterValue)};
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_AllForm_Export", sqlParam);
        }
        public static int getUDID(string CategoryName, string UDOName)
        {
            string strSQL = "SELECT UDID FROM vw_GetUDOValues WHERE UDCategory='" + CategoryName + "' AND UDDescription='" + UDOName + "'";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(hObj.connectionString, CommandType.Text, strSQL));
        }
        public static string GetStringDate(DateTime dtDate)
        {
            string lblDate = dtDate.Day + "-" + dtDate.Month + "-" + dtDate.Year;
            return lblDate;
        }
        public static string encryptForLicense(string PlainText)
        {
            return HospitalCryptography.SalonEncrypt(PlainText, "SalonLicense");
        }
        public static string decryptForLicense(string PlainText)
        {
            return HospitalCryptography.SalonDecrypt(PlainText, "SalonLicense");
        }
        public static string getProductSetupKey()
        {
            RegistryKey parentKey = Registry.CurrentUser.OpenSubKey(HospitalCryptography.SalonEncrypt("Salon", "SalonKey"));
            RegistryKey childKey = parentKey.OpenSubKey(HospitalCryptography.SalonEncrypt("Key", "SalonKey"));
            if (childKey != null)
                return (string)childKey.GetValue(HospitalCryptography.SalonEncrypt("ProductKey".ToUpper(), "SalonKey"));
            else
                return "";
        }
        public static void BindDropDownValues(ComboBox ctrlCombo, string DropDownName, string strCategoryName)
        {
            DataSet ds = getDropDownValues(DropDownName, strCategoryName);
            if (ds != null)
            {
                ctrlCombo.DataSource = ds.Tables[0];
                ctrlCombo.DisplayMember = "TextName";
                ctrlCombo.ValueMember = "Value";
            }
        }
        public static DataSet getDropDownValues(string DropDownName, string strCategoryName)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@DropDownName", DropDownName),
                                        new SqlParameter("@categoryName", strCategoryName) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_SelectOptions_DropDown", sqlParam);
        }
        //public static string leadingZeros(int numberText, int leadingSize)
        //{
        //    string returnZeros = string.Empty;
        //    int numLen = numberText.ToString().Length;
        //    for (int i = 0; i < leadingSize; i++)
        //    {
        //        if (i >= numLen)
        //        {
        //            returnZeros += "0";
        //        }
        //    }
        //    returnZeros += numberText;

        //    return returnZeros;
        //}
        public static string getRoleName(int UserID)
        {
            string strSQL = "SELECT RoleID FROM m_EmployeeInformation WHERE EmployeeID=" + UserID;
            int roleID = Convert.ToInt32(SqlHelper.ExecuteScalar(hObj.connectionString, CommandType.Text, strSQL));
            return getUDName(roleID);
        }
        public static string getUDName(int UDID)
        {
            string strSQL = "SELECT UDDescription FROM vw_GetUDOValues WHERE UDID=" + UDID;
            return Convert.ToString(SqlHelper.ExecuteScalar(hObj.connectionString, CommandType.Text, strSQL));
        }
        public static DataTable BindGridControl(string strCategoryName)
        {
            DataTable oTable = new DataTable();
            DataSet ds = UserDefinedCategoryProcess.selectDefinedOptions(strCategoryName);
            if (ds != null)
            {
                oTable.Columns.Add("UDId");
                oTable.Columns.Add("UdDescription");
                int i = 0;
                foreach (DataRow oRow in ds.Tables[0].Rows)
                {
                    if (i != 0)
                    {
                        DataRow oRow1 = oTable.NewRow();
                        oRow1["UDId"] = Convert.ToInt32(oRow["UDId"]);
                        oRow1["UdDescription"] = Convert.ToString(oRow["UdDescription"]);
                        oTable.Rows.Add(oRow1);
                    }
                    i++;
                }
            }
            return oTable;
        }
        public static bool isThermalPrinter()
        {
            string strQry = "SELECT ISNULL(isThermalPrinter, 0) FROM m_HospitalDetails";
            return Convert.ToBoolean(SqlHelper.ExecuteScalar(hObj.connectionString, CommandType.Text, strQry));
        }

        public static int getGRNProductQty(string productId)
        {
            string strSql = "SELECT ISNULL(ClosingQty,0) FROM UFN_GetClosingStockInformation() WHERE ProductId='" + productId + "' ";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(hObj.connectionString, CommandType.Text, strSql));
        }

        
       

    }
}
