using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreRepository.BL;
using CoreRepository.BL.Contracts;
using CoreRepository.DL;
using Tasky.DL.SQLiteBase;

namespace CoreRepository
{
    public class AppRepository<T> : IRepository<T> where T:BusinessEntityBase,new()
    {
       TaskDatabase db = null;
		protected static string dbLocation;
        public AppRepository(SQLiteConnection conn, string dbLocation)
		{
			db = new TaskDatabase(conn, dbLocation);
		}

        public List<T> GetItems()
        {
            return db.GetItems<T>().ToList();
        }

        public T GetItem(int id)
        {
            return db.GetItem<T>(id);
        }

        public int SaveItem(T entity)
        {
            return db.SaveItem(entity);
        }

        public int DeleteItem(T entity)
        {
            return db.DeleteItem(entity);
        }

        //Custom Code  Implementation
        public List<Orders> GetOrderByBase(int id)
        {
            return db.GetOrderByBase(id).ToList();
        }
        public List<OrderDetails> GetOrderDetailsByOrder(int id)
        {
            return db.GetOrderDetailsByOrder(id).ToList();
        }

        public int CurrentBaseOrder()
        {
            return db.CurrentBaseOrder();
        }



    }
}
