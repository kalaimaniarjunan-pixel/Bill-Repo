using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalManagement.Map;
using System.Data;
using System.Data.SqlClient;
using SalonFazia.Helper;

namespace HospitalManagement.Process
{
    public static class EBUnitProcess
    {
        static HospitalSessionObjects sObj = new HospitalSessionObjects();
        public static void saveProcess(ref EBUnitMap _EBUnitMap)
        {
            try
            {
                string strSQL = "SELECT COUNT(*) FROM m_EBUnit Where CONVERT(VARCHAR(50),MeterDate,111)=CONVERT(VARCHAR(50),CONVERT(DATETIME,'" + _EBUnitMap.EBUnitDate.ToShortDateString() + "',111),101)";
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(sObj.connectionString, CommandType.Text, strSQL));
                if (cnt == 0)
                {
                    SqlParameter[] sqlParam = {new SqlParameter("@EBUnitID", _EBUnitMap.EBUnitID),
                                      new SqlParameter("@UnitDate", _EBUnitMap.EBUnitDate), 
                                      new SqlParameter("@Startmeter",_EBUnitMap.StartMeterValue),
                                      new SqlParameter("@Endmeter", _EBUnitMap.EndMeterValue),
                                      new SqlParameter("@intUserId",sObj.userID)};
                    sqlParam[0].Direction = ParameterDirection.InputOutput;
                    sqlParam[0].Size = 4;
                    SqlHelper.ExecuteNonQuery(sObj.connectionString, CommandType.StoredProcedure, "USP_Save_EBUnit", sqlParam);
                    _EBUnitMap.EBUnitID = Convert.ToInt32(sqlParam[0].Value);
                    _EBUnitMap.strErrorMsg = "Sucessfuly Saved!";
                    _EBUnitMap.isError = false;
                }
                else
                {
                    _EBUnitMap.strErrorMsg = "Already Exists!";
                    _EBUnitMap.isError = true;
                }
            }
            catch (Exception ex)
            {
                _EBUnitMap.strErrorMsg = "Error.. " + ex.Message;
                _EBUnitMap.isError = true;
            }
        }
        public static DataSet selectProcess(int EBUnitID)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@EBUnitID", EBUnitID) };
            return SqlHelper.ExecuteDataset(sObj.connectionString, CommandType.StoredProcedure, "USP_Select_EBUnit", sqlParam);
        }
    }
}
