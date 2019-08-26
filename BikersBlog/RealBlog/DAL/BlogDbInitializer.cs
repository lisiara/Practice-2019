using RealBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealBlog.DAL
{
    public class BlogDbInitializer : DropCreateDatabaseAlways<BlogDBContext>
    {
        protected override void Seed(BlogDBContext context)
        {
            User defaultUser = new User { Nickname = "test", Password = "testtest", Email="test@mail.ru" };
            context.Users.Add(defaultUser);
            context.SaveChanges();

        }

    }
}