using Model;
using Models;
using System;
using System.Text.RegularExpressions;
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
    public partial class Inventory : Common
    {
        string sql;
        List<string> allNames;

        //const double stockValue;
        public Inventory()
        {
            InitializeComponent();
            Initial();
            allNames = getProducts();
        }

        void Initial()
        {
            sql = @"SELECT i.ID, i.InvoiceNo AS [Invoice No], s.SName AS [Supplier Name], p.Name AS [Model], c.Title AS [Category], b.Title AS [Brand], p.ItemCode AS [Item Code], i.OtherCost AS [Other Cost], i.PaidAmount AS [Paid Amount], i.Discount, i.Due, i.CreatedDate AS [Created Date] 
            FROM (((((Products_1 p LEFT JOIN ProductDetails_1 d ON p.ID = d.ProductID) LEFT JOIN Category c ON c.ID = p.CategoryId) LEFT JOIN Brand b ON b.ID = p.BrandId)
            LEFT JOIN Inventory i ON d.InventoryId = i.ID) LEFT JOIN Suppliers s ON i.SupplierId = s.ID)";
            getInventoryInvoice(sql);

            // Stock value calculation
            string sqlStock = @"SELECT p.Price, pd.RemainQuantity FROM Products_1 p LEFT JOIN  ProductDetails_1 pd
            ON p.ID = pd.ProductID";
            getStockValue(sqlStock);
        }

        List<string> getProducts()
        {
            List<string> sample = new List<string>();
            string sql = "Select p.ID, p.Name, c.Title, b.Title FROM ((Products_1 p LEFT JOIN Category c ON p.CategoryId = c.ID)" +
                "LEFT JOIN Brand b ON b.ID = p.BrandId)";
            DataTable dt = (DataTable)Select(sql).Data;
            int count = 0, key = 0, countAllNames = 0;
            string productName;
            string brand;
            string category;
            count = dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                key = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                productName = dt.Rows[i]["Name"].ToString();
                brand = dt.Rows[i]["b.Title"].ToString();
                category = dt.Rows[i]["c.Title"].ToString();
                sample.Add(productName);
                countAllNames = sample.Count;
                for (int j = 0; j < countAllNames; j++)
                {
                    //Regex nameRegex = new Regex(category);
                    if (sample.Contains(category) == false)
                    {
                        sample.Add(category);
                    }

                    //Regex brandRegex = new Regex(brand);
                    if (sample.Contains(brand) == false)
                    {
                        sample.Add(brand);
                    }

                }
            }
            return sample;
            //   return dt.AsEnumerable()
            //.ToList<((int, string))>(row => row.Field<int>(0),
            //                       row => row.Field<string>(1));

            //return dt.AsEnumerable().ToList <(int, string)>
        }
        void getStockValue(string sql)
        {
            DataTable dtStock = (DataTable)Select(sql).Data;
            double totalStockValue = 0, totalPrice = 0, price = 0, quantity = 0;
            int count = dtStock.Rows.Count;
            for(int i = 0; i < count; i++)
            {
                price = !string.IsNullOrEmpty(dtStock.Rows[i][0].ToString()) ? Convert.ToDouble(dtStock.Rows[i][0]) : 0;
                quantity = !string.IsNullOrEmpty(dtStock.Rows[i][1].ToString()) ? Convert.ToDouble(dtStock.Rows[i][1]) : 0;
                totalPrice = totalPrice + (price * quantity);
            }
            labelStockValue.Text = totalPrice.ToString();
        }

        void getInventoryInvoice(string sql)
        {
            DataTable dt = (DataTable)Select(sql).Data;
            gridInvoices.Refresh();
            gridInvoices.DataSource = dt;
            gridInvoices.AutoGenerateColumns = false;
            if (gridInvoices.Columns.Count == 12)
            {
                DataGridViewLinkColumn edit = new DataGridViewLinkColumn();
                edit.UseColumnTextForLinkValue = true;
                edit.HeaderText = "Payment";
                edit.DataPropertyName = "lnkColumn";
                edit.LinkBehavior = LinkBehavior.AlwaysUnderline;
                edit.Text = "Payment";
                edit.LinkColor = Color.Blue;
                gridInvoices.Columns.Add(edit);

                DataGridViewLinkColumn viewDetails = new DataGridViewLinkColumn();
                viewDetails.UseColumnTextForLinkValue = true;
                viewDetails.HeaderText = "View Details";
                viewDetails.DataPropertyName = "lnkColumn";
                viewDetails.LinkBehavior = LinkBehavior.AlwaysUnderline;
                viewDetails.Text = "View Details";
                viewDetails.LinkColor = Color.Blue;
                gridInvoices.Columns.Add(viewDetails);

                DataGridViewLinkColumn delete = new DataGridViewLinkColumn();
                delete.UseColumnTextForLinkValue = true;
                delete.HeaderText = "delete";
                delete.DataPropertyName = "lnkColumn";
                delete.LinkBehavior = LinkBehavior.AlwaysUnderline;
                delete.Text = "Delete";
                delete.LinkColor = Color.Blue;
                gridInvoices.Columns.Add(delete);
            }
            gridInvoices.Refresh();
        }

        long getMaxId(string sql)
        {
            //Connection con = new Connection();
            DataTable dt;
            //string cmd = "SELECT MAX(Id) FROM Products";
            dt = (DataTable)Select(sql).Data;
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

        private void gridInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                if (e.RowIndex > -1)
                {
                    long inventoryId = Convert.ToInt64(gridInvoices.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //long supplierId = Convert.ToInt64(gridInvoices.Rows[e.RowIndex].Cells[1].Value.ToString());
                    (new InvoicePayment(inventoryId)).ShowDialog();
                    getInventoryInvoice(sql);
                }
            }

            else if (e.ColumnIndex == 13)
            {
                if (e.RowIndex > -1)
                {
                    long inventoryId = Convert.ToInt64(gridInvoices.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string sqlDetail = @"SELECT i.ID, i.InvoiceNo, s.SName, p.ID, p.Name, p.ItemCode AS [Item Code], b.Title AS Brand, c.Title AS Category, p.Price,
                p.PriceAfterDiscount AS [Discounted Buying Price], p.CostPerUnit AS [Buing Cost/unit], 
                d.SellingPrice AS [Selling Price], p.TotalQuantity AS [Total Quantity], d.RemainQuantity AS [Remain Quantity], i.OtherCost, i.PaidAmount, i.Discount, i.Due, i.CreatedDate 
                FROM (((((Inventory i LEFT JOIN Suppliers s ON i.SupplierId = s.ID) LEFT JOIN ProductDetails d ON d.InventoryId = i.ID)
                LEFT JOIN Products p ON p.ID = d.ProductID)
                LEFT JOIN Category c ON c.ID = p.CategoryId) LEFT JOIN Brand b ON b.ID = p.BrandId)
                WHERE i.ID = " + inventoryId + "";
                    //DataTable dt = (DataTable)Select(sql).Data;
                    (new InventoryDetails(sqlDetail)).ShowDialog();
                    getInventoryInvoice(sql);
                }
            }

            else if (e.ColumnIndex == 14)
            {
                if (e.RowIndex > -1)
                {

                    long inventoryId = Convert.ToInt64(gridInvoices.Rows[e.RowIndex].Cells[0].Value.ToString());
                    long balanceSheetId = getMaxId("SELECT MAX(Id) FROM BalanceSheet");
                    string sqlFindSaleId = @"SELECT pd.ProductID, pd.RemainQuantity FROM (((SalesDetails sd LEFT JOIN Products p ON sd.ProductId = p.ID) LEFT JOIN ProductDetails pd
                ON pd.ProductID = p.ID) LEFT JOIN Inventory i ON i.ID = pd.InventoryId) WHERE i.ID = " + inventoryId + "";
                    DataTable dt = (DataTable)Select(sqlFindSaleId).Data;
                    int count = dt.Rows.Count;
                    int remainQuantity = 0;
                    if (count > 0)
                    {
                        //remainQuantity = Convert.ToInt32(dt.Rows[])
                    }
                    if (count == 0)
                    {
                        //long inventoryId = Convert.ToInt64(gridInvoices.Rows[e.RowIndex].Cells[0].Value.ToString());
                        string name = gridInvoices.Rows[e.RowIndex].Cells[1].Value.ToString();
                        DialogResult dr = MessageBox.Show("Are You Sure You Want To Delete " + Environment.NewLine
                            + name + "'s Informations", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                        if (dr.ToString() == "Yes")
                        {


                            string sqlIPM = "SELECT ID, DigitalWalletId, TransactionAmount FROM Inventory_Payment_Methods WHERE InventoryId = " + inventoryId + "";
                            DataTable dtIPM = (DataTable)Select(sqlIPM).Data;
                            for (int i = 0; i < dtIPM.Rows.Count; i++)
                            {
                                long inventoryPaymentMethodId = Convert.ToInt64(dtIPM.Rows[i]["ID"].ToString());
                                long digitalWalletId = Convert.ToInt64(dtIPM.Rows[i]["DigitalWalletId"].ToString());
                                double transactionAmount = Convert.ToDouble(dtIPM.Rows[i]["TransactionAmount"].ToString());
                                //balanceSheetId = getMaxId("SELECT MAX(Id) FROM BalanceSheet");

                                string sqlDigitalWallet = @"Select Amount FROM DigitalWallet WHERE ID = " + digitalWalletId + "";
                                DataTable dtDigitalWallet = (DataTable)Select(sqlDigitalWallet).Data;
                                double amount = Convert.ToDouble(dtDigitalWallet.Rows[0]["Amount"].ToString());
                                amount += transactionAmount;
                                string sqlUpdateDigitalWallet = @"UPDATE DigitalWallet SET Amount = " + amount + " WHERE ID = " + digitalWalletId + "";
                                CUD(sqlUpdateDigitalWallet);
                                string sqlDigitalWalletHistory = "INSERT INTO DigitalWallet_History(DigitalWalletId, TransactionType, DetailPurpose, TransactedAmount, UpdatedDate, BalanceSheetId)" +
                                    "VALUES (" + digitalWalletId + ", 'DEPOSITED', 'DELETED DATA ADJUSTED', " + transactionAmount + ", '" + DateTime.Now + "', " + balanceSheetId + ")";
                                CUD(sqlDigitalWalletHistory);

                                var balanceSheet = BalanceSheet(balanceSheetId);
                                double currentBalance = balanceSheet.Item1;
                                double totalDebit = balanceSheet.Item4;
                                double debitLiability = balanceSheet.Item5;

                                string sqlInventoryDue = @"SELECT Due FROM Inventory WHERE ID = " + inventoryId + "";
                                DataTable dtInventoryDue = (DataTable)Select(sqlInventoryDue).Data;
                                double due = Convert.ToDouble(dtInventoryDue.Rows[0]["Due"].ToString());
                                string sqlUpdateBalanceSheet = @"UPDATE BalanceSheet SET CurrentBalance = " + (currentBalance + transactionAmount) + ", TotalDebit = " + (totalDebit - transactionAmount) + ", DebitLiability = " + (debitLiability - due) + "" +
                                    " WHERE ID = " + balanceSheetId + "";
                                CUD(sqlUpdateBalanceSheet);

                            }

                            string sqlAllId = @"SELECT p.ID, pd.ID FROM ((ProductDetails pd LEFT JOIN Inventory i ON i.ID = pd.InventoryId)
                    LEFT JOIN Products p ON p.ID = pd.ProductID)
                    WHERE i.ID = " + inventoryId + "";
                            DataTable dtSqlAllId = (DataTable)Select(sqlAllId).Data;
                            for (int i = 0; i < dtSqlAllId.Rows.Count; i++)
                            {
                                long productDetailsId = Convert.ToInt64(dtSqlAllId.Rows[i]["pd.ID"].ToString());
                                long productId = Convert.ToInt64(dtSqlAllId.Rows[i]["p.ID"].ToString());

                                string sqlDeleteProduct = @"DELETE FROM Products WHERE ID = " + productId + "";
                                CUD(sqlDeleteProduct);
                                string sqlDeleteProductDetails = @"DELETE FROM ProductDetails WHERE ID = " + productDetailsId + "";
                                CUD(sqlDeleteProductDetails);

                                string sqlDeleteProductCopy = @"DELETE FROM Products_1 WHERE ID = " + productId + "";
                                CUD(sqlDeleteProductCopy);
                                string sqlDeleteProductDetailsCopy = @"DELETE FROM ProductDetails_1 WHERE ID = " + productDetailsId + "";
                                CUD(sqlDeleteProductDetailsCopy);

                            }

                            string sqlDeleteInventory = @"DELETE FROM Inventory WHERE ID = " + inventoryId + "";
                            CUD(sqlDeleteInventory);

                            getInventoryInvoice(sql);
                        }
                        //string sqlWalletIds = "SELECT DigitalWalletId, TransactionAmount FROM Inventory_Payment_Methods WHERE InventoryId = " + inventoryId + "";
                        // DataTable dtWalletIds = (DataTable)Select(sqlWalletIds).Data;
                    }
                    else if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("You can't delete this invoice as some of its product already sold. Invoice that is not engaged in selling yet can be deleted!!!");
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbSearchCategory.SelectedIndex == 1)
            {
                grpName.Enabled = false;
                grpName.Visible = false;
                grpDate.Enabled = true;
                grpDate.Visible = true;
                txtName.Text = "";
                
            }

            if (cmbSearchCategory.SelectedIndex == 0)
            {
                txtName.Text = "";
                grpDate.Enabled = false;
                grpDate.Visible = false;
                grpName.Enabled = true;
                grpName.Visible = true;
                
            }

            if(cmbSearchCategory.SelectedIndex == 2)
            {
                txtName.Text = "";
                grpName.Enabled = true;
                grpName.Visible = true;
                grpDate.Visible = false;
                grpDate.Enabled = false;
               
                
                
                sql = @"SELECT i.ID, i.InvoiceNo AS [Invoice No], s.SName AS [Supplier Name], p.Name AS [Model], c.Title AS [Category], b.Title AS [Brand], p.ItemCode AS [Item Code], i.OtherCost AS [Other Cost], i.PaidAmount AS [Paid Amount], i.Discount, i.Due, i.CreatedDate AS [Created Date] 
            FROM (((((Products p LEFT JOIN ProductDetails d ON p.ID = d.ProductID) LEFT JOIN Category c ON c.ID = p.CategoryId) LEFT JOIN Brand b ON b.ID = p.BrandId)
            LEFT JOIN Inventory i ON d.InventoryId = i.ID) LEFT JOIN Suppliers s ON i.SupplierId = s.ID) WHERE i.Due <> 0";
                getInventoryInvoice(sql);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            hideResults();
            if(grpName.Visible == true && txtName.Text != "" && grpDate.Visible == false && cmbSearchCategory.SelectedIndex == 0)
            {
                string name = txtName.Text.ToString();
                sql = @"SELECT i.ID, i.InvoiceNo AS [Invoice No], s.SName AS [Supplier Name], p.Name AS [Model], c.Title AS [Category], b.Title AS [Brand], p.ItemCode AS [Item Code], i.OtherCost AS [Other Cost], i.PaidAmount AS [Paid Amount], i.Discount, i.Due, i.CreatedDate AS [Created Date] 
            FROM (((((Products p LEFT JOIN ProductDetails d ON p.ID = d.ProductID) LEFT JOIN Category c ON c.ID = p.CategoryId) LEFT JOIN Brand b ON b.ID = p.BrandId)
            LEFT JOIN Inventory i ON d.InventoryId = i.ID) LEFT JOIN Suppliers s ON i.SupplierId = s.ID) WHERE p.Name LIKE '%" + name + "%' OR s.SName LIKE '%" + name + "%' OR c.Title LIKE '%" + name + "%' OR b.Title LIKE '%" + name + "%'";
                getInventoryInvoice(sql);
            }
            else if(grpDate.Visible == true && grpName.Visible == false && grpName.Visible == false && cmbSearchCategory.SelectedIndex == 1)
            {
                DateTime dateFrom = DateTime.Parse(dateTimePickerFrom.Text);
                DateTime dateTo = DateTime.Parse(dateTimePickerTo.Text);
                sql = @"SELECT i.ID, i.InvoiceNo AS [Invoice No], s.SName AS [Supplier Name], p.Name AS [Model], c.Title AS [Category], b.Title AS [Brand], p.ItemCode AS [Item Code], i.OtherCost AS [Other Cost], i.PaidAmount AS [Paid Amount], i.Discount, i.Due, i.CreatedDate AS [Created Date] 
            FROM (((((Products p LEFT JOIN ProductDetails d ON p.ID = d.ProductID) LEFT JOIN Category c ON c.ID = p.CategoryId) LEFT JOIN Brand b ON b.ID = p.BrandId)
            LEFT JOIN Inventory i ON d.InventoryId = i.ID) LEFT JOIN Suppliers s ON i.SupplierId = s.ID) WHERE i.CreatedDate BETWEEN #" + DateTime.Parse(dateFrom.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(dateTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";
                getInventoryInvoice(sql);
            }
            else if(grpName.Visible == true && txtName.Text != "" && grpDate.Visible == false && cmbSearchCategory.SelectedIndex == 2)
            {
                string name = txtName.Text.ToString();
                sql = @"SELECT i.ID, i.InvoiceNo AS [Invoice No], s.SName AS [Supplier Name], p.Name AS [Model], c.Title AS [Category], b.Title AS [Brand], p.ItemCode AS [Item Code], i.OtherCost AS [Other Cost], i.PaidAmount AS [Paid Amount], i.Discount, i.Due, i.CreatedDate AS [Created Date] 
            FROM (((((Products p LEFT JOIN ProductDetails d ON p.ID = d.ProductID) LEFT JOIN Category c ON c.ID = p.CategoryId) LEFT JOIN Brand b ON b.ID = p.BrandId)
            LEFT JOIN Inventory i ON d.InventoryId = i.ID) LEFT JOIN Suppliers s ON i.SupplierId = s.ID) WHERE p.Name LIKE '%" + name + "%' OR s.SName LIKE '%" + name + "%' OR c.Title LIKE '%" + name + "%' OR b.Title LIKE '%" + name + "%' AND i.Due <> 0";
                getInventoryInvoice(sql);

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Initial();
        }
        void hideResults()
        {
            lbAutoComplete.Visible = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Focused)
            {
                lbAutoComplete.Items.Clear();
                //productIds = new List<long>();
                //productId = 0;
                if (txtName.Text.Length == 0)
                {
                    hideResults();
                    return;
                }

                if (!String.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    string pattern = @"\b\w*" + txtName.Text.ToLower() + @"+\w*\b";
                    lbAutoComplete.Items.Clear();
                    int count = allNames.Count;

                    for (int i = 0; i < count; i++)
                    {
                        Regex nameRegex = new Regex(pattern);
                        if (nameRegex.IsMatch(allNames[i].ToLower()))
                        {
                            lbAutoComplete.Items.Add(allNames[i]);
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
                        MessageBox.Show("This is not present in your inventory!!!");
                        //txtSupplierName.Text = "Supplier's Name";
                        hideResults();
                        //txtName.Text = "";

                    }
                }
            }
        }

        private void lbAutoComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAutoComplete.SelectedIndex > -1)
            {
                int selectedIndex = lbAutoComplete.SelectedIndex; 
                txtName.Text = lbAutoComplete.Items[selectedIndex].ToString();
            }
            else
            {
                txtName.Text = "";
            }
            hideResults();
        }
    }
}
