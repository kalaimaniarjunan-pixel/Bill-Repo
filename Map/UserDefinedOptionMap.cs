using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    public class UserDefinedOptionMap
    {
        public int UDId { get; set; }
        public string ProductID { get; set; }
        public string UDDescription { get; set; }
        public int UDCategoryID { get; set; }
        public int Qty { get; set; }
        //public int TestCount { get; set; }
        public string Report { get; set; }
        public string Normal { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public decimal Price { get; set; }
        public decimal amount { get; set; }
        public decimal Tax { get; set; }
        public decimal StGST { get; set; }
        public decimal CtGST { get; set; }
        public decimal netAmount { get; set; }
        public decimal discount { get; set; }
        public decimal discountvalue { get; set; }
        public List<PatientReportMap> _listPatientReport { get; set; }
    }
}
