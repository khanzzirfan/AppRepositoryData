using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreRepository.BL.Contracts;
using CoreRepository.DL.SQLite;

namespace CoreRepository.BL
{
    public class OrderDetails : IBusinessEntity
    {
        public OrderDetails()
        {
        }

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
