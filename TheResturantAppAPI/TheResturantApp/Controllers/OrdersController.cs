using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TheResturantApp.CommonResource;
using TheResturantApp.Models;

namespace TheResturantApp.Controllers
{
    [RoutePrefix("api/Orders")]
    public class OrdersController : ApiController
    {
        private TRAContext db = new TRAContext();

        // GET: api/Orders
        [Authorize]
        public IQueryable<Order> GetOrders()
        {
            return db.Orders;
        }

        // GET: api/Orders/5
        [Authorize]
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> GetOrder(int id)
        {
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [Authorize]
        [Route("getrecentorders")]
        [ResponseType(typeof(OrderDetailDTO))]
        public async Task<IHttpActionResult> GetRecentOrders(string orderType, string orderValue)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TRAContext"].ConnectionString;
            SqlDataReader reader = null;
            var orderdto = new List<OrderDetailDTO>();
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("dbp_get_recent_orders", connection);
                connection.Open();
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pv_order_by", orderType));
                    cmd.Parameters.Add(new SqlParameter("@pv_value", orderValue));
                    reader = cmd.ExecuteReader();
                    var orderlist = new CommonResource.ReflectionPopulator<TempOrderDTO>().CreateList(reader);

                    var dorderlist = orderlist.GroupBy(c => c.OrderId).Select(s => new OrderDetailDTO()
                    {
                        Comments = s.FirstOrDefault().Comments,
                        CustomerId = s.FirstOrDefault().CustomerId,
                        DateOrdered = s.FirstOrDefault().DateOrdered,
                        DateRequired = s.FirstOrDefault().DateRequired,
                        ID = s.FirstOrDefault().OrderId,
                        IsInvoiced = s.FirstOrDefault().IsInvoiced,
                        Name = s.FirstOrDefault().Name,
                        OrderItems = s.Where(d => d.OrderId == s.Key).Select(m => new TransactionDTO()
                        {
                            MenuID = m.MenuID,
                            MenuName = m.MenuName,
                            Quantity = m.Quantity,
                            UnitPrice = m.UnitPrice,

                        }).ToList(),
                    }).ToList();


                    orderdto = dorderlist;

                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                    throw;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
            return Ok(orderdto);
        }

        [Authorize]
        [Route("GetOrderDetails")]
        [ResponseType(typeof(OrderDTO))]
        public async Task<IHttpActionResult> GetOrdersDTO(string orderType, string orderValue)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TRAContext"].ConnectionString;
            SqlDataReader reader = null;
            var orderdto = new List<OrderDTO>();
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("dbp_get_orders", connection);
                connection.Open();
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pv_order_by", orderType));
                    cmd.Parameters.Add(new SqlParameter("@pv_value", orderValue));
                    reader = cmd.ExecuteReader();
                    var orderlist = new CommonResource.ReflectionPopulator<OrderDTO>().CreateList(reader);
                    orderdto = orderlist;
                }
                catch (Exception ex )
                {
                    var message = ex.Message;
                    throw;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }

            return Ok(orderdto);
        }
        
        // PUT: api/Orders/5
        [Authorize]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.ID)
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Authorize]
        [Route("placeorderitems")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostOrderItems(OrderDetailDTO order)
        {
            try
            {
                var v = 2;
                var orderId = 0;
                var jsonString = JsonConvert.SerializeObject(order);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    var pJsonString = new SqlParameter("@pv_json_order", jsonString);
                    var orderIdParameter = new SqlParameter();
                    orderIdParameter.ParameterName = "@pn_output_id";
                    orderIdParameter.Direction = ParameterDirection.Output;
                    orderIdParameter.SqlDbType = SqlDbType.Int;

                    await db.Database.ExecuteSqlCommandAsync("EXEC dbp_resto_add_json_order @pv_json_order, @pn_output_id OUTPUT", pJsonString, orderIdParameter).ContinueWith((result) =>
                    {
                        var res = result.Result;

                        if (Convert.ToInt32(orderIdParameter.Value) > 1)
                        {
                            orderId = Convert.ToInt32(orderIdParameter.Value);
                        }
                    });
                }

                if (orderId < 1)
                {
                    return StatusCode(HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            
            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/Orders
        [Authorize]
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            order.InsertDateTime = DateTime.Now;
            order.InsertProcess = "IrfankWEBAPI";
            order.InsertProcess = "IrfanTest";

            var pName = new SqlParameter("@pv_order_name", order.OrderName);
            var pCustId = new SqlParameter("@pv_customer_id", order.CustomerId);
            var pDate = new SqlParameter("@pv_order_date", order.OrderDate);
            var prequiredDate = new SqlParameter("@pv_required_date", order.RequiredDate);

            //var pMenuId = new SqlParameter("@pv_menu_id", order.MenuId);
            //var pPrice = new SqlParameter("@pv_unit_price", order.UnitPrice);
            //var pQuantity = new SqlParameter("@pv_quantity", order.Quantity);
            var pComments = new SqlParameter("@pv_comments", order.Comments);
            

            var orderIdParameter = new SqlParameter();
            orderIdParameter.ParameterName = "@pn_output_id";
            orderIdParameter.Direction = ParameterDirection.Output;
            orderIdParameter.SqlDbType = SqlDbType.Int;

            try
            {
              
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
           
            //db.Orders.Add(order);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = order.ID }, order);
        }

        // DELETE: api/Orders/5
        [Authorize]
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> DeleteOrder(int id)
        {
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            await db.SaveChangesAsync();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.ID == id) > 0;
        }
    }
}