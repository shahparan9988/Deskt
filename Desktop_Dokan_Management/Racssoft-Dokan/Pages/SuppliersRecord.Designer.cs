
namespace Racssoft_Dokan.Pages
{
    partial class SuppliersRecord
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
            this.txtBoxSupplierSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgSuppliersInfo = new System.Windows.Forms.DataGridView();
            this.groupBoxSuppliersInfo = new System.Windows.Forms.GroupBox();
            this.lblTotalDue = new System.Windows.Forms.Label();
            this.lblTotalPaid = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalPurchase = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxSuppliers = new System.Windows.Forms.ComboBox();
            this.listBoxSuppliersName = new System.Windows.Forms.ListBox();
            this.groupBoxSuppliersRecord = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgSuppliersInfo)).BeginInit();
            this.groupBoxSuppliersInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxSuppliersRecord.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxSupplierSearch
            // 
            this.txtBoxSupplierSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxSupplierSearch.Location = new System.Drawing.Point(356, 19);
            this.txtBoxSupplierSearch.Name = "txtBoxSupplierSearch";
            this.txtBoxSupplierSearch.Size = new System.Drawing.Size(225, 22);
            this.txtBoxSupplierSearch.TabIndex = 0;
            this.txtBoxSupplierSearch.Text = "Suppliers Name";
            this.txtBoxSupplierSearch.Click += new System.EventHandler(this.textBox_Click);
            this.txtBoxSupplierSearch.TextChanged += new System.EventHandler(this.txtBoxSupplierSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Righteous", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(263, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 28);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgSuppliersInfo
            // 
            this.dgSuppliersInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSuppliersInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSuppliersInfo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgSuppliersInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSuppliersInfo.Location = new System.Drawing.Point(6, 117);
            this.dgSuppliersInfo.Name = "dgSuppliersInfo";
            this.dgSuppliersInfo.Size = new System.Drawing.Size(775, 317);
            this.dgSuppliersInfo.TabIndex = 2;
            this.dgSuppliersInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSuppliersInfo_CellContentClick);
            // 
            // groupBoxSuppliersInfo
            // 
            this.groupBoxSuppliersInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSuppliersInfo.Controls.Add(this.lblTotalDue);
            this.groupBoxSuppliersInfo.Controls.Add(this.lblTotalPaid);
            this.groupBoxSuppliersInfo.Controls.Add(this.label11);
            this.groupBoxSuppliersInfo.Controls.Add(this.label3);
            this.groupBoxSuppliersInfo.Controls.Add(this.lblTotalPurchase);
            this.groupBoxSuppliersInfo.Controls.Add(this.lblAddress);
            this.groupBoxSuppliersInfo.Controls.Add(this.lblMobileNo);
            this.groupBoxSuppliersInfo.Controls.Add(this.lblName);
            this.groupBoxSuppliersInfo.Controls.Add(this.label2);
            this.groupBoxSuppliersInfo.Controls.Add(this.label8);
            this.groupBoxSuppliersInfo.Controls.Add(this.label7);
            this.groupBoxSuppliersInfo.Controls.Add(this.label1);
            this.groupBoxSuppliersInfo.Controls.Add(this.dgSuppliersInfo);
            this.groupBoxSuppliersInfo.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSuppliersInfo.Location = new System.Drawing.Point(6, 114);
            this.groupBoxSuppliersInfo.Name = "groupBoxSuppliersInfo";
            this.groupBoxSuppliersInfo.Size = new System.Drawing.Size(787, 440);
            this.groupBoxSuppliersInfo.TabIndex = 3;
            this.groupBoxSuppliersInfo.TabStop = false;
            this.groupBoxSuppliersInfo.Text = "Suppliers Information";
            // 
            // lblTotalDue
            // 
            this.lblTotalDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDue.AutoSize = true;
            this.lblTotalDue.Location = new System.Drawing.Point(517, 80);
            this.lblTotalDue.Name = "lblTotalDue";
            this.lblTotalDue.Size = new System.Drawing.Size(15, 16);
            this.lblTotalDue.TabIndex = 3;
            this.lblTotalDue.Text = "_";
            // 
            // lblTotalPaid
            // 
            this.lblTotalPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPaid.AutoSize = true;
            this.lblTotalPaid.Location = new System.Drawing.Point(517, 53);
            this.lblTotalPaid.Name = "lblTotalPaid";
            this.lblTotalPaid.Size = new System.Drawing.Size(15, 16);
            this.lblTotalPaid.TabIndex = 3;
            this.lblTotalPaid.Text = "_";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(406, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Due Amount";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Paid Amount";
            // 
            // lblTotalPurchase
            // 
            this.lblTotalPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPurchase.AutoSize = true;
            this.lblTotalPurchase.Location = new System.Drawing.Point(517, 27);
            this.lblTotalPurchase.Name = "lblTotalPurchase";
            this.lblTotalPurchase.Size = new System.Drawing.Size(15, 16);
            this.lblTotalPurchase.TabIndex = 3;
            this.lblTotalPurchase.Text = "_";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(207, 80);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(15, 16);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "_";
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Location = new System.Drawing.Point(207, 53);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(15, 16);
            this.lblMobileNo.TabIndex = 3;
            this.lblMobileNo.Text = "_";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(207, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(15, 16);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "_";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Purchase Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(122, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Mobile No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxSuppliers);
            this.groupBox1.Controls.Add(this.listBoxSuppliersName);
            this.groupBox1.Controls.Add(this.txtBoxSupplierSearch);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(87, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 89);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Search By";
            // 
            // comboBoxSuppliers
            // 
            this.comboBoxSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSuppliers.FormattingEnabled = true;
            this.comboBoxSuppliers.Items.AddRange(new object[] {
            "Select Supplier\'s Name"});
            this.comboBoxSuppliers.Location = new System.Drawing.Point(28, 19);
            this.comboBoxSuppliers.Name = "comboBoxSuppliers";
            this.comboBoxSuppliers.Size = new System.Drawing.Size(251, 24);
            this.comboBoxSuppliers.TabIndex = 6;
            this.comboBoxSuppliers.SelectedIndexChanged += new System.EventHandler(this.comboBoxSuppliers_SelectedIndexChanged);
            // 
            // listBoxSuppliersName
            // 
            this.listBoxSuppliersName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxSuppliersName.FormattingEnabled = true;
            this.listBoxSuppliersName.ItemHeight = 16;
            this.listBoxSuppliersName.Location = new System.Drawing.Point(356, 33);
            this.listBoxSuppliersName.Name = "listBoxSuppliersName";
            this.listBoxSuppliersName.Size = new System.Drawing.Size(225, 52);
            this.listBoxSuppliersName.TabIndex = 5;
            this.listBoxSuppliersName.Visible = false;
            this.listBoxSuppliersName.SelectedIndexChanged += new System.EventHandler(this.listBoxSuppliersName_SelectedIndexChanged);
            // 
            // groupBoxSuppliersRecord
            // 
            this.groupBoxSuppliersRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSuppliersRecord.Controls.Add(this.groupBox1);
            this.groupBoxSuppliersRecord.Controls.Add(this.groupBoxSuppliersInfo);
            this.groupBoxSuppliersRecord.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSuppliersRecord.Location = new System.Drawing.Point(4, 3);
            this.groupBoxSuppliersRecord.Name = "groupBoxSuppliersRecord";
            this.groupBoxSuppliersRecord.Size = new System.Drawing.Size(801, 559);
            this.groupBoxSuppliersRecord.TabIndex = 5;
            this.groupBoxSuppliersRecord.TabStop = false;
            this.groupBoxSuppliersRecord.Text = "Supplier\'s Record";
            // 
            // SuppliersRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(810, 573);
            this.Controls.Add(this.groupBoxSuppliersRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SuppliersRecord";
            this.Text = "SuppliersRecord";
            this.Resize += new System.EventHandler(this.SuppliersRecord_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgSuppliersInfo)).EndInit();
            this.groupBoxSuppliersInfo.ResumeLayout(false);
            this.groupBoxSuppliersInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxSuppliersRecord.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxSupplierSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgSuppliersInfo;
        private System.Windows.Forms.GroupBox groupBoxSuppliersInfo;
        private System.Windows.Forms.Label lblTotalPaid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalPurchase;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalDue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxSuppliersName;
        private System.Windows.Forms.ComboBox comboBoxSuppliers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxSuppliersRecord;
    }
}