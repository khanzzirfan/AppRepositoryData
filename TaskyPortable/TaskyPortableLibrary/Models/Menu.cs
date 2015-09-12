using System.Collections.Generic;
using Tasky.BL.Contracts;
using Tasky.DL.SQLite;
using Tasky.DL.SQLiteBase;

namespace TaskyPortableLibrary
{
	
	public class Menu : IBusinessEntity
	{
		public Menu()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		// new property
		public bool Active { get; set; }
		
		[Indexed]
		public int FruitID { get; set; }
	}
}
