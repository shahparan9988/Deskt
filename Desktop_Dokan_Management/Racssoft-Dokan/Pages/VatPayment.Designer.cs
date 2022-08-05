
namespace Racssoft_Dokan.Pages
{
    partial class VatPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VatPayment));
            this.dateTimePickerVatPayment = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCollectedVat = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelDueVat = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelPaidVat = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelForPaymentMethod = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerVatPayment
            // 
            this.dateTimePickerVatPayment.Location = new System.Drawing.Point(212, 6);
            this.dateTimePickerVatPayment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePickerVatPayment.Name = "dateTimePickerVatPayment";
            this.dateTimePickerVatPayment.Size = new System.Drawing.Size(194, 21);
            this.dateTimePickerVatPayment.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Collected VAT";
            // 
            // labelCollectedVat
            // 
            this.labelCollectedVat.AutoSize = true;
            this.labelCollectedVat.Location = new System.Drawing.Point(91, 27);
            this.labelCollectedVat.Name = "labelCollectedVat";
            this.labelCollectedVat.Size = new System.Drawing.Size(14, 14);
            this.labelCollectedVat.TabIndex = 1;
            this.labelCollectedVat.Text = "_";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Due VAT";
            // 
            // labelDueVat
            // 
            this.labelDueVat.AutoSize = true;
            this.labelDueVat.Location = new System.Drawing.Point(299, 25);
            this.labelDueVat.Name = "labelDueVat";
            this.labelDueVat.Size = new System.Drawing.Size(14, 14);
            this.labelDueVat.TabIndex = 1;
            this.labelDueVat.Text = "_";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "Paid VAT";
            // 
            // labelPaidVat
            // 
            this.labelPaidVat.AutoSize = true;
            this.labelPaidVat.Location = new System.Drawing.Point(91, 64);
            this.labelPaidVat.Name = "labelPaidVat";
            this.labelPaidVat.Size = new System.Drawing.Size(14, 14);
            this.labelPaidVat.TabIndex = 1;
            this.labelPaidVat.Text = "_";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(145, 19);
            this.cmbPaymentMethod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(139, 22);
            this.cmbPaymentMethod.TabIndex = 2;
            this.cmbPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMethod_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelPaidVat);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelDueVat);
            this.groupBox1.Controls.Add(this.labelCollectedVat);
            this.groupBox1.Location = new System.Drawing.Point(10, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 95);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vat";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelForPaymentMethod);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmbPaymentMethod);
            this.groupBox2.Location = new System.Drawing.Point(55, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 223);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment";
            // 
            // panelForPaymentMethod
            // 
            this.panelForPaymentMethod.BackColor = System.Drawing.Color.White;
            this.panelForPaymentMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForPaymentMethod.Location = new System.Drawing.Point(7, 53);
            this.panelForPaymentMethod.Name = "panelForPaymentMethod";
            this.panelForPaymentMethod.Size = new System.Drawing.Size(277, 163);
            this.panelForPaymentMethod.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "Payment Method";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(348, 400);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(58, 34);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Paying Amount";
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.DecimalPlaces = 2;
            this.numericUpDownAmount.Location = new System.Drawing.Point(119, 363);
            this.numericUpDownAmount.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(226, 21);
            this.numericUpDownAmount.TabIndex = 7;
            this.numericUpDownAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VatPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(418, 445);
            this.Controls.Add(this.numericUpDownAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePickerVatPayment);
            this.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VatPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VAT Payment";
            this.MouseCaptureChanged += new System.EventHandler(this.VatPayment_MouseCaptureChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerVatPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCollectedVat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelDueVat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPaidVat;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel panelForPaymentMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
    }
}