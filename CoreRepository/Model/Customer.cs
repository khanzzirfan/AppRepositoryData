using System;

namespace CoreRepository
{
	public class Customer:IBusinessEntity
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string UniqueId { get; set; }
	}
}

