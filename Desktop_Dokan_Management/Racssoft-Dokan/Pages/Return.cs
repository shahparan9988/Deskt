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
    public partial class Return : Common
    {
        static long productDetailsId;
        static long productIds;


        //Payment Method
        List<int> isComboAdded = new List<int>();
        List<(int, Label)> isAddedLabel = new List<(int, Label)>();
        List<(int, NumericUpDown)> isAddedTextBox = new List<(int, NumericUpDown)>();
        List<(int, Button)> isAddedButton = new List<(int, Button)>();
        Dictionary<int, string> paymentMethods;

        public Return(long productId)
        {
            InitializeComponent();
            Initial(productId);
        }

        void Initial(long productId)
        {


            paymentMethods = getPaymentMethod();
            comboPaymentMethod.Items.AddRange(getPaymentMethod().Select(s => s.Value).ToArray());


            string sql = @"SELECT * FROM Products p LEFT JOIN ProductDetails d ON d.ProductId = p.ID WHERE p.ID = " + productId + "";
            DataTable dt = (DataTable)Select(sql).Data;
            productDetailsId = !string.IsNullOrEmpty(dt.Rows[0]["d.ID"].ToString()) ? Convert.ToInt64(dt.Rows[0]["d.ID"].ToString()) : 0;
            productIds = !string.IsNullOrEmpty(dt.Rows[0]["p.ID"].ToString()) ? Convert.ToInt64(dt.Rows[0]["p.ID"].ToString()) : 0;
            lblProductName.Text = !string.IsNullOrEmpty(dt.Rows[0]["Name"].ToString()) ? dt.Rows[0]["Name"].ToString() : "";
            lblProductCode.Text = !string.IsNullOrEmpty(dt.Rows[0]["ItemCode"].ToString()) ? dt.Rows[0]["ItemCode"].ToString() : "";
            lblProductQuantity.Text = !string.IsNullOrEmpty(dt.Rows[0]["TotalQuantity"].ToString()) ? dt.Rows[0]["TotalQuantity"].ToString() : "0";
            lblRemainQuantity.Text = !string.IsNullOrEmpty(dt.Rows[0]["RemainQuantity"].ToString()) ? dt.Rows[0]["RemainQuantity"].ToString() : "0";
            lblBuyingPrice.Text = !string.IsNullOrEmpty(dt.Rows[0]["PriceAfterDiscount"].ToString()) ? dt.Rows[0]["PriceAfterDiscount"].ToString() : "0";

            numericReturnUnitPrice.Value = Convert.ToDecimal(lblBuyingPrice.Text);



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

			double paidAmount = 0;
			for (int i = 0; i < isAddedTextBox.Count; i++)
			{

				//int digitalWalletId = Convert.ToInt32(d.Key) + 1;
				double transactionAmount = Convert.ToDouble(Convert.ToString(isAddedTextBox[i].Item2.Value));
				paidAmount = paidAmount + transactionAmount;
			}

			numericTotalReturn.Value = Convert.ToDecimal(paidAmount);


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

		private void btnSave_Click(object sender, EventArgs e)
        {
            
            double returnQuantity = Convert.ToDouble(numericReturnQuantity.Value);
            double totalQuantity = Convert.ToDouble(lblProductQuantity.Text);
            double remainQuantity = Convert.ToDouble(lblRemainQuantity.Text);
			double totalPaidReturnPrice = Convert.ToDouble(numericTotalReturn.Value);
			double due = Convert.ToDouble(numericDue.Value);
            //double remainQuantity = Convert.ToDouble(lblRemainQuantity);

            string sqlUpdate = "UPDATE ProductDetails SET RemainQuantity = " + (remainQuantity - returnQuantity) + " WHERE ID = " + productDetailsId + "";
            CUD(sqlUpdate);
			string sqlUpdateDuplicate = "UPDATE ProductDetails_1 SET RemainQuantity = " + (remainQuantity - returnQuantity) + " WHERE ID = " + productDetailsId + "";
			CUD(sqlUpdateDuplicate);
			string sqlReturnProduct = "INSERT INTO ReturnProducts(ProductId, ReturnUnitPrice, TotalPaidReturnPrice, Due, ReturnQuantity, CreatedDate)" +
                "VALUES (" + productIds + ", " + numericReturnUnitPrice.Value + ", " + totalPaidReturnPrice + ", " + due + ", " + returnQuantity + ", '" + DateTime.Now + "')";
            CUD(sqlReturnProduct);

			long returnProductId = getMaxId("SELECT MAX(Id) FROM ReturnProducts");
			long balanceSheetId = getMaxId("SELECT MAX(Id) FROM BalanceSheet");
			var balanceSheet = BalanceSheet(balanceSheetId);
			double currentBalance = balanceSheet.Item1;
			double totalCredit = balanceSheet.Item2;
			double creditLiability = balanceSheet.Item3;

			/////////////////////////////
			for (int i = 0; i < isAddedTextBox.Count; i++)
			{

				int digitalWalletId = Convert.ToInt32(isAddedTextBox[i].Item1);
				double transactionAmount = Convert.ToDouble(Convert.ToString(isAddedTextBox[i].Item2.Value));

				string dGHistorySql = @"INSERT INTO DigitalWallet_History(DigitalWalletId, TransactionType, DetailPurpose, TransactedAmount, UpdatedDate, BalanceSheetId)
				VALUES(" + digitalWalletId + ", 'DEPOSITED', 'RETURN PRODUCT PAYEMENT', " + transactionAmount + ", '" + DateTime.Now + "', " + balanceSheetId + ")";
				CUD(dGHistorySql);
				long dgHistoryId = getMaxId("SELECT MAX(Id) FROM DigitalWallet_History");

				string sql = @"INSERT INTO ReturnProduct_Payment_Methods(ReturnProductId, DigitalWalletId, TransactedAmount, BalanceSheetId, DG_HistoryId)
									VALUES(" + returnProductId + ", " + digitalWalletId + ", " + transactionAmount + ", " + balanceSheetId + ", " + dgHistoryId + ")";
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
					" TotalCredit = " + (totalCredit + transactionAmount) + ", CreditLiability = " + (creditLiability + due) + " WHERE ID = " + balanceSheetId + "";
				CUD(sqlUpdateBalanceSheet);
				panelPaymentWays.Controls.Clear();

			}


			//string sql


			this.Close();
        }

        private void groupBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
			calculation();
        }

        private void panelPaymentWays_Enter(object sender, EventArgs e)
        {
			calculation();
        }

        private void panelPaymentWays_Click(object sender, EventArgs e)
        {
			calculation();
		}
    }
}
