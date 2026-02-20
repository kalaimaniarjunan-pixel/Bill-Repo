namespace HospitalManagement.Pages
{
    partial class Attendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendance));
            this.lblEmpID = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblLeaveType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblHeader = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gBoxAttendance = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.rbPresent = new System.Windows.Forms.RadioButton();
            this.cBShift = new System.Windows.Forms.ComboBox();
            this.cBoxEmpId = new System.Windows.Forms.ComboBox();
            this.rbLeave = new System.Windows.Forms.RadioButton();
            this.cBLeaveType = new System.Windows.Forms.ComboBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.chBoxHalfDay = new System.Windows.Forms.CheckBox();
            this.gBLeaveType = new System.Windows.Forms.GroupBox();
            this.txtAttendaceId = new System.Windows.Forms.TextBox();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gBoxAttendance.SuspendLayout();
            this.gBLeaveType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmpID
            // 
            this.lblEmpID.AutoSize = true;
            this.lblEmpID.Location = new System.Drawing.Point(27, 32);
            this.lblEmpID.Name = "lblEmpID";
            this.lblEmpID.Size = new System.Drawing.Size(73, 15);
            this.lblEmpID.TabIndex = 0;
            this.lblEmpID.Text = "Employee ID";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(62, 64);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(31, 15);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date";
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Location = new System.Drawing.Point(62, 106);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(31, 15);
            this.lblShift.TabIndex = 2;
            this.lblShift.Text = "Shift";
            // 
            // lblLeaveType
            // 
            this.lblLeaveType.AutoSize = true;
            this.lblLeaveType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaveType.Location = new System.Drawing.Point(62, 29);
            this.lblLeaveType.Name = "lblLeaveType";
            this.lblLeaveType.Size = new System.Drawing.Size(66, 15);
            this.lblLeaveType.TabIndex = 3;
            this.lblLeaveType.Text = "Leave Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Reason";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(201)))), ((int)(((byte)(62)))));
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.btnCancel,
            this.toolStripSeparator4,
            this.btnSave,
            this.toolStripSeparator5});
            this.toolStrip2.Location = new System.Drawing.Point(0, 385);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(403, 29);
            this.toolStrip2.TabIndex = 18;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(49, 23);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // btnSave
            // 
            this.btnSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 23);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(201)))), ((int)(((byte)(62)))));
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.lblHeader,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(403, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Margin = new System.Windows.Forms.Padding(3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(118, 19);
            this.lblHeader.Text = "Attendance Details";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // gBoxAttendance
            // 
            this.gBoxAttendance.Controls.Add(this.dtpDate);
            this.gBoxAttendance.Controls.Add(this.rbPresent);
            this.gBoxAttendance.Controls.Add(this.cBShift);
            this.gBoxAttendance.Controls.Add(this.cBoxEmpId);
            this.gBoxAttendance.Controls.Add(this.rbLeave);
            this.gBoxAttendance.Controls.Add(this.lblEmpID);
            this.gBoxAttendance.Controls.Add(this.lblDate);
            this.gBoxAttendance.Controls.Add(this.lblShift);
            this.gBoxAttendance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxAttendance.Location = new System.Drawing.Point(15, 32);
            this.gBoxAttendance.Name = "gBoxAttendance";
            this.gBoxAttendance.Size = new System.Drawing.Size(355, 176);
            this.gBoxAttendance.TabIndex = 20;
            this.gBoxAttendance.TabStop = false;
            this.gBoxAttendance.Text = "Attendance";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(154, 66);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(84, 23);
            this.dtpDate.TabIndex = 5;
            // 
            // rbPresent
            // 
            this.rbPresent.AutoSize = true;
            this.rbPresent.Location = new System.Drawing.Point(154, 141);
            this.rbPresent.Name = "rbPresent";
            this.rbPresent.Size = new System.Drawing.Size(64, 19);
            this.rbPresent.TabIndex = 4;
            this.rbPresent.TabStop = true;
            this.rbPresent.Text = "Present";
            this.rbPresent.UseVisualStyleBackColor = true;
            this.rbPresent.CheckedChanged += new System.EventHandler(this.rbPresent_CheckedChanged);
            // 
            // cBShift
            // 
            this.cBShift.FormattingEnabled = true;
            this.cBShift.Location = new System.Drawing.Point(154, 98);
            this.cBShift.Name = "cBShift";
            this.cBShift.Size = new System.Drawing.Size(157, 23);
            this.cBShift.TabIndex = 4;
            // 
            // cBoxEmpId
            // 
            this.cBoxEmpId.FormattingEnabled = true;
            this.cBoxEmpId.Location = new System.Drawing.Point(154, 32);
            this.cBoxEmpId.Name = "cBoxEmpId";
            this.cBoxEmpId.Size = new System.Drawing.Size(157, 23);
            this.cBoxEmpId.TabIndex = 3;
            // 
            // rbLeave
            // 
            this.rbLeave.AutoSize = true;
            this.rbLeave.Location = new System.Drawing.Point(249, 141);
            this.rbLeave.Name = "rbLeave";
            this.rbLeave.Size = new System.Drawing.Size(62, 19);
            this.rbLeave.TabIndex = 3;
            this.rbLeave.TabStop = true;
            this.rbLeave.Text = "Absent";
            this.rbLeave.UseVisualStyleBackColor = true;
            this.rbLeave.CheckedChanged += new System.EventHandler(this.rbLeave_CheckedChanged);
            // 
            // cBLeaveType
            // 
            this.cBLeaveType.FormattingEnabled = true;
            this.cBLeaveType.Location = new System.Drawing.Point(154, 21);
            this.cBLeaveType.Name = "cBLeaveType";
            this.cBLeaveType.Size = new System.Drawing.Size(157, 23);
            this.cBLeaveType.TabIndex = 21;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(154, 86);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(157, 62);
            this.txtReason.TabIndex = 22;
            // 
            // chBoxHalfDay
            // 
            this.chBoxHalfDay.AutoSize = true;
            this.chBoxHalfDay.Location = new System.Drawing.Point(154, 57);
            this.chBoxHalfDay.Name = "chBoxHalfDay";
            this.chBoxHalfDay.Size = new System.Drawing.Size(68, 19);
            this.chBoxHalfDay.TabIndex = 23;
            this.chBoxHalfDay.Text = "HalfDay";
            this.chBoxHalfDay.UseVisualStyleBackColor = true;
            this.chBoxHalfDay.CheckedChanged += new System.EventHandler(this.chBoxHalfDay_CheckedChanged);
            // 
            // gBLeaveType
            // 
            this.gBLeaveType.Controls.Add(this.lblLeaveType);
            this.gBLeaveType.Controls.Add(this.chBoxHalfDay);
            this.gBLeaveType.Controls.Add(this.label5);
            this.gBLeaveType.Controls.Add(this.txtReason);
            this.gBLeaveType.Controls.Add(this.cBLeaveType);
            this.gBLeaveType.Location = new System.Drawing.Point(15, 215);
            this.gBLeaveType.Name = "gBLeaveType";
            this.gBLeaveType.Size = new System.Drawing.Size(355, 157);
            this.gBLeaveType.TabIndex = 24;
            this.gBLeaveType.TabStop = false;
            this.gBLeaveType.Text = "Leave Type";
            // 
            // txtAttendaceId
            // 
            this.txtAttendaceId.Location = new System.Drawing.Point(377, 42);
            this.txtAttendaceId.Name = "txtAttendaceId";
            this.txtAttendaceId.Size = new System.Drawing.Size(14, 23);
            this.txtAttendaceId.TabIndex = 25;
            this.txtAttendaceId.Visible = false;
            // 
            // Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(403, 414);
            this.Controls.Add(this.txtAttendaceId);
            this.Controls.Add(this.gBLeaveType);
            this.Controls.Add(this.gBoxAttendance);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Attendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance";
            this.Load += new System.EventHandler(this.Attendance_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gBoxAttendance.ResumeLayout(false);
            this.gBoxAttendance.PerformLayout();
            this.gBLeaveType.ResumeLayout(false);
            this.gBLeaveType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmpID;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblLeaveType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblHeader;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox gBoxAttendance;
        private System.Windows.Forms.RadioButton rbLeave;
        private System.Windows.Forms.RadioButton rbPresent;
        private System.Windows.Forms.ComboBox cBShift;
        private System.Windows.Forms.ComboBox cBoxEmpId;
        private System.Windows.Forms.ComboBox cBLeaveType;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.CheckBox chBoxHalfDay;
        private System.Windows.Forms.GroupBox gBLeaveType;
        private System.Windows.Forms.TextBox txtAttendaceId;
    }
}