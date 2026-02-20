using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HospitalManagement.Map;
using System.IO;
using HospitalManagement.Process;

namespace HospitalManagement.Pages
{
    public partial class HospitalInformation : Form
    {
        private CompanyMap _companyMap = new CompanyMap();
        public byte[] clientPhoto = null;
        public HospitalInformation()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDlg = new OpenFileDialog();
            ofDlg.Filter = "JPG|*.jpg|GIF|*.gif|PNG|*.png|BMP|*.bmp";
            if (DialogResult.OK == ofDlg.ShowDialog())
            {
                txtCompanyLogo.Text = ofDlg.FileName;
                CompanyPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                CompanyPicture.Image = new Bitmap(ofDlg.OpenFile());
            }
        }
        private bool validateControl()
        {
            if (String.IsNullOrEmpty(txtHospitalName.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Hospital Name", "Message");
                txtHospitalName.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtCompanyAddress.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Address", "Message");
                txtCompanyAddress.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtCity.Text.Trim()))
            {
                MessageBox.Show("Please Enter the City", "Message");
                txtCity.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtZipcode.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Zip Code", "Message");
                txtZipcode.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtMobileno.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Mobile No", "Message");
                txtMobileno.Focus();
                return false;
            }
            if (txtMobileno.Text.Trim().Length != 10)
            {
                MessageBox.Show("Please Enter 10 Digit Mobile No", "Message");
                txtMobileno.Focus();
                return false;
            }
            return true;
        }

        private void txtMobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateControl())
                {
                    _companyMap.intCompanyID = Convert.ToInt32(txtCompanyId.Text);
                    _companyMap.strCompanyName = txtHospitalName.Text;
                    _companyMap.strAddress = txtCompanyAddress.Text;
                    _companyMap.strCity = txtCity.Text;
                    _companyMap.strVatno =txttin.Text;
                    _companyMap.strState = txtState.Text;
                    if (string.IsNullOrEmpty(txtZipcode.Text))
                        _companyMap.intZipcode = 0;
                    else
                        _companyMap.intZipcode = Convert.ToInt32(txtZipcode.Text);
                    //_companyMap.strPhoneNo = txtWorkNo.Text;
                    _companyMap.Mobileno = Convert.ToInt64(txtMobileno.Text);
                    _companyMap.strEmail = txtEmail.Text;
                    //_companyMap.strServiceTaxno = txtServiceTaxno.Text;
                    //_companyMap.strVatno = txtVatno.Text;
                    //_companyMap.strCstno = txtCstno.Text;

                    if (string.IsNullOrEmpty(txtCompanyLogo.Text))
                    {
                        if (clientPhoto != null)
                        {
                            _companyMap.companyLogo = clientPhoto;
                        }
                        else
                            _companyMap.companyLogo = new byte[0];
                    }
                    else
                    {
                        FileInfo imageInfo = new FileInfo(txtCompanyLogo.Text.Trim());
                        _companyMap.companyLogo = new byte[imageInfo.Length];
                        FileStream imagestream = imageInfo.OpenRead();
                        imagestream.Read(_companyMap.companyLogo, 0, _companyMap.companyLogo.Length);
                        imagestream.Close();
                    }
                    //_companyMap.isThermalPrinter = isThermalPrint.Checked;
                    //_companyMap.isEnable = isEnablechck.Checked;
                    //if (rdbftax.Checked)
                    //{
                    //    _companyMap.inttaxcalc = 2;
                    //}
                    //if (rdtax.Checked)
                    //{
                    //    _companyMap.inttaxcalc = 1;
                    //}
                    HospitalProcess.saveProcess(ref _companyMap);
                    if (!_companyMap.isError)
                    {
                        MessageBox.Show(_companyMap.strErrorMsg, "Message");
                        //loadCompanyDetails();
                        closeForms();
                    }
                    else
                    {
                        MessageBox.Show(_companyMap.strErrorMsg, "Message");
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
                DataSet oDataset = HospitalProcess.selectProcss(0);
                if (oDataset != null)
                {
                    ((Home)fc["Home"]).loadHomePanel(oDataset.Tables[0].Rows[0]);
                }
            }
            this.Close();
        }
        
        private void HospitalInformation_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCompanyId.Text))
                loadCompanyDetails();
            else
                txtCompanyId.Text = "0";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadCompanyDetails()
        {
            DataSet oDataset = HospitalProcess.selectProcss(0);
            if (oDataset.Tables[0].Rows.Count > 0)
            {
                DataRow oRow = oDataset.Tables[0].Rows[0];
                txtCompanyId.Text = "1";
                txtHospitalName.Text = Convert.ToString(oRow["CompanyName"]);
                txtCompanyAddress.Text = Convert.ToString(oRow["Address"]);
                txtCity.Text = Convert.ToString(oRow["City"]);
                txtState.Text = Convert.ToString(oRow["State"]);
                txtZipcode.Text = Convert.ToString(oRow["Zip"]);
                txtMobileno.Text = Convert.ToString(oRow["MobileNo"]);
                txtEmail.Text = Convert.ToString(oRow["EmailId"]);
                if (oRow["CompanyLogo"] != System.DBNull.Value)
                {
                    clientPhoto = ((byte[])oRow["CompanyLogo"]);
                    if (clientPhoto.Length > 0)
                    {
                        MemoryStream byteData = new MemoryStream(clientPhoto);
                        CompanyPicture.Image = Image.FromStream(byteData);
                    }
                }
            }
        }

        private void txtZipcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }
    }
}
