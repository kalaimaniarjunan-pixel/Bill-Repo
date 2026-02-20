using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalManagement.Map;
using System.Data.SqlClient;
using SalonFazia.Helper;
using System.Data;

namespace HospitalManagement.Process
{
    class EmployeeProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void InsertEmployeeDetails(ref EmployeeMap _employeeMap)
        {
            try
            {
                SqlParameter[] sqlParam = {new SqlParameter("@Output",""),
                                       new SqlParameter("@mode",_employeeMap.strErrorMsg),
                                       new SqlParameter("@EmployeeId",_employeeMap.strEmployeeId),
                                       new SqlParameter("@EmployeeName",_employeeMap.strEmployeeName),
                                       new SqlParameter("@Phone",_employeeMap.Mobile),
                                       new SqlParameter("@Email",_employeeMap.strEmailId),
                                       new SqlParameter("@Address",_employeeMap.strAddress),
                                       new SqlParameter("@Gender",_employeeMap.strGender),
                                       new SqlParameter("@Desg",_employeeMap.intDesignation),
                                       new SqlParameter("@Salary",_employeeMap.strSalary),
                                       new SqlParameter("@Rights",_employeeMap.intRights),
                                       new SqlParameter("@DateOfBirth",_employeeMap.DOB),
                                       new SqlParameter("@JoiningDate",_employeeMap.DOJ)
                                       };
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Manager_EmployeeDetails", sqlParam);
                _employeeMap.intRights = Convert.ToInt32(sqlParam[0].Value);
                _employeeMap.strErrorMsg = "Employee details saved successfully!";
                _employeeMap.isError = false;
            }
            catch (Exception ex)
            {
                _employeeMap.strErrorMsg = "Error.. " + ex.Message;
                _employeeMap.isError = true;
            }
        }

        public static DataSet SelectProcess(string employeeID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@EmployeeID", employeeID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_Employee", sqlParam);
        }
    }
}
