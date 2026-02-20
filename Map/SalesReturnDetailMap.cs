using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class SalesReturnDetailMap
    {
        public int intSalesReturnDetailID { get; set; }
        public int intSalesReturnID { get; set; }
        public string strProductID { get; set; }
        public decimal Price { get; set; }
        public int intQunatity { get; set; }
        public string strProductName { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public int intUserId { get; set; }
        public string strConnectionString { get; set; }
    }
}
