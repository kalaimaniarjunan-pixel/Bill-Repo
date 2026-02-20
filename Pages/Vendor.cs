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
    public partial class Vendor : Form
    {
        public string leadingzero;
        private VendorMap _VendorMap = new VendorMap();
        public Vendor()
        {
            InitializeComponent();
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            //int count = SuppliersProcess.number();
            //leadingzero = Common.leadingZeros(count, 5);
            //txtSupplierCode.Text = leadingzero.ToString();
            
            if (!String.IsNullOrEmpty(txtVendorID.Text))
                loadSuppliers(Convert.ToInt32(txtVendorID.Text));
            else
                txtVendorID.Text = "0";
        }
        private void loadSuppliers(int VendorID)
        {
            DataSet oDataset = VendorProcess.selectProcess(VendorID);
            if (oDataset.Tables[0].Rows.Count > 0)
            {
                if (oDataset != null)
                {
                    DataRow oRow = oDataset.Tables[0].Rows[0];
                    txtVendorID.Text = Convert.ToString(oRow["VendorID"]);
                    txtvendorName.Text = Convert.ToString(oRow["VendorName"]);
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
                    _VendorMap.intVendorID = Convert.ToInt32(txtVendorID.Text);
                    _VendorMap.strVendorName = txtvendorName.Text;
                    //_VendorMap.strSupplierCode = txtSupplierCode.Text;
                    _VendorMap.strAddress = txtAddress.Text;
                    _VendorMap.strCity = txtCity.Text;
                    _VendorMap.strState = txtState.Text;
                    if (String.IsNullOrEmpty(txtZipCode.Text))
                        _VendorMap.intZipcode = 0;
                    else
                        _VendorMap.intZipcode = Convert.ToInt32(txtZipCode.Text);
                    _VendorMap.strMobilePhone = txtMobilePhone.Text;
                    _VendorMap.strEmail = txtEmail.Text;
                    _VendorMap.strDetails = txtDetails.Text;

                    VendorProcess.saveProcess(ref _VendorMap);
                    if (!_VendorMap.isError)
                    {
                        MessageBox.Show(_VendorMap.strErrorMsg, "Message");
                        closeForms();
                    }
                    else
                    {
                        throw new Exception(_VendorMap.strErrorMsg);
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
            if (String.IsNullOrEmpty(txtvendorName.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Supplier Name", "Message");
                txtvendorName.Focus();
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
