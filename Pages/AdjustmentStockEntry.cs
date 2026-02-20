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
    public partial class AdjustmentStockEntry : Form
    {
        public GRNObj _grnObj = new GRNObj();
        AdjustmentStockMap _adjustmentStock = new AdjustmentStockMap();

        public AdjustmentStockEntry()
        {
            InitializeComponent();
        }

        private void AdjustmentStockEntry_Load(object sender, EventArgs e)
        {
            lblAdjustmentID.Hide();
            lblProductID.Hide();
            if (!String.IsNullOrEmpty(lblAdjustmentID.Text))
            {
                LoadAdjustmentStock(Convert.ToInt32(lblAdjustmentID.Text));
                //btnSave.Enabled = Common.isPermission("modify");
            }
            else
            {
                lblClosingStock.Text = "0";
                lblAdjustmentID.Text = "0";
                lblTotal.Text = "0";
            }
        }
        private void LoadAdjustmentStock(int AdjustmentID)
        {
            DataSet oDataSet = AdjustmentStockProcess.selectProcess(AdjustmentID);
            if (oDataSet != null)
            {
                if (oDataSet.Tables[0].Rows.Count > 0)
                {
                    DataRow oRow = oDataSet.Tables[0].Rows[0];
                    lblProductID.Text = Convert.ToString(oRow["ProductID"]);
                    btnProductName.Text = Convert.ToString(oRow["ProductName"]); //btnProductName.Text 
                    lblClosingStock.Text = Convert.ToString(oRow["Closing Stock"]);
                    txtAdjustmentStock.Text = Convert.ToString(oRow["Adjustment Stock"]);
                    lblTotal.Text = Convert.ToString(oRow["Total"]);
                    txtReason.Text = Convert.ToString(oRow["Reason"]);
                    btnSave.Enabled = false;
                    btnProductName.Enabled = false;
                    txtAdjustmentStock.Enabled = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateControl())
                {
                    _adjustmentStock.intAdjustmentStockID = Convert.ToInt32(lblAdjustmentID.Text);
                    _adjustmentStock.strProductID = Convert.ToString(lblProductID.Text);
                    _adjustmentStock.strProductname = Convert.ToString(btnProductName.Text);
                    _adjustmentStock.intClosingStock = Convert.ToInt32(lblClosingStock.Text);
                    _adjustmentStock.intAdjustmentStock = Convert.ToInt32(txtAdjustmentStock.Text);
                    _adjustmentStock.intTotal = Convert.ToInt32(lblTotal.Text);
                    _adjustmentStock.strReason = txtReason.Text;

                    AdjustmentStockProcess.saveProcess(ref _adjustmentStock);
                    if (!_adjustmentStock.isError)
                    {
                        lblAdjustmentID.Text = Convert.ToString(_adjustmentStock.intAdjustmentStockID);
                        MessageBox.Show(_adjustmentStock.strErrorMsg, "Message");
                        closeForms();
                    }
                    else
                    {
                        MessageBox.Show(_adjustmentStock.strErrorMsg, "Message");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error..." + ex.Message, "SoftGator");
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
        private bool validateControl()
        {
            if (String.IsNullOrEmpty(lblProductID.Text))
            {
                MessageBox.Show("Please Select the Product Name", "Message");
                //drpProductName.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtAdjustmentStock.Text))
            {
                MessageBox.Show("Please Enter the Adjustment Stock", "Message");
                txtAdjustmentStock.Focus();
                return false;
            }
            return true;
        }

        private void txtAdjustmentStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                if (txtAdjustmentStock.Text.Length == 0 && (e.KeyChar == (char)45))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        private void btnProductName_Click(object sender, EventArgs e)
        {
            LookupProduct _lukProduct = new LookupProduct();
            _lukProduct.Controls["lblname"].Text = "AdjustmentMap";
            _lukProduct.ShowDialog();
            if (Convert.ToInt32(_grnObj.strShortName) > 0)
            {
                lblProductID.Text = _grnObj.strObjId;
                btnProductName.Text = _grnObj.strObjName;
                lblClosingStock.Text = Convert.ToString(AdjustmentStockProcess.getClosingStock(Convert.ToString(lblProductID.Text)));
            }
            else
                MessageBox.Show("Please add the Selected Product to the GRN", "Message");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            closeForms();
        }

        private void txtAdjustmentStock_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAdjustmentStock.Text))
            {
                if (txtAdjustmentStock.Text.StartsWith("-"))
                    lblTotal.Text = Convert.ToString(Convert.ToInt32(lblClosingStock.Text) - Convert.ToInt32(txtAdjustmentStock.Text.Replace("-", "0")));
                else
                    lblTotal.Text = Convert.ToString(Convert.ToInt32(lblClosingStock.Text) + Convert.ToInt32(txtAdjustmentStock.Text));
            }
            else
            {
                lblTotal.Text = Convert.ToString(Convert.ToInt32(lblClosingStock.Text));
            }
        }
    }
}
