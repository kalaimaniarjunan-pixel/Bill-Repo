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
    public partial class SearchPatient : Form
    {
        private string searchString = string.Empty;
        private bool validate = false;
    //     private DataSet oDataSet = null;

        

        public SearchPatient()
        {
            InitializeComponent();
        }

       
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (validateControl())
            {
                DataSet oDataSet = Common.searchPatient(searchString);
                if (oDataSet.Tables[0].Rows.Count > 0)
                {
                    SearchResult _schRst = new SearchResult(oDataSet);
                    _schRst.ShowDialog();
                    this.Close();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Mismatch Customer value!. Do you like to add as a new Customer", "Message", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        //PatientInformation _patInf = new PatientInformation();
                        //_patInf.ShowDialog();


                        // Newly Added by Ezhil Customer
                        PatientMap objBAL = new PatientMap();
                        if (txtMobileNo.Text != "")
                        {
                            objBAL.Mobile = Convert.ToInt64(txtMobileNo.Text);
                        }

                        PatientInformation _patInf = new PatientInformation(objBAL);
                        _patInf.ShowDialog();
                        // Newly Added by Ezhil Customer                                           
                      
                       
                        
                        Clear();
                    }
                    else
                    {
                        Clear();
                    }
                } 
                searchString = string.Empty;
            }
            else
            {
                MessageBox.Show("Please Fill any one field..!","Message");
            }
        }
        private void btnWalkIn_Click(object sender, EventArgs e)
        {
            BillInformation bInf = new BillInformation();
            bInf.Controls["gBoxCustomer"].Controls["lblCustomerName"].Text = "Walk in Customer";
            bInf.Controls["gBoxCustomer"].Controls["lblCustomerID"].Text = "0";
            bInf.Controls["gBoxCustomer"].Controls["lblMobileNumber"].Text = "";
            bInf.Controls["gBoxBillsPayment"].Controls["chBoxAddAmount"].Enabled = false;

            bInf.formIndex = Application.OpenForms.Count - 1;
            this.Dispose();
            bInf.ShowDialog();
        }
        private bool validateControl()
        {            
            if (String.IsNullOrEmpty(searchString))
            {
                searchString = txtPatientId.Text.Trim();
                validate =  false;
                if (String.IsNullOrEmpty(searchString))
                {
                    searchString = txtMobileNo.Text.Trim();
                    validate = false;
                    if (String.IsNullOrEmpty(searchString))
                    {
                        searchString = txtEmailId.Text.Trim();
                        validate = false;
                    }
                }
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                validate = true;
            }
            return validate;
        }

        private void txtPatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnSearch_Click(sender, new EventArgs());
        }

        private void txtMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnSearch_Click(sender, new EventArgs());
        }

        private void txtEmailId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnSearch_Click(sender, new EventArgs());
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void Clear()
        {
            txtPatientId.Text = "";
            txtEmailId.Text = "";
            txtMobileNo.Text = "";
        }

        private void SearchPatient_Load(object sender, EventArgs e)
        {

        }
    }
}
