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
using SpiritualCare.Model.Person;

namespace SpiritualCare.API.Person.Controllers
{
    public class P_AddressController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Address
        public IQueryable<P_Address> GetP_Addresses()
        {
            return db.P_Addresses;
        }

        // GET: api/P_Address/5
        [ResponseType(typeof(P_Address))]
        public IHttpActionResult GetP_Address(long id)
        {
            P_Address p_Address = db.P_Addresses.Find(id);
            if (p_Address == null)
            {
                return NotFound();
            }

            return Ok(p_Address);
        }

        // PUT: api/P_Address/5
        [ResponseType(typeof(P_Address))]
        [HttpPost]
        public IHttpActionResult PutP_Address(long id, P_Address p_Address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Address.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Address).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Address);
        }

        // POST: api/P_Address
        [ResponseType(typeof(P_Address))]
        public IHttpActionResult PostP_Address(P_Address p_Address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Addresses.Add(p_Address);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Address.ID }, p_Address);
        }

        // DELETE: api/P_Address/5
        [ResponseType(typeof(P_Address))]
        [HttpPost]
        public IHttpActionResult DeleteP_Address(long id)
        {
            P_Address p_Address = db.P_Addresses.Find(id);
            if (p_Address == null)
            {
                return NotFound();
            }

            db.P_Addresses.Remove(p_Address);
            db.SaveChanges();

            return Ok(p_Address);
        }
        // OPTIONS: api/P_Address
        // for use with angular framework
        [HttpOptions]
        public IHttpActionResult OptionsP_Address()
        {
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_AddressExists(long id)
        {
            return db.P_Addresses.Count(e => e.ID == id) > 0;
        }
    }
}