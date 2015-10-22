using SQLite;
namespace RestoCore
{
	public class Menu : IBusinessEntity
	{
		public Menu()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public decimal MenuID { get; set;}
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string MenuType { get; set; }
		public string MenuCategory { get; set; }
		public string ThumbUrl { get; set; }
		public string LargeUrl { get; set; }
		public string SmallUrl { get; set; }

		public  decimal QuantityOrdered { get; set; }

	}
}

