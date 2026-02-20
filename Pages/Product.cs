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
using System.Globalization;
namespace HospitalManagement.Pages
{
    public partial class Product : Form
    {
        private ProductsMap _productMap = new ProductsMap();
        private bool isFormNewMode = false;

        public Product()
        {
            InitializeComponent();
        }
        private void Product_Load(object sender, EventArgs e)
        {
            //DataSet ds = ProductsProcess.supplierLoad();
            //cmbsupplier.DataSource = ds.Tables[0];
            //cmbsupplier.DisplayMember = "SupplierName";
            //cmbsupplier.ValueMember = "SupplierID";
            //cmbsupplier.SelectedIndex = 0;
            fillDropDown();
            label10.Visible = false;
            txtTaxable.Visible = false;

            if (!String.IsNullOrEmpty(txtProductId.Text))
            {
                loadProducts(txtProductId.Text);
                txtProductId.Enabled = false;
                isFormNewMode = false;
                cmbsupplier.Enabled = false;
            }
            else
            {
                isFormNewMode = true;
                txtProductId.Text = string.Empty;
            }


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateControl())
                {
                    _productMap.intProductID = txtProductId.Text.Trim();
                    _productMap.strProductName = txtProductName.Text.Trim();
                    _productMap.intPieceQty = Convert.ToInt32(txtPieceQty.Text);
                    _productMap.intUOM = Convert.ToInt32(drpUOM.SelectedValue);
                    //_productMap.intSupplierId = Convert.ToInt32(cmbsupplier.SelectedValue);
                    //_productMap.strSupplierName = cmbsupplier.Text;
                    _productMap.Price = Convert.ToDecimal(txtPrice.Text);
                //    _productMap.Mrpprice = Convert.ToDecimal(txtMrp.Text);
                    if (String.IsNullOrEmpty(txtMrp.Text))
                        _productMap.Mrpprice = 0;
                    else
                        _productMap.Mrpprice = Convert.ToDecimal(txtMrp.Text);
                    _productMap.isTaxable = isTaxable.Checked;
                    _productMap.StGST = Convert.ToDecimal(txtStGST.Text);
                    _productMap.CtGST = Convert.ToDecimal(txtCtGST.Text);
                    _productMap.isActive = isActive.Checked;
                    if (String.IsNullOrEmpty(txtTaxable.Text))
                        _productMap.TaxAmount = 0;
                    else
                        _productMap.TaxAmount = Convert.ToDecimal(txtTaxable.Text);
                    _productMap.strhsnnumber = txthsnnumber.Text;
                    _productMap.intSupplierId = Convert.ToInt32(drpSupplierName.SelectedValue);
                    _productMap.strSupplierName  = Convert.ToString(drpSupplierName.Text);
                    _productMap.strTypeofProduct = Convert.ToString(drpUOM.Text);
                    ProductsProcess.saveProcess(ref _productMap);
                    if (!_productMap.isError)
                    {
                        MessageBox.Show(_productMap.strErrorMsg, "Message");
                        closeForms();
                    }
                    else
                    {
                        throw new Exception(_productMap.strErrorMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.. " + ex.Message, "Message");
            }
        }
        private void loadProducts(string productID)
        {
            DataSet oDataset = ProductsProcess.selectProcess(productID);
            if (oDataset.Tables[0].Rows.Count > 0)
            {
                if (oDataset != null)
                {
                    DataRow oRow = oDataset.Tables[0].Rows[0];
                    txtProductId.Text = Convert.ToString(oRow["ProductId"]);
                    txtProductName.Text = Convert.ToString(oRow["Description"]);
                    drpSupplierName.SelectedValue = Convert.ToInt32(oRow["SupplierId"]);
                   // cmbsupplier.SelectedValue = Convert.ToInt32(oRow["SupplierId"]);
                    drpUOM.SelectedValue = Convert.ToInt32(oRow["Uom"]);                   
                    txtPieceQty.Text = Convert.ToString(oRow["PieceQuantity"]);
                    txtPrice.Text = Convert.ToString(oRow["Price"]);
                    txtMrp.Text = Convert.ToString(oRow["MRPPrice"]);
                    isTaxable.Checked = Convert.ToBoolean(oRow["IsTaxable"]);
                    isActive.Checked = Convert.ToBoolean(oRow["IsActive"]);
                    txtTaxable.Text = Convert.ToString(oRow["TaxAmount"]);
                    txtStGST.Text = Convert.ToString(oRow["StGST"]);
                    txtCtGST.Text = Convert.ToString(oRow["CtGST"]);
                    txthsnnumber.Text = Convert.ToString(oRow["Hsnnumber"]);
                    if (isTaxable.Checked)
                        txtTaxable.Visible = true;
                }
            }
        }
        private bool validateControl()
        {
            if (String.IsNullOrEmpty(txtProductId.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Product Id", "Message");
                txtProductId.Focus();
                return false;
            }
            if (isFormNewMode)
            {
                DataSet ds = ProductsProcess.SameName(txtProductId.Text.Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow oRow = ds.Tables[0].Rows[0];
                    if (oRow[0].ToString().Trim().ToUpper() == txtProductId.Text.Trim().ToUpper())
                    {
                        MessageBox.Show("Product ID Already Exist... Pls Enter New Product ID", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtProductId.Focus();
                        return false;
                    }
                }
            }
            if (String.IsNullOrEmpty(txtProductName.Text.Trim()))
            {
                MessageBox.Show("Please Enter the Product Name", "Message");
                txtProductId.Focus();
                return false;
            }
            if (txtProductName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Poduct Name Length must be greater than 3", "Message");
                txtProductName.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtPieceQty.Text.Trim()))
            {
                MessageBox.Show("Please Enter Piece of Quantity", "Message");
                txtPieceQty.Focus();
                return false;
            }
            //if (cmbsupplier.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select Supplier", "Message");
            //    cmbsupplier.Focus();
            //    return false;
            //}
            if (drpUOM.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select UOM", "Message");
                drpUOM.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtPrice.Text.Trim()))
            {
                MessageBox.Show("Please Enter Selling Price", "Message");
                txtPrice.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtCtGST.Text.Trim()))
            {
                MessageBox.Show("Please Enter CGST", "Message");
                txtCtGST.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtStGST.Text.Trim()))
            {
                MessageBox.Show("Please Enter SGST", "Message");
                txtStGST.Focus();
                return false;
            }

