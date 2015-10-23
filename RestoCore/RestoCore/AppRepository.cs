using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RestoCore
{
	public class AppRepository<T> : IRepository<T> where T: IBusinessEntity, new()
	{
		protected static  AppDatabase db = null;
		protected static string dbLocation;

		public AppRepository (SQLiteConnection conn, string dbLocation)
		{
			db = new AppDatabase(conn, dbLocation);
		}

		public List<T> GetItems()
		{
			return db.GetItems<T>().ToList();
		}

		public T GetItem(int id)
		{
			return db.GetItem<T>(id);
		}

		public  int SaveItem(T entity)
		{
			return db.SaveItem(entity);
		}

		public void SaveItems(IEnumerable<T> items)
		{
			db.SaveItems (items);
		}

		public int DeleteItem(T entity)
		{
			return db.DeleteItem(entity);
		}

		public int DeleteItem(int id)
		{
			return db.DeleteItem<T>(id);
		}

		public T Get(Expression<Func<T, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public List<T> FindById(int id)
		{
			throw new NotImplementedException();
		}

		public int CountTable()
		{
			return db.CountTable<T>();
		}
	}
}

