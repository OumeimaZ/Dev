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
using DevOps.Models;

namespace DevOps.Controllers
{
    public class DevsController : ApiController
    {
        private DevOContext db = new DevOContext();

        // GET: api/Devs
        public IQueryable<Dev> GetDevs()
        {
            return db.Devs;
        }

        // GET: api/Devs/5
        [ResponseType(typeof(Dev))]
        public IHttpActionResult GetDev(int id)
        {
            Dev dev = db.Devs.Find(id);
            if (dev == null)
            {
                return NotFound();
            }

            return Ok(dev);
        }

        // PUT: api/Devs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDev(int id, Dev dev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dev.Id)
            {
                return BadRequest();
            }

            db.Entry(dev).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevExists(id))
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

        // POST: api/Devs
        [ResponseType(typeof(Dev))]
        public IHttpActionResult PostDev(Dev dev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Devs.Add(dev);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dev.Id }, dev);
        }

        // DELETE: api/Devs/5
        [ResponseType(typeof(Dev))]
        public IHttpActionResult DeleteDev(int id)
        {
            Dev dev = db.Devs.Find(id);
            if (dev == null)
            {
                return NotFound();
            }

            db.Devs.Remove(dev);
            db.SaveChanges();

            return Ok(dev);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DevExists(int id)
        {
            return db.Devs.Count(e => e.Id == id) > 0;
        }
    }
}