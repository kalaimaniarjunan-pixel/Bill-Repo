using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalManagement.Map;
using System.Configuration;
using System.Data.SqlClient;
using SalonFazia.Helper;
using System.Data;

namespace HospitalManagement.Process
{
    class PatientProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();

        public static void InsertPatientDetails(ref PatientMap _patientMap)
        {
            try
            {
                SqlParameter[] sqlParam = {new SqlParameter("@Output",0),new SqlParameter("@mode","ADD"),
                                       new SqlParameter("@PatientID",_patientMap.strPatientId),
                                       new SqlParameter("@PatientName",_patientMap.strPatientName),
                                       new SqlParameter("@Mobile",_patientMap.Mobile),
                                       new SqlParameter("@EmailId",_patientMap.strEmailId),
                                       new SqlParameter("@Address",_patientMap.strAddress),
                                       new SqlParameter("@TinNo",_patientMap.intPinNo),
                                       new SqlParameter("@Gender",_patientMap.strGender),
                                       new SqlParameter("@City",_patientMap.City),
                                       new SqlParameter("@Age",_patientMap.intAge),
                                       new SqlParameter("@Referedby",_patientMap.strReferedBy),
                                       new SqlParameter("@DOB",_patientMap.DOB),
                                       new SqlParameter("@RegisterDate",_patientMap.RegDate)
                                       };
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Manager_PatientDetails", sqlParam);

                // Newly Added by Ezhil Customer
                Int32 AutoID = Convert.ToInt32(sqlParam[0].Value);
                string Query = "SELECT PatientID FROM m_patientdetails WHERE S_NO= '" + AutoID + "'";
                _patientMap.strPatientId = Convert.ToString(SqlHelper.ExecuteScalar(hObj.connectionString, CommandType.Text, Query));
                // Newly Added by Ezhil Customer

                //_patientMap.intAge = Convert.ToInt32(sqlParam[0].Value);
                _patientMap.strErrorMsg = "Customer details saved successfully!";
                _patientMap.isError = false;
            }
            catch (Exception ex)
            {
                _patientMap.strErrorMsg = "Error.. " + ex.Message;
                _patientMap.isError = true;
            }
        }

        public static DataSet SelectProcess(string patientID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@PatientID", patientID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_Patient", sqlParam);
        }
        public static int CheckRecordByMobile(Int64 Mobile)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@Output",""),new SqlParameter("@mode","MOBILE"),
                                        new SqlParameter("@Mobile", Mobile),
                                        new SqlParameter("@Email", string.Empty)};
            sqlParam[0].Direction = ParameterDirection.InputOutput;
            SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Checking_Exist_Record", sqlParam);
            return Convert.ToInt32(sqlParam[0].Value);
        }
        public static int CheckRecordByEmail(string Email)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@Output",""),new SqlParameter("@mode","EMAIL"),
                                         new SqlParameter("@Mobile", 0),
                                        new SqlParameter("@Email", Email)};
            sqlParam[0].Direction = ParameterDirection.InputOutput;
            SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Checking_Exist_Record", sqlParam);
            return Convert.ToInt32(sqlParam[0].Value);
        }
    }
}
