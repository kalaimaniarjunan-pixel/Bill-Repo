using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class AdjustmentStockMap
    {
        public int intAdjustmentStockID { get; set; }
        public string strProductID { get; set; }
        public int intClosingStock { get; set; }
        public string strProductname { get; set; }
        public int intAdjustmentStock { get; set; }
        public int intTotal { get; set; }
        public string strReason { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
    }
}
