using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class GRNDetailsMap
    {
        public int intGRNDetailsID { get; set; }
        public int intGRNNo { get; set; }
        public string strProductID { get; set; }
        public int intQty { get; set; }
        public decimal Price { get; set; }
        public decimal TaxinPercentage { get; set; }
        public decimal TotalAmount { get; set; }
        public string strProductName { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public int intUserId { get; set; }
        public string strConnectionString { get; set; }
        public string strShortName { get; set; }
    }
}
