using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace TheResturantApp.Models
{
    public class Customer
    {
        public Customer()
        {
        }

        [Key]
        [Column]
        public int CustomerId { get; set; }

        [Column, Required, MaxLength(100)]
        public string Name { get; set; }

        [Column, Required, MaxLength(100)]
        public string Phone { get; set; }
        
        //Audit Fields
        [Column, Required]
        public DateTime InsertDatetime { get; set; }

        [Column, Required, MaxLength(100)]
        public string InsertUser { get; set; }

        [Column, Required, MaxLength(100)]
        public string InsertProcess { get; set; }

        [Column]
        public DateTime UpdateDateTime { get; set; }

        [Column, MaxLength(100)]
        public string UpdateUser { get; set; }

        [Column, MaxLength(100)]
        public string UpdateProcess { get; set; }


    }
}