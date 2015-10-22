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
		protected static SQLiteConnection database;
		protected static string dbLocation;

		public AppDatabase (SQLiteConnection conn, string path)
		{
			database = conn;
			dbLocation = path;
			// create the tables
			database.CreateTable<Menu>();
			database.CreateTable<BaseOrder>();
			database.CreateTable<Orders>();
			database.CreateTable<OrderDetails>();
		}


		public IEnumerable<T> GetItems<T>() where T : IBusinessEntity, new()
		{
			lock (locker)
			{
				return (from i in database.Table<T>() select i).ToList();
			}
		}

		public static T GetItem<T> (int id) where T : IBusinessEntity, new ()
		{
			lock (locker) {
				return database.Table<T>().FirstOrDefault(x => x.ID == id);
			}
		}

		public static int SaveItem<T> (T item) where T : IBusinessEntity
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
		public static void SaveItems<T> (IEnumerable<T> items) where T : IBusinessEntity
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
		public static void ClearTable<T>() where T : IBusinessEntity, new ()
		{
			lock (locker) {
				database.Execute (string.Format ("delete from \"{0}\"", typeof (T).Name));
			}
		}

		// helper for checking if database has been populated
		public static int CountTable<T>() where T : IBusinessEntity, new ()
		{
			lock (locker) {
				string sql = string.Format ("select count (*) from \"{0}\"", typeof (T).Name);
				var c = database.CreateCommand (sql, new object[0]);
				return c.ExecuteScalar<int>();
			}
		}


		/** Custom Methods Implementation ****/
		public static IEnumerable<Orders> GetOrderByBase(int id)
		{
			lock (locker)
			{
				return database.Table<Orders>()
					.Where(c => c.BaseOrderID == id).ToList();
			}
		}

		public static IEnumerable<OrderDetails> GetOrderDetailsByOrder(int id)
		{
			lock (locker)
			{
				return database.Table<OrderDetails>()
					.Where(c => c.OrderID == id).ToList();
			}
		}



	}
}

