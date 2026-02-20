using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    public class HospitalLicenseMap
    {
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int NoofDays { get; set; }
        public int DayCounter { get; set; }
        public string strProduct { get; set; }
        public string licenseKey { get; set; }
        public bool isExpire { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }

    }
    public class HospitalSMSMap
    {
        public int SMSCount { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
    }
}
