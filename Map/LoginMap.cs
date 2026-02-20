using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class LoginMap
    {
        public string strPassword { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
        public string strUserId { get; set; }
        public string strConnectionString { get; set; }
    }
}
