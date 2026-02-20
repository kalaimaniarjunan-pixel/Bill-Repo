using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class CompanyMap
    {
        public int intCompanyID { get; set; }
        public string strCompanyName { get; set; }
        public string strAddress { get; set; }
        public string strCity { get; set; }
        public string strState { get; set; }
        public int intZipcode { get; set; }
        public string strPhoneNo { get; set; }
        public Int64 Mobileno { get; set; }
        public string strEmail { get; set; }
        public string strServiceTaxno { get; set; }
        public string strVatno { get; set; }
        public string strCstno { get; set; }
        public int intBackup { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public byte[] companyLogo { get; set; }
        public bool isThermalPrinter { get; set; }
        public bool isEnable { get; set; }
        public int inttaxcalc { get; set; }
    }
    public class DeleteMap
    {
        public string strTableName { get; set; }
        public string strPrimaryID { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public int intUserId { get; set; }
        public string strConnectionString { get; set; }
    }
}
