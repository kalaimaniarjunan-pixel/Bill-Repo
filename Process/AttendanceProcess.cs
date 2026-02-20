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
    class AttendanceProcess
    {
        static HospitalSessionObjects hObj = new HospitalSessionObjects();
        public static void saveProcess(ref AttendanceMap _attendanceMap)
        {
            try
            {
                hObj = new HospitalSessionObjects();
                SqlParameter[] sqlParam = {new SqlParameter("@AttendanceID", _attendanceMap.intAttendanceID),
                                      new SqlParameter("@EmployeeID", _attendanceMap.EmployeeID), 
                                      new SqlParameter("@AttendanceDate",_attendanceMap.dtAttendanceDate),
                                      new SqlParameter("@ShiftID", _attendanceMap.intShiftID),
                                      new SqlParameter("@Status", _attendanceMap.Status),
                                      new SqlParameter("@isHalfDay",_attendanceMap.isHalfDay),
                                      new SqlParameter("@LeaveType",_attendanceMap.intLeaveType),
                                      new SqlParameter("@Reason",_attendanceMap.strReason)
                                          };
                sqlParam[0].Direction = ParameterDirection.InputOutput;
                sqlParam[0].Size = 4;
                SqlHelper.ExecuteNonQuery(hObj.connectionString, CommandType.StoredProcedure, "USP_Save_Attendance", sqlParam);
                _attendanceMap.intAttendanceID = Convert.ToInt32(sqlParam[0].Value);
                _attendanceMap.strErrorMsg = "Sucessfully Saved";
                _attendanceMap.isError = false;
            }
            catch (Exception ex)
            {
                _attendanceMap.strErrorMsg = "Error.. " + ex.Message;
                _attendanceMap.isError = true;
            }
        }
        public static DataSet selectProcess(int intAttendanceID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@AttendanceID", intAttendanceID) };
            return SqlHelper.ExecuteDataset(hObj.connectionString, CommandType.StoredProcedure, "USP_Select_Attendance", sqlParam);
        }
    }
}
