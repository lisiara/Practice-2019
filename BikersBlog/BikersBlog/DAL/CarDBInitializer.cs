using BikersBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BikersBlog.DAL
{
    public class CarDBInitializer : DropCreateDatabaseAlways<CarDBContext>  // Create....
    {
        protected override void Seed(CarDBContext context)
        {
            var car1= new  Models.Car { Modelname = "Hond", Maxspeed = 300 };
            var car2 = new  Models.Car { Modelname = "Toyot", Maxspeed = 330 };
            context.Cars.Add(car1);
            context.Cars.Add(car2);

            var driver1 = new Driver
            {
                Age = 18,
                Name = "kokoko",
                Lastname = "dododod",
                Car = car1
            };
            var driver2 = new Driver
            {
                Age = 22,
            Name = "driver2",
                Lastname = "2222",
                Car = car2
            };
            context.Drivers.Add(driver1);
            context.Drivers.Add(driver2);


            context.SaveChanges();
            //context.Cars.Remove(car2);
            //car1.ModelName = "Mitsibishi";

            //var selectResult = context.Cars.Where(c => c.Maxspeed > 90);

            //base.Seed(context);
        }

    }
}