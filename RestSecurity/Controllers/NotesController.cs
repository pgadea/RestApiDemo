using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RestSecurity.Models;
using Microsoft.AspNet.Identity;

namespace RestSecurity.Controllers
{
    [Authorize]
    public class NotesController : ApiController
    {
        private RestSecurityContext db = new RestSecurityContext();

        // GET: api/Notes
        public IQueryable<Notes> GetNotes()
        {
            string userId = User.Identity.GetUserId();
            return db.Notes.Where(n => n.UserId == userId);
        }

        // GET: api/Notes/5
        [ResponseType(typeof(Notes))]
        public async Task<IHttpActionResult> GetNotes(int id)
        {
            Notes notes = await db.Notes.FindAsync(id);
            if (notes == null)
            {
                return NotFound();
            }

            return Ok(notes);
        }

        // PUT: api/Notes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNotes(int id, Notes notes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notes.Id)
            {
                return BadRequest();
            }

            db.Entry(notes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotesExists(id))
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

        // POST: api/Notes
        [ResponseType(typeof(Notes))]
        public async Task<IHttpActionResult> PostNotes(Notes notes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = User.Identity.GetUserId();
            notes.UserId = userId;

            db.Notes.Add(notes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = notes.Id }, notes);
        }

        // DELETE: api/Notes/5
        [ResponseType(typeof(Notes))]
        public async Task<IHttpActionResult> DeleteNotes(int id)
        {
            Notes notes = await db.Notes.FindAsync(id);
            if (notes == null)
            {
                return NotFound();
            }

            db.Notes.Remove(notes);
            await db.SaveChangesAsync();

            return Ok(notes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotesExists(int id)
        {
            return db.Notes.Count(e => e.Id == id) > 0;
        }
    }
}