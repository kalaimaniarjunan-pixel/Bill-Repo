using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HospitalManagement.Map;
using SalonFazia.Helper;
using System.Data.SqlClient;

namespace HospitalManagement.Process
{
    class ProductsProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void saveProcess(ref ProductsMap _ProductProp)
        {
            try
            {
                SqlParameter[] sqlParam = { new SqlParameter("@ProductId",_ProductProp.intProductID),
                                                 new SqlParameter("@Description",_ProductProp.strProductName),
                                                 new SqlParameter("@SupplierId", _ProductProp.intSupplierId), 
                                                // new SqlParameter("@SupplierName",string.Empty),
                                                 new SqlParameter("@SupplierName",_ProductProp.strSupplierName),
                                               //  new SqlParameter("@TypeofProduct",_ProductProp.strTypeofProduct),
                                                 new SqlParameter("@PieceQuantity",_ProductProp.intPieceQty),
                                                 new SqlParameter("@Uom",_ProductProp.intUOM),
                                                 new SqlParameter("@Price",_ProductProp.Price),
                                                 new SqlParameter("@Mrpprice",_ProductProp.Mrpprice),
                                                 new SqlParameter("@IsActive", _ProductProp.isActive),
                                                 new SqlParameter("@IsTaxable",_ProductProp.isTaxable),
                                                 new SqlParameter("@TaxAmount",_ProductProp.TaxAmount),
                                                 new SqlParameter("@StGST",_ProductProp.StGST),
                                                 new SqlParameter("@CtGST",_ProductProp.CtGST),
                                                 new SqlParameter("@UserID",hObj.userID),
                                                 new SqlParameter("@Hsnnumber",_ProductProp.strhsnnumber)
                                    };
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Save_Products", sqlParam);
                _ProductProp.strErrorMsg = "Sucessfuly Saved!";
                _ProductProp.isError = false;
            }
            catch (Exception ex)
            {
                _ProductProp.strErrorMsg = "Error.. " + ex.Message;
                _ProductProp.isError = true;
            }
        }
        public static DataSet selectProcess(string ProductId)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@ProductId", ProductId) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_Products", sqlParam);
        }
        public static DataSet supplierLoad()
        {
            string strQry = "SELECT '0' AS SupplierID, CONVERT(VARCHAR(100),'--Select Supplier Name--') AS SupplierName UNION ALL SELECT  SupplierID,SupplierName FROM s_Suppliers";
            DataSet dt = SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, strQry);
            return dt;
        }
        public static DataSet SameName(string ProductId)
        {
            string strSql = "select ProductId,Description,Price from s_Products where ProductId= '" + ProductId + "'";
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, strSql);
        }
        public static DataSet getProductStock(string ProductId)
        {
            string strSql = " SELECT UOMUDO.UDDescription AS UOMName,UFN_GetClosingStockInformation.ClosingQty AS Stock FROM s_Products " +
                     " LEFT JOIN UFN_GetClosingStockInformation() on UFN_GetClosingStockInformation.ProductId=s_Products.ProductId " +
                    " LEFT JOIN s_UserDefinedOptions UOMUDO ON UOMUDO.UDId=s_Products.UOM " +
                    " WHERE s_Products.ProductID ='" + ProductId + "'";
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.Text, strSql);
        }
    }
}
