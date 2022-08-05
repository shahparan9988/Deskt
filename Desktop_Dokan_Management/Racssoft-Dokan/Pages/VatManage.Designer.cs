
namespace Racssoft_Dokan.Pages
{
    partial class VatManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnManage = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCollectedVat = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPaidVat = new System.Windows.Forms.Label();
            this.lblDueVat = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.checkBoxDue = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxforIndividual = new System.Windows.Forms.CheckBox();
            this.grpBoxCustomerMobile = new System.Windows.Forms.GroupBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.grpBoxShopAllSalesDetails = new System.Windows.Forms.GroupBox();
            this.cmbSelectSearch = new System.Windows.Forms.ComboBox();
            this.groupBoxSearchByDate = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpBoxCustomerMobile.SuspendLayout();
            this.grpBoxShopAllSalesDetails.SuspendLayout();
            this.groupBoxSearchByDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnManage);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.checkBoxDue);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkBoxforIndividual);
            this.groupBox1.Controls.Add(this.grpBoxCustomerMobile);
            this.groupBox1.Controls.Add(this.grpBoxShopAllSalesDetails);
            this.groupBox1.Controls.Add(this.groupBoxSearchByDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(950, 589);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VAT Manage";
            // 
            // btnManage
            // 
            this.btnManage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.btnManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManage.Font = new System.Drawing.Font("Righteous", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManage.ForeColor = System.Drawing.Color.White;
            this.btnManage.Location = new System.Drawing.Point(831, 371);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(75, 53);
            this.btnManage.TabIndex = 28;
            this.btnManage.Text = "Manage VAT ";
            this.btnManage.UseVisualStyleBackColor = false;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(10, 245);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Size = new System.Drawing.Size(778, 335);
            this.dataGridView1.TabIndex = 27;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lblCollectedVat);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblPaidVat);
            this.groupBox2.Controls.Add(this.lblDueVat);
            this.groupBox2.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 59);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "VAT";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(424, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 16);
            this.label14.TabIndex = 8;
            this.label14.Text = "Due VAT:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 16);
            this.label15.TabIndex = 8;
            this.label15.Text = "Paid VAT:";
            // 
            // lblCollectedVat
            // 
            this.lblCollectedVat.AutoSize = true;
            this.lblCollectedVat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.lblCollectedVat.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectedVat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblCollectedVat.Location = new System.Drawing.Point(116, 17);
            this.lblCollectedVat.Name = "lblCollectedVat";
            this.lblCollectedVat.Size = new System.Drawing.Size(16, 16);
            this.lblCollectedVat.TabIndex = 5;
            this.lblCollectedVat.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 16);
            this.label13.TabIndex = 8;
            this.label13.Text = "Collected VAT:";
            // 
            // lblPaidVat
            // 
            this.lblPaidVat.AutoSize = true;
            this.lblPaidVat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.lblPaidVat.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidVat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblPaidVat.Location = new System.Drawing.Point(116, 37);
            this.lblPaidVat.Name = "lblPaidVat";
            this.lblPaidVat.Size = new System.Drawing.Size(16, 16);
            this.lblPaidVat.TabIndex = 5;
            this.lblPaidVat.Text = "0";
            // 
            // lblDueVat
            // 
            this.lblDueVat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDueVat.AutoSize = true;
            this.lblDueVat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.lblDueVat.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueVat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblDueVat.Location = new System.Drawing.Point(501, 17);
            this.lblDueVat.Name = "lblDueVat";
            this.lblDueVat.Size = new System.Drawing.Size(16, 16);
            this.lblDueVat.TabIndex = 5;
            this.lblDueVat.Text = "0";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Righteous", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(528, 141);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 33);
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // checkBoxDue
            // 
            this.checkBoxDue.AutoSize = true;
            this.checkBoxDue.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDue.Location = new System.Drawing.Point(281, 111);
            this.checkBoxDue.Name = "checkBoxDue";
            this.checkBoxDue.Size = new System.Drawing.Size(73, 20);
            this.checkBoxDue.TabIndex = 24;
            this.checkBoxDue.Text = "Due VAT";
            this.checkBoxDue.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Righteous", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(376, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 19;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxforIndividual
            // 
            this.checkBoxforIndividual.AutoSize = true;
            this.checkBoxforIndividual.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxforIndividual.Location = new System.Drawing.Point(43, 106);
            this.checkBoxforIndividual.Name = "checkBoxforIndividual";
            this.checkBoxforIndividual.Size = new System.Drawing.Size(177, 20);
            this.checkBoxforIndividual.TabIndex = 23;
            this.checkBoxforIndividual.Text = "Individual Customer Search";
            this.checkBoxforIndividual.UseVisualStyleBackColor = true;
            this.checkBoxforIndividual.CheckedChanged += new System.EventHandler(this.checkBoxforIndividual_CheckedChanged);
            // 
            // grpBoxCustomerMobile
            // 
            this.grpBoxCustomerMobile.Controls.Add(this.txtMobileNo);
            this.grpBoxCustomerMobile.Enabled = false;
            this.grpBoxCustomerMobile.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxCustomerMobile.Location = new System.Drawing.Point(43, 125);
            this.grpBoxCustomerMobile.Name = "grpBoxCustomerMobile";
            this.grpBoxCustomerMobile.Size = new System.Drawing.Size(166, 46);
            this.grpBoxCustomerMobile.TabIndex = 22;
            this.grpBoxCustomerMobile.TabStop = false;
            this.grpBoxCustomerMobile.Text = "Mobile No";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(6, 18);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(151, 21);
            this.txtMobileNo.TabIndex = 13;
            // 
            // grpBoxShopAllSalesDetails
            // 
            this.grpBoxShopAllSalesDetails.Controls.Add(this.cmbSelectSearch);
            this.grpBoxShopAllSalesDetails.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxShopAllSalesDetails.Location = new System.Drawing.Point(42, 26);
            this.grpBoxShopAllSalesDetails.Name = "grpBoxShopAllSalesDetails";
            this.grpBoxShopAllSalesDetails.Size = new System.Drawing.Size(220, 67);
            this.grpBoxShopAllSalesDetails.TabIndex = 21;
            this.grpBoxShopAllSalesDetails.TabStop = false;
            this.grpBoxShopAllSalesDetails.Text = "Date wise Search";
            // 
            // cmbSelectSearch
            // 
            this.cmbSelectSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSelectSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectSearch.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSelectSearch.FormattingEnabled = true;
            this.cmbSelectSearch.ItemHeight = 16;
            this.cmbSelectSearch.Items.AddRange(new object[] {
            "Choose Options for Sales Details",
            "Search by Date",
            "Todays sales "});
            this.cmbSelectSearch.Location = new System.Drawing.Point(19, 23);
            this.cmbSelectSearch.MaxDropDownItems = 20;
            this.cmbSelectSearch.Name = "cmbSelectSearch";
            this.cmbSelectSearch.Size = new System.Drawing.Size(182, 24);
            this.cmbSelectSearch.TabIndex = 0;
            this.cmbSelectSearch.SelectedIndexChanged += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxSearchByDate
            // 
            this.groupBoxSearchByDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSearchByDate.Controls.Add(this.dateTimePicker2);
            this.groupBoxSearchByDate.Controls.Add(this.dateTimePicker1);
            this.groupBoxSearchByDate.Controls.Add(this.label3);
            this.groupBoxSearchByDate.Controls.Add(this.label2);
            this.groupBoxSearchByDate.Enabled = false;
            this.groupBoxSearchByDate.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSearchByDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBoxSearchByDate.Location = new System.Drawing.Point(281, 26);
            this.groupBoxSearchByDate.Name = "groupBoxSearchByDate";
            this.groupBoxSearchByDate.Size = new System.Drawing.Size(507, 67);
            this.groupBoxSearchByDate.TabIndex = 20;
            this.groupBoxSearchByDate.TabStop = false;
            this.groupBoxSearchByDate.Text = "Search by Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Location = new System.Drawing.Point(293, 23);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(203, 22);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(43, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(195, 22);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(270, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "From";
            // 
            // VatManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(950, 589);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VatManage";
            this.Text = "VatManage";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpBoxCustomerMobile.ResumeLayout(false);
            this.grpBoxCustomerMobile.PerformLayout();
            this.grpBoxShopAllSalesDetails.ResumeLayout(false);
            this.groupBoxSearchByDate.ResumeLayout(false);
            this.groupBoxSearchByDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox checkBoxDue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxforIndividual;
        private System.Windows.Forms.GroupBox grpBoxCustomerMobile;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.GroupBox grpBoxShopAllSalesDetails;
        private System.Windows.Forms.ComboBox cmbSelectSearch;
        public System.Windows.Forms.GroupBox groupBoxSearchByDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCollectedVat;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblPaidVat;
        private System.Windows.Forms.Label lblDueVat;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnManage;
    }
}