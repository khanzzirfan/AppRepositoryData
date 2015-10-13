
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
        [Column]
        public decimal CategoryId { get; set; }
        [Column]
        public decimal Price { get; set; }
        [Column]
        public string ThumbUrl { get; set; }
        [Column]
        public string LargeUrl { get; set; }
        [Column]
        public string SmallUrl { get; set; }
    }
}
