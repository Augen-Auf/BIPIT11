using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using БИПиТ11.Models;

namespace БИПиТ11.Controllers
{
    public class ClientsController : ApiController
    {
        private adverstEntities db = new adverstEntities();

        // GET: api/Clients
        public IEnumerable<ModelClient> GetClient()
        {
            List<ModelClient> clients = new List<ModelClient>();
            foreach (Client client in db.Client)
            {
                clients.Add(new ModelClient(client.IdC, client.Client1, client.Phone));
            }
            return clients;
            
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            client.IdC = id;
            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Client.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.IdC }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Client.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Client.Count(e => e.IdC == id) > 0;
        }
    }
}