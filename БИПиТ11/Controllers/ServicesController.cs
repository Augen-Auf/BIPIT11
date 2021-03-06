﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using БИПиТ11;
using БИПиТ11.Models;

namespace БИПиТ11.Controllers
{
    public class ServicesController : ApiController
    {
        private adverstEntities db = new adverstEntities();

        // GET: api/Services
        public IEnumerable<ModelService> GetClient()
        {
            List<ModelService> services = new List<ModelService>();
            foreach (Service service in db.Service)
            {
                services.Add(new ModelService(service.IdS, service.Service1, service.Price));
            }
            return services;

        }

        // GET: api/Services/5
        [ResponseType(typeof(Service))]
        public IHttpActionResult GetService(int id)
        {
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        // PUT: api/Services/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutService(int id, Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.IdS = id;
            db.Entry(service).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Services
        [ResponseType(typeof(Service))]
        public IHttpActionResult PostService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Service.Add(service);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = service.IdS }, service);
        }

        // DELETE: api/Services/5
        [ResponseType(typeof(Service))]
        public IHttpActionResult DeleteService(int id)
        {
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            db.Service.Remove(service);
            db.SaveChanges();

            return Ok(service);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceExists(int id)
        {
            return db.Service.Count(e => e.IdS == id) > 0;
        }
    }
}