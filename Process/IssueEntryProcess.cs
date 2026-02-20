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
    class IssueEntryProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void saveProcess(ref IssueEntryMap _issueEntryProp)
        {
            SqlConnection _oCon = new SqlConnection(hObj.connectionString);
            _oCon.Open();
            SqlTransaction _oTran = _oCon.BeginTransaction();
            SqlCommand _oCmd;
            try
            {
                SqlParameter[] sqlParam = { new SqlParameter("@IssueEntryID", _issueEntryProp.intIssueEntryID), 
                                          new SqlParameter("@IssueDate",_issueEntryProp.strIssueEntryDate),
                                          new SqlParameter("@SupplierID",_issueEntryProp.intSupplierID),
                                          new SqlParameter("@UserID",hObj.userID)};
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(_oTran, CommandType.StoredProcedure, "USP_Save_IssueEntry", sqlParam);
                _issueEntryProp.intIssueEntryID = Convert.ToInt16(sqlParam[0].Value);
                string strIssueEntryDetail = "";
                foreach (IssueEntryDetailMap _detailMap in _issueEntryProp.DetailMap)
                {
                    if (_detailMap.intIssueEntryID != 0)
                        strIssueEntryDetail += _detailMap.intIssueEntryID + ",";
                }
                if (!string.IsNullOrEmpty(strIssueEntryDetail))
                {
                    strIssueEntryDetail = strIssueEntryDetail.Substring(0, strIssueEntryDetail.Length - 1);
                    _oCmd = new SqlCommand();
                    _oCmd.CommandText = "DELETE FROM c_IssueEntry_Details Where IssueEntry =" + _issueEntryProp.intIssueEntryID + " AND IssueEntryDetailID NOT IN (" + strIssueEntryDetail + ")";
                    _oCmd.Connection = _oCon;
                    _oCmd.Transaction = _oTran;
                    _oCmd.ExecuteNonQuery();
                }
                foreach (IssueEntryDetailMap _detailMap in _issueEntryProp.DetailMap)
                {
                    SqlParameter[] newsqlParam = { new SqlParameter("@IssueDetailEntryID", _detailMap.intIssueEntryDetailID), 
                                                new SqlParameter("@IssueEntryID", _issueEntryProp.intIssueEntryID),
                                                new SqlParameter("@ProductID", _detailMap.strProductID),
                                                new SqlParameter("@Quantity", _detailMap.intQty),
                                                new SqlParameter("@UserID",_issueEntryProp.intUserId)};
                    newsqlParam[0].Direction = ParameterDirection.InputOutput;
                    SqlHelper.ExecuteNonQuery(_oTran, CommandType.StoredProcedure, "USP_Save_IssueEntryDetail", newsqlParam);
                    _detailMap.intIssueEntryDetailID = Convert.ToInt16(newsqlParam[0].Value);
                }
                _oTran.Commit();
                _oCon.Close();
                _issueEntryProp.strErrorMsg = "Successfully Saved!";
                _issueEntryProp.isError = false;
                if (hObj.isWebPageEnabled)
                    createJSONObject(_issueEntryProp);
            }
            catch (Exception ex)
            {
                _issueEntryProp.strErrorMsg = "Error.. " + ex.Message;
                _issueEntryProp.isError = true;
                _oTran.Rollback();
                if (ConnectionState.Open == _oCon.State)
                    _oCon.Close();
            }
        }
        public static DataSet selectProcess(int IssueEntryID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@IssueEntryID", IssueEntryID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_IssueEntry", sqlParam);
        }
        public static DataSet selectDetailProcess(int IssueEntryID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@IssueEntryID", IssueEntryID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_IssueEntryDetails", sqlParam);
        }
        public static string ieJSONObj(IssueEntryMap Map)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("\"IssueEntryID\":");
            strBuilder.Append(Map.intIssueEntryID + ",");
            strBuilder.Append("\"IssueDate\":");
            strBuilder.Append("\"" + Common.GetDateTime(Map.strIssueEntryDate).ToShortDateString() + "\",");
            strBuilder.Append("\"RecordStatus\":");
            strBuilder.Append(0);
            return strBuilder.ToString();
        }

        public static void createJSONObject(IssueEntryMap Map)
        {
            foreach (IssueEntryDetailMap DetailsMap in Map.DetailMap)
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("{");
                strBuilder.Append("\"action\":\"Insert\",");
                strBuilder.Append("\"Table\":\"c_IssueEntry_Details\",");
                strBuilder.Append("\"data\":{");
                strBuilder.Append("\"IssueDetailEntryID\":");
                strBuilder.Append(DetailsMap.intIssueEntryDetailID + ",");
                strBuilder.Append("\"IssueEntryID\":{\"Table\":\"c_IssueEntry\",\"data\":{");
                strBuilder.Append(ieJSONObj(Map));
                strBuilder.Append("}},");
                strBuilder.Append("\"ProductID\":");
                strBuilder.Append("\"" + DetailsMap.strProductID + "\",");
                strBuilder.Append("\"Quantity\":");
                strBuilder.Append(DetailsMap.intQty);
                strBuilder.Append("}");
                strBuilder.Append("}");

                string strSQL = "INSERT INTO s_RecordTransfer(CompanyCode,FormName,JSONData,SubmittedDate,SubmittedBy,IsProcess) VALUES('{0}','IssueEntry','{1}',GETDATE(),{2},0)";
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.Text, string.Format(strSQL, HospitalProcess.getCompanyCode(), strBuilder.ToString(), hObj.userID));
            }
        }
    }
}
