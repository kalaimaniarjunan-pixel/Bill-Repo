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
    public partial class Expanses : Form
    {
        public Expanses()
        {
            InitializeComponent();
        }

        private void Expanses_Load(object sender, EventArgs e)
        {
            lblExpenses.Hide();
            DataBind(Common.BindGridControl("Expenses"));
            if (!string.IsNullOrEmpty(lblExpenses.Text))
            {
                LoadExpenses(Convert.ToInt32(lblExpenses.Text));
            }
            else
            {
                lblExpenses.Text = "0";
            }
        }
        private void DataBind(DataTable oTable)
        {
            BindingSource bSource = new BindingSource();
            bSource.DataSource = oTable;
            grdExpensesDetails.AutoGenerateColumns = false;
            grdExpensesDetails.DataSource = bSource;
            if (grdExpensesDetails.RowCount > 0 && oTable.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataGridViewRow oRow in grdExpensesDetails.Rows)
                {
                    if (i == oTable.Rows.Count) break;
                    if (oTable.Columns.Count == 2)
                    {
                        oRow.Cells["ExpensesDetailsId"].Value = 0;
                        oRow.Cells["ExpensesDetails"].Value = oTable.Rows[i]["UdDescription"];
                        oRow.Cells["ExpensesGetId"].Value = oTable.Rows[i]["UDId"];
                        oRow.Cells["Amount"].Value = 0;
                        oRow.Cells["Other"].Value = "";
                    }
                    else
                    {
                        oRow.Cells["ExpensesDetailsId"].Value = Convert.ToInt32(oTable.Rows[i]["ExpensesDetailID"]);
                        oRow.Cells["ExpensesDetails"].Value = oTable.Rows[i]["ExpensesDetails"];
                        oRow.Cells["ExpensesGetId"].Value = oTable.Rows[i]["ExpensesGetId"];
                        oRow.Cells["Amount"].Value = oTable.Rows[i]["Amount"];
                        oRow.Cells["Other"].Value = oTable.Rows[i]["Other"];
                    }
                    i++;
                }
            }
        }
        private void LoadExpenses(int ExpensesID)
        {
            DataSet oDataset = Expensesprocess.selectProcess(ExpensesID);
            if (oDataset != null)
            {
                if (oDataset.Tables[0].Rows.Count > 0)
                {
                    DataRow oRow = oDataset.Tables[0].Rows[0];
                    dtExpensesDate.Text = Convert.ToString(oRow["ExpensesDate"]);
                    txtReceivedAmount.Text = Convert.ToString(oRow["ReceivedAmount"]);
                    lblTotalAmount.Text = Convert.ToString(oRow["ExpensesAmount"]);
                }
            }

            oDataset = Expensesprocess.selectDetailProcess(ExpensesID);
            if (oDataset != null)
            {
                DataBind(oDataset.Tables[0]);
            }
            calAmount();
        }
        private void calAmount()
        {
            if (grdExpensesDetails.RowCount > 0)
            {
                decimal totAmt = 0;
                foreach (DataGridViewRow oRow in grdExpensesDetails.Rows)
                {
                    totAmt = totAmt + Convert.ToDecimal(oRow.Cells["Amount"].Value);
                    //totAmt = Convert.ToDecimal(lblTotalAmount.Text);
                }
                totAmt = Math.Round(totAmt);
                lblTotalAmount.Text = totAmt.ToString("#,#.0#");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            grdExpensesDetails.EndEdit();
            ExpensesMap _expensesMap = new ExpensesMap();
            calAmount();
            if (String.IsNullOrEmpty(txtReceivedAmount.Text)) txtReceivedAmount.Text = "0";
            _expensesMap.intExpensesID = Convert.ToInt32(lblExpenses.Text);
            _expensesMap.dtExpensesDate = Common.GetDateTime(dtExpensesDate.Text);
            _expensesMap.ExpensesAmount = Convert.ToDecimal(lblTotalAmount.Text);
            _expensesMap.ReceivedAmount = Convert.ToDecimal(txtReceivedAmount.Text);
            _expensesMap.ExpenseDetails = new List<ExpensesDetailsMap>();
            grdExpensesDetails.EndEdit();
            if (grdExpensesDetails.RowCount > 0)
            {
                int i = 0;
                foreach (DataGridViewRow oRow in grdExpensesDetails.Rows)
                {
                    if (i == grdExpensesDetails.Rows.Count) break;
                    ExpensesDetailsMap _detailMap = new ExpensesDetailsMap();
                    _detailMap.intExpensesDetailsID = Convert.ToInt32(oRow.Cells["ExpensesDetailsId"].Value);
                    _detailMap.intExpensesID = 0;
                    _detailMap.intExpensesDetails = Convert.ToInt32(oRow.Cells["ExpensesGetId"].Value);
                    _detailMap.strOther = Convert.ToString(oRow.Cells["Other"].Value);
                    _detailMap.Amount = Convert.ToDecimal(oRow.Cells["Amount"].Value);
                    _expensesMap.ExpenseDetails.Add(_detailMap);
                    i++;
                }
            }
            Expensesprocess.saveProcess(ref _expensesMap);
            if (!_expensesMap.isError)
            {
                lblExpenses.Text = Convert.ToString(_expensesMap.intExpensesID);
                MessageBox.Show(_expensesMap.strErrorMsg, "Message");
                closeForms();
                calAmount();
            }
            else
            {
                MessageBox.Show(_expensesMap.strErrorMsg, "Message");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            closeForms();
        }

        private void txtReceivedAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void grdExpensesDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                calAmount();
            }
        }
    }
}
