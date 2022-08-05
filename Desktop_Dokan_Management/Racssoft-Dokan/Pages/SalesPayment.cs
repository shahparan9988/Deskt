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
    public partial class SalesPayment : Common
    {

		public static long salesId;
		public static double paidAmount;

		//Payment Method
		List<int> isComboAdded = new List<int>();
		List<(int, Label)> isAddedLabel = new List<(int, Label)>();
		List<(int, NumericUpDown)> isAddedTextBox = new List<(int, NumericUpDown)>();
		List<(int, Button)> isAddedButton = new List<(int, Button)>();
		Dictionary<int, string> paymentMethods;

		public SalesPayment(long id)
		{
			InitializeComponent();
			salesId = id;
			dgPaymentHistoryLoad(salesId);
			dgProductLists(salesId);
			Initial();
			paymentMethods = getPaymentMethod();
			comboPaymentMethod.Items.AddRange(getPaymentMethod().Select(s => s.Value).ToArray());

		}

		void Initial()
		{
			string sql = @"SELECT s.ID, s.Invoice, d.VatPaid, p.TotalQuantity, pd.GivenVat, d.VatPaidDate, d.GivenVat, d.Quantity, c.CustomerName, c.CustomerMobile, s.TotalPayable, s.Discount, s.Due, s.Vat, s.CreatedDate 
            FROM ((((Sales s LEFT JOIN Customer c ON s.CustomerId = c.ID) LEFT JOIN SalesDetails d ON d.SalesId = s.ID)
			LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON pd.ProductID = p.ID)
			WHERE s.ID = " + salesId + "";
			DataTable dt = (DataTable)Select(sql).Data;
			lblInvoiceNo.Text = dt.Rows[0]["Invoice"].ToString();
			lblCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
			lblCustomerMobile.Text = dt.Rows[0]["CustomerMobile"].ToString();
			lblPayableAmount.Text = dt.Rows[0]["TotalPayable"].ToString();
			lblDue.Text = dt.Rows[0]["Due"].ToString();
			lblPaidAmount.Text = (Convert.ToDouble(lblPayableAmount.Text) - Convert.ToDouble(lblDue.Text)).ToString();
			lblDiscount.Text = dt.Rows[0]["Discount"].ToString();
			lblVat.Text = dt.Rows[0]["Vat"].ToString();
			
			lblCreatedDate.Text = dt.Rows[0]["CreatedDate"].ToString();
			int rowCount = 0;
			double customerGivenVat = 0, vatPaid = 0, totalQuantity = 0, quantity = 0, dueVat = 0, pdGivenVat = 0, sellerGivenVat = 0;
			rowCount = dt.Rows.Count;
			for(int i = 0; i < rowCount; i++)
            {
				quantity = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[i]["Quantity"].ToString()) ? Convert.ToInt64(dt.Rows[i]["Quantity"]) : 0;
				totalQuantity = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[i]["TotalQuantity"].ToString()) ? Convert.ToInt64(dt.Rows[i]["TotalQuantity"]) : 0;
				customerGivenVat = customerGivenVat + (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[i]["d.GivenVat"].ToString()) ? Convert.ToInt64(dt.Rows[i]["d.GivenVat"]) : 0);
				vatPaid = vatPaid + (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[i]["VatPaid"].ToString()) ? Convert.ToDouble(dt.Rows[i]["VatPaid"]) : 0);
				pdGivenVat = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[i]["pd.GivenVat"].ToString()) ? Convert.ToInt64(dt.Rows[i]["pd.GivenVat"]) : 0;
				sellerGivenVat = sellerGivenVat + vatPaid + ((pdGivenVat) / totalQuantity) * quantity;
			}

			lblVat.Text = Convert.ToString(customerGivenVat);
			lblVatPaid.Text = Convert.ToString(sellerGivenVat);
			dueVat = customerGivenVat - sellerGivenVat;

			//lblDueVat.Text = Convert.ToString(Math.Round(dueVat, 2));
			//lblUpdatedDate.Text = dt.Rows[0]["UpdatedDate"].ToString();
			//payableAmount = Convert.ToDouble(dt.Rows[0]["PaidAmount"]) + Convert.ToDouble(dt.Rows[0]["Due"]);
			//lblPayableAmount.Text = payableAmount.ToString();


		}
		Dictionary<int, string> getPaymentMethod()
		{
			string sql = "Select * FROM DigitalWallet";
			DataTable dt = (DataTable)Select(sql).Data;
			return dt.AsEnumerable()
	  .ToDictionary<DataRow, int, string>(row => row.Field<int>(0),
								row => row.Field<string>(1) + "--" + row.Field<string>(2));
			//Dictionary<int, string> units = new Dictionary<int, string>();
			//foreach(DataRow r in dt.Rows)
			//         {

			//         }

		}

		void dgProductLists(long salesId)
		{
			string sqlProducts = @"SELECT p.Name, c.Title AS [Category], b.Title AS [Brand], sd.Quantity, sd.SellingPrice AS [Unit Price], sd.TotalPrice AS [Price], sd.Discount FROM ((((Sales s
			LEFT JOIN SalesDetails sd ON sd.SalesId = s.ID) LEFT JOIN Products p ON sd.ProductId = p.ID)
			LEFT JOIN Category c ON c.ID = p.CategoryId) LEFT JOIN Brand b ON b.ID = p.BrandId)			
			WHERE s.ID = " + salesId + "";
			DataTable dtProducts = (DataTable)Select(sqlProducts).Data;
			dgProducts.Refresh();
			dgProducts.DataSource = dtProducts;
			dgProducts.AutoGenerateColumns = false;
			//datagridviewProductsResize();


		}

		void datagridviewProductsResize()
		{
			//dgProducts.Columns[-1].Width = 10;
			dgProducts.Columns[0].Width = 65;
			dgProducts.Columns[1].Width = 48;
			dgProducts.Columns[2].Width = 65;
			dgProducts.Columns[3].Width = 65;
			dgProducts.Columns[4].Width = 60;
		}


		void dgPaymentHistoryLoad(long salesId)
		{
			string sqlDuePaymentHistory = @"SELECT dw.Title, dw.AccountNo AS [A/C No], spm.TransactionAmount AS [Amount], spm.UpdatedDate AS [Date] FROM Sales_Payment_Methods spm LEFT JOIN DigitalWallet dw
			ON spm.DigitalWalletId = dw.ID WHERE SalesId = " + salesId + "";
			DataTable dtDuePaymentHistory = (DataTable)Select(sqlDuePaymentHistory).Data;
			dgPaymentHistory.Refresh();
			dgPaymentHistory.DataSource = dtDuePaymentHistory;
			dgPaymentHistory.AutoGenerateColumns = false;
			datagridviewResize();


		}

		void datagridviewResize()
		{
			dgPaymentHistory.Columns[0].Width = 50;
			dgPaymentHistory.Columns[1].Width = 75;
			dgPaymentHistory.Columns[2].Width = 65;
		}

		// Payment Method
		//
		//
		//
		//
		//
		//
		//
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			//string a = paymentMethods.g(comboPaymentMethod.SelectedItem.ToString());
			string unit1 = comboPaymentMethod.SelectedItem.ToString();
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
			addWallet(comboPaymentMethod.Items[comboPaymentMethod.SelectedIndex].ToString(), itemKey);
		}
		void addWallet(string walletName, int i)
		{
			//if (isComboAdded.Where(w => w == i).ToList().Count > 0) return;

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
			//var item = (1, textBox) ;
			isAddedTextBox.Add((i, textBox));
			isAddedLabel.Add((i, label));
			isAddedButton.Add((i, delete));
			setLocation(isAddedLabel, isAddedTextBox, isAddedButton);
			this.panelPaymentWays.Controls.Add(textBox);
			this.panelPaymentWays.Controls.Add(label);
			this.panelPaymentWays.Controls.Add(delete);
			delete.Click += new System.EventHandler(this.deleteButton_Click_1);
			textBox.ValueChanged += new System.EventHandler(this.txtPrice_ValueChanged);
			textBox.Click += new System.EventHandler(this.textBox_Click);



			//count++;

		}

		void addWalletEdit(string walletName, int i, double amount)
		{
			//if (isComboAdded.Where(w => w == i).ToList().Count > 0) return;

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
			textBox.Value = Convert.ToDecimal(amount);

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
			isAddedTextBox.Add((i, textBox));
			isAddedLabel.Add((i, label));
			isAddedButton.Add((i, delete));
			setLocation(isAddedLabel, isAddedTextBox, isAddedButton);
			this.panelPaymentWays.Controls.Add(textBox);
			this.panelPaymentWays.Controls.Add(label);
			this.panelPaymentWays.Controls.Add(delete);
			delete.Click += new System.EventHandler(this.deleteButton_Click_1);
			textBox.ValueChanged += new System.EventHandler(this.txtPrice_ValueChanged);
			textBox.Click += new System.EventHandler(this.textBox_Click);



			//count++;

		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			string m = "this.textBox" + "2";
			//this.panel1.Controls.Remove(Convert.m);
			//this.panel1.Controls.Remove(this.label2);

			string[] s = "s_1".Split('_');

			int i = Convert.ToInt32(s[1]);
			isComboAdded.Remove(i);
		}

		private void deleteButton_Click_1(object sender, EventArgs e)
		{
			var button = (Button)sender;
			string[] s = button.Name.Split('_');

			int i = Convert.ToInt32(s[1]);
			//int locationY = button.Location.Y;
			int index = (button.Location.Y - 10) / 22;
			isComboAdded.Remove(index);
			this.panelPaymentWays.Controls.Remove(isAddedButton[index].Item2);
			isAddedButton.Remove((isAddedButton[index]));
			this.panelPaymentWays.Controls.Remove(isAddedLabel[index].Item2);
			isAddedLabel.Remove((isAddedLabel[index]));
			this.panelPaymentWays.Controls.Remove(isAddedTextBox[index].Item2);
			isAddedTextBox.Remove((isAddedTextBox[index]));
			setLocation(isAddedLabel, isAddedTextBox, isAddedButton);
			calculation();
			//this.panel1.Controls.Remove(isAddedTextBox[i]);
			//if (isAddedLabel.Where(w => w.Name == "label_" + i).ToList().Count > 0) this.panel1.Controls.Remove(w);

			//this.panel1.Where(w => w.name == "textBox_" + i).Remove(w);
			//isAddedTextBox.Remove(isAddedTextBox[i]);
			//this.panel1.Controls.Remove(isAddedLabel[i]);
			//isAddedLabel.Remove(isAddedLabel[i]);
			// this.panel1.Controls.Remove("this.textBox + s[1]");




		}

		void setLocation(List<(int, Label)> labels, List<(int, NumericUpDown)> textBoxes, List<(int, Button)> buttons)
		{
			for (int i = 0; i < labels.Count; i++)
			{
				labels[i].Item2.Location = new System.Drawing.Point(15, 10 + i * 22);
				textBoxes[i].Item2.Location = new System.Drawing.Point(123, 10 + i * 22);
				buttons[i].Item2.Location = new System.Drawing.Point(225, 10 + i * 22);
			}
		}

		private void txtPrice_ValueChanged(object sender, EventArgs e)
		{
			calculation();
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

		void calculation()
		{
			double payableAmount = Convert.ToDouble(lblPayableAmount.Text);
			double paidAmount = Convert.ToDouble(lblPaidAmount.Text);
			double due = Convert.ToDouble(lblDue.Text);


			for (int i = 0; i < isAddedTextBox.Count; i++)
			{
				if (Convert.ToString(isAddedTextBox[i].Item2.Text) == "")
				{
					isComboAdded.Remove(i);
					this.panelPaymentWays.Controls.Remove(isAddedButton[i].Item2);
					isAddedButton.Remove((isAddedButton[i]));
					this.panelPaymentWays.Controls.Remove(isAddedLabel[i].Item2);
					isAddedLabel.Remove((isAddedLabel[i]));
					this.panelPaymentWays.Controls.Remove(isAddedTextBox[i].Item2);
					isAddedTextBox.Remove((isAddedTextBox[i]));
					setLocation(isAddedLabel, isAddedTextBox, isAddedButton);
					i--;
					continue;
				}

				//int digitalWalletId = Convert.ToInt32(d.Key) + 1;
				double transactionAmount = !string.IsNullOrEmpty(Convert.ToString(isAddedTextBox[i].Item2.Text)) ? Convert.ToDouble(Convert.ToString(isAddedTextBox[i].Item2.Value)) : 0;
				
				paidAmount = paidAmount + transactionAmount;

			}

			

			lblDue.Text = (payableAmount - paidAmount).ToString();
			//lblPaidAmount.Text = paidAmount.ToString();

		}

		private void groupBox1_MouseCaptureChanged(object sender, EventArgs e)
		{
			calculation();
		}

		private void groupBox2_MouseCaptureChanged(object sender, EventArgs e)
		{
			calculation();
		}

		private void panelPaymentWays_MouseCaptureChanged(object sender, EventArgs e)
		{
			calculation();
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
		private void btnSave_Click(object sender, EventArgs e)
		{
			
			if (Convert.ToDouble(lblDue.Text.ToString()) >= 0)
			{
				calculation();
				double due = Convert.ToDouble(lblDue.Text);
				//double paidAmount = payableAmount - due;

				string sqlSales = @"UPDATE Sales SET Due = " + due + " WHERE ID = " + salesId + "";
				CUD(sqlSales);

				///////  BalanceSheeet Update ///////
				long balanceSheetId = getMaxId("SELECT MAX(Id) FROM BalanceSheet");
				var balanceSheet = BalanceSheet(balanceSheetId);
				double currentBalance = balanceSheet.Item1;
				double totalCredit = balanceSheet.Item2;
				double creditLiability = balanceSheet.Item3;
				//double d = 

				for (int i = 0; i < isAddedTextBox.Count; i++)
				{

					int digitalWalletId = Convert.ToInt32(isAddedTextBox[i].Item1);
					double transactionAmount = Convert.ToDouble(Convert.ToString(isAddedTextBox[i].Item2.Value));

					string dGHistorySql = @"INSERT INTO DigitalWallet_History(DigitalWalletId, TransactionType, DetailPurpose, TransactedAmount, UpdatedDate, BalanceSheetId)
				VALUES(" + digitalWalletId + ", 'DEPOSITED', 'SALES DUE PAYMENT', " + transactionAmount + ", '" + DateTime.Now + "', " + balanceSheetId + ")";
					CUD(dGHistorySql);
					long dgHistoryId = getMaxId("SELECT MAX(Id) FROM DigitalWallet_History");

					string sql = @"INSERT INTO Sales_Payment_Methods(SalesId, DigitalWalletId, TransactionAmount, BalanceSheetId, UpdatedDate, DG_HistoryId)
									VALUES(" + salesId + ", " + digitalWalletId + ", " + transactionAmount + ", " + balanceSheetId + ", '" + DateTime.Now + "', " + dgHistoryId + ")";
					CUD(sql);
					string sqlGetAmount = @"SELECT * FROM DigitalWallet WHERE ID = " + digitalWalletId + "";
					DataTable dt = (DataTable)Select(sqlGetAmount).Data;
					double amount = 0;
					if (dt.Rows.Count > 0)
					{
						amount = Convert.ToDouble(dt.Rows[0]["Amount"]);

					}

					amount = amount + transactionAmount;
					string sqlUpdateAmount = @"UPDATE DigitalWallet SET Amount = " + amount + " WHERE ID = " + digitalWalletId + "";
					CUD(sqlUpdateAmount);
					double totalBalance = DigitalWalletBalance();
					string sqlUpdateBalanceSheet = @"UPDATE BalanceSheet SET CurrentBalance = " + totalBalance + "," +
						" TotalCredit = " + (totalCredit + transactionAmount) + ", CreditLiability = " + (creditLiability - transactionAmount) + " WHERE Id = " + balanceSheetId + "";
					CUD(sqlUpdateBalanceSheet);

					
					//this.Close();

				}
				panelPaymentWays.Controls.Clear();
				isAddedButton.Clear();
				isAddedLabel.Clear();
				isAddedTextBox.Clear();
				Initial();
				dgPaymentHistoryLoad(salesId);
			}


			else
			{
				MessageBox.Show("You are paying more money than payable amount. Pay the amount that is mentioned in due field!!!");
				panelPaymentWays.Controls.Clear();
				isAddedButton.Clear();
				isAddedLabel.Clear();
				isAddedTextBox.Clear();
				calculation();
			}
		}
	}
}


