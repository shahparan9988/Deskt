using System;
using Racssoft_Dokan.Pages;
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
	public partial class BalanceSheetDetail : Form
	{
		public BalanceSheetDetail(DataTable dtCredit, DataTable dtDebit)
		{
			InitializeComponent();
			dgCredit.DataSource = dtCredit;
			dgDebit.DataSource = dtDebit;
		}

		private void BalanceSheetDetail_Load(object sender, EventArgs e)
		{

		}
	}
}
