using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class UserDefinedCategoryMap
    {
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public int intCategoryID { get; set; }
        public string strCategory { get; set; }
        public decimal Tax { get; set; }
        public decimal netAmount { get; set; }
        public string strConnectionString { get; set; }
    }
    public class PatientReportMap
    {
        public int intUDID { get; set; }
        public int intBillID { get; set; }
        public string Description { get; set; }
        public string Report { get; set; }
        public string Normal { get; set; }
        public decimal Amount { get; set; }
        public decimal NetAmount { get; set; }

        //public bool isError { get; set; }
        //public string strErrorMsg { get; set; }
        //public string strShortName { get; set; }
    }
}
