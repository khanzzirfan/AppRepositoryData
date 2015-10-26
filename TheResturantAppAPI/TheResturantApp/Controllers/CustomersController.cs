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
using TheResturantApp.Models;

namespace TheResturantApp.Controllers
{
    public class CustomersController : ApiController
    {
        private TRAContext db = new TRAContext();

        //// GET: api/Customers
        //public IQueryable<Customer> GetCustomers()
        //{
        //    return db.Customers;
        //}

        //// GET: api/Customers/5
        //[ResponseType(typeof(Customer))]
        //public async Task<IHttpActionResult> GetCustomer(int id)
        //{
        //    Customer customer = await db.Customers.FindAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(customer);
        //}

        // GET: api/Customers
        public IQueryable<CustomerDTO> GetCustomers()
        {
            var customers = from b in db.Customers
                            select new CustomerDTO()
                            {
                                CustomerId = b.CustomerId,
                                Name = b.Name,
                                Phone = b.Phone
                            };
            return customers;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(CustomerDetailDTO))]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            var customer = await db.Customers.Select(b =>
                new CustomerDetailDTO()
                {
                    CustomerId = b.CustomerId,
                    Name = b.Name,
                    Phone = b.Phone,
                    InsertDatetime = b.InsertDatetime,
                    InsertProcess = b.InsertProcess,
                    InsertUser = b.InsertUser

                }).FirstOrDefaultAsync(b => b.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> addCustomer(string uniqueNumber)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TRAContext"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (!string.IsNullOrEmpty(uniqueNumber))
                    {
                        connection.Open();
                        var cmd = new SqlCommand("dbp_resto_add_customer", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@pv_number", uniqueNumber));
                        var run = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
            return StatusCode(HttpStatusCode.OK);
        }

          

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Customers.Add(customer);
            //await db.SaveChangesAsync();
            //var bookIdParameter = new SqlParameter();
            //bookIdParameter.ParameterName = "@customer_id";
            //bookIdParameter.Direction = ParameterDirection.Output;
            //bookIdParameter.SqlDbType = SqlDbType.Int;
            //var customerId = db.Database.ExecuteSqlCommand("dbp_insert_customer_data @pn_Name, @pn_phone, @customer_id OUT",
            //                                          new SqlParameter("@pn_Name", customer.Name),
            //                                          new SqlParameter("@pn_phone", customer.Phone),
            //                                          bookIdParameter);

            //customer.CustomerId = (int)bookIdParameter.Value;
            var connectionString = ConfigurationManager.ConnectionStrings["TRAContext"].ConnectionString;
            SqlDataReader reader = null;
            var id = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("irfank.dbp_insert_customer_data", connection);
                connection.Open();
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pn_Name", customer.Name));
                    cmd.Parameters.Add(new SqlParameter("@pn_phone", customer.Phone));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["customer_id"]);
                    }
                }
                catch (Exception)
                {
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

            customer.CustomerId = id;
            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            await db.SaveChangesAsync();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.CustomerId == id) > 0;
        }
    }
}