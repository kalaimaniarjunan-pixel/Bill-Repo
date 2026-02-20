using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class ExpensesDetailsMap
    {
        public int intExpensesDetailsID { get; set; }
        public int intExpensesID { get; set; }
        public int intExpensesDetails { get; set; }
        public decimal Amount { get; set; }
        public string strOther { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
    }
}
