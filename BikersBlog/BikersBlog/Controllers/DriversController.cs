using BikersBlog.DAL;
using BikersBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikersBlog.Controllers
{
    public class DriversController : Controller
    {
        private CarDBContext dbContext = new CarDBContext();
        public ActionResult DriverView(int Id)
        {
            var myDriver = dbContext.Drivers.FirstOrDefault(c=>c.Id==Id);
            if (myDriver != null)
            {
                return View(myDriver);
            }
            return HttpNotFound();
        }
       
        public ActionResult DriverEd(int Id)
        {
            var myDriver = dbContext.Drivers.FirstOrDefault(c => c.Id == Id);
            if (myDriver != null)
            {
                return View(myDriver);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DriverEd(Driver driver)
        {
            if (ModelState.IsValid)
            {
                               
                dbContext.Entry(driver).State = EntityState.Modified;                                                           
                dbContext.SaveChanges();
                return RedirectToAction("List");
              //  myCar = car;
               // return RedirectToAction("Index", "My");
            }
                return View(driver);
            
        }

        public ActionResult List()
        {
            var allDrivers = dbContext.Drivers.OrderBy(c => c.Age).ToList();
            ViewBag.Drivers = allDrivers;
            return View();
           
        }
        [HttpPost]
        public ActionResult Create(Driver driver)
        {
            if (ModelState.IsValid)
            {

                dbContext.Drivers.Add(driver);
                dbContext.SaveChanges();
                

            }
            return RedirectToAction("List");

        }
    }
}