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
    public partial class IssueEntry : Form
    {
        private IssueEntryMap _IssueEntrymap = new IssueEntryMap();
        public GRNObj _objGRN = new GRNObj();

        public IssueEntry()
        {
            InitializeComponent();
        }

        private void IssueEntry_Load(object sender, EventArgs e)
        {
            lblUserId.Hide();
            fillDropDown();
            if (!String.IsNullOrEmpty(txtIssueID.Text))
            {
                loadIssueEntryDetails(Convert.ToInt32(txtIssueID.Text));
                btnSave.Enabled = false;
            }
            else
            {
                txtIssueID.Text = "0";
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
        private void loadIssueEntryDetails(int IssueEntryId)
        {
            if (IssueEntryId > 0)
            {
                btnSave.Enabled = false;
                drpSupplierName.Enabled = false;
                DataSet oDataset = IssueEntryProcess.selectProcess(IssueEntryId);
                if (oDataset != null)
                {
                    foreach (DataRow oRow in oDataset.Tables[0].Rows)
                    {
                        txtIssueID.Text = Convert.ToString(oRow["IssueEntryID"]);
                        dtIssueDate.Text = Convert.ToString(oRow["IssueDate"]);
                        drpSupplierName.SelectedIndex = Convert.ToInt32(oRow["SupplierID"]);
                    }
                }
                oDataset = IssueEntryProcess.selectDetailProcess(IssueEntryId);
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
                    oRow.Cells["IssueEntryDetailID"].Value = Convert.ToInt32(oTable.Rows[i]["IssueDetailEntryID"]);
                    oRow.Cells["ProductName"].Value = oTable.Rows[i]["ProductName"];
                    oRow.Cells["ProductId"].Value = oTable.Rows[i]["ProductID"];
                    oRow.Cells["Qty"].Value = oTable.Rows[i]["Quantity"];
                    oRow.Cells["UOM"].Value = oTable.Rows[i]["UOM"];
                    oRow.Cells["Stock"].Value = oTable.Rows[i]["Stock"];
                    i++;
                }
            }
        }
        private bool validateControl()
        {
            int rowCount = grdGetProduct.Rows.Count;
            if (drpSupplierName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select the Supplier", "Message");
                return false;
            }
            if (grdGetProduct.Rows.Count == 0)
            {
                MessageBox.Show("Please enter the Product Details", "Message");
                return false;
            }
            for (int i = 0; i < rowCount; i++)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(grdGetProduct.Rows[i].Cells["Qty"].Value)))
                {
                    if (Convert.ToInt32(grdGetProduct.Rows[i].Cells["Qty"].Value) == 0 || string.IsNullOrEmpty(grdGetProduct.Rows[i].Cells["Qty"].Value.ToString()))
                    {
                        string ProductName = grdGetProduct.Rows[i].Cells["ProductName"].Value.ToString();
                        MessageBox.Show("Please Enter the " + ProductName + " Quantity.", "Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            return true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            closeForms();
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
            try
            {
                if (validateControl())
                {
                    if (MessageBox.Show("Are you confirm to Save?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _IssueEntrymap.intIssueEntryID = Convert.ToInt32(txtIssueID.Text);
                        _IssueEntrymap.strIssueEntryDate = Common.GetDateTime(dtIssueDate.Text);
                        _IssueEntrymap.intSupplierID = Convert.ToInt32(drpSupplierName.SelectedValue);
                        _IssueEntrymap.DetailMap = new List<IssueEntryDetailMap>();
                        grdGetProduct.EndEdit();
                        if (grdGetProduct.RowCount > 0)
                        {
                            int i = 0;
                            foreach (DataGridViewRow oRow in grdGetProduct.Rows)
                            {
                                if (i == grdGetProduct.Rows.Count - 1) break;
                                IssueEntryDetailMap _detailMap = new IssueEntryDetailMap();
                                _detailMap.intIssueEntryDetailID = Convert.ToInt32(oRow.Cells["IssueEntryDetailID"].Value);
                                _detailMap.intIssueEntryID = 0;
                                _detailMap.strProductID = Convert.ToString(oRow.Cells["ProductId"].Value);
                                _detailMap.intQty = Convert.ToInt32(oRow.Cells["Qty"].Value);
                                _IssueEntrymap.DetailMap.Add(_detailMap);
                                i++;
                            }
                        }
                        IssueEntryProcess.saveProcess(ref _IssueEntrymap);
                        if (!_IssueEntrymap.isError)
                        {
                            MessageBox.Show(_IssueEntrymap.strErrorMsg, "Message");
                            //loadIssueEntryDetails(_IssueEntrymap.intIssueEntryID);
                            closeForms();
                        }
                        else
                        {
                            MessageBox.Show(_IssueEntrymap.strErrorMsg, "Message");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message");
            }
        }

        private void grdGetProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 1)
                {
                    LookupProduct _lukProduct = new LookupProduct();
                    _lukProduct.Controls["lblname"].Text = "IssueEntryMap";
                    _lukProduct.ShowDialog();
                    if (Convert.ToInt32(_objGRN.strShortName) > 0)
                    {
                        grdGetProduct.Rows[e.RowIndex].Cells["ProductName"].Value = _objGRN.strObjName;
                        grdGetProduct.Rows[e.RowIndex].Cells["ProductId"].Value = _objGRN.strObjId;
                        DataSet ds = ProductsProcess.getProductStock(_objGRN.strObjId);
                        if (ds.Tables[0].Rows.Count > 0 && !String.IsNullOrEmpty(Convert.ToString(grdGetProduct.Rows[e.RowIndex].Cells["ProductName"].Value)))
                        {
                            grdGetProduct.Rows[e.RowIndex].Cells["Qty"].Value = 0;
                            grdGetProduct.Rows[e.RowIndex].Cells["UOM"].Value = ds.Tables[0].Rows[0]["UOMName"];
                            grdGetProduct.Rows[e.RowIndex].Cells["Stock"].Value = ds.Tables[0].Rows[0]["Stock"];
                        }
                    }
                    else
                        MessageBox.Show("Please add the Selected Product to the GRN", "Message");
                }
            }
        }

        private void grdGetProduct_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 3)
                {
                    DataSet ds = ProductsProcess.getProductStock(Convert.ToString(grdGetProduct.Rows[e.RowIndex].Cells["ProductId"].Value));
                    if (ds.Tables[0].Rows.Count > 0 && !String.IsNullOrEmpty(Convert.ToString(grdGetProduct.Rows[e.RowIndex].Cells["ProductId"].Value)))
                    {
                        if (!String.IsNullOrEmpty(Convert.ToString(grdGetProduct.Rows[e.RowIndex].Cells["Qty"].Value)))
                        {
                            int qty = 0;
                            if (int.TryParse(Convert.ToString(grdGetProduct.Rows[e.RowIndex].Cells["Qty"].Value), out qty))
                            {
                                qty = Convert.ToInt32(grdGetProduct.Rows[e.RowIndex].Cells["Qty"].Value);
                                int stockQty = Convert.ToInt32(ds.Tables[0].Rows[0]["Stock"]);
                                if (stockQty < qty)
                                {
                                    MessageBox.Show("Quantity should be less than the stock!", "Message");
                                    grdGetProduct.Rows[e.RowIndex].Cells["Qty"].Value = 0;
                                }
                                else
                                {
                                    grdGetProduct.Rows[e.RowIndex].Cells["UOM"].Value = ds.Tables[0].Rows[0]["UOMName"];
                                    grdGetProduct.Rows[e.RowIndex].Cells["Stock"].Value = stockQty - qty;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please type number!", "Message");
                                grdGetProduct.Rows[e.RowIndex].Cells["Qty"].Value = 0;
                            }
                        }
                    }
                }
            }
        }
    }
}
