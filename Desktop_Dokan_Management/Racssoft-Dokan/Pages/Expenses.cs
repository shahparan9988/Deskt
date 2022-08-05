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

namespace Racssoft_Dokan.Pages
{
    public partial class Expenses : Common
    {

        //Payment Method
        List<int> isComboAdded = new List<int>();
        Dictionary<int, Label> isAddedLabel = new Dictionary<int, Label>();
        Dictionary<int, NumericUpDown> isAddedTextBox = new Dictionary<int, NumericUpDown>();
        Dictionary<int, Button> isAddedButton = new Dictionary<int, Button>();
        Dictionary<int, string> paymentMethods = new Dictionary<int, string>();
        public Expenses()
        {
            InitializeComponent();
			Initial();
        }

        void Initial()
        {
			string sqlExpense = @"SELECT e.ID, e.Detail, e.Amount, e.Due, e.CreatedDate FROM Expense e WHERE e.CreatedDate 
			BETWEEN #" + DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + "# " +
					"AND #" + DateTime.Parse(DateTime.Now.AddDays(1).ToString("MM/dd/yyyy")) + "#";
			getExpenseGrid(sqlExpense);

			paymentMethods = getPaymentMethod();
            cmbPaymentMethod.Items.AddRange(getPaymentMethod().Select(s => s.Value).ToArray());
        }

        Dictionary<int, string> getPaymentMethod()
        {
            string sql = "Select * FROM DigitalWallet";
            DataTable dt = (DataTable)Select(sql).Data;
            return dt.AsEnumerable()
      .ToDictionary<DataRow, int, string>(row => row.Field<int>(0),
                                row => row.Field<string>(1) + "--" + row.Field<string>(2));

        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (cmbPaymentMethod.SelectedIndex > -1)
			{
				string unit1 = cmbPaymentMethod.SelectedItem.ToString();

				var itemKey = 0;
				for (int i = paymentMethods.Count - 1; i >= 0; i--)
				{
					var item = paymentMethods.ElementAt(i);
					if (item.Value == unit1)
					{
						itemKey = item.Key;
					}
					//var itemValue = item.Value;
				}
				addWallet(cmbPaymentMethod.Items[cmbPaymentMethod.SelectedIndex].ToString(), itemKey);
			}
        }

		void addWallet(string walletName, int i)
		{
			if (isComboAdded.Where(w => w == i).ToList().Count > 0) return;

			System.Windows.Forms.NumericUpDown textBox = new NumericUpDown();
			System.Windows.Forms.Label label = new Label();
			System.Windows.Forms.Button delete = new Button();

			label.AutoSize = true;
			//label.Location = new System.Drawing.Point(21, 30 + count * 22);
			label.Name = "label_" + i;
			label.Size = new System.Drawing.Size(35, 20);
			label.TabIndex = 0;
			label.Text = walletName;

			//textBox.Location = new System.Drawing.Point(96, 30 + count * 20);
			textBox.Name = "textBox_" + i;
			textBox.Size = new System.Drawing.Size(100, 20);
			textBox.Maximum = new decimal(new int[] {
			1000000000,
			0,
			0,
			0});
			textBox.Minimum = new decimal(new int[] {
			0,
			0,
			0,
			0});
			textBox.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});

			textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;


			//delete.Location = new System.Drawing.Point(226, 30 + count * 20);
			delete.Name = "Delete_" + i;
			delete.Size = new System.Drawing.Size(17, 20);
			delete.TabIndex = 2;
			delete.Text = "x";
			delete.ForeColor = Color.Red;
			delete.TextAlign = ContentAlignment.MiddleCenter;
			delete.BackColor = System.Drawing.SystemColors.Control;
			delete.FlatStyle = FlatStyle.Flat;
			delete.FlatAppearance.BorderSize = 0;
			delete.Cursor = System.Windows.Forms.Cursors.Hand;

