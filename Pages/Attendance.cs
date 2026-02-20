using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HospitalManagement.Process;
using HospitalManagement.Map;

namespace HospitalManagement.Pages
{
    public partial class Attendance : Form
    {
        private DataSet oDataSet = null;
        private bool isHalfDay = false;
        private string Status;
        private AttendanceMap _attenMap = new AttendanceMap();
        public Attendance()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateControl())
            {
                _attenMap.intAttendanceID = Convert.ToInt32(txtAttendaceId.Text);
                _attenMap.EmployeeID = cBoxEmpId.SelectedValue.ToString();
                _attenMap.dtAttendanceDate = dtpDate.Value;
                _attenMap.intShiftID = Convert.ToInt32(cBShift.SelectedValue);
                _attenMap.Status = Status;
                _attenMap.intLeaveType = Convert.ToInt32(cBLeaveType.SelectedValue);
                _attenMap.isHalfDay = isHalfDay;
                _attenMap.strReason = txtReason.Text;

                AttendanceProcess.saveProcess(ref _attenMap);
                if (!_attenMap.isError)
                {
                    MessageBox.Show(_attenMap.strErrorMsg, "Message");
                    //loadEmployee("" + _doctorMap.intAge);
                    closeForms();
                }
                else
                {
                    throw new Exception(_attenMap.strErrorMsg);
                }
            }
        }
        private bool validateControl()
        {
            if (cBoxEmpId.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Employee Id.....", "Message");
                cBoxEmpId.Focus();
                return false;
            }
            if (rbPresent.Checked)
            {
                if (cBShift.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Shift.....", "Message");
                    cBShift.Focus();
                    return false;
                }
            }
            if (rbLeave.Checked)
            {
                if (cBLeaveType.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Leave Type", "Message");
                    cBLeaveType.Focus();
                    return false;
                }
            }
            return true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            closeForms();
        }
        private void closeForms()
        {
            FormCollection fc = Application.OpenForms;
            if (fc["Home"].IsDisposed != true)
            {
                ((Home)fc["Home"]).cancelChildForm();
            }
            this.Close();
        }
        private void rbPresent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPresent.Checked)
            {
                Status = "Present";
                gBLeaveType.Enabled = false;
            }
        }

        private void rbLeave_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLeave.Checked)
            {
                Status = "Absent";
                gBLeaveType.Enabled = true;
                cBShift.Enabled = false;
            }
        }
        private void fillDropDown()
        {
            Common.BindDropDownControl(cBShift, "Shift");
            Common.BindDropDownControl(cBLeaveType, "Leave Type");
        }
        private void Attendance_Load(object sender, EventArgs e)
        {
            fillDropDown();
            rbPresent.Checked = true;
            oDataSet = Common.BindDropDownEmployeeId();
            if (oDataSet != null)
            {
                cBoxEmpId.DataSource = oDataSet.Tables[0];
                cBoxEmpId.DisplayMember = "EmployeeName";
                cBoxEmpId.ValueMember = "EmployeeID";
                cBoxEmpId.SelectedIndex = 0;
            }

            if (!String.IsNullOrEmpty(txtAttendaceId.Text))
                loadAttendanceDetails();
            else
                txtAttendaceId.Text = "0";
        }

        private void chBoxHalfDay_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxHalfDay.Checked)
            {
                isHalfDay = true;
            }
            else
            {
                isHalfDay = false;
            }
        }
        private void loadAttendanceDetails()
        {
            DataSet oDataset = AttendanceProcess.selectProcess(Convert.ToInt32(txtAttendaceId.Text));
            if (oDataset != null)
            {
                string _status = string.Empty;
                DataRow oRow = oDataset.Tables[0].Rows[0];
                _status = Convert.ToString(oRow["EmployeeID"]);
                 cBoxEmpId.SelectedValue = _status;
                dtpDate.Text = Convert.ToString(oRow["AttendanceDate"]);
                cBShift.SelectedValue = Convert.ToInt32(oRow["ShiftID"]);
                _status = Convert.ToString(oRow["Status"]);
                if (_status == "Present")
                    rbPresent.Checked = true;
                else
                    rbLeave.Checked = true;
                cBLeaveType.SelectedValue = Convert.ToString(oRow["LeaveType"]);
                int _isHalfDay = Convert.ToInt32(oRow["isHalfDay"]);
                if (_isHalfDay == 1)
                    chBoxHalfDay.Checked = true;
                else
                    chBoxHalfDay.Checked = false;
                txtReason.Text = Convert.ToString(oRow["Reason"]);
                btnSave.Enabled = false;
                //txtId.Enabled = true;
                //txtId.ReadOnly = true;
                //btnSave.Text = "Update";
            }
        }
    }
}
