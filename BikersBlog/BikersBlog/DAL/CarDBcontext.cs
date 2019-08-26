using BikersBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BikersBlog.DAL
{
    public class CarDBContext : DbContext
    {


        public CarDBContext() : base("CarDBContext")
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }



    }
}