using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasky.BL.Contracts;
using Tasky.DL.SQLite;

namespace TaskyPortableLibrary
{
	public class Fruits : IBusinessEntity
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		// new property
		public bool Active { get; set; }
	}
}
