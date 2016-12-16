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
using POQuiz.Models;

namespace POQuiz.Controllers
{
    public class PrimeMinistersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PrimeMinisters
        [Route("secretOfLife/getAllPrimeMinisterResults")]
        public IQueryable<PrimeMinister> GetPrimeMinisters()
        {
            return db.PrimeMinisters.OrderByDescending(x=>x.AnswerDate);
        }

        //// GET: api/PrimeMinisters/5
        //[ResponseType(typeof(PrimeMinister))]
        //public IHttpActionResult GetPrimeMinister(Guid id)
        //{
        //    PrimeMinister primeMinister = db.PrimeMinisters.Find(id);
        //    if (primeMinister == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(primeMinister);
        //}

        //// PUT: api/PrimeMinisters/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPrimeMinister(Guid id, PrimeMinister primeMinister)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != primeMinister.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(primeMinister).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PrimeMinisterExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/PrimeMinisters
        [ResponseType(typeof(PrimeMinister))]
        public IHttpActionResult PostPrimeMinister(PrimeMinister primeMinister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            primeMinister.Id = Guid.NewGuid();
            primeMinister.AnswerDate = DateTime.Now;
            db.PrimeMinisters.Add(primeMinister);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                //if (PrimeMinisterExists(primeMinister.Id))
                //{
                //    return Conflict();
                //}
                //else
                //{
                //    throw;
                //}
                return BadRequest();
            }

            //return CreatedAtRoute("DefaultApi", new { id = primeMinister.Id }, primeMinister);
            return Ok();
        }

        //// DELETE: api/PrimeMinisters/5
        //[ResponseType(typeof(PrimeMinister))]
        //public IHttpActionResult DeletePrimeMinister(Guid id)
        //{
        //    PrimeMinister primeMinister = db.PrimeMinisters.Find(id);
        //    if (primeMinister == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PrimeMinisters.Remove(primeMinister);
        //    db.SaveChanges();

        //    return Ok(primeMinister);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrimeMinisterExists(Guid id)
        {
            return db.PrimeMinisters.Count(e => e.Id == id) > 0;
        }
    }
}