
namespace Racssoft_Dokan.Pages
{
    partial class InvoicePayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoicePayment));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpPaymentHistory = new System.Windows.Forms.GroupBox();
            this.dgPaymentHistory = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelPaymentWays = new System.Windows.Forms.Panel();
            this.comboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblUpdatedDate = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lblDue = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.lblPayableAmount = new System.Windows.Forms.Label();
            this.lblOtherCost = new System.Windows.Forms.Label();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpPaymentHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPaymentHistory)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.groupBox1.Controls.Add(this.grpPaymentHistory);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lblUpdatedDate);
            this.groupBox1.Controls.Add(this.lblCreatedDate);
            this.groupBox1.Controls.Add(this.lblDue);
            this.groupBox1.Controls.Add(this.lblDiscount);
            this.groupBox1.Controls.Add(this.lblPaidAmount);
            this.groupBox1.Controls.Add(this.lblPayableAmount);
            this.groupBox1.Controls.Add(this.lblOtherCost);
            this.groupBox1.Controls.Add(this.lblSupplierName);
            this.groupBox1.Controls.Add(this.lblInvoiceNo);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 485);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.MouseCaptureChanged += new System.EventHandler(this.groupBox1_MouseCaptureChanged);
            // 
            // grpPaymentHistory
            // 
            this.grpPaymentHistory.Controls.Add(this.dgPaymentHistory);
            this.grpPaymentHistory.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPaymentHistory.Location = new System.Drawing.Point(23, 251);
            this.grpPaymentHistory.Name = "grpPaymentHistory";
            this.grpPaymentHistory.Size = new System.Drawing.Size(339, 229);
            this.grpPaymentHistory.TabIndex = 3;
            this.grpPaymentHistory.TabStop = false;
            this.grpPaymentHistory.Text = "Payment History";
            this.grpPaymentHistory.MouseCaptureChanged += new System.EventHandler(this.grpPaymentHistory_MouseCaptureChanged);
            // 
            // dgPaymentHistory
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgPaymentHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPaymentHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPaymentHistory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgPaymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPaymentHistory.Location = new System.Drawing.Point(6, 19);
            this.dgPaymentHistory.Name = "dgPaymentHistory";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgPaymentHistory.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgPaymentHistory.Size = new System.Drawing.Size(327, 204);
            this.dgPaymentHistory.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Righteous", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(569, 440);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 33);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelPaymentWays);
            this.groupBox2.Controls.Add(this.comboPaymentMethod);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(368, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 411);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Due Payment";
            this.groupBox2.MouseCaptureChanged += new System.EventHandler(this.groupBox2_MouseCaptureChanged);
            // 
            // panelPaymentWays
            // 
            this.panelPaymentWays.BackColor = System.Drawing.Color.White;
            this.panelPaymentWays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPaymentWays.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelPaymentWays.Location = new System.Drawing.Point(6, 60);
            this.panelPaymentWays.Name = "panelPaymentWays";
            this.panelPaymentWays.Size = new System.Drawing.Size(270, 345);
            this.panelPaymentWays.TabIndex = 2;
            this.panelPaymentWays.MouseCaptureChanged += new System.EventHandler(this.panelPaymentWays_MouseCaptureChanged);
            // 
            // comboPaymentMethod
            // 
            this.comboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPaymentMethod.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPaymentMethod.FormattingEnabled = true;
            this.comboPaymentMethod.Location = new System.Drawing.Point(124, 22);
            this.comboPaymentMethod.Name = "comboPaymentMethod";
            this.comboPaymentMethod.Size = new System.Drawing.Size(152, 22);
            this.comboPaymentMethod.TabIndex = 1;
            this.comboPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(17, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 14);
            this.label17.TabIndex = 0;
            this.label17.Text = "Payment Method";
            // 
            // lblUpdatedDate
            // 
            this.lblUpdatedDate.AutoSize = true;
            this.lblUpdatedDate.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedDate.Location = new System.Drawing.Point(132, 223);
            this.lblUpdatedDate.Name = "lblUpdatedDate";
            this.lblUpdatedDate.Size = new System.Drawing.Size(15, 16);
            this.lblUpdatedDate.TabIndex = 0;
            this.lblUpdatedDate.Text = "_";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedDate.Location = new System.Drawing.Point(132, 199);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(15, 16);
            this.lblCreatedDate.TabIndex = 0;
            this.lblCreatedDate.Text = "_";
            // 
            // lblDue
            // 
            this.lblDue.AutoSize = true;
            this.lblDue.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDue.Location = new System.Drawing.Point(132, 123);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(15, 16);
            this.lblDue.TabIndex = 0;
            this.lblDue.Text = "_";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(132, 148);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(15, 16);
            this.lblDiscount.TabIndex = 0;
            this.lblDiscount.Text = "_";
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.AutoSize = true;
            this.lblPaidAmount.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidAmount.Location = new System.Drawing.Point(132, 102);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(15, 16);
            this.lblPaidAmount.TabIndex = 0;
            this.lblPaidAmount.Text = "_";
            // 
            // lblPayableAmount
            // 
            this.lblPayableAmount.AutoSize = true;
            this.lblPayableAmount.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayableAmount.Location = new System.Drawing.Point(132, 80);
            this.lblPayableAmount.Name = "lblPayableAmount";
            this.lblPayableAmount.Size = new System.Drawing.Size(15, 16);
            this.lblPayableAmount.TabIndex = 0;
            this.lblPayableAmount.Text = "_";
            // 
            // lblOtherCost
            // 
            this.lblOtherCost.AutoSize = true;
            this.lblOtherCost.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherCost.Location = new System.Drawing.Point(132, 174);
            this.lblOtherCost.Name = "lblOtherCost";
            this.lblOtherCost.Size = new System.Drawing.Size(15, 16);
            this.lblOtherCost.TabIndex = 0;
            this.lblOtherCost.Text = "_";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierName.Location = new System.Drawing.Point(132, 57);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(15, 16);
            this.lblSupplierName.TabIndex = 0;
            this.lblSupplierName.Text = "_";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.Location = new System.Drawing.Point(132, 32);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(15, 16);
            this.lblInvoiceNo.TabIndex = 0;
            this.lblInvoiceNo.Text = "_";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(26, 223);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Updated Date";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(26, 199);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Created Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(26, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Due";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Discount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Previous Paid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Payable Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Other Cost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Supplier Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice No";
            // 
            // InvoicePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(664, 488);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InvoicePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Invoice Payment";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpPaymentHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPaymentHistory)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboPaymentMethod;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblUpdatedDate;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lblDue;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.Label lblOtherCost;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelPaymentWays;
        private System.Windows.Forms.Label lblPayableAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpPaymentHistory;
        private System.Windows.Forms.DataGridView dgPaymentHistory;
    }
}