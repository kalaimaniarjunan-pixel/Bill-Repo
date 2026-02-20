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
    public partial class ChangePassword : Form
    {
        LoginMap _loginMap = new LoginMap();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            bttnChange.Enabled = false;
            txtNewPass.ReadOnly = true;
            txtConformPass.ReadOnly = true;
            Common.BindDropDownFromEmployeeForLogin(comboBoxUser, true);
        }

        private void txtConformPass_Leave(object sender, EventArgs e)
        {
            string NewPass = txtNewPass.Text.Trim();
            string ConPass = txtConformPass.Text.Trim();

            if (NewPass != ConPass)
            {
                bttnChange.Enabled = false;
                MessageBox.Show("Password Mismatch.....", "Message");
                //errProConPass.SetError(txtConformPass, "Password Mismatch");
            }
            else
            {
                bttnChange.Enabled = true;
                //errProConPass.SetError(txtConformPass, "");
            }
        }

        private void bttnChange_Click(object sender, EventArgs e)
        {
            if (validateControl())
            {
                _loginMap.strUserId = comboBoxUser.SelectedValue.ToString();
                _loginMap.strPassword = txtConformPass.Text.Trim();
                LoginProcess.UpdatePassword(_loginMap);
                if (!_loginMap.isError)
                {
                    MessageBox.Show(_loginMap.strErrorMsg, "Message");
                    this.Dispose();
                }
                else
                {
                    throw new Exception(_loginMap.strErrorMsg);
                }
            }
        }
        private bool validateControl()
        {
            if (txtNewPass.Text.Trim() != txtConformPass.Text.Trim())
            {
                MessageBox.Show("Password Mismatch.....", "Message");
                bttnChange.Enabled = false;
                txtConformPass.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNewPass.Text.Trim()))
            {
                MessageBox.Show("Please Enter New Password.....", "Message");
                bttnChange.Enabled = false;
                txtNewPass.Focus();
                return false;
            }
            return true;
        }
        private void stripCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOldPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnCheck_Click(sender, new EventArgs());
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (comboBoxUser.SelectedValue.ToString() != "0")
            {
                _loginMap.strUserId = comboBoxUser.SelectedValue.ToString();
                _loginMap.strPassword = txtOldPass.Text;
                int count = LoginProcess.CheckPassWord(_loginMap);
                if (count == 1)
                {
                    txtOldPass.Focus();
                    txtOldPass.Text = "";
                    bttnChange.Enabled = false;
                    txtNewPass.ReadOnly = true;
                    txtConformPass.ReadOnly = true;
                    MessageBox.Show("Wrong Password", "Message", MessageBoxButtons.OK);
                }
                else
                {
                    btnCheck.Enabled = false;
                    txtOldPass.Enabled = false;
                    bttnChange.Enabled = true;
                    txtNewPass.ReadOnly = false;
                    txtConformPass.ReadOnly = false;
                }
            }
            else
            {
                MessageBox.Show("Please Select the UserName", "Message", MessageBoxButtons.OK);
            }
        }

        private void comboBoxUser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtOldPass.Text = "";
            btnCheck.Enabled = true;
            txtOldPass.Enabled = true;
            bttnChange.Enabled = false;
            txtNewPass.ReadOnly = true;
            txtConformPass.ReadOnly = true;
            txtNewPass.Text = string.Empty;
            txtConformPass.Text = string.Empty;
        }

        private void txtConformPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bttnChange_Click(sender, new EventArgs());
        }
    }
}
