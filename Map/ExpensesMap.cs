using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Map
{
    class ExpensesMap
    {
        public int intExpensesID { get; set; }
        public DateTime dtExpensesDate { get; set; }
        public decimal ExpensesAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public List<ExpensesDetailsMap> ExpenseDetails { get; set; }
        public bool isError { get; set; }
        public string strErrorMsg { get; set; }
    }
}
