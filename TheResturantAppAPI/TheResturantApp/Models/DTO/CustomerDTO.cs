using System.ComponentModel.DataAnnotations;
using System;

namespace TheResturantApp.Models
{
    public class CustomerDTO
    {
        public decimal CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

    }

    public class CustomerDetailDTO
    {

        public decimal CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime InsertDatetime { get;set; }
        public string InsertProcess { get; set; }
        public string InsertUser { get; set; }
    }
    
}