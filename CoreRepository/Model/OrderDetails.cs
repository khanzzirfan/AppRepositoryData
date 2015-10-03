using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreRepository
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

	public class OrderDetailDTO
	{
		public int OrderDetailId { get; set; }
		public string MenuName { get; set; }
		public decimal Quantity { get; set; }
		public decimal Price { get; set; }

		public decimal TotalAmount { get; set; }
	}
}