            if (drpSupplierName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Supplier", "Message");
                drpSupplierName.Focus();
                return false;
            }


            return true;
        }
        private void fillDropDown()
        {
            Common.BindDropDownControl(drpUOM, "UOM");
            DataSet ds = ProductsProcess.supplierLoad();
            drpSupplierName.DataSource = ds.Tables[0];
            drpSupplierName.DisplayMember = "SupplierName";
            drpSupplierName.ValueMember = "SupplierID";
            drpSupplierName.SelectedIndex = 0;
        }

        private void isTaxable_CheckedChanged(object sender, EventArgs e)
        {
            //if (isTaxable.Checked)
            //{
            //    txtTaxable.Visible = true;
            //    label10.Visible = true;
            //}
            //else
            //{
            //    txtTaxable.Visible = false;
            //    txtTaxable.Text = "0";
            //    label10.Visible = false;
            //}
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

        private void txtProductId_Leave(object sender, EventArgs e)
        {
            if (isFormNewMode && !string.IsNullOrEmpty(txtProductId.Text))
            {
                DataSet ds = ProductsProcess.SameName(txtProductId.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow oRow = ds.Tables[0].Rows[0];
                    if (oRow[0].ToString().Trim().ToUpper() == txtProductId.Text.Trim().ToUpper())
                    {
                        MessageBox.Show("Product ID Already Exist... Pls Enter New Product ID", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtProductId.Focus();
                    }
                }
            }
        }

        private void txtPieceQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void txtStGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void txtCtGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void txtMrp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }
    }
}
