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
    public class P_Person_AddressController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Person_Address
        public IQueryable<P_Person_Address> GetP_Person_Addresses()
        {
            return db.P_Person_Addresses;
        }

        // GET: api/P_Person_Address/5
        [ResponseType(typeof(P_Person_Address))]
        public IHttpActionResult GetP_Person_Address(long id)
        {
            P_Person_Address p_Person_Address = db.P_Person_Addresses.Find(id);
            if (p_Person_Address == null)
            {
                return NotFound();
            }

            return Ok(p_Person_Address);
        }

        // PUT: api/P_Person_Address/5
        [ResponseType(typeof(P_Person_Address))]
        [HttpPost]
        public IHttpActionResult PutP_Person_Address(long id, P_Person_Address p_Person_Address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Person_Address.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Person_Address).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_Person_AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Person_Address);
        }

        // POST: api/P_Person_Address
        [ResponseType(typeof(P_Person_Address))]
        public IHttpActionResult PostP_Person_Address(P_Person_Address p_Person_Address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Person_Addresses.Add(p_Person_Address);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Person_Address.ID }, p_Person_Address);
        }

        // DELETE: api/P_Person_Address/5
        [ResponseType(typeof(P_Person_Address))]
        [HttpPost]
        public IHttpActionResult DeleteP_Person_Address(long id)
        {
            P_Person_Address p_Person_Address = db.P_Person_Addresses.Find(id);
            if (p_Person_Address == null)
            {
                return NotFound();
            }

            db.P_Person_Addresses.Remove(p_Person_Address);
            db.SaveChanges();

            return Ok(p_Person_Address);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_Person_AddressExists(long id)
        {
            return db.P_Person_Addresses.Count(e => e.ID == id) > 0;
        }
    }
}