
namespace Racssoft_Dokan.Pages
{
    partial class BalanceSheet1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dateTimePickerSpecificDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.btnOK = new FontAwesome.Sharp.IconButton();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.lblCreditLiability = new System.Windows.Forms.Label();
            this.lblDebitLiability = new System.Windows.Forms.Label();
            this.lblTotalDebit = new System.Windows.Forms.Label();
            this.lblTotalCredit = new System.Windows.Forms.Label();
            this.lblOpeningBalance = new System.Windows.Forms.Label();
            this.balanceSheetChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelGrossProfit = new System.Windows.Forms.Label();
            this.labelNetProfit = new System.Windows.Forms.Label();
            this.labelTotalSale = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTotalDue = new System.Windows.Forms.Label();
            this.labelProfit = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartSaleProfitDue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceSheetChart)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSaleProfitDue)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Racssoft_Dokan.Properties.Resources.Logo_mockup__1___1_ww;
            this.pictureBox1.Location = new System.Drawing.Point(340, 147);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 278);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // dateTimePickerSpecificDate
            // 
            this.dateTimePickerSpecificDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerSpecificDate.Enabled = false;
            this.dateTimePickerSpecificDate.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerSpecificDate.Location = new System.Drawing.Point(760, 33);
            this.dateTimePickerSpecificDate.Name = "dateTimePickerSpecificDate";
            this.dateTimePickerSpecificDate.Size = new System.Drawing.Size(195, 21);
            this.dateTimePickerSpecificDate.TabIndex = 18;
            this.dateTimePickerSpecificDate.ValueChanged += new System.EventHandler(this.dateTimePickerSpecificDate_ValueChanged);
            // 
            // cmbSearch
            // 
            this.cmbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Items.AddRange(new object[] {
            "Searching Categories",
            "Specific Date",
            "Date Wise"});
            this.cmbSearch.Location = new System.Drawing.Point(760, 10);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(195, 22);
            this.cmbSearch.TabIndex = 17;
            this.cmbSearch.SelectedIndexChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnOK.IconColor = System.Drawing.Color.Black;
            this.btnOK.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOK.Location = new System.Drawing.Point(701, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(40, 24);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentBalance.AutoSize = true;
            this.lblCurrentBalance.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblCurrentBalance.Location = new System.Drawing.Point(259, 19);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(149, 21);
            this.lblCurrentBalance.TabIndex = 9;
            this.lblCurrentBalance.Text = "Current Balance: 0";
            // 
            // lblCreditLiability
            // 
            this.lblCreditLiability.AutoSize = true;
            this.lblCreditLiability.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditLiability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblCreditLiability.Location = new System.Drawing.Point(18, 87);
            this.lblCreditLiability.Name = "lblCreditLiability";
            this.lblCreditLiability.Size = new System.Drawing.Size(139, 21);
            this.lblCreditLiability.TabIndex = 11;
            this.lblCreditLiability.Text = "Credit Liability: 0";
            // 
            // lblDebitLiability
            // 
            this.lblDebitLiability.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDebitLiability.AutoSize = true;
            this.lblDebitLiability.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebitLiability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblDebitLiability.Location = new System.Drawing.Point(259, 87);
            this.lblDebitLiability.Name = "lblDebitLiability";
            this.lblDebitLiability.Size = new System.Drawing.Size(132, 21);
            this.lblDebitLiability.TabIndex = 12;
            this.lblDebitLiability.Text = "Debit Liability: 0";
            // 
            // lblTotalDebit
            // 
            this.lblTotalDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDebit.AutoSize = true;
            this.lblTotalDebit.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDebit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblTotalDebit.Location = new System.Drawing.Point(259, 52);
            this.lblTotalDebit.Name = "lblTotalDebit";
            this.lblTotalDebit.Size = new System.Drawing.Size(110, 21);
            this.lblTotalDebit.TabIndex = 13;
            this.lblTotalDebit.Text = "Total Debit: 0";
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.AutoSize = true;
            this.lblTotalCredit.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCredit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblTotalCredit.Location = new System.Drawing.Point(18, 52);
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Size = new System.Drawing.Size(117, 21);
            this.lblTotalCredit.TabIndex = 14;
            this.lblTotalCredit.Text = "Total Credit: 0";
            // 
            // lblOpeningBalance
            // 
            this.lblOpeningBalance.AutoSize = true;
            this.lblOpeningBalance.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpeningBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.lblOpeningBalance.Location = new System.Drawing.Point(18, 19);
            this.lblOpeningBalance.Name = "lblOpeningBalance";
            this.lblOpeningBalance.Size = new System.Drawing.Size(154, 21);
            this.lblOpeningBalance.TabIndex = 15;
            this.lblOpeningBalance.Text = "Opening Balance: 0";
            // 
            // balanceSheetChart
            // 
            this.balanceSheetChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.balanceSheetChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.balanceSheetChart.Legends.Add(legend3);
            this.balanceSheetChart.Location = new System.Drawing.Point(480, 3);
            this.balanceSheetChart.Name = "balanceSheetChart";
            this.balanceSheetChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.balanceSheetChart.Size = new System.Drawing.Size(471, 239);
            this.balanceSheetChart.TabIndex = 19;
            this.balanceSheetChart.Text = "chart1";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.Location = new System.Drawing.Point(223, 11);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(198, 21);
            this.dateTimePickerFrom.TabIndex = 20;
            this.dateTimePickerFrom.Visible = false;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerTo.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Location = new System.Drawing.Point(486, 11);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(193, 21);
            this.dateTimePickerTo.TabIndex = 20;
            this.dateTimePickerTo.Visible = false;
            // 
            // labelFrom
            // 
            this.labelFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(188, 14);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(32, 14);
            this.labelFrom.TabIndex = 21;
            this.labelFrom.Text = "From";
            this.labelFrom.Visible = false;
            // 
            // labelTo
            // 
            this.labelTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(461, 14);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(19, 14);
            this.labelTo.TabIndex = 21;
            this.labelTo.Text = "To";
            this.labelTo.Visible = false;
            // 
            // labelGrossProfit
            // 
            this.labelGrossProfit.AutoSize = true;
            this.labelGrossProfit.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrossProfit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.labelGrossProfit.Location = new System.Drawing.Point(31, 178);
            this.labelGrossProfit.Name = "labelGrossProfit";
            this.labelGrossProfit.Size = new System.Drawing.Size(122, 21);
            this.labelGrossProfit.TabIndex = 10;
            this.labelGrossProfit.Text = "Gross Profit : 0";
            // 
            // labelNetProfit
            // 
            this.labelNetProfit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNetProfit.AutoSize = true;
            this.labelNetProfit.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNetProfit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.labelNetProfit.Location = new System.Drawing.Point(245, 178);
            this.labelNetProfit.Name = "labelNetProfit";
            this.labelNetProfit.Size = new System.Drawing.Size(105, 21);
            this.labelNetProfit.TabIndex = 10;
            this.labelNetProfit.Text = "Net Profit : 0";
            // 
            // labelTotalSale
            // 
            this.labelTotalSale.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTotalSale.AutoSize = true;
            this.labelTotalSale.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.labelTotalSale.Location = new System.Drawing.Point(128, 82);
            this.labelTotalSale.Name = "labelTotalSale";
            this.labelTotalSale.Size = new System.Drawing.Size(20, 21);
            this.labelTotalSale.TabIndex = 23;
            this.labelTotalSale.Text = "0";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.label6.Location = new System.Drawing.Point(37, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 21);
            this.label6.TabIndex = 23;
            this.label6.Text = "Total Sale :";
            // 
            // labelTotalDue
            // 
            this.labelTotalDue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTotalDue.AutoSize = true;
            this.labelTotalDue.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalDue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.labelTotalDue.Location = new System.Drawing.Point(128, 127);
            this.labelTotalDue.Name = "labelTotalDue";
            this.labelTotalDue.Size = new System.Drawing.Size(20, 21);
            this.labelTotalDue.TabIndex = 23;
            this.labelTotalDue.Text = "0";
            // 
            // labelProfit
            // 
            this.labelProfit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelProfit.AutoSize = true;
            this.labelProfit.BackColor = System.Drawing.Color.White;
            this.labelProfit.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProfit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.labelProfit.Location = new System.Drawing.Point(129, 171);
            this.labelProfit.Name = "labelProfit";
            this.labelProfit.Size = new System.Drawing.Size(20, 21);
            this.labelProfit.TabIndex = 23;
            this.labelProfit.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.label8.Location = new System.Drawing.Point(37, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 21);
            this.label8.TabIndex = 23;
            this.label8.Text = "Due             :";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.label7.Location = new System.Drawing.Point(38, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 21);
            this.label7.TabIndex = 23;
            this.label7.Text = "Profit         :";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.balanceSheetChart, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(954, 245);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblOpeningBalance);
            this.panel1.Controls.Add(this.labelNetProfit);
            this.panel1.Controls.Add(this.lblDebitLiability);
            this.panel1.Controls.Add(this.lblTotalDebit);
            this.panel1.Controls.Add(this.lblCreditLiability);
            this.panel1.Controls.Add(this.lblTotalCredit);
            this.panel1.Controls.Add(this.labelGrossProfit);
            this.panel1.Controls.Add(this.lblCurrentBalance);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 239);
            this.panel1.TabIndex = 16;
            // 
            // chartSaleProfitDue
            // 
            chartArea4.Name = "ChartArea1";
            this.chartSaleProfitDue.ChartAreas.Add(chartArea4);
            this.chartSaleProfitDue.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chartSaleProfitDue.Legends.Add(legend4);
            this.chartSaleProfitDue.Location = new System.Drawing.Point(3, 3);
            this.chartSaleProfitDue.Name = "chartSaleProfitDue";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSaleProfitDue.Series.Add(series2);
            this.chartSaleProfitDue.Size = new System.Drawing.Size(654, 283);
            this.chartSaleProfitDue.TabIndex = 17;
            this.chartSaleProfitDue.Text = "chart1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.28721F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.71279F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chartSaleProfitDue, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 304);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(954, 289);
            this.tableLayoutPanel2.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.labelTotalDue);
            this.panel2.Controls.Add(this.labelProfit);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.labelTotalSale);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(663, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 283);
            this.panel2.TabIndex = 0;
            // 
            // BalanceSheet1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(972, 607);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.dateTimePickerSpecificDate);
            this.Controls.Add(this.cmbSearch);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BalanceSheet1";
            this.Text = "BalanceSheet1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceSheetChart)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSaleProfitDue)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerSpecificDate;
        private System.Windows.Forms.ComboBox cmbSearch;
        private FontAwesome.Sharp.IconButton btnOK;
        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.Label lblCreditLiability;
        private System.Windows.Forms.Label lblDebitLiability;
        private System.Windows.Forms.Label lblTotalDebit;
        private System.Windows.Forms.Label lblTotalCredit;
        private System.Windows.Forms.Label lblOpeningBalance;
        private System.Windows.Forms.DataVisualization.Charting.Chart balanceSheetChart;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label labelGrossProfit;
        private System.Windows.Forms.Label labelNetProfit;
        private System.Windows.Forms.Label labelTotalSale;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTotalDue;
        private System.Windows.Forms.Label labelProfit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSaleProfitDue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
    }
}