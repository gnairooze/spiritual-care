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
using SpiritualCare.Data;
using SpiritualCare.Model.Lookup;

namespace SpiritualCare.API.Controllers.lookups
{
    public class L_ChurchController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_Church
        public IQueryable<L_Church> GetL_Churches()
        {
            return db.L_Churches;
        }

        // GET: api/L_Church/5
        [ResponseType(typeof(L_Church))]
        public async Task<IHttpActionResult> GetL_Church(long id)
        {
            L_Church l_Church = await db.L_Churches.FindAsync(id);
            if (l_Church == null)
            {
                return NotFound();
            }

            return Ok(l_Church);
        }

        // PUT: api/L_Church/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutL_Church(long id, L_Church l_Church)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_Church.ID)
            {
                return BadRequest();
            }

            db.Entry(l_Church).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_ChurchExists(id))
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

        // POST: api/L_Church
        [ResponseType(typeof(L_Church))]
        public async Task<IHttpActionResult> PostL_Church(L_Church l_Church)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_Churches.Add(l_Church);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = l_Church.ID }, l_Church);
        }

        // DELETE: api/L_Church/5
        [ResponseType(typeof(L_Church))]
        public async Task<IHttpActionResult> DeleteL_Church(long id)
        {
            L_Church l_Church = await db.L_Churches.FindAsync(id);
            if (l_Church == null)
            {
                return NotFound();
            }

            db.L_Churches.Remove(l_Church);
            await db.SaveChangesAsync();

            return Ok(l_Church);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool L_ChurchExists(long id)
        {
            return db.L_Churches.Count(e => e.ID == id) > 0;
        }
    }
}