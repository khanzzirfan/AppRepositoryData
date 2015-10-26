using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheResturantApp.Models
{
    public class RestoBuild
    {
        [Key]
        [Column]
        public decimal ID { get; set; }
        [Column]
        public string BuildVersion { get; set; }
        [Column]
        public DateTime BuildDate { get; set; }
    }
}
