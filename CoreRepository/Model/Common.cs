using System;

namespace CoreRepository
{
	public class Common
	{
		public Common ()
		{
		}
	}

	/// <summary>
	/// Build: Application Build Information;
	/// </summary>
	public class Build:IBusinessEntity
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string BuildVersion { get; set; }
		public DateTime BuildDate { get; set; }
	}

	public class BuildDTO
	{
		public decimal Id { get; set; }
		public string BuildVersion { get; set; }
		public DateTime BuildDate { get; set; }
	}

}

