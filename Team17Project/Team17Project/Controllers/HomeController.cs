using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team17Project.Controllers
{
    public class HomeController : Controller
    {
        Models.Team17ProjectBetaDatabaseEntities db = new Models.Team17ProjectBetaDatabaseEntities();
        public ActionResult Index(int? id)
        {
            List<Models.Image> images = new List<Models.Image>();
            if(id != null)
            {
                images = (from u in db.Images
                          where u.LocationId == id
                          select u).Take(20).ToList();

            }
            else
            {
                images = (from u in db.Images
                          select u).Take(20).ToList();
            }
            ViewBag.LocationDropdown = new SelectList(db.Locations, "Id", "Name");
            return View(images);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}