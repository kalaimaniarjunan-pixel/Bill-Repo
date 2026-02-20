using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class GRNMap
    {
        public int intGRNNo { get; set; }
        public int intSupplierID { get; set; }
        public DateTime ReceiveDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ChangeAmount { get; set; }
        public decimal TenderAmount { get; set; }
        public decimal TotalPaid { get; set; }
        public int AddToAdvance { get; set; }
        public List<GRNDetailsMap> DetailsMap { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public int intUserId { get; set; }
        public string strConnectionString { get; set; }
        public string supplierinvoiceno { get; set; }
        
    }
    public class GRNObj
    {
        public string strObjId { get; set; }
        public string strObjName { get; set; }
        public string strObjType { get; set; }
        public string strUOM { get; set; }
        public decimal ObjTax { get; set; }
        public decimal ObjPrice { get; set; }
        public string strShortName { get; set; }
    }
}
