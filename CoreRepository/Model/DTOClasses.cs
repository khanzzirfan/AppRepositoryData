using System;
using System.Collections.Generic;
using System.Linq;


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

	public class OrderDetailsDTO
	{
		public decimal ID { get; set; }
		public decimal CustomerId { get; set; }
		public string Name { get; set; }
		public DateTime DateOrdered { get; set; }
		public DateTime DateRequired { get; set; }
		public string Comments { get; set; }
		public string IsInvoiced { get; set; }
		public List<TransactionDTO> OrderItems { get; set; }
	}

	public class TransactionDTO
	{
		public decimal MenuID { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal Quantity { get; set; }
		public string MenuName { get; set; }
	}


}

