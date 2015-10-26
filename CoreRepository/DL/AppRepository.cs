using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tasky.DL.SQLiteBase;

namespace CoreRepository
{
    public class AppRepository<T> : IRepository<T> where T: IBusinessEntity, new()
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

        public List<Menu> GetMenuByCategory(string category)
        {
            return db.GetMenuByCategory(category).ToList();
        }
		public List<Menu> GetMenuByType(string type)
		{
			return db.GetMenuByType(type).ToList();
		}

        public List<T> FindById(int id)
        {
            return db.FindById<T>(id).ToList();
        }

		public List<OrderDetailDTO> GetOrderDetailDTO()
		{
			return db.GetOrderDetailDTO ().ToList ();
		}

		public int UpdateOrder(int menuId, decimal quantity, bool updateOrder)
		{
			return db.UpdateOrder (menuId, quantity, updateOrder);
		}
		public int DeleteAllOrders()
		{
			return db.DeleteAllOrders ();
		}

		public int DeleteAllMenu()
		{
			return db.DeleteAllMenu ();
		}

		public int UpdateBuildVersion(string revisionNumber)
		{
			return db.UpdateBuildVersion (revisionNumber);
		}
    }
}
