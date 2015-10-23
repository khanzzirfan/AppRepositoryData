using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RestoCore
{
	public class AppDatabase
	{
		static object locker = new object();
		protected SQLiteConnection database;
		protected static string dbLocation;

		public AppDatabase (SQLiteConnection conn, string path)
		{
			database = conn;
			dbLocation = path;
			// create the tables
			database.CreateTable<Customer>();
			database.CreateTable<Menu>();
			database.CreateTable<BaseOrder>();
			database.CreateTable<Orders>();
			database.CreateTable<OrderDetails>();

			//Initialize Database Seed it;
			SeedDatabase();
		}

		public void SeedDatabase()
		{
			//Register customer on App Startup;
			var count = CountTable<Customer> ();
			if (count < 1) {
				var seed = new SampleSeedDB ();
				var addcustomer = seed.AddCustomer ();
				SaveItem(addcustomer);
			}
		}

		public IEnumerable<T> GetItems<T>() where T : IBusinessEntity, new()
		{
			lock (locker)
			{
				return (from i in database.Table<T>() select i).ToList();
			}
		}

		public T GetItem<T> (int id) where T : IBusinessEntity, new ()
		{
			lock (locker) {
				return database.Table<T>().FirstOrDefault(x => x.ID == id);
			}
		}

		public int SaveItem<T> (T item) where T : IBusinessEntity
		{
			lock (locker) {
				if (item.ID != 0) {
					database.Update (item);
					return item.ID;
				} else {
					return database.Insert (item);
				}
			}
		}

		/// <summary>
		/// Saves the items in Bulk; Pass Ienumerable Items;
		/// </summary>
		/// <param name="items">Items.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public void SaveItems<T> (IEnumerable<T> items) where T : IBusinessEntity
		{
			lock (locker) {
				database.BeginTransaction ();
				foreach (T item in items) {
					SaveItem<T> (item);
				}
				database.Commit ();
			}
		}

		public int DeleteItem<T>(int id) where T : IBusinessEntity, new()
		{
			lock (locker)
			{
				return database.Delete<T>(new T() { ID = id });
			}
		}

		public int DeleteItem<T>(T item) where T : IBusinessEntity, new()
		{
			lock (locker)
			{
				return database.Delete(item);
			}
		}


		/// <summary>
		/// Clears the table. Clears All the T data
		/// </summary>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public void ClearTable<T>() where T : IBusinessEntity, new ()
		{
			lock (locker) {
				database.Execute (string.Format ("delete from \"{0}\"", typeof (T).Name));
			}
		}

		// helper for checking if database has been populated
		public int CountTable<T>() where T : IBusinessEntity, new ()
		{
			lock (locker) {
				string sql = string.Format ("select count (*) from \"{0}\"", typeof (T).Name);
				var c = database.CreateCommand (sql, new object[0]);
				return c.ExecuteScalar<int>();
			}
		}


		//This is not really needed. The Save item performs update or insert itself;
		public int UpdateItem<T>(T item) where T : IBusinessEntity, new()
		{
			lock (locker)
			{
				database.Execute( string.Format ("DELETE FROM {0} WHERE ID = {1}", typeof(T).Name, item.ID));
				SaveItem (item);
				return 1;
			}
		}

		/***************
		 * There will be always one order in the orders table
		 * So, Basically need only Order Detail Table
		 * Keep inserting rows in to order Details
		 * 
		 *  * **********/

		/** Custom Methods Implementation ****/


		public IEnumerable<Orders> GetOrderByBase(int id)
		{
			lock (locker)
			{
				return database.Table<Orders>()
					.Where(c => c.BaseOrderID == id).ToList();
			}
		}

		public IEnumerable<OrderDetails> GetOrderDetailsByOrder(int id)
		{
			lock (locker)
			{
				return database.Table<OrderDetails>()
					.Where(c => c.OrderID == id).ToList();
			}
		}

	}
}

