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
using Microsoft.Reporting.WinForms;

namespace HospitalManagement.Pages
{
    public partial class BillInformation : Form
    {
        UserDefinedOptionMap _optionMap = new UserDefinedOptionMap();
        BillMap _billMap = new BillMap();
        private DataSet oDataSet = null;
        private decimal total = 0;
        private decimal netTotal = 0;
        private int intRowNo = 0;
        private decimal discountPercent = 0;
        private decimal discountAmount = 0;
        private decimal tenderAmount = 0;
        private decimal changeAmount = 0;
        private decimal advance = 0;
        public int formIndex = 0;
        public int ClosedBillId = 0;
      
        public BillInformation()
        {
            InitializeComponent();
        }

        public BillInformation(DataSet oDataSet)
        {
            this.oDataSet = oDataSet;
            InitializeComponent();
        }

        private void BillInformation_Load(object sender, EventArgs e)
        {
            // Customer Info
            if (oDataSet != null)
            {
                DataTable oDataTable = oDataSet.Tables[0];
                lblCustomerID.Text = oDataTable.Rows[0][0].ToString();
                lblCustomerName.Text = oDataTable.Rows[0][1].ToString();
                lblMobileNumber.Text = oDataTable.Rows[0][2].ToString();
            }
            
            //Grid rows 
            DataTable oTableReceipt = new DataTable();
            setOptionsInitialRow(ref oTableReceipt);
            createOptionNewRow(ref oTableReceipt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = oTableReceipt;
            grdBillDetails.AutoGenerateColumns = false;
            grdBillDetails.DataSource = bSource;
            setOptionsValuetoGrid(ref oTableReceipt);

            fillDropDown();
            if (grdBillDetails.Rows.Count > 0)
            {
                grdBillDetails.Rows[0].Cells[1].Selected = true;
            }
            if (String.IsNullOrEmpty(lblBillID.Text) || lblBillID.Text =="lblBillId")
            {
                lblStatus.Text = "Open";
                lblBillID.Text = "0";
                lblClosedBillId.Hide();
                btnCancelBill.Enabled = false;
                btnPrintBill.Enabled = false;
                btnPrintReport.Enabled = false;
                btnCompleteBill.Enabled = false;
                lblBillDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                loadPrevCustomer(0);
            }
            else
            {
                btnSave.Enabled = false;
                chBoxDiscount.Enabled = false;
                loadBillDetails(Convert.ToInt32(lblBillID.Text));
                lblClosedBillId.Text = lblBillID.Text;
                if (lblStatus.Text == "Closed")
                {
                    lblBillID.Hide();
                    lblClosedBillId.Text = "" + ClosedBillId;
                }
                loadPrevCustomer(Convert.ToInt32(lblBillID.Text));
            }
        }
        public void loadPrevCustomer(int billId)
        {
            if (lblCustomerID.Text != "")
            {
                DataSet oDataSet = BillProcess.selectCustomerPrev(lblCustomerID.Text, billId);
                if (oDataSet != null)
                {
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = oDataSet.Tables[0];
                    grdpreviewData.AutoGenerateColumns = true;
                    grdpreviewData.DataSource = bSource;
                    grdpreviewData.RowHeadersVisible = false;
                    if (grdpreviewData.RowCount > 0 && oDataSet.Tables[0].Rows.Count > 0)
                    {
                        int i = 0;
                        foreach (DataGridViewRow oRow in grdpreviewData.Rows)
                        {
                            if (i == oDataSet.Tables[0].Rows.Count) break;
                            int j = 0;
                            foreach (DataColumn oCell in oDataSet.Tables[0].Columns)
                            {
                                oRow.Cells[j].Value = oDataSet.Tables[0].Rows[i][j];
                                oRow.Cells[j].ReadOnly = true;
                                j++;
                            }
                            i++;
                        }
                        grdpreviewData.Columns[0].Visible = false;
                    }
                }
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
        private void loadBillDetails(int BillId)
        {
            if (BillId > 0)
            {
                DataSet oDataset = BillProcess.selectProcess(BillId);
                if (oDataset != null)
                {
                    foreach (DataRow oRow in oDataset.Tables[0].Rows)
                    {
                        lblBillDate.Text = Common.GetStringDate(Convert.ToDateTime(oRow["BillDate"]));
                        lblStatus.Text = Convert.ToString(oRow["Status"]);
                        lblCustomerID.Text = Convert.ToString(oRow["PatientID"]);
                        lblCustomerName.Text = Convert.ToString(oRow["PatientName"]);
                        lblMobileNumber.Text = Convert.ToString(oRow["Mobile"]);
                        txtDiscountamount.Text = Convert.ToString(oRow["DiscountPercent"]);
                        txtDiscountName.Text = Convert.ToString(oRow["DiscountName"]);
                        drpTenderType.SelectedValue = Convert.ToInt32(oRow["TypeOfPayment"]);
                        drpBankName.SelectedValue = Convert.ToInt32(oRow["Bankname"]);
                        txtCardno.Text = Convert.ToString(oRow["CardNo"]);
                        txtChequeNo.Text = Convert.ToString(oRow["ChequeNo"]);
                        txtTenderAmount.Text = Convert.ToString(oRow["TenderAmount"]);
                        lblAmount.Text = Convert.ToString(oRow["Amount"]);
                        lblQuantity.Text = Convert.ToString(oRow["Tax"]);
                        lblTenderAmount.Text = Convert.ToString(oRow["TenderAmount"]);
                        lblDiscount.Text = Convert.ToString(oRow["DiscountAmount"]);
                        lblTotalAmount.Text = Convert.ToString(oRow["NetAmount"]);
                        lblChangeAmount.Text = Convert.ToString(oRow["ChangeAmount"]);
                        lblTotalpay.Text = Convert.ToString(oRow["AmountPaid"]);
                        if (Convert.ToInt32(oRow["AddToAdvance"]) == 0) chBoxAddAmount.Checked = true;
                        // **  chBoxAddAmount.Enabled = false;
                         chBoxAddAmount.Enabled = true;
                    }
                }
                drpTenderType.Enabled = false;
              // **    txtTenderAmount.ReadOnly = true;
                txtTenderAmount.ReadOnly = false;
                txtDiscountamount.ReadOnly = true;
                drpBankName.Enabled = false;
                txtCardno.ReadOnly = true;
                txtChequeNo.ReadOnly = true;
                if (lblStatus.Text == "Cancel")
                {
                    btnCancelBill.Enabled = false;
                    btnPrintBill.Enabled = true;
                    btnCompleteBill.Enabled = false;
                }
                else if (lblStatus.Text == "Closed")
                {
                    btnCompleteBill.Enabled = false;
                    btnCancelBill.Enabled = false;
                }
                oDataset = BillProcess.selectDetailProcess(BillId);
                if (oDataset != null)
                    DataBind(oDataset.Tables[0]);
            }
        }

        private void fillDropDown()
        {
            Common.BindDropDownControl(drpTenderType, "Tender Type");
            Common.BindDropDownControl(drpBankName, "Bank Name");
        }

        private bool validateControl()
        {
            if (grdBillDetails.Rows.Count == 1)
            {
                MessageBox.Show("Please Enter values atleast one row", "Message");
                return false;
            }
            if (drpTenderType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select the Tender Type", "Message");
                drpTenderType.Focus();
                return false;
            }
            if (drpBankName.Visible == true)
            {
                if (drpBankName.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Bank Name", "Message");
                    drpBankName.Focus();
                    return false;
                }
            }
            if (chBoxDiscount.Checked)
            {
                if (string.IsNullOrEmpty(txtDiscountamount.Text.Trim()) || txtDiscountamount.Text.Trim() == "0")
                {
                    MessageBox.Show("Please Enter the Discount Amount", "Message");
                    txtDiscountamount.Focus();
                    return false;
                }
            }
            //if (string.IsNullOrEmpty(txtTenderAmount.Text.Trim()) || txtTenderAmount.Text.Trim() == "0")

            if (string.IsNullOrEmpty(txtTenderAmount.Text.Trim()) )
            {
                MessageBox.Show("Please Enter the Tender Amount", "Message");
                txtTenderAmount.Focus();
                return false;
            }

            if (grdBillDetails.RowCount > 0)
            {
                int i = 0;
                foreach (DataGridViewRow oRow in grdBillDetails.Rows)
                {
                    if (i == grdBillDetails.Rows.Count - 1) break;
                    if (lblCustomerName.Text == string.Empty)
                    {
                        MessageBox.Show("Please Select Customer", "Soft Gator");
                        return false;
                    }
                    //if (Convert.ToInt32(drpEmployee.SelectedIndex) == 0)
                    //{
                    //    MessageBox.Show("Please Select Employee", "Soft Gator");
                    //    return false;
                    //}
                    if (String.IsNullOrEmpty(Convert.ToString(oRow.Cells["ProductId"].Value)))
                    {
                        MessageBox.Show("Please Select Product", "Apalis Tender");
                        return false;
                    }

                    // New changes 18 May 2019 Product Qty Count Validtion check Start  
                    if (1 == 1)
                    {
                        int Quantity = Common.getGRNProductQty(Convert.ToString(oRow.Cells["ProductID"].Value));
                        // **if (Quantity == 0 || Quantity < Convert.ToInt32(oRow.Cells["Qty"].Value))
                        //{
                        //    MessageBox.Show("No Stock in this Products!", "Apalis Tender");
                        //    return false;
                        //}
                      // ** if (Convert.ToString(oRow.Cells["drpType"].Value) == "BOX")
                        if (Quantity == 0 || Quantity < Convert.ToInt32(oRow.Cells["Qty"].Value))
                        {
                            DataSet oDataset = BillProcess.SelectPieceofQuantity(Convert.ToString(oRow.Cells["ProductID"].Value));
                            if (oDataset != null)
                            {
                                int piece = Convert.ToInt32(oDataset.Tables[0].Rows[0][0]);
                                if (piece == 0)
                                {
                                    piece = 1;
                                }
                                if ((piece * Convert.ToInt32(oRow.Cells["Qty"].Value)) > Quantity)
                                {
                                    int Box = Quantity / piece;
                                    decimal Pack = Quantity % piece;
                                // **   MessageBox.Show(Convert.ToString(oRow.Cells["ProductID"].Value) + "  Available Stock is " + Box + "  Box &  " + Pack + "  Pack.  Please Enter Valid Quantity!", "Soft Gator");
                                    MessageBox.Show("R_No : "+ Convert.ToString(oRow.Cells[14].Value) + "  " + Convert.ToString(oRow.Cells["ProductID"].Value) + "  Available Stock is " + Box + "  Box &  " + Pack + "  Pack.  Please Enter Valid Quantity!", "Apalis Tender"); 
                                    return false;
                                }
                            }
                        }
                        i++;

                        // New changes 18 May 2019 Product Qty Count Validtion check End  
                    }
                }
            }




            //if (netTotal > tenderAmount + discountAmount)
            //{
            //    MessageBox.Show("Please Enter the valid Amount", "Message");
            //    txtTenderAmount.Focus();
            //    return false;
            //}
            return true;
        }

        private void closeForms()
        {
            FormCollection fc = Application.OpenForms;
            if (fc["Home"].IsDisposed != true)
            {
                ((Home)fc["Home"]).closeFormBill();
            }
            this.Close();
        }

        private void BillInformation_Activated(object sender, EventArgs e)
        {
            if (((LookupDiseases)(Application.OpenForms["LookupCategory"])) != null && !((LookupDiseases)(Application.OpenForms["LookupCategory"])).IsDisposed)
            {
                ((LookupDiseases)(Application.OpenForms["LookupCategory"])).Close();
            }
            if (((SearchResult)(Application.OpenForms["SearchResult"])) != null && !((SearchResult)(Application.OpenForms["SearchResult"])).IsDisposed)
            {
                ((SearchResult)(Application.OpenForms["SearchResult"])).Close();
            }
            if (((SearchPatient)(Application.OpenForms["SearchPatient"])) != null && !((SearchPatient)(Application.OpenForms["SearchPatient"])).IsDisposed)
            {
                ((SearchPatient)(Application.OpenForms["SearchPatient"])).Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            closeForms();
        }

        public void DataBind(DataTable oTable)
        {
            BindingSource bSource = new BindingSource();
            bSource.DataSource = oTable;
            grdBillDetails.AutoGenerateColumns = false;
            grdBillDetails.DataSource = bSource;
            //grdBillDetails.Enabled = false;
            if (grdBillDetails.RowCount > 0 && oTable.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataGridViewRow oRow in grdBillDetails.Rows)
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string message = string.Empty;
            string ProductID = string.Empty;
            foreach (DataGridViewRow row in grdBillDetails.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Chkbill"].Value);
                if (isSelected)
                {
                    ProductID = Convert.ToString(row.Cells["ProductID"].Value);
                    message += Environment.NewLine;
                    message += row.Cells["ProductID"].Value.ToString();
                }
            }

           // MessageBox.Show("Selected Values" + message);
            
             if (validateControl())
            {
                _billMap.intBillID = Convert.ToInt32(lblBillID.Text);
                _billMap.dtBillDate = System.DateTime.Now;
                _billMap.strPatientID = lblCustomerID.Text;
                //_billMap.intStatus = Common.getUDID("Bill Status", "Closed");
                _billMap.intStatus = Common.getUDID("Bill Status", "In Progress");
                _billMap.intTypeOfPayment = Convert.ToInt32(drpTenderType.SelectedValue);
                if (drpTenderType.SelectedIndex == 1)
                {
                    _billMap.TenderAmount = Convert.ToDecimal(txtTenderAmount.Text);
                    _billMap.strCardNo = string.Empty;
                    _billMap.strChequeNo = string.Empty;
                    _billMap.intBankname = 0;
                }
                else if (drpTenderType.SelectedIndex == 2)
                {
                    _billMap.strCardNo=  string.Empty;
                    _billMap.strChequeNo = txtChequeNo.Text;
                    _billMap.intBankname = Convert.ToInt32(drpBankName.SelectedValue);
                }
                else
                {
                    _billMap.strCardNo = txtCardno.Text;
                    _billMap.strChequeNo = string.Empty;
                    _billMap.intBankname = Convert.ToInt32(drpBankName.SelectedValue);
                }
                _billMap.TenderAmount = Convert.ToDecimal(txtTenderAmount.Text);

                if (chBoxDiscount.Checked)
                {
                    _billMap.strDiscountName = txtDiscountName.Text;
                    //_billMap.DiscountAmount = Convert.ToDecimal(txtDiscountamount.Text);
                    _billMap.DiscountPercent = Convert.ToDecimal(txtDiscountamount.Text);
                    _billMap.DiscountAmount = Convert.ToDecimal(lblDiscount.Text);
                }
                else
                {
                    //kalai change discount grid process 16072017

                    //_billmap.strdiscountname = string.empty;
                    //_billmap.discountamount = 0;
                    //_billmap.discountpercent = 0;

                    //kalai change discount grid process 16072017
                }
                

                        _billMap.Amount = Convert.ToDecimal(lblAmount.Text);
                        //_billMap.Tax = Convert.ToDecimal(lblQuantity.Text);                    
                        _billMap.Change = Convert.ToDecimal(lblChangeAmount.Text);
                        _billMap.NetAmount = Convert.ToDecimal(lblTotalAmount.Text);
                        _billMap.AmountPaid = (_billMap.NetAmount - _billMap.DiscountAmount);
                        if (chBoxAddAmount.Checked) _billMap.AddToAdvance = 0;
                        else _billMap.AddToAdvance = 1;
                    
                   



                if (grdBillDetails.RowCount > 0)
                {
                    int i = 0;
                    foreach (DataGridViewRow oRow in grdBillDetails.Rows)
                    {
                        if (string.IsNullOrEmpty(oRow.Cells["ProductName"].Value.ToString().Trim())) break;
                        BillDetailsMap _detailMap = new BillDetailsMap();
                        _detailMap.intBillDetailID = Convert.ToInt32(oRow.Cells["BillDetailId"].Value);
                        _detailMap.intBillID = 0;
                        _detailMap.ProductID = Convert.ToString(oRow.Cells["ProductID"].Value);
                        _detailMap.strProductName = Convert.ToString(oRow.Cells["ProductName"].Value);
                        _detailMap.intQty = Convert.ToInt32(oRow.Cells["Qty"].Value);
                        _detailMap.price = Convert.ToDecimal(oRow.Cells["Price"].Value);
                      //  _detailMap.Tax = Convert.ToDecimal(oRow.Cells["Tax"].Value);
                        _detailMap.DiscountAmount = Convert.ToDecimal(oRow.Cells["discountnew"].Value);
                        _detailMap.DiscountPercent = Convert.ToDecimal(oRow.Cells["discountnewvalue"].Value);
                        _detailMap.StGST = Convert.ToDecimal(oRow.Cells["S_GST"].Value);
                        _detailMap.StGSTAmt = Convert.ToDecimal(oRow.Cells["SGSTAmt"].Value);
                        _detailMap.CtGST = Convert.ToDecimal(oRow.Cells["C_GST"].Value);
                        _detailMap.CtGSTAmt = Convert.ToDecimal(oRow.Cells["CGSTAmt"].Value);
                        _detailMap.Tax = Convert.ToDecimal(oRow.Cells["SGSTAmt"].Value) + Convert.ToDecimal(oRow.Cells["CGSTAmt"].Value);
                        _billMap.Tax +=(Convert.ToDecimal(oRow.Cells["SGSTAmt"].Value) + Convert.ToDecimal(oRow.Cells["CGSTAmt"].Value));
                        _detailMap.intNetAmount = Convert.ToDecimal(oRow.Cells["NetAmount"].Value);
                        if (_billMap._listBillDetail == null)
                            _billMap._listBillDetail = new List<BillDetailsMap>();
                        _billMap._listBillDetail.Add(_detailMap);
                        i++;
                    }
                }
                if (grdBillDetails.RowCount > 0)
                {
                    string ProductName = string.Empty;
                    foreach (DataGridViewRow oRow in grdBillDetails.Rows)
                    {
                        if (string.IsNullOrEmpty(oRow.Cells["ProductName"].Value.ToString())) break;
                        ProductName = string.Concat(ProductName, ",", Convert.ToString(oRow.Cells["ProductName"].Value));
                        _billMap.UDDiseases = ProductName.Remove(0, 1);

                    }
                }

                BillProcess.saveProcess(ref _billMap);

                if (!_billMap.isError)
                {
                    btnSave.Enabled = false;
                    MessageBox.Show(_billMap.strErrorMsg, "Message");
                    HospitalViewer hopsiView = new HospitalViewer(_billMap.intBillID, _billMap.intBillID);
                    //PatientReport patientReport = new PatientReport(_billMap.intBillID);
                    //patientReport.Show();
                    hopsiView.ShowDialog();
                    closeForms();
                    
                }
            }
        }
        private void btnCancelBill_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you confirm to Save?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BillProcess.cancelBillProcess(Convert.ToInt32(lblBillID.Text));
                MessageBox.Show("Cancelled Sucessfully!", "Message");
                closeForms();
            }
        }
        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            HospitalViewer hopsiView = new HospitalViewer(Convert.ToInt32(lblBillID.Text), Convert.ToInt32(lblClosedBillId.Text));
            closeForms();
            hopsiView.ShowDialog();
        }
        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            //PatientReport patientReport = new PatientReport(Convert.ToInt32(lblBillID.Text));
            //closeForms();
            //patientReport.ShowDialog();
        }
        private void grdBillDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                intRowNo = e.RowIndex;
                if (e.ColumnIndex == 2)
                {
                    if (!_billMap.isError)
                    {
                        UserDefinedOptionMap userDefOpt = new UserDefinedOptionMap();
                        LookupProduct _lokUpCat = new LookupProduct(ref userDefOpt);
                        DialogResult OBJ = _lokUpCat.ShowDialog();
                        _lokUpCat.Dispose();
                        if (userDefOpt.ProductID != null)
                        {
                            grdBillDetails.Rows[intRowNo].Cells["ProductID"].Value = userDefOpt.ProductID;
                            grdBillDetails.Rows[intRowNo].Cells["ProductName"].Value = userDefOpt.UDDescription;
                            grdBillDetails.Rows[intRowNo].Cells["Tax"].Value = userDefOpt.Tax;
                            grdBillDetails.Rows[intRowNo].Cells["discountnew"].Value = userDefOpt.discount;
                            grdBillDetails.Rows[intRowNo].Cells["discountnewvalue"].Value = userDefOpt.discountvalue;
                            grdBillDetails.Rows[intRowNo].Cells["S_GST"].Value = userDefOpt.StGST;
                            grdBillDetails.Rows[intRowNo].Cells["C_GST"].Value = userDefOpt.CtGST;
                            grdBillDetails.Rows[intRowNo].Cells["Price"].Value = userDefOpt.Price;
                            grdBillDetails.Rows[intRowNo].Cells["Qty"].Value = 1;
                            lblQty.Text = Convert.ToString(userDefOpt.Qty);
                            DataTable oTableReceipt = new DataTable();
                            getOptionsValueFromGrid(ref oTableReceipt);
                            createOptionNewRow(ref oTableReceipt);
                            BindingSource bSource = new BindingSource();
                            bSource.DataSource = oTableReceipt;
                            grdBillDetails.AutoGenerateColumns = false;
                            grdBillDetails.DataSource = bSource;
                            setOptionsValuetoGrid(ref oTableReceipt);
                            grdBillDetails.ClearSelection();
                            grdBillDetails.Rows[grdBillDetails.Rows.Count - 1].Cells[2].Selected = true;
                            //grdBillDetails.Rows[grdBillDetails.Rows.Count - 1].Selected = true;
                            txtTenderAmount.Text = "";
                            total = total + userDefOpt.Price;
                            lblAmount.Text = Convert.ToString(total);
                            

                            netTotal = netTotal + total;
                            netTotal = Math.Round(netTotal);
                            lblTotalAmount.Text = Convert.ToString(netTotal);
                            lblChangeAmount.Text = "0";
                            chBoxDiscount.Checked = false;
                            drpTenderType.SelectedIndex = 0;
                            BillDetailsMap _detailMap = new BillDetailsMap();
                            _detailMap.price = userDefOpt.Price;
                            //_detailMap.Tax = userDefOpt.Tax ;
                            _detailMap.Tax = userDefOpt.StGST + userDefOpt.CtGST;                           
                            _detailMap.StGST = userDefOpt.StGST;
                            _detailMap.CtGST = userDefOpt.CtGST;
                            //calGrid();
                            NetTotal();
                        }
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    NetTotal();
                }
            }
        }

