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
    public partial class PatientInformation : Form
    {
        private PatientMap _patientMap = new PatientMap();
        //private string _gender = string.Empty;

        private string _gender = string.Empty, _saveFrom = string.Empty; // Newly Added by Ezhil Customer
        //private int count = 0;
        //private bool _isError = false;

        public PatientInformation()
        {
            InitializeComponent();
        }

        public PatientInformation(PatientMap objBAL)
        {
            InitializeComponent();
            _patientMap = objBAL;
            _saveFrom = "Customer Search";
            
        }

        private void PatientInformation_Load(object sender, EventArgs e)
        {
            txttin.Visible = false;
            fillDropDown();
            if(String.IsNullOrEmpty(txtId.Text))
            txtMobile.Text = _patientMap.Mobile.ToString();
            if (!String.IsNullOrEmpty(txtId.Text))
                loadPatient(txtId.Text);
            else
                txtId.Text = "";
            //txtMobile.Text =_patientMap.Mobile.ToString();
        }
        private void fillDropDown()
        {
            //Common.BindDropDownControl(cbBooldGroup, "Blood Group");
        }
        private void bttnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateControl())
                {
                    _patientMap.strPatientId = txtId.Text;
                    _patientMap.strPatientName = txtName.Text;
                    _patientMap.Mobile = Convert.ToInt64(txtMobile.Text);
                    _patientMap.strEmailId = txtEmailId.Text;
                    _patientMap.strAddress = rtbAddress.Text;
                    _patientMap.strGender = _gender;
                    if (!String.IsNullOrEmpty(txttin.Text.Trim()))
                        _patientMap.intPinNo = txttin.Text;
                    else
                        _patientMap.intPinNo ="0";



                    _patientMap.City = txtCity.Text;//Convert.ToInt32(cbBooldGroup.SelectedValue);
                    if (!String.IsNullOrEmpty(txtAge.Text.Trim()))
                        _patientMap.intAge = Convert.ToInt32(txtAge.Text);
                    else
                        _patientMap.intAge = 0;
                    _patientMap.strReferedBy = txtReferedBy.Text;
                    _patientMap.DOB = this.dtpDOB.Value;
                    _patientMap.RegDate = this.dtpRegDate.Value;

                    PatientProcess.InsertPatientDetails(ref _patientMap);
                    if (!_patientMap.isError)
                    {
                        MessageBox.Show(_patientMap.strErrorMsg, "Message");
                        //loadEmployee("" + _patientMap.intAge);
                       // closeForms();
                        // Newly Added by Ezhil Customer
                        if (_saveFrom == "Customer Search")
                        {
                            DataSet oDataSet = Common.searchPatient(_patientMap.strPatientId);
                            if (oDataSet.Tables[0].Rows.Count > 0)
                            {
                                this.Close();
                                BillInformation objForm = new BillInformation(oDataSet);
                                objForm.ShowDialog();
                            }

                        }
                        else
                        closeForms();
                        if (!String.IsNullOrEmpty(txtId.Text))
                            loadPatient(txtId.Text);
                        else
                            txtId.Text = "";                  
                        // Newly Added by Ezhil Customer
                    }
                    else
                    {
                        throw new Exception(_patientMap.strErrorMsg);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void loadPatient(string patID)
         {
            DataSet oDataset = PatientProcess.SelectProcess(patID);
            if (oDataset != null)
            {
                DataRow oRow = oDataset.Tables[0].Rows[0];
                txtId.Text = Convert.ToString(oRow["PatientID"]);
                txtName.Text = Convert.ToString(oRow["PatientName"]);
                txtMobile.Text = Convert.ToString(oRow["Mobile"]);
                txtEmailId.Text = Convert.ToString(oRow["Email"]);
                rtbAddress.Text = Convert.ToString(oRow["Address"]);
                string _gender = Convert.ToString(oRow["Gender"]);
                if (_gender == "Male")
                    rbMale.Checked = true;
                else if (_gender == "Female")
                    rbFemale.Checked = true;
                txtCity.Text = Convert.ToString(oRow["City"]);
                txtAge.Text = Convert.ToString(oRow["Age"]);
                txttin.Text = Convert.ToString(oRow["Tinno"]);
                txtReferedBy.Text = Convert.ToString(oRow["Referedby"]);
                dtpDOB.Text = Convert.ToString(oRow["DOB"]);
                dtpRegDate.Text = Convert.ToString(oRow["RegisterDate"]);
                txtId.Enabled = true;
                txtId.ReadOnly = true;
                //_isError = true;
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
            //if (String.IsNullOrEmpty(txtMobile.Text.Trim()))
            //{
            //    MessageBox.Show("Please Enter the Mobile No", "Message");
            //    txtMobile.Focus();
            //    return false;
            //}
            //if (txtMobile.Text.Trim().Length != 10)
            //{
            //    MessageBox.Show("Please Enter the 10 Digit Mobile No", "Message");
            //    txtMobile.Focus();
            //    return false;
            //}
            if (rbMale.Checked == false && rbFemale.Checked == false)
            {
                MessageBox.Show("Please Enter the Gender", "Message");
                return false;
            }
            if (String.IsNullOrEmpty(txtCity.Text.Trim()))
            {
                MessageBox.Show("Please Enter the City", "Message");
                txtCity.Focus();
                return false;
            }
            //if (String.IsNullOrEmpty(txtAge.Text.Trim()))
            //{
            //    MessageBox.Show("Please Enter the Age", "Message");
            //    txtAge.Focus();
            //    return false;
            //}
            //if (String.IsNullOrEmpty(txtReferedBy.Text.Trim()))
            //{
            //    MessageBox.Show("Please Enter the Reference", "Message");
            //    txtReferedBy.Focus();
            //    return false;
            //}
            return true;
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

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            closeForms();
        }

        private void PatientInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForms();
        }

        private void txtMobile_Leave(object sender, EventArgs e)
        {
            //if (!_isError)
            //{
            //    count = PatientProcess.CheckRecordByMobile(Convert.ToInt64(txtMobile.Text));
            //    if (count > 0)
            //    {
            //        MessageBox.Show("Existing Mobile No", "Message");
            //        closeForms();
            //    }
            //}
        }

        private void txtEmailId_Leave(object sender, EventArgs e)
        {
            //if (!_isError)
            //{
            //    count = PatientProcess.CheckRecordByEmail(txtEmailId.Text);
            //    if (count > 0)
            //    {
            //        MessageBox.Show("Existing Email Id", "Message");
            //        closeForms();
            //    }
            //}
        }

        private void chktin_CheckedChanged(object sender, EventArgs e)
        {
            if (chktin.Checked == true)
            {
                txttin.Visible = true;

            }
            else
            {
                if (chktin.Checked == false)
                txttin.Visible = false;
            }
        }

      

        //private void txtPinNo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
        //    {
        //        e.Handled = true;
        //    }
        //}

    }
}
