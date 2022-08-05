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
    public partial class StoreTransactionHistory : Common
    {
        string sqlStore;
        public StoreTransactionHistory(string sql)
        {
            InitializeComponent();
            sqlStore = sql;
            Initial();

        }

        void Initial()
        {
            DataTable dt = (DataTable)Select(sqlStore).Data;
            dataGridViewStoreHistory.Refresh();
            
            dataGridViewStoreHistory.DataSource = dt;
            dataGridViewStoreHistory.Columns[0].Visible = false;
            dataGridViewStoreHistory.AutoGenerateColumns = false;
            if (dataGridViewStoreHistory.Columns.Count == 7)
            {
                DataGridViewLinkColumn view = new DataGridViewLinkColumn();
                view.UseColumnTextForLinkValue = true;
                view.HeaderText = "view";
                view.DataPropertyName = "lnkColumn";
                view.LinkBehavior = LinkBehavior.AlwaysUnderline;
                view.Text = "view";
                view.LinkColor = Color.Blue;
                dataGridViewStoreHistory.Columns.Add(view);
            }
        }

        private void dataGridViewStoreHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 7)
            {
                if (e.RowIndex > -1)
                {
                    long inventoryId = Convert.ToInt64(dataGridViewStoreHistory.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string sqlDetail = @"SELECT i.ID, i.InvoiceNo, s.SName, p.ID, p.Name, p.ItemCode, p.Price,
                p.PriceAfterDiscount AS [Discounted Buying Price], p.CostPerUnit AS [Buing Cost/unit], 
                d.SellingPrice, p.TotalQuantity, d.RemainQuantity, i.OtherCost, i.PaidAmount, i.Discount, i.Due, i.CreatedDate 
                FROM (((Inventory i LEFT JOIN Suppliers s ON i.SupplierId = s.ID) LEFT JOIN ProductDetails d ON d.InventoryId = i.ID)
                LEFT JOIN Products p ON p.ID = d.ProductID) WHERE i.ID = " + inventoryId + "";
                    //DataTable dt = (DataTable)Select(sql).Data;
                    (new InventoryDetails(sqlDetail)).ShowDialog();
                    //getInventoryInvoice(sql);
                }
            }
        }
    }
}
