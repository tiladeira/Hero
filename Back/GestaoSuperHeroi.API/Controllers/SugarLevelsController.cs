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
using GestaoSuperHeroi.API.Data;
using GestaoSuperHeroi.API.Models;

namespace GestaoSuperHeroi.API.Controllers
{
    public class SugarLevelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SugarLevels
        public IQueryable<SugarLevel> GetSugarLevels()
        {
            return db.SugarLevels;
        }

        // GET: api/SugarLevels/5
        [ResponseType(typeof(SugarLevel))]
        public IHttpActionResult GetSugarLevel(int id)
        {
            SugarLevel sugarLevel = db.SugarLevels.Find(id);
            if (sugarLevel == null)
            {
                return NotFound();
            }

            return Ok(sugarLevel);
        }

        // PUT: api/SugarLevels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSugarLevel(int id, SugarLevel sugarLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sugarLevel.Id)
            {
                return BadRequest();
            }

            db.Entry(sugarLevel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SugarLevelExists(id))
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

        // POST: api/SugarLevels
        [ResponseType(typeof(SugarLevel))]
        public IHttpActionResult PostSugarLevel(SugarLevel sugarLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SugarLevels.Add(sugarLevel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sugarLevel.Id }, sugarLevel);
        }

        // DELETE: api/SugarLevels/5
        [ResponseType(typeof(SugarLevel))]
        public IHttpActionResult DeleteSugarLevel(int id)
        {
            SugarLevel sugarLevel = db.SugarLevels.Find(id);
            if (sugarLevel == null)
            {
                return NotFound();
            }

            db.SugarLevels.Remove(sugarLevel);
            db.SaveChanges();

            return Ok(sugarLevel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SugarLevelExists(int id)
        {
            return db.SugarLevels.Count(e => e.Id == id) > 0;
        }
    }
}