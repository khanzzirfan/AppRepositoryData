using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheResturantApp.Models
{
    public class Order
    {
        public Order()
        {

        }

        [Key]
        [Column]
        public int Id { get; set; }
        
        [Column]
        public int CustomerId { get; set; }
        
        [Column]
        public decimal TotalAmount { get; set; }
        
        [Column]
        public decimal TaxAmount { get; set; }
        
        [Column]
        public decimal NetAmount { get; set; }

        [Column, MaxLength(400)]
        public string Comments { get; set; }
        
        [Column, Required]
        public DateTime InsertDateTime { get; set; }

        [Column, Required, MaxLength(100)]
        public string InsertProcess { get; set; }

        [Column, Required, MaxLength(100)]
        public string InsertUser { get; set; }

        [Column]
        public DateTime? UpdateDateTime { get; set; }
        
        [Column,MaxLength(100)]
        public string Updateuser { get; set; }

        [Column, MaxLength(100)]
        public string UpdateProcess { get; set; }
    }
}
