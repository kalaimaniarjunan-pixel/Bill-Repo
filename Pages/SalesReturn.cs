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
    public partial class SalesReturn : Form
    {
        private SalesReturnMap _SalesReturnMap = new SalesReturnMap();

        public SalesReturn()
        {
            InitializeComponent();
        }

        private void SalesReturn_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSalesReturnID.Text))
            {
                loadSalesReturnDetails(Convert.ToInt32(txtSalesReturnID.Text));
                btnSave.Enabled = false;
                btnShowDetails.Enabled = false;
                txtBillId.ReadOnly = true;
            }
            else
            {
                txtSalesReturnID.Text = "0";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateControl())
                {
                    if (MessageBox.Show("Are you confirm to Save?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _SalesReturnMap.intSalesReturnID = Convert.ToInt32(txtSalesReturnID.Text);
                        _SalesReturnMap.intBillID = Convert.ToInt32(txtBillId.Text);
                        _SalesReturnMap.ReturnDate = Common.GetDateTime(dtReturnDate.Text);
                        if (rdoCard.Checked)
                            _SalesReturnMap.intPaymentType = 2;
                        else if (rdoCash.Checked)
                            _SalesReturnMap.intPaymentType = 1;
                        _SalesReturnMap.DetailsMap = new List<SalesReturnDetailMap>();
                        grdGetProduct.EndEdit();
                        if (grdGetProduct.RowCount > 0)
                        {
                            int i = 0;
                            foreach (DataGridViewRow oRow in grdGetProduct.Rows)
                            {
                                if (i == grdGetProduct.Rows.Count) break;
                                SalesReturnDetailMap _detailMap = new SalesReturnDetailMap();
                                _detailMap.intSalesReturnDetailID = Convert.ToInt32(oRow.Cells["SalesReturnDetailsID"].Value);
                                _detailMap.intSalesReturnID = 0;
                                _detailMap.strProductName = Convert.ToString(oRow.Cells["ProductName"].Value);
                                _detailMap.strProductID = Convert.ToString(oRow.Cells["ProductID"].Value);  //SalesReturnProcess.getProductId(_detailMap.strProductName).ToString();
                                _detailMap.intQunatity = Convert.ToInt32(oRow.Cells["Qty"].Value);
                                _detailMap.Price = Convert.ToDecimal(oRow.Cells["Price"].Value);
                                _SalesReturnMap.DetailsMap.Add(_detailMap);
                                i++;
                            }
                        }
                        SalesReturnProcess.saveProcess(ref _SalesReturnMap);
                        if (!_SalesReturnMap.isError)
                        {
                            MessageBox.Show(_SalesReturnMap.strErrorMsg, "Message");
                            //loadSalesReturnDetails(_SalesReturnMap.intSalesReturnID);
                            closeForms();
                        }
                        else
                        {
                            MessageBox.Show(_SalesReturnMap.strErrorMsg, "Message");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.. " + ex.Message, "Message");
            }
        }
        private void loadSalesReturnDetails(int SalesReturnID)
        {
            if (SalesReturnID > 0)
            {
                DataSet oDataset = SalesReturnProcess.selectProcess(SalesReturnID);
                if (oDataset != null)
                {
                    foreach (DataRow oRow in oDataset.Tables[0].Rows)
                    {
                        txtSalesReturnID.Text = Convert.ToString(oRow["SalesReturnID"]);
                        txtBillId.Text = Convert.ToString(oRow["BillID"]);
                        if (Convert.ToInt32(oRow["PaymentType"]) == 1)
                            rdoCash.Checked = true;
                        else
                            rdoCard.Checked = true;
                        dtReturnDate.Text = Convert.ToString(oRow["ReturnDate"]);
                    }
                }
                oDataset = SalesReturnProcess.selectDetailProcess(SalesReturnID);
                if (oDataset != null)
                    DataBind(oDataset.Tables[0]);
            }
        }
        private void DataBind(DataTable oTable)
        {
            BindingSource bSource = new BindingSource();
            bSource.DataSource = oTable;
            grdGetProduct.AutoGenerateColumns = false;
            grdGetProduct.DataSource = bSource;
            if (grdGetProduct.RowCount > 0 && oTable.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataGridViewRow oRow in grdGetProduct.Rows)
                {
                    if (i == oTable.Rows.Count) break;
                    oRow.Cells["SalesReturnDetailsID"].Value = Convert.ToInt32(oTable.Rows[i]["SalesReturnDetailID"]);
                    oRow.Cells["ProductID"].Value = oTable.Rows[i]["ProductID"];
                    //DataSet ProductName = SalesReturnProcess.getProductName(Convert.ToString(oTable.Rows[i]["ProductID"]));
                    oRow.Cells["ProductName"].Value = oTable.Rows[i]["ProductName"];
                    oRow.Cells["Qty"].Value = oTable.Rows[i]["Quantity"];
                    oRow.Cells["Price"].Value = oTable.Rows[i]["Price"];
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

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            if (validateControl())
            {
                DataSet oDataset = SalesReturnProcess.selectSalesReturnBillId(Convert.ToInt32(txtBillId.Text));
                if (oDataset != null)
                {
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = oDataset.Tables[0];
                    grdGetProduct.AutoGenerateColumns = false;
                    grdGetProduct.DataSource = bSource;
                    if (grdGetProduct.RowCount > 0 && oDataset.Tables[0].Rows.Count > 0)
                    {
                        int i = 0;
                        btnSave.Enabled = true;
                        grdGetProduct.Visible = true;
                        foreach (DataGridViewRow oRow in grdGetProduct.Rows)
                        {
                            if (i == oDataset.Tables[0].Rows.Count) break;
                            oRow.Cells["ProductID"].Value = oDataset.Tables[0].Rows[i]["ProductID"];
                            oRow.Cells["ProductName"].Value = oDataset.Tables[0].Rows[i]["ProductName"];
                            oRow.Cells["Qty"].Value = oDataset.Tables[0].Rows[i]["Qty"];
                            oRow.Cells["Price"].Value = oDataset.Tables[0].Rows[i]["Amount"];
                            if (Convert.ToInt32(oDataset.Tables[0].Rows[i]["PaymentType"]) == 1)
                                rdoCash.Checked = true;
                            else
                                rdoCard.Checked = true;
                            i++;
                        }
                    }
                }
            }
        }
        private bool validateControl()
        {
            if (String.IsNullOrEmpty(txtBillId.Text.Trim()))
            {
                MessageBox.Show("Please Enter Bill Id", "Message");
                txtBillId.Focus();
                return false;
            }
            if (SalesReturnProcess.checkExistingSaleReturn(Convert.ToInt32(txtBillId.Text.Trim())) > 0)
            {
                MessageBox.Show("This Bill Id is Already Added in Sales Return", "Message");
                btnSave.Enabled = false;
                grdGetProduct.Visible = false;
                txtBillId.Focus();
                return false;
            }
            return true;
        }

        private void txtBillId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnShowDetails_Click(sender, new EventArgs());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            closeForms();
        }
    }
}
