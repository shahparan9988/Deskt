using Model;
using Models;
using Racssoft_Dokan.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using System.Xml.Schema;

namespace Racssoft_Dokan.Pages
{
    public partial class BalanceSheet : Common
    {
        public BalanceSheet()
        {
            InitializeComponent();
        }
        DataTable dtCredit, dtDebit;
        private void Details()
		{
            (new BalanceSheetDetail(dtCredit, dtDebit)).ShowDialog();
		}
        bool firstTime = true;
        void graph(double value, bool isProfit)
        {
            string text = "Profit";
            Color color = Color.Green;
            if (!isProfit)
            {
                text = "Loss";
                color = Color.Red;
            }
            if (firstTime)
            {
                balanceSheetChart.Series["sale"].Points.AddXY(text, value);
                firstTime = false;
            }
            else
            {
                balanceSheetChart.Series["sale"].Points.RemoveAt(0);
                balanceSheetChart.Series["sale"].Points.AddXY(text, value);
            }
            
            balanceSheetChart.Series["sale"].Points[0].Color = color;
        }
        private void BalanceSheet_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
            
            cmbSearch.SelectedIndex = 0;
        }

        void chartGenerator(double openingBalance, double currentBalance, double totalCredit, double totalCreditBefore, double creditLiability, double creditLiabilityBefore, double totalDebit, double totalDebitBefore, double debitLiability, double debitLiabilityBefore)
        {
            // chartArea
            balanceSheetChart.Series.Clear();
            ChartArea chartArea = new ChartArea();
            chartArea = balanceSheetChart.ChartAreas[0];
            //balanceSheetChart.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;//x axis
                                                                              //chartAccounts.ChartAreas[0].AxisY.LabelStyle.Format = "P";
                                                                              //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 13);
            balanceSheetChart.ChartAreas[0].AxisX.Interval = 1;
            //balanceSheetChart.ChartAreas[0].AxisX.ScrollBar = true;
            //balanceSheetChart.ChartAreas[0].Axes[1].MajorGrid.Enabled = true;//y axis

            //Series
            Series series1 = new Series();
          
            balanceSheetChart.Series.Add(series1);
           
            //Series style
            //series1.ChartType = SeriesChartType.Doughnut;
            series1.ChartType = SeriesChartType.Doughnut;
            
            //series1// type
            series1.BorderWidth = 1;
           
            //series1.Color = Color.Green;
            series1.Name = "Amount";
           
            //series1.CustomProperties.
           

            //Series series2 = new Series();
            //chartAccounts.Series.Add(series2);
            ////Series style
            //series2.ChartType = SeriesChartType.Spline;  // type
            //series2.BorderWidth = 2;
            //series2.Color = Color.Blue;
            ////series1.Name = "Balance";

            //DataTable dt = (DataTable)Select(sql).Data;
            //chartAccounts.DataBindTable(dt.DefaultView, "Balance");

            
                string opening = "opening Bal.";
                
                int ix = series1.Points.AddXY(opening, openingBalance);
            
            series1.Points.AddXY(opening, openingBalance);
                string current = "Closing Bal.";
               
                series1.Points.AddXY(current, currentBalance);
                
                string creditBalance = "Total Credit";
                series1.Points.AddXY(creditBalance, (totalCredit-totalCreditBefore));
               
                string creditLiaBalance = "Credit Liability";
               
                series1.Points.AddXY(creditLiaBalance, (creditLiability-creditLiabilityBefore));
                

                string debitBalance = "Total Debit";
                series1.Points.AddXY(debitBalance, (totalDebit-totalDebitBefore));
       

                string debitLiaBalance = "Debit Liability";
               
                series1.Points.AddXY(debitLiaBalance, (debitLiability-debitLiabilityBefore));
            

                //series2.Points.AddXY(name, amount);
          
        }

        private void openingBalanceCalculation((double, double, double, double) openingBalance)
        {
            double totalCredit = openingBalance.Item1 + openingBalance.Item2;
            double totalDebit = openingBalance.Item3 + openingBalance.Item4;
            lblOpeningBalance.Text = "Opening Balance: " + (totalCredit - totalDebit);
            lblOpeningBalanceCashBank.Text = String.Format("Cash: {0}, Bank: {1}", (openingBalance.Item1 - openingBalance.Item3), (openingBalance.Item2 - openingBalance.Item4));

            bool isProfit = totalCredit > totalDebit;
            //if (isProfit) graph(totalCredit, isProfit); else graph(totalDebit, isProfit);
        }
        private void currentBalanceCalculation((double, double, double, double) currentBalance)
        {
            //LoadCredit()
            double totalCredit = currentBalance.Item1 + currentBalance.Item2;
            double totalDebit = currentBalance.Item3 + currentBalance.Item4;
            lblCurrentBalance.Text = "Current Balance: " + (totalCredit - totalDebit).ToString();
            lblCurrentBalanceCashBank.Text = String.Format("Cash: {0}, Bank: {1}", (currentBalance.Item1 - currentBalance.Item3), (currentBalance.Item2 - currentBalance.Item4));
        }

