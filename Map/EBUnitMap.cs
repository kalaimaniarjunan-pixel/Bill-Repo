using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    public class EBUnitMap
    {
        public int EBUnitID { get; set; }
        public DateTime EBUnitDate { get; set; }
        public int StartMeterValue { get; set; }
        public int EndMeterValue { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
    }
}
