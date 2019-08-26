using RealBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealBlog.DAL
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext() : base("BikersBlogDatabase")
        {
            Database.SetInitializer(new BlogDbInitializer());
        }

        public DbSet<User> Users { get; set;}
        public DbSet<Post> Posts { get; set; }
    }
}