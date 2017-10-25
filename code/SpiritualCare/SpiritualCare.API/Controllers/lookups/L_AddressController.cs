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
    public class L_AddressController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_Address
        public IQueryable<L_Address> GetL_AddressTypes()
        {
            return db.L_AddressTypes;
        }

        // GET: api/L_Address/5
        [ResponseType(typeof(L_Address))]
        public async Task<IHttpActionResult> GetL_Address(long id)
        {
            L_Address l_Address = await db.L_AddressTypes.FindAsync(id);
            if (l_Address == null)
            {
                return NotFound();
            }

            return Ok(l_Address);
        }

        // PUT: api/L_Address/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutL_Address(long id, L_Address l_Address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_Address.ID)
            {
                return BadRequest();
            }

            db.Entry(l_Address).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_AddressExists(id))
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

        // POST: api/L_Address
        [ResponseType(typeof(L_Address))]
        public async Task<IHttpActionResult> PostL_Address(L_Address l_Address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_AddressTypes.Add(l_Address);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = l_Address.ID }, l_Address);
        }

        // DELETE: api/L_Address/5
        [ResponseType(typeof(L_Address))]
        public async Task<IHttpActionResult> DeleteL_Address(long id)
        {
            L_Address l_Address = await db.L_AddressTypes.FindAsync(id);
            if (l_Address == null)
            {
                return NotFound();
            }

            db.L_AddressTypes.Remove(l_Address);
            await db.SaveChangesAsync();

            return Ok(l_Address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool L_AddressExists(long id)
        {
            return db.L_AddressTypes.Count(e => e.ID == id) > 0;
        }
    }
}