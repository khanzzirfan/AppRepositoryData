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
        public decimal CustomerId { get; set; }

        [Column, Required, MaxLength(100)]
        public string Name { get; set; }

        [Column, MaxLength(100)]
        public string FirstName { get; set; }

        [Column, MaxLength(100)]
        public string LastName { get; set; }

        [Column]
        public DateTime DOB { get; set; }

        [Column, MaxLength(100)]
        public string IRDNumber { get; set; }

        [Column, MaxLength(10)]
        public string Gender { get; set; }

        [Column, MaxLength(100)]
        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }

        [Column, MaxLength(100)]
        [Required(ErrorMessage = "Please Enter Mobile No")]
        [Display(Name = "Mobile")]
        [StringLength(14, ErrorMessage = "The Mobile must contains 14 characters", MinimumLength = 8)]
        public string Phone { get; set; }

        [Column, MaxLength(100)]
        public string HomeNumber { get; set; }

        [Column, MaxLength(1)]
        public string Active { get; set; }

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