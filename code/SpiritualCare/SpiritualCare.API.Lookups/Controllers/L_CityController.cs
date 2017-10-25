using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SpiritualCare.Data;
using SpiritualCare.Model.Lookup;

namespace SpiritualCare.API.Lookups.Controllers
{
    public class L_CityController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_City
        public IQueryable<L_City> GetL_Cities()
        {
            return db.L_Cities;
        }

        // GET: api/L_City/5
        [ResponseType(typeof(L_City))]
        public IHttpActionResult GetL_City(long id)
        {
            L_City l_City = db.L_Cities.Find(id);
            if (l_City == null)
            {
                return NotFound();
            }

            return Ok(l_City);
        }

        // PUT: api/L_City/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutL_City(long id, L_City l_City)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_City.ID)
            {
                return BadRequest();
            }

            db.Entry(l_City).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_CityExists(id))
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

        // POST: api/L_City
        [ResponseType(typeof(L_City))]
        public IHttpActionResult PostL_City(L_City l_City)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_Cities.Add(l_City);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_City.ID }, l_City);
        }

        // DELETE: api/L_City/5
        [ResponseType(typeof(L_City))]
        public IHttpActionResult DeleteL_City(long id)
        {
            L_City l_City = db.L_Cities.Find(id);
            if (l_City == null)
            {
                return NotFound();
            }

            db.L_Cities.Remove(l_City);
            db.SaveChanges();

            return Ok(l_City);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool L_CityExists(long id)
        {
            return db.L_Cities.Count(e => e.ID == id) > 0;
        }
    }
}