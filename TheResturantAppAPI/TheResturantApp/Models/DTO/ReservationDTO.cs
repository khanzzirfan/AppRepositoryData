using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheResturantApp.Models.DTO
{
    public class ReservationDTO
    {
        public decimal ID { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int Guests { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public string CustomerId { get; set; }

    }
}
