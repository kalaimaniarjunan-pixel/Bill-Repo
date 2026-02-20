using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    public class AttendanceMap
    {
        public int intAttendanceID { get; set; }
        public string EmployeeID { get; set; }
        public DateTime dtAttendanceDate { get; set; }
        public int intShiftID { get; set; }
        public string Status { get; set; }
        public bool isHalfDay { get; set; }
        public int intLeaveType { get; set; }
        public string strReason { get; set; }

        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
    }
}
