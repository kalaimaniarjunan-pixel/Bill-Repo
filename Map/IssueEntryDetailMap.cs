using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class IssueEntryDetailMap
    {
        public int intIssueEntryDetailID { get; set; }
        public int intIssueEntryID { get; set; }
        public string strProductID { get; set; }
        public int intQty { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public int intUserId { get; set; }
        public string strConnectionString { get; set; }
    }
}
