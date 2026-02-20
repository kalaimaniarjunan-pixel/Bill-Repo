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
    public partial class GoodsReceipt : Form
    {
        public GRNObj _objGRN = new GRNObj();
        private GRNMap _GRNMap = new GRNMap();
        private decimal tenderAmount = 0;
        private decimal netTotal = 0;
        private decimal changeAmount = 0;
        private decimal balAmount = 0;

        public GoodsReceipt()
        {
            InitializeComponent();
        }
        private void GoodsReceipt_Load(object sender, EventArgs e)
        {
            fillDropDown();
            if (!String.IsNullOrEmpty(txtGRNno.Text))
            {
                loadGRNDetails(Convert.ToInt32(txtGRNno.Text));
                btnSave.Enabled = false;
            }
            else
            {
                txtGRNno.Text = "0";
            }
        }
        private void fillDropDown()
        {
            DataSet ds = ProductsProcess.supplierLoad();
            drpSupplierName.DataSource = ds.Tables[0];
            drpSupplierName.DisplayMember = "SupplierName";
            drpSupplierName.ValueMember = "SupplierID";
            drpSupplierName.SelectedIndex = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateControl())
                {
                    if (MessageBox.Show("Are you confirm to Save?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _GRNMap.intGRNNo = Convert.ToInt32(txtGRNno.Text);
                        _GRNMap.ReceiveDate = Common.GetDateTime(dtReceivedDate.Text);
                        _GRNMap.intSupplierID = Convert.ToInt32(drpSupplierName.SelectedValue);
                        _GRNMap.TotalAmount = Convert.ToDecimal(lblTotalAmount.Text);
                        _GRNMap.ChangeAmount = Convert.ToDecimal(lblChangeAmount.Text);
                        _GRNMap.TenderAmount = Convert.ToDecimal(txtTenderAmount.Text);
                        _GRNMap.TotalPaid = Convert.ToDecimal(lblTotalPaid.Text);
                        _GRNMap.supplierinvoiceno = Convert.ToString(txtsupplierinvoiceno.Text);
                        if (chBoxAddToCart.Checked) _GRNMap.AddToAdvance = 0;
                        else _GRNMap.AddToAdvance = 1;

                        _GRNMap.DetailsMap = new List<GRNDetailsMap>();
                        grdGetProducts.EndEdit();
                        if (grdGetProducts.RowCount > 0)
                        {
                            int i = 0;
                            foreach (DataGridViewRow oRow in grdGetProducts.Rows)
                            {
                                if (i == grdGetProducts.Rows.Count - 1) break;
                                GRNDetailsMap _detailMap = new GRNDetailsMap();
                                if (oRow.Cells["GRNDetailId"].Value == null)
                                    _detailMap.intGRNDetailsID = 0;
                                else
                                    _detailMap.intGRNDetailsID = Convert.ToInt32(oRow.Cells["GRNDetailId"].Value);
                                _detailMap.intGRNNo = 0;
                                _detailMap.strProductID = Convert.ToString(oRow.Cells["ProductID"].Value);
                                _detailMap.strProductName = oRow.Cells["ProductsName"].Value.ToString();
                                _detailMap.intQty = Convert.ToInt32(oRow.Cells["ReceiveQty"].Value);
                                _detailMap.Price = Convert.ToDecimal(oRow.Cells["Price"].Value);
                                _detailMap.TaxinPercentage = Convert.ToDecimal(oRow.Cells["Tax"].Value);
                                _detailMap.TotalAmount = Convert.ToDecimal(oRow.Cells["TotalAmount"].Value);
                                _GRNMap.DetailsMap.Add(_detailMap);
                                i++;
                            }
                        }
                        GRNProcess.saveProcess(ref _GRNMap);
                        if (!_GRNMap.isError)
                        {
                            MessageBox.Show(_GRNMap.strErrorMsg, "Message");
                            closeForms();
                        }
                        else
                        {
                            MessageBox.Show(_GRNMap.strErrorMsg, "Message");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.. " + ex.Message, "Message");
            }
        }
        private void loadGRNDetails(int GRNNo)
        {
            if (GRNNo > 0)
            {
                DataSet oDataset = GRNProcess.selectProcess(GRNNo);
                if (oDataset != null)
                {
                    foreach (DataRow oRow in oDataset.Tables[0].Rows)
                    {
                        txtGRNno.Text = Convert.ToString(oRow["GRNNo"]);
                        drpSupplierName.SelectedValue = oRow["SupplierID"];
                        dtReceivedDate.Text = Convert.ToString(oRow["ReceiveDate"]);
                        lblTotalAmount.Text = Convert.ToString(oRow["TotalAmount"]);
                        lblTotalPaid.Text = Convert.ToString(oRow["TotalAmount"]);
                        lblChangeAmount.Text = Convert.ToString(oRow["ChangeAmount"]);
                        txtTenderAmount.Text = Convert.ToString(oRow["TenderAmount"]);
                        txtsupplierinvoiceno.Text = Convert.ToString(oRow["Supplierinvoiceno"]);
                        if (Convert.ToInt32(oRow["AddToAdvance"]) == 0) chBoxAddToCart.Checked = true;
                        chBoxAddToCart.Enabled = false;
                        txtTenderAmount.ReadOnly = true;
                        txtsupplierinvoiceno.ReadOnly = true;

                    }
                }
                oDataset = GRNProcess.selectDetailProcess(GRNNo);
                if (oDataset != null)
                    DataBind(oDataset.Tables[0]);
                calAmount();
            }
        }
        private void calAmount()
        {
            if (grdGetProducts.RowCount > 0)
            {
                decimal totAmt = 0;
                foreach (DataGridViewRow oRow in grdGetProducts.Rows)
                {
                    totAmt = totAmt + Convert.ToDecimal(oRow.Cells["TotalAmount"].Value);
                }
                //string total = totAmt.ToString("#,#.0#");
                //lblTotalAmount.Text = Math.Round(totAmt).ToString();
                totAmt = Math.Round(totAmt);
                lblTotalAmount.Text = totAmt.ToString("#,#.0#");
            }
        }
        private void DataBind(DataTable oTable)
        {
            BindingSource bSource = new BindingSource();
            bSource.DataSource = oTable;
            grdGetProducts.AutoGenerateColumns = false;
            grdGetProducts.DataSource = bSource;
            if (grdGetProducts.RowCount > 0 && oTable.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataGridViewRow oRow in grdGetProducts.Rows)
                {
                    if (i == oTable.Rows.Count) break;
                    oRow.Cells["GRNDetailId"].Value = Convert.ToInt32(oTable.Rows[i]["GRNDetailId"]);
                    oRow.Cells["ProductID"].Value = oTable.Rows[i]["ProductID"];
                    oRow.Cells["ProductsName"].Value = oTable.Rows[i]["ProductName"];
                    oRow.Cells["ReceiveQty"].Value = oTable.Rows[i]["Quantity"];
                    oRow.Cells["Price"].Value = oTable.Rows[i]["Price"];
                    oRow.Cells["UOM"].Value = oTable.Rows[i]["UOM"];
                    oRow.Cells["Tax"].Value = Convert.ToInt32(oTable.Rows[i]["TaxinPercentage"]);
                    decimal totalamt = Convert.ToDecimal(oTable.Rows[i]["Price"]) * Convert.ToDecimal(oTable.Rows[i]["Quantity"]);
                    decimal tax = totalamt * (Convert.ToDecimal(oTable.Rows[i]["TaxinPercentage"]) / 100);
                    //totalamt = totalamt + (totalamt * (Convert.ToDecimal(oTable.Rows[i]["TaxinPercentage"]) / 100));
                    oRow.Cells["TotalAmount"].Value = totalamt + tax;
                    i++;
                }
                grdGetProducts.Columns[3].ReadOnly = true;
            }
        }
        private bool validateControl()
        {
            if (grdGetProducts.Rows.Count == 0)
            {
                MessageBox.Show("Please Enter atleast one row", "Message");
                return false;
            }
            if (drpSupplierName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select the Supplier", "Message");
                return false;
            }
            if (string.IsNullOrEmpty(txtTenderAmount.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Tender Amount", "Message");
                txtTenderAmount.Focus();
                return false;
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
            closeForms();
        }

        private void grdGetProducts_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 3 || e.ColumnIndex == 5 || e.ColumnIndex == 6)
                {
                    if (Convert.ToInt64(grdGetProducts.Rows[e.RowIndex].Cells["ReceiveQty"].Value) > 0)
                    {
                        decimal taxAmt = 0;
                        decimal totalAmt = 0;
                        long qty = 0;
                        txtTenderAmount.Text = string.Empty;
                        if (!String.IsNullOrEmpty(Convert.ToString(grdGetProducts.Rows[e.RowIndex].Cells["ReceiveQty"].Value)))
                            qty = Convert.ToInt64(grdGetProducts.Rows[e.RowIndex].Cells["ReceiveQty"].Value);
                        if (!String.IsNullOrEmpty(Convert.ToString(grdGetProducts.Rows[e.RowIndex].Cells["Price"].Value)))
                            totalAmt = Convert.ToDecimal(grdGetProducts.Rows[e.RowIndex].Cells["Price"].Value);
                        if (!String.IsNullOrEmpty(Convert.ToString(grdGetProducts.Rows[e.RowIndex].Cells["Tax"].Value)))
                            taxAmt = Convert.ToDecimal(grdGetProducts.Rows[e.RowIndex].Cells["Tax"].Value);

                        grdGetProducts.Rows[e.RowIndex].Cells["TotalAmount"].Value = (qty * totalAmt) + ((qty * totalAmt) * taxAmt / 100);
                    }
                }
                calAmount();
                if (!string.IsNullOrEmpty(txtTenderAmount.Text))
                    tenderAmount = Convert.ToDecimal(txtTenderAmount.Text);
                else
                    tenderAmount = 0;
                balAmount = Convert.ToDecimal(lblBalance.Text);
                netTotal = Convert.ToDecimal(lblTotalAmount.Text);
                changeAmount = (netTotal - tenderAmount) + balAmount;
                changeAmount = Math.Round(changeAmount);
                lblChangeAmount.Text = Convert.ToString(changeAmount);
                lblTotalPaid.Text = changeAmount.ToString("#,#.0#");
                //lblTotalPaid.Text = Convert.ToString(changeAmount);
            }
        }

        private void grdGetProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 1)
                {
                    UserDefinedOptionMap userDefOpt = new UserDefinedOptionMap();
                    LookupProduct _lokUpCat = new LookupProduct(ref userDefOpt);
                    _lokUpCat.Controls["lblname"].Text = "GRNMap";
                    DialogResult OBJ = _lokUpCat.ShowDialog();
                    _lokUpCat.Dispose();
                    if (userDefOpt.ProductID != null)
                    {
                        grdGetProducts.Rows[e.RowIndex].Cells["ProductID"].Value = userDefOpt.ProductID;
                        grdGetProducts.Rows[e.RowIndex].Cells["ProductsName"].Value = userDefOpt.UDDescription;
                        grdGetProducts.Rows[e.RowIndex].Cells["Tax"].Value = userDefOpt.Tax;
                       // ** grdGetProducts.Rows[e.RowIndex].Cells["Price"].Value = userDefOpt.Price;
                        grdGetProducts.Columns[6].ReadOnly = false;
                        grdGetProducts.Rows[e.RowIndex].Cells["Price"].Value = "0.00";
                        //grdGetProducts.Rows[e.RowIndex].Cells["mrp_price"].Value = userDefOpt.mrp_price;
                    }
                }
            }
        }

        private void txtTenderAmount_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTenderAmount.Text))
            {
                txtTenderAmount.Text = "";
                tenderAmount = 0;
                //lblChangeAmount.Text = Convert.ToString(lblTotalAmount.Text);
                changeBal();
            }
            else
            {
                changeBal();
            }
        }
        private void changeBal()
        {
            if (!string.IsNullOrEmpty(txtTenderAmount.Text))
                tenderAmount = Convert.ToDecimal(txtTenderAmount.Text);
            else
                tenderAmount = 0;
            balAmount = Convert.ToDecimal(lblBalance.Text);
            netTotal = Convert.ToDecimal(lblTotalAmount.Text);
            changeAmount = (netTotal - tenderAmount) + balAmount;
            changeAmount = Math.Round(changeAmount);
            lblChangeAmount.Text = Convert.ToString(changeAmount);
        }
        private void drpSupplierName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(drpSupplierName.SelectedValue) > 0)
            {
                DataSet oDataset = GRNProcess.selectBalProcess(Convert.ToInt32(drpSupplierName.SelectedValue));
                if (oDataset.Tables[0].Rows.Count > 0)
                    lblBalance.Text = Convert.ToString((oDataset.Tables[0].Rows[0]["ChangeAmount"]));
                else
                    lblBalance.Text = "0.00";
            }
            else
                lblBalance.Text = "0.00";
            changeBal();
        }

        private void txtTenderAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

    }
}
