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
    public class P_WhatsAppController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_WhatsApp
        public IQueryable<P_WhatsApp> GetP_WhatsApps()
        {
            return db.P_WhatsApps;
        }

        // GET: api/P_WhatsApp/5
        [ResponseType(typeof(P_WhatsApp))]
        public IHttpActionResult GetP_WhatsApp(long id)
        {
            P_WhatsApp p_WhatsApp = db.P_WhatsApps.Find(id);
            if (p_WhatsApp == null)
            {
                return NotFound();
            }

            return Ok(p_WhatsApp);
        }

        // PUT: api/P_WhatsApp/5
        [ResponseType(typeof(P_WhatsApp))]
        [HttpPost]
        public IHttpActionResult PutP_WhatsApp(long id, P_WhatsApp p_WhatsApp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_WhatsApp.ID)
            {
                return BadRequest();
            }

            db.Entry(p_WhatsApp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_WhatsAppExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_WhatsApp);
        }

        // POST: api/P_WhatsApp
        [ResponseType(typeof(P_WhatsApp))]
        public IHttpActionResult PostP_WhatsApp(P_WhatsApp p_WhatsApp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_WhatsApps.Add(p_WhatsApp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_WhatsApp.ID }, p_WhatsApp);
        }

        // DELETE: api/P_WhatsApp/5
        [ResponseType(typeof(P_WhatsApp))]
        [HttpPost]
        public IHttpActionResult DeleteP_WhatsApp(long id)
        {
            P_WhatsApp p_WhatsApp = db.P_WhatsApps.Find(id);
            if (p_WhatsApp == null)
            {
                return NotFound();
            }

            db.P_WhatsApps.Remove(p_WhatsApp);
            db.SaveChanges();

            return Ok(p_WhatsApp);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_WhatsAppExists(long id)
        {
            return db.P_WhatsApps.Count(e => e.ID == id) > 0;
        }
    }
}