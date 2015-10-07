using System;
using System.Collections.Generic;
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
using System.Web.Mvc;
using TheResturantApp.Models;

namespace TheResturantApp.Controllers
{
    public class OrdersController : ApiController
    {
        private TRAContext db = new TRAContext();

        // GET: api/Orders
        public IQueryable<Order> GetOrders()
        {
            return db.Orders;
        }

        // GET: api/Orders/5
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

        // PUT: api/Orders/5
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

        // POST: api/Orders
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
           
            var paramCustomerId = new SqlParameter("@pn_customer_id", order.CustomerId);
            var paramTotalAmount = new SqlParameter("@pn_total_amount", order.TotalAmount);
            var paramTaxAmount = new SqlParameter("@pn_tax_amount", order.TaxAmount);
            var paramNetAmount = new SqlParameter("@pn_net_amount", order.NetAmount);
            var paramComments = new SqlParameter("@pn_comments", order.Comments);

            var orderIdParameter = new SqlParameter();
            orderIdParameter.ParameterName = "@pn_output_id";
            orderIdParameter.Direction = ParameterDirection.Output;
            orderIdParameter.SqlDbType = SqlDbType.Int;

            await db.Database.ExecuteSqlCommandAsync("Exec dbp_insert_orders @pn_customer_id, @pn_total_amount, @pn_tax_amount,@pn_net_amount, @pn_comments, @pn_output_id OUTPUT", paramCustomerId, paramTotalAmount, paramTaxAmount, paramNetAmount, paramComments, orderIdParameter).ContinueWith((result) =>
            {
                var res = result.Result;

                if (Convert.ToInt32(orderIdParameter.Value) > 1)
                {
                    order.ID = Convert.ToInt32(orderIdParameter.Value);
                }
            });

            //db.Orders.Add(order);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = order.ID }, order);
        }

        // DELETE: api/Orders/5
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