using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace БИПиТ11.Controllers
{
    public class OrdersController : ApiController
    {
        private adverstEntities db = new adverstEntities();

        // GET: api/Orders
        public IEnumerable<OrderView> GetOrderView()
        {
            return db.OrderView.ToList();
        }

        // GET: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrderView(int id)
        {
            Order orderView = db.Order.Find(id);
            if (orderView == null)
            {
                return NotFound();
            }

            return Ok(orderView);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderView(int id, Order orderView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            orderView.IdO = id;
            db.Entry(orderView).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Orders
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrderView(Order orderView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Order.Add(orderView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderViewExists(orderView.IdO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orderView.IdO }, orderView);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrderView(int id)
        {
            Order orderView = db.Order.Find(id);
            if (orderView == null)
            {
                return NotFound();
            }

            db.Order.Remove(orderView);
            db.SaveChanges();

            return Ok(orderView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderViewExists(int id)
        {
            return db.OrderView.Count(e => e.IdO == id) > 0;
        }
    }
}