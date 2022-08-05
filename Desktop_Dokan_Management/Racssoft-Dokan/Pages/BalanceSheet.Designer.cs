
namespace Racssoft_Dokan.Pages
{
    partial class BalanceSheet
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalCredit = new System.Windows.Forms.Label();
            this.lblCreditCashBank = new System.Windows.Forms.Label();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblOpeningBalanceCashBank = new System.Windows.Forms.Label();
            this.lblOpeningBalance = new System.Windows.Forms.Label();
            this.lblTotalDebit = new System.Windows.Forms.Label();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.lblCurrentBalanceCashBank = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.btnDetailOpening = new FontAwesome.Sharp.IconButton();
            this.btnRefresh = new FontAwesome.Sharp.IconButton();
            this.balanceSheetChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblLiability = new System.Windows.Forms.Label();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblDebitCashBank = new System.Windows.Forms.Label();
            this.btnOK = new FontAwesome.Sharp.IconButton();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePickerSpecificDate = new System.Windows.Forms.DateTimePicker();
            this.lblCreditLiability = new System.Windows.Forms.Label();
            this.lblDebitLiability = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.balanceSheetChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(746, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            this.label1.Visible = false;
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.AutoSize = true;
            this.lblTotalCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCredit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTotalCredit.Location = new System.Drawing.Point(12, 111);
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Size = new System.Drawing.Size(122, 20);
            this.lblTotalCredit.TabIndex = 0;
            this.lblTotalCredit.Text = "Total Credit: 0";
            // 
            // lblCreditCashBank
            // 
            this.lblCreditCashBank.AutoSize = true;
            this.lblCreditCashBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCreditCashBank.Location = new System.Drawing.Point(455, 485);
            this.lblCreditCashBank.Name = "lblCreditCashBank";
            this.lblCreditCashBank.Size = new System.Drawing.Size(86, 13);
            this.lblCreditCashBank.TabIndex = 0;
            this.lblCreditCashBank.Text = "Cash: 0, Bank: 0";
            this.lblCreditCashBank.Visible = false;
            // 
            // dpFrom
            // 
            this.dpFrom.Location = new System.Drawing.Point(782, 44);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(200, 20);
            this.dpFrom.TabIndex = 3;
            this.dpFrom.Visible = false;
            // 
            // lblOpeningBalanceCashBank
            // 
            this.lblOpeningBalanceCashBank.AutoSize = true;
            this.lblOpeningBalanceCashBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblOpeningBalanceCashBank.Location = new System.Drawing.Point(455, 452);
            this.lblOpeningBalanceCashBank.Name = "lblOpeningBalanceCashBank";
            this.lblOpeningBalanceCashBank.Size = new System.Drawing.Size(86, 13);
            this.lblOpeningBalanceCashBank.TabIndex = 0;
            this.lblOpeningBalanceCashBank.Text = "Cash: 0, Bank: 0";
            this.lblOpeningBalanceCashBank.Visible = false;
            // 
            // lblOpeningBalance
            // 
            this.lblOpeningBalance.AutoSize = true;
            this.lblOpeningBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpeningBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblOpeningBalance.Location = new System.Drawing.Point(14, 46);
            this.lblOpeningBalance.Name = "lblOpeningBalance";
            this.lblOpeningBalance.Size = new System.Drawing.Size(166, 20);
            this.lblOpeningBalance.TabIndex = 0;
            this.lblOpeningBalance.Text = "Opening Balance: 0";
            // 
            // lblTotalDebit
            // 
            this.lblTotalDebit.AutoSize = true;
            this.lblTotalDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDebit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTotalDebit.Location = new System.Drawing.Point(11, 178);
            this.lblTotalDebit.Name = "lblTotalDebit";
            this.lblTotalDebit.Size = new System.Drawing.Size(117, 20);
            this.lblTotalDebit.TabIndex = 0;
            this.lblTotalDebit.Text = "Total Debit: 0";
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.AutoSize = true;
            this.lblCurrentBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblCurrentBalance.Location = new System.Drawing.Point(12, 78);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(159, 20);
            this.lblCurrentBalance.TabIndex = 0;
            this.lblCurrentBalance.Text = "Current Balance: 0";
            // 
            // lblCurrentBalanceCashBank
            // 
            this.lblCurrentBalanceCashBank.AutoSize = true;
            this.lblCurrentBalanceCashBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCurrentBalanceCashBank.Location = new System.Drawing.Point(455, 465);
            this.lblCurrentBalanceCashBank.Name = "lblCurrentBalanceCashBank";
            this.lblCurrentBalanceCashBank.Size = new System.Drawing.Size(86, 13);
            this.lblCurrentBalanceCashBank.TabIndex = 0;
            this.lblCurrentBalanceCashBank.Text = "Cash: 0, Bank: 0";
            this.lblCurrentBalanceCashBank.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(746, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "To";
            this.label2.Visible = false;
            // 
            // dpTo
            // 
            this.dpTo.Location = new System.Drawing.Point(782, 76);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(200, 20);
            this.dpTo.TabIndex = 3;
            this.dpTo.Visible = false;
            // 
            // btnDetailOpening
            // 
            this.btnDetailOpening.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDetailOpening.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetailOpening.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetailOpening.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDetailOpening.IconColor = System.Drawing.Color.Black;
            this.btnDetailOpening.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDetailOpening.Location = new System.Drawing.Point(691, 158);
            this.btnDetailOpening.Name = "btnDetailOpening";
            this.btnDetailOpening.Size = new System.Drawing.Size(85, 30);
            this.btnDetailOpening.TabIndex = 2;
            this.btnDetailOpening.Text = "Details";
            this.btnDetailOpening.UseVisualStyleBackColor = true;
            this.btnDetailOpening.Click += new System.EventHandler(this.btnDetailOpening_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnRefresh.IconColor = System.Drawing.Color.Black;
            this.btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRefresh.Location = new System.Drawing.Point(691, 114);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(85, 33);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // balanceSheetChart
            // 
            chartArea1.Name = "ChartArea1";
            this.balanceSheetChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.balanceSheetChart.Legends.Add(legend1);
            this.balanceSheetChart.Location = new System.Drawing.Point(440, 201);
            this.balanceSheetChart.Name = "balanceSheetChart";
            this.balanceSheetChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.balanceSheetChart.Size = new System.Drawing.Size(576, 232);
            this.balanceSheetChart.TabIndex = 5;
            this.balanceSheetChart.Text = "chart1";
            // 
            // lblLiability
            // 
            this.lblLiability.AutoSize = true;
            this.lblLiability.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLiability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblLiability.Location = new System.Drawing.Point(14, 247);
            this.lblLiability.Name = "lblLiability";
            this.lblLiability.Size = new System.Drawing.Size(139, 20);
            this.lblLiability.TabIndex = 0;
            this.lblLiability.Text = "Total Liability : 0";
            this.lblLiability.Visible = false;
            // 
            // cmbSearch
            // 
            this.cmbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Items.AddRange(new object[] {
            "Specific Date",
            "Today",
            "This Month",
            "Last Month",
            "This Year",
            "Last Year",
            "Month Wise",
            "Date Wise"});
            this.cmbSearch.Location = new System.Drawing.Point(828, 5);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(200, 21);
            this.cmbSearch.TabIndex = 6;
            this.cmbSearch.SelectedIndexChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            // 
            // cmbMonth
            // 
            this.cmbMonth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"});
            this.cmbMonth.Location = new System.Drawing.Point(925, 45);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(91, 21);
            this.cmbMonth.TabIndex = 6;
            this.cmbMonth.Visible = false;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // cmbYear
            // 
            this.cmbYear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(828, 47);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(91, 21);
            this.cmbYear.TabIndex = 6;
            this.cmbYear.Visible = false;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // lblDebitCashBank
            // 
            this.lblDebitCashBank.AutoSize = true;
            this.lblDebitCashBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblDebitCashBank.Location = new System.Drawing.Point(455, 498);
            this.lblDebitCashBank.Name = "lblDebitCashBank";
            this.lblDebitCashBank.Size = new System.Drawing.Size(86, 13);
            this.lblDebitCashBank.TabIndex = 0;
            this.lblDebitCashBank.Text = "Cash: 0, Bank: 0";
            this.lblDebitCashBank.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnOK.IconColor = System.Drawing.Color.Black;
            this.btnOK.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOK.Location = new System.Drawing.Point(884, 123);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(98, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(12, 327);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(422, 185);
            this.chart2.TabIndex = 7;
            this.chart2.Text = "chart2";
            // 
            // dateTimePickerSpecificDate
            // 
            this.dateTimePickerSpecificDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerSpecificDate.Location = new System.Drawing.Point(828, 26);
            this.dateTimePickerSpecificDate.Name = "dateTimePickerSpecificDate";
            this.dateTimePickerSpecificDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSpecificDate.TabIndex = 8;
            this.dateTimePickerSpecificDate.Visible = false;
            this.dateTimePickerSpecificDate.ValueChanged += new System.EventHandler(this.dateTimePickerSpecificDate_ValueChanged);
            // 
            // lblCreditLiability
            // 
            this.lblCreditLiability.AutoSize = true;
            this.lblCreditLiability.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditLiability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblCreditLiability.Location = new System.Drawing.Point(11, 147);
            this.lblCreditLiability.Name = "lblCreditLiability";
            this.lblCreditLiability.Size = new System.Drawing.Size(142, 20);
            this.lblCreditLiability.TabIndex = 0;
            this.lblCreditLiability.Text = "Credit Liability: 0";
            // 
            // lblDebitLiability
            // 
            this.lblDebitLiability.AutoSize = true;
            this.lblDebitLiability.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebitLiability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblDebitLiability.Location = new System.Drawing.Point(12, 214);
            this.lblDebitLiability.Name = "lblDebitLiability";
            this.lblDebitLiability.Size = new System.Drawing.Size(137, 20);
            this.lblDebitLiability.TabIndex = 0;
            this.lblDebitLiability.Text = "Debit Liability: 0";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(13, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(72, 16);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message";
            this.lblMessage.Visible = false;
            // 
            // BalanceSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1036, 524);
            this.Controls.Add(this.dateTimePickerSpecificDate);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.cmbSearch);
            this.Controls.Add(this.balanceSheetChart);
            this.Controls.Add(this.dpTo);
            this.Controls.Add(this.dpFrom);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDetailOpening);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblCurrentBalance);
            this.Controls.Add(this.lblCurrentBalanceCashBank);
            this.Controls.Add(this.lblDebitCashBank);
            this.Controls.Add(this.lblCreditCashBank);
            this.Controls.Add(this.lblLiability);
            this.Controls.Add(this.lblCreditLiability);
            this.Controls.Add(this.lblDebitLiability);
            this.Controls.Add(this.lblTotalDebit);
            this.Controls.Add(this.lblTotalCredit);
            this.Controls.Add(this.lblOpeningBalance);
            this.Controls.Add(this.lblOpeningBalanceCashBank);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BalanceSheet";
            this.Text = "BalanceSheet";
            this.Load += new System.EventHandler(this.BalanceSheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.balanceSheetChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalCredit;
        private System.Windows.Forms.Label lblCreditCashBank;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.Label lblOpeningBalanceCashBank;
        private System.Windows.Forms.Label lblOpeningBalance;
        private System.Windows.Forms.Label lblTotalDebit;
        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.Label lblCurrentBalanceCashBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpTo;
        private FontAwesome.Sharp.IconButton btnDetailOpening;
        private System.Windows.Forms.DataVisualization.Charting.Chart balanceSheetChart;
        private System.Windows.Forms.Label lblLiability;
        private System.Windows.Forms.ComboBox cmbSearch;
		private System.Windows.Forms.ComboBox cmbMonth;
		private System.Windows.Forms.ComboBox cmbYear;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblDebitCashBank;
		private FontAwesome.Sharp.IconButton btnOK;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DateTimePicker dateTimePickerSpecificDate;
        private System.Windows.Forms.Label lblCreditLiability;
        private System.Windows.Forms.Label lblDebitLiability;
        private System.Windows.Forms.Label lblMessage;
    }
}