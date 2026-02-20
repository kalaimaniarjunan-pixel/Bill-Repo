using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class VendorMap
    {
        public int intVendorID { get; set; }
        public string strVendorName { get; set; }
        public string strVendorCode { get; set; }
        public string strEmail { get; set; }
        public string strAddress { get; set; }
        public string strCity { get; set; }
        public string strState { get; set; }
        public int intZipcode { get; set; }
        public string strMobilePhone { get; set; }
        public string strDetails { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public int intUserId { get; set; }
        public string strConnectionString { get; set; }
    }
}
