using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    public class ReportMap
    {
        public string strReportName { get; set; }
        public int intEmployeeId { get; set; }
        public string strClientId { get; set; }
        public string strProduct { get; set; }
        public int intSupplier { get; set; }
        public string strService { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int intSerorProduct { get; set; }
        public int noofVisit { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public int intUserId { get; set; }
        public string strConnectionString { get; set; }
        public int intWorkstationID { get; set; }
        public int intLevelNo { get; set; }
        public int intPaymentMode { get; set; }
        public int intBillId { get; set; }
        public string strClientName { get; set; }
        public string strPhoneno { get; set; }
        public int intTop { get; set; }
    }
}
