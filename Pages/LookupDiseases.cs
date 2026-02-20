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
    public partial class LookupDiseases : Form
    {
        UserDefinedOptionMap _optionMap = null;
        private string _totalTest = string.Empty;
        //private int _testCount = 0;
        private decimal _Amount = 0;
        private decimal total = 0;
        private decimal _bttmTotal = 0;
        private decimal _bttmTotalTax = 0;
        private decimal totalWithTax = 0;
        private bool _isError = false;
        private int _categoryID = 0;
        private decimal tax = 0;
        private decimal _AmountTax = 0;
        private int _billDetailsID = 0;
        private List<UserDefinedOptionMap> listUserDefOpt = null;
        //private UserDefinedOptionMap userDefOpt = null;

        public LookupDiseases()
        {
            InitializeComponent();
        }

        public LookupDiseases(ref List<UserDefinedOptionMap> listUserDefOpt)
        {
            InitializeComponent();
            this.listUserDefOpt = listUserDefOpt;
        }
        public LookupDiseases(ref int billDetailsID)
        {
            InitializeComponent();
            _billDetailsID = billDetailsID;
            reviewBill();
        }
        //public LookupDiseases(ref UserDefinedOptionMap userDefOpt)
        //{
        //    InitializeComponent();
        //    this.userDefOpt = userDefOpt;
        //}
        private void reviewBill()
        {
            btnOk.Enabled = false;
            cBoxDiseases.Enabled = false;
            DataSet oDataset = BillProcess.selectTestDetailProcess(_billDetailsID);
            if (oDataset != null)
            {
                cBoxDiseases.Text = Convert.ToString(oDataset.Tables[0].Rows[0][0]);
                txtTax.Text = Convert.ToString(oDataset.Tables[0].Rows[0][1]);
                grdUdOptions.DataSource = oDataset.Tables[0];
                grdUdOptions.Columns[0].Visible = false;
                grdUdOptions.Columns[1].Visible = false;
                grdUdOptions.Columns[2].Visible = false;
                grdUdOptions.Columns[3].Visible = false;
                grdUdOptions.Columns[4].Visible = false;
                grdUdOptions.Columns[5].Visible = false;
                grdUdOptions.Columns[6].Visible = false;
                grdUdOptions.Columns[7].Visible = false;
                grdUdOptions.Columns[8].Visible = false;
                grdUdOptions.Columns[9].Visible = false;
                Label1.Visible = false;
                toolStripTotal.Visible = false;
                txtUdDiseaseID.Visible = false;
                grdUdOptions.Enabled = false;
                _isError = true;
                //foreach (DataGridViewRow Rows in grdUdOptions.Rows)
                //{
                //    _Amount = Convert.ToDecimal(Rows.Cells["Amount"].Value);
                //    _AmountTax = Convert.ToDecimal(Rows.Cells["NetAmount"].Value);
                //    total = total + _Amount;
                //    totalWithTax = totalWithTax + _AmountTax;
                //    lblNetTotal.Text = Convert.ToString(total);
                //    lblTotalTax.Text = Convert.ToString(totalWithTax);
                //}
            }
        }
        private void LookupCategory_Load(object sender, EventArgs e)
        {
            if (!_isError)
            {
                DataSet oDataSet = Common.BindDropDownCategory();
                if (oDataSet != null)
                {
                    cBoxDiseases.DataSource = oDataSet.Tables[0];
                    cBoxDiseases.DisplayMember = "UDDiseases";
                    cBoxDiseases.ValueMember = "UDDiseasesID";
                    cBoxDiseases.SelectedIndex = 0;
                }
                SelectCheckCol();
                lblNetTotal.Text = Convert.ToString(0);
                lblTotalTax.Text = Convert.ToString(0);
            }
        }

        public void SelectCheckCol()
        {
            DataGridViewCheckBoxColumn objCkBoxSelect = new DataGridViewCheckBoxColumn();
            objCkBoxSelect.HeaderText = "   Select";
            objCkBoxSelect.Name = "Select";
            objCkBoxSelect.Width = 70;
            objCkBoxSelect.DisplayIndex = 0;
            grdUdOptions.Columns.Add(objCkBoxSelect);
        }

        private void loadUdCategory(int diseasesID)
        {
            DataSet oDataSet = null;
            if (diseasesID != 0)
            {
                oDataSet = UserDefinedDiseasesProcess.selectProcessLookup(diseasesID);
                if (oDataSet != null)
                {
                    txtUdDiseaseID.Text = Convert.ToString(oDataSet.Tables[0].Rows[0]["UDDiseasesID"]);
                    cBoxDiseases.Text = Convert.ToString(oDataSet.Tables[0].Rows[0]["UDDiseases"]);
                    txtTax.Text = Convert.ToString(oDataSet.Tables[0].Rows[0]["Tax"]);
                    tax = Convert.ToDecimal(txtTax.Text);
                }
            }
            oDataSet = UserDefinedTestProcess.selectProcessLookup(diseasesID);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
            }
        }
        public void DataBind(DataTable oTable)
        {
            BindingSource bSource = new BindingSource();
            bSource.DataSource = oTable;
            grdUdOptions.AutoGenerateColumns = false;
            grdUdOptions.DataSource = bSource;
            if (grdUdOptions.RowCount > 0 && oTable.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataGridViewRow oRow in grdUdOptions.Rows)
                {
                    if (i == oTable.Rows.Count) break;
                    int j = 0;
                    foreach (DataColumn oCell in oTable.Columns)
                    {
                        oRow.Cells[j].Value = oTable.Rows[i][j];
                        j++;
                    }
                    i++;
                }
            }
            if (cBoxDiseases.SelectedIndex != 0)
            {
                foreach (DataGridViewRow oRow in grdUdOptions.Rows)
                {
                    _Amount = Convert.ToDecimal(oRow.Cells["Amount"].Value);
                    _bttmTotal = _bttmTotal + _Amount;
                }
                lblNetTotal.Text = Convert.ToString(_bttmTotal);
                foreach (DataGridViewRow oRow in grdUdOptions.Rows)
                {
                    _Amount = Convert.ToDecimal(oRow.Cells["NetAmount"].Value);
                    _bttmTotalTax = _bttmTotalTax + _Amount;
                }
                lblTotalTax.Text = Convert.ToString(_bttmTotalTax);
            }
            else
            {
                lblTotalTax.Text = Convert.ToString(0);
                lblNetTotal.Text = Convert.ToString(0);
            }
        }

        private void cBoxCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            total = Convert.ToInt32(0);
            _bttmTotal = Convert.ToInt32(0);
            totalWithTax = Convert.ToInt32(0);
            _bttmTotalTax = Convert.ToInt32(0);
            _categoryID = Convert.ToInt32(cBoxDiseases.SelectedValue);
            
            if (_categoryID != 0)
            {
                loadUdCategory(_categoryID);
                grdUdOptions.Rows[grdUdOptions.CurrentRow.Index].Cells["Report"].ReadOnly = true;
            }
            else
            {
                loadUdCategory(Convert.ToInt32(total));
                txtUdDiseaseID.Text = Convert.ToString(total);
            }
        }

        private void netAmountCalculation()
        {
            if (_isError)
            {
                _Amount = Convert.ToDecimal(grdUdOptions.CurrentRow.Cells["Amount"].Value);
                total = total + _Amount;
                lblNetTotal.Text = Convert.ToString(total);
                _Amount = Convert.ToDecimal(grdUdOptions.CurrentRow.Cells["NetAmount"].Value);
                totalWithTax = totalWithTax + _Amount;
                lblTotalTax.Text = Convert.ToString(totalWithTax);
            }
            else if (!_isError)
            {
                _Amount = Convert.ToDecimal(grdUdOptions.CurrentRow.Cells["Amount"].Value);
                total = total - _Amount;
                lblNetTotal.Text = Convert.ToString(total);
                _Amount = Convert.ToDecimal(grdUdOptions.CurrentRow.Cells["NetAmount"].Value);
                totalWithTax = totalWithTax - _Amount;
                lblTotalTax.Text = Convert.ToString(totalWithTax);
            }
        }
        private void grdUdOptions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grdUdOptions.Columns["Select"].Index)
            {
                grdUdOptions.EndEdit();//Stop editing of cell.
                if ((bool)grdUdOptions.Rows[e.RowIndex].Cells["Select"].Value)
                {
                    _isError = true;
                    grdUdOptions.Rows[grdUdOptions.CurrentRow.Index].Cells["Report"].ReadOnly = false;
                    grdUdOptions.EditMode = DataGridViewEditMode.EditOnEnter;
                    grdUdOptions.CurrentRow.Cells["Select"].Selected = false; 
                    grdUdOptions.CurrentRow.Cells["Report"].Selected = true;
                    netAmountCalculation();
                }
                else if (!(bool)grdUdOptions.Rows[e.RowIndex].Cells["Select"].Value)
                {
                    _isError = false;
                    grdUdOptions.Rows[grdUdOptions.CurrentRow.Index].Cells["Report"].ReadOnly = true;
                    grdUdOptions.CurrentRow.Cells["Report"].Value = string.Empty;
                    netAmountCalculation();
                }
            }
        }
        private void calculateTotal()
        {
            foreach (DataGridViewRow Rows in grdUdOptions.Rows)
            {
                bool isChecked;
                String strChecked = (Rows.Cells["Select"].Value == null)
                    ? String.Empty : Rows.Cells["Select"].Value.ToString();
                if (bool.TryParse(strChecked, out isChecked) && isChecked)
                {
                    _Amount = Convert.ToDecimal(Rows.Cells["Amount"].Value);
                    _AmountTax = Convert.ToDecimal(Rows.Cells["NetAmount"].Value);
                    total = total + _Amount;
                    totalWithTax = totalWithTax + _AmountTax;
                    lblNetTotal.Text = Convert.ToString(total);
                    lblTotalTax.Text = Convert.ToString(totalWithTax);
                }
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateControl())
                {
                    total = 0;
                    totalWithTax = 0;
                    calculateTotal();
                    _optionMap = new UserDefinedOptionMap();
                    _optionMap.UDCategoryID = Convert.ToInt32(cBoxDiseases.SelectedValue);
                    _optionMap.amount = Convert.ToDecimal(total);
                    //_optionMap.TestCount = _testCount;
                    _optionMap.Tax = tax;
                    _optionMap.netAmount = totalWithTax;

                    _optionMap._listPatientReport = new List<PatientReportMap>();
                    foreach (DataGridViewRow oRow in grdUdOptions.Rows)
                    {
                        bool isChecked;
                        String strChecked = (oRow.Cells["Select"].Value == null)
                            ? String.Empty : oRow.Cells["Select"].Value.ToString();
                        if (bool.TryParse(strChecked, out isChecked) && isChecked)
                        {
                            PatientReportMap _patientReportMap = new PatientReportMap();
                            _patientReportMap.intUDID = Convert.ToInt32(oRow.Cells["UDId"].Value);
                            _patientReportMap.Description = Convert.ToString(oRow.Cells["Description"].Value);
                            _patientReportMap.Report = Convert.ToString(oRow.Cells["Report"].Value);
                            _patientReportMap.Normal = Convert.ToString(oRow.Cells["Normal"].Value);
                            _patientReportMap.Amount = Convert.ToDecimal(oRow.Cells["Amount"].Value);
                            _patientReportMap.NetAmount = Convert.ToDecimal(oRow.Cells["NetAmount"].Value);
                            _optionMap._listPatientReport.Add(_patientReportMap);
                        }
                    }
                    closeForms();
                    this.listUserDefOpt.Add(_optionMap);

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.. " + ex.Message, "Message");
            }
        }
        private bool validateControl()
        {
            btnOk.Enabled = true;
            _totalTest = string.Empty;
            int rowCount = grdUdOptions.Rows.Count;
            grdUdOptions.EndEdit();//Stop editing of cell.

            if (cBoxDiseases.SelectedIndex == 0)
            {
                MessageBox.Show("Please Enter the Category Name", "Message");
                cBoxDiseases.Focus();
                return false;
            }

            for (int i = 0; i < rowCount; i++)
            {
                if (Convert.ToBoolean(grdUdOptions.Rows[i].Cells["Select"].Value) == true)
                {
                    if (Convert.ToString(grdUdOptions.Rows[i].Cells["Report"].Value) == string.Empty)
                    {
                        string value = grdUdOptions.Rows[i].Cells["Description"].Value.ToString();
                        MessageBox.Show("Please Fill the " + value + " Test Report.", "Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                if (Convert.ToBoolean(grdUdOptions.Rows[i].Cells["Select"].Value) == true)
                {
                    string test = grdUdOptions.Rows[i].Cells["Description"].Value.ToString();
                    _totalTest = string.Concat(_totalTest, test, ",");
                    //_testCount = _testCount + 1;
                }
                if (i == rowCount - 1)
                {
                    int selected = 0;
                    foreach (DataGridViewRow row in grdUdOptions.Rows)
                    {
                        if (!Convert.ToBoolean(row.Cells["Select"].Value))
                        {
                            selected = selected + 1;
                            if (selected == rowCount)
                            {
                                MessageBox.Show("Please Select any one Test..", "Message",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return false;
                            }
                        }
                    }
                    if (_totalTest != string.Empty)
                    {
                        string listOfTest = _totalTest.Remove(_totalTest.Length - 1, 1);
                        DialogResult dialogResult = MessageBox.Show("The Seleted Tests are " + listOfTest + "..", "Message",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (DialogResult.OK == dialogResult)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ////////////  Over Work //////////////////

        //private void checkBoxReady_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBoxReady.Checked == true)
        //    {
        //        btnOk.Enabled = true;
        //        _totalTest = string.Empty;
        //        int rowCount = grdUdOptions.Rows.Count;
        //        grdUdOptions.EndEdit();//Stop editing of cell.

        //        for (int i = 0; i < rowCount; i++)
        //        {
        //            if (Convert.ToBoolean(grdUdOptions.Rows[i].Cells["Select"].Value) == true)
        //            {
        //                if (Convert.ToString(grdUdOptions.Rows[i].Cells["Report"].Value) == string.Empty)
        //                {
        //                    string value = grdUdOptions.Rows[i].Cells["Description"].Value.ToString();
        //                    MessageBox.Show("Please Fill the " + value + " Test Report.", "Message",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                    btnOk.Enabled = false;
        //                    checkBoxReady.Checked = false;
        //                    break;
        //                }
        //            }
        //            if (Convert.ToBoolean(grdUdOptions.Rows[i].Cells["Select"].Value) == true)
        //            {
        //                string test = grdUdOptions.Rows[i].Cells["Description"].Value.ToString();
        //                _totalTest = string.Concat(_totalTest, test, ",");
        //            }
        //            if (i == rowCount - 1)
        //            {
        //                int selected = 0;
        //                foreach (DataGridViewRow row in grdUdOptions.Rows)
        //                {
        //                    if (!Convert.ToBoolean(row.Cells["Select"].Value))
        //                    {
        //                        selected = selected + 1;
        //                        if (selected == rowCount)
        //                        {
        //                            MessageBox.Show("Please Select any one Test..", "Message",
        //                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                            btnOk.Enabled = false;
        //                            checkBoxReady.Checked = false;
        //                            break;
        //                        }
        //                    }
        //                }
        //                if (_totalTest != string.Empty)
        //                {
        //                    string listOfTest = _totalTest.Remove(_totalTest.Length - 1, 1);
        //                    MessageBox.Show("The Seleted Tests are " + listOfTest + "..", "Message",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        btnOk.Enabled = false;
        //    }
        //}

        //private void rbSelectAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    //foreach (DataGridViewRow row in grdUdOptions.Rows)
        //    //{
        //    //    //row.Cells["Select"].Value = true;
        //    //    //row.Cells["Report"].ReadOnly = false;
        //    //    //lblNetTotal.Text = Convert.ToString(netTotal);
        //    //}
        //}

        //private void rbUnCheckAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    //foreach (DataGridViewRow row in grdUdOptions.Rows)
        //    //{
        //    //    //netTotal = 0;
        //    //    //row.Cells["Select"].Value = false;
        //    //    //row.Cells["Report"].ReadOnly = true;
        //    //    //lblNetTotal.Text = Convert.ToString(netTotal);
        //    //}
        //}
    }
}
