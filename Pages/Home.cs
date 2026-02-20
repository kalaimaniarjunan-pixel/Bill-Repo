using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HospitalManagement.Pages;
using HospitalManagement.Process;
using HospitalManagement.Map;
using System.Configuration;
using System.IO;
using System.Globalization;
namespace HospitalManagement
{
    public partial class Home : Form
    {
        private int formID = 0;
        private int selectIndex = -1;
        private int pageNo = 1;
        private int pageIndex = 1;
        private string strFilter = "";
        private bool isFormClose = false;
        private decimal total = 0;
        private decimal totalWithTax = 0;
        private decimal _Amount = 0;
        private decimal _AmountTax = 0;
        public string strPackage = string.Empty;
        public string userName;
        public string daysCount;
        public bool isExpireDay;

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            tblBody.Hide();
            tblActions.Hide();
            panelHome.Show();
            gboxDateRange.Hide();
            gBoxStatus.Hide();
            panelHome.Left = 500;
            panelHome.Top = 275;
            panelHome.Width = 500;
            panelHome.Height = 211;
            label1.ForeColor = Color.Green;
            lblCompanyName.ForeColor = Color.Green;
            DataSet dsCompany = HospitalProcess.selectProcss(0);
            if (dsCompany != null)
            {
                if (dsCompany.Tables[0] != null && dsCompany.Tables[0].Rows.Count > 0)
                {
                    loadHomePanel(dsCompany.Tables[0].Rows[0]);
                }
                else
                {
                    lblCompanyName.Text = "Company Name";
                    HospitalInformation _company = new HospitalInformation();
                    _company.Show();
                    _company.Focus();
                }
            }
            lblTopWelcome.Text = userName;
            lblTopExpireDays.Text = daysCount;
            lblTopExpireDays.Visible = isExpireDay;
            if (lblTopWelcome.Text != "ApalisAdmin")
            {
                createLicenseToolStripMenuItem.Visible = false;
            }


        }

        private void setInitialpageing()
        {
            pageNo = 1;
            strFilter = "";
            txtFilter.Text = "";
            btnPrevious.Enabled = false;
            btnPreviousLink.Visible = false;
            //tblBody.Width = Screen.PrimaryScreen.Bounds.Width - 225;
            if (formID != 1)
                tblActions.Height = 156;
            else
                tblActions.Height = 186;
        }

        private void setpageing()
        {
            setBorderInitial();
            btnNo1.Visible = true;
            btnNo1.Text = "1";
            btnNo2.Visible = true;
            btnNo2.Text = "2";
            btnNo3.Visible = true;
            btnNo3.Text = "3";
            btnNo4.Visible = true;
            btnNo4.Text = "4";
            btnNo5.Visible = true;
            btnNo5.Text = "5";
            btnNext.Enabled = true;
            btnNextLink.Visible = true;
            if (pageIndex <= 5)
            {
                btnPreviousLink.Visible = false;
                btnPrevious.Enabled = false;
                if (pageIndex == 1) btnNext.Enabled = false;
                btnNextLink.Visible = false;
                if (pageIndex < 5)
                    btnNo5.Visible = false;
                if (pageIndex < 4)
                    btnNo4.Visible = false;
                if (pageIndex < 3)
                    btnNo3.Visible = false;
                if (pageIndex < 2)
                    btnNo2.Visible = false;
            }
            btnNo1.LinkColor = Color.Red;
        }

        private void setEndpageing()
        {
            if (Convert.ToInt32(btnNo1.Text) <= 1)
            {
                btnPreviousLink.Visible = false;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPreviousLink.Visible = true;
                btnPrevious.Enabled = true;
            }
            if (Convert.ToInt32(btnNo5.Text) >= pageIndex)
            {
                btnNextLink.Visible = false;
                //btnNext.Enabled = false;
            }
            else
            {
                btnNextLink.Visible = true;
                btnNext.Enabled = true;
            }
            btnNo1.Visible = true;
            btnNo2.Visible = true;
            btnNo3.Visible = true;
            btnNo4.Visible = true;
            btnNo5.Visible = true;
            if (Convert.ToInt32(btnNo1.Text) > pageIndex)
                btnNo1.Visible = false;
            if (Convert.ToInt32(btnNo2.Text) > pageIndex)
                btnNo2.Visible = false;
            if (Convert.ToInt32(btnNo3.Text) > pageIndex)
                btnNo3.Visible = false;
            if (Convert.ToInt32(btnNo4.Text) > pageIndex)
                btnNo4.Visible = false;
            if (Convert.ToInt32(btnNo5.Text) > pageIndex)
                btnNo5.Visible = false;

            pageNo = Convert.ToInt32(btnNo1.Text);
            setBorderInitial();
            btnNo1.LinkColor = Color.Red;
            if (formID == 1)
            {
                DataBindForBill();
            }
            else
            {
                DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                if (oDataSet != null)
                {
                    DataBind(oDataSet.Tables[0]);
                }
            }
        }

        private void setBorderInitial()
        {
            btnNo1.LinkColor = Color.Blue;
            btnNo2.LinkColor = Color.Blue;
            btnNo3.LinkColor = Color.Blue;
            btnNo4.LinkColor = Color.Blue;
            btnNo5.LinkColor = Color.Blue;
        }

