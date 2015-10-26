using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TheResturantApp.Models;

namespace TheResturantApp.Controllers
{
    public class RestoBuildsController : ApiController
    {
        private TRAContext db = new TRAContext();

        // GET: api/RestoBuilds
        [Authorize]
        public IQueryable<RestoBuild> GetRestoBuilds()
        {
            return db.RestoBuilds.OrderByDescending(d=> d.ID).Take(1);
        }

        
        // GET: api/RestoBuilds/5
        [ResponseType(typeof(RestoBuild))]
        public async Task<IHttpActionResult> GetRestoBuild(decimal id)
        {
            RestoBuild restoBuild = await db.RestoBuilds.FindAsync(id);
            if (restoBuild == null)
            {
                return NotFound();
            }

            return Ok(restoBuild);
        }

        // PUT: api/RestoBuilds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestoBuild(decimal id, RestoBuild restoBuild)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restoBuild.ID)
            {
                return BadRequest();
            }

            db.Entry(restoBuild).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestoBuildExists(id))
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

        // POST: api/RestoBuilds
        [ResponseType(typeof(RestoBuild))]
        public async Task<IHttpActionResult> PostRestoBuild(RestoBuild restoBuild)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestoBuilds.Add(restoBuild);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RestoBuildExists(restoBuild.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = restoBuild.ID }, restoBuild);
        }

        // DELETE: api/RestoBuilds/5
        [ResponseType(typeof(RestoBuild))]
        public async Task<IHttpActionResult> DeleteRestoBuild(decimal id)
        {
            RestoBuild restoBuild = await db.RestoBuilds.FindAsync(id);
            if (restoBuild == null)
            {
                return NotFound();
            }

            db.RestoBuilds.Remove(restoBuild);
            await db.SaveChangesAsync();

            return Ok(restoBuild);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestoBuildExists(decimal id)
        {
            return db.RestoBuilds.Count(e => e.ID == id) > 0;
        }
    }
}