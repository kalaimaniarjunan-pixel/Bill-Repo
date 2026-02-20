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
    public partial class UserDefinedDiseases : Form
    {
        private int intDeleteRow = 0;
        private UserDefinedCategoryMap _categoryMap = new UserDefinedCategoryMap();
        private UserDefinedOptionMap _optionMap = new UserDefinedOptionMap();

        public UserDefinedDiseases()
        {
            InitializeComponent();
        }

        private void UserDefinedDiseases_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUdDiseasesID.Text))
                loadUdCategory(Convert.ToInt32(txtUdDiseasesID.Text));
            else
                txtUdDiseasesID.Text = "0";
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            DataTable objDT = this.grdUdOptions.DataSource as DataTable;
            if (objDT == null)
            {
                objDT = new DataTable();
                foreach (DataGridViewColumn column in grdUdOptions.Columns)
                {
                    objDT.Columns.Add(column.DataPropertyName);
                }
                createOptionNewRow(ref objDT);
                this.grdUdOptions.DataSource = objDT;
            }
            else
            {
                createOptionNewRow(ref objDT);
            }

            //DataTable oTableReceipt = new DataTable();
            //if (grdUdOptions.Rows.Count == 0)
            //{
            //    //grdUdOptions.Rows.Add();
            //    setOptionsInitialRow(ref oTableReceipt);
            //}
            //else
            //{
            //    getOptionsValueFromGrid(ref oTableReceipt);
            //}
            //createOptionNewRow(ref oTableReceipt);
            //BindingSource bSource = new BindingSource();
            //bSource.DataSource = oTableReceipt;
            //grdUdOptions.AutoGenerateColumns = false;
            //grdUdOptions.DataSource = bSource;
            //setOptionsValuetoGrid(ref oTableReceipt);
        }
        private void createOptionNewRow(ref DataTable odt)
        {
            DataRow oDataRow = odt.NewRow();
            oDataRow["UDTestId"] = 0;
            oDataRow["UDTestDescription"] = "";
            oDataRow["Normal"] = "";
            oDataRow["Amount"] = "0";
            odt.Rows.Add(oDataRow);
        }
        private void setOptionsInitialRow(ref DataTable odt)
        {
            odt.Columns.Add(new DataColumn("UDId", typeof(int)));
            odt.Columns.Add(new DataColumn("TestName", typeof(string)));
            odt.Columns.Add(new DataColumn("Normal", typeof(string)));
            odt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
        }
        private void getOptionsValueFromGrid(ref DataTable odt)
        {
            if (grdUdOptions.Rows.Count > 0)
            {
                setOptionsInitialRow(ref odt);
                foreach (DataGridViewRow oRow in grdUdOptions.Rows)
                {
                    DataRow oDataRow = odt.NewRow();
                    oDataRow["UDId"] = oRow.Cells[0].Value;
                    oDataRow["TestName"] = oRow.Cells[1].Value;
                    oDataRow["Normal"] = oRow.Cells[2].Value;
                    oDataRow["Amount"] = oRow.Cells[3].Value;
                    odt.Rows.Add(oDataRow);
                }
            }
        }
        private void setOptionsValuetoGrid(ref DataTable odt)
        {
            if (odt.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataGridViewRow oRow in grdUdOptions.Rows)
                {
                    if (i == odt.Rows.Count) break;
                    oRow.Cells[0].Value = odt.Rows[i][0];
                    oRow.Cells[1].Value = odt.Rows[i][1];
                    oRow.Cells[2].Value = odt.Rows[i][2];
                    oRow.Cells[3].Value = odt.Rows[i][3];
                    i++;
                }
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

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you like to delete the seleted row", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int count = Convert.ToInt32(grdUdOptions.Rows[intDeleteRow].Cells[0].Value);
                UserDefinedTestProcess.DeleteTest(count);
                if (intDeleteRow > 0)
                {
                    grdUdOptions.Rows.RemoveAt(intDeleteRow);
                    intDeleteRow = 0;
                }
            }
        }

        private void grdUdOptions_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            intDeleteRow = e.RowIndex;
        }
        private void grdUdOptions_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.grdUdOptions.CommitEdit(DataGridViewDataErrorContexts.Commit);
            this.grdUdOptions.EndEdit();
        }
        private void loadUdCategory(int diseasesID)
        {
            DataSet oDataSet = UserDefinedDiseasesProcess.selectProcess(diseasesID);
            if (oDataSet != null)
            {
                txtUdDiseasesID.Text = Convert.ToString(oDataSet.Tables[0].Rows[0]["UDDiseasesID"]);
                txtUDDiseasesName.Text = Convert.ToString(oDataSet.Tables[0].Rows[0]["UDDiseases"]);
                txtTax.Text = Convert.ToString(oDataSet.Tables[0].Rows[0]["Tax"]);
            }
            oDataSet = UserDefinedTestProcess.selectProcess(diseasesID);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
            }
            //txtUDDiseasesName.Enabled = true;
            //btnDeleteRow.Enabled = false;
        }
        public void DataBind(DataTable oTable)
        {
            grdUdOptions.Rows.Clear();
            grdUdOptions.DataSource = oTable;
            //BindingSource bSource = new BindingSource();
            //bSource.DataSource = oTable;
            //grdUdOptions.AutoGenerateColumns = false;
            //grdUdOptions.DataSource = bSource;
            
            //if (grdUdOptions.RowCount > 0 && oTable.Rows.Count > 0)
            //{
            //    int i = 0;
            //    foreach (DataGridViewRow oRow in grdUdOptions.Rows)
            //    {
            //        if (i == oTable.Rows.Count) break;
            //        int j = 0;
            //        foreach (DataColumn oCell in oTable.Columns)
            //        {
            //            oRow.Cells[j].Value = oTable.Rows[i][j];
            //            j++;
            //        }
            //        i++;
            //    }
            //}
        }
        private bool validateControl()
        {
            if (String.IsNullOrEmpty(txtUDDiseasesName.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Category Name", "Message");
                txtUDDiseasesName.Focus();
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateControl())
                {
                    _categoryMap.intCategoryID = Convert.ToInt32(txtUdDiseasesID.Text);
                    _categoryMap.strCategory = txtUDDiseasesName.Text;
                    if (txtTax.Text != string.Empty)
                        _categoryMap.Tax = Convert.ToDecimal(txtTax.Text);
                    else
                        _categoryMap.netAmount = _optionMap.amount;

                    UserDefinedDiseasesProcess.saveProcess(ref _categoryMap);
                    if (!_categoryMap.isError)
                    {
                        grdUdOptions.EndEdit();
                        foreach (DataGridViewRow oRow in grdUdOptions.Rows)
                        {
                            if (string.Empty == Convert.ToString(oRow.Cells[1].Value.ToString()) ) break;
                            _optionMap.UDCategoryID = _categoryMap.intCategoryID;
                            _optionMap.UDId = Convert.ToInt32(oRow.Cells[0].Value);
                            _optionMap.UDDescription = Convert.ToString(oRow.Cells[1].Value.ToString());
                            _optionMap.Normal = Convert.ToString(oRow.Cells[2].Value);
                            if (oRow.Cells[3].Value != DBNull.Value)
                                _optionMap.amount = Convert.ToDecimal(oRow.Cells[3].Value);
                            else
                                _optionMap.amount = 0;
                            if (txtTax.Text != string.Empty && txtTax.Text != "0.00")
                                _optionMap.netAmount = Convert.ToDecimal(((_categoryMap.Tax * _optionMap.amount) / 100) + _optionMap.amount);
                            else
                                _optionMap.netAmount = _optionMap.amount;

                            UserDefinedTestProcess.saveProcess(ref _optionMap);
                        }
                        MessageBox.Show(_categoryMap.strErrorMsg, "Message");
                        //loadUdCategory(_categoryMap.intCategoryID);
                        closeForms();
                    }
                    else
                    {
                        MessageBox.Show(_categoryMap.strErrorMsg, "Message");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.. " + ex.Message, "Message");
            }
        }

    }
}
