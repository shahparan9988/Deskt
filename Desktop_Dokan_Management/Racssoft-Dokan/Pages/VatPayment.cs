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
    public partial class VatPayment : Common
    {

        //Payment Method
        List<int> isComboAdded = new List<int>();
        Dictionary<int, Label> isAddedLabel = new Dictionary<int, Label>();
        Dictionary<int, NumericUpDown> isAddedTextBox = new Dictionary<int, NumericUpDown>();
        Dictionary<int, Button> isAddedButton = new Dictionary<int, Button>();
        Dictionary<int, string> paymentMethods = new Dictionary<int, string>();
		List<int> listOfId;

		public VatPayment(double customerGivenVat, double sellerGivenVat, double dueVat, List <int> listOfIds)
        {
            InitializeComponent();
			Initial(customerGivenVat, sellerGivenVat, dueVat, listOfIds);
        }

        void Initial(double customerGivenVat, double sellerGivenVat, double dueVat, List<int> listOfIds)
        {
			listOfId = listOfIds;
			labelCollectedVat.Text = System.Math.Round(customerGivenVat, 1).ToString();
			labelPaidVat.Text = System.Math.Round(sellerGivenVat, 1).ToString();
			labelDueVat.Text = System.Math.Round(dueVat, 1).ToString();

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
			Calculation();
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
			Calculation();
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
			textBox.DecimalPlaces = 2;


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
			//textBox.ValueChanged += new System.EventHandler(this.numericAmount_ValueChanged);
			//textBox.Click += new System.EventHandler(this.textBox_Click);



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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
			double totalAmount = 0, transactedAmount = 0;
			DateTime date = DateTime.Parse(dateTimePickerVatPayment.Value.ToString());

			foreach (KeyValuePair<int, NumericUpDown> d in isAddedTextBox)
			{
				transactedAmount = Convert.ToDouble(Convert.ToString(d.Value.Value));
				totalAmount += transactedAmount;

			}

			double dueVat = Convert.ToDouble(labelDueVat.Text);

			if ((dueVat + 1) > totalAmount && totalAmount >= dueVat)
			{
				int countListItem = 0;
				countListItem = listOfId.Count;
				for (int i = 0; i < countListItem; i++)
				{
					string sql1 = @"SELECT s.ID, d.ID, d.Quantity, d.GivenVat, d.VatPaid, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                               pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE
                                s.ID = " + listOfId[i] + "";
					VatCalculator(sql1);
				}

                double cost = 0;
                long balanceSheetId = getMaxId("SELECT MAX(Id) FROM BalanceSheet");


                string sqlVatManage = @"INSERT INTO VatManage(Amount, CreatedDate, BalanceSheetId) VALUES (" + totalAmount + "," +
                    "'" + date + "', " + balanceSheetId + ")";
                CUD(sqlVatManage);
                long vatManageId = getMaxId("SELECT MAX(Id) FROM VatManage");




                foreach (KeyValuePair<int, NumericUpDown> d in isAddedTextBox)
                {
                    var balanceSheet = BalanceSheet(balanceSheetId);
                    double currentBalance = balanceSheet.Item1;
                    double totalDebit = balanceSheet.Item4;
                    //double debitLiability = balanceSheet.Item5;
                    int digitalWalletId = Convert.ToInt32(d.Key);
                    double transactionAmount = Convert.ToDouble(Convert.ToString(d.Value.Value));

                    string dGHistorySql = @"INSERT INTO DigitalWallet_History(DigitalWalletId, TransactionType, DetailPurpose, TransactedAmount, UpdatedDate, BalanceSheetId)
				VALUES(" + digitalWalletId + ", 'WITHDRAWN', 'VAT PAYMENT', " + transactionAmount + ", '" + date + "', " + balanceSheetId + ")";
                    CUD(dGHistorySql);
                    long dgHistoryId = getMaxId("SELECT MAX(Id) FROM DigitalWallet_History");

                    string sql = @"INSERT INTO VatManage_Payment_Methods(VatManageId, DigitalWalletId, TransactionAmount, UpdatedDate, DG_HistoryId)
									VALUES(" + vatManageId + ", " + digitalWalletId + ", " + transactionAmount + ", '" + date + "', " + dgHistoryId + ")";
                    CUD(sql);
                    string sqlGetAmount = @"SELECT * FROM DigitalWallet WHERE ID = " + digitalWalletId + "";
                    DataTable dt = (DataTable)Select(sqlGetAmount).Data;
                    double amount = 0;
					int dtRows = 0;
					dtRows = dt.Rows.Count;
                    if (dtRows > 0)
                    {
                        amount = Convert.ToDouble(dt.Rows[0]["Amount"]);

                    }

                    amount = amount - transactionAmount;
                    string sqlUpdateAmount = @"UPDATE DigitalWallet SET Amount = " + amount + " WHERE ID = " + digitalWalletId + "";
                    CUD(sqlUpdateAmount);
                    double totalBalance = DigitalWalletBalance();
                    string sqlUpdateBalanceSheet = @"UPDATE BalanceSheet SET CurrentBalance = " + totalBalance + "," +
                        " TotalDebit = " + (totalDebit + transactionAmount) + " WHERE ID = " + balanceSheetId + "";
                    CUD(sqlUpdateBalanceSheet);
                }
                MessageBox.Show("Saved Successfully!!!");
				this.Close();
            }
            else
            {
				MessageBox.Show("Please, Submit exact due amount!!!");
            }
		}

		void Calculation()
		{
			//double amount = Convert.ToDouble(numericAmount.Value);
			double paidAmount = 0;

			foreach (KeyValuePair<int, NumericUpDown> d in isAddedTextBox)
			{
				//int digitalWalletId = Convert.ToInt32(d.Key) + 1;
				double transactionAmount = Convert.ToDouble(Convert.ToString(d.Value.Value));
				paidAmount = paidAmount + transactionAmount;
			}
			numericUpDownAmount.Value = Convert.ToDecimal(paidAmount);
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

		void VatCalculator(string sql)
		{
			double soldQuantity = 0, totalQuantity = 0, customerGivenVat = 0, vatPaid = 0, pdGivenVat = 0, sellerGivenVat = 0;
			int salesDetailsId = 0, salesId = 0;
			string sqlSales, sqlSalesDetails;
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
				//costPerUnit = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["CostPerUnit"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["CostPerUnit"]) : 0;
				//costPerUnit = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? Convert.ToDouble(dt.Rows[0][2]) : 0;
				//soldQuantity = Convert.ToDouble(dt1.Rows[i]["Quantity"]);
				soldQuantity = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["Quantity"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["Quantity"]) : 0;
				
				//totalQuantity = Convert.ToDouble(dt1.Rows[i]["TotalQuantity"]);
				totalQuantity = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["TotalQuantity"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["TotalQuantity"]) : 0;
				//totalCostPerUnit = totalCostPerUnit + (costPerUnit * soldQuantity);
				//totalSellingPrice = totalSellingPrice + Convert.ToDouble(dt1.Rows[i]["TotalPrice"]);
				//totalSellingPrice = totalSellingPrice + (dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["TotalPrice"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["TotalPrice"]) : 0);
				//customerGivenVat = customerGivenVat + Convert.ToDouble(dt1.Rows[i]["d.GivenVat"]);
				customerGivenVat = (dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["d.GivenVat"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["d.GivenVat"]) : 0);
				//vatPaid = (dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["VatPaid"].ToString()) ? Convert.ToDouble(dt1.Rows[i]["VatPaid"]) : 0);
				//sellerGivenVat = sellerGivenVat + ((Convert.ToDouble(dt1.Rows[i]["pd.GivenVat"]) / totalQuantity) * soldQuantity);
				pdGivenVat = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["pd.GivenVat"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["pd.GivenVat"]) : 0;
				sellerGivenVat =  ((pdGivenVat) / totalQuantity) * soldQuantity;
				vatPaid = customerGivenVat - sellerGivenVat;
				salesDetailsId = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["d.ID"].ToString()) ? Convert.ToInt32(dt1.Rows[i]["d.ID"]) : 0;
				salesId = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["s.ID"].ToString()) ? Convert.ToInt32(dt1.Rows[i]["s.ID"]) : 0;

				sqlSales = @"UPDATE Sales SET IsVatPaid = " + true + " WHERE ID = " + salesId + "";
				CUD(sqlSales);
				sqlSalesDetails = @"UPDATE SalesDetails SET VatPaid = " + vatPaid + ", VatPaidDate = '" + DateTime.Parse(dateTimePickerVatPayment.Value.ToString()) + "' WHERE ID = " + salesDetailsId + "";
				CUD(sqlSalesDetails);

				









				//quantity = Convert.ToDouble(dt1.Rows[i]["Quantity"]);
				//if (dt1.Rows[i]["SellingPrice"] != DBNull.Value) sellingPrice = sellingPrice + (Convert.ToDouble(dt1.Rows[i]["SellingPrice"])*quantity);
			}

			//profit = totalSellingPrice - totalCostPerUnit;
			//lblCollectedVat.Text = Convert.ToString(customerGivenVat);
			//lblPaidVat.Text = Convert.ToString(sellerGivenVat);
			//dueVat = customerGivenVat - sellerGivenVat;

			//lblDueVat.Text = Convert.ToString(Math.Round(dueVat, 2));


			//lblTotalProfit.Text = Convert.ToString(Math.Round(profit, 2));
			//lblTotalCost.Text = Convert.ToString(Math.Round(totalCostPerUnit, 2));

		}

        private void VatPayment_MouseCaptureChanged(object sender, EventArgs e)
        {
			Calculation();
        }
    }
}
