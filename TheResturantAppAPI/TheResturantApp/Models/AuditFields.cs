using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace TheResturantApp.Models
{
    public abstract class AuditFields
    {
        [Key]
        [Column]
        public decimal ID { get; set; }

        [Column, MaxLength(1)]
        public string Active { get; set; }

        [Column]
        public DateTime InsertDateTime { get; set; }

        [Column, MaxLength(100)]
        public string InsertUser { get; set; }

        [Column, MaxLength(100)]
        public string InsertProcess { get; set; }

        [Column]
        public DateTime UpdateDateTime { get; set; }

        [Column, MaxLength(100)]
        public string UpdateUser { get; set; }

        [Column, MaxLength(100)]
        public string UpdateProcess { get; set; }

    }
}
