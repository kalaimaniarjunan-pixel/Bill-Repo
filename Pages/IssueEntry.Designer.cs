namespace HospitalManagement.Pages
{
    partial class IssueEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueEntry));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblHeader = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.label3 = new System.Windows.Forms.Label();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IssueEntryDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdGetProduct = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.gBoxDescription = new System.Windows.Forms.GroupBox();
            this.drpSupplierName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIssueID = new System.Windows.Forms.TextBox();
            this.dtIssueDate = new System.Windows.Forms.DateTimePicker();
            this.lblUserId = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGetProduct)).BeginInit();
            this.gBoxDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(201)))), ((int)(((byte)(62)))));
            this.toolStrip1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblHeader,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(540, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Margin = new System.Windows.Forms.Padding(3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(94, 19);
            this.lblHeader.Text = "Purchase Entry";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(201)))), ((int)(((byte)(62)))));
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.btnCancel,
            this.toolStripSeparator3,
            this.btnSave,
            this.toolStripSeparator4});
            this.toolStrip2.Location = new System.Drawing.Point(0, 344);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(540, 29);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date";
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 110;
            // 
            // UOM
            // 
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            this.UOM.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.MaxInputLength = 4;
            this.Qty.Name = "Qty";
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "Product Id";
            this.ProductId.Name = "ProductId";
            this.ProductId.ReadOnly = true;
            this.ProductId.Visible = false;
            // 
            // ProductName
            // 
            this.ProductName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProductName.Width = 170;
            // 
            // IssueEntryDetailID
            // 
            this.IssueEntryDetailID.HeaderText = "IssueEntryDetailID";
            this.IssueEntryDetailID.Name = "IssueEntryDetailID";
            this.IssueEntryDetailID.ReadOnly = true;
            this.IssueEntryDetailID.Visible = false;
            // 
            // grdGetProduct
            // 
            this.grdGetProduct.BackgroundColor = System.Drawing.Color.White;
            this.grdGetProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdGetProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGetProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IssueEntryDetailID,
            this.ProductName,
            this.ProductId,
            this.Qty,
            this.UOM,
            this.Stock});
            this.grdGetProduct.Location = new System.Drawing.Point(5, 134);
            this.grdGetProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdGetProduct.Name = "grdGetProduct";
            this.grdGetProduct.RowHeadersWidth = 25;
            this.grdGetProduct.Size = new System.Drawing.Size(509, 197);
            this.grdGetProduct.TabIndex = 12;
            this.grdGetProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdGetProduct_CellClick);
            this.grdGetProduct.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdGetProduct_CellValidated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Purchase ID";
            // 
            // gBoxDescription
            // 
            this.gBoxDescription.Controls.Add(this.drpSupplierName);
            this.gBoxDescription.Controls.Add(this.label1);
            this.gBoxDescription.Controls.Add(this.txtIssueID);
            this.gBoxDescription.Controls.Add(this.label4);
            this.gBoxDescription.Controls.Add(this.dtIssueDate);
            this.gBoxDescription.Controls.Add(this.label3);
            this.gBoxDescription.Location = new System.Drawing.Point(5, 36);
            this.gBoxDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBoxDescription.Name = "gBoxDescription";
            this.gBoxDescription.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBoxDescription.Size = new System.Drawing.Size(509, 77);
            this.gBoxDescription.TabIndex = 11;
            this.gBoxDescription.TabStop = false;
            this.gBoxDescription.Text = "General";
            // 
            // drpSupplierName
            // 
            this.drpSupplierName.FormattingEnabled = true;
            this.drpSupplierName.Location = new System.Drawing.Point(311, 41);
            this.drpSupplierName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.drpSupplierName.Name = "drpSupplierName";
            this.drpSupplierName.Size = new System.Drawing.Size(151, 21);
            this.drpSupplierName.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Supplier\'s Name";
            // 
            // txtIssueID
            // 
            this.txtIssueID.Enabled = false;
            this.txtIssueID.Location = new System.Drawing.Point(40, 42);
            this.txtIssueID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIssueID.Name = "txtIssueID";
            this.txtIssueID.Size = new System.Drawing.Size(95, 20);
            this.txtIssueID.TabIndex = 9;
            // 
            // dtIssueDate
            // 
            this.dtIssueDate.CustomFormat = "dd/MM/yyyy";
            this.dtIssueDate.Enabled = false;
            this.dtIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIssueDate.Location = new System.Drawing.Point(180, 42);
            this.dtIssueDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtIssueDate.Name = "dtIssueDate";
            this.dtIssueDate.Size = new System.Drawing.Size(95, 20);
            this.dtIssueDate.TabIndex = 7;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(-116, 426);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(35, 13);
            this.lblUserId.TabIndex = 13;
            this.lblUserId.Text = "label1";
            // 
            // IssueEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(540, 373);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grdGetProduct);
            this.Controls.Add(this.gBoxDescription);
            this.Controls.Add(this.lblUserId);
            this.Name = "IssueEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PurchaseEntry";
            this.Load += new System.EventHandler(this.IssueEntry_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGetProduct)).EndInit();
            this.gBoxDescription.ResumeLayout(false);
            this.gBoxDescription.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblHeader;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewButtonColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueEntryDetailID;
        private System.Windows.Forms.DataGridView grdGetProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gBoxDescription;
        private System.Windows.Forms.TextBox txtIssueID;
        private System.Windows.Forms.DateTimePicker dtIssueDate;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.ComboBox drpSupplierName;
        private System.Windows.Forms.Label label1;
    }
}