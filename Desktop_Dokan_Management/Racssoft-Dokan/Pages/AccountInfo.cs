using System;
using Model;
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
    public partial class AccountInfo : Common
    {


		void initial()
        {
			getAccountInfo();

		}
        public AccountInfo()
        {
            InitializeComponent();
			initial();

		}

        public void getAccountInfo()
        {
            string sql = @"SELECT ID, Title AS [Account Name], AccountNo AS [Account No], Amount AS [Balance] FROM DigitalWallet";
			datagridviewGenerator(sql);
			chartGenerator(sql);
        }


		 
		void chartGenerator(string sql)
        {
			// chartArea
			chartAccounts.Series.Clear();
			ChartArea chartArea = new ChartArea();
			chartAccounts.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;//x axis
			//chartAccounts.ChartAreas[0].AxisY.LabelStyle.Format = "P";
			//chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 13);
			chartAccounts.ChartAreas[0].AxisX.Interval = 1;
			chartAccounts.ChartAreas[0].Axes[1].MajorGrid.Enabled = true;//y axis

			//Series
			Series series1 = new Series();
			chartAccounts.Series.Add(series1);
			//Series style
			series1.ChartType = SeriesChartType.Column;  // type
			series1.BorderWidth = 2;
			series1.Color = Color.FromArgb(64, 86, 141);
			series1.Name = "Balance";

	

			DataTable dt = (DataTable)Select(sql).Data;
			//chartAccounts.DataBindTable(dt.DefaultView, "Balance");

			for(int i = 0; i < dt.Rows.Count; i++)
            {
				string name = Convert.ToString(dt.Rows[i]["Account Name"]);
				double amount = Convert.ToDouble(dt.Rows[i]["Balance"]);
				series1.Points.AddXY(name, amount);

            }
			
		}

		void datagridviewGenerator(string sql)
		{
			DataTable dt = (DataTable)Select(sql).Data;
			dgAccounts.Refresh();
			dgAccounts.DataSource = dt;

			dgAccounts.Columns[0].Visible = false;
			dgAccounts.AutoGenerateColumns = false;

			

			if (dgAccounts.Columns.Count < 5)
			{
				DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
				Editlink.UseColumnTextForLinkValue = true;
				Editlink.HeaderText = "Edit";
				Editlink.DataPropertyName = "lnkColumn";
				Editlink.LinkBehavior = LinkBehavior.SystemDefault;
				Editlink.Text = "Edit";
				dgAccounts.Columns.Add(Editlink);
			}
			datagridviewCellResizer();

			dgAccounts.Refresh();
			double totalBalance = 0;
			var balance = "";

			for (int a = 0; a < dgAccounts.Rows.Count - 1; a++)
			{
				balance = dgAccounts.Rows[a].Cells[3].Value.ToString();
				if (balance != DBNull.Value.ToString())
				{
					totalBalance += Convert.ToDouble(balance);
				}
			}
			//totalBalance = DigitalWalletBalance();
			lblBalance.Text = " "+ totalBalance +" ";
		}

		void datagridviewCellResizer()
		{
			dgAccounts.Columns[1].Width = 65;
			dgAccounts.Columns[2].Width = 65;
			dgAccounts.Columns[3].Width = 65;
			dgAccounts.Columns[4].Width = 65;
		
			//dgItems.Columns[12].Width = 75;
			//dgItems.Columns[13].Width = 75;
		}

		void Clear()
        {
			txtAccountName.Text = "";
			txtAccountNo.Text = "";
			numericAccountAmount.Value = 0;
        }

		long getMaxId(string cmd)
		{
			DataTable dt;
			//cmd = "SELECT MAX(Id) FROM Products";
			dt = (DataTable)Select(cmd).Data;
			long id = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()) ? Convert.ToInt64(dt.Rows[0][0]) : 0;
			return id;
		}

		public double DigitalWalletBalance()
		{
			string digitalWalletSql = @"SELECT * FROM DigitalWallet";
			DataTable digitalWalletDt = (DataTable)Select(digitalWalletSql).Data;
			double totalDigitalWalletBalance = 0;
			for (int i = 0; i < digitalWalletDt.Rows.Count; i++)
			{
				totalDigitalWalletBalance = totalDigitalWalletBalance + Convert.ToDouble(digitalWalletDt.Rows[i]["Amount"]);
			}
			return totalDigitalWalletBalance;
		}
		private void btnCreateAccount_Click(object sender, EventArgs e)
        {
			if (txtAccountName.Text != "" && txtAccountNo.Text != "")
			{
				string name = Convert.ToString(txtAccountName.Text);
				string accountNo = Convert.ToString(txtAccountNo.Text);
				double balance = Convert.ToDouble(numericAccountAmount.Value);

				string sql = "INSERT INTO DigitalWallet(Title, AccountNo, Amount) VALUES ('" + name + "', '" + accountNo + "', " + balance + ")";
				CUD(sql);
				getAccountInfo();
				long balanceSheetId = getMaxId("SELECT MAX(Id) FROM BalanceSheet");
				string balanceSheetSql = @"SELECT * FROM BalanceSheet WHERE ID = " + balanceSheetId + "";
				DataTable dt = (DataTable)Select(balanceSheetSql).Data;
				//double totalCredit = Convert.ToDouble(dt.Rows[0]["TotalCredit"]);
				double totalCredit = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0]["TotalCredit"].ToString()) ? Convert.ToDouble(dt.Rows[0]["TotalCredit"]) : 0;
				double currentBalance = DigitalWalletBalance();
				if (dt.Rows.Count > 0)
				{
					string sqlUpdateBalanceSheet = "UPDATE BalanceSheet SET CurrentBalance = " + currentBalance + ", TotalCredit = " + (totalCredit + balance) + " WHERE " +
						"ID = " + balanceSheetId + "";
					CUD(sqlUpdateBalanceSheet);
				}
				else if(dt.Rows.Count == 0)
                {
					string sqlInsertBalanceSheet = "INSERT INTO BalanceSheet(OpeningBalance, CurrentBalance, TotalCredit," +
						"CreditLiability, TotalDebit, DebitLiability, UpdatedDate) VALUES (" + balance + ", " + balance + ", "+balance+"," +
						"0, 0, 0, '" + DateTime.Now + "')";
					CUD(sqlInsertBalanceSheet);
                }

				Clear();

			}

			else MessageBox.Show("Please, Fill up all requireds fields");
        }

        private void dgAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			if(e.ColumnIndex == 4)
            {
				if (e.RowIndex > -1)
				{
					(new AccountAction(Convert.ToInt32(dgAccounts.Rows[e.RowIndex].Cells[0].Value.ToString()))).ShowDialog();
					getAccountInfo();
				}
            }
        }
    }
}
