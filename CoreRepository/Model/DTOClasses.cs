using System;

namespace CoreRepository
{
	public class DTOClasses
	{
		public DTOClasses ()
		{
		}
	}

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
	}

}

