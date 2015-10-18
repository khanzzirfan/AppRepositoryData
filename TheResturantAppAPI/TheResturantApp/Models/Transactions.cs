using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace TheResturantApp.Models
{
    public class Transactions: AuditFields
    {
        [Column]
        public decimal OrderID { get; set; }
        [Column]
        public decimal MenuID { get; set; }
        [Column]
        public decimal UnitPrice { get; set; }
        [Column]
        public decimal Quantity { get; set; }
        [Column]
        public decimal Discount { get; set; }
        [Column]
        public decimal OrderAmount { get; set; }

        [Column]
        public decimal PricePlanId { get; set; }

        [Column, MaxLength(200)]
        public string Comments { get; set; }


    }
}
