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
            // create the tables
            database.CreateTable<Menu>();
            database.CreateTable<BaseOrder>();
            database.CreateTable<Orders>();
            database.CreateTable<OrderDetails>();
            SeedDatabase();

        }

        public void SeedDatabase()
        {
            //Only seeds the data in debug mode.
            var seed = new SampleSeedDB();
            var menuList = seed.MenuList;
            if (database.Table<Menu>().Count() > 0)
            {
            }
            if (database.Table<Menu>().Count() < 1)
            {
                foreach (var item in menuList)
                {
                    SaveItem(item);
                }
            }

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
                // Following throws NotSupportedException - thanks aliegeni
                //return (from i in Table<T> ()
                //        where i.ID == id
                //        select i).FirstOrDefault ();
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

        public IEnumerable<Menu> GetMenuByCategory(string category)
        {
            return database.Table<Menu>().Where(c => c.MenuCategory == category).AsEnumerable();
        }

        public IEnumerable<OrderDetails> GetMenuWithQuantityOrdered(int menuId, int baseOrderId)
        {
            var orderId = GetOrderByBase(baseOrderId).FirstOrDefault().ID;
            return GetOrderDetailsByOrder(orderId);
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
        /// UpdateOrder; updates the current order based on baseOrderId
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="orderId"></param>
        /// <param name="baseOrderId"></param>
        /// <param name="quantity"></param>
        /// <param name="updateOrder"></param>
        /// <returns>This query return the order detail Id</returns>
        public int UpdateOrder(int menuId, int orderId, int baseOrderId, decimal quantity, bool updateOrder)
        {
            var orderDetailId = 0;
            if (!updateOrder)
            { // remove order
				var OD = GetItems<OrderDetails>();
				var detail1 = OD.Where(c => c.MenuID == menuId && c.OrderID == orderId).FirstOrDefault();
				if (detail1 != null && detail1.ID > 0) {
					DeleteItem<OrderDetails>(detail1);
                }
                return 1;
            }

            var menuItem = GetItem<Menu>(menuId);
            var dateorder = DateTime.Now;
            //GetCurrent Orders
            if (baseOrderId == 0)
            {
                var baseOrder = new BaseOrder()
                {
                    OrderDate = dateorder,
                    OrderInProgress = false,
                };
                baseOrderId = SaveItem(baseOrder);
            }
            //Get OrderList
            var orders = GetItem<Orders>(orderId);
            if (orders == null)
            {
                orders = new Orders();
                orders.BaseOrderID = baseOrderId;
                orders.CustomerID = baseOrderId;
                orders.OrderRequired = dateorder;
                orders.OrderDate = dateorder;
                orderId = SaveItem(orders);
            }

            var orderDetails = GetItems<OrderDetails>().FirstOrDefault(c => c.MenuID == menuId && c.OrderID == orderId);
            if (orderDetails == null)
            {
				orderDetails = new OrderDetails ();
				orderDetails.MenuID = menuId;
				orderDetails.OrderID = orderId;
				orderDetails.Price = menuItem.Price;
				orderDetails.Quantity = quantity;
				orderDetails.TotalAmount = menuItem.Price * quantity;
                orderDetailId= SaveItem(orderDetails);
            }else
            {
                orderDetails.Quantity = quantity;
                orderDetails.Price = menuItem.Price;
                orderDetails.TotalAmount = quantity * menuItem.Price;
                orderDetailId=SaveItem(orderDetails);
            }

            return orderDetailId;
        }

        public decimal GetItemTotalByMenu(int menuId, int orderId)
        {
            var detail = database.Table<OrderDetails>().ToList();
            if (detail != null && detail.Count > 0)
            {
                var counter = detail.Where(c => c.MenuID == menuId && c.OrderID == orderId)
                    .Select(c => new
                    {
                        total = c.Price * c.Quantity
                    }).FirstOrDefault();
                var total = counter!=null? counter.total:0.0m;
            }
            return 0.0m;
        }

		public IEnumerable<OrderDetailDTO> GetOrderDetailDTO()
		{
			var selectQuery = @"Select m.Name As MenuName,
									   od.Quantity,
									   od.Price,
										od.TotalAmount,
										od.Id AS OrderDetailId,
										 m.Id as MenuID
								  FROM Menu m
								  JOIN OrderDetails od	 ON m.Id = od.MenuID ";
			var dto = database.Query<OrderDetailDTO> (selectQuery);
			return dto;
		}

		/// <summary>
		/// Clears all orders from the bucket.
		/// </summary>
		/// <returns>The all orders.</returns>
		public int ClearAllOrders()
		{
			var OD = GetItems<OrderDetails>();
			foreach (var d in OD) {
				DeleteItem<OrderDetails> (d);
			}

			var orders = GetItems<Orders> ();
			foreach (var d in orders) {
				DeleteItem<Orders> (d);
			}

			var baseOrder = GetItems<BaseOrder> ();
			foreach (var d in baseOrder) {
				DeleteItem<BaseOrder> (d);
			}
			return 1;
		}

    }
}