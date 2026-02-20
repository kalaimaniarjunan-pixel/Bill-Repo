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
    public partial class LookupProduct : Form
    {
        private int selectedIndex = -1;
        private string strFilterContents = "";
        private UserDefinedOptionMap userDefOpt = null;

        public LookupProduct()
        {
            InitializeComponent();
        }
        public LookupProduct(ref UserDefinedOptionMap userDefOpt)
        {
            InitializeComponent();
            this.userDefOpt = userDefOpt;
        }
        private void LookupProduct_Load(object sender, EventArgs e)
        {
            fillDropDown();
            DataSet oDataSet = BillProcess.selectServiceProductProcess(strFilterContents);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
            }
        }
        private void fillDropDown()
        {
            Common.BindDropDownControl(drpUOM, "UOM");
        }
        private void DataBind(DataTable oTable)
        {
            BindingSource bSource = new BindingSource();
            bSource.DataSource = oTable;
            grdServiceList.AutoGenerateColumns = true;
            grdServiceList.DataSource = bSource;
            grdServiceList.Columns[1].Width = 320;
            grdServiceList.Columns[7].Width = 50;
            grdServiceList.Columns[8].Width = 50;
            grdServiceList.Columns["TaxAmount"].Visible = false;
            int i = 0;
            foreach (DataGridViewRow oRow in grdServiceList.Rows)
            {
                if (i == oTable.Rows.Count) break;
                int j = 0;
                foreach (DataColumn oCell in oTable.Columns)
                {
                    oRow.Cells[j].Value = oTable.Rows[i][j];
                    oRow.Cells[j].ReadOnly = true;
                    j++;
                }
                if (i == oTable.Rows.Count) break;
                oRow.Cells["ProductID"].Value = Convert.ToString(oTable.Rows[i]["ProductID"]);
                oRow.Cells["ProductName"].Value = Convert.ToString(oTable.Rows[i]["ProductName"]);
                oRow.Cells["Price"].Value = Convert.ToDecimal(oTable.Rows[i]["Price"]);
                oRow.Cells["MRP"].Value = Convert.ToDecimal(oTable.Rows[i]["MRP"]);
                oRow.Cells["TaxAmount"].Value = Convert.ToDecimal(oTable.Rows[i]["TaxAmount"]);
                oRow.Cells["StGST"].Value = Convert.ToDecimal(oTable.Rows[i]["StGST"]);
                oRow.Cells["CtGST"].Value = Convert.ToDecimal(oTable.Rows[i]["CtGST"]);
                oRow.Cells["UOM"].Value = Convert.ToString(oTable.Rows[i]["UOM"]);
                oRow.Cells["Qty"].Value = Convert.ToInt32(oTable.Rows[i]["Qty"]);
                i++;
            }
            selectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (selectedIndex > -1)
            {
                if (lblname.Text == "GRNMap")
                {
                    FormCollection fc = Application.OpenForms;
                    if (fc["GoodsReceipt"].IsDisposed != true)
                    {
                        //((GoodsReceipt)fc["GoodsReceipt"])._objGRN.strObjId = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[0].Value);
                        //((GoodsReceipt)fc["GoodsReceipt"])._objGRN.strObjName = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[1].Value);
                        //((GoodsReceipt)fc["GoodsReceipt"])._objGRN.ObjTax = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells[3].Value);
                        //((GoodsReceipt)fc["GoodsReceipt"])._objGRN.ObjPrice = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells[4].Value);
                        //((GoodsReceipt)fc["GoodsReceipt"])._objGRN.strUOM = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[5].Value);
                        this.userDefOpt.ProductID = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[0].Value);
                        this.userDefOpt.UDDescription = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[1].Value);
                        this.userDefOpt.Tax = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells[3].Value);
                        this.userDefOpt.Price = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells[4].Value);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Stock in this Product !", "Message");
                    }
                }
                else if (lblname.Text == "IssueEntryMap")
                {
                    FormCollection fc = Application.OpenForms;
                    if (fc["IssueEntry"].IsDisposed != true)
                    {
                        ((IssueEntry)fc["IssueEntry"])._objGRN.strObjId = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[0].Value);
                        ((IssueEntry)fc["IssueEntry"])._objGRN.strObjName = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[2].Value);
                        this.Close();
                    }
                }
                else if (lblname.Text == "AdjustmentMap")
                {
                    FormCollection fc = Application.OpenForms;
                    if (fc["AdjustmentStockEntry"].IsDisposed != true)
                    {
                        ((AdjustmentStockEntry)fc["AdjustmentStockEntry"])._grnObj.strObjId = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[0].Value);
                        ((AdjustmentStockEntry)fc["AdjustmentStockEntry"])._grnObj.strObjName = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[1].Value);
                        ((AdjustmentStockEntry)fc["AdjustmentStockEntry"])._grnObj.strShortName = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells["ShortName"].Value);

                        this.Close();
                    }
                }
                else
                {
                    if (Convert.ToInt32(grdServiceList.Rows[selectedIndex].Cells[2].Value.ToString().Trim()) > 0)
                    {
                        this.userDefOpt.ProductID = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[0].Value);
                        this.userDefOpt.UDDescription = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[1].Value);
                        this.userDefOpt.Tax = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells[3].Value);
                        this.userDefOpt.Price = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells[4].Value);
                        this.userDefOpt.Qty = Convert.ToInt32(grdServiceList.Rows[selectedIndex].Cells[2].Value);
                        this.userDefOpt.StGST = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells["StGST"].Value);
                        this.userDefOpt.CtGST = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells["CtGST"].Value);
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No Stock in this Product !", "Message");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Row!", "Message");
            }
        }

        private void grdServiceList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selectedIndex > -1)
            {
                if (lblname.Text == "GRNMap")
                {
                    FormCollection fc = Application.OpenForms;
                    if (fc["GoodsReceipt"].IsDisposed != true)
                    {
                        //((GoodsReceipt)fc["GoodsReceipt"])._objGRN.strObjId = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[0].Value);
                        //((GoodsReceipt)fc["GoodsReceipt"])._objGRN.strObjName = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[1].Value);
                        //((GoodsReceipt)fc["GoodsReceipt"])._objGRN.ObjTax = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells[3].Value);
                        //((GoodsReceipt)fc["GoodsReceipt"])._objGRN.ObjPrice = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells[4].Value);
                        //((GoodsReceipt)fc["GoodsReceipt"])._objGRN.strUOM = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[5].Value);
                        this.userDefOpt.ProductID = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[0].Value);
                        this.userDefOpt.UDDescription = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[1].Value);
                        this.userDefOpt.Tax = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells[3].Value);
                        this.userDefOpt.Price = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells[4].Value);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Stock in this Product !", "Message");
                    }
                }
                else if (lblname.Text == "IssueEntryMap")
                {
                    FormCollection fc = Application.OpenForms;
                    if (fc["IssueEntry"].IsDisposed != true)
                    {
                        ((IssueEntry)fc["IssueEntry"])._objGRN.strObjId = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[0].Value);
                        ((IssueEntry)fc["IssueEntry"])._objGRN.strObjName = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[1].Value);
                        ((IssueEntry)fc["IssueEntry"])._objGRN.strShortName = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[2].Value);
                        this.Close();
                    }
                }
                else if (lblname.Text == "AdjustmentMap")
                {
                    FormCollection fc = Application.OpenForms;
                    if (fc["AdjustmentStockEntry"].IsDisposed != true)
                    {
                        ((AdjustmentStockEntry)fc["AdjustmentStockEntry"])._grnObj.strObjId = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[0].Value);
                        ((AdjustmentStockEntry)fc["AdjustmentStockEntry"])._grnObj.strObjName = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[1].Value);
                        ((AdjustmentStockEntry)fc["AdjustmentStockEntry"])._grnObj.strShortName = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[2].Value);

                        this.Close();
                    }
                }
                else
                {
                    if (Convert.ToInt32(grdServiceList.Rows[selectedIndex].Cells[2].Value.ToString().Trim()) > 0  )
                    {
                        this.userDefOpt.ProductID = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[0].Value);
                        this.userDefOpt.UDDescription = Convert.ToString(grdServiceList.Rows[selectedIndex].Cells[1].Value);
                        this.userDefOpt.Tax = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells[3].Value);
                        this.userDefOpt.Price = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells[4].Value);
                        this.userDefOpt.Qty = Convert.ToInt32(grdServiceList.Rows[selectedIndex].Cells[2].Value);
                        this.userDefOpt.StGST = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells["StGST"].Value);
                        this.userDefOpt.CtGST = Convert.ToDecimal(grdServiceList.Rows[selectedIndex].Cells["CtGST"].Value);
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No Stock in this Product !", "Message");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Row!", "Message");
            }
        }

        private void grdServiceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                grdServiceList.Rows[e.RowIndex].Selected = true;
                selectedIndex = e.RowIndex;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            strFilterContents = txtSearch.Text;
            drpUOM.Text = "-- Select UOM --";
            getDetails();
        }
        private void getDetails()
        {
            DataSet oDataSet = BillProcess.selectServiceProductProcess( strFilterContents);
            if (oDataSet != null)
            {
                DataBind(oDataSet.Tables[0]);
            }
        }

        private void drpUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpUOM.SelectedIndex > 0)
                strFilterContents = drpUOM.Text;
                txtSearch.Text = string.Empty;
            if (drpUOM.SelectedIndex == 0)
                strFilterContents = string.Empty;
            getDetails();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
