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
    public partial class SalesTransactionHistory : Common
    {
        string sqlSale;
        public SalesTransactionHistory(string sql)
        {
            InitializeComponent();
            sqlSale = sql;
            Initial();
        }

        void Initial()
        {
            DataTable dt = (DataTable)Select(sqlSale).Data;
            dataGridViewSalesHistory.Refresh();

            dataGridViewSalesHistory.DataSource = dt;
            dataGridViewSalesHistory.Columns[0].Visible = false;
            dataGridViewSalesHistory.AutoGenerateColumns = false;
            if (dataGridViewSalesHistory.Columns.Count == 7)
            {
                DataGridViewLinkColumn view = new DataGridViewLinkColumn();
                view.UseColumnTextForLinkValue = true;
                view.HeaderText = "view";
                view.DataPropertyName = "lnkColumn";
                view.LinkBehavior = LinkBehavior.AlwaysUnderline;
                view.Text = "view";
                view.LinkColor = Color.Blue;
                dataGridViewSalesHistory.Columns.Add(view);
            }
        }

        private void dataGridViewSalesHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (e.RowIndex > -1)
                {
                    long salesId = Convert.ToInt64(dataGridViewSalesHistory.Rows[e.RowIndex].Cells[0].Value.ToString());
                    (new SalesPayment(salesId)).ShowDialog();
                    Initial();
                }
            }
        }
    }
}
