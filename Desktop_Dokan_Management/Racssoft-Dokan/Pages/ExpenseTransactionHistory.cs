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
    public partial class ExpenseTransactionHistory : Common
    {
        string sqlExpense;
        public ExpenseTransactionHistory(string sql)
        {
            InitializeComponent();
            sqlExpense = sql;
            Initial();
        }

        void Initial()
        {
            DataTable dtExpense = (DataTable)Select(sqlExpense).Data;
            dataGridViewExpenseHistory.DataSource = dtExpense;
        }
    }
}
