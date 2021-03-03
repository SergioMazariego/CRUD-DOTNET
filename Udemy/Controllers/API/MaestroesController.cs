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
using Udemy.Models;

namespace Udemy.Controllers.API
{
    public class MaestroesController : ApiController
    {
        private AlumnosContect db = new AlumnosContect();

        // GET: api/Maestroes
        public IQueryable<Maestro> GetMaestro()
        {
            return db.Maestro;
        }

        // GET: api/Maestroes/5
        [ResponseType(typeof(Maestro))]
        public async Task<IHttpActionResult> GetMaestro(int id)
        {
            Maestro maestro = await db.Maestro.FindAsync(id);
            if (maestro == null)
            {
                return NotFound();
            }

            return Ok(maestro);
        }

        // PUT: api/Maestroes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMaestro(int id, Maestro maestro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maestro.ID)
            {
                return BadRequest();
            }

            db.Entry(maestro).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaestroExists(id))
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

        // POST: api/Maestroes
        [ResponseType(typeof(Maestro))]
        public async Task<IHttpActionResult> PostMaestro(Maestro maestro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Maestro.Add(maestro);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = maestro.ID }, maestro);
        }

        // DELETE: api/Maestroes/5
        [ResponseType(typeof(Maestro))]
        public async Task<IHttpActionResult> DeleteMaestro(int id)
        {
            Maestro maestro = await db.Maestro.FindAsync(id);
            if (maestro == null)
            {
                return NotFound();
            }

            db.Maestro.Remove(maestro);
            await db.SaveChangesAsync();

            return Ok(maestro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaestroExists(int id)
        {
            return db.Maestro.Count(e => e.ID == id) > 0;
        }
    }
}