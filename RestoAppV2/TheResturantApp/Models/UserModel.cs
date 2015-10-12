using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheResturantApp.Models
{
    public class UserModel:AuditFields
    {
        [Key]
        [Column]
        public decimal ID { get; set; }
        [Column, Required, MaxLength(100)]
        public string Name { get; set; }
       
        [Column, MaxLength(100)]
        public string Role { get; set; }
        
        [Column,Required]
        public string PasswordHash { get; set; }

         [Column]
        public string PasswordRevision { get; set; }
         [Column]
        public Guid? ResetKey { get; set; }
    }
}