        private void setOptionsInitialRow(ref DataTable odt)
        {           
            odt.Columns.Add(new DataColumn("BillDetailId", typeof(int)));
            odt.Columns.Add(new DataColumn("EmployeeID", typeof(string)));
            odt.Columns.Add(new DataColumn("ProductName", typeof(string)));
            odt.Columns.Add(new DataColumn("TestCount", typeof(int)));
            odt.Columns.Add(new DataColumn("Amount", typeof(decimal)));          
            odt.Columns.Add(new DataColumn("Tax", typeof(decimal)));
            odt.Columns.Add(new DataColumn("Discountnew", typeof(decimal)));
            odt.Columns.Add(new DataColumn("Discountnewvalue", typeof(decimal)));
            //  odt.Columns.Add(new DataColumn("SGST", typeof(int)));
            odt.Columns.Add(new DataColumn("SGST", typeof(decimal)));
            odt.Columns.Add(new DataColumn("SGSTAmt", typeof(decimal)));
            //odt.Columns.Add(new DataColumn("CGST", typeof(int)));
            odt.Columns.Add(new DataColumn("CGST", typeof(decimal)));
            odt.Columns.Add(new DataColumn("CGSTAmt", typeof(decimal)));
            odt.Columns.Add(new DataColumn("NetAmount", typeof(decimal)));
            odt.Columns.Add(new DataColumn("ProductID", typeof(string)));
            odt.Columns.Add(new DataColumn("SNo", typeof(int)));
        }
        private void createOptionNewRow(ref DataTable odt)
        {
           
            DataRow oDataRow = odt.NewRow();          
            oDataRow["BillDetailId"] = 0;
            oDataRow["EmployeeID"] = "Select Employee";
            oDataRow["ProductName"] = "";
            oDataRow["TestCount"] = 0;
            oDataRow["Amount"] = 0;
            oDataRow["Tax"] = 0;
            oDataRow["Discountnew"] = 0;
            oDataRow["Discountnewvalue"] = 0;
            oDataRow["SGST"] = 0;
            oDataRow["SGSTAmt"] = 0;
            oDataRow["CGST"] = 0;
            oDataRow["CGSTAmt"] = 0;
            oDataRow["NetAmount"] = 0;
            oDataRow["ProductID"] = "";
            oDataRow["SNo"] = 0;
            odt.Rows.Add(oDataRow);
            string message = string.Empty;
            string ProductID = string.Empty;
            foreach (DataGridViewRow row in grdBillDetails.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Chkbill"].Value);
                if (isSelected)
                {
                    ProductID = Convert.ToString(row.Cells["ProductID"].Value);
                    message += Environment.NewLine;
                    message += row.Cells["ProductID"].Value.ToString();
                }
            }
           

            //MessageBox.Show("Selected Values" + message);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grdBillDetails.Columns["Chkbill"].Index) //To check that we are in the right column
            {
                grdBillDetails.EndEdit();  //Stop editing of cell.
                if ((bool)grdBillDetails.Rows[e.RowIndex].Cells["Chkbill"].Value)
                {
                    //dataGridView1.Columns[3].ReadOnly = true;// for entire column 
                    int colIndex = e.ColumnIndex;
                    int rowIndex = e.RowIndex;
                    grdBillDetails.Rows[colIndex].Cells[rowIndex].ReadOnly = true;
                }
            }
        }

      


