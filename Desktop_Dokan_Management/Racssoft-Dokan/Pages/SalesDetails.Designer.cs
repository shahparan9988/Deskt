namespace Racssoft_Dokan.Pages
{
    partial class SalesDetails
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxSalesDetails = new System.Windows.Forms.GroupBox();
            this.chartSale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.checkBoxDue = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalSale = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotalProfit = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalDue = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCollectedVat = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPaidVat = new System.Windows.Forms.Label();
            this.lblDueVat = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBoxInvoiceDetails = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPurchasedDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDue = new System.Windows.Forms.Label();
            this.lblCustomerMobile = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblPaid = new System.Windows.Forms.Label();
            this.lblInvoiceId = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
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
            this.groupBoxSalesDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSale)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxInvoiceDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.grpBoxCustomerMobile.SuspendLayout();
            this.grpBoxShopAllSalesDetails.SuspendLayout();
            this.groupBoxSearchByDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSalesDetails
            // 
            this.groupBoxSalesDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.groupBoxSalesDetails.Controls.Add(this.chartSale);
            this.groupBoxSalesDetails.Controls.Add(this.btnRefresh);
            this.groupBoxSalesDetails.Controls.Add(this.checkBoxDue);
            this.groupBoxSalesDetails.Controls.Add(this.groupBox1);
            this.groupBoxSalesDetails.Controls.Add(this.groupBoxInvoiceDetails);
            this.groupBoxSalesDetails.Controls.Add(this.button1);
            this.groupBoxSalesDetails.Controls.Add(this.checkBoxforIndividual);
            this.groupBoxSalesDetails.Controls.Add(this.grpBoxCustomerMobile);
            this.groupBoxSalesDetails.Controls.Add(this.grpBoxShopAllSalesDetails);
            this.groupBoxSalesDetails.Controls.Add(this.groupBoxSearchByDate);
            this.groupBoxSalesDetails.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSalesDetails.Location = new System.Drawing.Point(6, 3);
            this.groupBoxSalesDetails.Name = "groupBoxSalesDetails";
            this.groupBoxSalesDetails.Size = new System.Drawing.Size(1260, 630);
            this.groupBoxSalesDetails.TabIndex = 0;
            this.groupBoxSalesDetails.TabStop = false;
            this.groupBoxSalesDetails.Text = "Sales Record";
            // 
            // chartSale
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSale.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSale.Legends.Add(legend1);
            this.chartSale.Location = new System.Drawing.Point(832, 14);
            this.chartSale.Name = "chartSale";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series5";
            this.chartSale.Series.Add(series1);
            this.chartSale.Size = new System.Drawing.Size(422, 177);
            this.chartSale.TabIndex = 19;
            this.chartSale.Text = "chart1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Righteous", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(546, 138);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 33);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // checkBoxDue
            // 
            this.checkBoxDue.AutoSize = true;
            this.checkBoxDue.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDue.Location = new System.Drawing.Point(299, 108);
            this.checkBoxDue.Name = "checkBoxDue";
            this.checkBoxDue.Size = new System.Drawing.Size(48, 20);
            this.checkBoxDue.TabIndex = 17;
            this.checkBoxDue.Text = "Due";
            this.checkBoxDue.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(6, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 425);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lblTotalSale);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.lblTotalProfit);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblTotalDue);
            this.groupBox3.Controls.Add(this.lblTotalCost);
            this.groupBox3.Location = new System.Drawing.Point(6, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 59);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(22, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Sale:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Profit:";
            // 
            // lblTotalSale
            // 
            this.lblTotalSale.AutoSize = true;
            this.lblTotalSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.lblTotalSale.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblTotalSale.Location = new System.Drawing.Point(94, 18);
            this.lblTotalSale.Name = "lblTotalSale";
            this.lblTotalSale.Size = new System.Drawing.Size(16, 16);
            this.lblTotalSale.TabIndex = 5;
            this.lblTotalSale.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(221, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 16);
            this.label12.TabIndex = 4;
            this.label12.Text = "Cost:";
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.AutoSize = true;
            this.lblTotalProfit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.lblTotalProfit.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProfit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblTotalProfit.Location = new System.Drawing.Point(304, 18);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Size = new System.Drawing.Size(16, 16);
            this.lblTotalProfit.TabIndex = 5;
            this.lblTotalProfit.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(22, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Due:";
            // 
            // lblTotalDue
            // 
            this.lblTotalDue.AutoSize = true;
            this.lblTotalDue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.lblTotalDue.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblTotalDue.Location = new System.Drawing.Point(94, 37);
            this.lblTotalDue.Name = "lblTotalDue";
            this.lblTotalDue.Size = new System.Drawing.Size(16, 16);
            this.lblTotalDue.TabIndex = 7;
            this.lblTotalDue.Text = "0";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.lblTotalCost.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblTotalCost.Location = new System.Drawing.Point(304, 37);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(16, 16);
            this.lblTotalCost.TabIndex = 7;
            this.lblTotalCost.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lblCollectedVat);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblPaidVat);
            this.groupBox2.Controls.Add(this.lblDueVat);
            this.groupBox2.Location = new System.Drawing.Point(434, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 59);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "VAT";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(208, 28);
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
            this.lblDueVat.AutoSize = true;
            this.lblDueVat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.lblDueVat.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueVat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblDueVat.Location = new System.Drawing.Point(285, 28);
            this.lblDueVat.Name = "lblDueVat";
            this.lblDueVat.Size = new System.Drawing.Size(16, 16);
            this.lblDueVat.TabIndex = 5;
            this.lblDueVat.Text = "0";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(794, 336);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBoxInvoiceDetails
            // 
            this.groupBoxInvoiceDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInvoiceDetails.Controls.Add(this.label11);
            this.groupBoxInvoiceDetails.Controls.Add(this.label7);
            this.groupBoxInvoiceDetails.Controls.Add(this.lblPurchasedDate);
            this.groupBoxInvoiceDetails.Controls.Add(this.label10);
            this.groupBoxInvoiceDetails.Controls.Add(this.label5);
            this.groupBoxInvoiceDetails.Controls.Add(this.lblDue);
            this.groupBoxInvoiceDetails.Controls.Add(this.lblCustomerMobile);
            this.groupBoxInvoiceDetails.Controls.Add(this.label8);
            this.groupBoxInvoiceDetails.Controls.Add(this.lblCustomerName);
            this.groupBoxInvoiceDetails.Controls.Add(this.lblPaid);
            this.groupBoxInvoiceDetails.Controls.Add(this.lblInvoiceId);
            this.groupBoxInvoiceDetails.Controls.Add(this.lblInvoiceNumber);
            this.groupBoxInvoiceDetails.Controls.Add(this.dataGridView2);
            this.groupBoxInvoiceDetails.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInvoiceDetails.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBoxInvoiceDetails.Location = new System.Drawing.Point(832, 197);
            this.groupBoxInvoiceDetails.Name = "groupBoxInvoiceDetails";
            this.groupBoxInvoiceDetails.Size = new System.Drawing.Size(428, 425);
            this.groupBoxInvoiceDetails.TabIndex = 15;
            this.groupBoxInvoiceDetails.TabStop = false;
            this.groupBoxInvoiceDetails.Text = "Invoice Details";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(253, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 16);
            this.label11.TabIndex = 9;
            this.label11.Text = "Purchased Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(6, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Customer\'s Mobile No";
            // 
            // lblPurchasedDate
            // 
            this.lblPurchasedDate.AutoSize = true;
            this.lblPurchasedDate.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchasedDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPurchasedDate.Location = new System.Drawing.Point(355, 27);
            this.lblPurchasedDate.Name = "lblPurchasedDate";
            this.lblPurchasedDate.Size = new System.Drawing.Size(15, 16);
            this.lblPurchasedDate.TabIndex = 10;
            this.lblPurchasedDate.Text = "#";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(253, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Due";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Customer\'s Name";
            // 
            // lblDue
            // 
            this.lblDue.AutoSize = true;
            this.lblDue.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDue.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDue.Location = new System.Drawing.Point(302, 72);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(15, 16);
            this.lblDue.TabIndex = 10;
            this.lblDue.Text = "#";
            // 
            // lblCustomerMobile
            // 
            this.lblCustomerMobile.AutoSize = true;
            this.lblCustomerMobile.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerMobile.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCustomerMobile.Location = new System.Drawing.Point(139, 73);
            this.lblCustomerMobile.Name = "lblCustomerMobile";
            this.lblCustomerMobile.Size = new System.Drawing.Size(15, 16);
            this.lblCustomerMobile.TabIndex = 10;
            this.lblCustomerMobile.Text = "#";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(253, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Paid";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCustomerName.Location = new System.Drawing.Point(119, 51);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(15, 16);
            this.lblCustomerName.TabIndex = 10;
            this.lblCustomerName.Text = "#";
            // 
            // lblPaid
            // 
            this.lblPaid.AutoSize = true;
            this.lblPaid.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaid.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPaid.Location = new System.Drawing.Point(302, 49);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(15, 16);
            this.lblPaid.TabIndex = 10;
            this.lblPaid.Text = "#";
            // 
            // lblInvoiceId
            // 
            this.lblInvoiceId.AutoSize = true;
            this.lblInvoiceId.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceId.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInvoiceId.Location = new System.Drawing.Point(6, 28);
            this.lblInvoiceId.Name = "lblInvoiceId";
            this.lblInvoiceId.Size = new System.Drawing.Size(59, 16);
            this.lblInvoiceId.TabIndex = 9;
            this.lblInvoiceId.Text = "Invoice Id";
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNumber.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(73, 28);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(15, 16);
            this.lblInvoiceNumber.TabIndex = 10;
            this.lblInvoiceNumber.Text = "#";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(9, 104);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(413, 315);
            this.dataGridView2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Righteous", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(394, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxforIndividual
            // 
            this.checkBoxforIndividual.AutoSize = true;
            this.checkBoxforIndividual.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxforIndividual.Location = new System.Drawing.Point(28, 108);
            this.checkBoxforIndividual.Name = "checkBoxforIndividual";
            this.checkBoxforIndividual.Size = new System.Drawing.Size(177, 20);
            this.checkBoxforIndividual.TabIndex = 14;
            this.checkBoxforIndividual.Text = "Individual Customer Search";
            this.checkBoxforIndividual.UseVisualStyleBackColor = true;
            this.checkBoxforIndividual.CheckedChanged += new System.EventHandler(this.checkBoxforIndividual_CheckedChanged);
            // 
            // grpBoxCustomerMobile
            // 
            this.grpBoxCustomerMobile.Controls.Add(this.txtMobileNo);
            this.grpBoxCustomerMobile.Enabled = false;
            this.grpBoxCustomerMobile.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxCustomerMobile.Location = new System.Drawing.Point(28, 127);
            this.grpBoxCustomerMobile.Name = "grpBoxCustomerMobile";
            this.grpBoxCustomerMobile.Size = new System.Drawing.Size(166, 46);
            this.grpBoxCustomerMobile.TabIndex = 13;
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
            this.grpBoxShopAllSalesDetails.Location = new System.Drawing.Point(28, 23);
            this.grpBoxShopAllSalesDetails.Name = "grpBoxShopAllSalesDetails";
            this.grpBoxShopAllSalesDetails.Size = new System.Drawing.Size(253, 67);
            this.grpBoxShopAllSalesDetails.TabIndex = 11;
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
            "Todays sales ",
            "Last 2 days sales",
            "Last 7 days sales",
            "Last 2 weeks sales ",
            "Last 30 days sales"});
            this.cmbSelectSearch.Location = new System.Drawing.Point(19, 23);
            this.cmbSelectSearch.MaxDropDownItems = 20;
            this.cmbSelectSearch.Name = "cmbSelectSearch";
            this.cmbSelectSearch.Size = new System.Drawing.Size(217, 24);
            this.cmbSelectSearch.TabIndex = 0;
            this.cmbSelectSearch.SelectedIndexChanged += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxSearchByDate
            // 
            this.groupBoxSearchByDate.Controls.Add(this.dateTimePicker2);
            this.groupBoxSearchByDate.Controls.Add(this.dateTimePicker1);
            this.groupBoxSearchByDate.Controls.Add(this.label3);
            this.groupBoxSearchByDate.Controls.Add(this.label2);
            this.groupBoxSearchByDate.Enabled = false;
            this.groupBoxSearchByDate.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSearchByDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBoxSearchByDate.Location = new System.Drawing.Point(299, 23);
            this.groupBoxSearchByDate.Name = "groupBoxSearchByDate";
            this.groupBoxSearchByDate.Size = new System.Drawing.Size(507, 67);
            this.groupBoxSearchByDate.TabIndex = 2;
            this.groupBoxSearchByDate.TabStop = false;
            this.groupBoxSearchByDate.Text = "Search by Date";
            // 
            // dateTimePicker2
            // 
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
            // SalesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1083, 656);
            this.Controls.Add(this.groupBoxSalesDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalesDetails";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "SalesDetails";
            this.groupBoxSalesDetails.ResumeLayout(false);
            this.groupBoxSalesDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSale)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxInvoiceDetails.ResumeLayout(false);
            this.groupBoxInvoiceDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.grpBoxCustomerMobile.ResumeLayout(false);
            this.grpBoxCustomerMobile.PerformLayout();
            this.grpBoxShopAllSalesDetails.ResumeLayout(false);
            this.groupBoxSearchByDate.ResumeLayout(false);
            this.groupBoxSearchByDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSalesDetails;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSelectSearch;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.GroupBox groupBoxSearchByDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTotalSale;
        private System.Windows.Forms.Label lblTotalDue;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.Label lblInvoiceId;
        private System.Windows.Forms.GroupBox grpBoxShopAllSalesDetails;
        private System.Windows.Forms.GroupBox grpBoxCustomerMobile;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.CheckBox checkBoxforIndividual;
        private System.Windows.Forms.GroupBox groupBoxInvoiceDetails;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPurchasedDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCustomerMobile;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblDue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxDue;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalProfit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblDueVat;
        private System.Windows.Forms.Label lblPaidVat;
        private System.Windows.Forms.Label lblCollectedVat;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSale;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}