        void LoadCredit(DateTime dFrom, DateTime dTo)
        {
            string sql = @"SELECT PaidCash as Cash, PaidBank as Bank, DueAmmount as [Due], PaidDate as [Paid Date] FROM Bill_Collection 
                    WHERE PaidDate Between #" + dFrom.Date.ToShortDateString() + "# AND #" + dTo.Date.ToShortDateString() + "# ";
            DataTable dt = (DataTable)Select(sql).Data;
            //dgCredit.DataSource = dt;
            dtCredit = dt;
            object totalCash = dt?.Compute("Sum(Cash)", "");
            object totalBank = dt?.Compute("Sum(Bank)", "");
            totalCash = totalCash is DBNull ? 0 : totalCash;
            totalBank = totalBank is DBNull ? 0 : totalBank;
            double total = Convert.ToDouble(totalCash) + Convert.ToDouble(totalBank);
            lblTotalCredit.Text = "Total Credit: " + total;
            lblCreditCashBank.Text = String.Format("Cash: {0}, Bank: {1}", totalCash, totalBank);
        }

        void LoadDebit(DateTime dFrom, DateTime dTo)
        {
            string sql = @"SELECT WhichDateTime as [Collection Date], Cash, Bank FROM Daily_Expenditure_Debit 
                        WHERE WhichDateTime Between #" + dFrom.Date + "# AND #" + dTo.Date + "#";
            DataTable dt = (DataTable)Select(sql).Data;
            //dgDebit.DataSource = dt;
            dtDebit = dt;
            object totalCash = dt?.Compute("Sum(Cash)", "");
            object totalBank = dt?.Compute("Sum(Bank)", "");
            totalCash = totalCash is DBNull ? 0 : totalCash;
            totalBank = totalBank is DBNull ? 0 : totalBank;
            double total = Convert.ToDouble(totalCash) + Convert.ToDouble(totalBank);
            lblTotalDebit.Text = "Total Debit: " + total;
            lblDebitCashBank.Text = String.Format("Cash: {0}, Bank: {1}", totalCash, totalBank);
        }
        (double, double, double, double) Balance(DateTime date)
        {
            string sql = @"SELECT PaidCash as [Cash], PaidBank as [Bank], DueAmmount as [Due], PaidDate as [Paid Date] FROM Bill_Collection WHERE PaidDate = #" + date.Date.ToString("MM/dd/yyyy") + "#";
            DataTable dt = (DataTable)Select(sql).Data;

            object totoalCreditCash = dt?.Compute("Sum(Cash)", "");
            totoalCreditCash = totoalCreditCash is DBNull ? 0 : totoalCreditCash;
            
            object totoalCreditBank = dt?.Compute("Sum(Bank)", "");
            totoalCreditBank = totoalCreditBank is DBNull ? 0 : totoalCreditBank;

            sql = @"SELECT WhichDateTime as [Collection Date], Cash, Bank FROM Daily_Expenditure_Debit WHERE WhichDateTime = #" + date.Date.ToString("MM/dd/yyyy") + "#";
            dt = (DataTable)Select(sql).Data;

            object totoalDebitCash = dt?.Compute("Sum(Cash)", "");
            totoalDebitCash = totoalDebitCash is DBNull ? 0 : totoalDebitCash; 
            
            object totoalDebitBank = dt?.Compute("Sum(Bank)", "");
            totoalDebitBank = totoalDebitBank is DBNull ? 0 : totoalDebitBank;
            return (Convert.ToDouble(totoalCreditCash), Convert.ToDouble(totoalCreditBank), Convert.ToDouble(totoalDebitCash), Convert.ToDouble(totoalDebitBank));
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            LoadCredit(dateTime, dateTime);
            LoadDebit(dateTime, dateTime);

            var openingBalance = Balance(dpFrom.Value.Date.AddDays(-1));
            openingBalanceCalculation(openingBalance);
            var currentBalance = Balance(dpTo.Value);
            currentBalanceCalculation(currentBalance);
        }
        private void dateWiseComponentShowHide(bool flag)
		{
            dpFrom.Visible = flag;
            dpTo.Visible = flag;
            btnOK.Visible = flag;
        }
        private void monthWiseComponentShowHide(bool flag)
		{
            cmbYear.Visible = flag;
            cmbMonth.Visible = flag;
        }
        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateWiseComponentShowHide(false);
            monthWiseComponentShowHide(false);
			//dgCredit.DataSource = new DataTable();
			//dgDebit.DataSource = new DataTable();  

