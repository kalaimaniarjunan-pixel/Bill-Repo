using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using HospitalManagement.Process;
using HospitalManagement.Map;
using System.Globalization;

namespace HospitalManagement.Pages
{
    public partial class CreateLicense : Form
    {
        private HospitalLicenseMap _salonMap = new HospitalLicenseMap();
        //private SalonSMSMap _salonSmsMap = new SalonSMSMap();

        public CreateLicense()
        {
            InitializeComponent();
        }
        private void CreateLicense_Load(object sender, EventArgs e)
        {
            LoadCombo();
            loadRecord();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                _salonMap.StartDate = Common.GetDateTime(dtStartDate.Text);
                if (rdoOnemonth.Checked)
                {
                    _salonMap.ExpiryDate = _salonMap.StartDate.AddMonths(1);
                    _salonMap.NoofDays = 30;
                }
                else if (rdo3Months.Checked)
                {
                    _salonMap.ExpiryDate = _salonMap.StartDate.AddMonths(3);
                    _salonMap.NoofDays = 90;
                }
                else if (rdo6Months.Checked)
                {
                    _salonMap.ExpiryDate = _salonMap.StartDate.AddMonths(6);
                    _salonMap.NoofDays = 180;
                }
                else if (rdo12months.Checked)
                {
                    _salonMap.ExpiryDate = _salonMap.StartDate.AddMonths(12);
                    _salonMap.NoofDays = 360;
                }
                else if (rdo24Months.Checked)
                {
                    _salonMap.ExpiryDate = _salonMap.StartDate.AddMonths(24);
                    _salonMap.NoofDays = 720;
                }
                else if (rdo36Months.Checked)
                {
                    _salonMap.ExpiryDate = _salonMap.StartDate.AddMonths(36);
                    _salonMap.NoofDays = 1440;
                }
                _salonMap.DayCounter = _salonMap.NoofDays;
                _salonMap.isExpire = true;
                _salonMap.strProduct = ddlPoduct.Text;
                HospitalLicenseProcess.SaveProcess(_salonMap);
                if (!_salonMap.isError)
                {
                    MessageBox.Show(_salonMap.strErrorMsg, "Message");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Error.... " + _salonMap.strErrorMsg, "Message");
                }
            }
        }
        public bool validate()
        {
            if (ddlPoduct.Text == "-- Select Package --" || ddlPoduct.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Your Package", "Message");
                ddlPoduct.Focus();
                return false;
            }
            return true;
        }
        private void loadRecord()
        {
            HospitalLicenseMap _licenseMap = HospitalLicenseProcess.selectProcess();
            if (!String.IsNullOrEmpty(_licenseMap.licenseKey))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(_licenseMap.licenseKey);
                XmlNode packageNode = xDoc.SelectSingleNode("SalonLicense/Package");
                if (packageNode != null) ddlPoduct.Text = packageNode.InnerText;
                else ddlPoduct.Text = "Silver";
                XmlNode xNode = xDoc.SelectSingleNode("SalonLicense/StartDate");
                if (xNode != null)
                {
                    dtStartDate.Text = Common.GetDateTime(xNode.InnerText).ToShortDateString(); //getDateFromString(xNode.InnerText); //Convert.ToString(xNode.InnerText);
                  //  IFormatProvider culture = new CultureInfo("en-US", true);
                    //DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                   // string date = DateTime.ParseExact(xNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                   // string datestring;
                   //// dateformate = "yyyy-MM-dd";
                   // datestring = xNode.InnerText.ToString();
                   // CultureInfo provider = CultureInfo.InvariantCulture;
                   // string   result;
                   // result = DateTime.Parse(datestring).ToString("yyyy-MM-dd");
                   //// dtStartDate.Text = Convert.ToString(DateTime.ParseExact(xNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture));
                    
                }
            }
        }
        private string getDateFromString(string strDate)
        {
            if (strDate.IndexOf("/") > 0)
            {
                string[] strDateSplit = strDate.Split('/');
                DateTime dt = new DateTime(Convert.ToInt16(strDateSplit[2]), Convert.ToInt16(strDateSplit[1]), Convert.ToInt16(strDateSplit[0]));
                return dt.ToShortDateString();
            }
            return "";
        }

        public void LoadCombo()
        {
            string[] objType = { "Silver", "Gold","Platinum","Economic" };
            for (int i = 0; i < objType.Length; i++)
            {
                ddlPoduct.Items.Add(objType[i]);
            }
            ddlPoduct.Items.Insert(0, "-- Select Package --");
            ddlPoduct.Text = "-- Select Package --";
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
