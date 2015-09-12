using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tasky.BL;
using Tasky.DL.SQLiteBase;
using TaskyPortableLibrary;

namespace Tasky.DAL {
	public class TaskRepository {
		DL.TaskDatabase db = null;
		protected static string dbLocation;		
		//protected static TaskRepository me;

        public TaskRepository(SQLiteConnection conn, string dbLocation)
		{
			db = new Tasky.DL.TaskDatabase(conn, dbLocation);
		}

		public Task GetTask(int id)
		{
            return db.GetItem<Task>(id);
		}
		
		public IEnumerable<Task> GetTasks ()
		{
			return db.GetItems<Task>();
		}
		
		public int SaveTask (Task item)
		{
			return db.SaveItem<Task>(item);
		}

		public int DeleteTask(int id)
		{
			return db.DeleteItem<Task>(id);
		}
	}


	public class GenericRepository<T> : IRepository<T>
		where T : BL.Contracts.IBusinessEntity, new()
	{
		DL.TaskDatabase db = null;
		protected static string dbLocation;
		public GenericRepository(SQLiteConnection conn, string dbLocation)
		{
			db = new Tasky.DL.TaskDatabase(conn, dbLocation);
		}
		public List<T> GetAll()
		{
			return db.GetItems<T>().ToList();
		}

		public T GetById(int id)
		{
			return db.GetItem<T>(id);
		}

		public int Insert(T entity)
		{
			return db.SaveItem(entity);
		}

		public int Delete(T entity)
		{
			return db.DeleteItem(entity);
		}

	}
}

