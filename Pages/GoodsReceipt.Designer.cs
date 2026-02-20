namespace HospitalManagement.Pages
{
    partial class GoodsReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsReceipt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblHeader = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtGRNno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gBoxGeneral = new System.Windows.Forms.GroupBox();
            this.txtsupplierinvoiceno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.drpSupplierName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grdGetProducts = new System.Windows.Forms.DataGridView();
            this.GRNDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductsName = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiveQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalPaid = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblChangeAmount = new System.Windows.Forms.Label();
            this.chBoxAddToCart = new System.Windows.Forms.CheckBox();
            this.txtTenderAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gBoxGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGetProducts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtReceivedDate
            // 
            this.dtReceivedDate.CustomFormat = "dd/MM/yyyy";
            this.dtReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceivedDate.Location = new System.Drawing.Point(491, 21);
            this.dtReceivedDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtReceivedDate.Name = "dtReceivedDate";
            this.dtReceivedDate.Size = new System.Drawing.Size(128, 23);
            this.dtReceivedDate.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label4.Location = new System.Drawing.Point(402, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Received Date";
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
            this.toolStrip2.Location = new System.Drawing.Point(0, 535);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1075, 29);
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
            this.toolStrip1.Size = new System.Drawing.Size(1075, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Margin = new System.Windows.Forms.Padding(3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(163, 19);
            this.lblHeader.Text = "Goods Receipt Notes Entry";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // txtGRNno
            // 
            this.txtGRNno.Enabled = false;
            this.txtGRNno.Location = new System.Drawing.Point(161, 21);
            this.txtGRNno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGRNno.Name = "txtGRNno";
            this.txtGRNno.Size = new System.Drawing.Size(103, 23);
            this.txtGRNno.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label2.Location = new System.Drawing.Point(57, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "GRN No (Invoice)";
            // 
            // gBoxGeneral
            // 
            this.gBoxGeneral.Controls.Add(this.txtsupplierinvoiceno);
            this.gBoxGeneral.Controls.Add(this.label9);
            this.gBoxGeneral.Controls.Add(this.drpSupplierName);
            this.gBoxGeneral.Controls.Add(this.dtReceivedDate);
            this.gBoxGeneral.Controls.Add(this.label3);
            this.gBoxGeneral.Controls.Add(this.txtGRNno);
            this.gBoxGeneral.Controls.Add(this.label2);
            this.gBoxGeneral.Controls.Add(this.label4);
            this.gBoxGeneral.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxGeneral.Location = new System.Drawing.Point(7, 32);
            this.gBoxGeneral.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBoxGeneral.Name = "gBoxGeneral";
            this.gBoxGeneral.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBoxGeneral.Size = new System.Drawing.Size(724, 82);
            this.gBoxGeneral.TabIndex = 30;
            this.gBoxGeneral.TabStop = false;
            this.gBoxGeneral.Text = "General";
            // 
            // txtsupplierinvoiceno
            // 
            this.txtsupplierinvoiceno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsupplierinvoiceno.Location = new System.Drawing.Point(491, 52);
            this.txtsupplierinvoiceno.Name = "txtsupplierinvoiceno";
            this.txtsupplierinvoiceno.Size = new System.Drawing.Size(128, 23);
            this.txtsupplierinvoiceno.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label9.Location = new System.Drawing.Point(365, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 18);
            this.label9.TabIndex = 40;
            this.label9.Text = "Supplier\'s Invoice No";
            // 
            // drpSupplierName
            // 
            this.drpSupplierName.FormattingEnabled = true;
            this.drpSupplierName.Location = new System.Drawing.Point(161, 52);
            this.drpSupplierName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.drpSupplierName.Name = "drpSupplierName";
            this.drpSupplierName.Size = new System.Drawing.Size(151, 23);
            this.drpSupplierName.TabIndex = 39;
            this.drpSupplierName.SelectionChangeCommitted += new System.EventHandler(this.drpSupplierName_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label3.Location = new System.Drawing.Point(57, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 38;
            this.label3.Text = "Supplier\'s Name";
            // 
            // grdGetProducts
            // 
            this.grdGetProducts.BackgroundColor = System.Drawing.Color.White;
            this.grdGetProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdGetProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdGetProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGetProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GRNDetailId,
            this.ProductsName,
            this.ProductID,
            this.ReceiveQty,
            this.UOM,
            this.Price,
            this.Tax,
            this.TotalAmount});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdGetProducts.DefaultCellStyle = dataGridViewCellStyle7;
            this.grdGetProducts.Location = new System.Drawing.Point(7, 122);
            this.grdGetProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdGetProducts.Name = "grdGetProducts";
            this.grdGetProducts.RowHeadersWidth = 35;
            this.grdGetProducts.Size = new System.Drawing.Size(724, 409);
            this.grdGetProducts.TabIndex = 32;
            this.grdGetProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdGetProducts_CellClick);
            this.grdGetProducts.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdGetProducts_CellValidated);
            // 
            // GRNDetailId
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.GRNDetailId.DefaultCellStyle = dataGridViewCellStyle2;
            this.GRNDetailId.HeaderText = "GRNDetailId";
            this.GRNDetailId.Name = "GRNDetailId";
            this.GRNDetailId.ReadOnly = true;
            this.GRNDetailId.Visible = false;
            this.GRNDetailId.Width = 80;
            // 
            // ProductsName
            // 
            this.ProductsName.FillWeight = 160F;
            this.ProductsName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ProductsName.HeaderText = "Product Name";
            this.ProductsName.Name = "ProductsName";
            this.ProductsName.Width = 160;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "Product Id";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductID.Visible = false;
            // 
            // ReceiveQty
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.ReceiveQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.ReceiveQty.HeaderText = "Receive Qty";
            this.ReceiveQty.MaxInputLength = 10;
            this.ReceiveQty.Name = "ReceiveQty";
            // 
            // UOM
            // 
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            this.UOM.ReadOnly = true;
            this.UOM.Visible = false;
            this.UOM.Width = 80;
            // 
            // Price
            // 
            dataGridViewCellStyle4.Format = "0.00";
            dataGridViewCellStyle4.NullValue = "0.00";
            this.Price.DefaultCellStyle = dataGridViewCellStyle4;
            this.Price.HeaderText = "Price";
            this.Price.MaxInputLength = 16;
            this.Price.Name = "Price";
            this.Price.Width = 110;
            // 
            // Tax
            // 
            dataGridViewCellStyle5.Format = "0.00";
            dataGridViewCellStyle5.NullValue = "0.00";
            this.Tax.DefaultCellStyle = dataGridViewCellStyle5;
            this.Tax.HeaderText = "Tax";
            this.Tax.MaxInputLength = 10;
            this.Tax.Name = "Tax";
            this.Tax.ReadOnly = true;
            // 
            // TotalAmount
            // 
            dataGridViewCellStyle6.Format = "0.00";
            dataGridViewCellStyle6.NullValue = "0.00";
            this.TotalAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.TotalAmount.HeaderText = "TotalAmount";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            this.TotalAmount.Width = 130;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblTotalPaid);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblChangeAmount);
            this.groupBox1.Controls.Add(this.chBoxAddToCart);
            this.groupBox1.Controls.Add(this.txtTenderAmount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblBalance);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblTotalAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.groupBox1.Location = new System.Drawing.Point(751, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 497);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cash Details";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(32, 185);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 18);
            this.label19.TabIndex = 46;
            this.label19.Text = "Net Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label7.Location = new System.Drawing.Point(108, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 18);
            this.label7.TabIndex = 45;
            this.label7.Text = "Rs :";
            // 
            // lblTotalPaid
            // 
            this.lblTotalPaid.AutoSize = true;
            this.lblTotalPaid.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPaid.ForeColor = System.Drawing.Color.Red;
            this.lblTotalPaid.Location = new System.Drawing.Point(142, 183);
            this.lblTotalPaid.Name = "lblTotalPaid";
            this.lblTotalPaid.Size = new System.Drawing.Size(50, 24);
            this.lblTotalPaid.TabIndex = 44;
            this.lblTotalPaid.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label5.Location = new System.Drawing.Point(29, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 18);
            this.label5.TabIndex = 43;
            this.label5.Text = "Change Amount :";
            // 
            // lblChangeAmount
            // 
            this.lblChangeAmount.AutoSize = true;
            this.lblChangeAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeAmount.Location = new System.Drawing.Point(143, 104);
            this.lblChangeAmount.Name = "lblChangeAmount";
            this.lblChangeAmount.Size = new System.Drawing.Size(28, 15);
            this.lblChangeAmount.TabIndex = 42;
            this.lblChangeAmount.Text = "0.00";
            // 
            // chBoxAddToCart
            // 
            this.chBoxAddToCart.AutoSize = true;
            this.chBoxAddToCart.Location = new System.Drawing.Point(97, 240);
            this.chBoxAddToCart.Name = "chBoxAddToCart";
            this.chBoxAddToCart.Size = new System.Drawing.Size(93, 22);
            this.chBoxAddToCart.TabIndex = 41;
            this.chBoxAddToCart.Text = "Add To Cart";
            this.chBoxAddToCart.UseVisualStyleBackColor = true;
            // 
            // txtTenderAmount
            // 
            this.txtTenderAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenderAmount.Location = new System.Drawing.Point(141, 125);
            this.txtTenderAmount.Name = "txtTenderAmount";
            this.txtTenderAmount.Size = new System.Drawing.Size(110, 23);
            this.txtTenderAmount.TabIndex = 40;
            this.txtTenderAmount.TextChanged += new System.EventHandler(this.txtTenderAmount_TextChanged);
            this.txtTenderAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenderAmount_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label8.Location = new System.Drawing.Point(29, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 18);
            this.label8.TabIndex = 39;
            this.label8.Text = "Tender Amount :";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(137, 22);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(28, 13);
            this.lblBalance.TabIndex = 38;
            this.lblBalance.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label6.Location = new System.Drawing.Point(87, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 18);
            this.label6.TabIndex = 37;
            this.label6.Text = "Total :";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Green;
            this.lblTotalAmount.Location = new System.Drawing.Point(137, 56);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(50, 24);
            this.lblTotalAmount.TabIndex = 36;
            this.lblTotalAmount.Text = "0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "Balance for Supplier :";
            // 
            // GoodsReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1075, 564);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gBoxGeneral);
            this.Controls.Add(this.grdGetProducts);
            this.Name = "GoodsReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Goods Receipt";
            this.Load += new System.EventHandler(this.GoodsReceipt_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gBoxGeneral.ResumeLayout(false);
            this.gBoxGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGetProducts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtReceivedDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblHeader;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox txtGRNno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gBoxGeneral;
        private System.Windows.Forms.DataGridView grdGetProducts;
        private System.Windows.Forms.ComboBox drpSupplierName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenderAmount;
        private System.Windows.Forms.CheckBox chBoxAddToCart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblChangeAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalPaid;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtsupplierinvoiceno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn GRNDetailId;
        private System.Windows.Forms.DataGridViewButtonColumn ProductsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiveQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
    }
}