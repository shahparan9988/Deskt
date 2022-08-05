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
    public partial class FundTransactionHistory : Common
    {
        string sqlHistory;
        public FundTransactionHistory(string sql)
        {
            InitializeComponent();
            sqlHistory = sql;
            Initial();
        }

        private void Initial()
        {
            DataTable dt = (DataTable)Select(sqlHistory).Data;
            dataGridViewFundHistory.DataSource = dt;
        }
    }
}
