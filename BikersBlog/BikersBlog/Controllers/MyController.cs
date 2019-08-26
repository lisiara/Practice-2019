using BikersBlog.DAL;
using BikersBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikersBlog.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        private CarDBContext dbContext = new CarDBContext();
        public ActionResult Index()
        {
            var myCar = new Car();
            return View(myCar);
        }
       
        public ActionResult Second()
        {
            var myCar = new Car();
            return View(myCar);
        }

        [HttpPost]
        public ActionResult Second(Car car)
        {
            if (ModelState.IsValid)
            {
                dbContext.Cars.Add(car);
                dbContext.SaveChanges();
              //  myCar = car;
               // return RedirectToAction("Index", "My");
            }
                return View(car);
            
        }
    }
}

