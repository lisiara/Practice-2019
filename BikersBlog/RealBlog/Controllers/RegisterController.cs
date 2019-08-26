using BikersBlog.Helpers;
using RealBlog.DAL;
using RealBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RealBlog.Controllers
{
    public class RegisterController : Controller
    {
        private readonly BlogDBContext dbContext = new BlogDBContext();
        // GET: Register
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Feed");
        }

        [HttpPost]
        public ActionResult Register(User model, HttpPostedFileBase imageData)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != (model.PasswordConfirm))
                {
                    ModelState.AddModelError(string.Empty, "пароли не совпадают");
                }
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Nickname == model.Nickname);                
                if(userInDb!=null)
                { 
                    ModelState.AddModelError(string.Empty, "Пользователь с таким псевдонимом уже существует");
                }

                var userInDbByEmail = dbContext.Users.FirstOrDefault(u => u.Email == model.Email);
                if (userInDbByEmail != null)
                {
                    ModelState.AddModelError(string.Empty, "Пользователь с такой почтой уже существует");
                }

                if (ModelState.IsValid)
                {
                    if (imageData != null)
                    {
                        model.Photourl = ImageSaveHelper.SaveImage(imageData);
                    }

                    dbContext.Users.Add(model);
                    dbContext.SaveChanges();
                    FormsAuthentication.SetAuthCookie(model.Nickname, false);
                    Session["UserId"] = model.Id.ToString();
                    Session["UserNick"] = model.Nickname;
                    Session["UserPhotourl"] = model.Photourl;
                    return RedirectToAction("Index", "Feed");
                    
                }
               
            }
            return View("Index",model);
        }
    }
}