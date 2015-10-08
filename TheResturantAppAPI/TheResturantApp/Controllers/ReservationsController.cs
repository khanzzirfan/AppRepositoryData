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
using TheResturantApp.Models.DTO;

namespace TheResturantApp.Controllers
{
    public class ReservationsController : ApiController
    {
        private TRAContext db = new TRAContext();

        // GET: api/Reservations
        public IQueryable<ReservationDTO> GetReservations()
        {
            var reservation = from d in db.Reservations
                              select new ReservationDTO()
                              {
                                  Comment = d.Comments,
                                  Date = d.Date,
                                  Time = d.Time,
                                  Email = d.Email,
                                  Guests = d.Guests,
                                  Name = d.Name,
                                  Phone = d.Phone
                              };

            return reservation;
        }

        // GET: api/Reservations/00-000
        [ResponseType(typeof(ReservationDTO))]
        public async Task<IHttpActionResult> GetReservation(string phone)
        {
            var reservation = await db.Reservations.Select(c => new ReservationDTO()
            {
                Time = c.Time,
                Date = c.Date,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Guests = c.Guests,
                Comment = c.Comments
            }).SingleOrDefaultAsync(b => b.Phone == phone);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/Reservations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReservation(decimal id, Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation.ID)
            {
                return BadRequest();
            }

            db.Entry(reservation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
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

        // POST: api/Reservations
        [ResponseType(typeof(Reservation))]
        public async Task<IHttpActionResult> PostReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reservations.Add(reservation);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReservationExists(reservation.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reservation.ID }, reservation);
        }

        // DELETE: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public async Task<IHttpActionResult> DeleteReservation(decimal id)
        {
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            db.Reservations.Remove(reservation);
            await db.SaveChangesAsync();

            return Ok(reservation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservationExists(decimal id)
        {
            return db.Reservations.Count(e => e.ID == id) > 0;
        }
    }
}