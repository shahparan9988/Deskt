using Model;
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

namespace Racssoft_Dokan.Pages
{
	public partial class BalanceSheet1 : Common
	{
		//DateTime dateTimeFrom = DateTime.Parse(DateTime.Now.AddDays(-7).ToString());
		//DateTime dateTimeTo = DateTime.Parse(DateTime.Now.ToString());

		DateTime dateTimeFrom;
		DateTime dateTimeTo;
		public BalanceSheet1()
		{
			InitializeComponent();
			cmbSearch.SelectedIndex = 0;
			dateTimeFrom = DateTime.Parse(DateTime.Now.AddDays(-7).ToString());
			dateTimeTo = DateTime.Parse(DateTime.Now.ToString());
			//chartGenerator(dateTimeFrom, dateTimeTo);
			//chartGenerateSaleprofitDue1(dateTimeFrom, dateTimeTo);
			chartGeneratorFormLoading(dateTimeFrom, dateTimeTo);
			GrossProfitNetProfitCalculation(dateTimeTo, dateTimeTo.AddDays(1));
		}

		void Initial()
		{
			dateTimeFrom = DateTime.Parse(dateTimePickerFrom.Text.ToString());
			dateTimeTo = DateTime.Parse(dateTimePickerTo.Text.ToString());
			string sqlBalanceSheet = @"SELECT * FROM BalanceSheet WHERE UpdatedDate
            BETWEEN #" + DateTime.Parse(dateTimeFrom.ToString("MM/dd/yyyy")) + "# " +
					"AND #" + DateTime.Parse(dateTimeTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";
			chartGenerator(dateTimeFrom, dateTimeTo);
			chartGeneratorSaleProfitDue(dateTimeFrom, dateTimeTo);
		}

		void BalanceSheetGeneratorForMultipleDates(DateTime dateTimeFrom, DateTime dateTimeTo)
		{
			string sql = @"SELECT * FROM BalanceSheet WHERE UpdatedDate BETWEEN #" + DateTime.Parse(dateTimeFrom.ToString("MM/dd/yyyy")) + "# " +
					"AND #" + DateTime.Parse(dateTimeTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";

			DataTable dt = (DataTable)Select(sql).Data;
			int nOfRowsOfDt = dt.Rows.Count;

			if (nOfRowsOfDt > 0)
			{
				long idBefore = Convert.ToInt64(dt.Rows[0]["ID"]);
				string sqlBefore = @"SELECT * FROM BalanceSheet WHERE ID = " + (idBefore - 1) + "";
				DataTable dtBefore = (DataTable)Select(sqlBefore).Data;
				double openingBalance = Convert.ToDouble(dt.Rows[0]["OpeningBalance"]);
				//double openingBalanceFirst = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["OpeningBalance"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["OpeningBalance"]) : 0;
				double currentBalance = Convert.ToDouble(dt.Rows[nOfRowsOfDt - 1]["CurrentBalance"]);
				//double currentBalanceFirst = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["CurrentBalance"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["CurrentBalance"]) : 0;
				lblOpeningBalance.Text = "Opening Balance: " + openingBalance + "";
				lblCurrentBalance.Text = "Closing Balance: " + currentBalance + "";
				double totalCredit = Convert.ToDouble(dt.Rows[nOfRowsOfDt - 1]["TotalCredit"]);
				double totalCreditBefore = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["TotalCredit"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["TotalCredit"]) : 0;
				//(dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["CreditLiability"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["CreditLiability"]) : 0;
				lblTotalCredit.Text = "TotalCredit: " + (totalCredit - totalCreditBefore) + "";
				double creditLiability = Convert.ToDouble(dt.Rows[nOfRowsOfDt - 1]["CreditLiability"]);
				double creditLiabilityBefore = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["CreditLiability"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["CreditLiability"]) : 0;
				lblCreditLiability.Text = "Credit Liability: " + (creditLiability - creditLiabilityBefore) + "";
				double totalDebit = Convert.ToDouble(dt.Rows[nOfRowsOfDt - 1]["TotalDebit"]);
				double totalDebitBefore = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["TotalDebit"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["TotalDebit"]) : 0;
				lblTotalDebit.Text = "Total Debit: " + (totalDebit - totalDebitBefore) + "";
				double debitLiability = Convert.ToDouble(dt.Rows[nOfRowsOfDt - 1]["DebitLiability"]);
				double debitLiabilityBefore = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["DebitLiability"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["DebitLiability"]) : 0;
				lblDebitLiability.Text = "Debit Liability: " + (debitLiability - debitLiabilityBefore) + "";

				//chartGeneratorDoughnut(openingBalance, currentBalance, totalCredit, totalCreditBefore, creditLiability, creditLiabilityBefore, totalDebit, totalDebitBefore, debitLiability, debitLiabilityBefore);


			}
			//chartGenerateSaleprofitDue1(dateTimeFrom, dateTimeTo);
		}

		void chartGeneratorFormLoading(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
			string sql = @"SELECT * FROM BalanceSheet WHERE UpdatedDate BETWEEN #" + DateTime.Parse(dateTimeTo.ToString("MM/dd/yyyy")) + "# " +
					"AND #" + DateTime.Parse(dateTimeTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";

			DataTable dt = (DataTable)Select(sql).Data;

			if (dt.Rows.Count > 0)
			{
				long idBefore = Convert.ToInt64(dt.Rows[0]["ID"]);
				string sqlBefore = @"SELECT * FROM BalanceSheet WHERE ID = " + (idBefore - 1) + "";
				DataTable dtBefore = (DataTable)Select(sqlBefore).Data;
				double openingBalance = Convert.ToDouble(dt.Rows[0]["OpeningBalance"]);
				double currentBalance = Convert.ToDouble(dt.Rows[0]["CurrentBalance"]);
				lblOpeningBalance.Text = "Opening Balance: " + dt.Rows[0]["OpeningBalance"] + "";
				lblCurrentBalance.Text = "Closing Balance: " + dt.Rows[0]["CurrentBalance"] + "";
				double totalCredit = Convert.ToDouble(dt.Rows[0]["TotalCredit"]);
				double totalCreditBefore = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["TotalCredit"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["TotalCredit"]) : 0;
				//(dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["CreditLiability"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["CreditLiability"]) : 0;
				lblTotalCredit.Text = "TotalCredit: " + (totalCredit - totalCreditBefore) + "";
				double creditLiability = Convert.ToDouble(dt.Rows[0]["CreditLiability"]);
				double creditLiabilityBefore = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["CreditLiability"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["CreditLiability"]) : 0;
				lblCreditLiability.Text = "Credit Liability: " + creditLiability ;
				double totalDebit = Convert.ToDouble(dt.Rows[0]["TotalDebit"]);
				double totalDebitBefore = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["TotalDebit"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["TotalDebit"]) : 0;
				lblTotalDebit.Text = "Total Debit: " + (totalDebit - totalDebitBefore) + "";
				double debitLiability = Convert.ToDouble(dt.Rows[0]["DebitLiability"]);
				double debitLiabilityBefore = (dtBefore.Rows.Count > 0 && !string.IsNullOrEmpty(dtBefore.Rows[0]["DebitLiability"].ToString())) ? Convert.ToDouble(dtBefore.Rows[0]["DebitLiability"]) : 0;
				lblDebitLiability.Text = "Debit Liability: " + (debitLiability) + "";

				chartGeneratorDoughnut(openingBalance, currentBalance, totalCredit, totalCreditBefore, creditLiability, 0, totalDebit, totalDebitBefore, debitLiability, 0);


			}
			chartGenerateSaleprofitDue1(dateTimeFrom, dateTimeTo);
		}
        

		private void dateTimePickerSpecificDate_ValueChanged(object sender, EventArgs e)
		{
			DateTime dateTimeTo = dateTimePickerSpecificDate.Value;
			DateTime dateTimeFrom = dateTimeTo.AddDays(-14);

			//DateTime date = DateTime.Parse(dateTimePickerSpecificDate.Text);
			chartGeneratorFormLoading(dateTimeFrom, dateTimeTo);
			GrossProfitNetProfitCalculation(dateTimeTo, dateTimeTo.AddDays(1));
			
		}

		void GrossProfitNetProfitCalculation(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
			string grossProfit = Convert.ToString(Math.Round(GrossProfitCalculation(dateTimeFrom, dateTimeTo)));
			labelGrossProfit.Text = "Gross Profit: " + grossProfit;
			labelProfit.Text = grossProfit;
        }

		Double GrossProfitCalculation(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
			string sql = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate BETWEEN #" + DateTime.Parse(dateTimeFrom.ToString("MM/dd/yyyy")) + "# " +
				"AND #" + DateTime.Parse(dateTimeTo.AddDays(0).ToString("MM/dd/yyyy")) + "#";
			return ProfitCalculator(sql);
			//labelGrossProfit.Text = "Gross Profit: " + Convert.ToString(Math.Round(ProfitCalculator(sql), 2));
		}

		double ProfitCalculator(string sql)
		{
			double totalCostPerUnit = 0, totalSellingPrice = 0, soldQuantity = 0, costPerUnit = 0, profit = 0, dueVat = 0, customerGivenVat = 0, sellerGivenVat = 0;
			double totalQuantity = 0, pdGivenVat = 0;
			DataTable dt1 = (DataTable)Select(sql).Data;
			for (int i = 0; i < dt1.Rows.Count; i++)
			{
				//if (dt1.Rows[i]["CostPerUnit"] != DBNull.Value)
				//{
				//    costPerUnit = Convert.ToDouble(dt1.Rows[i]["CostPerUnit"]);
				//    if (dt1.Rows[i]["Quantity"] != DBNull.Value)
				//    {
				//        quantity = Convert.ToDouble(dt1.Rows[i]["Quantity"]);
				//    }
				//    totalCostPerUnit = totalCostPerUnit + (costPerUnit * quantity);
				//}
				//dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? Convert.ToDouble(dt.Rows[0][2]) : 0;
				//dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["CostPerUnit"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["CostPerUnit"] : 0;
				//costPerUnit = Convert.ToDouble(dt1.Rows[i]["CostPerUnit"]);
				costPerUnit = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["CostPerUnit"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["CostPerUnit"]) : 0;
				//costPerUnit = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? Convert.ToDouble(dt.Rows[0][2]) : 0;
				//soldQuantity = Convert.ToDouble(dt1.Rows[i]["Quantity"]);
				soldQuantity = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["Quantity"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["Quantity"]) : 0;
				//totalQuantity = Convert.ToDouble(dt1.Rows[i]["TotalQuantity"]);
				totalQuantity = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["TotalQuantity"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["TotalQuantity"]) : 0;
				totalCostPerUnit = totalCostPerUnit + (costPerUnit * soldQuantity);
				//totalSellingPrice = totalSellingPrice + Convert.ToDouble(dt1.Rows[i]["TotalPrice"]);
				totalSellingPrice = totalSellingPrice + (dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["TotalPrice"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["TotalPrice"]) : 0);
				//customerGivenVat = customerGivenVat + Convert.ToDouble(dt1.Rows[i]["d.GivenVat"]);
				////customerGivenVat = customerGivenVat + (dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["d.GivenVat"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["d.GivenVat"]) : 0);
				//sellerGivenVat = sellerGivenVat + ((Convert.ToDouble(dt1.Rows[i]["pd.GivenVat"]) / totalQuantity) * soldQuantity);
				////pdGivenVat = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["pd.GivenVat"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["pd.GivenVat"]) : 0;
				////sellerGivenVat = sellerGivenVat + ((pdGivenVat) / totalQuantity) * soldQuantity;









				//quantity = Convert.ToDouble(dt1.Rows[i]["Quantity"]);
				//if (dt1.Rows[i]["SellingPrice"] != DBNull.Value) sellingPrice = sellingPrice + (Convert.ToDouble(dt1.Rows[i]["SellingPrice"])*quantity);
			}

			profit = totalSellingPrice - totalCostPerUnit;
			return profit;
			////lblCollectedVat.Text = Convert.ToString(customerGivenVat);
			////lblPaidVat.Text = Convert.ToString(sellerGivenVat);
			////dueVat = customerGivenVat - sellerGivenVat;

			////lblDueVat.Text = Convert.ToString(Math.Round(dueVat, 2));


			//labelGrossProfit.Text = "Gross Profit: " + Convert.ToString(Math.Round(profit, 2));
			////lblTotalCost.Text = Convert.ToString(Math.Round(totalCostPerUnit, 2));

		}

		void chartGeneratorDoughnut(double openingBalance, double currentBalance, double totalCredit, double totalCreditBefore, double creditLiability, double creditLiabilityBefore, double totalDebit, double totalDebitBefore, double debitLiability, double debitLiabilityBefore)
		{

			balanceSheetChart.Series.Clear();
			ChartArea chartArea = new ChartArea();
			chartArea = balanceSheetChart.ChartAreas[0];
			//balanceSheetChart.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;//x axis
			//chartAccounts.ChartAreas[0].AxisY.LabelStyle.Format = "P";
			//chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 13);
			balanceSheetChart.ChartAreas[0].AxisX.Interval = 1;
			balanceSheetChart.Palette = ChartColorPalette.SeaGreen;
			//balanceSheetChart.ChartAreas[0].AxisX.ScrollBar = true;
			//balanceSheetChart.ChartAreas[0].Axes[1].MajorGrid.Enabled = true;//y axis

			//Series
			Series series1 = new Series();

			balanceSheetChart.Series.Add(series1);

			//Series style
			series1.ChartType = SeriesChartType.Doughnut;
			balanceSheetChart.Series[0]["PieLabelStyle"] = "Disabled";

			//series1// type
			series1.BorderWidth = 1;

			//series1.Color = Color.Green;
			series1.Name = "Amount";
			balanceSheetChart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;

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
			//int ix = series1.Points.AddXY(opening, openingBalance);
			series1.Points.AddXY(opening, openingBalance);

			string current = "Closing Bal.";
			series1.Points.AddXY(current, currentBalance);

			string creditBalance = "Total Credit";
			series1.Points.AddXY(creditBalance, (totalCredit - totalCreditBefore));

			string creditLiaBalance = "Credit Liability";
			series1.Points.AddXY(creditLiaBalance, (creditLiability - creditLiabilityBefore));

			string debitBalance = "Total Debit";
			series1.Points.AddXY(debitBalance, (totalDebit - totalDebitBefore));


			string debitLiaBalance = "Debit Liability";
			series1.Points.AddXY(debitLiaBalance, (debitLiability - debitLiabilityBefore));


			//series2.Points.AddXY(name, amount);

		}



			
		

		void chartGenerateSaleprofitDue1(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
			chartSaleProfitDue.Series.Clear();
			ChartArea chartArea = new ChartArea();
			chartSaleProfitDue.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;
			chartSaleProfitDue.ChartAreas[0].Axes[1].MajorGrid.Enabled = false;
			chartSaleProfitDue.ChartAreas[0].AxisX.Interval = 1;

			Series series1 = new Series();
			chartSaleProfitDue.Series.Add(series1);
			//Series style

			series1.ChartType = SeriesChartType.Spline;
			series1.MarkerBorderWidth = 1;// type
			series1.BorderWidth = 1;
			//series1.Color = Color.Green;
			series1.Name = "Total Sale";

			Series series2 = new Series();
			chartSaleProfitDue.Series.Add(series2);
			//Series style
			series2.ChartType = SeriesChartType.Spline;
			series2.MarkerBorderWidth = 1;// type
			series2.BorderWidth = 1;
			//series2.Color = Color.Blue;
			series2.Name = "Due";

			Series series3 = new Series();
			chartSaleProfitDue.Series.Add(series3);
			//Series style
			series3.ChartType = SeriesChartType.Spline;
			series3.MarkerBorderWidth = 1;// type
			series3.BorderWidth = 1;
			//series3.Color = Color.Red;
			series3.Name = "Profit";
			chartSaleProfitDue.Palette = ChartColorPalette.Bright;
			double totalDays = (dateTimeTo - dateTimeFrom).TotalDays;
			int nOfAddDays = 1;
			int nOfLoop = 15;

			if (totalDays > nOfLoop)
			{
				nOfAddDays = (Convert.ToInt32(totalDays) / 15) + 1;
				if (totalDays < nOfLoop * 2) nOfAddDays = 2;
			}

			//DateTime dtf = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
			//DateTime dtt = DateTime.Parse(DateTime.Now.AddDays(1).ToString("MM/dd/yyyy")); 

			DateTime from = dateTimeFrom;
			DateTime to = dateTimeTo;
			double totalPayable = 0, totalDue = 0, totalSale = 0, dueAll = 0, profit = 0;


			for (int i = 0; i < nOfLoop; i++)
			{
				string sqlSaleProfits = @"SELECT TotalPayable, Due, CreatedDate FROM Sales WHERE CreatedDate
				BETWEEN #" + DateTime.Parse(from.ToString("MM/dd/yyyy")) + "# " +
				"AND #" + DateTime.Parse(from.AddDays(nOfAddDays).ToString("MM/dd/yyyy")) + "#";
				DataTable dtSaleProfits = (DataTable)Select(sqlSaleProfits).Data;
				long countRows = dtSaleProfits.Rows.Count;
				//int count = 1;
				for (int j = 0; j < countRows; j++)
				{
					totalPayable += Convert.ToDouble(dtSaleProfits.Rows[j]["TotalPayable"].ToString());
					
					totalDue += Convert.ToDouble(dtSaleProfits.Rows[j]["Due"].ToString());
					
					//count = j + 1;

				}
				totalPayable = (totalPayable / nOfAddDays);
				totalDue = (totalDue / nOfAddDays);
				series1.Points.AddXY(from.AddDays(nOfAddDays / 2).ToString("MM/dd/yyyy"), (totalPayable));
				//series1.Points.AddXY(from.AddDays(nOfAddDays / 2).ToString("MM/dd/yyyy"), (totalPayable/count));
				series2.Points.AddXY(from.AddDays(nOfAddDays / 2).ToString("MM/dd/yyyy"), (totalDue));
				//series2.Points.AddXY(from.AddDays(nOfAddDays / 2).ToString("MM/dd/yyyy"), (totalDue/count));
				//series3.Points.AddXY(strDate, totalCredit);

				totalPayable = 0;
				totalDue = 0;
				from = from.AddDays(nOfAddDays);
			}

			string sqlSaleProfit = @"SELECT TotalPayable, Due, CreatedDate FROM Sales WHERE CreatedDate
				BETWEEN #" + DateTime.Parse(dateTimeTo.ToString("MM/dd/yyyy")) + "# " +
				"AND #" + DateTime.Parse(dateTimeTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";
			DataTable dtSaleProfit = (DataTable)Select(sqlSaleProfit).Data;
			int rowsCount = dtSaleProfit.Rows.Count;
		
			for (int j = 0; j < rowsCount; j++)
			{
				totalPayable += Convert.ToDouble(dtSaleProfit.Rows[j]["TotalPayable"].ToString());
				totalDue += Convert.ToDouble(dtSaleProfit.Rows[j]["Due"].ToString());
			}

			//GrossProfitNetProfitCalculation(dateTimeTo, dateTimeTo.AddDays(1));



			labelTotalSale.Text = totalPayable.ToString();
			labelTotalDue.Text = totalDue.ToString();
		}

		void chartGeneratorSaleProfitDue(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
			chartSaleProfitDue.Series.Clear();
			ChartArea chartArea = new ChartArea();
			chartSaleProfitDue.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;
			chartSaleProfitDue.ChartAreas[0].Axes[1].MajorGrid.Enabled = false;
			chartSaleProfitDue.ChartAreas[0].AxisX.Interval = 1;

			Series series1 = new Series();
			chartSaleProfitDue.Series.Add(series1);
			//Series style

			series1.ChartType = SeriesChartType.Spline;
			series1.MarkerBorderWidth = 1;// type
			series1.BorderWidth = 1;
			//series1.Color = Color.Green;
			series1.Name = "Total Sale";

			Series series2 = new Series();
			chartSaleProfitDue.Series.Add(series2);
			//Series style
			series2.ChartType = SeriesChartType.Spline;
			series2.MarkerBorderWidth = 1;// type
			series2.BorderWidth = 1;
			//series2.Color = Color.Blue;
			series2.Name = "Due";

			Series series3 = new Series();
			chartSaleProfitDue.Series.Add(series3);
			//Series style
			series3.ChartType = SeriesChartType.Spline;
			series3.MarkerBorderWidth = 1;// type
			series3.BorderWidth = 1;
			//series3.Color = Color.Red;
			series3.Name = "Profit";
			chartSaleProfitDue.Palette = ChartColorPalette.Bright;
			double totalDays = (dateTimeTo - dateTimeFrom).TotalDays;
			int nOfAddDays = 1;
			int nOfLoop = 15;

			if (totalDays > nOfLoop)
            {
				nOfAddDays = (Convert.ToInt32(totalDays) / 15) + 1;
				if (totalDays < nOfLoop * 2) nOfAddDays = 2;
            }

			//DateTime dtf = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
			//DateTime dtt = DateTime.Parse(DateTime.Now.AddDays(1).ToString("MM/dd/yyyy")); 

			DateTime from = dateTimeFrom;
			DateTime to = dateTimeTo;
			double totalPayable = 0, totalDue = 0, totalSale = 0, dueAll = 0, averageProfit = 0, totalProfit = 0, profit = 0;
			

			for (int i = 0; i < nOfLoop; i++)
			{
				// Total Sale & Total Due Calculation
				//if (i == (nOfLoop - 1))
				//{
				//	nOfAddDays = Convert.ToInt32((to - from).TotalDays);
				//}
				string sqlSaleProfit = @"SELECT TotalPayable, Due, CreatedDate FROM Sales WHERE CreatedDate
				BETWEEN #" + DateTime.Parse(from.ToString("MM/dd/yyyy")) + "# " +
				"AND #" + DateTime.Parse(from.AddDays(nOfAddDays).ToString("MM/dd/yyyy")) + "#"; 

				
				DataTable dtSaleProfit = (DataTable)Select(sqlSaleProfit).Data;
				int countRows = dtSaleProfit.Rows.Count;
				//int count = 1;
				for(int j = 0; j < countRows; j++)
                {
					totalPayable  += Convert.ToDouble(dtSaleProfit.Rows[j]["TotalPayable"].ToString());
					
					totalDue  += Convert.ToDouble(dtSaleProfit.Rows[j]["Due"].ToString());
					
					//count = j+1;
					
				}
				totalSale = totalSale + totalPayable;
				dueAll = dueAll + totalDue;
				// Total Gross Profit Calculation
				profit = GrossProfitCalculation(from, from.AddDays(nOfAddDays));
				totalProfit += profit;
				averageProfit = profit / nOfAddDays;
				


				totalPayable = (totalPayable / nOfAddDays);
				totalDue = (totalDue / nOfAddDays);
				series1.Points.AddXY(from.AddDays(nOfAddDays / 2).ToString("MM/dd/yyyy"), (totalPayable));
				//series1.Points.AddXY(from.AddDays(nOfAddDays / 2).ToString("MM/dd/yyyy"), (totalPayable/count));
				series2.Points.AddXY(from.AddDays(nOfAddDays / 2).ToString("MM/dd/yyyy"), (totalDue));
				//series2.Points.AddXY(from.AddDays(nOfAddDays / 2).ToString("MM/dd/yyyy"), (totalDue/count));
				series3.Points.AddXY(from.AddDays(nOfAddDays / 2).ToString("MM/dd/yyyy"), averageProfit);

				totalPayable = 0;
				totalDue = 0;
				from = from.AddDays(nOfAddDays);
			}

			labelTotalSale.Text = totalSale.ToString();
			labelTotalDue.Text = dueAll.ToString();
			labelProfit.Text = totalProfit.ToString();

		}


		void chartGenerator(DateTime dateTimeFrom, DateTime dateTimeTo)
		{
			// chartArea
			balanceSheetChart.Series.Clear();
			ChartArea chartArea = new ChartArea();
			balanceSheetChart.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;//x axis
																			  //chartAccounts.ChartAreas[0].AxisY.LabelStyle.Format = "P";
																			  //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 13);
			balanceSheetChart.ChartAreas[0].AxisX.Interval = 1;
			balanceSheetChart.ChartAreas[0].Axes[1].MajorGrid.Enabled = false;//y axis
			balanceSheetChart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
			
			//Series
			Series series1 = new Series();
			balanceSheetChart.Series.Add(series1);
			//Series style

			series1.ChartType = SeriesChartType.Spline;
			series1.MarkerBorderWidth = 1;// type
			series1.BorderWidth = 1;
			//series1.Color = Color.Green;
			series1.Name = "Opening Balance";

			Series series2 = new Series();
			balanceSheetChart.Series.Add(series2);
			//Series style
			series2.ChartType = SeriesChartType.Spline;
			series2.MarkerBorderWidth = 1;// type
			series2.BorderWidth = 1;
			//series2.Color = Color.Blue;
			series2.Name = "Current Balance";

			Series series3 = new Series();
			balanceSheetChart.Series.Add(series3);
			//Series style
			series3.ChartType = SeriesChartType.Spline;
			series3.MarkerBorderWidth = 1;// type
			series3.BorderWidth = 1;
			//series3.Color = Color.Red;
			series3.Name = "Total Credit";

			Series series4 = new Series();
			balanceSheetChart.Series.Add(series4);
			//Series style
			series4.ChartType = SeriesChartType.Spline;
			series4.MarkerBorderWidth = 1;// type
			series4.BorderWidth = 1;
			//series4.Color = Color.Black;
			series4.Name = "Credit Liability";

			Series series5 = new Series();
			balanceSheetChart.Series.Add(series5);
			//Series style
			series5.ChartType = SeriesChartType.Spline;
			series5.MarkerBorderWidth = 1;// type
			series5.BorderWidth = 1;
			//series5.Color = Color.Yellow;
			series5.Name = "Total Debit";

			Series series6 = new Series();
			balanceSheetChart.Series.Add(series6);
			//Series style
			series6.ChartType = SeriesChartType.Spline;
			series6.MarkerBorderWidth = 1;
			//series6.// type
			series6.BorderWidth = 1;
			//series6.Color = Color.Pink;
			series6.Name = "Debit Liability";

			//balanceSheetChart.Series[0].AxisLabel = false;
			balanceSheetChart.Palette = ChartColorPalette.Bright;
			string sqlBalanceSheet = @"SELECT * FROM BalanceSheet WHERE UpdatedDate
            BETWEEN #" + DateTime.Parse(dateTimeFrom.ToString("MM/dd/yyyy")) + "# " +
					"AND #" + DateTime.Parse(dateTimeTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";

			DataTable dt = (DataTable)Select(sqlBalanceSheet).Data;
			
			int countRows = dt.Rows.Count;
			int decrement = 1;
			DataTable dtBalanceSheetBefore;
			string dateTime, strDate;
			double openingBalance = 0, currentBalance = 0, totalCredit = 0, totalCreditBefore = 0, creditLiability = 0, totalDebit = 0, totalDebitBefore = 0, debitLiability = 0;
			if(countRows > 0)
            {
				int balanceSheetId = Convert.ToInt32(dt.Rows[0]["ID"]);
				string sqlBalanceSheetTop = @"SELECT TOP 1 * FROM BalanceSheet";
				DataTable dtBalanceSheetTop = (DataTable)Select(sqlBalanceSheetTop).Data;
				int countTop = dtBalanceSheetTop.Rows.Count;
				int balanceSheetIdTop = 1;
				if(countTop > 0)
                {
					balanceSheetIdTop = Convert.ToInt32(dtBalanceSheetTop.Rows[0]["ID"]);

				}
				
				while ((balanceSheetId - decrement) > balanceSheetIdTop)
				{
					string sqlBalanceSheetBefore = @"SELECT * FROM BalanceSheet WHERE ID = " + (balanceSheetId - decrement) + "";
					dtBalanceSheetBefore = (DataTable)Select(sqlBalanceSheetBefore).Data;
					int count = dtBalanceSheetBefore.Rows.Count;
					if (count > 0)
					{
						dateTime = Convert.ToString(dt.Rows[0]["UpdatedDate"]);
						//DateTime date = DateTime.Parse(dateTime);
						strDate = DateTime.Parse(dateTime).ToString("MM/dd/yyyy");
						openingBalance = Convert.ToDouble(dt.Rows[0]["OpeningBalance"]);
						currentBalance = Convert.ToDouble(dt.Rows[0]["CurrentBalance"]);
						totalCredit = Convert.ToDouble(dt.Rows[0]["TotalCredit"]);
						totalCreditBefore = Convert.ToDouble(dtBalanceSheetBefore.Rows[0]["TotalCredit"]);
						creditLiability = Convert.ToDouble(dt.Rows[0]["CreditLiability"]);
						totalDebit = Convert.ToDouble(dt.Rows[0]["TotalDebit"]);
						totalDebitBefore = Convert.ToDouble(dtBalanceSheetBefore.Rows[0]["TotalDebit"]);
						debitLiability = Convert.ToDouble(dt.Rows[0]["DebitLiability"]);
						series1.Points.AddXY(strDate, openingBalance);
						series2.Points.AddXY(strDate, currentBalance);
						series3.Points.AddXY(strDate, (totalCredit-totalCreditBefore));
						series4.Points.AddXY(strDate, creditLiability);
						series5.Points.AddXY(strDate, (totalDebit-totalDebitBefore));
						series6.Points.AddXY(strDate, debitLiability);
						break;
					}
					decrement++;
				}
            }
			//chartAccounts.DataBindTable(dt.DefaultView, "Balance");
			//int nOFColumn = 7;
			//int gapBetweenColumn = countRows / nOFColumn;

            for (int i = 1; i < countRows; i++)
            {

                dateTime = Convert.ToString(dt.Rows[i]["UpdatedDate"]);
				//strDate = "";
				//DateTime date = DateTime.Parse(dateTime);

				// hide dates after certain period
				//if (gapBetweenColumn > 0)
				//            {
				//	if ((i % gapBetweenColumn) == 0)
				//                {
				//		strDate = DateTime.Parse(dateTime).ToString("MM/dd/yyyy");
				//	}

				//}

				strDate = DateTime.Parse(dateTime).ToString("MM/dd/yyyy");
				openingBalance = Convert.ToDouble(dt.Rows[i]["OpeningBalance"]);
                currentBalance = Convert.ToDouble(dt.Rows[i]["CurrentBalance"]);
                totalCredit = Convert.ToDouble(dt.Rows[i]["TotalCredit"]);
                totalCreditBefore = Convert.ToDouble(dt.Rows[i-1]["TotalCredit"]);
                creditLiability = Convert.ToDouble(dt.Rows[i]["CreditLiability"]);
                totalDebit = Convert.ToDouble(dt.Rows[i]["TotalDebit"]);
                totalDebitBefore = Convert.ToDouble(dt.Rows[i-1]["TotalDebit"]);
                debitLiability = Convert.ToDouble(dt.Rows[i]["DebitLiability"]);
                series1.Points.AddXY(strDate, openingBalance);
                series2.Points.AddXY(strDate, currentBalance);
                series3.Points.AddXY(strDate, (totalCredit - totalCreditBefore));
                series4.Points.AddXY(strDate, creditLiability);
                series5.Points.AddXY(strDate, (totalDebit - totalDebitBefore));
                series6.Points.AddXY(strDate, debitLiability);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
			//Initial();
			DateTime dateTimeFrom = DateTime.Parse(dateTimePickerFrom.Text.ToString());
			DateTime dateTimeTo = DateTime.Parse(dateTimePickerTo.Text.ToString());
			double nOfDays = (dateTimeTo - dateTimeFrom).TotalDays;
			if(nOfDays >= 0)
            {
				chartGenerator(dateTimeFrom, dateTimeTo);
				chartGeneratorSaleProfitDue(dateTimeFrom, dateTimeTo);
				GrossProfitNetProfitCalculation(dateTimeFrom, dateTimeTo.AddDays(1));
				BalanceSheetGeneratorForMultipleDates(dateTimeFrom, dateTimeTo);
            }
			else
            {
				MessageBox.Show("The date of from can not be after the date of To!!!");
            }
        }


        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
			if(cmbSearch.SelectedIndex == 1)
            {
				labelFrom.Visible = false;
				labelTo.Visible = false;
				dateTimePickerFrom.Visible = false;
				dateTimePickerTo.Visible = false;
				btnOK.Visible = false;
				dateTimePickerSpecificDate.Enabled = true;
				
            }

			else if(cmbSearch.SelectedIndex == 2)
            {
				dateTimePickerSpecificDate.Enabled = false;
				labelFrom.Visible = true;
				labelTo.Visible = true;
				dateTimePickerFrom.Visible = true;
				dateTimePickerTo.Visible = true;
				btnOK.Visible = true;
            }
        }

       
    }
}
