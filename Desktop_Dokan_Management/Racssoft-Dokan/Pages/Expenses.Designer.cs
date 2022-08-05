
namespace Racssoft_Dokan.Pages
{
    partial class Expenses
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
            this.grpExpense = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelForPaymentMethod = new System.Windows.Forms.Panel();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.rTxtExpenseDetail = new System.Windows.Forms.RichTextBox();
            this.numericAmount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericDue = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.grpExpenseDetails = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgExpense = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpExpense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDue)).BeginInit();
            this.grpExpenseDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExpense)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpExpense
            // 
            this.grpExpense.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.grpExpense.Controls.Add(this.btnSave);
            this.grpExpense.Controls.Add(this.panelForPaymentMethod);
            this.grpExpense.Controls.Add(this.cmbPaymentMethod);
            this.grpExpense.Controls.Add(this.rTxtExpenseDetail);
            this.grpExpense.Controls.Add(this.numericAmount);
            this.grpExpense.Controls.Add(this.label3);
            this.grpExpense.Controls.Add(this.label2);
            this.grpExpense.Controls.Add(this.label1);
            this.grpExpense.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpExpense.Location = new System.Drawing.Point(41, 4);
            this.grpExpense.Name = "grpExpense";
            this.grpExpense.Size = new System.Drawing.Size(376, 369);
            this.grpExpense.TabIndex = 0;
            this.grpExpense.TabStop = false;
            this.grpExpense.Text = "Expense";
            this.grpExpense.MouseCaptureChanged += new System.EventHandler(this.grpExpense_MouseCaptureChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Righteous", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(287, 332);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelForPaymentMethod
            // 
            this.panelForPaymentMethod.BackColor = System.Drawing.Color.White;
            this.panelForPaymentMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForPaymentMethod.Location = new System.Drawing.Point(31, 146);
            this.panelForPaymentMethod.Name = "panelForPaymentMethod";
            this.panelForPaymentMethod.Size = new System.Drawing.Size(316, 132);
            this.panelForPaymentMethod.TabIndex = 5;
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(132, 110);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(215, 24);
            this.cmbPaymentMethod.TabIndex = 4;
            this.cmbPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMethod_SelectedIndexChanged);
            // 
            // rTxtExpenseDetail
            // 
            this.rTxtExpenseDetail.Location = new System.Drawing.Point(132, 39);
            this.rTxtExpenseDetail.Name = "rTxtExpenseDetail";
            this.rTxtExpenseDetail.Size = new System.Drawing.Size(215, 60);
            this.rTxtExpenseDetail.TabIndex = 3;
            this.rTxtExpenseDetail.Text = "";
            // 
            // numericAmount
            // 
            this.numericAmount.Location = new System.Drawing.Point(133, 295);
            this.numericAmount.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numericAmount.Name = "numericAmount";
            this.numericAmount.ReadOnly = true;
            this.numericAmount.Size = new System.Drawing.Size(215, 22);
            this.numericAmount.TabIndex = 2;
            this.numericAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericAmount.ValueChanged += new System.EventHandler(this.numericAmount_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Payment Method";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expense Detail";
            // 
            // numericDue
            // 
            this.numericDue.BackColor = System.Drawing.Color.White;
            this.numericDue.Location = new System.Drawing.Point(173, 373);
            this.numericDue.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericDue.Name = "numericDue";
            this.numericDue.ReadOnly = true;
            this.numericDue.Size = new System.Drawing.Size(215, 27);
            this.numericDue.TabIndex = 8;
            this.numericDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericDue.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 21);
            this.label6.TabIndex = 7;
            this.label6.Text = "Due";
            this.label6.Visible = false;
            // 
            // grpExpenseDetails
            // 
            this.grpExpenseDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpExpenseDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.grpExpenseDetails.Controls.Add(this.btnSearch);
            this.grpExpenseDetails.Controls.Add(this.dgExpense);
            this.grpExpenseDetails.Controls.Add(this.label5);
            this.grpExpenseDetails.Controls.Add(this.label4);
            this.grpExpenseDetails.Controls.Add(this.dateTimePickerTo);
            this.grpExpenseDetails.Controls.Add(this.dateTimePickerFrom);
            this.grpExpenseDetails.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpExpenseDetails.Location = new System.Drawing.Point(16, 4);
            this.grpExpenseDetails.Name = "grpExpenseDetails";
            this.grpExpenseDetails.Size = new System.Drawing.Size(412, 369);
            this.grpExpenseDetails.TabIndex = 1;
            this.grpExpenseDetails.TabStop = false;
            this.grpExpenseDetails.Text = "Expense Details";
            this.grpExpenseDetails.MouseCaptureChanged += new System.EventHandler(this.grpExpenseDetails_MouseCaptureChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Righteous", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(344, 83);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 28);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgExpense
            // 
            this.dgExpense.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgExpense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExpense.Location = new System.Drawing.Point(6, 117);
            this.dgExpense.Name = "dgExpense";
            this.dgExpense.Size = new System.Drawing.Size(400, 246);
            this.dgExpense.TabIndex = 2;
            this.dgExpense.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgExpense_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(218, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "To";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(221, 48);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(185, 22);
            this.dateTimePickerTo.TabIndex = 0;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(12, 48);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(186, 22);
            this.dateTimePickerFrom.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(913, 411);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Resize += new System.EventHandler(this.tableLayoutPanel1_Resize);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grpExpenseDetails);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(459, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 405);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericDue);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.grpExpense);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 405);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(919, 437);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Expense";
            this.groupBox1.MouseCaptureChanged += new System.EventHandler(this.groupBox1_MouseCaptureChanged);
            // 
            // Expenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(925, 440);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Expenses";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "Expenses";
            this.grpExpense.ResumeLayout(false);
            this.grpExpense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDue)).EndInit();
            this.grpExpenseDetails.ResumeLayout(false);
            this.grpExpenseDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExpense)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpExpense;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.RichTextBox rTxtExpenseDetail;
        private System.Windows.Forms.NumericUpDown numericAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelForPaymentMethod;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpExpenseDetails;
        private System.Windows.Forms.DataGridView dgExpense;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.NumericUpDown numericDue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}