﻿using System;
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
    public class L_ChurchServiceController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_ChurchService
        public IQueryable<L_ChurchService> GetL_ChurchServices()
        {
            return db.L_ChurchServices;
        }

        // GET: api/L_ChurchService/5
        [ResponseType(typeof(L_ChurchService))]
        public async Task<IHttpActionResult> GetL_ChurchService(long id)
        {
            L_ChurchService l_ChurchService = await db.L_ChurchServices.FindAsync(id);
            if (l_ChurchService == null)
            {
                return NotFound();
            }

            return Ok(l_ChurchService);
        }

        // PUT: api/L_ChurchService/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutL_ChurchService(long id, L_ChurchService l_ChurchService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_ChurchService.ID)
            {
                return BadRequest();
            }

            db.Entry(l_ChurchService).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_ChurchServiceExists(id))
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

        // POST: api/L_ChurchService
        [ResponseType(typeof(L_ChurchService))]
        public async Task<IHttpActionResult> PostL_ChurchService(L_ChurchService l_ChurchService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_ChurchServices.Add(l_ChurchService);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = l_ChurchService.ID }, l_ChurchService);
        }

        // DELETE: api/L_ChurchService/5
        [ResponseType(typeof(L_ChurchService))]
        public async Task<IHttpActionResult> DeleteL_ChurchService(long id)
        {
            L_ChurchService l_ChurchService = await db.L_ChurchServices.FindAsync(id);
            if (l_ChurchService == null)
            {
                return NotFound();
            }

            db.L_ChurchServices.Remove(l_ChurchService);
            await db.SaveChangesAsync();

            return Ok(l_ChurchService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool L_ChurchServiceExists(long id)
        {
            return db.L_ChurchServices.Count(e => e.ID == id) > 0;
        }
    }
}