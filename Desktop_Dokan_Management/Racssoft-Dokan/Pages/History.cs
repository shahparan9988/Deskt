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
    public partial class History : Common
    {
        DateTime dateFrom;
        DateTime dateTo;
        public History()
        {
            InitializeComponent();
            dateFrom = DateTime.Parse(DateTime.Now.ToString());
            dateTo = DateTime.Parse(DateTime.Now.ToString());

            Initial();
        }

        void Initial()
        {
            GenerateStoreHistory(dateFrom, dateTo);
            GenerateSaleHistory(dateFrom, dateTo);
            GenerateExpenseHistory(dateFrom, dateTo);
            GenerateFundHistory(dateFrom, dateTo);
        }

        private void GenerateFundHistory(DateTime dateFrom, DateTime dateTo)
        {
            string sql = @"SELECT dw.Title, dwh.TransactionType, dwh.DetailPurpose, dwh.TransactedAmount, dwh.UpdatedDate
            FROM DigitalWallet_History dwh LEFT JOIN DigitalWallet dw ON dwh.DigitalWalletId = dw.ID 
            WHERE dwh.DetailPurpose <> 'DELETED DATA' AND dwh.DetailPurpose <> 'DELETED DATA ADJUSTED' AND
            dwh.DetailPurpose <> 'RETURN PRODUCT PAYEMENT' AND dwh.DetailPurpose <> 'INVENTORY DUE PAYMENT' AND
            dwh.DetailPurpose <> 'SALES DUE PAYMENT' AND dwh.DetailPurpose <> 'SALES PAYMENT' AND
            dwh.DetailPurpose <> 'EXPENSES PAYMENT' AND dwh.DetailPurpose <> 'EXPENSES DUE PAYMENT'AND dwh.DetailPurpose <> 'INVENTORY PURCHASE PAYMENT'AND dwh.DetailPurpose <> 'DELETED EXPENSE DATA ADJUSTED'AND dwh.DetailPurpose <> 'VAT PAYMENT'AND
            dwh.UpdatedDate BETWEEN #" + DateTime.Parse(dateFrom.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(dateTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";
            DataTable dt = (DataTable)Select(sql).Data;
            dataGridViewFund.DataSource = dt;
        }

        void GenerateStoreHistory(DateTime dateFrom, DateTime dateTo)
        {
            
            string sql = @"SELECT i.InvoiceNo, dw.Title, dwh.TransactionType, dwh.DetailPurpose, dwh.TransactedAmount,
            dwh.UpdatedDate FROM (((Inventory_Payment_Methods ipm LEFT JOIN Inventory i ON ipm.InventoryId = i.ID)
            LEFT JOIN DigitalWallet dw ON dw.ID = ipm.DigitalWalletId)
            LEFT JOIN DigitalWallet_History dwh ON dwh.ID = ipm.DG_HistoryId) WHERE dwh.UpdatedDate
            BETWEEN #" + DateTime.Parse(dateFrom.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(dateTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";
            DataTable dt = (DataTable)Select(sql).Data;
            dataGridViewStore.DataSource = dt;

        }

        void GenerateSaleHistory(DateTime dateFrom, DateTime dateTo)
        {

            string sql = @"SELECT s.Invoice, dw.Title, dwh.TransactionType, dwh.DetailPurpose, dwh.TransactedAmount,
            dwh.UpdatedDate FROM (((Sales_Payment_Methods spm LEFT JOIN Sales s ON spm.SalesId = s.ID)
            LEFT JOIN DigitalWallet dw ON dw.ID = spm.DigitalWalletId)
            LEFT JOIN DigitalWallet_History dwh ON dwh.ID = spm.DG_HistoryId) WHERE dwh.UpdatedDate
            BETWEEN #" + DateTime.Parse(dateFrom.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(dateTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";
            DataTable dt = (DataTable)Select(sql).Data;
            dataGridViewSale.DataSource = dt;

        }

        void GenerateExpenseHistory(DateTime dateFrom, DateTime dateTo)
        {

            string sql = @"SELECT e.Detail, dw.Title as [Payment Mehod], dwh.TransactedAmount, e.Due, dwh.UpdatedDate
            FROM (((Expense e LEFT JOIN ExpenseDetails ed ON e.ID = ed.ExpenseId)
            LEFT JOIN DigitalWallet dw ON dw.ID = ed.DigitalWalletId)
            LEFT JOIN DigitalWallet_History dwh ON dwh.ID = ed.DG_HistoryId) WHERE dwh.UpdatedDate
            BETWEEN #" + DateTime.Parse(dateFrom.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(dateTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";
            DataTable dt = (DataTable)Select(sql).Data;
            dataGridViewExpense.DataSource = dt;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dateFrom = DateTime.Parse(dateTimePickerFrom.Text.ToString());
            dateTo = DateTime.Parse(dateTimePickerTo.Text.ToString());
            GenerateStoreHistory(dateFrom, dateTo);
            GenerateSaleHistory(dateFrom, dateTo);
            GenerateExpenseHistory(dateFrom, dateTo);
            GenerateFundHistory(dateFrom, dateTo);
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT i.ID, i.InvoiceNo, dw.Title, dwh.TransactionType, dwh.DetailPurpose, dwh.TransactedAmount,
            dwh.UpdatedDate FROM (((Inventory_Payment_Methods ipm LEFT JOIN Inventory i ON ipm.InventoryId = i.ID)
            LEFT JOIN DigitalWallet dw ON dw.ID = ipm.DigitalWalletId)
            LEFT JOIN DigitalWallet_History dwh ON dwh.ID = ipm.DG_HistoryId) WHERE dwh.UpdatedDate
            BETWEEN #" + DateTime.Parse(dateFrom.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(dateTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";
            (new StoreTransactionHistory(sql)).ShowDialog();
            Initial();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT s.ID, s.Invoice, dw.Title, dwh.TransactionType, dwh.DetailPurpose, dwh.TransactedAmount,
            dwh.UpdatedDate FROM (((Sales_Payment_Methods spm LEFT JOIN Sales s ON spm.SalesId = s.ID)
            LEFT JOIN DigitalWallet dw ON dw.ID = spm.DigitalWalletId)
            LEFT JOIN DigitalWallet_History dwh ON dwh.ID = spm.DG_HistoryId) WHERE dwh.UpdatedDate
            BETWEEN #" + DateTime.Parse(dateFrom.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(dateTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";
            (new SalesTransactionHistory(sql)).ShowDialog();
            Initial();
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT e.Detail, dw.Title as [Payment Mehod], dwh.TransactedAmount, e.Due, dwh.UpdatedDate
            FROM (((Expense e LEFT JOIN ExpenseDetails ed ON e.ID = ed.ExpenseId)
            LEFT JOIN DigitalWallet dw ON dw.ID = ed.DigitalWalletId)
            LEFT JOIN DigitalWallet_History dwh ON dwh.ID = ed.DG_HistoryId) WHERE dwh.UpdatedDate
            BETWEEN #" + DateTime.Parse(dateFrom.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(dateTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";
            (new ExpenseTransactionHistory(sql)).ShowDialog();
        }

        private void btnFund_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT dw.Title, dwh.TransactionType, dwh.DetailPurpose, dwh.TransactedAmount, dwh.UpdatedDate
            FROM DigitalWallet_History dwh LEFT JOIN DigitalWallet dw ON dwh.DigitalWalletId = dw.ID 
            WHERE dwh.DetailPurpose <> 'DELETED DATA' AND dwh.DetailPurpose <> 'DELETED DATA ADJUSTED' AND
            dwh.DetailPurpose <> 'RETURN PRODUCT PAYEMENT' AND dwh.DetailPurpose <> 'INVENTORY DUE PAYMENT' AND
            dwh.DetailPurpose <> 'SALES DUE PAYMENT' AND dwh.DetailPurpose <> 'SALES PAYMENT' AND
            dwh.DetailPurpose <> 'EXPENSES PAYMENT' AND dwh.DetailPurpose <> 'EXPENSES DUE PAYMENT'AND dwh.DetailPurpose <> 'INVENTORY PURCHASE PAYMENT'AND dwh.DetailPurpose <> 'DELETED EXPENSE DATA ADJUSTED'AND dwh.DetailPurpose <> 'VAT PAYMENT'AND
            dwh.UpdatedDate BETWEEN #" + DateTime.Parse(dateFrom.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(dateTo.AddDays(1).ToString("MM/dd/yyyy")) + "#";
            (new FundTransactionHistory(sql)).ShowDialog();
        }
    }
}
