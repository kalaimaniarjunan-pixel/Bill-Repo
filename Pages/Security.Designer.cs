namespace HospitalManagement.Pages
{
    partial class Security
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.txtSecurityPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(57, 44);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(77, 27);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtSecurityPassword
            // 
            this.txtSecurityPassword.HideSelection = false;
            this.txtSecurityPassword.Location = new System.Drawing.Point(12, 13);
            this.txtSecurityPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSecurityPassword.MaxLength = 20;
            this.txtSecurityPassword.Multiline = true;
            this.txtSecurityPassword.Name = "txtSecurityPassword";
            this.txtSecurityPassword.PasswordChar = '*';
            this.txtSecurityPassword.Size = new System.Drawing.Size(176, 22);
            this.txtSecurityPassword.TabIndex = 2;
            this.txtSecurityPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSecurityPassword_KeyDown);
            // 
            // Security
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(200, 84);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtSecurityPassword);
            this.Name = "Security";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Security_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtSecurityPassword;
    }
}