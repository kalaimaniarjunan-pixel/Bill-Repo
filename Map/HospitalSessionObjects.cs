using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using HospitalManagement.Process;

namespace HospitalManagement.Map
{
    class HospitalSessionObjects
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public string connectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }


        private int _userID = 0;  //Common.getUserID();    
       
        public int userID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private string _userName = ""; //Common.getUserName();
        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private int _roleID = 0; //Common.getRoleID();
        public int roleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }

        private int _exipiredDay = 0;
        public int exipiredDay
        {
            get { return _exipiredDay; }
            set { _exipiredDay = value; }
        }
        private bool _isWebPageEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["WebPageEnabled"]);

        public bool isWebPageEnabled
        {
            get { return _isWebPageEnabled; }
            set { _isWebPageEnabled = value; }
        }
    }
}