			dtCredit = new DataTable();
			dtDebit = new DataTable();

			string searchText = cmbSearch.Text;

            if(searchText == "Specific Date")
            {
                dateTimePickerSpecificDate.Visible = true;
                
            }
            if(searchText == "Today")
			{
                //graph();
                DateTime dateTime = DateTime.Now.Date;
                LoadCredit(dateTime, dateTime);
                LoadDebit(dateTime, dateTime);

                var openingBalance = Balance(dateTime.AddDays(-1));
                openingBalanceCalculation(openingBalance);
                var currentBalance = Balance(dpTo.Value);
                currentBalanceCalculation(currentBalance);
            }
            if (searchText == "Month Wise")
            {
                for (int y = 2021; y <= DateTime.Now.Year; y++)
                {
                    cmbYear.Items.Add(y);
                }
                monthWiseComponentShowHide(true);
            }
            else if (searchText == "Date Wise")
            {
                dateWiseComponentShowHide(true);
            }
            else if (searchText == "This Month")
            {
                DateTime dateTime = DateTime.Now.Date;
                var firstDayOfMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
                //graph();
                LoadCredit(firstDayOfMonth, dateTime);
                LoadDebit(firstDayOfMonth, dateTime);

                var openingBalance = Balance(firstDayOfMonth.AddDays(-1));
                openingBalanceCalculation(openingBalance);
            }
            else if (searchText == "Last Month")
            {
                DateTime dateTime = DateTime.Now.Date;
                var firstDayOfLastMonth = new DateTime(dateTime.Year, dateTime.AddMonths(-1).Month, 1);
                var lastDayOfLastMonth = firstDayOfLastMonth.AddMonths(1).AddDays(-1);
                //graph();
                LoadCredit(firstDayOfLastMonth, lastDayOfLastMonth);
                LoadDebit(firstDayOfLastMonth, lastDayOfLastMonth);


                var openingBalance = Balance(firstDayOfLastMonth.AddDays(-1));
                openingBalanceCalculation(openingBalance);
            }
            else if (searchText == "This Year")
            {
                DateTime dateTime = DateTime.Now.Date;
                var firstDayOfYear = new DateTime(dateTime.Year, 1, 1);
                
                //graph();
                LoadCredit(firstDayOfYear, dateTime);
                LoadDebit(firstDayOfYear, dateTime);


                var openingBalance = Balance(firstDayOfYear.AddDays(-1));
                openingBalanceCalculation(openingBalance);
            }
            else if (searchText == "Last Year")
            {
                //graph();
                DateTime dateTime = DateTime.Now.Date;
                var firstDayOfLastYear = new DateTime(dateTime.AddYears(-1).Year, 1, 1);
                var lastDayOfLstYear = new DateTime(dateTime.AddYears(-1).Year, 12, 31);
                LoadCredit(firstDayOfLastYear, lastDayOfLstYear);
                LoadDebit(firstDayOfLastYear, lastDayOfLstYear);

                var openingBalance = Balance(firstDayOfLastYear.AddDays(-1));
                openingBalanceCalculation(openingBalance);
            }
        }

		private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (!string.IsNullOrEmpty(cmbYear.Text) && !string.IsNullOrEmpty(cmbMonth.Text)) {
                //graph();
                (double, double, double, double) balance = BalanceMonthWise(cmbMonth.SelectedIndex+1, Convert.ToInt32(cmbYear.Text));
                double totalDebit = balance.Item3 + balance.Item4;
                lblTotalDebit.Text = "Total Debit: " + totalDebit;

                double totalCredit = balance.Item1 + balance.Item2;
                lblTotalCredit.Text = "Total Credit: " + totalCredit;
                lblCreditCashBank.Text = String.Format("Cash: {0}, Bank: {1}", balance.Item1, balance.Item2);
                lblDebitCashBank.Text = String.Format("Cash: {0}, Bank: {1}", balance.Item3, balance.Item4);
            }
        }

        (double, double, double, double) BalanceMonthWise(int month, int year)
        {
            string sql = @"SELECT PaidCash as [Cash], PaidBank as [Bank], DueAmmount as [Due], PaidDate as [Paid Date] FROM Bill_Collection WHERE Month(PaidDate) = " + month + " and Year(PaidDate) = " + year;
            DataTable dt = (DataTable)Select(sql).Data;

            //dgCredit.DataSource = dt;
            dtCredit = dt;

            object totoalCreditCash = dt?.Compute("Sum(Cash)", "");
            totoalCreditCash = totoalCreditCash is DBNull ? 0 : totoalCreditCash;

            object totoalCreditBank = dt?.Compute("Sum(Bank)", "");
            totoalCreditBank = totoalCreditBank is DBNull ? 0 : totoalCreditBank;

            sql = @"SELECT WhichDateTime as [Collection Date], Cash, Bank FROM Daily_Expenditure_Debit WHERE Month(WhichDateTime) = " + month + " and Year(WhichDateTime) = " + year;
            dt = (DataTable)Select(sql).Data;

            dtDebit = dt;

            object totoalDebitCash = dt?.Compute("Sum(Cash)", "");
            totoalDebitCash = totoalDebitCash is DBNull ? 0 : totoalDebitCash;

            object totoalDebitBank = dt?.Compute("Sum(Bank)", "");
            totoalDebitBank = totoalDebitBank is DBNull ? 0 : totoalDebitBank;
            return (Convert.ToDouble(totoalCreditCash), Convert.ToDouble(totoalCreditBank), Convert.ToDouble(totoalDebitCash), Convert.ToDouble(totoalDebitBank));
        }

        private void btnDetailOpening_Click(object sender, EventArgs e)
        {
            Details();
            //bool flag = false;

            //if (btnDetailOpening.Text == "Details")
            //{
            //    flag = true;
            //}
            //btnDetailOpening.Text = btnDetailOpening.Text == "Details" ? "Hide" : "Details";

            //lblOpeningBalanceCashBank.Visible = flag;


            //string sql = @"SELECT PaidCash as [Cash], PaidBank as [Bank], DueAmmount as [Due], PaidDate as [Paid Date] FROM Bill_Collection WHERE PaidDate = #" + date.Date.ToString("MM/dd/yyyy") + "#";
            //DataTable dt = (DataTable)Select(sql).Data;
            //dgDetails.DataSource
        }

        private void dateTimePickerSpecificDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(dateTimePickerSpecificDate.Text);
            string sql = @"SELECT * FROM BalanceSheet WHERE UpdatedDate BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(date.AddDays(1).ToString("MM/dd/yyyy")) + "#";
            
            DataTable dt = (DataTable)Select(sql).Data;
            
            if (dt.Rows.Count > 0)
            {
                long idBefore = Convert.ToInt64(dt.Rows[0]["ID"]);
                string sqlBefore = @"SELECT * FROM BalanceSheet WHERE ID = " + (idBefore - 1) + "";
                DataTable dtBefore = (DataTable)Select(sqlBefore).Data;
                double openingBalance = Convert.ToDouble(dt.Rows[0]["OpeningBalance"]);
                double currentBalance = Convert.ToDouble(dt.Rows[0]["OpeningBalance"]);
                lblOpeningBalance.Text = "Opening Balance: " + dt.Rows[0]["OpeningBalance"] + "";
                lblCurrentBalance.Text = "Closing Balance: " + dt.Rows[0]["CurrentBalance"] + "";
                double totalCredit = Convert.ToDouble(dt.Rows[0]["TotalCredit"]);
                double totalCreditBefore = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["TotalCredit"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["TotalCredit"]) : 0;
                //(dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["CreditLiability"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["CreditLiability"]) : 0;
                lblTotalCredit.Text = "TotalCredit: " + (totalCredit - totalCreditBefore) + "";
                double creditLiability = Convert.ToDouble(dt.Rows[0]["CreditLiability"]);
                double creditLiabilityBefore = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["CreditLiability"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["CreditLiability"]) : 0;
                lblCreditLiability.Text = "Credit Liability: " + (creditLiability - creditLiabilityBefore) + "";
                double totalDebit = Convert.ToDouble(dt.Rows[0]["TotalDebit"]);
                double totalDebitBefore = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["TotalDebit"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["TotalDebit"]) : 0;
                lblTotalDebit.Text = "Total Debit: " + (totalDebit - totalDebitBefore) + "";
                double debitLiability = Convert.ToDouble(dt.Rows[0]["DebitLiability"]);
                double debitLiabilityBefore = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["DebitLiability"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["DebitLiability"]) : 0;
                lblDebitLiability.Text = "Debit Liability: " + (debitLiability - debitLiabilityBefore) + "";

                chartGenerator(openingBalance, currentBalance, totalCredit, totalCreditBefore, creditLiability, creditLiabilityBefore, totalDebit, totalDebitBefore, debitLiability, debitLiabilityBefore);


            }
        }

        private void btnOK_Click(object sender, EventArgs e)
		{
            if (dpFrom.Value > dpTo.Value) { lblMessage.Text = "Date range not valid!"; lblMessage.Visible = true; return; }
            LoadCredit(dpFrom.Value, dpTo.Value);
            LoadDebit(dpFrom.Value, dpTo.Value);

            var openingBalance = Balance(dpFrom.Value.Date.AddDays(-1));
            openingBalanceCalculation(openingBalance);
            var currentBalance = Balance(dpTo.Value);
            currentBalanceCalculation(currentBalance);
        }
	}
}
