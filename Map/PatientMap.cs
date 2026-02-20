using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    public class PatientMap
    {
        public string strPatientId { get; set; }
        public string strPatientName { get; set; }
        public long Mobile { get; set; }
        public string strEmailId { get; set; }
        public string strAddress { get; set; }
        public string strGender { get; set; }
        public Int32 BloodGroup { get; set; }
        public string City { get; set; }
        public Int32 intAge { get; set; }
        public string intPinNo { get; set; }
        public string strReferedBy { get; set; }
        public DateTime DOB { get; set; }
        public DateTime RegDate { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }

    }
}
