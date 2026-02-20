using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class BillMap
    {
        //public int intBillID { get; set; }
        public int intBillID { get; set; }
        public DateTime dtBillDate { get; set; }
        public string strPatientID { get; set; }
        public string UDDiseases { get; set; }
        public int intCategory { get; set; }
        public int intStatus { get; set; }
        public int intTypeOfPayment { get; set; }
        public int intBankname { get; set; }
        public string strCardNo { get; set; }
        public string strChequeNo { get; set; }
        public string strDiscountName { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal TenderAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public decimal Change { get; set; }
        public decimal NetAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public string strShortName { get; set; }
        public decimal TotalAmount { get; set; }
        public int AddToAdvance { get; set; }
        public List<BillDetailsMap> _listBillDetail { get; set; }
        
    }
}
