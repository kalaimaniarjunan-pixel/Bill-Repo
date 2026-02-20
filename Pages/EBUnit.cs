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
    public partial class EBUnit : Form
    {
        public EBUnit()
        {
            InitializeComponent();
        }

        private void EBUnit_Load(object sender, EventArgs e)
        {
            lblEBUnit.Hide();
            if (!String.IsNullOrEmpty(lblEBUnit.Text))
            {
                loadEBUnit(Convert.ToInt32(lblEBUnit.Text));
                btnSave.Enabled = false;
            }
            else
            {
                lblEBUnit.Text = "0";
            }
        }
        private void loadEBUnit(int EBUnitID)
        {
            DataSet oDataset = EBUnitProcess.selectProcess(EBUnitID);
            if (oDataset != null)
            {
                if (oDataset.Tables[0].Rows.Count > 0)
                {
                    DataRow oRow = oDataset.Tables[0].Rows[0];
                    EBUnitDate.Text = Convert.ToString(oRow["MeterDate"]);
                    txtOpeningValue.Text = Convert.ToString(oRow["StartMeterValue"]);
                    txtClosingValue.Text = Convert.ToString(oRow["EndMeterValue"]);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOpeningValue.Text) && !string.IsNullOrEmpty(txtClosingValue.Text))
            {
                int open = Convert.ToInt32(txtOpeningValue.Text);
                int close = Convert.ToInt32(txtClosingValue.Text);
                if (open <= close)
                {
                    EBUnitMap _ebUnitMap = new EBUnitMap();

                    _ebUnitMap.EBUnitID = Convert.ToInt32(lblEBUnit.Text);
                    _ebUnitMap.EBUnitDate = Common.GetDateTime(EBUnitDate.Text);
                    _ebUnitMap.StartMeterValue = Convert.ToInt32(txtOpeningValue.Text);
                    if (!String.IsNullOrEmpty(txtClosingValue.Text))
                        _ebUnitMap.EndMeterValue = Convert.ToInt32(txtClosingValue.Text);
                    EBUnitProcess.saveProcess(ref _ebUnitMap);
                    if (!_ebUnitMap.isError)
                    {
                        lblEBUnit.Text = Convert.ToString(_ebUnitMap.EBUnitID);
                        MessageBox.Show(_ebUnitMap.strErrorMsg, "Message");
                        closeForms();
                    }
                    else
                    {
                        MessageBox.Show(_ebUnitMap.strErrorMsg, "Message");
                    }
                }
                else
                {
                    MessageBox.Show("The Statring Meter is Greater", "Message");
                }
            }
            else
            {
                MessageBox.Show("Please Enter the values", "Message");
            }
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

        private void txtOpeningValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void txtClosingValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && (e.KeyChar != (char)46) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void EBUnit_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForms();
        }
    }
}
