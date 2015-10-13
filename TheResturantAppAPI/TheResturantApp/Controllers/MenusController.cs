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
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TheResturantApp.Models;
using TheResturantApp.Models.DTO;

namespace TheResturantApp.Controllers
{
    [RoutePrefix("api/Menus")]
    public class MenusController : ApiController
    {
        private TRAContext db = new TRAContext();

        // GET: api/Menus
        [Authorize]
        public IQueryable<Menu> GetMenus()
        {
            return db.Menus;
        }


        // GET: api/Menus/5
        [Authorize]
        [Route("getmenudto")]
        [ResponseType(typeof(MenuDTO))]
        public async Task<IHttpActionResult> GetMenuDTO()
        {
            var menuDTO = new List<MenuDTO>();
            var connectionString = ConfigurationManager.ConnectionStrings["TRAContext"].ConnectionString;
            SqlDataReader reader = null;
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("dbp_resto_get_menu", connection);
                connection.Open();
                try
                {
                    reader = cmd.ExecuteReader();
                    menuDTO = new CommonResource.ReflectionPopulator<MenuDTO>().CreateList(reader);
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

            return Ok(menuDTO);
        }


        // GET: api/Menus/5
        [Authorize]
        [ResponseType(typeof(Menu))]
        public async Task<IHttpActionResult> GetMenu(decimal id)
        {
            Menu menu = await db.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        // PUT: api/Menus/5
        [Authorize]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMenu(decimal id, Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menu.ID)
            {
                return BadRequest();
            }

            db.Entry(menu).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
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

        // POST: api/Menus
        [Authorize]
        [ResponseType(typeof(Menu))]
        public async Task<IHttpActionResult> PostMenu(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Menus.Add(menu);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MenuExists(menu.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = menu.ID }, menu);
        }

        // DELETE: api/Menus/5
        [ResponseType(typeof(Menu))]
        public async Task<IHttpActionResult> DeleteMenu(decimal id)
        {
            Menu menu = await db.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            db.Menus.Remove(menu);
            await db.SaveChangesAsync();

            return Ok(menu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuExists(decimal id)
        {
            return db.Menus.Count(e => e.ID == id) > 0;
        }
    }
}