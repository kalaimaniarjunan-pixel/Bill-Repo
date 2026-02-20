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
    public partial class DoctorInformation : Form
    {
        private DoctorMap _doctorMap = new DoctorMap();
        private string _gender = string.Empty;

        public DoctorInformation()
        {
            InitializeComponent();
        }

        private void DoctorInformation_Load(object sender, EventArgs e)
        {
            fillDropDown();
            if (!String.IsNullOrEmpty(txtId.Text))
                loadEmployee(txtId.Text);
            else
                txtId.Text = "";
        }
        private void bttnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateControl())
                {
                    _doctorMap.strDoctorId = txtId.Text;
                    _doctorMap.strDoctorName = txtName.Text;
                    _doctorMap.Mobile = Convert.ToInt64(txtMobile.Text);
                    _doctorMap.strEmailId = txtEmailId.Text;
                    _doctorMap.strAddress = rtbAddress.Text;
                    _doctorMap.strGender = _gender;
                    _doctorMap.BloodGroup = Convert.ToInt32(cbBooldGroup.SelectedValue);
                    if (String.IsNullOrEmpty(txtAge.Text.Trim()))
                        _doctorMap.intAge = Convert.ToInt32(txtAge.Text);
                    else
                        _doctorMap.intAge = 0;
                    _doctorMap.intSpecialist = Convert.ToInt32(cbSpecialist.SelectedValue);
                    _doctorMap.DOB = this.dtpDOB.Value;
                    _doctorMap.DOJ = this.dtpDOJ.Value;

                    DoctorProcess.InsertDoctorDetails(ref _doctorMap);
                    if (!_doctorMap.isError)
                    {
                        MessageBox.Show(_doctorMap.strErrorMsg, "Message");
                        //loadEmployee("" + _doctorMap.intAge);
                        closeForms();
                    }
                    else
                    {
                        throw new Exception(_doctorMap.strErrorMsg);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void loadEmployee(string docID)
        {
            DataSet oDataset = DoctorProcess.SelectProcess(docID);
            if (oDataset != null)
            {
                DataRow oRow = oDataset.Tables[0].Rows[0];
                txtId.Text = Convert.ToString(oRow["DoctorID"]);
                txtName.Text = Convert.ToString(oRow["DoctorName"]);
                txtMobile.Text = Convert.ToString(oRow["Mobile"]);
                txtEmailId.Text = Convert.ToString(oRow["Email"]);
                rtbAddress.Text = Convert.ToString(oRow["Address"]);
                string _gender = Convert.ToString(oRow["Gender"]);
                if (_gender == "Male")
                    rbMale.Checked = true;
                else if (_gender == "Female")
                    rbFemale.Checked = true;
                cbBooldGroup.SelectedValue = Convert.ToString(oRow["BloodGroup"]);
                txtAge.Text = Convert.ToString(oRow["Age"]);
                cbSpecialist.SelectedValue = Convert.ToInt32(oRow["Categories"]);
                dtpDOB.Text = Convert.ToString(oRow["DOB"]);
                dtpDOJ.Text = Convert.ToString(oRow["DOJ"]);
                txtId.Enabled = true;
                txtId.ReadOnly = true;
            }
        }

        private bool validateControl()
        {
            //if (String.IsNullOrEmpty(txtId.Text))
            //{
            //    MessageBox.Show("Please Enter the Patient Id", "Message");
            //    txtId.Focus();
            //    return false;
            //}
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
            if (rbMale.Checked == false && rbFemale.Checked == false)
            {
                MessageBox.Show("Please Enter the Gender", "Message");
                return false;
            }
            //if (String.IsNullOrEmpty(txtAge.Text.Trim()))
            //{
            //    MessageBox.Show("Please Enter the Age", "Message");
            //    rtbAddress.Focus();
            //    return false;
            //}
            //if (cbSpecialist.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select specialist", "SoftGator");
            //    cbSpecialist.Focus();
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

        private void fillDropDown()
        {
            Common.BindDropDownControl(cbSpecialist, "Specialist");
            Common.BindDropDownControl(cbBooldGroup, "Blood Group");
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

        private void DoctorInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForms();
        }

        private void stripCancel_Click(object sender, EventArgs e)
        {
            closeForms();
        }

    }
}
