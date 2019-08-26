using BikersBlog.Helpers;
using RealBlog.DAL;
using RealBlog.Models;
using RealBlog.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RealBlog.Controllers
{
    public class FeedController : Controller
    {
        private readonly BlogDBContext dbContext = new BlogDBContext();
        // GET: Feed
        public ActionResult Index()
        {
            var posts = dbContext.Posts.OrderByDescending(c=>c.Data).ToList();
            ViewBag.Posts = posts;
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel model)
        {
            var posts = dbContext.Posts.Where(c => c.Text.Contains(model.Searchstring) || c.Author.Nickname == model.Searchstring).OrderByDescending(c => c.Data).ToList();
            ViewBag.Posts = posts;
            return View("Index");
        }


        [HttpPost]        
        public ActionResult AddPost(Post model, HttpPostedFileBase imageData)
        {
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
                    var userid = Convert.ToInt32(Session["UserId"]);
                    var author = dbContext.Users.FirstOrDefault(u => u.Id == userid);
                    model.Author = author;
                    if (author==null)
                    {
                        throw new Exception("Пользовательне найден в бд");
                    }
                    model.Author = author;

                    dbContext.Posts.Add(model);
                    dbContext.SaveChanges();
                    //return View("Index");
                    return RedirectToAction("Index");
                }

            }

            var posts = dbContext.Posts.ToList();
            ViewBag.Posts = posts;
            return View("Index", model);

                
        }
    }
}