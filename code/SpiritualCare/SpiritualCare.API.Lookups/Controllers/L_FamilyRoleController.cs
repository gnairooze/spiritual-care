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
    public class L_FamilyRoleController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_FamilyRole
        public IQueryable<L_FamilyRole> GetL_FamilyRoles()
        {
            return db.L_FamilyRoles;
        }

        // GET: api/L_FamilyRole/5
        [ResponseType(typeof(L_FamilyRole))]
        public IHttpActionResult GetL_FamilyRole(long id)
        {
            L_FamilyRole l_FamilyRole = db.L_FamilyRoles.Find(id);
            if (l_FamilyRole == null)
            {
                return NotFound();
            }

            return Ok(l_FamilyRole);
        }

        // PUT: api/L_FamilyRole/5
        [ResponseType(typeof(L_FamilyRole))]
        [HttpPost]
        public IHttpActionResult PutL_FamilyRole(long id, L_FamilyRole l_FamilyRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_FamilyRole.ID)
            {
                return BadRequest();
            }

            db.Entry(l_FamilyRole).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_FamilyRoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(l_FamilyRole);
        }

        // POST: api/L_FamilyRole
        [ResponseType(typeof(L_FamilyRole))]
        public IHttpActionResult PostL_FamilyRole(L_FamilyRole l_FamilyRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_FamilyRoles.Add(l_FamilyRole);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_FamilyRole.ID }, l_FamilyRole);
        }

        // DELETE: api/L_FamilyRole/5
        [ResponseType(typeof(L_FamilyRole))]
        [HttpPost]
        public IHttpActionResult DeleteL_FamilyRole(long id)
        {
            L_FamilyRole l_FamilyRole = db.L_FamilyRoles.Find(id);
            if (l_FamilyRole == null)
            {
                return NotFound();
            }

            db.L_FamilyRoles.Remove(l_FamilyRole);
            db.SaveChanges();

            return Ok(l_FamilyRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool L_FamilyRoleExists(long id)
        {
            return db.L_FamilyRoles.Count(e => e.ID == id) > 0;
        }
    }
}