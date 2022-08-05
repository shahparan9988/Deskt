using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class ItemGrid
	{
		public long ID { get; set; }
		public string Name { get; set; }
		public string ItemCode { get; set; }
		public double Price { get; set; }
		public double Vat { get; set; }
		public string VatType { get; set; }
		public double SalePrice { get; set; }
		public double ActualSalePrice { get; set; }
		public double TotalQuantity { get; set; }
		public double RemainQuantity { get; set; }
		public double SaleQuantity { get; set; }
		public double GivenVat { get; set; }
		public double DiscountIndi { get; set; }
		public double Discount { get; set; }
		public double PaidAmount { get; set; }
		public double Due { get; set; }
		public double CostPerUnit { get; set; }
		public double CostPerUnitAfterDiscount { get; set; }
		//public double OtherCost { get; set; }
		//public double SellingPrice { get; set; }
		//public double SellingUnit { get; set; }
		public int UnitId { get; set; }
		
		//public double TakeQuantity { get; set; }
		//public double DiscountPrice { get; set; }
		//public double Amount { get; set; }
		//public string Description { get; set; }
		
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }

		public int CreatedBy { get; set; }
		//public string CreateTime { get; set; }
		//public string UpdateTime { get; set; }
	}
}
