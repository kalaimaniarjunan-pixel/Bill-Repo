using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HospitalManagement.Map;
using HospitalManagement.Process;

namespace HospitalManagement.Pages
{
    public partial class EmployeeInformation : Form
    {
        private EmployeeMap _employeeMap = new EmployeeMap();
        private int _rights = 0;
        private string _gender = string.Empty;

        public EmployeeInformation()
        {
            InitializeComponent();
        }

        private void EmployeeInformation_Load(object sender, EventArgs e)
        {
            fillDropDown();
            if (!String.IsNullOrEmpty(txtId.Text))
                loadEmployee(txtId.Text);
            else
                txtId.Text = "";
        }

        private void fillDropDown()
        {
            Common.BindDropDownControl(cboxDesgination, "Designation");
        }

        private void bttnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateControl())
                {
                    _employeeMap.strEmployeeId = txtId.Text;
                    _employeeMap.strEmployeeName = txtName.Text;
                    _employeeMap.Mobile = Convert.ToInt64(txtMobile.Text);
                    _employeeMap.strEmailId = txtEmailId.Text;
                    _employeeMap.strAddress = rtbAddress.Text;
                    _employeeMap.strGender = _gender;
                    _employeeMap.intDesignation = Convert.ToInt32(cboxDesgination.SelectedValue);
                    _employeeMap.DOB = this.dtpDOB.Value;
                    _employeeMap.DOJ = this.dtpDOJ.Value;
                    if (!string.IsNullOrEmpty(txtSalary.Text))
                        _employeeMap.strSalary = Convert.ToInt64(txtSalary.Text);
                    else
                        _employeeMap.strSalary = 0;
                    _employeeMap.intRights = _rights;
                    if (bttnSave.Text == "Update")
                        _employeeMap.strErrorMsg = "UPDATE";
                    else
                        _employeeMap.strErrorMsg = "ADD";
                    EmployeeProcess.InsertEmployeeDetails(ref _employeeMap);
                    if (!_employeeMap.isError)
                    {
                        MessageBox.Show(_employeeMap.strErrorMsg, "Message");
                        //loadEmployee("" + _employeeMap.intAge);
                        closeForms();
                    }
                    else
                    {
                        throw new Exception(_employeeMap.strErrorMsg);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void loadEmployee(string empID)
        {
            DataSet oDataset = EmployeeProcess.SelectProcess(empID);
            if (oDataset != null)
            {
                DataRow oRow = oDataset.Tables[0].Rows[0];
                txtId.Text = Convert.ToString(oRow["EmployeeID"]);
                txtName.Text = Convert.ToString(oRow["EmployeeName"]);
                txtMobile.Text = Convert.ToString(oRow["Phone"]);
                txtEmailId.Text = Convert.ToString(oRow["Email"]);
                rtbAddress.Text = Convert.ToString(oRow["Address"]);
                string _gender = Convert.ToString(oRow["Gender"]);
                if (_gender == "Male")
                    rbMale.Checked = true;
                else if (_gender == "Female")
                    rbFemale.Checked = true;
                txtSalary.Text = Convert.ToString(oRow["Salary"]);
                cboxDesgination.SelectedValue = Convert.ToString(oRow["Designation"]);
                dtpDOB.Text = Convert.ToString(oRow["DatOfBirth"]);
                dtpDOJ.Text = Convert.ToString(oRow["JoiningDate"]);
                int right = Convert.ToInt32(oRow["Rights"]);
                if (right == 1)
                    ckBoxAddLogin.Checked = true;
                else
                    ckBoxAddLogin.Checked = false;
                txtId.Enabled = true;
                txtId.ReadOnly = true;
                bttnSave.Text = "Update";
            }
        }

        private bool validateControl()
        {
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Name", "Message");
                txtName.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtMobile.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Mobile No", "Message");
                txtMobile.Focus();
                return false;
            }
            if (txtMobile.Text.Trim().Length != 10)
            {
                MessageBox.Show("Please Enter the 10 Digit Mobile No", "Message");
                txtMobile.Focus();
                return false;
            }
            if (cboxDesgination.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Designation", "Message");
                cboxDesgination.Focus();
                return false;
            }
            if (rbMale.Checked == false && rbFemale.Checked == false)
            {
                MessageBox.Show("Please Enter the Gender", "Message");
                return false;
            }
            return true;
        }

        private void ckBoxAddLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBoxAddLogin.Checked == true)
            {
                _rights = 1;
            }
            else if (ckBoxAddLogin.Checked == false)
            {
                _rights = 0;
            }  
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                _gender = rbMale.Text;
            }  
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                _gender = rbFemale.Text;
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
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

        private void stripCancel_Click(object sender, EventArgs e)
        {
            closeForms();
        }

        private void EmployeeInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForms();
        }

    }
}
