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
    public partial class Suppliers : Form
    {
        public string leadingzero;
        private SuppliersMap _suppliersMap = new SuppliersMap();
        public Suppliers()
        {
            InitializeComponent();
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            //int count = SuppliersProcess.number();
            //leadingzero = Common.leadingZeros(count, 5);
            //txtSupplierCode.Text = leadingzero.ToString();
            
            if (!String.IsNullOrEmpty(txtSupplierID.Text))
                loadSuppliers(Convert.ToInt32(txtSupplierID.Text));
            else
                txtSupplierID.Text = "0";
        }
        private void loadSuppliers(int supplierID)
        {
            DataSet oDataset = SuppliersProcess.selectProcess(supplierID);
            if (oDataset.Tables[0].Rows.Count > 0)
            {
                if (oDataset != null)
                {
                    DataRow oRow = oDataset.Tables[0].Rows[0];
                    txtSupplierID.Text = Convert.ToString(oRow["SupplierID"]);
                    txtSupplierName.Text = Convert.ToString(oRow["SupplierName"]);
                    txtAddress.Text = Convert.ToString(oRow["Address"]);
                    txtCity.Text = Convert.ToString(oRow["City"]);
                    txtState.Text = Convert.ToString(oRow["State"]);
                    txtZipCode.Text = Convert.ToString(oRow["ZipCode"]);
                    txtMobilePhone.Text = Convert.ToString(oRow["MobileNumber"]);
                    txtEmail.Text = Convert.ToString(oRow["Email"]);
                    txtDetails.Text = Convert.ToString(oRow["Details"]);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateControl())
                {
                    _suppliersMap.intSupplierID = Convert.ToInt32(txtSupplierID.Text);
                    _suppliersMap.strSupplierName = txtSupplierName.Text;
                    //_suppliersMap.strSupplierCode = txtSupplierCode.Text;
                    _suppliersMap.strAddress = txtAddress.Text;
                    _suppliersMap.strCity = txtCity.Text;
                    _suppliersMap.strState = txtState.Text;
                    if (String.IsNullOrEmpty(txtZipCode.Text))
                        _suppliersMap.intZipcode = 0;
                    else
                        _suppliersMap.intZipcode = Convert.ToInt32(txtZipCode.Text);
                    _suppliersMap.strMobilePhone = txtMobilePhone.Text;
                    _suppliersMap.strEmail = txtEmail.Text;
                    _suppliersMap.strDetails = txtDetails.Text;

                    SuppliersProcess.saveProcess(ref _suppliersMap);
                    if (!_suppliersMap.isError)
                    {
                        MessageBox.Show(_suppliersMap.strErrorMsg, "Message");
                        closeForms();
                    }
                    else
                    {
                        throw new Exception(_suppliersMap.strErrorMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.. " + ex.Message, "SoftGator");
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
        private bool validateControl()
        {
            if (String.IsNullOrEmpty(txtSupplierName.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Supplier Name", "Message");
                txtSupplierName.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtMobilePhone.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Mobile No", "Message");
                txtMobilePhone.Focus();
                return false;
            }
            if (txtMobilePhone.Text.Trim().Length != 10)
            {
                MessageBox.Show("Please Enter 10 Digit Mobile No", "Message");
                txtMobilePhone.Focus();
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            closeForms();
        }

        private void txtMobilePhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }
    }
}
