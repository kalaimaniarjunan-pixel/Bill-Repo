using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class SuppliersMap
    {
        public int intSupplierID { get; set; }
        public string strSupplierName { get; set; }
        public string strSupplierCode { get; set; }
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
