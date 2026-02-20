using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class SalesReturnMap
    {
        public int intSalesReturnID { get; set; }
        public int intBillID { get; set; }
        public DateTime ReturnDate { get; set; }
        public int intPaymentType { get; set; }
        public List<SalesReturnDetailMap> DetailsMap { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public int intUserId { get; set; }
        public string strConnectionString { get; set; }
    }
}
