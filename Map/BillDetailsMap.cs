using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class BillDetailsMap
    {
        public long intBillDetailID { get; set; }
        public long intBillID { get; set; }
        public int intMemberType { get; set; }
        public bool ismemberUsed { get; set; }
        public string ProductID { get; set; }
        public string strDoctorID { get; set; }
        public string strServiceID { get; set; }
        public string strDiseaseName { get; set; }
        public string strProductName { get; set; }
        public int intTestCount { get; set; }
        public int intQty { get; set; }
        public decimal price { get; set; }
        public decimal Tax { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal StGST { get; set; }
        public decimal StGSTAmt { get; set; }
        public decimal CtGST { get; set; }
        public decimal CtGSTAmt { get; set; }
        public decimal discount { get; set; }
        public decimal intDiscountPercent { get; set; }
        public decimal intNetAmount { get; set; }
        public int cardno { get; set; }
        public DateTime dtTime { get; set; }
        //public string strType { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public string strShortName { get; set; }
        public List<PatientReportMap> _listPatientReport { get; set; }
    }
}
