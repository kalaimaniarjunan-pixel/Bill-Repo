using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalManagement.Map;
using System.Data.SqlClient;
using System.Data;
using SalonFazia.Helper;

namespace HospitalManagement.Process
{
    class DoctorProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void InsertDoctorDetails(ref DoctorMap _doctorMap)
        {
            try
            {
                SqlParameter[] sqlParam = {new SqlParameter("@Output",""),new SqlParameter("@mode","ADD"),
                                       new SqlParameter("@DoctorID",_doctorMap.strDoctorId),
                                       new SqlParameter("@DoctorName",_doctorMap.strDoctorName),
                                       new SqlParameter("@Mobile",_doctorMap.Mobile),
                                       new SqlParameter("@Email",_doctorMap.strEmailId),
                                       new SqlParameter("@Address",_doctorMap.strAddress),
                                       new SqlParameter("@Gender",_doctorMap.strGender),
                                       new SqlParameter("@BloodGroup",_doctorMap.BloodGroup),
                                       new SqlParameter("@Age",_doctorMap.intAge),
                                       new SqlParameter("@Categories",_doctorMap.intSpecialist),
                                       new SqlParameter("@DOB",_doctorMap.DOB),
                                       new SqlParameter("@DOJ",_doctorMap.DOJ)
                                       };
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Manager_DoctorDetails", sqlParam);
                _doctorMap.intAge = Convert.ToInt32(sqlParam[0].Value);
                _doctorMap.strErrorMsg = "Employee details saved successfully!";
                _doctorMap.isError = false;
            }
            catch (Exception ex)
            {
                _doctorMap.strErrorMsg = "Error.. " + ex.Message;
                _doctorMap.isError = true;
            }
        }

        public static DataSet SelectProcess(string doctorID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@DoctorID", doctorID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_Doctor", sqlParam);
        }
    }
}
