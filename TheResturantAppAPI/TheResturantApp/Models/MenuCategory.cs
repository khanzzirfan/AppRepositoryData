using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace TheResturantApp.Models
{
    public class MenuCategory:AuditFields
    {
        [Column, Required, MaxLength(100)]
        public string Description { get; set; }
    }
}
