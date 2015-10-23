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


	public class Customer:IBusinessEntity
	{
		public Customer ()
		{		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string UniqueId {get;set;}
	}

	/// <summary>
	/// Sample seed Dataase.
	/// </summary>
	public class SampleSeedDB
	{
		public SampleSeedDB()
		{
			
		}

		public Customer AddCustomer()
		{
			var customer = new Customer()
			{
				UniqueId = string.Format("{0}", Guid.NewGuid())	
			};

			return customer;
		}
	}

}

