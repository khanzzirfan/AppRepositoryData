using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System;

namespace TheResturantApp.Models
{
    public class Reservation:AuditFields
    {
        [Column, Required, MaxLength(100)]
        public string Name { get; set; }
        
        [Column, Required]
        public int Guests { get; set; }
        
        [Column]
        public int StatusID { get; set; }
        
        [Column, MaxLength(100)]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }

        [Column, MaxLength(100)]
        [Required(ErrorMessage = "Please Enter Mobile No")]
        [Display(Name = "Mobile")]
        [StringLength(14, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 8)]
        public string Phone { get; set; }

        [Column]
        public string Comments { get; set; }
        
        [Column,Required]
        public DateTime Date { get; set; }
        
        [Column,Required]
        public string Time { get; set; }
        
        [Column]
        public decimal TableID { get; set; } 

    }
}
