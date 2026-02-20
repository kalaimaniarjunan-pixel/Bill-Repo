using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HospitalManagement.Process;

namespace HospitalManagement.Pages
{
    public partial class SearchResult : Form
    {
        private DataSet _oDataSet = null;
        private decimal advance = 0;
        int selectedIndex = 0;
        public SearchResult()
        {
            InitializeComponent();
        }

        public SearchResult(DataSet oDataSet)
        {
            InitializeComponent();
            this._oDataSet = oDataSet;
        }

        private void SearchResult_Load(object sender, EventArgs e)
        {
            if (_oDataSet != null)
            {
                DataTable oDataTable = _oDataSet.Tables[0];
                grdSearchResult.DataSource = null;
                BindingSource bSource = new BindingSource();
                bSource.DataSource = oDataTable;
                grdSearchResult.AutoGenerateColumns = true;
                grdSearchResult.DataSource = bSource;
                grdSearchResult.Columns[0].Visible = true;
                grdSearchResult.AllowUserToAddRows = false;
                if (grdSearchResult.RowCount > 0 && oDataTable.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataGridViewRow oRow in grdSearchResult.Rows)
                    {
                        if (i == _oDataSet.Tables[0].Rows.Count) break;
                        int j = 0;
                        foreach (DataColumn oCell in oDataTable.Columns)
                        {
                            oRow.Cells[j].Value = oDataTable.Rows[i][j];
                            oRow.Cells[j].ReadOnly = true;
                            j++;
                        }
                        i++;
                    }
                }
            }
            if (_oDataSet.Tables[0].Rows.Count > 0)
            {
                DataSet oDataSet = BillProcess.selectCustomerPrevAdvance(_oDataSet.Tables[0].Rows[0][0].ToString());
                if (oDataSet.Tables[1].Rows.Count > 0)
                {
                    advance = Convert.ToDecimal(oDataSet.Tables[1].Rows[0][0]);
                    if (advance < 0)
                    {
                        lblBalance.Text = advance.ToString();
                        lblOutStanding.Text = "0.00";
                    }
                    else
                    {
                        lblBalance.Text = "0.00";
                        lblOutStanding.Text = advance.ToString();
                    }
                }
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (selectedIndex > -1)
            {
                string strPatientId = (string)grdSearchResult.Rows[selectedIndex].Cells[0].Value;
                BillInformation _billInfo = new BillInformation(PatientProcess.SelectProcess(strPatientId));
                _billInfo.ShowDialog();
            }
        }

        private void grdSearchResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string strPatientId = (string)grdSearchResult.Rows[e.RowIndex].Cells[0].Value;
                BillInformation _billInfo = new BillInformation(PatientProcess.SelectProcess(strPatientId));
                _billInfo.ShowDialog();
            }
        }

        private void grdSearchResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnOk_Click(sender, new EventArgs());
        }

        private void grdSearchResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                selectedIndex = e.RowIndex;
        }


        private void btnCashBack_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenderAmount.Text.Trim()) || txtTenderAmount.Text.Trim() == "0")
            {
                if (_oDataSet.Tables[0].Rows.Count > 0)
                {
                    decimal tender = Convert.ToDecimal(txtTenderAmount.Text.Trim());
                    string customerID = _oDataSet.Tables[0].Rows[0][0].ToString();
                    decimal bal = 0;
                    if (lblBalance.Text != "0.00")
                    {
                        bal = tender + Convert.ToDecimal(lblBalance.Text);
                    }
                    if (lblOutStanding.Text != "0.00")
                    {
                        bal = Convert.ToDecimal(lblOutStanding.Text) - tender;
                    }

                    int count = BillProcess.cashBackProcess(bal, customerID);
                    if (count > 0)
                    {
                        MessageBox.Show("Cash Back Saved Sucessfully", "Message");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Failed to Save", "Message");
                }
            }
            else
            {
                MessageBox.Show("Please Enter the Tender Amount", "Message");
                txtTenderAmount.Focus();
            }
        }

    }
}
