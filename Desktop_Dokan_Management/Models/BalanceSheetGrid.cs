using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class BalanceSheetGrid
	{
		public long ID { get; set; }
		public double OpeningBalance { get; set; }
		public double CurrentBalance { get; set; }
		public double TotalCredit { get; set; }
		public double CreditLiability { get; set; }
		public double TotalDebit { get; set; }
		public double DebitLiability { get; set; }
		public DateTime UpdatedDate { get; set; }
		public int CreatedBy { get; set; }
		//public string CreateTime { get; set; }
		//public string UpdateTime { get; set; }
	}
}
