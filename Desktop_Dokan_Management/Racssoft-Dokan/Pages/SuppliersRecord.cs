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
using System.Text.RegularExpressions;

namespace Racssoft_Dokan.Pages
{
	public partial class SuppliersRecord : Common
	{
		long inventoryId;
		Dictionary<int, string> allSuppliers;
		public SuppliersRecord()
		{
			InitializeComponent();
			allSuppliers = getSuppliers();
			comboBoxSuppliers.Items.AddRange(getSuppliers().Select(s => s.Value).ToArray());
			comboBoxSuppliers.SelectedIndex = 0;
		}

		Dictionary<int, string> getSuppliers()
		{
			string sql = "Select * FROM Suppliers";
			DataTable dt = (DataTable)Select(sql).Data;
			return dt.AsEnumerable()
	  .ToDictionary<DataRow, int, string>(row => row.Field<int>(0),
								row => row.Field<string>(1)); // + " " + row.Field<string>(2) + " " + row.Field<string>(4));
		}

		private void textBox_Click(object sender, EventArgs e)
		{
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

		private void btnSearch_Click(object sender, EventArgs e)
		{
			string name = txtBoxSupplierSearch.Text.ToString();
			string sqlSupplier = @"SELECT s.SName, s.Phone, s.Address, i.ID, i.InvoiceNo, i.PaidAmount, i.Discount, i.Due, i.CreatedDate FROM Inventory i
			LEFT JOIN Suppliers s ON i.SupplierId = s.ID WHERE s.SName = '" + name + "'";
			DataTable dtSupplier = (DataTable)Select(sqlSupplier).Data;
			dgSuppliersInfo.Refresh();
			dgSuppliersInfo.DataSource = dtSupplier;
			dgSuppliersInfo.AutoGenerateColumns = false;
			dgSuppliersInfo.Columns[0].Visible = false;
			dgSuppliersInfo.Columns[1].Visible = false;
			dgSuppliersInfo.Columns[2].Visible = false;
			dgSuppliersInfo.Columns[3].Visible = false;

			lblName.Text = (dtSupplier.Rows.Count > 0 && !string.IsNullOrEmpty(dtSupplier.Rows[0]["SName"].ToString())) ? Convert.ToString(dtSupplier.Rows[0]["SName"]) : "_";
			lblMobileNo.Text = (dtSupplier.Rows.Count > 0 && !string.IsNullOrEmpty(dtSupplier.Rows[0]["Phone"].ToString())) ? Convert.ToString(dtSupplier.Rows[0]["Phone"]) : "_";
			lblAddress.Text = (dtSupplier.Rows.Count > 0 && !string.IsNullOrEmpty(dtSupplier.Rows[0]["Address"].ToString())) ? Convert.ToString(dtSupplier.Rows[0]["Address"]) : "_";
			//inventoryId = (dtSupplier.Rows.Count > 0 && !string.IsNullOrEmpty(dtSupplier.Rows[0]["ID"].ToString())) ? Convert.ToInt64(dtSupplier.Rows[0]["ID"]) : 0;

			if (dgSuppliersInfo.Columns.Count == 9)
			{
				DataGridViewLinkColumn edit = new DataGridViewLinkColumn();
				edit.UseColumnTextForLinkValue = true;
				edit.HeaderText = "view";
				edit.DataPropertyName = "lnkColumn";
				edit.LinkBehavior = LinkBehavior.AlwaysUnderline;
				edit.Text = "View Details";
				edit.LinkColor = Color.Blue;
				dgSuppliersInfo.Columns.Add(edit);


				DataGridViewLinkColumn payment = new DataGridViewLinkColumn();
				payment.UseColumnTextForLinkValue = true;
				payment.HeaderText = "Payment";
				payment.DataPropertyName = "lnkColumn";
				payment.LinkBehavior = LinkBehavior.AlwaysUnderline;
				payment.Text = "Payment Action";
				payment.LinkColor = Color.Blue;
				dgSuppliersInfo.Columns.Add(payment);

			}
			long count = 0;
			double totalPurchase = 0, totalPaid = 0, totalDue = 0;
			count = dtSupplier.Rows.Count;
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					double paid = !string.IsNullOrEmpty(dtSupplier.Rows[i]["PaidAmount"].ToString()) ? Convert.ToDouble(dtSupplier.Rows[i]["PaidAmount"]) : 0;
					double due = !string.IsNullOrEmpty(dtSupplier.Rows[i]["Due"].ToString()) ? Convert.ToDouble(dtSupplier.Rows[i]["Due"]) : 0;
					totalPaid += paid;
					totalDue += due;
				}
				totalPurchase = totalPaid + totalDue;
			}

