using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class EmployeeMap
    {
        public string strEmployeeId { get; set; }
        public string strEmployeeName { get; set; }
        public long Mobile { get; set; }
        public string strEmailId { get; set; }
        public string strAddress { get; set; }
        public string strGender { get; set; }
        public Int32 intDesignation { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public long strSalary { get; set; }
        public Int32 intRights { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
    }
}