			isComboAdded.Add(i);
			isAddedTextBox.Add(i, textBox);
			isAddedLabel.Add(i, label);
			isAddedButton.Add(i, delete);
			setLocation(isAddedLabel, isAddedTextBox, isAddedButton);
			this.panelForPaymentMethod.Controls.Add(textBox);
			this.panelForPaymentMethod.Controls.Add(label);
			this.panelForPaymentMethod.Controls.Add(delete);
			delete.Click += new System.EventHandler(this.deleteButton_Click_1);
			textBox.ValueChanged += new System.EventHandler(this.numericAmount_ValueChanged);
			textBox.Click += new System.EventHandler(this.textBox_Click);



			//count++;

		}

		private void deleteButton_Click_1(object sender, EventArgs e)
		{
			var button = (Button)sender;
			string[] s = button.Name.Split('_');

			int i = Convert.ToInt32(s[1]);
			isComboAdded.Remove(i);
			this.panelForPaymentMethod.Controls.Remove((Button)sender);
			isAddedButton.Remove(i);
			this.panelForPaymentMethod.Controls.Remove(isAddedLabel[i]);
			isAddedLabel.Remove(i);
			this.panelForPaymentMethod.Controls.Remove(isAddedTextBox[i]);
			isAddedTextBox.Remove(i);
			setLocation(isAddedLabel, isAddedTextBox, isAddedButton);
			Calculation();
			//this.panel1.Controls.Remove(isAddedTextBox[i]);
			//if (isAddedLabel.Where(w => w.Name == "label_" + i).ToList().Count > 0) this.panel1.Controls.Remove(w);

			//this.panel1.Where(w => w.name == "textBox_" + i).Remove(w);
			//isAddedTextBox.Remove(isAddedTextBox[i]);
			//this.panel1.Controls.Remove(isAddedLabel[i]);
			//isAddedLabel.Remove(isAddedLabel[i]);
			// this.panel1.Controls.Remove("this.textBox + s[1]");




		}

		void setLocation(Dictionary<int, Label> labels, Dictionary<int, NumericUpDown> textBoxes, Dictionary<int, Button> buttons)
		{
			for (int i = 0; i < labels.Count; i++)
			{
				labels.ElementAt(i).Value.Location = new System.Drawing.Point(15, 10 + i * 22);
				textBoxes.ElementAt(i).Value.Location = new System.Drawing.Point(140, 10 + i * 22);
				buttons.ElementAt(i).Value.Location = new System.Drawing.Point(250, 10 + i * 22);
			}
		}

		void Calculation()
        {
			double amount = Convert.ToDouble(numericAmount.Value);
			double paidAmount = 0;

			foreach (KeyValuePair<int, NumericUpDown> d in isAddedTextBox)
			{
				//int digitalWalletId = Convert.ToInt32(d.Key) + 1;
				double transactionAmount = Convert.ToDouble(Convert.ToString(d.Value.Value));
				paidAmount = paidAmount + transactionAmount;
			}
			numericAmount.Value = Convert.ToDecimal(paidAmount);
			//if ((amount - paidAmount) > 0) numericDue.Value = Convert.ToDecimal(amount - paidAmount);
			//if((amount - paidAmount) < 0)
    //        {
				//MessageBox.Show("Paid amount can not be more than the cost!!!");
				//numericDue.Value = 0;
    //        }



		}

		long getMaxId(string cmd)
		{
			DataTable dt;
			//cmd = "SELECT MAX(Id) FROM Products";
			dt = (DataTable)Select(cmd).Data;
			long id = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()) ? Convert.ToInt64(dt.Rows[0][0]) : 0;
			return id;
		}

		public (double, double, double, double, double) BalanceSheet(long balanceSheetId)
		{
			string sql = @"SELECT * FROM BalanceSheet WHERE ID = " + balanceSheetId + "";
			DataTable dt = (DataTable)Select(sql).Data;

			double currentBalance = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? Convert.ToDouble(dt.Rows[0][2]) : 0;
			double totalCredit = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][3].ToString()) ? Convert.ToDouble(dt.Rows[0][3]) : 0;
			double creditLiability = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][4].ToString()) ? Convert.ToDouble(dt.Rows[0][4]) : 0;
			double totalDebit = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][5].ToString()) ? Convert.ToDouble(dt.Rows[0][5]) : 0;
			double debitLiability = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][6].ToString()) ? Convert.ToDouble(dt.Rows[0][6]) : 0;
			return (Convert.ToDouble(currentBalance), Convert.ToDouble(totalCredit), Convert.ToDouble(creditLiability), Convert.ToDouble(totalDebit), Convert.ToDouble(debitLiability));
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

		private void textBox_Click(object sender, EventArgs e)
		{
			//if (txtName.Focused) lblForNameFieldValidation.Visible = false;
			//if (txtBuyingTotalQuantity.Focused) lblForBuyingQuantityValidation.Visible = false;
			//if (cmbUnitForBuy.SelectedIndex != 0) lblForBuyingUnitValidation.Visible = false;
			if (sender.GetType() == typeof(TextBox))
			{
				((TextBox)sender).SelectAll();

			}

			else if (sender.GetType() == typeof(RichTextBox))
			{
				((RichTextBox)sender).SelectAll();
			}
			else
			{
				NumericUpDown numeric = (NumericUpDown)sender;
				(numeric).Select(0, numeric.Value.ToString().Length + 3);
			}
		}

        private void numericAmount_ValueChanged(object sender, EventArgs e)
        {
			Calculation();
        }

        private void grpExpense_MouseCaptureChanged(object sender, EventArgs e)
        {
			Calculation();
        }

        private void grpExpenseDetails_MouseCaptureChanged(object sender, EventArgs e)
        {
			Calculation();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
			string detail = Convert.ToString(rTxtExpenseDetail.Text);
			double cost = Convert.ToDouble(numericAmount.Value);
			long balanceSheetId = getMaxId("SELECT MAX(Id) FROM BalanceSheet");
			//double due = Convert.ToDouble(numericDue.Value);
			double due = 0;

			string sqlExpense = @"INSERT INTO Expense(Detail, Amount, CreatedDate, BalanceSheetId, Due) VALUES ('" + detail + "'," +
				""+ cost +", '"+ DateTime.Now +"', "+ balanceSheetId +", "+ due +" )";
			CUD(sqlExpense);
			long expenseId = getMaxId("SELECT MAX(Id) FROM Expense");

			
			

			foreach (KeyValuePair<int, NumericUpDown> d in isAddedTextBox)
			{
				var balanceSheet = BalanceSheet(balanceSheetId);
				double currentBalance = balanceSheet.Item1;
				double totalDebit = balanceSheet.Item4;
				double debitLiability = balanceSheet.Item5;
				int digitalWalletId = Convert.ToInt32(d.Key);
				double transactionAmount = Convert.ToDouble(Convert.ToString(d.Value.Value));

				string dGHistorySql = @"INSERT INTO DigitalWallet_History(DigitalWalletId, TransactionType, DetailPurpose, TransactedAmount, UpdatedDate, BalanceSheetId)
				VALUES(" + digitalWalletId + ", 'WITHDRAWN', 'EXPENSES PAYMENT', " + transactionAmount + ", '" + DateTime.Now + "', " + balanceSheetId + ")";
				CUD(dGHistorySql);
				long dgHistoryId = getMaxId("SELECT MAX(Id) FROM DigitalWallet_History");

				string sql = @"INSERT INTO ExpenseDetails(ExpenseId, DigitalWalletId, TransactionAmount, UpdatedDate, DG_HistoryId)
									VALUES(" + expenseId + ", " + digitalWalletId + ", " + transactionAmount + ", '" + DateTime.Now + "', " + dgHistoryId + ")";
				CUD(sql);
				string sqlGetAmount = @"SELECT * FROM DigitalWallet WHERE ID = " + digitalWalletId + "";
				DataTable dt = (DataTable)Select(sqlGetAmount).Data;
				double amount = 0;
				if (dt.Rows.Count > 0)
				{
					amount = Convert.ToDouble(dt.Rows[0]["Amount"]);

				}

				amount = amount - transactionAmount;
				string sqlUpdateAmount = @"UPDATE DigitalWallet SET Amount = " + amount + " WHERE ID = " + digitalWalletId + "";
				CUD(sqlUpdateAmount);
				double totalBalance = DigitalWalletBalance();
				string sqlUpdateBalanceSheet = @"UPDATE BalanceSheet SET CurrentBalance = " + totalBalance + "," +
					" TotalDebit = " + (totalDebit + transactionAmount) + ", DebitLiability = " + (debitLiability + due) + " WHERE ID = " + balanceSheetId + "";
				CUD(sqlUpdateBalanceSheet);
			}
			MessageBox.Show("Saved Successfully!!!");
			Clear();
			Initial();
		}

		void Clear()
        {
			rTxtExpenseDetail.Text = "";
			cmbPaymentMethod.SelectedIndex = -1;
			panelForPaymentMethod.Controls.Clear();
			isComboAdded.Clear();
			isAddedTextBox.Clear();
			isAddedLabel.Clear();
			isAddedButton.Clear();
			paymentMethods.Clear();
			numericAmount.Value = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
			DateTime dateFrom = DateTime.Parse(dateTimePickerFrom.Text);
			DateTime dateTo = DateTime.Parse(dateTimePickerTo.Text);

			string sqlExpense = @"SELECT e.ID, e.Detail, e.Amount, e.Due, e.CreatedDate FROM Expense e WHERE e.CreatedDate 
			BETWEEN #" + DateTime.Parse(dateFrom.ToString("MM/dd/yyyy")) + "# " +
					"AND #" + DateTime.Parse(dateTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";
			getExpenseGrid(sqlExpense);
		}

		void getExpenseGrid(string sql)
		{
			DataTable dt = (DataTable)Select(sql).Data;
			dgExpense.Refresh();
			dgExpense.DataSource = dt;
			dgExpense.AutoGenerateColumns = false;
			dgExpense.Columns[0].Visible = false;
			if (dgExpense.Columns.Count == 5)
			{
				DataGridViewLinkColumn payMent = new DataGridViewLinkColumn();
				payMent.UseColumnTextForLinkValue = true;
				payMent.HeaderText = "View";
				payMent.DataPropertyName = "lnkColumn";
				payMent.LinkBehavior = LinkBehavior.AlwaysUnderline;
				payMent.Text = "view";
				payMent.LinkColor = Color.Blue;
				dgExpense.Columns.Add(payMent);


				DataGridViewLinkColumn delete = new DataGridViewLinkColumn();
				delete.UseColumnTextForLinkValue = true;
				delete.HeaderText = "delete";
				delete.DataPropertyName = "lnkColumn";
				delete.LinkBehavior = LinkBehavior.AlwaysUnderline;
				delete.Text = "Delete";
				delete.LinkColor = Color.Blue;
				dgExpense.Columns.Add(delete);
			}
			dgExpense.Refresh();
		}

        private void dgExpense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.ColumnIndex == 6)
			{
				if (e.RowIndex > -1)
				{
					long expenseId = Convert.ToInt64(dgExpense.Rows[e.RowIndex].Cells[0].Value.ToString());
					long balanceSheetId = getMaxId("SELECT MAX(Id) FROM BalanceSheet");
					//long inventoryId = Convert.ToInt64(gridInvoices.Rows[e.RowIndex].Cells[0].Value.ToString());
					string name = dgExpense.Rows[e.RowIndex].Cells[0].Value.ToString();
					DialogResult dr = MessageBox.Show("Are You Sure You Want To Delete " + Environment.NewLine
						+ name + "'s Informations", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


					if (dr.ToString() == "Yes")
					{


						string sqlExpense = "SELECT e.ID, e.BalanceSheetId, ed.ID, ed.DigitalWalletId, ed.TransactionAmount, " +
						"ed.UpdatedDate, ed.DG_HistoryId FROM Expense e LEFT JOIN ExpenseDetails ed ON e.ID = ed.ExpenseId" +
						" WHERE e.ID = " + expenseId + "";
						DataTable dtExpense = (DataTable)Select(sqlExpense).Data;
						int countDtExpense = dtExpense.Rows.Count;
						for (int i = 0; i < countDtExpense; i++)
						{
							int digitalWalletId = Convert.ToInt32(dtExpense.Rows[i]["DigitalWalletId"].ToString());
							long expenseDetailsId = Convert.ToInt64(dtExpense.Rows[i]["ed.ID"].ToString());
							long digitalWalletHistoryId = Convert.ToInt64(dtExpense.Rows[i]["DG_HistoryId"].ToString());
							double transactionAmount = Convert.ToDouble(dtExpense.Rows[i]["TransactionAmount"].ToString());

							string sqlDigitalWallet = @"Select Amount FROM DigitalWallet WHERE ID = " + digitalWalletId + "";
							DataTable dtDigitalWallet = (DataTable)Select(sqlDigitalWallet).Data;
							double amount = Convert.ToDouble(dtDigitalWallet.Rows[0]["Amount"].ToString());
							amount += transactionAmount;
							string sqlUpdateDigitalWallet = @"UPDATE DigitalWallet SET Amount = " + amount + " WHERE ID = " + digitalWalletId + "";
							CUD(sqlUpdateDigitalWallet);
							string sqlDigitalWalletHistory = "INSERT INTO DigitalWallet_History(DigitalWalletId, TransactionType, DetailPurpose, TransactedAmount, UpdatedDate, BalanceSheetId)" +
								"VALUES (" + digitalWalletId + ", 'DEPOSITED', 'DELETED EXPENSE DATA ADJUSTED', " + transactionAmount + ", '" + DateTime.Now + "', " + balanceSheetId + ")";
							CUD(sqlDigitalWalletHistory);
							var balanceSheet = BalanceSheet(balanceSheetId);
							double currentBalance = balanceSheet.Item1;
							double totalCredit = balanceSheet.Item2;
							double totalDebit = balanceSheet.Item4;
							double debitLiability = balanceSheet.Item5;

							string sqlUpdateBalanceSheet = @"UPDATE BalanceSheet SET CurrentBalance = " + (currentBalance + transactionAmount) + ", TotalCredit = " + (totalCredit + transactionAmount) + ", DebitLiability = " + (debitLiability) + "" +
								" WHERE ID = " + balanceSheetId + "";
							CUD(sqlUpdateBalanceSheet);
							string sqlDigitalWalletHistoryDelete = @"DELETE FROM DigitalWallet_History WHERE ID = " + digitalWalletHistoryId + "";
							CUD(sqlDigitalWalletHistoryDelete);
							string sqlExpenseDetailsDelete = @"DELETE FROM ExpenseDetails WHERE ID = " + expenseDetailsId + "";
							CUD(sqlExpenseDetailsDelete);
						}

						string sqlExpenseDelete = @"DELETE FROM Expense WHERE ID = " + expenseId + "";
						CUD(sqlExpenseDelete);
						btnSearch_Click(sender, e);

						//for (int i = 0; i < dtIPM.Rows.Count; i++)
						//{
						//    long inventoryPaymentMethodId = Convert.ToInt64(dtIPM.Rows[i]["ID"].ToString());
						//    long digitalWalletId = Convert.ToInt64(dtIPM.Rows[i]["DigitalWalletId"].ToString());
						//    double transactionAmount = Convert.ToDouble(dtIPM.Rows[i]["TransactionAmount"].ToString());
						//    //balanceSheetId = getMaxId("SELECT MAX(Id) FROM BalanceSheet");

						//    string sqlDigitalWallet = @"Select Amount FROM DigitalWallet WHERE ID = " + digitalWalletId + "";
						//    DataTable dtDigitalWallet = (DataTable)Select(sqlDigitalWallet).Data;
						//    double amount = Convert.ToDouble(dtDigitalWallet.Rows[0]["Amount"].ToString());
						//    amount += transactionAmount;
						//    string sqlUpdateDigitalWallet = @"UPDATE DigitalWallet SET Amount = " + amount + " WHERE ID = " + digitalWalletId + "";
						//    CUD(sqlUpdateDigitalWallet);
						//    string sqlDigitalWalletHistory = "INSERT INTO DigitalWallet_History(DigitalWalletId, TransactionType, DetailPurpose, TransactedAmount, UpdatedDate, BalanceSheetId)" +
						//        "VALUES (" + digitalWalletId + ", 'DEPOSITED', 'DELETED DATA ADJUSTED', " + transactionAmount + ", '" + DateTime.Now + "', " + balanceSheetId + ")";
						//    CUD(sqlDigitalWalletHistory);

						//    var balanceSheet = BalanceSheet(balanceSheetId);
						//    double currentBalance = balanceSheet.Item1;
						//    double totalDebit = balanceSheet.Item4;
						//    double debitLiability = balanceSheet.Item5;

						//    string sqlInventoryDue = @"SELECT Due FROM Inventory WHERE ID = " + inventoryId + "";
						//    DataTable dtInventoryDue = (DataTable)Select(sqlInventoryDue).Data;
						//    double due = Convert.ToDouble(dtInventoryDue.Rows[0]["Due"].ToString());
						//    string sqlUpdateBalanceSheet = @"UPDATE BalanceSheet SET CurrentBalance = " + (currentBalance + transactionAmount) + ", TotalDebit = " + (totalDebit - transactionAmount) + ", DebitLiability = " + (debitLiability - due) + "" +
						//        " WHERE ID = " + balanceSheetId + "";
						//    CUD(sqlUpdateBalanceSheet);

						//}

						//string sqlAllId = @"SELECT p.ID, pd.ID FROM ((ProductDetails pd LEFT JOIN Inventory i ON i.ID = pd.InventoryId)
						//LEFT JOIN Products p ON p.ID = pd.ProductID)
						//WHERE i.ID = " + inventoryId + "";
						//DataTable dtSqlAllId = (DataTable)Select(sqlAllId).Data;
						//for (int i = 0; i < dtSqlAllId.Rows.Count; i++)
						//{
						//    long productDetailsId = Convert.ToInt64(dtSqlAllId.Rows[i]["pd.ID"].ToString());
						//    long productId = Convert.ToInt64(dtSqlAllId.Rows[i]["p.ID"].ToString());

						//    string sqlDeleteProduct = @"DELETE FROM Products WHERE ID = " + productId + "";
						//    CUD(sqlDeleteProduct);
						//    string sqlDeleteProductDetails = @"DELETE FROM ProductDetails WHERE ID = " + productDetailsId + "";
						//    CUD(sqlDeleteProductDetails);

						//}

						//string sqlDeleteInventory = @"DELETE FROM Inventory WHERE ID = " + inventoryId + "";
						//CUD(sqlDeleteInventory);

						//getInventoryInvoice(sql);
					}
					//string sqlWalletIds = "SELECT DigitalWalletId, TransactionAmount FROM Inventory_Payment_Methods WHERE InventoryId = " + inventoryId + "";

				}
			}
        }

        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {

			if (tableLayoutPanel1.Size.Width < 919)
			{
				groupBox1.Size = new System.Drawing.Size(919, 559);
				groupBox1.Dock = DockStyle.None;
				//groupBox1.Dock = DockStyle.None;
			}

			else if(tableLayoutPanel1.Size.Width >= 919)
			{
				groupBox1.Dock = DockStyle.Fill;
				//groupBox1.Dock = DockStyle.Fill;
			}
		}

        private void groupBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
			Calculation();
        }
    }
}
