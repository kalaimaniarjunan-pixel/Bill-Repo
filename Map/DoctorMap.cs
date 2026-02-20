using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class DoctorMap
    {
        public string strDoctorId { get; set; }
        public string strDoctorName { get; set; }
        public long Mobile { get; set; }
        public string strEmailId { get; set; }
        public string strAddress { get; set; }
        public string strGender { get; set; }
        public Int32 BloodGroup { get; set; }
        public Int32 intAge { get; set; }
        public Int32 intSpecialist { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        //public Int32 intRights { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
    }
}
