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
    class AdjustmentStockProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void saveProcess(ref AdjustmentStockMap _adjustmentProp)
        {
            try
            {
                SqlParameter[] sqlParam = {new SqlParameter("@adjustmentStockID", _adjustmentProp.intAdjustmentStockID),
                                      new SqlParameter("@ProductID", _adjustmentProp.strProductID), 
                                      new SqlParameter("@closingStock",_adjustmentProp.intClosingStock),
                                      new SqlParameter("@AdjustmentStock", _adjustmentProp.intAdjustmentStock),
                                      //new SqlParameter("@ProductName",_adjustmentProp.strProductname),
                                      new SqlParameter("@Total",_adjustmentProp.intTotal),
                                      new SqlParameter("@Reason",_adjustmentProp.strReason),
                                      new SqlParameter("@UserID",hObj.userID)};
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                sqlParam[0].Size = 4;
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Save_AdjustmentStock", sqlParam);
                _adjustmentProp.intAdjustmentStockID = Convert.ToInt32(sqlParam[0].Value);
                _adjustmentProp.strErrorMsg = "Sucessfully Saved";
                _adjustmentProp.isError = false;
                if (hObj.isWebPageEnabled)
                    createJSONObject(_adjustmentProp);
            }
            catch (Exception ex)
            {
                _adjustmentProp.strErrorMsg = "Error.. " + ex.Message;
                _adjustmentProp.isError = true;
            }
        }
        public static DataSet selectProcess(int intAdjustmentID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@adjustmentStockID", intAdjustmentID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_AdjustmentStock", sqlParam);
        }
        public static int getClosingStock(string ProductID)
        {
            int intStock = 0;
            string strSQL = "Select ClosingQty from UFN_GetClosingStockInformation() Where ProductID = '" + ProductID + "'";
            intStock = Convert.ToInt32(SqlHelper.ExecuteScalar(hObj.connectionString, CommandType.Text, strSQL));
            return intStock;
        }
        public static void createJSONObject(AdjustmentStockMap Map)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("{");
            strBuilder.Append("\"action\":\"Insert\",");
            strBuilder.Append("\"Table\":\"c_AdjustmentStock\",");
            strBuilder.Append("\"data\":{");
            strBuilder.Append("\"adjustmentStockID\":");
            strBuilder.Append(Map.intAdjustmentStockID + ",");
            strBuilder.Append("\"ProductID\":");
            strBuilder.Append("\"" + Map.strProductID + "\",");
            strBuilder.Append("\"closingStock\":");
            strBuilder.Append(Map.intClosingStock + ",");
            strBuilder.Append("\"AdjustmentStock\":");
            strBuilder.Append(Map.intAdjustmentStock + ",");
            strBuilder.Append("\"Total\":");
            strBuilder.Append(Map.intTotal + ",");
            strBuilder.Append("\"Reason\":");
            strBuilder.Append("\"" + Map.strReason + "\",");
            strBuilder.Append("\"RecordStatus\":");
            strBuilder.Append(0);
            strBuilder.Append("}");
            strBuilder.Append("}");

            string strSQL = "INSERT INTO s_RecordTransfer(CompanyCode,FormName,JSONData,SubmittedDate,SubmittedBy,IsProcess) VALUES('{0}','Adjustment Stock','{1}',GETDATE(),{2},0)";
            SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.Text, string.Format(strSQL, HospitalProcess.getCompanyCode(), strBuilder.ToString(), hObj.userID));
        }
    }
}
