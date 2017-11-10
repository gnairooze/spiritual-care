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
using SpiritualCare.Model.Activity.CareContact;

namespace SpiritualCare.API.Activity.CareContact.Controllers
{
    public class A_CC_CareContactServantController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/A_CC_CareContactServant
        public IQueryable<A_CC_CareContactServant> GetA_CC_CareContactServants()
        {
            return db.A_CC_CareContactServants;
        }

        // GET: api/A_CC_CareContactServant/5
        [ResponseType(typeof(A_CC_CareContactServant))]
        public IHttpActionResult GetA_CC_CareContactServant(long id)
        {
            A_CC_CareContactServant a_CC_CareContactServant = db.A_CC_CareContactServants.Find(id);
            if (a_CC_CareContactServant == null)
            {
                return NotFound();
            }

            return Ok(a_CC_CareContactServant);
        }

        // PUT: api/A_CC_CareContactServant/5
        [ResponseType(typeof(A_CC_CareContactServant))]
        [HttpPost]
        public IHttpActionResult PutA_CC_CareContactServant(long id, A_CC_CareContactServant a_CC_CareContactServant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != a_CC_CareContactServant.ID)
            {
                return BadRequest();
            }

            db.Entry(a_CC_CareContactServant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!A_CC_CareContactServantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(a_CC_CareContactServant);
        }

        // POST: api/A_CC_CareContactServant
        [ResponseType(typeof(A_CC_CareContactServant))]
        public IHttpActionResult PostA_CC_CareContactServant(A_CC_CareContactServant a_CC_CareContactServant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.A_CC_CareContactServants.Add(a_CC_CareContactServant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = a_CC_CareContactServant.ID }, a_CC_CareContactServant);
        }

        // DELETE: api/A_CC_CareContactServant/5
        [ResponseType(typeof(A_CC_CareContactServant))]
        [HttpPost]
        public IHttpActionResult DeleteA_CC_CareContactServant(long id)
        {
            A_CC_CareContactServant a_CC_CareContactServant = db.A_CC_CareContactServants.Find(id);
            if (a_CC_CareContactServant == null)
            {
                return NotFound();
            }

            db.A_CC_CareContactServants.Remove(a_CC_CareContactServant);
            db.SaveChanges();

            return Ok(a_CC_CareContactServant);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool A_CC_CareContactServantExists(long id)
        {
            return db.A_CC_CareContactServants.Count(e => e.ID == id) > 0;
        }
    }
}