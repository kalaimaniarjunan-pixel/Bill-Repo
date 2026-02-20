using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalManagement.Pages
{
    public partial class Security : Form
    {
        public Security()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (isVaildUser())
            {
                CreateLicense _createLicense = new CreateLicense();
                this.Hide();
                _createLicense.ShowDialog();
            }
        }
        private bool isVaildUser()
        {
            if (String.IsNullOrEmpty(txtSecurityPassword.Text.Trim()))
            {
                MessageBox.Show("Please Enter the password!", "Message");
                txtSecurityPassword.Focus();
            }
            else
            {
                if (txtSecurityPassword.Text.Trim() == "Ap@l1s")
                {
                    return true;
                }
                else MessageBox.Show("Please type vaild password!", "Message");
            }
            return false;
        }

        private void Security_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void txtSecurityPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk_Click(sender, new EventArgs());
        }
    }
}