			lblTotalPurchase.Text = totalPurchase.ToString();
			lblTotalPaid.Text = totalPaid.ToString();
			lblTotalDue.Text = totalDue.ToString();
			//int d = dgSuppliersInfo.Columns.Count;
			dgSuppliersInfo.Refresh();


		}

		private void dgSuppliersInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 9)
			{
				if (e.RowIndex > -1)
				{
					inventoryId = !string.IsNullOrEmpty(dgSuppliersInfo.Rows[e.RowIndex].Cells[3].Value.ToString()) ? Convert.ToInt64(dgSuppliersInfo.Rows[e.RowIndex].Cells[3].Value.ToString()) : 0;
					string sql = @"SELECT i.ID, i.InvoiceNo, s.SName, p.ID, p.Name, p.ItemCode AS [Item Code], b.Title AS Brand, c.Title AS Category, p.Price,
                p.PriceAfterDiscount AS [Discounted Buying Price], p.CostPerUnit AS [Buing Cost/unit], 
                d.SellingPrice AS [Selling Price], p.TotalQuantity AS [Total Quantity], d.RemainQuantity AS [Remain Quantity], i.OtherCost, i.PaidAmount, i.Discount, i.Due, i.CreatedDate 
                FROM (((((Inventory i LEFT JOIN Suppliers s ON i.SupplierId = s.ID) LEFT JOIN ProductDetails d ON d.InventoryId = i.ID)
                LEFT JOIN Products p ON p.ID = d.ProductID)
                LEFT JOIN Category c ON c.ID = p.CategoryId) LEFT JOIN Brand b ON b.ID = p.BrandId)
                WHERE i.ID = " + inventoryId + "";
					//DataTable dt = (DataTable)Select(sql).Data;
					(new InventoryDetails(sql)).ShowDialog();
					btnSearch_Click(sender, e);
					//getInventoryInvoice();
				}
			}
			if (e.ColumnIndex == 10)
			{
				if (e.RowIndex > -1)
				{
					inventoryId = !string.IsNullOrEmpty(dgSuppliersInfo.Rows[e.RowIndex].Cells[3].Value.ToString()) ? Convert.ToInt64(dgSuppliersInfo.Rows[e.RowIndex].Cells[3].Value.ToString()) : 0;
					(new InvoicePayment(inventoryId)).ShowDialog();
					btnSearch_Click(sender, e);
				}
			}

		}

		void hideResults()
		{
			listBoxSuppliersName.Visible = false;
		}

		private void txtBoxSupplierSearch_TextChanged(object sender, EventArgs e)
		{
			if (txtBoxSupplierSearch.Text != "Suppliers Name")
			{
				if (txtBoxSupplierSearch.Focused)
				{
					listBoxSuppliersName.Items.Clear();
					//supplierIds = new List<long>();
					//productId = 0;
					if (txtBoxSupplierSearch.Text.Length == 0)
					{
						hideResults();
						return;
					}

					if (!String.IsNullOrEmpty(txtBoxSupplierSearch.Text.Trim()))
					{
						string pattern = @"\b\w*" + txtBoxSupplierSearch.Text.Trim() + @"+\w*\b";
						listBoxSuppliersName.Items.Clear();

						foreach (KeyValuePair<int, string> s in allSuppliers.Where(p => Regex.IsMatch(p.Value, pattern, RegexOptions.IgnoreCase)))
						{
							listBoxSuppliersName.Items.Add(s.Value);
							//supplierIds.Add(s.Key);
						}




						if (listBoxSuppliersName.Items.Count > 0)
						{
							listBoxSuppliersName.Visible = true;
						}

						else
						{
							//txtSupplierName.Text = "Supplier's Name";
							MessageBox.Show("The Supplier Name is not in your database. Plese add this supplier!!!");
							//txtSupplierName.Text = "Supplier's Name";
							hideResults();
							txtBoxSupplierSearch.Text = "Supplier's Name";
						}
					}
				}
			}

		}

        private void listBoxSuppliersName_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (listBoxSuppliersName.SelectedIndex > -1)
			{
				int selectedIndex = listBoxSuppliersName.SelectedIndex;
				//supplierId = supplierIds[selectedIndex];
				txtBoxSupplierSearch.Text = listBoxSuppliersName.Items[selectedIndex].ToString();
			}

			hideResults();
		}

		private void comboBoxSuppliers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxSuppliers.SelectedIndex > 0)
			{
				long suppliersId = Convert.ToInt64(allSuppliers.ElementAt(comboBoxSuppliers.SelectedIndex - 1).Key);
				string sqlSupplier = @"SELECT s.SName, s.Phone, s.Address, i.ID, i.InvoiceNo, i.PaidAmount, i.Discount, i.Due, i.CreatedDate FROM Inventory i
			    LEFT JOIN Suppliers s ON i.SupplierId = s.ID WHERE s.ID = " + suppliersId + "";
				DataTable dtSupplier = (DataTable)Select(sqlSupplier).Data;
				dgSuppliersInfo.Refresh();
				dgSuppliersInfo.DataSource = dtSupplier;
				dgSuppliersInfo.AutoGenerateColumns = false;
				dgSuppliersInfo.Columns[0].Visible = false;
				dgSuppliersInfo.Columns[1].Visible = false;
				dgSuppliersInfo.Columns[2].Visible = false;
				dgSuppliersInfo.Columns[3].Visible = false;

				lblName.Text = (dtSupplier.Rows.Count > 0 && !string.IsNullOrEmpty(dtSupplier.Rows[0]["SName"].ToString())) ? Convert.ToString(dtSupplier.Rows[0]["SName"]) : "_";
				lblMobileNo.Text = (dtSupplier.Rows.Count > 0 && !string.IsNullOrEmpty(dtSupplier.Rows[0]["Phone"].ToString())) ? Convert.ToString(dtSupplier.Rows[0]["Phone"]) : "_";
				lblAddress.Text = (dtSupplier.Rows.Count > 0 && !string.IsNullOrEmpty(dtSupplier.Rows[0]["Address"].ToString())) ? Convert.ToString(dtSupplier.Rows[0]["Address"]) : "_";
				//inventoryId = (dtSupplier.Rows.Count > 0 && !string.IsNullOrEmpty(dtSupplier.Rows[0]["ID"].ToString())) ? Convert.ToInt64(dtSupplier.Rows[0]["ID"]) : 0;

				if (dgSuppliersInfo.Columns.Count == 9)
				{
					DataGridViewLinkColumn edit = new DataGridViewLinkColumn();
					edit.UseColumnTextForLinkValue = true;
					edit.HeaderText = "view";
					edit.DataPropertyName = "lnkColumn";
					edit.LinkBehavior = LinkBehavior.AlwaysUnderline;
					edit.Text = "View Details";
					edit.LinkColor = Color.Blue;
					dgSuppliersInfo.Columns.Add(edit);


					DataGridViewLinkColumn payment = new DataGridViewLinkColumn();
					payment.UseColumnTextForLinkValue = true;
					payment.HeaderText = "Payment";
					payment.DataPropertyName = "lnkColumn";
					payment.LinkBehavior = LinkBehavior.AlwaysUnderline;
					payment.Text = "Payment Action";
					payment.LinkColor = Color.Blue;
					dgSuppliersInfo.Columns.Add(payment);

				}
				long count = 0;
				double totalPurchase = 0, totalPaid = 0, totalDue = 0;
				count = dtSupplier.Rows.Count;
				if (count > 0)
				{
					for (int i = 0; i < count; i++)
					{
						double paid = !string.IsNullOrEmpty(dtSupplier.Rows[i]["PaidAmount"].ToString()) ? Convert.ToDouble(dtSupplier.Rows[i]["PaidAmount"]) : 0;
						double due = !string.IsNullOrEmpty(dtSupplier.Rows[i]["Due"].ToString()) ? Convert.ToDouble(dtSupplier.Rows[i]["Due"]) : 0;
						totalPaid += paid;
						totalDue += due;
					}
					totalPurchase = totalPaid + totalDue;
				}

				lblTotalPurchase.Text = totalPurchase.ToString();
				lblTotalPaid.Text = totalPaid.ToString();
				lblTotalDue.Text = totalDue.ToString();
				//int d = dgSuppliersInfo.Columns.Count;
				dgSuppliersInfo.Refresh();
				txtBoxSupplierSearch.Text = allSuppliers.ElementAt(comboBoxSuppliers.SelectedIndex - 1).Value.ToString();

			}
		}

        private void SuppliersRecord_Resize(object sender, EventArgs e)
        {
			if (groupBoxSuppliersRecord.Size.Width < 802)
			{
				groupBoxSuppliersRecord.Size = new System.Drawing.Size(802, 559);
				groupBoxSuppliersRecord.Dock = DockStyle.None;
			}

			else
			{
				groupBoxSuppliersRecord.Dock = DockStyle.Fill;
			}
		}
    }
}