        public void DataBind(DataTable oTable)
        {
            grdLoadData.DataSource = null;
            BindingSource bSource = new BindingSource();
            bSource.DataSource = oTable;
            grdLoadData.AutoGenerateColumns = true;
            grdLoadData.DataSource = bSource;
            grdLoadData.Columns[0].Visible = true;
            if (grdLoadData.RowCount > 0 && oTable.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataGridViewRow oRow in grdLoadData.Rows)
                {
                    if (i == oTable.Rows.Count) break;
                    int j = 0;
                    foreach (DataColumn oCell in oTable.Columns)
                    {
                        oRow.Cells[j].Value = oTable.Rows[i][j];
                        oRow.Cells[j].ReadOnly = true;
                        j++;
                    }
                    i++;
                }
                selectIndex = 0;
            }
            if (formID == 4)  grdLoadData.Columns[2].Width = 250;
            if (formID == 5)  grdLoadData.Columns[0].Visible = false;           
            if (formID == 6)  grdLoadData.Columns[0].Visible = false;
            if (formID == 7)  grdLoadData.Columns[0].Visible = false;
            if (formID == 9)  grdLoadData.Columns[0].Visible = false;
            if (formID == 10) grdLoadData.Columns[0].Visible = false;
            if (formID == 11) grdLoadData.Columns[0].Visible = false;
            if (formID == 12) grdLoadData.Columns[0].Visible = false;
            if (formID == 13) grdLoadData.Columns[0].Visible = false;
            if (formID == 14) grdLoadData.Columns[0].Visible = false;
            if (formID == 15) grdLoadData.Columns[0].Visible = false;
            if (formID == 15) grdLoadData.Columns[0].Visible = false;
            if (formID == 16) grdLoadData.Columns[0].Visible = false;
            gBoxBillTotal.Visible = false;
            tblBirthday.Hide();
            tblAnniversary.Hide();
        }

        // Menu Items
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelHome.Show();
            gboxDateRange.Hide();
            gBoxStatus.Hide();
            tblBody.Hide();
            tblActions.Hide();
            label1.Show();
            lblCompanyName.Show();
            cLogo.Show();
            panelHome.Left = 400;
            panelHome.Top = 275;
            panelHome.Width = 500;
            panelHome.Height = 211;
            DataSet dsCompany = HospitalProcess.selectProcss(0);
            if (dsCompany != null)
            {
                if (dsCompany.Tables[0] != null && dsCompany.Tables[0].Rows.Count > 0)
                {
                    loadHomePanel(dsCompany.Tables[0].Rows[0]);
                }
            }
        }
        private void hideOtherGroups()
        {
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            btnPrint.Visible = false;
            PrintIco.Visible = false;
            gboxDateRange.Hide();
            gBoxStatus.Hide();
            panelHome.Hide();
            tblBody.Show();
            tblActions.Show();
            panelHome.Left = 20;
            panelHome.Top = 608;
            panelHome.Width = 118;
            panelHome.Height = 45;
            tblBirthday.Hide();
            tblAnniversary.Hide();
        }

        private void bttnBillsToolStrip_Click(object sender, EventArgs e)
        {
            formID = 1;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Bill Information";
            btnAdd.Text = "Add Bill";
            btnDelete.Text = "Delete Bill";
            btnView.Text = "View Bill";
            btnPrint.Text = "Print Bill";
            hideOtherGroups();
            btnDelete.Enabled = false;
            gboxDateRange.Show();
            gBoxStatus.Show();
            gboxDateRange.Height = 148;
            gBoxStatus.Top = 431;
            rdoTodayBills.Checked = true;
            //rdoClosed.Checked = true;
            rdoInProgress.Checked = true;
            dtFromDate.Visible = false;
            dtToDate.Visible = false;
            label2.Visible = false;
            label7.Visible = false;
            btnGetBill.Visible = false;
            DataBindForBill();
            setpageing();
            gboxDateRange.Show();
            gBoxStatus.Show();
            btnPrint.Visible = true;
            PrintIco.Visible = true;
            gBoxBillTotal.Visible = true;
        }
        private void addEditPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 2;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Customer Information";
            btnAdd.Text = "Add Customer";
            btnDelete.Text = "Delete Customer";
            btnView.Text = "View Customer";
            btnPrint.Text = "Print Customer";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
        }
        private void bttnPatientToolStrip_Click(object sender, EventArgs e)
        {
            formID = 2;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Customer Information";
            btnAdd.Text = "Add Customer";
            btnDelete.Text = "Delete Customer";
            btnView.Text = "View Customer";
            btnPrint.Text = "Print Customer";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
        }

        private void bttnDoctorsToolStrip_Click(object sender, EventArgs e)
        {
            formID = 3;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Employee Information";
            btnAdd.Text = "Add Employee";
            btnDelete.Text = "Delete Employee";
            btnView.Text = "View Employee";
            btnPrint.Text = "Print Employee";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
        }

        private void bttnEmployeeToolStrip_Click(object sender, EventArgs e)
        {
            formID = 4;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Product Information";
            btnAdd.Text = "Add Product";
            btnDelete.Text = "Delete Product";
            btnView.Text = "View Product";
            btnPrint.Text = "Print Product";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
        }

        private void bttnCategoriesToolStrip_Click(object sender, EventArgs e)
        {
            formID = 5;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Tests Information";
            btnAdd.Text = "Add Tests";
            btnDelete.Text = "Delete Tests";
            btnView.Text = "View Tests";
            btnPrint.Text = "Print Tests";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
        }
        private void eBUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 7;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "EBUnit";
            btnAdd.Text = "Add EBUnit";
            btnDelete.Text = "Delete EBUnit";
            btnView.Text = "View EBUnit";
            btnPrint.Text = "Print EBUnit";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
            btnDelete.Enabled = false;
        }
        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 9;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Attendance";
            btnAdd.Text = "Add Attendance";
            btnDelete.Text = "Delete Attendance";
            btnView.Text = "View Attendance";
            btnPrint.Text = "Print Attendance";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
            btnDelete.Enabled = false;
        }

        //private void expensesToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    formID = 8;
        //    selectIndex = -1;
        //    setInitialpageing();
        //    lblHeaderlabel.Text = "Expenses";
        //    btnAdd.Text = "Add Expenses";
        //    btnDelete.Text = "Delete Expenses";
        //    btnView.Text = "View Expenses";
        //    btnPrint.Text = "Print Expenses";

        //    DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
        //    if (oDataSet != null)
        //    {
        //        DataBind(oDataSet.Tables[0]);
        //        pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
        //        lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
        //        setpageing();
        //    }
        //    hideOtherGroups();
        //}

        // Master Item
        private void addEditPatientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formID = 2;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Customer Information";
            btnAdd.Text = "Add Customer";
            btnDelete.Text = "Delete Customer";
            btnView.Text = "View Customer";
            btnPrint.Text = "Print Customer";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
        }
        private void addEditDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 3;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Employee Information";
            btnAdd.Text = "Add Employee";
            btnDelete.Text = "Delete Employee";
            btnView.Text = "View Employee";
            btnPrint.Text = "Print Employee";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
        }
        private void addEditEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 4;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Product Information";
            btnAdd.Text = "Add Product";
            btnDelete.Text = "Delete Product";
            btnView.Text = "View Product";
            btnPrint.Text = "Print Product";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
        }
        private void addEditDiseasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 10;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Supplier Information";
            btnAdd.Text = "Add Supplier";
            btnDelete.Text = "Delete Supplier";
            btnView.Text = "View Supplier";
            btnPrint.Text = "Print Supplier";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
        }
        private void addEditCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 6;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Categories Information";
            btnAdd.Text = "Add Categories";
            btnDelete.Text = "Delete Categories";
            btnView.Text = "View Categories";
            btnPrint.Text = "Print Categories";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
            btnDelete.Enabled = false;
        }

        private void grdLoadData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                grdLoadData.Rows[e.RowIndex].Selected = true;
                selectIndex = e.RowIndex;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (formID == 1)
            {
                SearchPatient _schPat = new SearchPatient();
                _schPat.ShowDialog();
            }
            if (formID == 2)
            {
                PatientInformation _patInfo = new PatientInformation();
                _patInfo.ShowDialog();
            }
            if (formID == 3)
            {
                EmployeeInformation _docInfo = new EmployeeInformation();
                _docInfo.ShowDialog();
            }
            if (formID == 4)
            {
                Product _proInfo = new Product();
                _proInfo.ShowDialog();
            }
            if (formID == 6)
            {
                UserDefinedCategories _userDfCat = new UserDefinedCategories();
                _userDfCat.ShowDialog();
            }
            if (formID == 7)
            {
                EBUnit _ebUnit = new EBUnit();
                _ebUnit.ShowDialog();
            }
            if (formID == 9)
            {
                Attendance _ebUnit = new Attendance();
                _ebUnit.ShowDialog();
            }
            if (formID == 10)
            {
                Suppliers _suppInfo = new Suppliers();
                _suppInfo.ShowDialog();
            }
            if (formID == 11)
            {
                GoodsReceipt _goodRep = new GoodsReceipt();
                _goodRep.ShowDialog();
            }
            if (formID == 12)
            {
                SalesReturn _salesReturn = new SalesReturn();
                _salesReturn.ShowDialog();
            }
            if (formID == 13)
            {
                IssueEntry _issueEntry = new IssueEntry();
                _issueEntry.ShowDialog();
            }
            else if (formID == 14)
            {
                AdjustmentStockEntry _adjustment = new AdjustmentStockEntry();
                _adjustment.Controls["lblAdjustmentID"].Text = "";
                _adjustment.ShowDialog();
            }
            else if (formID == 15)
            {
                Expanses _expenses = new Expanses();
                _expenses.Controls["lblExpenses"].Text = "";
                _expenses.ShowDialog();
            }

            else if (formID == 16)
            {
                Vendor _Vendor = new Vendor();
                _Vendor.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectIndex > -1)
            {
                DialogResult dialogResult = MessageBox.Show("Do you like to delete the seleted row", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    DataSet oDataSet = new DataSet();
                    DeleteMap _deleteMap = new DeleteMap();
                    _deleteMap.strConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                    if (formID == 1)
                    {
                        _deleteMap.strPrimaryID = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Bill ID"].Value);
                        _deleteMap.strTableName = "Bill";
                        Common.DeleteRecord(ref _deleteMap);
                        MessageBox.Show(_deleteMap.strErrorMsg, "Message");
                        oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                    }
                    if (formID == 2)
                    {
                        _deleteMap.strPrimaryID = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Customer ID"].Value);
                        _deleteMap.strTableName = "Customer";
                        Common.DeleteRecord(ref _deleteMap);
                        MessageBox.Show(_deleteMap.strErrorMsg, "Message");
                        oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                    }
                    if (formID == 3)
                    {
                        _deleteMap.strPrimaryID = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Employee ID"].Value);
                        _deleteMap.strTableName = "Employee";
                        Common.DeleteRecord(ref _deleteMap);
                        MessageBox.Show(_deleteMap.strErrorMsg, "Message");
                        oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                    }
                    if (formID == 4)
                    {
                        _deleteMap.strPrimaryID = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Product ID"].Value);
                        _deleteMap.strTableName = "Product";
                        Common.DeleteRecord(ref _deleteMap);
                        MessageBox.Show(_deleteMap.strErrorMsg, "Message");
                        oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                    }
                    if (formID == 5)
                    {
                        _deleteMap.strPrimaryID = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Diseases ID"].Value);
                        _deleteMap.strTableName = "Diseases";
                        Common.DeleteRecord(ref _deleteMap);
                        MessageBox.Show(_deleteMap.strErrorMsg, "Message");
                        oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                    }
                    if (formID == 6)
                    {
                        _deleteMap.strPrimaryID = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Category ID"].Value);
                        _deleteMap.strTableName = "Category";
                        Common.DeleteRecord(ref _deleteMap);
                        MessageBox.Show(_deleteMap.strErrorMsg, "Message");
                        oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                    }
                    if (formID == 10)
                    {
                        _deleteMap.strPrimaryID = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Supplier ID"].Value);
                        _deleteMap.strTableName = "Supplier";
                        Common.DeleteRecord(ref _deleteMap);
                        MessageBox.Show(_deleteMap.strErrorMsg, "Message");
                        oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                    }
                    if (formID == 11)
                    {
                        _deleteMap.strPrimaryID = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["GRNNo"].Value);
                        _deleteMap.strTableName = "GRN";
                        Common.DeleteRecord(ref _deleteMap);
                        MessageBox.Show(_deleteMap.strErrorMsg, "Message");
                        oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                    }
                    if (oDataSet != null && oDataSet.Tables.Count > 0)
                    {
                        DataBind(oDataSet.Tables[0]);
                        pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                        lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                    }
                    setpageing();
                }
            }
            else
            {
                MessageBox.Show("Please Select Row!", "Message");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            callViewAllForms();
        }

        private void grdLoadData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            callViewAllForms();
        }

        private void callViewAllForms()
        {
            if (selectIndex > -1)
            {
                if (formID == 1)
                {
                    BillInformation _billInfo = new BillInformation();
                    _billInfo.Controls["gBoxBillInfo"].Controls["lblBillID"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["OrginalBillID"].Value);
                    _billInfo.ClosedBillId = Convert.ToInt32(grdLoadData.Rows[selectIndex].Cells["BillID"].Value);
                    _billInfo.ShowDialog();
                    //selectIndex = 0;
                }
                else if (formID == 2)
                {
                    PatientInformation _patInfo = new PatientInformation();
                    _patInfo.Controls["gBoxPatientDetails"].Controls["txtId"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Customer ID"].Value);
                    _patInfo.ShowDialog();
                    selectIndex = 0;
                }
                else if (formID == 3)
                {
                    EmployeeInformation _docInfo = new EmployeeInformation();
                    _docInfo.Controls["gBoxEmployeeDetails"].Controls["txtId"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Employee ID"].Value);
                    _docInfo.ShowDialog();
                    selectIndex = 0;
                }
                else if (formID == 4)
                {
                    Product _pro = new Product();
                    _pro.Controls["gBoxProduct"].Controls["txtProductId"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Product ID"].Value);
                    _pro.ShowDialog();
                    selectIndex = 0;
                }
                else if (formID == 5)
                {
                    UserDefinedDiseases _userDfCat = new UserDefinedDiseases();
                    _userDfCat.Controls["gBoxCategory"].Controls["txtUdDiseasesID"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Diseases ID"].Value);
                    _userDfCat.ShowDialog();
                    //selectIndex = 0;
                }
                else if (formID == 6)
                {
                    UserDefinedCategories _userDfCat = new UserDefinedCategories();
                    _userDfCat.Controls["gBoxCategory"].Controls["txtUdcategoryID"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Category ID"].Value);
                    _userDfCat.ShowDialog();
                    //selectIndex = 0;
                }
                else if (formID == 7)
                {
                    EBUnit _ebUnit = new EBUnit();
                    _ebUnit.Controls["lblEBUnit"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["EBUnitId"].Value); ;
                    _ebUnit.ShowDialog();
                    selectIndex = 0;
                }
                else if (formID == 9)
                {
                    Attendance _ebUnit = new Attendance();
                    _ebUnit.Controls["txtAttendaceId"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["AttendanceID"].Value); ;
                    _ebUnit.ShowDialog();
                    selectIndex = 0;
                }
                else if (formID == 10)
                {
                    Suppliers _supp = new Suppliers();
                    _supp.Controls["gBoxGeneral"].Controls["txtSupplierID"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Supplier ID"].Value); 
                    _supp.ShowDialog();
                    selectIndex = 0;
                }
                else if (formID == 11)
                {
                    GoodsReceipt _goodRep = new GoodsReceipt();
                    _goodRep.Controls["gBoxGeneral"].Controls["txtGRNno"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["GRNNo"].Value); ;
                    _goodRep.ShowDialog();
                    selectIndex = 0;
                }
                else if (formID == 12)
                {
                    SalesReturn _salesReturn = new SalesReturn();
                    _salesReturn.Controls["gBoxDescription"].Controls["txtSalesReturnID"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["SalesReturnID"].Value);
                    _salesReturn.ShowDialog();
                    selectIndex = 0;
                }
                else if (formID == 13)
                {
                    IssueEntry _IssueEntry = new IssueEntry();
                    _IssueEntry.Controls["gBoxDescription"].Controls["txtIssueID"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["IssueEntryID"].Value);
                    _IssueEntry.ShowDialog();
                    selectIndex = 0;
                }
                else if (formID == 14)
                {
                    AdjustmentStockEntry _adjustment = new AdjustmentStockEntry();
                    _adjustment.Controls["lblAdjustmentID"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["adjustmentStockID"].Value);
                    _adjustment.ShowDialog();
                }
                else if (formID == 15)
                {
                    Expanses _expenses = new Expanses();
                    _expenses.Controls["lblExpenses"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["ExpensesID"].Value);
                    _expenses.ShowDialog();
                }

                else if (formID == 16)
                {
                    Vendor _Vendor = new Vendor();
                    _Vendor.Controls["gBoxGeneral"].Controls["txtVendorID"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["Vendor ID"].Value); 
                    _Vendor.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please Select Row!", "Message");
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            pageNo = 1;
            strFilter = txtFilter.Text;
            btnNo1.LinkColor = Color.Red;

            if (formID == 1)
            {
                DataBindForBill();
            }
            else
            {
                DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                if (oDataSet != null)
                {
                    DataBind(oDataSet.Tables[0]);
                    pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                    lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                    setpageing();
                }
            }
        }

        public void closeFormBill()
        {
            if (formID == 1)
            {
                setInitialpageing();
                DataBindForBill();
                setpageing();
            }
        }

        public void cancelChildForm()
        {
            if (formID > 1)
            {
                setInitialpageing();

                DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                if (oDataSet != null)
                {
                    DataBind(oDataSet.Tables[0]);
                    pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                    lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                }

                setpageing();
            }
        }

        private void addBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 1;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Bill Information";
            btnAdd.Text = "Add Bill";
            btnDelete.Text = "Delete Bill";
            btnView.Text = "View Bill";
            btnPrint.Text = "Print Bill";
            hideOtherGroups();
            btnDelete.Enabled = false;
            gboxDateRange.Show();
            gBoxStatus.Show();
            gboxDateRange.Height = 148;
            gBoxStatus.Top = 431;
            rdoTodayBills.Checked = true;
            rdoClosed.Checked = true;
            dtFromDate.Visible = false;
            dtToDate.Visible = false;
            label2.Visible = false;
            label7.Visible = false;
            btnGetBill.Visible = false;
            DataBindForBill();
            setpageing();
            gboxDateRange.Show();
            gBoxStatus.Show();
            btnPrint.Visible = true;
            PrintIco.Visible = true;
            gBoxBillTotal.Visible = true;
        }
        public void DataBindForBill()
        {
            DateTime dttempFromDate = new DateTime();
            DateTime dttempToDate = new DateTime();
            int intStatusID = 0;
            if (rdoOpen.Checked)
            {
                intStatusID = Common.getUDID("Bill Status", "Open");
            }
            else if (rdoClosed.Checked)
            {
                intStatusID = Common.getUDID("Bill Status", "Closed");
            }
            else if (rdoCancel.Checked)
            {
                intStatusID = Common.getUDID("Bill Status", "Cancel");
            }
            else if (rdoInProgress.Checked)
            {
                intStatusID = Common.getUDID("Bill Status", "In Progress");
            }
            if (rdoTodayBills.Checked)
            {
                dttempFromDate = System.DateTime.Today;
                dttempToDate = System.DateTime.Today;
            }
            else if (rdoYesterdayBills.Checked)
            {
                dttempFromDate = System.DateTime.Today.AddDays(-1);
                dttempToDate = System.DateTime.Today.AddDays(-1);
            }
            else if (rdoAllDates.Checked)
            {
                dttempFromDate = Common.GetDateTime("01/01/1900");
                dttempToDate = System.DateTime.Today;
            }
            else if (rdoDateRange.Checked)
            {
                dttempFromDate = Common.GetDateTime(dtFromDate.Text);
                dttempToDate = Common.GetDateTime(dtToDate.Text);
            }
            DataSet oDataSet = BillProcess.selectProcessByFilter(dttempFromDate, dttempToDate, intStatusID, pageNo, strFilter);
            if (oDataSet != null)
            {
                BindingSource bSource = new BindingSource();
                bSource.DataSource = oDataSet.Tables[0];
                grdLoadData.AutoGenerateColumns = true;
                grdLoadData.DataSource = bSource;
                int i = 0;
                if (grdLoadData.RowCount > 0 && oDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataGridViewRow oRow in grdLoadData.Rows)
                    {
                        if (i == oDataSet.Tables[0].Rows.Count) break;
                        int j = 0;
                        foreach (DataColumn oCell in oDataSet.Tables[0].Columns)
                        {
                            oRow.Cells[j].Value = oDataSet.Tables[0].Rows[i][j];
                            oRow.Cells[j].ReadOnly = true;
                            j++;
                        }
                        i++;
                    }
                }
                if (i > 0)
                {
                    selectIndex = 0;
                }

                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
            }
            total = 0;
            totalWithTax = 0;
            foreach (DataGridViewRow Rows in grdLoadData.Rows)
            {
                _Amount = Convert.ToDecimal(Rows.Cells["Amount"].Value);
                _AmountTax = Convert.ToDecimal(Rows.Cells["Total"].Value);
                total = total + _Amount;
                totalWithTax = totalWithTax + _AmountTax;
            }
            if (total == 0)
                txtProductWithoutTax.Text = string.Empty;
            else
                txtProductWithoutTax.Text = Convert.ToString(total);

            if (totalWithTax == 0)
                txtProductTax.Text = string.Empty;
            else
                txtProductTax.Text = Convert.ToString(totalWithTax);
            grdLoadData.Columns[0].Visible = false;
            grdLoadData.Columns[6].Width = 120;

            grdLoadData.Columns["OrginalBillID"].Visible = false;
            grdLoadData.Columns["Product List"].Width = 150;
            //  grdLoadData.Columns["ClientName"].Width = 120;
            //DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            //if (oDataSet != null)
            //{
            //    DataBind(oDataSet.Tables[0]);
            //    pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
            //    lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
            //    setpageing();
            //}
        }

        private void hospitalDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSet oDataset = HospitalProcess.selectProcss(0);
            if (oDataset != null)
            {
                if (oDataset.Tables[0].Rows.Count > 0)
                {
                    HospitalInformation _hospital = new HospitalInformation();
                    _hospital.Controls["txtCompanyId"].Text = Convert.ToString(oDataset.Tables[0].Rows[0]["CompanyId"]);
                    _hospital.Show();
                }
                else
                {
                    HospitalInformation _hospital = new HospitalInformation();
                    _hospital.Show();
                }
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword _chPass = new ChangePassword();
            _chPass.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutHospitalApalis _abtHopApa = new AboutHospitalApalis();
            _abtHopApa.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Common.createBackUpDB();
            if (MessageBox.Show("Are you sure want to Log Out!", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormCollection fc = Application.OpenForms;
                if (fc.Count > 0)
                {
                    for (int i = (fc.Count - 1); i > 1; i--)
                    {
                        if (fc[i] != null && fc[i].IsDisposed != true)
                            fc[i].Dispose();
                    }
                }

                Login l = new Login();
                l.Show();
                isFormClose = true;
                this.Hide();
            }
        }

        private void bttnLogOutToolStrip_Click(object sender, EventArgs e)
        {
           // Common.createBackUpDB();
            if (MessageBox.Show("Are you sure want to Log Out!", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormCollection fc = Application.OpenForms;
                if (fc.Count > 0)
                {
                    for (int i = (fc.Count - 1); i > 1; i--)
                    {
                        if (fc[i] != null && fc[i].IsDisposed != true)
                            fc[i].Dispose();
                    }
                }
                Login l = new Login();
                l.Show();
                isFormClose = true;
                this.Hide();
            }
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isFormClose) { }
            else if (MessageBox.Show("Are you sure want to Log Out!", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               // Common.createBackUpDB();
                FormCollection fc = Application.OpenForms;
                if (fc.Count > 0)
                {
                    for (int i = (fc.Count - 1); i > 1; i--)
                    {
                        if (fc[i] != null && fc[i].IsDisposed != true)
                            fc[i].Dispose();
                    }
                }
                Login l = new Login();
                l.Show();
                this.Hide();
            }
            else
            {
                e.Cancel = true;
            }
        }
        public void loadHomePanel(DataRow oRow)
        {
            lblCompanyName.Text = Convert.ToString(oRow["CompanyName"]);
            if (oRow["CompanyLogo"] != System.DBNull.Value)
            {
                byte[] clientPhoto = ((byte[])oRow["CompanyLogo"]);
                if (clientPhoto.Length > 0)
                {
                    MemoryStream byteData = new MemoryStream(clientPhoto);
                    cLogo.Image = Image.FromStream(byteData);
                    cLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewLog _viewLog = new ViewLog();
            _viewLog.ShowDialog();
        }

        private void rdoTodayBills_CheckedChanged(object sender, EventArgs e)
        {
            setInitialpageing();
            DataBindForBill();
            setpageing();
            gboxDateRange.Height = 148;
            gBoxStatus.Top = 431;
        }

        private void rdoYesterdayBills_CheckedChanged(object sender, EventArgs e)
        {
            setInitialpageing();
            DataBindForBill();
            setpageing();
            gboxDateRange.Height = 148;
            gBoxStatus.Top = 431;
        }

        private void rdoAllDates_CheckedChanged(object sender, EventArgs e)
        {
            setInitialpageing();
            DataBindForBill();
            setpageing();
            gboxDateRange.Height = 148;
            gBoxStatus.Top = 431;
        }

        private void btnGetBill_Click(object sender, EventArgs e)
        {
            setInitialpageing();
            DataBindForBill();
            setpageing();
        }

        private void rdoDateRange_CheckedChanged(object sender, EventArgs e)
        {
            gboxDateRange.Height = 257;
            gBoxStatus.Top = 540;
            if (rdoDateRange.Checked)
            {
                dtFromDate.Visible = true;
                dtToDate.Visible = true;
                btnGetBill.Visible = true;
                label7.Visible = true;
                label2.Visible = true;
            }
            else
            {
                dtFromDate.Visible = false;
                dtToDate.Visible = false;
                btnGetBill.Visible = false;
                label7.Visible = false;
                label2.Visible = false;
            }
        }

        #region Export Options

        private void lnkExportExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application 

            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook 
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program 
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            //  worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Export data";

            DataTable table = formID == 1 ? getBillToExport().Tables[0] : Common.getAllFormExport(formID, strFilter).Tables[0];
            int ColumnIndex = 0;
            int intFirstCol = 0;
            foreach (DataColumn col in table.Columns)
            {
                if (col.ColumnName == "OrginalBillID") continue;
                if (intFirstCol == 0) intFirstCol = 1;
                else
                {
                    ColumnIndex++;
                    worksheet.Cells[1, ColumnIndex] = col.ColumnName;
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in table.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                intFirstCol = 0;
                foreach (DataColumn col in table.Columns)
                {
                    if (col.ColumnName == "OrginalBillID") continue;
                    if (intFirstCol == 0) intFirstCol = 1;
                    else
                    {
                        ColumnIndex++;
                        worksheet.Cells[rowIndex + 1, ColumnIndex] = row[col.ColumnName];
                    }
                }
            }
            using (SaveFileDialog exportExcelFile = new SaveFileDialog())
            {
                exportExcelFile.Title = "Select Excel File";
                exportExcelFile.Filter = "Microsoft Office Excel Workbook(*.xls)|*.xls ";
                if (DialogResult.OK == exportExcelFile.ShowDialog())
                {
                    workbook.SaveAs(exportExcelFile.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    string fileName = exportExcelFile.FileName.Substring(exportExcelFile.FileName.LastIndexOf("\\") + 1, exportExcelFile.FileName.IndexOf(".") - exportExcelFile.FileName.LastIndexOf("\\") - 1);
                    MessageBox.Show(fileName + " File successfuly created in the Path " + exportExcelFile.FileName, "SoftGator");
                }
            }
            app.Quit();
        }
        private DataSet getBillToExport()
        {
            DateTime dttempFromDate = new DateTime();
            DateTime dttempToDate = new DateTime();
            int intStatusID = 0;
            if (rdoOpen.Checked)
            {
                intStatusID = Common.getUDID("Bill Status", "Open");
            }
            else if (rdoClosed.Checked)
            {
                intStatusID = Common.getUDID("Bill Status", "Closed");
            }
            else if (rdoCancel.Checked)
            {
                intStatusID = Common.getUDID("Bill Status", "Cancel");
            }
            else if (rdoInProgress.Checked)
            {
                intStatusID = Common.getUDID("Bill Status", "In Progress");
            }
            if (rdoTodayBills.Checked)
            {
                dttempFromDate = System.DateTime.Today;
                dttempToDate = System.DateTime.Today;
            }
            else if (rdoYesterdayBills.Checked)
            {
                dttempFromDate = System.DateTime.Today.AddDays(-1);
                dttempToDate = System.DateTime.Today.AddDays(-1);
            }
            else if (rdoAllDates.Checked)
            {
                dttempFromDate = Common.GetDateTime("01/01/1900");
                dttempToDate = System.DateTime.Today;
            }
            else if (rdoDateRange.Checked)
            {
                dttempFromDate = Common.GetDateTime(dtFromDate.Text);
                dttempToDate = Common.GetDateTime(dtToDate.Text);
            }
            return BillProcess.selectProcessByFilter(dttempFromDate, dttempToDate, intStatusID, pageNo, strFilter);
        }

        private void lnkExportPDF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 0, 0, 50, 50);
            MemoryStream mstream = new MemoryStream();
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, mstream);
            doc.Open();
            DataTable table = formID == 1 ? getBillToExport().Tables[0] : Common.getAllFormExport(formID, strFilter).Tables[0];
            int colCnt = table.Columns.Contains("OrginalBillID") ? table.Columns.Count - 2 : table.Columns.Count - 1;
            iTextSharp.text.Table dTable = new iTextSharp.text.Table(colCnt);
            dTable.Width = 100;
            dTable.Padding = 1;
            dTable.Spacing = 1;
            int ColumnIndex = 0;
            int intFirstCol = 0;
            foreach (DataColumn col in table.Columns)
            {
                if (col.ColumnName == "OrginalBillID") continue;
                if (intFirstCol == 0) intFirstCol = 1;
                else
                {
                    ColumnIndex++;
                    iTextSharp.text.Cell cell = new iTextSharp.text.Cell(new iTextSharp.text.Phrase(col.ColumnName, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 9)));
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Gray);
                    dTable.AddCell(cell);
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in table.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                intFirstCol = 0;
                foreach (DataColumn col in table.Columns)
                {
                    if (col.ColumnName == "OrginalBillID") continue;
                    if (intFirstCol == 0) intFirstCol = 1;
                    else
                    {
                        ColumnIndex++;
                        iTextSharp.text.Cell cell = new iTextSharp.text.Cell(new iTextSharp.text.Phrase(row[col.ColumnName].ToString(), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 8)));
                        cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        dTable.AddCell(cell);
                    }
                }
            }
            doc.Add(dTable);
            doc.Close();
            using (SaveFileDialog exportPDfFile = new SaveFileDialog())
            {
                exportPDfFile.Title = "Select Pdf File";
                exportPDfFile.Filter = "Adobe PDF Files(*.pdf)|*.pdf";
                if (DialogResult.OK == exportPDfFile.ShowDialog())
                {
                    File.WriteAllBytes(exportPDfFile.FileName, mstream.ToArray());
                    string fileName = exportPDfFile.FileName.Substring(exportPDfFile.FileName.LastIndexOf("\\") + 1, exportPDfFile.FileName.IndexOf(".") - exportPDfFile.FileName.LastIndexOf("\\") - 1);
                    MessageBox.Show(fileName + " File successfuly created in the Path " + exportPDfFile.FileName, "SoftGator");
                }
            }
        }

        #endregion

        private void rdoClosed_CheckedChanged(object sender, EventArgs e)
        {
            setInitialpageing();
            DataBindForBill();
            setpageing();
        }

        private void rdoCancel_CheckedChanged(object sender, EventArgs e)
        {
            setInitialpageing();
            DataBindForBill();
            setpageing();
        }

        private void createLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Security _sec = new Security();
            _sec.ShowDialog();
        }

        private void billReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //HospiReportViewer _hospRptVw = new HospiReportViewer();
            //_hospRptVw.ShowDialog();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            pageNo = pageNo - 1; //Convert.ToInt32(btnNo1.Text);
            setBorderInitial();
            switch (pageNo % 5)
            {
                case 1:
                    btnNo1.LinkColor = Color.Red;
                    break;
                case 2:
                    btnNo2.LinkColor = Color.Red;
                    break;
                case 3:
                    btnNo3.LinkColor = Color.Red;
                    break;
                case 4:
                    btnNo4.LinkColor = Color.Red;
                    break;
                default:
                    btnNo5.LinkColor = Color.Red;
                    break;
            }
            if (pageNo % 5 == 0)
            {
                btnNo1.Text = "" + (Convert.ToInt32(btnNo1.Text) - 5);
                btnNo2.Text = "" + (Convert.ToInt32(btnNo2.Text) - 5);
                btnNo3.Text = "" + (Convert.ToInt32(btnNo3.Text) - 5);
                btnNo4.Text = "" + (Convert.ToInt32(btnNo4.Text) - 5);
                btnNo5.Text = "" + (Convert.ToInt32(btnNo5.Text) - 5);
                btnNextLink.Visible = true;
                //setEndpageing();
            }
            btnNo1.Visible = true;
            btnNo2.Visible = true;
            btnNo3.Visible = true;
            btnNo4.Visible = true;
            btnNo5.Visible = true;
            if (Convert.ToInt32(btnNo1.Text) > pageIndex)
                btnNo1.Visible = false;
            if (Convert.ToInt32(btnNo2.Text) > pageIndex)
                btnNo2.Visible = false;
            if (Convert.ToInt32(btnNo3.Text) > pageIndex)
                btnNo3.Visible = false;
            if (Convert.ToInt32(btnNo4.Text) > pageIndex)
                btnNo4.Visible = false;
            if (Convert.ToInt32(btnNo5.Text) > pageIndex)
                btnNo5.Visible = false;
            if (pageNo <= 5) btnPreviousLink.Visible = false;
            if (pageNo == 1) btnPrevious.Enabled = false;
            if (pageIndex > pageNo) btnNext.Enabled = true;
            if (formID == 1)
            {
                DataBindForBill();
            }
            else
            {
                DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                if (oDataSet != null)
                {
                    DataBind(oDataSet.Tables[0]);
                }
            }
        }

        private void btnPreviousLink_Click(object sender, EventArgs e)
        {
            btnNo1.Text = "" + (Convert.ToInt32(btnNo1.Text) - 5);
            btnNo2.Text = "" + (Convert.ToInt32(btnNo2.Text) - 5);
            btnNo3.Text = "" + (Convert.ToInt32(btnNo3.Text) - 5);
            btnNo4.Text = "" + (Convert.ToInt32(btnNo4.Text) - 5);
            btnNo5.Text = "" + (Convert.ToInt32(btnNo5.Text) - 5);
            setEndpageing();
        }

        private void btnNo1_Click(object sender, EventArgs e)
        {
            pageNo = Convert.ToInt32(btnNo1.Text);
            setBorderInitial();
            btnNo1.LinkColor = Color.Red;
            if (formID == 1)
            {
                DataBindForBill();
            }
            else
            {
                DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                if (oDataSet != null)
                {
                    DataBind(oDataSet.Tables[0]);
                }
            }
        }

        private void btnNo2_Click(object sender, EventArgs e)
        {
            pageNo = Convert.ToInt32(btnNo2.Text);
            setBorderInitial();
            btnNo2.LinkColor = Color.Red;
            if (formID == 1)
            {
                DataBindForBill();
            }
            else
            {
                DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                if (oDataSet != null)
                {
                    DataBind(oDataSet.Tables[0]);
                }
            }
        }

        private void btnNo3_Click(object sender, EventArgs e)
        {
            pageNo = Convert.ToInt32(btnNo3.Text);
            setBorderInitial();
            btnNo3.LinkColor = Color.Red;
            if (formID == 1)
            {
                DataBindForBill();
            }
            else
            {
                DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                if (oDataSet != null)
                {
                    DataBind(oDataSet.Tables[0]);
                }
            }
        }

        private void btnNo4_Click(object sender, EventArgs e)
        {
            pageNo = Convert.ToInt32(btnNo4.Text);
            setBorderInitial();
            btnNo4.LinkColor = Color.Red;
            if (formID == 1)
            {
                DataBindForBill();
            }
            else
            {
                DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                if (oDataSet != null)
                {
                    DataBind(oDataSet.Tables[0]);
                }
            }
        }

        private void btnNo5_Click(object sender, EventArgs e)
        {
            pageNo = Convert.ToInt32(btnNo5.Text);
            setBorderInitial();
            btnNo5.LinkColor = Color.Red;
            if (formID == 1)
            {
                DataBindForBill();
            }
            else
            {
                DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                if (oDataSet != null)
                {
                    DataBind(oDataSet.Tables[0]);
                }
            }
        }

        private void btnNextLink_Click(object sender, EventArgs e)
        {
            btnNo1.Text = "" + (Convert.ToInt32(btnNo1.Text) + 5);
            btnNo2.Text = "" + (Convert.ToInt32(btnNo2.Text) + 5);
            btnNo3.Text = "" + (Convert.ToInt32(btnNo3.Text) + 5);
            btnNo4.Text = "" + (Convert.ToInt32(btnNo4.Text) + 5);
            btnNo5.Text = "" + (Convert.ToInt32(btnNo5.Text) + 5);
            setEndpageing();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pageNo = pageNo + 1; //Convert.ToInt32(btnNo1.Text);
            setBorderInitial();
            switch (pageNo % 5)
            {
                case 1:
                    btnNo1.LinkColor = Color.Red;
                    break;
                case 2:
                    btnNo2.LinkColor = Color.Red;
                    break;
                case 3:
                    btnNo3.LinkColor = Color.Red;
                    break;
                case 4:
                    btnNo4.LinkColor = Color.Red;
                    break;
                default:
                    btnNo5.LinkColor = Color.Red;
                    break;
            }
            if (pageNo > 5 && pageNo % 5 == 1)
            {
                btnNo1.Text = "" + (Convert.ToInt32(btnNo1.Text) + 5);
                btnNo2.Text = "" + (Convert.ToInt32(btnNo2.Text) + 5);
                btnNo3.Text = "" + (Convert.ToInt32(btnNo3.Text) + 5);
                btnNo4.Text = "" + (Convert.ToInt32(btnNo4.Text) + 5);
                btnNo5.Text = "" + (Convert.ToInt32(btnNo5.Text) + 5);
                //setEndpageing();
                btnPreviousLink.Visible = true;
            }
            if (Convert.ToInt32(btnNo1.Text) > pageIndex)
                btnNo1.Visible = false;
            if (Convert.ToInt32(btnNo2.Text) > pageIndex)
                btnNo2.Visible = false;
            if (Convert.ToInt32(btnNo3.Text) > pageIndex)
                btnNo3.Visible = false;
            if (Convert.ToInt32(btnNo4.Text) > pageIndex)
                btnNo4.Visible = false;
            if (Convert.ToInt32(btnNo5.Text) > pageIndex)
            {
                btnNo5.Visible = false;
                btnNextLink.Visible = false;
            }
            if (pageNo > 1) btnPrevious.Enabled = true;
            if (pageNo == pageIndex) btnNext.Enabled = false;
            if (formID == 1)
            {
                DataBindForBill();
            }
            else
            {
                DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
                if (oDataSet != null)
                {
                    DataBind(oDataSet.Tables[0]);
                }
            }
        }

        private void billwiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HospiReportViewer _rptViewer = new HospiReportViewer();
            _rptViewer.strReportName = "BillwiseReport";
            _rptViewer.Show();
        }

        private void cancelledBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HospiReportViewer _rptViewer = new HospiReportViewer();
            _rptViewer.strReportName = "CancelledBillReport";
            _rptViewer.Show();
        }

        private void billwisePatientReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //HospiReportViewer _rptViewer = new HospiReportViewer();
            //_rptViewer.strReportName = "BillwisePatientReport";
            //_rptViewer.Show();
        }

        private void bttnHomeToolStrip_Click(object sender, EventArgs e)
        {
            panelHome.Show();
            gboxDateRange.Hide();
            gBoxStatus.Hide();
            tblBody.Hide();
            tblActions.Hide();
            label1.Show();
            lblCompanyName.Show();
            cLogo.Show();
            panelHome.Left = 400;
            panelHome.Top = 275;
            panelHome.Width = 500;
            panelHome.Height = 211;
            DataSet dsCompany = HospitalProcess.selectProcss(0);
            if (dsCompany != null)
            {
                if (dsCompany.Tables[0] != null && dsCompany.Tables[0].Rows.Count > 0)
                {
                    loadHomePanel(dsCompany.Tables[0].Rows[0]);
                }
            }
        }

        private void goodsReceiptEntryGRNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 11;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "GRN Information";
            btnAdd.Text = "Add GRN";
            btnDelete.Text = "Delete GRN";
            btnView.Text = "View GRN";
            btnPrint.Text = "Print GRN";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
            //btnDelete.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 12;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Sales Return";
            btnAdd.Text = "Add Sales Return";
            btnDelete.Text = "Delete Sales Return";
            btnView.Text = "View Sales Return";
            btnPrint.Text = "Print Sales Return";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
            btnDelete.Enabled = false;
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 13;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Purchase Return";
            btnAdd.Text = "Add Purchase Return";
            btnDelete.Text = "Delete Purchase Return";
            btnView.Text = "View Purchase Return";
            btnPrint.Text = "Print Purchase Return";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
            btnDelete.Enabled = false;
        }

        private void issueEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 13;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Issue Entry";
            btnAdd.Text = "Add Issue Entry";
            btnDelete.Text = "Delete Issue Entry";
            btnView.Text = "View Issue Entry";
            btnPrint.Text = "Print Issue Entry";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
            btnDelete.Enabled = false;

        }

        private void adjustmentStockEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 14;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Adjustment Stock";
            btnAdd.Text = "Add Adjustment Stock";
            btnDelete.Text = "Delete Adjustment Stock";
            btnView.Text = "View Adjustment Stock";
            btnPrint.Text = "Print Adjustment Stock";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
            btnDelete.Enabled = false;
        }

        private void closingStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HospiReportViewer _rptViewer = new HospiReportViewer();
            _rptViewer.strReportName = "ClosingStockReport";
            _rptViewer.Show();
        }

        private void stockSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HospiReportViewer _rptViewer = new HospiReportViewer();
            _rptViewer.strReportName = "StockSummaryReport";
            _rptViewer.Show();
        }

        private void productSoldsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HospiReportViewer _rptViewer = new HospiReportViewer();
            _rptViewer.strReportName = "ProductSolds";
            _rptViewer.Show();
        }

        private void allBillsContainingProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HospiReportViewer _rptViewer = new HospiReportViewer();
            _rptViewer.strReportName = "AllBillsContainingProducts";
            _rptViewer.Show();
        }

        private void dayWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HospiReportViewer _rptViewer = new HospiReportViewer();
            _rptViewer.strReportName = "DaywiseReport";
            _rptViewer.Show();
        }

        private void expancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 15;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Expenses";
            btnAdd.Text = "Add Expenses";
            btnDelete.Text = "Delete Expenses";
            btnView.Text = "View Expenses";
            btnPrint.Text = "Print Expenses";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();
            btnDelete.Enabled = false;
        }

        private void rdoInProgress_CheckedChanged(object sender, EventArgs e)
        {
            setInitialpageing();
            DataBindForBill();
            setpageing();
        }

        private void supplierBillDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HospiReportViewer _rptViewer = new HospiReportViewer();
            _rptViewer.strReportName = "SupplierBillDetailsReport";
            _rptViewer.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectIndex > -1)
                {
                    if (formID == 1)
                    {
                        int billID;
                        int OrginalBillId;
                        BillInformation _billInfo = new BillInformation();
                        _billInfo.Controls["gBoxBillInfo"].Controls["lblBillID"].Text = Convert.ToString(grdLoadData.Rows[selectIndex].Cells["OrginalBillID"].Value);
                        _billInfo.ClosedBillId = Convert.ToInt32(grdLoadData.Rows[selectIndex].Cells["BillID"].Value);
                        billID = OrginalBillId = Convert.ToInt32(grdLoadData.Rows[selectIndex].Cells["OrginalBillID"].Value);
                        OrginalBillId = _billInfo.ClosedBillId;
                        //  OrginalBillId = billID;
                        HospitalViewer hopsiView = new HospitalViewer(Convert.ToInt32(billID), Convert.ToInt32(OrginalBillId));
                        hopsiView.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Row!", "Message");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select Row!", "Message");

            }
        }

        private void supplierWiseBillReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HospiReportViewer _rptViewer = new HospiReportViewer();
            _rptViewer.strReportName = "SupplierWiseBillReport";
            _rptViewer.Show();
        }

        private void supplierWiseClosingStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
             HospiReportViewer _rptViewer = new HospiReportViewer();
             _rptViewer.strReportName = "SupplierWiseClosingStockReport";
            _rptViewer.Show();
        }

        //private void aToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    formID = 16;
        //    selectIndex = -1;
        //    setInitialpageing();
        //    lblHeaderlabel.Text = "Vendor Information";
        //    btnAdd.Text = "Add Vendor";
        //    btnDelete.Text = "Delete Vendor";
        //    btnView.Text = "View Vendor";
        //    btnPrint.Text = "Print Vendor";
        //}

        private void addEditVendorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formID = 16;
            selectIndex = -1;
            setInitialpageing();
            lblHeaderlabel.Text = "Vendor Information";
            btnAdd.Text = "Add Vendor";
            btnDelete.Text = "Delete Vendor";
            btnView.Text = "View Supplier";
            btnPrint.Text = "Print Vendor";

            DataSet oDataSet = Common.getAllFormList(formID, pageNo, strFilter);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
                pageIndex = Convert.ToInt32(oDataSet.Tables[1].Rows[0]["PageSize"]);
                lblTotalRecords.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Records"]);
                setpageing();
            }
            hideOtherGroups();

        }

        //private void grdLoadData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        //{
        //    DataGridView grd = sender as DataGridView;
        //    if (grdLoadData.Rows[e.RowIndex].Cells[3].Value.ToString() == "Cancel")
        //    {
        //        grdLoadData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
        //    }
        //    if (grdLoadData.Rows[e.RowIndex].Cells[2].Value.ToString() == "Cancel")
        //    {
        //        grdLoadData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
        //    }
        //    if (grdLoadData.Rows[e.RowIndex].Cells[4].Value.ToString() == "Cancel")
        //    {
        //        grdLoadData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
        //    }
        //}

    }
}
