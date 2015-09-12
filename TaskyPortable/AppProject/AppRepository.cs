using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.DL.SQLiteBase;

namespace AppProject
{
	public class AppRepository<T>:IAppRepository<T> where T:new()
	{
		private SQLiteConnection db;
		public T list { get; set; }

		public AppRepository(SQLiteConnection db)
		{
			this.db = db;
		}


		public List<T> GetAll()
		{
			return db.Table<T>().ToList();
		}

		public T Get(int id)
		{
			throw new NotImplementedException();
		}

		public int Insert(T entity)
		{
			throw new NotImplementedException();
		}

		public int Update(T entity)
		{
			throw new NotImplementedException();
		}

		public int Delete(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