        private void getOptionsValueFromGrid(ref DataTable odt)
        {
            
            if (grdBillDetails.Rows.Count > 0)
            {
                setOptionsInitialRow(ref odt);
                foreach (DataGridViewRow oRow in grdBillDetails.Rows)
                {
                    DataRow oDataRow = odt.NewRow();
                    oDataRow["BillDetailId"] = oRow.Cells[0].Value != System.DBNull.Value ? oRow.Cells[0].Value : 0;
                    oDataRow["EmployeeID"] = oRow.Cells[1].Value != System.DBNull.Value ? oRow.Cells[1].Value : "";
                    oDataRow["ProductName"] = oRow.Cells[2].Value != System.DBNull.Value ? oRow.Cells[2].Value : "";
                    oDataRow["TestCount"] = oRow.Cells[3].Value != System.DBNull.Value ? oRow.Cells[3].Value : 0;
                    oDataRow["Amount"] = oRow.Cells[4].Value != System.DBNull.Value ? oRow.Cells[4].Value : 0;
                    oDataRow["Tax"] = oRow.Cells[5].Value != System.DBNull.Value ? oRow.Cells[5].Value : 0;
                    //oDataRow["Discountnew"] = oRow.Cells[6].Value != System.DBNull.Value ? oRow.Cells[6].Value : 0;
                    //oDataRow["Discountnewvalue"] = oRow.Cells[7].Value != System.DBNull.Value ? oRow.Cells[7].Value : 0;
                    oDataRow["Discountnew"] = oRow.Cells["Discountnew"].Value != System.DBNull.Value ? oRow.Cells["Discountnew"].Value : 0;
                    oDataRow["Discountnewvalue"] = oRow.Cells["Discountnewvalue"].Value != System.DBNull.Value ? oRow.Cells["Discountnewvalue"].Value : 0;
                    oDataRow["SGST"] = oRow.Cells["S_GST"].Value != System.DBNull.Value ? oRow.Cells["S_GST"].Value : 0;
                    oDataRow["CGST"] = oRow.Cells["C_GST"].Value != System.DBNull.Value ? oRow.Cells["C_GST"].Value : 0;
                    oDataRow["NetAmount"] = oRow.Cells[10].Value != System.DBNull.Value ? oRow.Cells["NetAmount"].Value : 0;
                    oDataRow["ProductID"] = oRow.Cells[13].Value != System.DBNull.Value ? oRow.Cells["ProductID"].Value : 0;                   
                    int Qty = 0;
                    decimal price = 0, discount = 0, tax = 0, discountPercent = 0, SGSTtax = 0, CGSTtax = 0, Taxamountresult=0; 
                    if (Convert.ToInt32(oDataRow["TestCount"]) > 0)
                        Qty = Convert.ToInt32(oDataRow["TestCount"]);
                    //if (Convert.ToDecimal(grdBillDetails.Rows[intRowNo].Cells["Price"].Value) > 0)
                    if (Convert.ToDecimal(oDataRow["Amount"]) > 0)
                        price = Convert.ToDecimal(oDataRow["Amount"]);
                    if (Convert.ToDecimal(oDataRow["SGST"]) > 0)                        
                        tax += SGSTtax = Convert.ToDecimal(oDataRow["SGST"]);
                    if (Convert.ToDecimal(oDataRow["CGST"]) > 0)                        
                        tax += CGSTtax = Convert.ToDecimal(oDataRow["CGST"]);
                    SGSTtax = ((Qty * price) * SGSTtax / 100);
                    CGSTtax = ((Qty * price) * CGSTtax / 100);
                   // Taxamountresult = SGSTtax + CGSTtax;                  
                    oDataRow["SGSTAmt"] = SGSTtax;
                    oDataRow["CGSTAmt"] = CGSTtax;
                    decimal decAmount = price;
                    if (discount != 0) decAmount = price - discount;
                    if (discountPercent != 0) decAmount = price - (price * discountPercent / 100);
                    decimal taxAmount = ((Qty * decAmount) * tax / 100);
                   // decimal tAmount = (Qty * decAmount) + taxAmount;
                    decimal tAmount = (Qty * decAmount) + taxAmount;
                    oDataRow["NetAmount"] = tAmount;

                    decimal Discountnewvalue = 0;
                    if (Convert.ToDecimal(oDataRow["Discountnew"]) > 0)
                        Discountnewvalue = Convert.ToDecimal(oDataRow["Discountnew"]);
                    if (Discountnewvalue > 0)
                    {
                        decimal CalAmount = Qty *  price;
                        Discountnewvalue = ((CalAmount) * Discountnewvalue / 100);

                        oDataRow["Discountnewvalue"] = Discountnewvalue;

                        if (Discountnewvalue != 0) Discountnewvalue = CalAmount - Discountnewvalue;
                        //  Discountnewvalue = ((Qty * price) * Discountnewvalue / 100);

                        SGSTtax = ((Discountnewvalue) * Convert.ToDecimal(oDataRow["CGST"]) / 100);//Kavin
                        CGSTtax = ((Discountnewvalue) * Convert.ToDecimal(oDataRow["CGST"]) / 100);//Kavin
                        /* Kavin
                        SGSTtax = ((Discountnewvalue) * SGSTtax / 100);
                        CGSTtax = ((Discountnewvalue) * CGSTtax / 100);
                        */

                        //SGSTtax = ((Qty * price) * Discountnewvalue / 100);
                        //CGSTtax = ((Qty * price) * Discountnewvalue / 100);
                        oDataRow["SGSTAmt"] = SGSTtax;
                        oDataRow["CGSTAmt"] = CGSTtax;

                        //      if (Discountnewvalue != 0) Discountnewvalue = price - (price * Discountnewvalue / 100);
                        decimal taxAmount1 = (( Discountnewvalue) * tax / 100);
                        decimal tAmount1 = ( Discountnewvalue) + taxAmount1;

                        oDataRow["NetAmount"] = tAmount1;
                    }                    

                    odt.Rows.Add(oDataRow);
                }
            }
        }
        private void setOptionsValuetoGrid(ref DataTable odt)
        {
            if (odt.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataGridViewRow oRow in grdBillDetails.Rows)
                {
                    if (i == odt.Rows.Count) break;
                    oRow.Cells[0].Value = odt.Rows[i]["BillDetailId"];
                    oRow.Cells[1].Value = odt.Rows[i]["EmployeeId"];
                    oRow.Cells[2].Value = odt.Rows[i]["ProductName"];
                    oRow.Cells[3].Value = odt.Rows[i]["TestCount"];
                    oRow.Cells[4].Value = odt.Rows[i]["Amount"];
                    oRow.Cells[5].Value = odt.Rows[i]["Tax"];
                    oRow.Cells[6].Value = odt.Rows[i]["Discountnew"];
                    oRow.Cells[7].Value = odt.Rows[i]["Discountnewvalue"];
                    oRow.Cells[8].Value = odt.Rows[i]["SGST"];
                    oRow.Cells[9].Value = odt.Rows[i]["SGSTAmt"];
                    oRow.Cells[10].Value = odt.Rows[i]["CGST"];
                    oRow.Cells[11].Value = odt.Rows[i]["CGSTAmt"];
                    oRow.Cells[12].Value = odt.Rows[i]["NetAmount"];
                    oRow.Cells[13].Value = odt.Rows[i]["ProductId"];
                    oRow.Cells[14].Value = i + 1;
                    i++;
                }
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            //DataTable oTableReceipt = new DataTable();
            //if (grdBillDetails.Rows.Count == 0)
            //{
            //    setOptionsInitialRow(ref oTableReceipt);
            //}
            //else
            //{
            //    getOptionsValueFromGrid(ref oTableReceipt);
            //}
            
            //createOptionNewRow(ref oTableReceipt);
            //BindingSource bSource = new BindingSource();
            //bSource.DataSource = oTableReceipt;
            //grdBillDetails.AutoGenerateColumns = false;
            //grdBillDetails.DataSource = bSource;
            //setOptionsValuetoGrid(ref oTableReceipt);
        }
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            //if (intRowNo > 0)
            //{
            //    grdBillDetails.Rows.RemoveAt(intRowNo);
            //    intRowNo = 0;
            //}
        }
        private void grdBillDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            intRowNo = e.RowIndex;
        }
        private void drpTenderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpTenderType.SelectedIndex == 0)
            {
                lblBankName.Hide();
                drpBankName.Hide();
                lblCardName.Hide();
                txtCardno.Hide();
                txtChequeNo.Hide();
                txtTenderAmount.Hide();
                lblTender.Hide();

                tenderAmount = 0;
                netTotal = Convert.ToDecimal(lblTotalAmount.Text);
                changeAmount = (netTotal - tenderAmount) - discountAmount + advance;
                changeAmount = Math.Round(changeAmount);
                lblChangeAmount.Text = Convert.ToString(changeAmount);
                lblTenderAmount.Text = Convert.ToString(tenderAmount);
            }
            else if (drpTenderType.SelectedIndex == 1)
            {
                lblBankName.Hide();
                drpBankName.Hide();
                lblCardName.Hide();
                txtCardno.Hide();
                txtChequeNo.Hide();
                txtTenderAmount.Show();
                lblTender.Show();

             //   tenderAmount = Convert.ToDecimal(txtTenderAmount.Text);
                netTotal = Convert.ToDecimal(lblTotalAmount.Text);
                changeAmount = (netTotal - tenderAmount) - discountAmount + advance;
                changeAmount = Math.Round(changeAmount);
                lblChangeAmount.Text = Convert.ToString(changeAmount);
                lblTenderAmount.Text = Convert.ToString(tenderAmount);
            }
            else if (drpTenderType.SelectedIndex == 2)
            {
                lblBankName.Show();
                drpBankName.Show();
                lblCardName.Show();

                txtTenderAmount.Hide();
                lblTender.Hide();
                lblCardName.Text = "Cheque No";
                txtCardno.Hide();
                txtChequeNo.Show();
                tenderAmount = Convert.ToDecimal(txtTenderAmount.Text);
                netTotal = Convert.ToDecimal(lblTotalAmount.Text);
                changeAmount = (netTotal - tenderAmount) - discountAmount + advance;
                changeAmount = Math.Round(changeAmount);
                lblChangeAmount.Text = Convert.ToString(changeAmount);
                lblTenderAmount.Text = Convert.ToString(tenderAmount);
            }
            else
            {
                lblBankName.Show();
                drpBankName.Show();
                lblCardName.Show();

                txtTenderAmount.Hide();
                lblTender.Hide();
                lblCardName.Text = "Card No";
                txtCardno.Show();
                txtChequeNo.Hide();
                tenderAmount = Convert.ToDecimal(txtTenderAmount.Text);
                netTotal = Convert.ToDecimal(lblTotalAmount.Text);
                changeAmount = (netTotal - tenderAmount) - discountAmount + advance;
                changeAmount = Math.Round(changeAmount);
                lblChangeAmount.Text = Convert.ToString(changeAmount);
                lblTenderAmount.Text = Convert.ToString(tenderAmount);
            }
          //  txtTenderAmount.Text = "";
        }
        private void txtDiscountamount_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDiscountamount.Text))
            {
                txtDiscountamount.Text = "";
                txtTenderAmount.Text = "";
                discountAmount = 0;
                tenderAmount = 0;
                lblDiscount.Text = "0";
                changeAmount = netTotal + discountAmount;
                lblChangeAmount.Text = Convert.ToString(changeAmount);
                lblTotalpay.Text = Convert.ToString(changeAmount);
               
            }

            if (txtDiscountamount.Text != string.Empty)
            {
                DiscountPercent();
            }
        }
        private void DiscountPercent()
        {
            netTotal = Convert.ToDecimal(lblTotalAmount.Text);
            if (!string.IsNullOrEmpty(txtDiscountamount.Text.Trim())) discountPercent = Convert.ToDecimal(txtDiscountamount.Text);
            else discountPercent = 0;
            discountAmount = Math.Round(netTotal * discountPercent / 100);
            changeAmount = netTotal - discountAmount + advance;
            changeAmount = Math.Round(changeAmount);
            lblDiscount.Text = Convert.ToString(discountAmount);
            lblChangeAmount.Text = Convert.ToString(changeAmount);
            lblTotalpay.Text = Convert.ToString(changeAmount);
            txtTenderAmount.Text =netTotal.ToString();
            drpTenderType.SelectedIndex = 0;
        }
        private void txtTenderAmount_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTenderAmount.Text))
            {
                txtTenderAmount.Text = "";
                tenderAmount = 0;
                lblTenderAmount.Text = "0";
                //changeAmount = netTotal - discountAmount;
                //lblChangeAmount.Text = Convert.ToString(changeAmount);
                //lblTotalpay.Text = Convert.ToString(changeAmount);
                lblChangeAmount.Text = Convert.ToString(lblTotalpay.Text);
            }
            
            if (txtTenderAmount.Text != string.Empty)
            {
                tenderAmount = Convert.ToDecimal(txtTenderAmount.Text);
                netTotal = Convert.ToDecimal(lblTotalAmount.Text);
                changeAmount = (netTotal - tenderAmount) - discountAmount + advance;
                changeAmount = Math.Round(changeAmount);
                lblChangeAmount.Text = Convert.ToString(changeAmount);
                //lblTotalpay.Text = Convert.ToString(changeAmount);
                lblTenderAmount.Text = Convert.ToString(tenderAmount);
                //DiscountPercent();
            }
        }
        private void chBoxDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxDiscount.Checked)
            {
               // gBoxGift.Enabled = true;
                lblDiscount.Text = "0";
            }
            else
            {
              //  gBoxGift.Enabled = false;
                txtDiscountamount.Text = string.Empty;
                txtDiscountName.Text = string.Empty;
                drpTenderType.SelectedIndex = 0;
                if (txtTenderAmount.Text != string.Empty)
                {
                    changeAmount = (netTotal - tenderAmount) + discountAmount;
                    lblChangeAmount.Text = Convert.ToString(changeAmount);
                    lblDiscount.Text = "0";
                }
            }
        }
        private void txtDiscountName_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountName.Text == string.Empty) txtDiscountamount.Enabled = false;
            else txtDiscountamount.Enabled = true;
        }
        private void txtTenderAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }
        private void txtDiscountamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }
        private void txtCardno_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCardno.Text))
            {
                txtTenderAmount.Hide();
                lblTender.Hide();
            }
            else if (!String.IsNullOrEmpty(txtCardno.Text))
            {
                txtTenderAmount.Show();
                lblTender.Show();
            }
        }
        private void txtChequeNo_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtChequeNo.Text))
            {
                txtTenderAmount.Hide();
                lblTender.Hide();
            }
            else if (!String.IsNullOrEmpty(txtChequeNo.Text))
            {
                txtTenderAmount.Show();
                lblTender.Show();
            }
        }

        private void txtTenderAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave_Click(sender, new EventArgs());
        }

        private void grdBillDetails_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 6)
                {
                    decimal Discountnewvalue;
                    Discountnewvalue = Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["Discountnew"].Value);

                    if (Discountnewvalue > 0)
                    {
                        btnSave.Enabled = true;
                        int Qty = 0;
                        decimal price = 0, tax = 0, SGSTtax = 0, CGSTtax = 0;
                        //discount = 0, discountPercent = 0,
                        if (Convert.ToInt32(grdBillDetails.Rows[e.RowIndex].Cells["Qty"].Value) > 0)
                            Qty = Convert.ToInt32(grdBillDetails.Rows[e.RowIndex].Cells["Qty"].Value);
                        if (Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["Price"].Value) > 0)
                            price = Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["Price"].Value);
                        if (Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["Discountnew"].Value) > 0)
                            Discountnewvalue = Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["Discountnew"].Value);

                        if (Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["S_GST"].Value) > 0)
                            tax += SGSTtax = Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["S_GST"].Value);
                        if (Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["C_GST"].Value) > 0)
                            tax += CGSTtax = Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["C_GST"].Value);
                        decimal CalAmount = Qty * price;
                    //    Discountnewvalue = ((Qty * price) * Discountnewvalue / 100);
                        Discountnewvalue = ((CalAmount) * Discountnewvalue / 100);

                        decimal caldiscountqty = CalAmount - Discountnewvalue;
                        grdBillDetails.Rows[e.RowIndex].Cells["Discountnewvalue"].Value = Discountnewvalue;
                        grdBillDetails.Rows[e.RowIndex].Cells["Discountnewvalue"].ReadOnly = true;
                        if (Discountnewvalue != 0) Discountnewvalue = CalAmount - Discountnewvalue;
                        //  Discountnewvalue = ((Qty * price) * Discountnewvalue / 100);
                        SGSTtax = ((caldiscountqty) * SGSTtax / 100);
                        CGSTtax = ((caldiscountqty) * CGSTtax / 100);
                        grdBillDetails.Rows[e.RowIndex].Cells["SGSTAmt"].Value = SGSTtax;
                        grdBillDetails.Rows[e.RowIndex].Cells["CGSTAmt"].Value = CGSTtax;

                        //      if (Discountnewvalue != 0) Discountnewvalue = price - (price * Discountnewvalue / 100);
                        decimal taxAmount = ((caldiscountqty) * tax / 100);
                        decimal tAmount = (caldiscountqty) + taxAmount;
                        grdBillDetails.Rows[e.RowIndex].Cells["NetAmount"].Value = tAmount;
                        NetTotalnew();
                        


                    }
                    else
                    {
                        grdBillDetails.Rows[e.RowIndex].Cells["Discountnewvalue"].Value = Discountnewvalue;
                        int Qty = 0;
                        decimal price = 0, tax = 0, SGSTtax = 0, CGSTtax = 0;
                        decimal discount = 0;
                        if (Convert.ToInt64(grdBillDetails.Rows[e.RowIndex].Cells["Qty"].Value) > 0)
                            Qty = Convert.ToInt32(grdBillDetails.Rows[e.RowIndex].Cells["Qty"].Value);
                        if (Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["Price"].Value) > 0)
                            price = Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["Price"].Value);
                        if (Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["S_GST"].Value) > 0)
                            tax += SGSTtax = Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["S_GST"].Value);
                        if (Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["C_GST"].Value) > 0)
                            tax += CGSTtax = Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["C_GST"].Value);

                        SGSTtax = ((Qty * price) * SGSTtax / 100);
                        CGSTtax = ((Qty * price) * CGSTtax / 100);
                        grdBillDetails.Rows[e.RowIndex].Cells["SGSTAmt"].Value = SGSTtax;
                        grdBillDetails.Rows[e.RowIndex].Cells["CGSTAmt"].Value = CGSTtax;

                        decimal decAmount = price;
                        if (discount != 0) decAmount = price - discount;
                        if (discountPercent != 0) decAmount = price - (price * discountPercent / 100);
                        decimal taxAmount = ((Qty * decAmount) * tax / 100);
                        decimal tAmount = (Qty * decAmount) + taxAmount;
                        grdBillDetails.Rows[e.RowIndex].Cells["NetAmount"].Value = tAmount;
                        NetTotal();

                        
                    }

                    //if (Convert.ToInt32(lblQty.Text.Trim()) >= Convert.ToInt32(grdBillDetails.Rows[e.RowIndex].Cells["Qty"].Value))
                    //{
                    //    btnSave.Enabled = true;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("This product have only '" + lblQty.Text + "' items in the Stock", "Message");
                    //    grdBillDetails.Rows[e.RowIndex].Cells["Qty"].Value = 1;
                    //    btnSave.Enabled = false;
                    //}

                    //int Qty = 0;
                    //decimal price = 0, discount = 0, tax = 0, discountPercent = 0, SGSTtax = 0, CGSTtax = 0;
                    //if (Convert.ToInt32(grdBillDetails.Rows[e.RowIndex].Cells["Qty"].Value) > 0)
                    //    Qty = Convert.ToInt32(grdBillDetails.Rows[e.RowIndex].Cells["Qty"].Value);
                    //if (Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["Price"].Value) > 0)
                    //    price = Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["Price"].Value);
                    //if (Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["S_GST"].Value) > 0)
                    //    tax += SGSTtax = Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["S_GST"].Value);
                    //if (Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["C_GST"].Value) > 0)
                    //    tax += CGSTtax = Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["C_GST"].Value);

                    //SGSTtax = ((Qty * price) * SGSTtax / 100);
                    //CGSTtax = ((Qty * price) * CGSTtax / 100);
                    //grdBillDetails.Rows[e.RowIndex].Cells["SGSTAmt"].Value = SGSTtax;
                    //grdBillDetails.Rows[e.RowIndex].Cells["CGSTAmt"].Value = CGSTtax;

                    //decimal decAmount = price;
                    //if (discount != 0) decAmount = price - discount;
                    //if (discountPercent != 0) decAmount = price - (price * discountPercent / 100);
                    //decimal taxAmount = ((Qty * decAmount) * tax / 100);
                    //decimal tAmount = (Qty * decAmount) + taxAmount;
                    //grdBillDetails.Rows[e.RowIndex].Cells["NetAmount"].Value = tAmount;

                    //NetTotal();
                }

            }
        }
        //private void calGrid()
        //{
        //    int Qty = 0;
        //    decimal price = 0, discount = 0, tax = 0, discountPercent = 0,SGSTtax =0, CGSTtax = 0;
        //    if (Convert.ToInt32(grdBillDetails.Rows[intRowNo].Cells["Qty"].Value) > 0)
        //        Qty = Convert.ToInt32(grdBillDetails.Rows[intRowNo].Cells["Qty"].Value);
        //    if (Convert.ToDecimal(grdBillDetails.Rows[intRowNo].Cells["Price"].Value) > 0)
        //        price = Convert.ToDecimal(grdBillDetails.Rows[intRowNo].Cells["Price"].Value);
        //    //if (Convert.ToInt32(grdBillDetails.Rows[e.RowIndex].Cells["Discount"].Value) > 0)
        //    //    discount = Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["Discount"].Value);
        //    //if (Convert.ToDecimal(grdBillDetails.Rows[intRowNo].Cells["Tax"].Value) > 0)
        //    //    tax = Convert.ToDecimal(grdBillDetails.Rows[intRowNo].Cells["Tax"].Value);
        //    //if (Convert.ToInt32(grdBillDetails.Rows[e.RowIndex].Cells["DiscountPercent"].Value) > 0)
        //    //    discountPercent = Convert.ToDecimal(grdBillDetails.Rows[e.RowIndex].Cells["DiscountPercent"].Value);
        //    if (Convert.ToDecimal(grdBillDetails.Rows[intRowNo].Cells["S_GST"].Value) > 0)
        //        tax += SGSTtax = Convert.ToDecimal(grdBillDetails.Rows[intRowNo].Cells["S_GST"].Value);
        //    if (Convert.ToDecimal(grdBillDetails.Rows[intRowNo].Cells["C_GST"].Value) > 0)
        //        tax += CGSTtax = Convert.ToDecimal(grdBillDetails.Rows[intRowNo].Cells["C_GST"].Value);

        //    SGSTtax = ((Qty * price) * SGSTtax / 100);
        //    CGSTtax = ((Qty * price) * CGSTtax / 100);
        //    grdBillDetails.Rows[intRowNo].Cells["SGSTAmt"].Value = SGSTtax;
        //    grdBillDetails.Rows[intRowNo].Cells["CGSTAmt"].Value = CGSTtax;

        //    decimal decAmount = price;
        //    if (discount != 0) decAmount = price - discount;
        //    if (discountPercent != 0) decAmount = price - (price * discountPercent / 100);
        //    decimal taxAmount = ((Qty * decAmount) * tax / 100);
        //    decimal tAmount = (Qty * decAmount) + taxAmount;
        //    grdBillDetails.Rows[intRowNo].Cells["NetAmount"].Value = tAmount;
        //}
        public void NetTotal()
            {
            int i = 0;
            int Qty = 0;
            decimal NetAmount = 0;
            foreach (DataGridViewRow oRow in grdBillDetails.Rows)
            {
                NetAmount = NetAmount + Convert.ToDecimal(oRow.Cells["NetAmount"].Value);
                Qty = Qty + Convert.ToInt32(oRow.Cells["Qty"].Value);
                i++;
            }
            lblQuantity.Text = Convert.ToString(Qty);
            lblTotalAmount.Text = Convert.ToString(Math.Round(NetAmount));
            lblTotalpay.Text = Convert.ToString(Math.Round(NetAmount + advance));
            txtTenderAmount.Text = lblTotalpay.Text;
            DiscountPercent();
        }
        public void NetTotalnew()
        {
            int i = 0;
            int Qty = 0;
            decimal NetAmount = 0;
            foreach (DataGridViewRow oRow in grdBillDetails.Rows)
            {
                NetAmount = NetAmount + Convert.ToDecimal(oRow.Cells["NetAmount"].Value);
                Qty = Qty + Convert.ToInt32(oRow.Cells["Qty"].Value);
                i++;
            }
            lblQuantity.Text = Convert.ToString(Qty);
            lblTotalAmount.Text = Convert.ToString(Math.Round(NetAmount));
            lblTotalpay.Text = Convert.ToString(Math.Round(NetAmount + advance));
            DiscountPercent();
        }

        private void grdpreviewData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BillInformation _billObj = new BillInformation();
            _billObj.Controls["gBoxBillInfo"].Controls["lblBillID"].Text = Convert.ToString(grdpreviewData.Rows[e.RowIndex].Cells["BillID"].Value);
            //_billObj.Controls["lblMembershipID"].Text = "0";
            _billObj.formIndex = Application.OpenForms.Count;
            //_billObj.hide = 5;
            _billObj.Show();
        }

        private void lblBalance_Click(object sender, EventArgs e)
        {

        }

        private void btnCompleteBill_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you confirm to Save?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BillMap _tmpBillMap = SaveBillInformation();
                BillProcess.completeBillProcess(Convert.ToInt32(lblBillID.Text));
                MessageBox.Show("Completed Sucessfully!", "Message");
                closeForms();
            }
        }

        private BillMap SaveBillInformation()
        {
           
                _billMap = new BillMap();
                _billMap.intBillID = Convert.ToInt32(lblBillID.Text);
                _billMap.dtBillDate = System.DateTime.Now;
                _billMap.strPatientID = lblCustomerID.Text;
                //_billMap.intStatus = Common.getUDID("Bill Status", "Closed");
                _billMap.intStatus = Common.getUDID("Bill Status", "In Progress");
                _billMap.intTypeOfPayment = Convert.ToInt32(drpTenderType.SelectedValue);
                if (drpTenderType.SelectedIndex == 1)
                {
                    _billMap.TenderAmount = Convert.ToDecimal(txtTenderAmount.Text);
                    _billMap.strCardNo = string.Empty;
                    _billMap.strChequeNo = string.Empty;
                    _billMap.intBankname = 0;
                }
                else if (drpTenderType.SelectedIndex == 2)
                {
                    _billMap.strCardNo = string.Empty;
                    _billMap.strChequeNo = txtChequeNo.Text;
                    _billMap.intBankname = Convert.ToInt32(drpBankName.SelectedValue);
                }
                else
                {
                    _billMap.strCardNo = txtCardno.Text;
                    _billMap.strChequeNo = string.Empty;
                    _billMap.intBankname = Convert.ToInt32(drpBankName.SelectedValue);
                }
                _billMap.TenderAmount = Convert.ToDecimal(txtTenderAmount.Text);

                if (chBoxDiscount.Checked)
                {
                    _billMap.strDiscountName = txtDiscountName.Text;
                    //_billMap.DiscountAmount = Convert.ToDecimal(txtDiscountamount.Text);
                    _billMap.DiscountPercent = Convert.ToDecimal(txtDiscountamount.Text);
                    _billMap.DiscountAmount = Convert.ToDecimal(lblDiscount.Text);
                }
                else
                {
                    //kalai change discount grid process 16072017

                    //_billmap.strdiscountname = string.empty;
                    //_billmap.discountamount = 0;
                    //_billmap.discountpercent = 0;

                    //kalai change discount grid process 16072017
                }
                _billMap.Amount = Convert.ToDecimal(lblAmount.Text);
                _billMap.Tax = Convert.ToDecimal(lblQuantity.Text);
                _billMap.Change = Convert.ToDecimal(lblChangeAmount.Text);
                _billMap.NetAmount = Convert.ToDecimal(lblTotalAmount.Text);
                _billMap.AmountPaid = (_billMap.NetAmount - _billMap.DiscountAmount);
                if (chBoxAddAmount.Checked) _billMap.AddToAdvance = 0;
                else _billMap.AddToAdvance = 1;

                if (grdBillDetails.RowCount > 0)
                {
                    int i = 0;
                    foreach (DataGridViewRow oRow in grdBillDetails.Rows)
                    {
                        if (string.IsNullOrEmpty(oRow.Cells["ProductName"].Value.ToString().Trim())) break;
                        BillDetailsMap _detailMap = new BillDetailsMap();
                        _detailMap.intBillDetailID = Convert.ToInt32(oRow.Cells["BillDetailId"].Value);
                        _detailMap.intBillID = 0;
                        _detailMap.ProductID = Convert.ToString(oRow.Cells["ProductID"].Value);
                        _detailMap.strProductName = Convert.ToString(oRow.Cells["ProductName"].Value);
                        _detailMap.intQty = Convert.ToInt32(oRow.Cells["Qty"].Value);
                        _detailMap.price = Convert.ToDecimal(oRow.Cells["Price"].Value);
                        _detailMap.Tax = Convert.ToDecimal(oRow.Cells["Tax"].Value);
                        _detailMap.DiscountAmount = Convert.ToDecimal(oRow.Cells["discountnew"].Value);
                        _detailMap.DiscountPercent = Convert.ToDecimal(oRow.Cells["discountnewvalue"].Value);
                        _detailMap.StGST = Convert.ToDecimal(oRow.Cells["S_GST"].Value);
                        _detailMap.StGSTAmt = Convert.ToDecimal(oRow.Cells["SGSTAmt"].Value);
                        _detailMap.CtGST = Convert.ToDecimal(oRow.Cells["C_GST"].Value);
                        _detailMap.CtGSTAmt = Convert.ToDecimal(oRow.Cells["CGSTAmt"].Value);
                        _detailMap.intNetAmount = Convert.ToDecimal(oRow.Cells["NetAmount"].Value);
                        if (_billMap._listBillDetail == null)
                            _billMap._listBillDetail = new List<BillDetailsMap>();
                        _billMap._listBillDetail.Add(_detailMap);
                        i++;
                    }
                }
                if (grdBillDetails.RowCount > 0)
                {
                    string ProductName = string.Empty;
                    foreach (DataGridViewRow oRow in grdBillDetails.Rows)
                    {
                        if (string.IsNullOrEmpty(oRow.Cells["ProductName"].Value.ToString())) break;
                        ProductName = string.Concat(ProductName, ",", Convert.ToString(oRow.Cells["ProductName"].Value));
                        _billMap.UDDiseases = ProductName.Remove(0, 1);
                    }
                }

                BillProcess.saveProcess(ref _billMap);
                return _billMap;               
        }

        private void grdBillDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
