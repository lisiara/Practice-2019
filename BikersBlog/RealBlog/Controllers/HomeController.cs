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
    public class HomeController : Controller
    {
        private BlogDBContext dbContext = new BlogDBContext();
        private object existanceUser;

        public ActionResult Index()
        {
            var cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                Session["UserId"] = cookie["UserId"];
                Session["UserNick"] = cookie["UserNick"];
                Session["UserPhotourl"] = cookie["UserPhotourl"];
                return RedirectToAction("Index", "Feed");
            }
            if (Session["UserId"] == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Feed");
        }
        

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(
                    u => u.Nickname == user.Nickname
                    && u.Password == user.Password);
                if (userInDb != null)
                {

                    FormsAuthentication.SetAuthCookie(user.Nickname, user.RememberMe);
                    Session["UserId"] = userInDb.Id.ToString();
                    Session["UserNick"] = userInDb.Nickname;
                    Session["UserPhotourl"] = userInDb.Photourl;


                    if (user.RememberMe)
                    {
                        HttpCookie userInfo = new HttpCookie("UserInfo");
                        userInfo["UserId"] = userInDb.Id.ToString();
                        userInfo["UserNick"] = userInDb.Nickname.ToString();
                        userInfo.Expires = DateTime.Now.AddYears(1);
                        Response.Cookies.Add(userInfo);
                    }

                    return RedirectToAction("Index", "Feed");

                    
                }

                else
                {
                    ModelState.AddModelError(String.Empty, "Ошибка. неверный пароль или псевдоним");
                }
            }
            return View("Index", user);
        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();

               var cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                var newCookie = new HttpCookie("UserInfo");
                newCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(newCookie);

            }



            Request.Cookies.Clear();
            return RedirectToAction("Index");
        }

    }
}