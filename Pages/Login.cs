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
using System.Xml;

namespace HospitalManagement.Pages
{
    public partial class Login : Form
    {
        private int DaysRequired = 0;
        private bool isFormClose = false;
        private string strPackage = string.Empty;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Common.BindDropDownFromEmployeeForLogin(cBoxUser,true);
        }
        private bool IsValidateControl()
        {
            if (cBoxUser.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select User Name", "Message");
                cBoxUser.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtPassWord.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Password", "Message");
                txtPassWord.Focus();
                return false;
            }
            return true;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (IsValidateControl())
            {
                if (cBoxUser.Text == "ApalisAdmin")
                {
                    LoginMap _loginMap = new LoginMap();
                    _loginMap.strUserId = cBoxUser.SelectedValue.ToString();
                    _loginMap.strPassword = txtPassWord.Text;
                    if (LoginProcess.isValidLogin(_loginMap))
                    {
                        Common.insertLoginDetails(_loginMap.strUserId);
                        Home _Home = new Home();
                        _Home.Top = 0;
                        _Home.Left = 0;
                        _Home.Width = Screen.PrimaryScreen.Bounds.Width;
                        _Home.Height = Screen.PrimaryScreen.Bounds.Height;
                       // _Home.Controls["lblUserId"].Text = Convert.ToString(_loginMap.strUserId);
                        _Home.userName = Convert.ToString(_loginMap.strUserId);
                        _Home.isExpireDay = false;
                        _Home.Show();
                        this.Hide();
                    }
                    else
                    {
                        txtPassWord.Text = string.Empty;
                        MessageBox.Show("Invalid User Name and Password!", "Message");
                    }
                }
                else
                {
                    if (isValidLicense(true))
                    {
                        LoginMap _loginMap = new LoginMap();
                        _loginMap.strUserId = cBoxUser.SelectedValue.ToString();
                        _loginMap.strPassword = txtPassWord.Text;
                        if (LoginProcess.isValidLogin(_loginMap))
                        {
                            Common.insertLoginDetails(_loginMap.strUserId);
                            Home _Home = new Home();
                            _Home.Top = 0;
                            _Home.Left = 0;
                            _Home.Width = Screen.PrimaryScreen.Bounds.Width;
                            _Home.Height = Screen.PrimaryScreen.Bounds.Height;
                            _Home.strPackage = strPackage;
                            _Home.userName = cBoxUser.Text;
                           // _Home.Controls["lblUserId"].Text = Convert.ToString(_loginMap.strUserId);
                            if (DaysRequired < 364)
                            {
                                _Home.daysCount = "License Expire in " + DaysRequired + " Day(s)";
                                _Home.isExpireDay = true;
                            }
                            else
                                _Home.isExpireDay = false;
                            _Home.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid User Name and Password!", "Message");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invaild License....", "Message");
                    }
                }
            }
        }
        private bool isValidLicense(bool isValidate)
        {
            HospitalLicenseMap _licenseMap = HospitalLicenseProcess.selectProcess();
            if (!String.IsNullOrEmpty(_licenseMap.licenseKey))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(_licenseMap.licenseKey);
                XmlNode packageNode = xDoc.SelectSingleNode("SalonLicense/Package");
                if (packageNode != null) strPackage = packageNode.InnerText;
                else strPackage = "Silver";
                if (isValidate)
                {
                    XmlNode xIPNode = xDoc.SelectSingleNode("SalonLicense/RegisterId");
                    if (xIPNode != null)
                    {
                        if (xIPNode.InnerText == "") return false;
                        else if (xIPNode.InnerText != Common.getProductSetupKey()) return false;
                    }
                    else
                    {
                        return false;
                    }
                    XmlNode xNode = xDoc.SelectSingleNode("SalonLicense/ExpiryDate");
                    if (xNode != null)
                    {
                        if (DateTime.Compare(System.DateTime.Today, Convert.ToDateTime(xNode.InnerText)) == 1)
                        {
                            _licenseMap.isExpire = false;
                            HospitalLicenseProcess.SaveProcess(_licenseMap);
                            return false;
                        }
                        else if (DateTime.Compare(System.DateTime.Today, Convert.ToDateTime(xNode.InnerText)) <= 0)
                        {
                            TimeSpan t = Convert.ToDateTime(xNode.InnerText).Subtract(System.DateTime.Today);
                            _licenseMap.DayCounter = t.Days;
                            _licenseMap.isExpire = true;
                            _licenseMap.strProduct = strPackage;
                            DaysRequired = t.Days;
                            HospitalLicenseProcess.SaveProcess(_licenseMap);
                        }
                    }
                    xNode = xDoc.SelectSingleNode("SalonLicense/IsExpire");
                    if (xNode != null && xNode.InnerText == "False")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to Exit from the application?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (isFormClose == false)
                {
                    isFormClose = true;
                }
                Application.Exit();
            }
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogIn_Click(sender, new EventArgs());
        }

    }
}
