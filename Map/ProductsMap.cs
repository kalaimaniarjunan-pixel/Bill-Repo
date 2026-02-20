using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class ProductsMap
    {
        public string intProductID { get; set; }
        public string strProductName { get; set; }
        public string strProductCode { get; set; }
        public int intSupplierId { get; set; }
        public int intPieceQty { get; set; }
        public int intUOM { get; set; }
        public decimal Mrpprice { get; set; }
        public decimal Price { get; set; }
        public int intStockInQty { get; set; }
        public bool isActive { get; set; }
        public bool isTaxable { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal StGST { get; set; }
        public decimal CtGST { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public int intUserId { get; set; }
        public string strConnectionString { get; set; }
        public string strBarCode { get; set; }
        public string strSupplierName { get; set; }
        public bool isBarcode { get; set; }
        public int intBarcode { get; set; }
        public string strShortName { get; set; }
        public string strhsnnumber { get; set; }
        public string strTypeofProduct { get; set; }
       
    }
}
