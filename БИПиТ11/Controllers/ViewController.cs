using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace БИПиТ11.Controllers
{
    public class ViewController : Controller
    {
        public ActionResult Client()
        {
            return View();
        }

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult Order()
        {
            return View();
        }
    }
}