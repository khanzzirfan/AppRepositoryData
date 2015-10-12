
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace TheResturantApp.Models
{
    public class Menu : AuditFields
    {
        [Column, Required, MaxLength(100)]
        public string Name { get; set; }
        [Column, Required, MaxLength(100)]
        public string Description { get; set; }
        [Column]
        public decimal MenuTypeId { get; set; }
        public virtual MenuType MenuType { get; set; }

        [Column]
        public decimal CategoryId { get; set; }
        public virtual MenuCategory MenuCategory { get;set;}

        [Column]
        public decimal Price { get; set; }
        
    }
}
