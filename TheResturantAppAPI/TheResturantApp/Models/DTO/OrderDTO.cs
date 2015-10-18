﻿using System;
using System.Collections.Generic;
namespace TheResturantApp.Models
{
    public class OrderDTO
    {
        public decimal OrderId { get; set; }
        public decimal CustomerId { get; set; }
        public string Name { get; set; }
        public string MenuName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DateOrdered { get; set; }
        public string IsInvoiced { get; set; }
    }

    public class OrderDetailDTO
    {
        public decimal ID { get; set; }
        public decimal CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime DateRequired { get; set; }
        public string Comments { get; set; }
        public List<Transactions> OrderItems { get; set; }
    }

}
