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
using ChoreScore.Models;
using Microsoft.AspNet.Identity;

namespace ChoreScore.Controllers
{
    [RoutePrefix("api/chores")]
    public class ChoresController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Chores
        [Route(""), HttpGet]
        public IEnumerable<Chore> GetChores()
        {
            return db.Chores.ToList<Chore>();
        }

        // GET: api/Chores/5
        [ResponseType(typeof(Chore))]
        [Route("{id}"),HttpGet]
        public async Task<IHttpActionResult> GetChore(int id)
        {
            Chore chore = await db.Chores.FindAsync(id);
            if (chore == null)
            {
                return NotFound();
            }

            return Ok(chore);
        }

        // PUT: api/Chores/{id}
        [ResponseType(typeof(void))]
        [Route("{id}/dochore"),HttpPut]
        public async Task<IHttpActionResult> DoChore(int id)
        {
            var choreToEdit = db.Chores.Find(id);

            choreToEdit.CompletedDate = DateTime.Now;
            choreToEdit.isAssigned = true;
       
            choreToEdit.user = db.Users.Find(User.Identity.GetUserId());

            choreToEdit.user.CurrentPoints += choreToEdit.PointsAssigned;








            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoreExists(id))
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

        // POST: api/Chores/
        [ResponseType(typeof(Chore))]
        [Route("add"),HttpPost]
        public async Task<HttpResponseMessage> PostChore(Chore chore)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, chore);
            }

            db.Chores.Add(chore);
            await db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.Created,chore);
        }

        // DELETE: api/Chores/remove/{id}
        [ResponseType(typeof(Chore))]
        [Route("{id}"),HttpDelete]
        public async Task<IHttpActionResult> DeleteChore(int id)
        {
            var chore = db.Chores.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (chore == null)
            {
                return NotFound();
            }

            db.Chores.Remove(chore);
            await db.SaveChangesAsync();

            return Ok(chore);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChoreExists(int id)
        {
            return db.Chores.Count(e => e.Id == id) > 0;
        }
    }
}