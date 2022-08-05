using Model;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Racssoft_Dokan.Pages
{
	public partial class Sale : Common
	{
		
		List<(int, string)> allProducts;

		
		List<ItemGrid> allProduct;
		List<string> productName;
		static long productId;
		List<long> productIds;
		List<ItemGrid> itemGrid = new List<ItemGrid>();
		List<ItemGrid> autoCompleteItems = new List<ItemGrid>();
		Dictionary<long, ItemGrid> selectedItems = new Dictionary<long, ItemGrid>();
		//Dictionary<int, Object> allProducts = new Dictionary<int, Object>();
		static ItemGrid aItemGrid;
		Dictionary<int, string> paymentMethods;
		List<int> isComboAdded = new List<int>();
		Dictionary<int, Label> isAddedLabel = new Dictionary<int, Label>();
		Dictionary<int, NumericUpDown> isAddedTextBox = new Dictionary<int, NumericUpDown>();
		Dictionary<int, Button> isAddedButton = new Dictionary<int, Button>();
		void Initial()
		{
			allProduct = new List<ItemGrid>();
			string sql = "";
			DataTable dt = (DataTable)Select(sql).Data;
			aItemGrid = new ItemGrid();

			allProducts = getProducts();

			//lblMessage.Text = "";
			txtInvoice.Text = "Invoice-#" + (getMaxId("SELECT MAX(Id) FROM Sales") + 1);
			txtName.AutoCompleteMode = AutoCompleteMode.None;
			txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
			productName = new List<string>();
			this.ActiveControl = txtName;
			productName = allProduct.Select(w => w.Name).ToList();
			productIds = allProduct.Select(w => w.ID).ToList();
			hideResults();
			paymentMethods = getPaymentMethod();
			comboPaymentMethod.Items.AddRange(getPaymentMethod().Select(s => s.Value).ToArray());


			gd.Rows.Clear();
			gd.Columns.Clear();
			gd.Columns.Add("cItemId", "Item Code");
			gd.Columns.Add("cSerial", "#");
			gd.Columns.Add("cItemName", "Item Name");
			gd.Columns.Add("cCategory", "Category");
			gd.Columns.Add("cBrand", "Brand");
			gd.Columns.Add("cQuantity", "Quantity");
			gd.Columns.Add("cPrice", "Unit Price");
			gd.Columns.Add("cAmount", "Amount");
			gd.Columns[0].Visible = false;
			gd.Columns[1].ReadOnly = true;
			gd.Columns[2].ReadOnly = true;
			gd.Columns[4].ReadOnly = true;
			gd.Columns[5].ReadOnly = true;
			

			DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
			Editlink.UseColumnTextForLinkValue = true;
			Editlink.HeaderText = "Edit";
			Editlink.DataPropertyName = "lnkColumn";
			Editlink.LinkBehavior = LinkBehavior.AlwaysUnderline;
			Editlink.Text = "Edit";
			Editlink.LinkColor = Color.Blue;
			gd.Columns.Add(Editlink);

			DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
			Deletelink.UseColumnTextForLinkValue = true;
			Deletelink.HeaderText = "Delete";
			Deletelink.DataPropertyName = "lnkColumn";
			Deletelink.LinkBehavior = LinkBehavior.NeverUnderline;
			Deletelink.Text = "Delete";
			Deletelink.LinkColor = Color.Red;
			gd.Columns.Add(Deletelink);
		}
		public Sale()
		{
			InitializeComponent();
			Initial();
			gd.AutoGenerateColumns = false;
			gd.AllowUserToAddRows = false;
		}
		private void txt_KeyUp(object sender, KeyEventArgs e)
		{
			Calculation();
		}

        List<(int, string)> getProducts()
        {
			List<(int, string)> sample = new List<(int, string)>();
            string sql = "Select * FROM Products_1";
            DataTable dt = (DataTable)Select(sql).Data;
			int count = 0, key = 0;
			string productName;
			count = dt.Rows.Count;
			for(int i = 0; i < count; i++)
            {
				key = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
				productName = dt.Rows[i]["Name"].ToString();
				sample.Add((key, productName));
            }
			return sample;
         //   return dt.AsEnumerable()
         //.ToList<((int, string))>(row => row.Field<int>(0),
         //                       row => row.Field<string>(1));

            //return dt.AsEnumerable().ToList <(int, string)>
        }

		//  internal Dictionary<int, Object> getProducts()
		//  {
		//      string sql = "Select * FROM Products";
		//      DataTable dt = (DataTable)Select(sql).Data;
		//      return dt.AsEnumerable()
		//.ToDictionary<DataRow, int, Object>(row => row.Field<int>(0),
		//                          row => row.Field<Object>(1));
		//  }

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

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
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
			this.panelPaymentWays.Controls.Add(textBox);
			this.panelPaymentWays.Controls.Add(label);
			this.panelPaymentWays.Controls.Add(delete);
			delete.Click += new System.EventHandler(this.deleteButton_Click_1);
			textBox.ValueChanged += new System.EventHandler(this.txtPaid_TextChanged);
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
			isComboAdded.Remove(i);
			this.panelPaymentWays.Controls.Remove((Button)sender);
			isAddedButton.Remove(i);
			this.panelPaymentWays.Controls.Remove(isAddedLabel[i]);
			isAddedLabel.Remove(i);
			this.panelPaymentWays.Controls.Remove(isAddedTextBox[i]);
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
				textBoxes.ElementAt(i).Value.Location = new System.Drawing.Point(150, 10 + i * 22);
				buttons.ElementAt(i).Value.Location = new System.Drawing.Point(260, 10 + i * 22);
			}
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


        //private void txtName_TextChanged(object sender, EventArgs e)
        //{
        //    lbAutoComplete.Items.Clear();
        //    productIds = new List<long>();
        //    //autoCompleteItems = new List<ItemGrid>();
        //    //productId = 0;
        //    if (txtName.Text.Length == 0)
        //    {
        //        hideResults();
        //        return;
        //    }

        //    if (!String.IsNullOrEmpty(txtName.Text.Trim()))
        //    {
        //        string pattern = @"\b\w*" + txtName.Text.Trim() + @"+\w*\b";
        //        lbAutoComplete.Items.Clear();

        //        foreach (ItemGrid s in allProduct.Where(p => Regex.IsMatch(p.Name, pattern, RegexOptions.IgnoreCase)))
        //        {
        //            lbAutoComplete.Items.Add(s.Name);
        //            autoCompleteItems.Add(s);
        //        }
        //        if (lbAutoComplete.Items.Count > 0)
        //        {
        //            lbAutoComplete.Visible = true;
        //        }
        //        else
        //        {
        //            hideResults();
        //        }
        //    }
        //}


        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Focused)
            {
                lbAutoComplete.Items.Clear();
                productIds = new List<long>();
                //productId = 0;
                if (txtName.Text.Length == 0)
                {
                    hideResults();
                    return;
                }

                if (!String.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    string pattern = @"\b\w*" + txtName.Text.ToLower().Trim() + @"+\w*\b";
                    lbAutoComplete.Items.Clear();
					int count = allProducts.Count;

                    for(int i = 0; i < count; i++)
                    {
						Regex nameRegex = new Regex(pattern);
						if (nameRegex.IsMatch(allProducts[i].Item2.ToLower()))
						{
							lbAutoComplete.Items.Add(allProducts[i].Item2);
							productIds.Add(allProducts[i].Item1);
						}
                    }

					//foreach (List<(int, string)> s in allProducts.Where(p => Regex.IsMatch(p.Item2, pattern, RegexOptions.IgnoreCase)))
					//{
					//	lbAutoComplete.Items.Add(s.Item2);
					//	productIds.Add(s.Item1);
					//}
					if (lbAutoComplete.Items.Count > 0)
                    {
                        lbAutoComplete.Visible = true;
                    }
                    else
                    {
						MessageBox.Show("This Model Name is not in your inventory!!!");
						//txtSupplierName.Text = "Supplier's Name";
						hideResults();
						txtName.Text = "";
						
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
					string sql = @"SELECT d.SellingPrice, d.RemainQuantity, c.Title, b.Title FROM (((Products p LEFT JOIN ProductDetails d ON p.ID = d.ProductID)
					LEFT JOIN Category c ON p.CategoryId = c.ID)
					LEFT JOIN Brand b ON b.ID = p.BrandId)
					WHERE p.ID =" + productId + "";
					DataTable dt = (DataTable)Select(sql).Data;
					txtPrice.Text = Convert.ToString(dt.Rows[0]["SellingPrice"]);
					lblQuantity.Text = Convert.ToString(dt.Rows[0]["RemainQuantity"]);
					txtCategory.Text = String.IsNullOrEmpty(dt.Rows[0]["c.Title"].ToString()) ? "NULL" : Convert.ToString(dt.Rows[0]["c.Title"]);
					txtBrand.Text = String.IsNullOrEmpty(dt.Rows[0]["b.Title"].ToString()) ? "NULL" : Convert.ToString(dt.Rows[0]["b.Title"]);
				
				
			}
            else
            {
				txtName.Text = "";
			}
			hideResults();	
        }


        //void lbAutoComplete_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    productId = 0;
        //    if (lbAutoComplete.SelectedIndex > -1)
        //    {
        //        int selectedIndex = lbAutoComplete.SelectedIndex;
        //        aItemGrid = autoCompleteItems[selectedIndex];
        //        txtName.Text = lbAutoComplete.Items[selectedIndex].ToString();
        //        if (!selectedItems.ContainsKey(aItemGrid.ID))
        //        {
        //            selectedItems.Add(aItemGrid.ID, aItemGrid);
        //            LoadGrid(aItemGrid);
        //        }
        //        //gd.DataSource = selectedItems;
        //        //gd.Refresh();
        //    }
              
		      //Calculation();

        //    hideResults();
        //}



        void hideResults()
		{
			lbAutoComplete.Visible = false;
		}
		//private void LoadGrid(Dictionary<long, ItemGrid> ds)
		private void LoadGrid(ItemGrid ds)
		{
			
			//gd.DataSource = ds;
			int count = 0;
			//int quantity = quan;
			//foreach (ItemGrid i in ds.Values) {
			//ItemGrid i = ds.Values.Last();
			    gd.AllowUserToAddRows = true;
			int flag = 0;

			//gd.Rows.Add();
			for (int i = 0; i < gd.Rows.Count; i++)
			{
				if (gd.Rows[i].Cells[2].Value != null && gd.Rows[i].Cells[2].Value.ToString() == ds.Name)
                {
					//quantity = quantity + Convert.ToInt32(gd.Rows[i].Cells[3].Value.ToString());
					gd.Rows[i].Cells[3].Value = ds.SaleQuantity;
					gd.Rows[i].Cells[5].Value = ds.SalePrice * ds.SaleQuantity;
					flag = 1;
				}

			}
			
			if(flag == 0) gd.Rows.Add(ds.ID, ++count, ds.Name, ds.Category, ds.Brand, ds.SaleQuantity, ds.SalePrice, ds.SalePrice * ds.SaleQuantity);
			gd.AllowUserToAddRows = false;
			//gd.Rows.Add(++count);
			//gd.Rows.Add(i.ItemName);
			//gd.Rows.Add(1);
			//gd.Rows.Add(i.SellPrice);
			//gd.Rows.Add(i.SellPrice);
			//gd.Columns[0].Visible = false;
			//	gd.Columns[1].Visible = false;
			//	gd.Columns[3].Visible = false;
			//	gd.Columns[4].Visible = false;
			//	gd.Columns[5].Visible = false;
			//	gd.Columns[6].Visible = false;

			//	gd.Columns[10].Visible = false;
			//	gd.Columns[11].Visible = false;
			//	gd.Columns[12].Visible = false;
			//	gd.Columns[13].Visible = false;
			//	gd.Columns[14].Visible = false;
			//	gd.Columns[15].Visible = false;

			//	gd.Columns[7].HeaderText = "Quantity";
			//	gd.Columns[8].HeaderText = "Price";

			//	gd.Columns[2].ReadOnly = true;
			//	gd.Columns[8].ReadOnly = true;
			//	gd.Columns[9].ReadOnly = true;

			//	gd.Columns.Add("Amount", i.SellPrice.ToString());
			//DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
			//Editlink.UseColumnTextForLinkValue = true;
			//Editlink.HeaderText = "Edit";
			//Editlink.DataPropertyName = "lnkColumn";
			//Editlink.LinkBehavior = LinkBehavior.SystemDefault;
			//Editlink.Text = "Edit";
			//gd.Columns.Add(Editlink);




			//}

			gd.Refresh();
		}

		
		private void btnReloadItem_Click(object sender, EventArgs e)
		{
			Initial();
			new Sale();
		}

		private void textBox_Click(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(TextBox))
				((TextBox)sender).SelectAll();
			else
			{
				NumericUpDown numeric = (NumericUpDown)sender;
				(numeric).Select(0, numeric.Value.ToString().Length + 3);
			}
		}

		private void gd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			//int i = gd.CurrentCell.RowIndex;.
			//int j = gd.CurrentCell.ColumnIndex;
			//string a = gd.Rows[i].Cells[j].Value.ToString();
			if (e.ColumnIndex == 3)
			{
				long id = Convert.ToInt64(gd.Rows[e.RowIndex].Cells[0].Value.ToString());
				double quantity = Convert.ToDouble(gd.Rows[e.RowIndex].Cells[3].Value.ToString());
				if(quantity > selectedItems[id].RemainQuantity)
				{
					MessageBox.Show("Not Sufficient Amount");
					return;
				}
				double price = Convert.ToDouble(gd.Rows[e.RowIndex].Cells[4].Value.ToString());
				gd.Rows[e.RowIndex].Cells[5].Value = quantity * price;
				Calculation();
			}
		}
		void Calculation()
		{
			double amount = 0;
			//double vat = String.IsNullOrEmpty(txtVat.Text) ? 0 : Convert.ToDouble(txtVat.Text);
			foreach (DataGridViewRow d in gd.Rows)
			{
				amount += Convert.ToDouble(d.Cells[5].Value);
			}
			
			double discount = String.IsNullOrEmpty(txtDiscount.Text) ? 0 : Convert.ToDouble(txtDiscount.Text);
			//gd.Rows.Clear();

			//double paidByBank = String.IsNullOrEmpty(txtPaidByBank.Text) ? 0 : Convert.ToDouble(txtPaidByBank.Text);
			//double paidByCash = String.IsNullOrEmpty(txtPaidByCash.Text) ? 0 : Convert.ToDouble(txtPaidByCash.Text);
			double paid = 0;
			long id = 2;
			//var nn = Product.BalanceSheet(id);
			//double curr = nn.Item1;

			foreach (KeyValuePair<int, NumericUpDown> d in isAddedTextBox)
			{
				//int digitalWalletId = Convert.ToInt32(d.Key) + 1;
				double transactionAmount = Convert.ToDouble(Convert.ToString(d.Value.Value));
				paid = paid + transactionAmount;
			}


			int count = 0;
			double totalVat = 0;

			foreach (ItemGrid d in selectedItems.Values)
			{

				double quantity = d.SaleQuantity;
				double totalPrice = d.ActualSalePrice * quantity;
				double indiPrice = (totalPrice - ((totalPrice * discount) / amount)) / quantity;
				d.SalePrice = indiPrice;

				d.GivenVat = indiPrice * quantity * (d.Vat / 100);
				d.DiscountIndi = d.Discount + (d.ActualSalePrice * quantity * discount / amount)/quantity;
				totalVat = totalVat + d.GivenVat;
				//LoadGrid(d);
				//d.Cells[5].Value = price;
				//d.Cells[4].Value = price / quantity;
			}
			
			
			//double paid = paidByBank + paidByCash;
			double netPayable = 0, totalAfterDiscount = 0;
			totalAfterDiscount = amount - discount;
			netPayable = totalAfterDiscount + totalVat;
			
			
			txtPayable.Text = netPayable.ToString();
			double due = 0;
			if(netPayable > paid) due = netPayable - paid;
			txtDue.Text = due.ToString();
			double paidNote = String.IsNullOrEmpty(txtPaidNote.Text) ? 0 : Convert.ToDouble(txtPaidNote.Text);
			double change = 0;
			if (paid > netPayable)
			{
				change = paid - netPayable;
			}
			txtVat.Text = Convert.ToString(totalVat);
			//double change = paid - amount;
			txtChange.Text = change.ToString();
			txtTotal.Text = amount.ToString();
			txtTotalAmount.Text = txtPayable.Text;
			//txtPaidByCash1.Text = txtPaidByCash.Text;
			//txtPaidByBank1.Text = txtPaidByBank.Text;
			txtTotalPaidAmount.Text = paid.ToString();
			txtDue1.Text = txtDue.Text;
		}

		private void gd_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 7)
			{
				if (e.RowIndex > -1)
				{
					int count = gd.Rows.Count;
					if (count > 0)
					{
						long id = Convert.ToInt64(gd.Rows[e.RowIndex].Cells[0].Value.ToString());
						string name = gd.Rows[e.RowIndex].Cells[2].Value.ToString();
						DialogResult dr = MessageBox.Show("Are You Sure You Want To Delete " + Environment.NewLine
							+ name + "'s Informations", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (dr.ToString() == "Yes")
						{
							selectedItems.Remove(id);
							gd.Rows.RemoveAt(e.RowIndex);
							Calculation();
						}
					}
				}
			}

			if (e.ColumnIndex == 6)
			{
				int count = gd.Rows.Count;
				if (count > 0 && e.RowIndex > -1)
				{
					long id = Convert.ToInt64(gd.Rows[e.RowIndex].Cells[0].Value.ToString());
					string name = gd.Rows[e.RowIndex].Cells[2].Value.ToString();
					double quantity = Convert.ToDouble(gd.Rows[e.RowIndex].Cells[5].Value.ToString());

					txtName.Text = name;
					numericQuantity.Value = Convert.ToDecimal(quantity);
					
					productId = id;
					foreach (ItemGrid s in selectedItems.Values)
					{
						if (productId == s.ID)
						{
							lblQuantity.Text = s.RemainQuantity.ToString();

						}
					}
				}
			}
		
	}

		void textboxEnterEvent(object sender, KeyEventArgs e)
       {
			if( e.KeyValue == 13)
					{
				SendKeys.Send("{TAB}");

			}
        }

		private void btnOk_Click(object sender, EventArgs e)
		{
			int gdRowsCount = gd.Rows.Count;
			if (gdRowsCount > 0)
			{
				int UserID = 1;
				//!string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? Convert.ToDouble(dt.Rows[0][2]) : 0;
				string customerName = !string.IsNullOrEmpty(txtCustomerName.Text.ToString()) ? txtCustomerName.Text.ToString() : "Customer Name";
				string customerMobile = !string.IsNullOrEmpty(txtCustomerMobile.Text.ToString()) ? txtCustomerMobile.Text.ToString() : "Customer Mobile";
				double totalPrice = !string.IsNullOrEmpty(txtTotalAmount.Text.ToString()) ? Convert.ToDouble(txtTotalAmount.Text.ToString()) : 0;
				double totalPayable = !string.IsNullOrEmpty(txtTotalAmount.Text.ToString()) ? Convert.ToDouble(txtTotalAmount.Text) : 0;
				double bankPay = 0;
				double CashPay = 0;
				double due = !string.IsNullOrEmpty(txtDue.Text.ToString()) ? Convert.ToDouble(txtDue.Text.ToString()) : 0;
				double vat = !string.IsNullOrEmpty(txtVat.Text.ToString()) ? Convert.ToDouble(txtVat.Text.ToString()) : 0;
				double discount = !string.IsNullOrEmpty(txtDiscount.Text.ToString()) ? Convert.ToDouble(txtDiscount.Text.ToString()) : 0;
				double change = !string.IsNullOrEmpty(txtChange.Text.ToString()) ? Convert.ToDouble(txtChange.Text.ToString()) : 0;
				string email = "shahparan9988@gmail.com";
				int totalPoint = 0;
				double amount = 0;
				double creditAmount = 0;
				bool isPaidVat = false;

				BalanceSheetGrid balanceSheet = new BalanceSheetGrid();

				string sql = @"INSERT INTO Customer(CustomerName, CustomerMobile, Email, TotalPoint, CreatedDate) VALUES ('" + customerName + "', '" +
					customerMobile + "', '" + email + "', " + totalPoint + ", '" + DateTime.Now + "')";

				CUD(sql);
				long customerId = getMaxId("SELECT MAX(Id) FROM Customer");
				long balanceSheetId = getMaxId("SELECT MAX(Id) FROM BalanceSheet");
				if (balanceSheetId > 0)
				{
					string balanceSheetSql = "Select * FROM BalanceSheet WHERE ID = " + balanceSheetId + "";
					DataTable balanceSheetDt = (DataTable)Select(balanceSheetSql).Data;

					balanceSheet.ID = Convert.ToInt64(balanceSheetDt.Rows[0]["ID"]);
					balanceSheet.OpeningBalance = Convert.ToDouble(balanceSheetDt.Rows[0]["OpeningBalance"]);
					balanceSheet.CurrentBalance = Convert.ToDouble(balanceSheetDt.Rows[0]["CurrentBalance"]);
					balanceSheet.TotalCredit = Convert.ToDouble(balanceSheetDt.Rows[0]["TotalCredit"]);
					balanceSheet.CreditLiability = Convert.ToDouble(balanceSheetDt.Rows[0]["CreditLiability"]);
					balanceSheet.TotalDebit = Convert.ToDouble(balanceSheetDt.Rows[0]["TotalDebit"]);
					balanceSheet.DebitLiability = Convert.ToDouble(balanceSheetDt.Rows[0]["DebitLiability"]);
					balanceSheet.UpdatedDate = Convert.ToDateTime(balanceSheetDt.Rows[0]["UpdatedDate"]);

				}

				string sql1 = @"INSERT INTO Sales(Invoice, CustomerId, TotalPayable, BankPay, CashPay, Due, Vat, Discount, Change, CreatedDate, IsVatPaid) 
						VALUES ('" + txtInvoice.Text + "', " + customerId + ", " + totalPayable + ", " + bankPay + ", " + CashPay + ", " + due + ", " + vat + ", " + discount + ", " + change + ", '" + DateTime.Now + "', " + false + ")";
				CUD(sql1);

				long salesId = getMaxId("SELECT MAX(Id) FROM Sales");

				foreach (KeyValuePair<int, NumericUpDown> d in isAddedTextBox)
				{
					int digitalWalletId = Convert.ToInt32(d.Key);
					double transactionAmount = Convert.ToDouble(Convert.ToString(d.Value.Value));

					string dGHistorySql = @"INSERT INTO DigitalWallet_History(DigitalWalletId, TransactionType, DetailPurpose, TransactedAmount, UpdatedDate, BalanceSheetId)
				VALUES(" + digitalWalletId + ", 'DEPOSITED', 'SALES PAYMENT', " + transactionAmount + ", '" + DateTime.Now + "', " + balanceSheetId + ")";
					CUD(dGHistorySql);
					long dgHistoryId = getMaxId("SELECT MAX(Id) FROM DigitalWallet_History");

					string sqlSalesHistory = @"INSERT INTO Sales_Payment_Methods(SalesId, DigitalWalletId, TransactionAmount, BalanceSheetId, UpdatedDate, DG_HistoryId)
									VALUES(" + salesId + ", " + digitalWalletId + ", " + transactionAmount + ", " + balanceSheetId + ", '" + DateTime.Now + "', " + dgHistoryId + ")";
					CUD(sqlSalesHistory);
					string sqlGetAmount = @"SELECT * FROM DigitalWallet WHERE ID = " + digitalWalletId + "";
					DataTable dt = (DataTable)Select(sqlGetAmount).Data;

					if (dt.Rows.Count > 0)
					{
						amount = Convert.ToDouble(dt.Rows[0]["Amount"]);

					}

					creditAmount = creditAmount + transactionAmount;
					amount = amount + transactionAmount;
					string sqlUpdateAmount = @"UPDATE DigitalWallet SET Amount = " + amount + " WHERE ID = " + digitalWalletId + "";
					CUD(sqlUpdateAmount);
				}

				string digitalWalletSql = @"SELECT * FROM DigitalWallet";
				DataTable digitalWalletDt = (DataTable)Select(digitalWalletSql).Data;
				double totalDigitalWalletBalance = 0;
				for (int i = 0; i < digitalWalletDt.Rows.Count; i++)
				{
					totalDigitalWalletBalance = totalDigitalWalletBalance + Convert.ToDouble(digitalWalletDt.Rows[i]["Amount"]);
				}

				balanceSheet.CurrentBalance = totalDigitalWalletBalance;
				balanceSheet.TotalCredit = balanceSheet.TotalCredit + creditAmount;
				balanceSheet.CreditLiability = balanceSheet.CreditLiability + due;




				//int totalRows = gd.Rows.Count - 1;
				//MessageBox.Show(totalRows.ToString());

				int count = 0;
				//int quantity = Convert.ToInt32(gd.Rows[count].Cells[3].Value.ToString());

				if (DateTime.Now.Date.ToString("MM/dd/yyyy") == balanceSheet.UpdatedDate.Date.ToString("MM/dd/yyyy"))
				{
					string balanceSheetsql1 = @"UPDATE BalanceSheet SET CurrentBalance = " + balanceSheet.CurrentBalance + ", TotalCredit = " + balanceSheet.TotalCredit + ", CreditLiability = " + balanceSheet.CreditLiability + " WHERE ID = " + balanceSheet.ID + "";
					CUD(balanceSheetsql1);
				}

				if (DateTime.Now.Date.ToString("MM/dd/yyyy") != balanceSheet.UpdatedDate.Date.ToString("MM/dd/yyyy"))
				{
					string balanceSheetsql1 = @"INSERT INTO BalanceSheet(OpeningBalance, CurrentBalance, TotalCredit,
											CreditLiability, TotalDebit, DebitLiability, UpdatedDate) VALUES
											(" + balanceSheet.CurrentBalance + ", " + balanceSheet.CurrentBalance + "" +
												", " + balanceSheet.TotalCredit + ", " + balanceSheet.CreditLiability + "" +
												", " + balanceSheet.TotalDebit + ", " + balanceSheet.DebitLiability + "" +
												",'" + DateTime.Now + "')";
					CUD(balanceSheetsql1);
				}



				foreach (ItemGrid s in selectedItems.Values)
				{
					double quantity = s.SaleQuantity;
					string sql2 = @"INSERT INTO SalesDetails(SalesId, ProductId, Quantity, SellingPrice, GivenVat, TotalPrice, Discount, UnitId, VatPaid) VALUES
				(" + salesId + ", " + s.ID + ", " + quantity + ", " + s.SalePrice + ", " + s.GivenVat + ", " + (quantity * s.SalePrice) + ", " + s.DiscountIndi + ", " + s.UnitId + ", 0)";
					CUD(sql2);
					count++;

					string sql3 = @"UPDATE ProductDetails SET RemainQuantity = " + (s.RemainQuantity - quantity) + " WHERE ProductID = " + s.ID + "";
					CUD(sql3);

					string sql4 = @"UPDATE ProductDetails_1 SET RemainQuantity = " + (s.RemainQuantity - quantity) + " WHERE ProductID = " + s.ID + "";
					CUD(sql4);

					if ((s.RemainQuantity - quantity) < 1)
					{
						string sqlDeleteProducts = @"DELETE FROM Products_1 WHERE ID = " + s.ID + "";
						CUD(sqlDeleteProducts);
						string sqlDeleteProductDetails = @"DELETE FROM ProductDetails_1 WHERE ProductID = " + s.ID + "";
						CUD(sqlDeleteProductDetails);
					}
					//string sql4 = @"UPDATE Products SET Discount = " + s.DiscountIndi + " WHERE ID = " + s.ID + "";
					//CUD(sql4);
				}
				panelPaymentWays.Controls.Clear();
				isAddedButton.Clear();
				isAddedLabel.Clear();
				isAddedTextBox.Clear();
				comboPaymentMethod.Items.Clear();
				Clear();
				Initial();
				MessageBox.Show("Saved Successfully");
			}

            else
            {
				MessageBox.Show("Please, add products for sale!");
            }
		}


		long getMaxId(string cmd)
		{
			DataTable dt;
			//cmd = "SELECT MAX(Id) FROM Products";
			dt = (DataTable)Select(cmd).Data;
			long id = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()) ? Convert.ToInt64(dt.Rows[0][0]) : 0;
			return id;
		}

		void Clear()
        {
			txtCustomerName.Text = "Customer Name";
			numericQuantity.Value = 1;
			txtCustomerMobile.Text = "Customer Mobile";
			txtName.Text = "Model Name";
			numericDiscount.Value = 0;
			gd.Rows.Clear();
			txtTotal.Text = "0";
			txtDiscount.Text = "0";
			txtVat.Text = "0";
			txtPayable.Text = "0";
			txtPaidNote.Text = "0";
			txtDue.Text = "0";
			txtChange.Text = "0";
			txtTotalBuyTimes.Text = "0";
			txtTotalAmount.Text = "0";
			txtFirstTimeBuy.Text = "0";
			txtPoints.Text = "0";
			txtTotalPaidAmount.Text = "0";
			txtDue.Text = "0";
			panelPaymentWays.Controls.Clear();


		}
		


		private void txtQuantity_Leave(object sender, EventArgs e)
        {
			if (txtName.Text != "" && numericQuantity.Value != 0 && txtName.Text != "Model Name")
			{
				if (numericQuantity.Value <= Convert.ToInt32(lblQuantity.Text))
				{
					//int flagForProductId = 0;
					double quantity = Convert.ToDouble(numericQuantity.Value);
					//foreach (ItemGrid s in selectedItems.Values)
					//{
					//	if (txtName.Text == s.Name)
					//	{
					//		productId = s.ID;

					//	}
					//}


					string sql = @"SELECT * FROM (((Products p LEFT JOIN ProductDetails d ON p.ID = d.ProductID)
				LEFT JOIN Category c ON p.CategoryId = c.ID)
				LEFT JOIN Brand b ON b.ID = p.BrandId)
				WHERE p.ID =" + productId + ""; ;
					DataTable dt = (DataTable)Select(sql).Data;
					double discountIndi = Convert.ToDouble(numericDiscount.Value);


					aItemGrid = new ItemGrid();
					aItemGrid.ID = Convert.ToInt64(dt.Rows[0]["p.ID"]);
					aItemGrid.Name = dt.Rows[0]["Name"].ToString();
					aItemGrid.ItemCode = dt.Rows[0]["ItemCode"].ToString();
					aItemGrid.Category = String.IsNullOrEmpty(dt.Rows[0]["c.Title"].ToString()) ? "NULL" : Convert.ToString(dt.Rows[0]["c.Title"]);
					aItemGrid.Brand = String.IsNullOrEmpty(dt.Rows[0]["b.Title"].ToString()) ? "NULL" : Convert.ToString(dt.Rows[0]["b.Title"]);
					aItemGrid.RemainQuantity = Convert.ToDouble(dt.Rows[0]["RemainQuantity"]);
					aItemGrid.SaleQuantity = Convert.ToDouble(numericQuantity.Value);
					aItemGrid.Vat = Convert.ToDouble(dt.Rows[0]["Vat"]);

					aItemGrid.SalePrice = Convert.ToDouble(dt.Rows[0]["SellingPrice"]) - (discountIndi);
					aItemGrid.ActualSalePrice = Convert.ToDouble(dt.Rows[0]["SellingPrice"]) - (discountIndi);
					aItemGrid.DiscountIndi = (discountIndi);
					aItemGrid.Discount = (discountIndi);
					aItemGrid.UnitId = Convert.ToInt32(dt.Rows[0]["p.UnitId"]);
					aItemGrid.CreateDate = Convert.ToDateTime(dt.Rows[0]["CreateDate"]);
					aItemGrid.UpdateDate = Convert.ToDateTime(dt.Rows[0]["UpdateDate"]);
					aItemGrid.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);

					int flag = 0;
					foreach (ItemGrid s in selectedItems.Values)
					{
						if (txtName.Text == s.Name)
						{
							flag = 1;

						}
					}

					if (flag == 0) selectedItems.Add(aItemGrid.ID, aItemGrid);
					//allProduct.Add(aItemGrid);

					LoadGrid(aItemGrid);


					//gd.DataSource = selectedItems;
					gd.Refresh();

					Calculation();

					customerInformation();
					clearItem();



				}

				else MessageBox.Show("The amount of quantity is out of stock");
			}

			else MessageBox.Show("Enter the Model name/number of quantity");



			//hideResults();
		}

		void clearItem()
        {
			txtName.Text = "Model Name";
			txtCategory.Text = "";
			txtBrand.Text = "";
			numericQuantity.Value = 0;
			numericDiscount.Value = 0;
			txtPrice.Text = "";
			lblQuantity.Text = "_";
        }

		void customerInformation()
		{
			string mobile = txtCustomerMobile.Text.ToString();
			string sql = @"SELECT ID, CustomerName, CustomerMobile, CreatedDate FROM Customer WHERE CustomerMobile ='" + mobile + "'";
			DataTable dt = (DataTable)Select(sql).Data;
			int count = dt.Rows.Count;
			if (count > 0)
			{
				txtCustomerName.Text = Convert.ToString(dt.Rows[0]["CustomerName"]);
			}
			if(count == 0)
            {
				txtCustomerName.Text = "Customer Name";
			}
			if(txtCustomerName.Text == "") txtCustomerName.Text = "Customer Name";


			txtTotalBuyTimes.Text = count.ToString();
			
			if (count > 0 && dt.Rows[0]["CreatedDate"] != null)
			{
				txtFirstTimeBuy.Text = Convert.ToString(dt.Rows[0]["CreatedDate"]);

			}

			else if(count == 0) txtFirstTimeBuy.Text = "First Time Buy";
		}



        private void dt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtInvoice_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
			Calculation();
        }

     

        private void txtVat_TextChanged(object sender, EventArgs e)
        {
			Calculation();
		}

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
			Calculation();
        }

     

        private void btnCancel_Click(object sender, EventArgs e)
        {
			Clear();
        }

        

        private void txtCustomerMobile_Leave(object sender, EventArgs e)
        {
			customerInformation();
        }

        private void txtCustomerMobile_KeyUp(object sender, KeyEventArgs e)
        {
			customerInformation();
		}

        private void Sale_Click(object sender, EventArgs e)
        {
			Calculation();
        }

        private void txtCustomerName_TabIndexChanged(object sender, EventArgs e)
        {
			
		}

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
			//if (txtCustomerName.Text == "") txtCustomerName.Text = "Customer Name";
		}

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
			if (txtCustomerName.Text == "") txtCustomerName.Text = "Customer Name";
		}

        private void txtCustomerMobile_Leave_1(object sender, EventArgs e)
        {
			customerInformation();
			if (txtCustomerMobile.Text == "") txtCustomerMobile.Text = "Customer Mobile";
		}

        private void txtName_Leave(object sender, EventArgs e)
        {
			
			if (txtName.Text == "") txtName.Text = "Model Name";
		}

        private void btnReloadItem_Click_1(object sender, EventArgs e)
        {
			clearItem();
        }

        private void groupBox3_MouseCaptureChanged(object sender, EventArgs e)
        {
			Calculation();
        }
    }
}
