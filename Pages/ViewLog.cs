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
    public partial class ViewLog : Form
    {
        public ViewLog()
        {
            InitializeComponent();
        }

        private void ViewLog_Load(object sender, EventArgs e)
        {
            DataBind(Common.getLoginDetails().Tables[0]);
        }
        public void DataBind(DataTable oTable)
        {
            grdLoadViewLog.DataSource = null;
            BindingSource bSource = new BindingSource();
            bSource.DataSource = oTable;
            grdLoadViewLog.AutoGenerateColumns = true;
            grdLoadViewLog.DataSource = bSource;
            if (grdLoadViewLog.RowCount > 0 && oTable.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataGridViewRow oRow in grdLoadViewLog.Rows)
                {
                    if (i == oTable.Rows.Count) break;
                    int j = 0;
                    foreach (DataColumn oCell in oTable.Columns)
                    {
                        oRow.Cells[j].Value = oTable.Rows[i][j];
                        oRow.Cells[j].ReadOnly = true;
                        j++;
                    }
                    i++;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = this.dtpViewLog.Value;
            if (selectedDate != null)
            {
                DataBind(Common.getLoginDetails(this.dtpViewLog.Value).Tables[0]);
            }
        }
    }
}
