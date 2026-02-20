using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class IssueEntryMap
    {
        public int intIssueEntryID { get; set; }
        public DateTime strIssueEntryDate { get; set; }
        public int intSupplierID { get; set; }
        public List<IssueEntryDetailMap> DetailMap { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public int intUserId { get; set; }
        public string strConnectionString { get; set; }
    }
}
