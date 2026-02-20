namespace HospitalManagement.Pages
{
    partial class Product
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Product));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblHeader = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbsupplier = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.txtTaxable = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.isActive = new System.Windows.Forms.CheckBox();
            this.isTaxable = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtPieceQty = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gBoxProduct = new System.Windows.Forms.GroupBox();
            this.drpSupplierName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txthsnnumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCtGST = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStGST = new System.Windows.Forms.TextBox();
            this.txtMrp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblShortName = new System.Windows.Forms.Label();
            this.drpUOM = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.gBoxProduct.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(553, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Margin = new System.Windows.Forms.Padding(3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(51, 19);
            this.lblHeader.Text = "Product";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cmbsupplier
            // 
            this.cmbsupplier.FormattingEnabled = true;
            this.cmbsupplier.Location = new System.Drawing.Point(340, 296);
            this.cmbsupplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbsupplier.Name = "cmbsupplier";
            this.cmbsupplier.Size = new System.Drawing.Size(140, 25);
            this.cmbsupplier.TabIndex = 5;
            this.cmbsupplier.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(337, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "SupplierName *";
            this.label6.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(137, 346);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(230, 22);
            this.label12.TabIndex = 21;
            this.label12.Text = "Click to activate this Product";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(337, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(183, 16);
            this.label11.TabIndex = 20;
            this.label11.Text = "Apply Product Salestax when selling";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(321, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Taxable Percentage";
            this.label10.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // txtTaxable
            // 
            this.txtTaxable.Location = new System.Drawing.Point(449, 182);
            this.txtTaxable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTaxable.MaxLength = 10;
            this.txtTaxable.Name = "txtTaxable";
            this.txtTaxable.Size = new System.Drawing.Size(71, 25);
            this.txtTaxable.TabIndex = 8;
            this.txtTaxable.Visible = false;
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
            this.toolStrip2.Location = new System.Drawing.Point(0, 428);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(553, 29);
            this.toolStrip2.TabIndex = 11;
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
            // isActive
            // 
            this.isActive.AutoSize = true;
            this.isActive.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isActive.ForeColor = System.Drawing.Color.Green;
            this.isActive.Location = new System.Drawing.Point(143, 320);
            this.isActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.isActive.Name = "isActive";
            this.isActive.Size = new System.Drawing.Size(77, 25);
            this.isActive.TabIndex = 11;
            this.isActive.Text = "Active";
            this.isActive.UseVisualStyleBackColor = true;
            // 
            // isTaxable
            // 
            this.isTaxable.AutoSize = true;
            this.isTaxable.Location = new System.Drawing.Point(324, 229);
            this.isTaxable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.isTaxable.Name = "isTaxable";
            this.isTaxable.Size = new System.Drawing.Size(72, 21);
            this.isTaxable.TabIndex = 7;
            this.isTaxable.Text = "Taxable";
            this.isTaxable.UseVisualStyleBackColor = true;
            this.isTaxable.Visible = false;
            this.isTaxable.CheckedChanged += new System.EventHandler(this.isTaxable_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Selling Price *";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(143, 119);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrice.MaxLength = 20;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(137, 25);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // txtPieceQty
            // 
            this.txtPieceQty.Location = new System.Drawing.Point(142, 83);
            this.txtPieceQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPieceQty.MaxLength = 20;
            this.txtPieceQty.Name = "txtPieceQty";
            this.txtPieceQty.Size = new System.Drawing.Size(138, 25);
            this.txtPieceQty.TabIndex = 3;
            this.txtPieceQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPieceQty_KeyPress);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(142, 51);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductName.MaxLength = 100;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(295, 25);
            this.txtProductName.TabIndex = 2;
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(142, 22);
            this.txtProductId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductId.MaxLength = 50;
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(160, 25);
            this.txtProductId.TabIndex = 1;
            this.txtProductId.Leave += new System.EventHandler(this.txtProductId_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Per piece Quantity *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Name *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product ID *";
            // 
            // gBoxProduct
            // 
            this.gBoxProduct.Controls.Add(this.drpSupplierName);
            this.gBoxProduct.Controls.Add(this.label9);
            this.gBoxProduct.Controls.Add(this.label13);
            this.gBoxProduct.Controls.Add(this.txthsnnumber);
            this.gBoxProduct.Controls.Add(this.label7);
            this.gBoxProduct.Controls.Add(this.txtCtGST);
            this.gBoxProduct.Controls.Add(this.label5);
            this.gBoxProduct.Controls.Add(this.txtStGST);
            this.gBoxProduct.Controls.Add(this.txtMrp);
            this.gBoxProduct.Controls.Add(this.label3);
            this.gBoxProduct.Controls.Add(this.lblShortName);
            this.gBoxProduct.Controls.Add(this.drpUOM);
            this.gBoxProduct.Controls.Add(this.cmbsupplier);
            this.gBoxProduct.Controls.Add(this.label6);
            this.gBoxProduct.Controls.Add(this.label12);
            this.gBoxProduct.Controls.Add(this.label11);
            this.gBoxProduct.Controls.Add(this.label10);
            this.gBoxProduct.Controls.Add(this.txtTaxable);
            this.gBoxProduct.Controls.Add(this.isActive);
            this.gBoxProduct.Controls.Add(this.isTaxable);
            this.gBoxProduct.Controls.Add(this.label8);
            this.gBoxProduct.Controls.Add(this.txtPrice);
            this.gBoxProduct.Controls.Add(this.txtPieceQty);
            this.gBoxProduct.Controls.Add(this.txtProductName);
            this.gBoxProduct.Controls.Add(this.txtProductId);
            this.gBoxProduct.Controls.Add(this.label4);
            this.gBoxProduct.Controls.Add(this.label2);
            this.gBoxProduct.Controls.Add(this.label1);
            this.gBoxProduct.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxProduct.Location = new System.Drawing.Point(12, 29);
            this.gBoxProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBoxProduct.Name = "gBoxProduct";
            this.gBoxProduct.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBoxProduct.Size = new System.Drawing.Size(529, 395);
            this.gBoxProduct.TabIndex = 4;
            this.gBoxProduct.TabStop = false;
            this.gBoxProduct.Text = "Product Information";
            // 
            // drpSupplierName
            // 
            this.drpSupplierName.FormattingEnabled = true;
            this.drpSupplierName.Location = new System.Drawing.Point(143, 246);
            this.drpSupplierName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.drpSupplierName.Name = "drpSupplierName";
            this.drpSupplierName.Size = new System.Drawing.Size(175, 25);
            this.drpSupplierName.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 39;
            this.label9.Text = "HSN Code";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.label13.Location = new System.Drawing.Point(30, 253);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 18);
            this.label13.TabIndex = 40;
            this.label13.Text = "Supplier\'s Name *";
            // 
            // txthsnnumber
            // 
            this.txthsnnumber.Location = new System.Drawing.Point(143, 278);
            this.txthsnnumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txthsnnumber.MaxLength = 50;
            this.txthsnnumber.Name = "txthsnnumber";
            this.txthsnnumber.Size = new System.Drawing.Size(137, 25);
            this.txthsnnumber.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "C.GST *";
            // 
            // txtCtGST
            // 
            this.txtCtGST.Location = new System.Drawing.Point(142, 179);
            this.txtCtGST.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCtGST.MaxLength = 10;
            this.txtCtGST.Name = "txtCtGST";
            this.txtCtGST.Size = new System.Drawing.Size(138, 25);
            this.txtCtGST.TabIndex = 7;
            this.txtCtGST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCtGST_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 35;
            this.label5.Text = "S.GST *";
            // 
            // txtStGST
            // 
            this.txtStGST.Location = new System.Drawing.Point(142, 151);
            this.txtStGST.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStGST.MaxLength = 10;
            this.txtStGST.Name = "txtStGST";
            this.txtStGST.Size = new System.Drawing.Size(138, 25);
            this.txtStGST.TabIndex = 6;
            this.txtStGST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStGST_KeyPress);
            // 
            // txtMrp
            // 
            this.txtMrp.Location = new System.Drawing.Point(143, 212);
            this.txtMrp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMrp.MaxLength = 20;
            this.txtMrp.Name = "txtMrp";
            this.txtMrp.Size = new System.Drawing.Size(137, 25);
            this.txtMrp.TabIndex = 8;
            this.txtMrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMrp_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "MRP";
            // 
            // lblShortName
            // 
            this.lblShortName.AutoSize = true;
            this.lblShortName.Location = new System.Drawing.Point(286, 87);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(48, 17);
            this.lblShortName.TabIndex = 27;
            this.lblShortName.Text = "UOM *";
            // 
            // drpUOM
            // 
            this.drpUOM.FormattingEnabled = true;
            this.drpUOM.Location = new System.Drawing.Point(337, 83);
            this.drpUOM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.drpUOM.Name = "drpUOM";
            this.drpUOM.Size = new System.Drawing.Size(137, 25);
            this.drpUOM.TabIndex = 4;
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(553, 457);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.gBoxProduct);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Product";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product";
            this.Load += new System.EventHandler(this.Product_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.gBoxProduct.ResumeLayout(false);
            this.gBoxProduct.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblHeader;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ComboBox cmbsupplier;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TextBox txtTaxable;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.CheckBox isActive;
        private System.Windows.Forms.CheckBox isTaxable;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtPieceQty;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gBoxProduct;
        private System.Windows.Forms.Label lblShortName;
        private System.Windows.Forms.ComboBox drpUOM;
        private System.Windows.Forms.TextBox txtMrp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCtGST;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStGST;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txthsnnumber;
        private System.Windows.Forms.ComboBox drpSupplierName;
        private System.Windows.Forms.Label label13;
    }
}