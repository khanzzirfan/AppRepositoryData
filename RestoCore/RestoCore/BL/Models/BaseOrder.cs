using System;
using SQLite;

namespace RestoCore
{
	public class BaseOrder:IBusinessEntity
	{
		public BaseOrder ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public bool OrderInProgress {get;set;}
		public DateTime OrderDate {get;set;}
	}
}

