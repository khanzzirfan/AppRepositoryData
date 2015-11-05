using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using Tasky.DL.SQLiteBase;
using System.Linq.Expressions;
using System;

namespace CoreRepository
{
    /// <summary>
    /// TaskDatabase builds on SQLite.Net and represents a specific database, in our case, the Task DB.
    /// It contains methods for retrieval and persistance as well as db creation, all based on the 
    /// underlying ORM.
    /// </summary>
    public class TaskDatabase
    {
        static object locker = new object();

        SQLiteConnection database;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public TaskDatabase(SQLiteConnection conn, string path)
        {
            database = conn;
			//Add All Tables;
			UpdateDataModel ();

        }

		public void UpdateDataModel()
		{
			// create the tables
			if (CountTable<Customer> () < 1) {
				database.CreateTable<Customer> ();
				database.CreateTable<Build> ();
				database.CreateTable<Menu> ();
				database.CreateTable<OrderDetails> ();
				database.CreateTable<DisplayMenu> ();
				SeedDatabase ();
			}
		}
        public void SeedDatabase()
        {
            //Only seeds the data in debug mode.
            var seed = new SampleSeedDB();

			//Create Menu items
            var menuList = seed.MenuList;
			SaveItems (menuList);
			var displayList = seed.DisplayMenuList;
			SaveItems (displayList);
			//Create customer in the system;
			var customer = new Customer ();
			customer.UniqueId = string.Format("{0}",Guid.NewGuid ());
			SaveItem (customer);
        }

        public IEnumerable<T> GetItems<T>() where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                return (from i in database.Table<T>() select i).ToList();
            }
        }

        public T GetItem<T>(int id) where T : IBusinessEntity, new()
        {
            lock (locker)
            {
				var item = database.Table<T>().FirstOrDefault(x => x.ID == id);
                return database.Table<T>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveItem<T>(T item) where T : IBusinessEntity
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

		/// <summary>
		/// Saves the items in bulk Transaction;.
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

		// helper for checking if database has been populated
		public int CountTable<T>() where T : IBusinessEntity, new ()
		{
			var returnvalue = 0;
			lock (locker) {

				try
				{
					returnvalue =database.Table<T>().Count();
				}
				catch(Exception ex)
				{
					returnvalue =-1; 
				}
			}
			return returnvalue;
		}

		public int UpdateBuildVersion(string number)
		{
			var build = new Build () {
				BuildDate=DateTime.Now,
				BuildVersion = number,
			};

			return SaveItem (build);
		}

        /** Custom Methods Implementation ****/
		/***
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

        public int CurrentBaseOrder()
        {
            lock (locker)
            {
                int id = 0;

                try
                {
                    var baseOrders = database.Table<BaseOrder>().ToList();
                    if (baseOrders != null && baseOrders.Count > 0)
                    {
                        id = baseOrders.FirstOrDefault(c => c.OrderInProgress == false).ID;
                        return id;
                    }        
                        
                    //If no current order exists create order
					else 
                    {
                        var baseOrder = new BaseOrder()
                        {
                            OrderDate = new System.DateTime(),
                            OrderInProgress = false,
                        };
                        id = SaveItem(baseOrder);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.Message;
                }

                return id;
            }
        }
		***/

        public IEnumerable<Menu> GetMenuByCategory(string category)
        {
            return database.Table<Menu>().Where(c => c.MenuCategory == category).AsEnumerable();
        }

		public IEnumerable<Menu> GetMenuByType(string type)
		{
			return database.Table<Menu>().Where(c => c.MenuType == type).AsEnumerable();
		}

        public IEnumerable<T> FindById<T>(int id) where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                var list = database.Table<T>().Where(c => c.ID == id).AsEnumerable();
                return list;
            }
        }

		/// <summary>
		/// Updates the order;
		/// </summary>
		/// <returns>The order.</returns>
		/// <param name="menuId">Menu identifier.</param>
		/// <param name="quantity">Quantity.</param>
		/// <param name="updateOrder">If set to <c>true</c> update order.</param>
		public int UpdateOrder(int menuId, decimal quantity, bool updateOrder)
		{
			var detailId = 0;
			var details = new OrderDetails ();
			if (!updateOrder) {
				var delQuery = string.Format (" DELETE FROM OrderDetails WHERE MenuID = {0}", menuId);
				var dto = database.Query<OrderDetails> (delQuery);
				return 1;
			} else {

				var menuItem = GetItem<Menu> (menuId);
				details = database.Table<OrderDetails> ().FirstOrDefault (c => c.MenuID == menuId);
				if (details == null) {
					details = new OrderDetails () {
						MenuID = menuId,
						Price = menuItem.Price,
						Quantity = quantity,
						TotalAmount = menuItem.Price * quantity,
					};
				} else {
					details.Quantity = quantity;
					details.TotalAmount = menuItem.Price * quantity;
				}

				SaveItem (details);
				detailId = details.ID;
			}
			return detailId;
		}

		public int DeleteAllOrders()
		{
			var delQuery = @"DELETE FROM OrderDetails";
			database.Query<OrderDetails> (delQuery);
			return 1;
		}
        
		public int DeleteAllMenu()
		{
			try 
			{
				var delQuery = @"DROP TABLE Menu";
				database.Execute(delQuery);
				//database.Query<Menu> (delQuery);
				database.CreateTable<Menu>();
			}
			catch(Exception ex) {
				
			}

			return 1;
		}
		public IEnumerable<OrderDetailDTO> GetOrderDetailDTO()
		{
			var selectQuery = @"Select m.Name As MenuName,
									   od.Quantity,
									   od.Price,
										od.TotalAmount,
										od.Id AS OrderDetailId,
										 m.MenuID as MenuID
								  FROM Menu m
								  JOIN OrderDetails od	 ON m.Id = od.MenuID ";
			var dto = database.Query<OrderDetailDTO> (selectQuery);
			return dto;
		}

    }
}