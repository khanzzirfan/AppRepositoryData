using System;
using SQLite;

namespace RestoCore
{
	public class OrderDetails : IBusinessEntity
	{
		public OrderDetails()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		[Indexed]
		public int OrderID { get; set; }
		[Indexed]
		public int MenuID { get; set; }
		public decimal Quantity { get; set; }
		public decimal Price { get; set; }
		public decimal TotalAmount { get; set; }
		public decimal TaxAmount { get; set; }

	}
}

