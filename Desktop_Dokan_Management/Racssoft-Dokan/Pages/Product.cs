using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp;
using Model;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racssoft_Dokan.Pages
{
	public partial class Product : Common
	{
		Dictionary<int, string> allProduct;
		Dictionary<int, string> allSuppliers;
		List<string> productName;
		static long productId;
		static long supplierId;
		static long count;
		List<long> productIds;
		List<long> supplierIds;
		Dictionary<int, string> units;
		

		//Payment Method
		List<int> isComboAdded = new List<int>();
		List<(int, Label)> isAddedLabel = new List<(int, Label)>();
		List<(int, NumericUpDown)> isAddedTextBox = new List<(int, NumericUpDown)>();
		List<(int, Button)> isAddedButton = new List<(int, Button)>();
		Dictionary<int, string> paymentMethods;

		void Initial()
		{
			//allProduct = new Dictionary<int, string>();
			//Common common = new Common();
			string sql = @"SELECT p.Id, p.Name, p.ItemCode, TotalQuantity, p.Price, d.SellingPrice, u.Title AS SellingUnit, n.Title AS BuyingUnit
FROM ((Products AS p LEFT JOIN ProductDetails AS d ON p.ID = d.ProductId) LEFT JOIN Units AS u ON d.UnitId = u.ID)  LEFT JOIN Units AS n ON p.UnitId = n.ID";
			DataTable dt = (DataTable)Select(sql).Data;

			string vatSql = @"SELECT ID, Title, Vat FROM SetVat";
			DataTable dtVat = (DataTable)Select(vatSql).Data;
			decimal vatValue = Convert.ToDecimal(dtVat.Rows[0]["Vat"]);
			txtVatAll.Value = vatValue;
			radioBtnInclusive.Checked = true;
			lblMessage.Text = "";

			//dgProductItem Load 
			dgProductItemLoad();

			txtName.AutoCompleteMode = AutoCompleteMode.None;
			txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
			productName = new List<string>();
			this.ActiveControl = txtName;
			productName = allProduct.Select(w => w.Value).ToList();
			hideResults();
			//this.lbAutoComplete.Location = new System.Drawing.Point(327, 29);
			this.lbAutoComplete.Size = new System.Drawing.Size(154, 82);

			this.lbAutoCompleteSupplier.Location = new System.Drawing.Point(27, 29);
			this.lbAutoCompleteSupplier.Size = new System.Drawing.Size(261, 82);

			txtCode.Text = "item-#" + (getProductId() + 1);
			txtInvoice.Text = "INVOICE-#" + (getInventoryId() + 1);
			count = getProductId() + 1;
			units = getUnits();
			paymentMethods = getPaymentMethod();
			cmbUnit.Items.AddRange(getUnits().Select(s => s.Value).ToArray());
			cmbUnitForBuy.Items.AddRange(getUnits().Select(s => s.Value).ToArray());
			comboPaymentMethod.Items.AddRange(getPaymentMethod().Select(s => s.Value).ToArray());
		}
		public Product()
		{
			InitializeComponent();

			
		}
		long getProductId()
		{
			//Connection con = new Connection();
			DataTable dt;
			string cmd = "SELECT MAX(Id) FROM Products";
			dt = (DataTable)Select(cmd).Data;
			long id = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()) ? Convert.ToInt64(dt.Rows[0][0]) : 0;
			return id;
		}

		long getInventoryId()
		{
			//Connection con = new Connection();
			DataTable dt;
			string cmd = "SELECT MAX(Id) FROM Inventory";
			dt = (DataTable)Select(cmd).Data;
			long id = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()) ? Convert.ToInt64(dt.Rows[0][0]) : 0;
			return id;
		}

		Dictionary<int, string> getUnits()
        {
			string sql = "Select * FROM Units";
			DataTable dt = (DataTable)Select(sql).Data;
			return dt.AsEnumerable()
	  .ToDictionary<DataRow, int, string>(row => row.Field<int>(0),
								row => row.Field<string>(1));
			//Dictionary<int, string> units = new Dictionary<int, string>();
			//foreach(DataRow r in dt.Rows)
			//         {

			//         }

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
		Dictionary<int, string> getProducts()
        {
			string sql = "Select * FROM Products";
			DataTable dt = (DataTable)Select(sql).Data;
			return dt.AsEnumerable()
	  .ToDictionary<DataRow, int, string>(row => row.Field<int>(0),
								row => row.Field<string>(1));
		}

		Dictionary<int, string> getSuppliers()
		{
			string sql = "Select * FROM Suppliers";
			DataTable dt = (DataTable)Select(sql).Data;
			return dt.AsEnumerable()
	  .ToDictionary<DataRow, int, string>(row => row.Field<int>(0),
								row => row.Field<string>(1)); // + " " + row.Field<string>(2) + " " + row.Field<string>(4));
		}

		private void txtName_TextChanged(object sender, EventArgs e)
		{
			if (txtName.Focused)
			{
				lbAutoComplete.Items.Clear();
				lbAutoComplete.Visible = true;
				productIds = new List<long>();
				//productId = 0;
				if (txtName.Text.Length == 0)
				{
					hideResults();
					return;
				}

				if (!String.IsNullOrEmpty(txtName.Text.Trim()))
				{
					string pattern = @"\b\w*" + txtName.Text.Trim() + @"+\w*\b";
					lbAutoComplete.Items.Clear();

					foreach (KeyValuePair<int, string> s in allProduct.Where(p => Regex.IsMatch(p.Value, pattern, RegexOptions.IgnoreCase)))
					{
						lbAutoComplete.Items.Add(s.Value);
						productIds.Add(s.Key);
					}
					if (lbAutoComplete.Items.Count > 0)
					{
						lbAutoComplete.Visible = true;
					}
					else
					{
						hideResults();
					}
				}
			}

		}
		void lbAutoComplete_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//productId = 0;
			if (lbAutoComplete.SelectedIndex > -1)
			{
				int selectedIndex = lbAutoComplete.SelectedIndex;
				productId = productIds[selectedIndex];
				txtName.Text = lbAutoComplete.Items[selectedIndex].ToString();
			}
			
			hideResults();
		}

		void hideResults()
		{
			lbAutoComplete.Visible = false;
			lbAutoCompleteSupplier.Visible = false;
		}

		void Clear()
		{
			txtCode.Text = "item-#" + (getProductId()+1);
			txtInvoice.Text = "INVOICE-#" + (getInventoryId() + 1);
			dtPickerSupplier.Value = DateTime.Now;
			txtName.Text = "";
			cmbUnit.SelectedIndex = 0;
			cmbUnitForBuy.SelectedIndex = 0;
			txtPrice.Text = "0.00";
			radioBtnInclusive.Checked = false;
			radioBtnExclusive.Checked = false;
			radioBtnDutyFree.Checked = false;
			//txtVatAll.Value = 0;
			txtpayableAmount.Value = 0;
			txtPaidByCash.Value = 0;
			txtPaidAmount.Value = 0;
			txtDiscount.Value = 0;
			txtDue.Value = 0;
			txtOtherCost.Value = 0;
			//txtDiscount.Text = "0.00";
			txtSalePrice.Text = "0.00";
			txtSellingQuantity.Text = "0.00000";
			txtSupplierName.Text = "Supplier's Name";
			dtPickerSupplier.Value = DateTime.Now;
			panelPaymentWays.Controls.Clear();
			isComboAdded.Clear();
			isAddedTextBox.Clear();
			isAddedLabel.Clear();
			isAddedButton.Clear();

			txtBuyingTotalQuantity.Text = "0.00";
			dgProductItems.Rows.Clear();
			this.ActiveControl = txtName;
			hideResults();
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
				textBoxes[i].Item2.Location = new System.Drawing.Point(90, 10 + i * 22);
				buttons[i].Item2.Location = new System.Drawing.Point(200, 10 + i * 22);
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			Clear();
		}
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			//const int WM_KEYDOWN = 0x100;
			//const int WM_ENTERIDLE = 0x121;
			//const int VK_DELETE = 0x2e;
			//const int WM_PASTE = 0x302;
			//bool delete = msg.Msg == WM_KEYDOWN && (int)msg.WParam == VK_DELETE;

			//Control c = Control.FromHandle(msg.HWnd);
			//string name = c.Name;

			if (keyData == (Keys.Enter))
			{
				SendKeys.Send("{TAB}");
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		public string radioButtonSelector()
		{
			if (radioBtnInclusive.Checked == true)
			{
				return "Inclusive";
			}
			else if (radioBtnExclusive.Checked == true)
			{
				return "Exclusive";
			}
			else return "DutyFree";
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

			try
			{

				lblForNameFieldValidation.Visible = false;
				lblForBuyingQuantityValidation.Visible = false;
				lblForBuyingUnitValidation.Visible = false;



				double vatAll = 0;
				if (radioBtnDutyFree.Checked == false)
				{
					vatAll = Convert.ToDouble(txtVatAll.Value);
				}
				double otherCost = Convert.ToDouble(txtOtherCost.Value);
				double paidByCash = Convert.ToDouble(txtPaidByCash.Value);
				double paidByBank = Convert.ToDouble(txtPaidAmount.Value);
				double paidAmount = paidByCash + paidByBank;
				double discount = Convert.ToDouble(txtDiscount.Value);
				double due = Convert.ToDouble(txtDue.Value);
				DateTime dT = DateTime.Parse(dtPickerSupplier.Value.ToString());
				string vatType = radioButtonSelector();

				//foreach ( <int, NumericUpDown> d in isAddedTextBox)
				for(int i = 0; i < isAddedTextBox.Count; i++)
				{
					//int digitalWalletId = Convert.ToInt32(d.Key) + 1;
					double transactionAmount = Convert.ToDouble(Convert.ToString(isAddedTextBox[i].Item2.Value));
					paidAmount = paidAmount + transactionAmount;
				}

				string invoiceNo = txtInvoice.Text;
				string sql2 = @"INSERT INTO Inventory(InvoiceNo, SupplierId, OtherCost, PaidAmount, Discount, Due, CreatedDate, UpdatedDate) 
					    VALUES('" + invoiceNo + "', " + supplierId + ", " + otherCost + ", " + paidAmount +
							", '" + discount + "', " + due + ", '" + dT + "', '" + DateTime.Now + "')";
				CUD(sql2);
				long inventoryId = getInventoryId();

				///////  BalanceSheeet Update ///////
				long balanceSheetId = getMaxId("SELECT MAX(Id) FROM BalanceSheet");
				var balanceSheet = BalanceSheet(balanceSheetId);
				double currentBalance = balanceSheet.Item1;
				double totalDebit = balanceSheet.Item4;
				double debitLiability = balanceSheet.Item5;
				//double d = 

				//foreach (KeyValuePair<int, NumericUpDown> d in isAddedTextBox)
				for (int i = 0; i < isAddedTextBox.Count; i++)
				{
		
					int digitalWalletId = Convert.ToInt32(isAddedTextBox[i].Item1);
					double transactionAmount = Convert.ToDouble(Convert.ToString(isAddedTextBox[i].Item2.Value));

					string sql = @"INSERT INTO Inventory_Payment_Methods(InventoryId, DigitalWalletId, TransactionAmount, BalanceSheetId)
									VALUES("+inventoryId+", "+digitalWalletId+", "+transactionAmount+", " + balanceSheetId + ")";
					CUD(sql);
					string sqlGetAmount = @"SELECT * FROM DigitalWallet WHERE ID = "+ digitalWalletId +"";
					DataTable dt = (DataTable)Select(sqlGetAmount).Data;
					double amount = 0;
					if(dt.Rows.Count > 0)
                    {
						amount = Convert.ToDouble(dt.Rows[0]["Amount"]);

                    }

					amount = amount - transactionAmount;
					string sqlUpdateAmount = @"UPDATE DigitalWallet SET Amount = "+ amount +" WHERE ID = "+ digitalWalletId+"";
					CUD(sqlUpdateAmount);
					double totalBalance = DigitalWalletBalance();
					string sqlUpdateBalanceSheet = @"UPDATE BalanceSheet SET CurrentBalance = " + totalBalance + "," +
						" TotalDebit = "+(totalDebit + transactionAmount)+", DebitLiability = "+(debitLiability + due)+" WHERE Id = "+balanceSheetId+"";
					CUD(sqlUpdateBalanceSheet);
				}
				foreach (DataGridViewRow d in dgProductItems.Rows)
				{
					//amount += Convert.ToDouble(d.Cells[5].Value);
					string itemCode = d.Cells[0].Value.ToString();
					string name = d.Cells[1].Value.ToString();
					double buyingPrice = Convert.ToDouble(d.Cells[2].Value.ToString());
					double discountIndividual = Convert.ToDouble(d.Cells[3].Value.ToString());
					double quantity = Convert.ToDouble(d.Cells[4].Value.ToString());
					long unitId = Convert.ToInt64(d.Cells[5].Value.ToString());
					double salePrice = Convert.ToDouble(d.Cells[6].Value.ToString());
					double orgPrice = (buyingPrice * quantity) - discountIndividual;
					
					double costPerUnit = Convert.ToDouble(d.Cells[7].Value.ToString());
					//double totalAmount = (orgPrice * (otherCost - discount)) / ((costPerUnit * quantity) - orgPrice);
					//double priceAfterDiscount = (orgPrice - (orgPrice * discount / totalAmount)) / quantity;
					double priceAfterDiscount = Convert.ToDouble(d.Cells[8].Value.ToString());
					double GivenVat = 0;
					if (radioBtnExclusive.Checked == false && radioBtnDutyFree.Checked == false)
					{
						GivenVat = priceAfterDiscount * quantity * vatAll / 100;
					}
					string search = "SELECT ID, ItemCode From Products WHERE ItemCode = '" + itemCode + "'";
					DataTable dtSearch = (DataTable)Select(search).Data;


					if (dtSearch.Rows.Count == 0)
					{

						string sql = @"INSERT INTO Products(Name, ItemCode, Price, Vat, VatType, TotalQuantity, Discount, PriceAfterDiscount, CostPerUnit, UnitID, CreateDate, UpdateDate, CreatedBy) 
					    VALUES('" + name + "', '" + itemCode + "', " + buyingPrice + ", " + vatAll +
							", '" + vatType + "', " + quantity + ", " + discountIndividual + "," + priceAfterDiscount + ", " + costPerUnit + ", " + unitId + ", '" + dT + "', '" + DateTime.Now + "', 1)";

						CUD(sql);
						long id1 = getProductId();
						string sql1 = @"INSERT INTO ProductDetails(ProductID, UnitID, SellingPrice, GivenVat, RemainQuantity, SupplierID, InventoryId) VALUES(" + Convert.ToInt64(id1) + ", " + unitId + ", " + salePrice + "," + GivenVat + ", " + quantity + ", " + supplierId + ", " + inventoryId + " )";
						CUD(sql1);
						Clear();


					}
					else
					{
						//search = "SELECT ID, ItemCode From Products WHERE ItemCode = '" + itemCode + "'";
						//dtSearch = (DataTable)Select(search).Data;
						long id = Convert.ToInt64(dtSearch.Rows[0]["ID"]);
						string sql = "UPDATE Products SET Name = '" + name + "', ItemCode = '" + itemCode + "', Price = " + buyingPrice + ", Vat = " + vatAll + ", VatType = '" + vatType + "', TotalQuantity = " + quantity + "," +
							" UnitId = " + unitId + ", Discount = " + discountIndividual + ", PriceAfterDiscount = " + priceAfterDiscount + ", CostPerUnit = " + costPerUnit + ", CreateDate = '" + dT + "', UpdateDate = '" + DateTime.Now + "' WHERE ItemCode = " + itemCode + "";
						CUD(sql);
						string sql1 = "UPDATE ProductDetails SET UnitID = " + unitId + ", SellingPrice = "
							+ salePrice + ", GivenVat = " + GivenVat + " WHERE ProductID = " + id + "";
						CUD(sql1);

					}

				}

				//string sql2 = @"INSERT INTO Inventory(InvoiceNo, SupplierId, OtherCost, PaidAmount, Discount, Due, CreatedDate, UpdatedDate) 
				//	    VALUES('" + invoiceNo + "', " + supplierId + ", " + otherCost + ", " + (txtPaidByCash.Value + txtPaidAmount.Value) +
				//			", '" + discount + "', " + due + ", '" + dT + "', '" + DateTime.Now + "')";

			}



			//	if (txtName.Text != "" && Convert.ToDouble(txtBuyingTotalQuantity.Value.ToString()) != 0 && cmbUnitForBuy.SelectedIndex != 0)
			//	{
			//		string search = "SELECT ID, Name From Products WHERE ID = " + productId + "";
			//		DataTable dtSearch = (DataTable)Select(search).Data;


			//			ItemGrid item = new ItemGrid();
			//			item.Price = Convert.ToDouble(txtPrice.Value);
			//			//item.OtherCost = Convert.ToDouble(txtOtherPrice.Value);
			//			//item.Price = Convert.ToDouble(txtSellPrice.Value);
			//			if (item.Price == 0) MessageBox.Show("Are you sure your product buying price is equal to zero?");
			//			//item.DiscountPrice = txtDiscount.Value.ToString() == "" || txtDiscount.Value == 0 ? item.SellPrice : Convert.ToDouble(txtDiscount.Value);
			//			item.ItemCode = txtCode.Text;
			//			item.Name = txtName.Text;
			//			item.TotalQuantity = Convert.ToDouble(txtBuyingTotalQuantity.Value);
			//			//item.UnitID = Convert.ToInt16(cmbUnit.SelectedValue);
			//			item.UnitId = Convert.ToInt16(units.ElementAt(cmbUnitForBuy.SelectedIndex).Key) - 1;
			//			int UnitIDforSale = Convert.ToInt16(units.ElementAt(cmbUnit.SelectedIndex).Key) - 1;

			//			double sellPrice = Convert.ToDouble(txtSalePrice.Value);
			//			double sellQuantity = Convert.ToDouble(txtSellingQuantity.Value);



			//			item.PaidAmount = Convert.ToDouble(txtPaidAmount.Value);
			//			item.Discount = Convert.ToDouble(txtDiscount.Value);
			//			item.Due = Convert.ToDouble(txtDue.Value);
			//			//int cmb = Convert.ToInt16(cmbUnit.SelectedValue);
			//			//int cmb = 4;
			//			//DateTime dT = DateTime.Parse(DateTime.Now());
			//			//decimal id = 2;
			//			//string createdDate = Convert.ToString(DateTime.Now);
			//			//txtName.Text.Trim()

			//			//DateTime now = DateTime.Now;
			//			//string strDate = now.ToString();
			//			DateTime dT = DateTime.Parse(dtPickerSupplier.Value.ToString());


			//		//string sql = @"INSERT INTO Products(Name, ItemCode, Price, TotalQuantity, UnitId, CreateDate, UpdateDate, CreatedBy) VALUES('" + txtName.Text.Trim() + "', '" + txtCode.Text.Trim() + "', " + txtPrice.Value + ", " + txtQuantity.Value + ", " + cmbUnit.SelectedValue + ", '" + DateTime.Now + "', '" + DateTime.Now + "', " + id + ")";
			//		if (dtSearch.Rows.Count == 0)
			//		{
			//			string sql = @"INSERT INTO Products(Name, ItemCode, Price, TotalQuantity, Discount, OthersCost, CostPerUnit, PaidAmount, Due, UnitID, CreateDate, UpdateDate, CreatedBy) 
			//		    VALUES('" + txtName.Text.Trim() + "', '" + txtCode.Text.Trim() + "', " + txtPrice.Value + ", " + item.TotalQuantity +
			//			", " + item.Discount + ", " + txtOtherCost.Value + ", "+ item.PaidAmount +","+item.Due+", " + item.UnitId + ", '" + dT + "', '" + DateTime.Now + "', 1)";

			//			//string sql = @"INSERT INTO Products(Name, ItemCode, Price, TotalQuantity, UnitId, CreateDate, UpdateDate, CreatedBy) VALUES('sa','asd', 4, 2, 2, '" + DateTime.Now +"', '" + DateTime.Now + ", 2)";

			//			CUD(sql);
			//			lblMessage.Text = "Saved Successfully";
			//			long id = getProductId();

			//			string sql1 = @"INSERT INTO ProductDetails(ProductID, UnitID, SellingPrice, RemainQuantity, SupplierID) VALUES('" + Convert.ToInt64(id) + "', '" + UnitIDforSale + "', '" + sellPrice + "', '" + sellQuantity + "', " + supplierId + ")";
			//			CUD(sql1);
			//			txtCode.Text = "item-#" + (id + 1);
			//			grpBoxSuppliersInfo.Enabled = false;
			//			getItems();

			//		}

			//		else
			//		{
			//			string sql = "UPDATE Products SET Name = '" + txtName.Text.Trim() + "', ItemCode = '" + txtCode.Text.Trim() + "', Price = " + item.Price + ", TotalQuantity = " +item.TotalQuantity + "," +
			//				" UnitId = " + item.UnitId + ", Discount = " + item.Discount + ", PaidAmount = " + item.PaidAmount + ", Due = " + item.Due + ", CreateDate = '"+ dT +"', UpdateDate = '" + DateTime.Now + "' WHERE ID = " + productId + "";
			//			CUD(sql);
			//			string sql1 = "UPDATE ProductDetails SET ProductID = '" + productId + "', UnitID = " + UnitIDforSale + ", SellingPrice = "
			//				+ Convert.ToDouble(txtSalePrice.Value.ToString()) + ", RemainQuantity = '" + Convert.ToDouble(txtSellingQuantity.Value.ToString()) + "' WHERE ProductID = " + productId + "";
			//			CUD(sql1);
			//			getItems();
			//		}
			//	}

			//	else
			//             {
			//		if (txtName.Text == "")
			//		{
			//			lblForNameFieldValidation.Visible = true;
			//		}
			//		if(Convert.ToInt64(txtBuyingTotalQuantity.Value.ToString()) == 0)
			//                 {
			//			lblForBuyingQuantityValidation.Visible = true;
			//                 }

			//		if (cmbUnitForBuy.SelectedIndex == 0) lblForBuyingUnitValidation.Visible = true;
			//		MessageBox.Show("Please fill up the required fields");

			//             }
			//}
			catch (Exception ex)
			{
				lblMessage.Text = "Something Goes Wrong!";
			}
		}

		//int getSuppliers

		void getItems()
		{
			//bool flag = false;
			//Connection con = new Connection();
			string sql = @"SELECT p.Id AS ID, p.Name, p.ItemCode AS [Item Code], p.TotalQuantity AS [Buying Quantity], d.RemainQuantity AS [Remain Quantity], p.Price AS [Buying price], d.SellingPrice AS [Selling Price], s.SName AS [Supplier Name], d.SupplierID, u.Title AS [Selling Unit], p.CreateDate AS [Date]
            FROM ((((Products AS p LEFT JOIN ProductDetails AS d ON p.ID = d.ProductId) LEFT JOIN Units AS u ON d.UnitId = u.ID) LEFT JOIN Suppliers AS s ON d.SupplierID = s.ID)  LEFT JOIN Units AS n ON p.UnitId = n.ID)";
			string sql1 = @"SELECT i.ID AS InID, IPM.ID, w.ID, p.ID AS ID, d.SupplierID, i.InvoiceNo, i.OtherCost, i.PaidAmount, i.Discount, i.Due, IPM.TransactionAmount,
			w.Title, w.AccountNo, p.Name, p.ItemCode AS [Item Code], p.TotalQuantity AS [Buying Quantity],
			d.RemainQuantity AS [Remain Quantity], p.Price AS [Buying price], d.SellingPrice AS [Selling Price],
			s.SName AS [Supplier Name], u.Title AS [Selling Unit], p.CreateDate AS [Date]
            FROM (((((((Products AS p LEFT JOIN ProductDetails AS d ON p.ID = d.ProductId) LEFT JOIN Units AS u ON d.UnitId = u.ID)
			LEFT JOIN Suppliers AS s ON d.SupplierID = s.ID)  LEFT JOIN Units AS n ON p.UnitId = n.ID) 
			LEFT JOIN Inventory AS i ON d.InventoryId = i.ID) LEFT JOIN Inventory_Payment_Methods AS IPM ON i.ID = IPM.InventoryId)
			LEFT JOIN DigitalWallet AS w ON IPM.digitalWalletId = w.ID)";
			datagridviewGenerator(sql1);
			//DataTable dt = (DataTable)Select(sql).Data;
   //         dgItems.DataSource = dt;
   //         dgItems.AutoGenerateColumns = false;
   //         dgItems.Columns[0].Visible = false;
			//dgItems.Columns[5].Visible = false;
			//dgItems.Columns[8].Visible = false;
			//dgItems.Columns[2].Width = 65;
			
			//dgItems.Refresh();


			allProduct = getProducts();
		}

		void datagridviewCellResizer()
        {
			dgItems.Columns[2].Width = 65;
			dgItems.Columns[3].Width = 70;
			dgItems.Columns[4].Width = 70;
			dgItems.Columns[5].Width = 70;
			dgItems.Columns[6].Width = 65;
			dgItems.Columns[7].Width = 65;
			dgItems.Columns[8].Width = 65;
			dgItems.Columns[9].Width = 65;
			dgItems.Columns[10].Width = 65;
			dgItems.Columns[11].Width = 75;
			//dgItems.Columns[12].Width = 75;
			//dgItems.Columns[13].Width = 75;
		}

		private void EntryItems_Load(object sender, EventArgs e)
		{
			getItems();
			Initial();
			lblForBuyingUnitValidation.Visible = false;
			allSuppliers = getSuppliers();
			//DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
			//Editlink.UseColumnTextForLinkValue = true;
			//Editlink.HeaderText = "Edit";
			//Editlink.DataPropertyName = "lnkColumn";
			//Editlink.LinkBehavior = LinkBehavior.SystemDefault;
			//Editlink.Text = "Edit";
			//dgItems.Columns.Add(Editlink);

			//DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
			//Deletelink.UseColumnTextForLinkValue = true;
			//Deletelink.HeaderText = "Delete";
			//Deletelink.DataPropertyName = "lnkColumn";
			//Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
			//Deletelink.Text = "Delete";
			//dgItems.Columns.Add(Deletelink);

			cmbUnitForBuy.SelectedIndex = cmbUnitForBuy.Items.Count > 0 ?  0 : -1;
			cmbUnit.SelectedIndex = cmbUnit.Items.Count > 0 ?  0 : -1;
		
		}

		void datagridviewGenerator(string sql)
        {
			DataTable dt = (DataTable)Select(sql).Data;
			dgItems.Refresh();
			dgItems.DataSource = dt;
			//dgItems.Columns[0].Visible = false;
			//dgItems.Columns[1].Visible = false;
			//dgItems.Columns[2].Visible = false;
			//dgItems.Columns[3].Visible = false;
			//dgItems.Columns[4].Visible = false;
			dgItems.AutoGenerateColumns = false;

			if (dgItems.Columns.Count == 22)
			{

				DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
				Editlink.UseColumnTextForLinkValue = true;
				Editlink.HeaderText = "Edit";
				Editlink.DataPropertyName = "lnkColumn";
				Editlink.LinkBehavior = LinkBehavior.SystemDefault;
				Editlink.Text = "Edit";
				dgItems.Columns.Add(Editlink);

				DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
				Deletelink.UseColumnTextForLinkValue = true;
				Deletelink.HeaderText = "Delete";
				Deletelink.DataPropertyName = "lnkColumn";
				Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
				Deletelink.Text = "Delete";
				dgItems.Columns.Add(Deletelink);
			}
			
			datagridviewCellResizer();

			dgItems.Refresh();
		}

		private void dgItems_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 22)
				{
				    dgProductItems.Rows.Clear();
					isComboAdded.Clear();
					isAddedButton.Clear();
					isAddedLabel.Clear();
					isAddedTextBox.Clear();
					panelPaymentWays.Controls.Clear();
					long inventoryId = Convert.ToInt64(dgItems.Rows[e.RowIndex].Cells[0].Value.ToString());
					long inventoryPaymentId = Convert.ToInt64(dgItems.Rows[e.RowIndex].Cells[1].Value.ToString());
					long walletId = Convert.ToInt64(dgItems.Rows[e.RowIndex].Cells[2].Value.ToString());
					long productId = Convert.ToInt64(dgItems.Rows[e.RowIndex].Cells[3].Value.ToString());
					long supplierId = Convert.ToInt64(dgItems.Rows[e.RowIndex].Cells[4].Value.ToString());
					string invoiceNo = dgItems.Rows[e.RowIndex].Cells[5].Value.ToString();
					double otherCost = Convert.ToDouble(dgItems.Rows[e.RowIndex].Cells[6].Value.ToString());
					double paidAmount = Convert.ToDouble(dgItems.Rows[e.RowIndex].Cells[7].Value.ToString());
					double discount = Convert.ToDouble(dgItems.Rows[e.RowIndex].Cells[8].Value.ToString());
				    txtDiscount.Value = Convert.ToDecimal(discount);
					double due = Convert.ToDouble(dgItems.Rows[e.RowIndex].Cells[9].Value.ToString());
					//double transactionAmount = Convert.ToDouble(dgItems.Rows[e.RowIndex].Cells[10].Value.ToString());
					//string walletTitle = dgItems.Rows[e.RowIndex].Cells[11].Value.ToString();
					string walletAccountNo = dgItems.Rows[e.RowIndex].Cells[11].Value.ToString();
				//string product = dgItems.Rows[e.RowIndex].Cells[11].Value.ToString();

				string sql = @"SELECT * FROM (((Products p LEFT JOIN ProductDetails d ON p.ID = d.ProductID)
								LEFT JOIN Inventory i ON i.ID = d.InventoryId)
								 LEFT JOIN Suppliers s ON s.ID = i.SupplierId) WHERE i.ID = "+inventoryId+"";
				DataTable dt = (DataTable)Select(sql).Data;
				txtSupplierName.Text = dt.Rows[0]["SName"].ToString();
				dtPickerSupplier.Value = DateTime.Parse(dt.Rows[0]["i.CreatedDate"].ToString());
				ItemGrid item = new ItemGrid();
				for(int i = 0; i < dt.Rows.Count; i++)
                {
					item.ItemCode = dt.Rows[i]["ItemCode"].ToString();
					item.Name = dt.Rows[i]["Name"].ToString();
					item.Price = Convert.ToDouble(dt.Rows[i]["Price"].ToString());
					item.Discount = Convert.ToDouble(dt.Rows[i]["p.Discount"].ToString());
					item.TotalQuantity = Convert.ToDouble(dt.Rows[i]["TotalQuantity"].ToString());
					item.UnitId = Convert.ToInt16(dt.Rows[i]["d.UnitId"].ToString());
					item.SalePrice = Convert.ToDouble(dt.Rows[i]["SellingPrice"].ToString());
					item.CostPerUnit = Convert.ToDouble(dt.Rows[i]["CostPerUnit"].ToString());
					item.CostPerUnitAfterDiscount = Convert.ToDouble(dt.Rows[i]["CostPerUnit"].ToString());
					item.Vat = Convert.ToDouble(dt.Rows[i]["Vat"].ToString());
					item.VatType = dt.Rows[i]["VatType"].ToString();
					item.GivenVat = Convert.ToDouble(dt.Rows[i]["GivenVat"].ToString()) / item.TotalQuantity;

					LoadGrid(item);


				}
				//inventoryId = 29;
				string sqlWallet = @"SELECT * FROM Inventory_Payment_Methods m LEFT JOIN DigitalWallet w ON m.DigitalWalletId = w.ID 
									WHERE m.InventoryId = " + inventoryId + "";
				DataTable dtWallet = (DataTable)Select(sqlWallet).Data;
				for(int i = 0; i < dtWallet.Rows.Count; i++)
                {
					int digitalWalletId = Convert.ToInt32(dtWallet.Rows[i]["DigitalWalletId"].ToString());
					double transactionAmount = Convert.ToDouble(dtWallet.Rows[i]["TransactionAmount"].ToString());
					string walletTitle = dtWallet.Rows[i]["Title"].ToString();
					string walletAcNo = dtWallet.Rows[i]["AccountNo"].ToString();

					string walletTitleAc = walletTitle + "--" + walletAcNo;
					addWalletEdit(walletTitleAc, digitalWalletId, transactionAmount);
					//TextBox.
				}

				calculation();










				//long id = Convert.ToInt64(dgItems.Rows[e.RowIndex].Cells[0].Value.ToString());
				//	string name = dgItems.Rows[e.RowIndex].Cells[1].Value.ToString();
				//	string code = dgItems.Rows[e.RowIndex].Cells[2].Value.ToString();
				//	double totalBuyingQuantity = Convert.ToDouble(dgItems.Rows[e.RowIndex].Cells[3].Value);
				//	double sellingQuantity = Convert.ToDouble(dgItems.Rows[e.RowIndex].Cells[4].Value);
				//	Double price = Convert.ToDouble(dgItems.Rows[e.RowIndex].Cells[5].Value);
				//	Double sellingPrice = Convert.ToDouble(dgItems.Rows[e.RowIndex].Cells[6].Value);
				//	string sName = Convert.ToString(dgItems.Rows[e.RowIndex].Cells[7].Value);
				//	supplierId = Convert.ToInt64(dgItems.Rows[e.RowIndex].Cells[8].Value);
				//	productId = id;


				//	//getting the key from the dictionary
				//	string unit1 = Convert.ToString(dgItems.Rows[e.RowIndex].Cells[9].Value);
				//	var itemKey = 0;
				//	for (int i = units.Count - 1; i >= 0; i--)
				//	{
				//		var item = units.ElementAt(i);
				//		if (item.Value == unit1)
				//		{
				//			itemKey = item.Key + 1;
				//		}
				//		//var itemValue = item.Value;
				//	}

				//	//string unit2 = Convert.ToString(dgItems.Rows[e.RowIndex].Cells[10].Value);
				//	//var itemKey1 = 0;
				//	//for (int i = units.Count - 1; i >= 0; i--)
				//	//{
				//	//	var item1 = units.ElementAt(i);
				//	//	if (item1.Value == unit1)
				//	//	{
				//	//		itemKey1 = item1.Key + 1;
				//	//	}
				//	//	//var itemValue = item.Value;
				//	//}

				//	DateTime date = DateTime.Parse(dgItems.Rows[e.RowIndex].Cells[10].Value.ToString());

				//	txtCode.Text = code;
				//	txtName.Text = name;
				//	txtPrice.Text = price.ToString();
				//	cmbUnitForBuy.SelectedIndex = units.Keys.ToList().IndexOf(itemKey);
				//	//cmbUnit.SelectedIndex = units.Keys.ToList().IndexOf(itemKey1);
				//	//txtDiscount.Text = "0.00";
				//	txtSalePrice.Text = sellingPrice.ToString();
				//	txtBuyingTotalQuantity.Text = totalBuyingQuantity.ToString();
				//	txtSellingQuantity.Text = sellingQuantity.ToString();
				//	txtSupplierName.Text = sName;
				//	dtPickerSupplier.Value = date;
				//	grpBoxSuppliersInfo.Enabled = false;
			

				}
				else if (e.ColumnIndex == 23)
				{
					long id = Convert.ToInt64(dgItems.Rows[e.RowIndex].Cells[0].Value.ToString());
					string name = dgItems.Rows[e.RowIndex].Cells[1].Value.ToString();
					DialogResult dr = MessageBox.Show("Are You Sure You Want To Delete " + Environment.NewLine
						+ name + "'s Informations", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dr.ToString() == "Yes")
					{
						string sql = "DELETE FROM Products WHERE Id = " + id;
						string sql1 = "DELETE FROM ProductDetails WHERE ProductId = " + id;
						//bool flag = false;
						if (CUD(sql).IsSuccess && CUD(sql1).IsSuccess)
						{
							//sql = "DELETE FROM DoctorDetails WHERE DoctorId = " + id;
							//if (crud.Delete(sql))
							//{
							//	flag = true;
							//}
							getItems();
						}
						else
						{
							MessageBox.Show("Data couldn't be delete!");
						}
						//if (!flag)
						//{
						//	MessageBox.Show("Data couldn't delete!");
						//}
						//else
						//{
						//	getItems();
						//}
					}
				}
			//}
			//catch (Exception ex)
			//{
			//	ex.ToString();
			//}
		}

        private void chkHideBuyingPrice_CheckedChanged(object sender, EventArgs e)
        {
			dgItems.Columns[5].Visible = !chkHideBuyingPrice.Checked;
			//label29.BackColor = Color.Transparent;
		}

        private void button1_Click(object sender, EventArgs e)
        {
			string name = txtSearch.Text;

			string sql1 = @"SELECT p.Id, p.Name, p.ItemCode AS [Item Code], p.TotalQuantity AS [Buying Quantity], d.SellingQuantity AS [Selling Quantity], p.Price AS [Buying price], d.SellingPrice AS [Selling Price], s.SName AS [Supplier Name], s.ID, u.Title AS [Selling Unit], n.Title AS [Buying Unit], p.CreateDate AS [Date]
            FROM ((((Products AS p LEFT JOIN ProductDetails AS d ON p.ID = d.ProductId) LEFT JOIN Units AS u ON d.UnitId = u.ID) LEFT JOIN Suppliers AS s ON d.SupplierID = s.ID)  LEFT JOIN Units AS n ON p.UnitId = n.ID)
			WHERE p.Name LIKE '%" + name + "%' OR p.ItemCode LIKE '%" + name + "%' OR u.Title LIKE '%" + name + "%' OR n.Title LIKE '%" + name + "%'";

			string sql = @"SELECT p.Id, p.Name, p.ItemCode AS [Item Code], p.TotalQuantity AS [Buying Quantity], d.SellingQuantity, p.Price AS [Buying price], d.SellingPrice, u.Title AS SellingUnit, n.Title AS BuyingUnit
            FROM (((Products AS p LEFT JOIN ProductDetails AS d ON p.ID = d.ProductId) LEFT JOIN Units AS u ON d.UnitId = u.ID)  LEFT JOIN Units AS n ON p.UnitId = n.ID)
			WHERE p.Name LIKE '%" + name + "%' OR p.ItemCode LIKE '%" + name + "%' OR u.Title LIKE '%" + name + "%' OR n.Title LIKE '%" + name + "%'";
			DataTable dt = (DataTable)Select(sql1).Data;
			dgItems.DataSource = dt;
			dgItems.Columns[0].Visible = true;
			dgItems.AutoGenerateColumns = false;
			dgItems.Refresh();
		}

        private void groupBox1_Enter(object sender, EventArgs e)
        {
			if (lbAutoComplete.Visible) lbAutoComplete.Visible = false;
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    

   
		public static Byte[] HtmlToBytes(string htmlText)
		{
			Byte[] bytes;

			using (var ms = new MemoryStream())
			{
				using (var doc = new Document(PageSize.A4, 10, 10, 10, 10))
				{
					using (var writer = PdfWriter.GetInstance(doc, ms))
					{
						writer.CloseStream = false;
						doc.Open();
						using (var msHtml = new MemoryStream(Encoding.UTF8.GetBytes(htmlText)))
						{
							XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, Encoding.UTF8);
						}
					}
				}
				bytes = ms.ToArray();
			}

			return bytes;
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "PDF (*.pdf)|*.pdf";
				sfd.FileName = "Output.pdf";
				bool fileError = false;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					if (File.Exists(sfd.FileName))
					{
						try
						{
							File.Delete(sfd.FileName);
						}
						catch (IOException ex)
						{
							fileError = true;
							MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
						}
					}
					if (!fileError)
					{
						try
						{
							PdfPTable pdfTable = new PdfPTable(dgItems.Columns.Count);
							pdfTable.DefaultCell.Padding = 3;
							pdfTable.WidthPercentage = 100;
							pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

							foreach (DataGridViewColumn column in dgItems.Columns)
							{
								PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
							//var a = cell.Column.;
							if (column.HeaderText != "Edit" && column.HeaderText != "Delete")
								pdfTable.AddCell(cell);
							}

							foreach (DataGridViewRow row in dgItems.Rows)
							{
								foreach (DataGridViewCell cell in row.Cells)
								{
								if(cell.Value != null && cell.Value != "Edit" && cell.Value != "Delete")
									pdfTable.AddCell(cell.Value.ToString());
								}
							}

							using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
							{
								Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
								PdfWriter.GetInstance(pdfDoc, stream);
								pdfDoc.Open();
								pdfDoc.Add(pdfTable);
								pdfDoc.Close();
								stream.Close();
							}

							MessageBox.Show("Data Exported Successfully !!!", "Info");
						}
						catch (Exception ex)
						{
							MessageBox.Show("Error :" + ex.Message);
						}
					}
					//string Path = @"E:\";
					//string FileName = "1";
					//FileStream fs = new FileStream(Path + FileName + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None);
					//iTextSharp.text.Rectangle rec2 = new iTextSharp.text.Rectangle(PageSize.A4);


					//Document doc = new Document(rec2, 10, 10, 10, 10);
					//PdfWriter writer = PdfWriter.GetInstance(doc, fs);
					//doc.AddAuthor("Micke Blomquist");
					//doc.AddCreator("Sample application using iTextSharp");
					//doc.AddKeywords("PDF tutorial education");
					//doc.AddSubject("Document subject - Describing the steps creating a PDF document");
					//doc.AddTitle("The document title - PDF creation using iTextSharp");
					//doc.Open();
					//doc.Add(new Paragraph("Hello World!"));
					//doc.Close();
					//writer.Close();
					//fs.Close();




					////Creating iTextSharp Table from the DataTable data
					//PdfPTable pdfTable = new PdfPTable(dgItems.ColumnCount);

					//pdfTable.DefaultCell.Padding = 3;

					//pdfTable.WidthPercentage = 70;
					//pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
					//pdfTable.DefaultCell.BorderWidth = 1;
					////Adding Header row
					//foreach (DataGridViewColumn column in dgItems.Columns)
					//{
					//	PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
					//	cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
					//	pdfTable.AddCell(cell);
					//}

					////Adding DataRow
					//foreach (DataGridViewRow row in dgItems.Rows)
					//{
					//	foreach (DataGridViewCell cell in row.Cells)
					//	{
					//		if (cell.Value == null)
					//		{

					//		}
					//		else
					//		{
					//			pdfTable.AddCell(cell.Value.ToString());

					//		}


					//	}
				}
				//Exporting to PDF
				//string folderPath = "E:/PDF/";
				//if (!Directory.Exists(folderPath))
				//{
				//	Directory.CreateDirectory(folderPath);
				//}






				//using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
				//{




				//	Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
				//	pdfDoc.Open();
				//	PdfWriter.GetInstance(pdfDoc, stream);

				//	pdfDoc.Add(pdfTable);
				//	pdfDoc.Close();
				//	stream.Close();
			
			
		}


		private void textBox_Click(object sender, EventArgs e)
		{
			if (txtName.Focused) lblForNameFieldValidation.Visible = false;
			if (txtBuyingTotalQuantity.Focused) lblForBuyingQuantityValidation.Visible = false;
			if (cmbUnitForBuy.SelectedIndex != 0) lblForBuyingUnitValidation.Visible = false;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
			string name = txtSearch.Text;

			string sql1 = @"SELECT p.ID, p.Name, p.ItemCode AS [Item Code], p.TotalQuantity AS [Buying Quantity], d.SellingQuantity AS [Selling Quantity], p.Price AS [Buying price], d.SellingPrice AS [Selling Price], s.SName AS [Supplier Name], d.SupplierID, u.Title AS [Selling Unit], n.Title AS [Buying Unit], p.CreateDate AS [Date]
            FROM ((((Products AS p LEFT JOIN ProductDetails AS d ON p.ID = d.ProductId) LEFT JOIN Units AS u ON d.UnitId = u.ID) LEFT JOIN Suppliers AS s ON d.SupplierID = s.ID)  LEFT JOIN Units AS n ON p.UnitId = n.ID)
			WHERE p.Name LIKE '%" + name + "%' OR p.ItemCode LIKE '%" + name + "%' OR u.Title LIKE '%" + name + "%' OR n.Title LIKE '%" + name + "%'";

			string sql2 = @"SELECT p.ID, p.Name, p.ItemCode AS [Item Code], p.TotalQuantity AS [Buying Quantity], d.SellingQuantity AS [Selling Quantity], p.Price AS [Buying price], d.SellingPrice AS [Selling Price], s.SName AS [Supplier Name], s.ID, u.Title AS [Selling Unit], n.Title AS [Buying Unit], p.CreateDate AS [Date]
            FROM (((Products AS p LEFT JOIN ProductDetails AS d ON p.ID = d.ProductId) LEFT JOIN Units AS u ON d.UnitId = u.ID) LEFT JOIN Suppliers AS s ON d.SupplierID = s.ID)
			WHERE p.Name LIKE '%" + name + "%' OR p.ItemCode LIKE '%" + name + "%' OR u.Title LIKE '%" + name + "%' OR n.Title LIKE '%" + name + "%'";

			string sql = @"SELECT p.ID, p.Name, p.ItemCode AS [Item Code], p.TotalQuantity AS [Buying Quantity], d.SellingQuantity, p.Price AS [Buying price], d.SellingPrice, u.Title AS SellingUnit, n.Title AS BuyingUnit
            FROM (((Products AS p LEFT JOIN ProductDetails AS d ON p.ID = d.ProductId) LEFT JOIN Units AS u ON d.UnitId = u.ID)  LEFT JOIN Units AS n ON p.UnitId = n.ID)
			WHERE p.Name LIKE '%" + name + "%' OR p.ItemCode LIKE '%" + name + "%' OR u.Title LIKE '%" + name + "%' OR n.Title LIKE '%" + name + "%'";
			datagridviewGenerator(sql1);
			//DataTable dt = (DataTable)Select(sql1).Data;
			//dgItems.DataSource = dt;
			//dgItems.AutoGenerateColumns = false;
			//dgItems.Refresh();
			//lbAutoComplete. = false;

		}

		private void txtSupplierName_TextChanged(object sender, EventArgs e)
		{
			if (txtSupplierName.Text != "Supplier's Name")
			{
				if (txtSupplierName.Focused)
				{
					lbAutoCompleteSupplier.Items.Clear();
					supplierIds = new List<long>();
					//productId = 0;
					if (txtSupplierName.Text.Length == 0)
					{
						hideResults();
						return;
					}

					if (!String.IsNullOrEmpty(txtSuppliersName.Text.Trim()))
					{
						string pattern = @"\b\w*" + txtSupplierName.Text.Trim() + @"+\w*\b";
						lbAutoCompleteSupplier.Items.Clear();

						foreach (KeyValuePair<int, string> s in allSuppliers.Where(p => Regex.IsMatch(p.Value, pattern, RegexOptions.IgnoreCase)))
						{
							lbAutoCompleteSupplier.Items.Add(s.Value);
							supplierIds.Add(s.Key);
						}

						


						if (lbAutoCompleteSupplier.Items.Count > 0)
						{
							lbAutoCompleteSupplier.Visible = true;
						}

						else
						{
							//txtSupplierName.Text = "Supplier's Name";
							MessageBox.Show("The Supplier Name is not in your database. Plese add this supplier!!!");
							//txtSupplierName.Text = "Supplier's Name";
							hideResults();
							txtSupplierName.Text = "Supplier's Name";
						}
					}
				}
			}
		}

        private void lbAutoCompleteSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (lbAutoCompleteSupplier.SelectedIndex > -1)
			{
				int selectedIndex = lbAutoCompleteSupplier.SelectedIndex;
				supplierId = supplierIds[selectedIndex];
				txtSupplierName.Text = lbAutoCompleteSupplier.Items[selectedIndex].ToString();
			}

			hideResults();
		}

		private void btnSuppliersInfo_Click(object sender, EventArgs e)
		{
				

			if (txtSuppliersName.Text != "Name" && txtSuppliersName.Text != "" && txtSuppliersMobileNo.Text != "Mobile No" && txtSuppliersMobileNo.Text != "")
			{
				string sql = @"INSERT INTO Suppliers(SName, Phone, Address, CreatedDate)
				VALUES('" + Convert.ToString(txtSuppliersName.Text) + "', '" + Convert.ToString(txtSuppliersMobileNo.Text) + "', '" + Convert.ToString(rTxtSuppliersAddress.Text.Trim()) + "', '" + DateTime.Now + "')";

				CUD(sql);
				txtSupplierName.Text = txtSuppliersName.Text;

				grpBoxSuppliersInfo.Enabled = false;
				txtSuppliersName.Text = "Name";
				txtSuppliersMobileNo.Text = "Mobile No";
				rTxtSuppliersAddress.Text = "Address";
				allSuppliers = getSuppliers();

				foreach (var pair in allSuppliers)

				{
					if (pair.Value == txtSupplierName.Text)
					{
						supplierId = pair.Key;
					}
				}
			}
			else MessageBox.Show("Please Fill Up Supplier's Information");
		}

        private void btnSupplierAdd_Click(object sender, EventArgs e)
        {

			txtSuppliersName.Text = "Name";
			txtSuppliersMobileNo.Text = "Mobile No";
			rTxtSuppliersAddress.Text = "Address";

			if (!grpBoxSuppliersInfo.Enabled)
            {
				grpBoxSuppliersInfo.Enabled = true;
				
			}


        }


        private void txtSuppliersMobileNo_Leave(object sender, EventArgs e)
        {
			if (txtSuppliersMobileNo.Text != "Mobile No")
			{
				string sql = @"SELECT ID, SName, Phone From Suppliers WHERE Phone = '" + txtSuppliersMobileNo.Text + "'";
				DataTable dt = (DataTable)Select(sql).Data;
				if (dt.Rows.Count > 0)
				{
					MessageBox.Show("This Mobile No. is already belong to " + dt.Rows[0][1].ToString() + "");
					txtSuppliersMobileNo.Text = "Mobile No";
					txtSuppliersMobileNo.Focus();
				}
			}

		}

        private void groupBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
			if (lbAutoComplete.Visible) lbAutoComplete.Visible = false;
			//if (lbAutoCompleteSupplier.Visible) lbAutoCompleteSupplier.Visible = false;
			groupBox1.Focus();

			int flag = 0;
			//string value = txtSupplierName.Text.Trim();
			foreach (var pair in allSuppliers)
			{
				//string value = pair.Value.ToLower();
				if (pair.Value.ToLower() == txtSupplierName.Text.ToLower())
				{
					flag = 1;
					supplierId = pair.Key;
					lbAutoCompleteSupplier.Visible = false;
				}
			}

			if (txtSupplierName.Text == "Supplier's Name")
			{
				flag = 1;
			}

			if (flag == 0)
			{
				lbAutoCompleteSupplier.Visible = false;
				MessageBox.Show("The Supplier's name is not in your database.Please add new supplier!!!");
				txtSupplierName.Text = "Supplier's Name";
				
			}

		}

        private void grpBoxSupplier_MouseCaptureChanged(object sender, EventArgs e)
        {
			if (lbAutoComplete.Visible) lbAutoComplete.Visible = false;
			int flag = 0;
			//string value = txtSupplierName.Text.Trim();
			foreach (var pair in allSuppliers)

			{
				//string value = pair.Value.ToLower();
				if (pair.Value.ToLower() == txtSupplierName.Text.ToLower())
				{
					flag = 1;
					supplierId = pair.Key;
					lbAutoCompleteSupplier.Visible = false;
				}
			}

			if (txtSupplierName.Text == "Supplier's Name")
            {
				flag = 1;
			}

			
			if (flag == 0)
			{
				
				lbAutoCompleteSupplier.Visible = false;
				MessageBox.Show("The Supplier's name is not in your database.Please add new supplier!!!");
				txtSupplierName.Text = "Supplier's Name";
			}
		}



		void calculation()
        {
			double buyingUnitPrice = Convert.ToDouble(txtPrice.Value);
			double buyingQuantity = 1;
			buyingQuantity = Convert.ToDouble(txtBuyingTotalQuantity.Value);
			
			//int buyingUnit = cmbUnitForBuy.SelectedIndex;
			double paidByCash = Convert.ToDouble(txtPaidByCash.Value);
			double paidByBank = Convert.ToDouble(txtPaidAmount.Value);
			double paidAmount =paidByBank + paidByCash;

			for (int i = 0; i < isAddedTextBox.Count; i++)
			{
				
				//int digitalWalletId = Convert.ToInt32(d.Key) + 1;
				double transactionAmount = Convert.ToDouble(Convert.ToString(isAddedTextBox[i].Item2.Value));
				paidAmount = paidAmount + transactionAmount;
			}

			double discount = Convert.ToDouble(txtDiscount.Value);
			double discountIndi = Convert.ToDouble(txtDiscountIndividual.Value);
			double othersCost = Convert.ToDouble(txtOtherCost.Value);
			double totalAmount = 0, totalVat = 0;

			//if ((buyingUnitPrice * buyingQuantity) > discountIndi) txtCostPerUnit.Value = Convert.ToDecimal((buyingUnitPrice * buyingQuantity) - discountIndi)/ Convert.ToDecimal(buyingQuantity);
			txtCostPerUnit.Value = Convert.ToDecimal(buyingUnitPrice - buyingUnitPrice * discountIndi / 100);
			if (dgProductItems.Rows.Count > 0) {
				
				double buyingPrice = 0, discountIndividual = 0, costPerUnit = 0, orgPrice = 0;
				double paidPrice = 0, costPerUnitAfterDiscount = 0, vat = 0;
				paidPrice = Convert.ToDouble(txtCostPerUnit.Value);


				foreach (DataGridViewRow d in dgProductItems.Rows)
				{
					buyingPrice = Convert.ToDouble(d.Cells[2].Value.ToString());
					discountIndividual = Convert.ToDouble(d.Cells[3].Value.ToString());
					buyingQuantity = Convert.ToDouble(d.Cells[4].Value.ToString());
					vat = Convert.ToDouble(d.Cells[9].Value.ToString());
					//totalVat = totalVat + (Convert.ToDouble(d.Cells[8].Value.ToString())* buyingQuantity * vat / 100);
					totalVat = totalVat + Convert.ToDouble(d.Cells[11].Value.ToString());
					totalAmount = totalAmount + (buyingPrice * buyingQuantity) - discountIndividual;
				}

					foreach (DataGridViewRow d in dgProductItems.Rows)
				{
					//amount += Convert.ToDouble(d.Cells[5].Value);

					//double buyingPrice = Convert.ToDouble(d.Cells[2].Value.ToString());
					//double discountIndividual = Convert.ToDouble(d.Cells[3].Value.ToString());

					//double quantity = Convert.ToDouble(d.Cells[4].Value.ToString());
					//long unitId = Convert.ToInt64(d.Cells[5].Value.ToString());
					//double salePrice = Convert.ToDouble(d.Cells[6].Value.ToString());
					buyingPrice = Convert.ToDouble(d.Cells[2].Value.ToString());
					discountIndividual = Convert.ToDouble(d.Cells[3].Value.ToString());

					buyingQuantity = Convert.ToDouble(d.Cells[4].Value.ToString());
					orgPrice = (buyingPrice * buyingQuantity) - (buyingPrice * buyingQuantity) * discountIndividual / 100;

					costPerUnit = (orgPrice + (orgPrice * Convert.ToDouble(txtOtherCost.Value) / totalAmount) - (orgPrice * Convert.ToDouble(txtDiscount.Value) / totalAmount)) / buyingQuantity;
					costPerUnitAfterDiscount = (orgPrice - (orgPrice * Convert.ToDouble(txtDiscount.Value) / totalAmount)) / buyingQuantity;

					d.Cells[7].Value = costPerUnit;
					d.Cells[8].Value = costPerUnitAfterDiscount;
					//txtCostPerUnit.Value = Convert.ToDecimal(costPerUnit);
				}
	
			}

			double due = Convert.ToDouble(txtDue.Value);

			//double buyingPrice = buyingUnitPrice * buyingQuantity;
			//double costPerUnit = (buyingPrice + othersCost) / buyingQuantity;

			//txtCostPerUnit.Value = Convert.ToDecimal(costPerUnit);
			numericVat.Value = Convert.ToDecimal(totalVat);
			double Vat = Convert.ToDouble(numericVat.Value);
			double givenVat = Vat;
			double PayableAmount = totalAmount + givenVat - discount;

            due = PayableAmount - paidAmount;
			txtpayableAmount.Value = Convert.ToDecimal(PayableAmount);
			txtDue.Value = Convert.ToDecimal(due);
			//txtDue.Value = Convert.ToDecimal(due);
        }


        private void txtSuppliersName_Leave(object sender, EventArgs e)
        {
			if (txtSuppliersName.Text != "Name")
			{
				string sql = @"SELECT ID, SName, Phone From Suppliers WHERE SName LIKE '" + txtSuppliersName.Text + "'";
				DataTable dt = (DataTable)Select(sql).Data;
				if (dt.Rows.Count > 0)
				{
					MessageBox.Show("Supplier name should be unique. This name is already exist in database");
					txtSuppliersName.Text = "Name";
					txtSuppliersName.Focus();
				}
			}
		}

       

        private void txtName_Leave(object sender, EventArgs e)
        {
			if (txtName.Text == "") lblForNameFieldValidation.Visible = true;

        }

        private void txtBuyingTotalQuantity_Leave(object sender, EventArgs e)
        {
            if(txtBuyingTotalQuantity.Value == 0)
            {
				lblForBuyingQuantityValidation.Visible = true;
            }
        }


        private void cmbUnitForBuy_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (cmbUnitForBuy.SelectedIndex == 0) lblForBuyingUnitValidation.Visible = true;
			if (cmbUnitForBuy.SelectedIndex != 0) lblForBuyingUnitValidation.Visible = false;

			
		}

        private void txtPrice_ValueChanged(object sender, EventArgs e)
        {
			calculation();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
			ItemGrid item = new ItemGrid();
			item.ItemCode = txtCode.Text;
			item.Name = txtName.Text;
			item.Price = Convert.ToDouble(txtPrice.Value);
			
			item.VatType = Convert.ToString(radioButtonSelector());
			if (item.VatType == "Inclusive" || item.VatType == "Exclusive")
			{
				item.Vat = Convert.ToDouble(txtVatAll.Value);
			}
			else if (item.VatType == "DutyFree")
			{
				item.Vat = 0;
			}
			item.Discount = Convert.ToDouble(txtDiscountIndividual.Value);
			
			item.TotalQuantity = Convert.ToDouble(txtBuyingTotalQuantity.Value);
			if (radioBtnInclusive.Checked)
			{
				item.GivenVat = (item.Price - item.Price * item.Discount / 100) * item.Vat / 100;
			}
			else
			{
				item.GivenVat = 0;
			}
			item.UnitId = Convert.ToInt16(units.ElementAt(cmbUnitForBuy.SelectedIndex).Key) - 1;
			item.SalePrice = Convert.ToDouble(txtSalePrice.Value);
			item.CostPerUnit = Convert.ToDouble(txtCostPerUnit.Value);
			item.CostPerUnitAfterDiscount = Convert.ToDouble(txtCostPerUnit.Value);

			
			LoadGrid(item);


		}

        void dgProductItemLoad()
        {
			dgProductItems.Rows.Clear();
			dgProductItems.Columns.Clear();
			dgProductItems.Columns.Add("cItemCode", "Item Code");
			dgProductItems.Columns.Add("cName", "Name");
			dgProductItems.Columns.Add("cPrice", "Buying Price");
			dgProductItems.Columns.Add("cDiscount", "discount(%)");
			dgProductItems.Columns.Add("cQuantity", "Quantity");
			dgProductItems.Columns.Add("cUnitId", "UnitId");
			dgProductItems.Columns.Add("cSalePrice", "Sale Price");
			dgProductItems.Columns.Add("cCostPerUnit", "Cost Per Unit");
			dgProductItems.Columns.Add("cCostPerUnitAfterDiscount", "Cost Per Unit Without Other Cost");
			dgProductItems.Columns.Add("cVat", "Vat(%)");
			dgProductItems.Columns.Add("cVatType", "Vat Type");
			dgProductItems.Columns.Add("cGiven Vat", "Given Vat");


			DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
			Editlink.UseColumnTextForLinkValue = true;
			Editlink.HeaderText = "Edit";
			Editlink.DataPropertyName = "lnkColumn";
			Editlink.LinkBehavior = LinkBehavior.SystemDefault;
			Editlink.Text = "Edit";
			dgProductItems.Columns.Add(Editlink);

			DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
			Deletelink.UseColumnTextForLinkValue = true;
			Deletelink.HeaderText = "Delete";
			Deletelink.DataPropertyName = "lnkColumn";
			Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
			Deletelink.Text = "Delete";
			dgProductItems.Columns.Add(Deletelink);
			dgProductItems.AllowUserToAddRows = false;
			//dgProductItems.Rows.Clear();


		}

		void LoadGrid(ItemGrid item)
        {
			dgProductItems.AllowUserToAddRows = true;

			dgProductItems.Rows.Add(item.ItemCode, item.Name, item.Price, item.Discount, item.TotalQuantity, item.UnitId, item.SalePrice, item.CostPerUnit, item.CostPerUnitAfterDiscount, item.Vat, item.VatType, item.GivenVat*item.TotalQuantity);
			dgProductItems.AllowUserToAddRows = false;
			dgProductItems.AutoGenerateColumns = false;
			dgProductItems.Refresh();


			count++;
			txtCode.Text = "item-#" + count;
			ClearProductTextBox();
		}

		void ClearProductTextBox()
        {
			txtName.Text = "";
			txtPrice.Value = 0;
			txtDiscountIndividual.Value = 0;
			txtBuyingTotalQuantity.Value = 1;
			cmbUnitForBuy.SelectedIndex = 0;
			txtSalePrice.Value = 0;
			txtCostPerUnit.Value = 0;
        }

        private void dgProductItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			if(e.ColumnIndex == 12)
            {
				string itemCode = Convert.ToString(dgProductItems.Rows[e.RowIndex].Cells[0].Value);
				string productName = Convert.ToString(dgProductItems.Rows[e.RowIndex].Cells[1].Value);
				double buyingPrice = Convert.ToDouble(dgProductItems.Rows[e.RowIndex].Cells[2].Value);
				double discount = Convert.ToDouble(dgProductItems.Rows[e.RowIndex].Cells[3].Value);
				double quantity = Convert.ToDouble(dgProductItems.Rows[e.RowIndex].Cells[4].Value);
				int unitId = Convert.ToInt32(dgProductItems.Rows[e.RowIndex].Cells[5].Value);
				double salePrice = Convert.ToDouble(dgProductItems.Rows[e.RowIndex].Cells[6].Value);
				double costPerUnit = Convert.ToDouble(dgProductItems.Rows[e.RowIndex].Cells[7].Value);

				txtCode.Text = itemCode.ToString();
				txtName.Text = productName.ToString();
				txtPrice.Value = Convert.ToDecimal(buyingPrice);
				txtDiscountIndividual.Value = Convert.ToDecimal(discount);
				txtBuyingTotalQuantity.Value = Convert.ToDecimal(quantity);
				//cmbUnitForBuy.SelectedIndex = 

				
				var itemKey = 0;
				for (int i = units.Count - 1; i >= 0; i--)
				{
					var item = units.ElementAt(i);
					if (item.Key == unitId)
					{
						itemKey = item.Key;
					}
					//var itemValue = item.Value;
				}

				cmbUnitForBuy.SelectedIndex = itemKey;
				txtSalePrice.Value = Convert.ToDecimal(salePrice);
				txtCostPerUnit.Value = Convert.ToDecimal(costPerUnit);

			}

			if(e.ColumnIndex == 13)
            {
					DialogResult dr = MessageBox.Show("Are You Sure You Want To Delete ", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dr.ToString() == "Yes")
					{
						dgProductItems.Rows.RemoveAt(e.RowIndex);
						calculation();
					}
			
			}
        }

        private void dgProductItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtVatAll_ValueChanged(object sender, EventArgs e)
        {
			calculation();
        }

        private void radioBtnDutyFree_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnDutyFree.Checked)
            {
				label17.Visible = false;
				//txtVatAll.Value = 0;
				txtVatAll.Visible = false;
            }

			if(radioBtnDutyFree.Checked == false)
            {
				label17.Visible = true;
				//txtVatAll.Value = 0;
				txtVatAll.Visible = true;
			}
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCostPerUnit_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
