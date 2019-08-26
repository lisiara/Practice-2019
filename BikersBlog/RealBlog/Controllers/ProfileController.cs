using BikersBlog.Helpers;
using RealBlog.DAL;
using RealBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RealBlog.Controllers
{
    public class ProfileController : Controller
    {
        private readonly BlogDBContext dbContext = new BlogDBContext();
        // GET: Profile
        public ActionResult Index(int Id)
        {

            var user = dbContext.Users.FirstOrDefault(
                    u => u.Id == Id);
            if (user != null)
            {

                var posts = dbContext.Posts.Where(c => c.Author.Id == Id).OrderByDescending(c => c.Data).ToList();
                ViewBag.Posts = posts;
            }



            return View(user);
        }

        public ActionResult ProfilePost()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult UpdateProfile(User model, HttpPostedFileBase imageData)

        {
            //1 проверить валидность
            //2 пароли совпадают
            //3 проверка что нет других польхователей с таким никнеймом
            //4 отображаем форму опять
            if (ModelState.IsValid)
            {
                
                if (model.Password != (model.PasswordConfirm))
                {
                    ModelState.AddModelError(string.Empty, "пароли не совпадают");
                }
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Nickname == model.Nickname && u.Id!=model.Id);
                if (userInDb != null)
                {
                    ModelState.AddModelError(string.Empty, "Пользователь с таким псевдонимом уже существует");
                }
                if (ModelState.IsValid)
                {
                    if (imageData != null)
                    {
                        model.Photourl = ImageSaveHelper.SaveImage(imageData);
                        
                    }


                    Session["UserNick"] = model.Nickname;
                    Session["UserPhotourl"] = model.Photourl;

                    dbContext.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                                                          
                }                
            }
            var posts = dbContext.Posts.Where(c => c.Author.Id == model.Id).ToList();
            ViewBag.Posts = posts;
            return View("Index", model);
        }

        

        [HttpPost]
        public ActionResult AddPost(Post model, HttpPostedFileBase imageData)
        {
            var userid = Convert.ToInt32(Session["UserId"]);
            var author = dbContext.Users.FirstOrDefault(u => u.Id == userid);
            if (ModelState.IsValid)
            {
                if (imageData == null)
                {
                    ModelState.AddModelError(String.Empty, "Добавьте фотографию");
                }
                else
                {

                    model.Photourl = ImageSaveHelper.SaveImage(imageData);
                    model.Data = DateTime.Now;
                    
                   // model.Author = author;
                    if (author == null)
                    {
                        throw new Exception("Пользователь не найден в бд");
                    }
                    model.Author = author;

                    dbContext.Posts.Add(model);
                    dbContext.SaveChanges();
                    //return View("Index");
                   
                }

            }

            var posts = dbContext.Posts.Where(c => c.Author.Id == userid).ToList();
            ViewBag.Posts = posts;
            return View("Index", author);


        }
    }
}