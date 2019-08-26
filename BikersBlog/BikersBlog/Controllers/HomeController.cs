using BikersBlog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace BikersBlog.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Хелпер класс для работы с изображениями.
        /// </summary>
        public class ImageSaveHelper
        {
            /// <summary>
            /// Сохраняет изображение и возвращает путь до него.
            /// </summary>
            /// <param name="image"></param>
            /// <returns></returns>
            public static string SaveImage(HttpPostedFileBase image)
            {
                // var ext = Path.GetExtension(image.FileName);
                //  var newImageName = image.FileName;
                //  var result = newImageName + ext;
                var result = image.FileName;
                var filePathOriginal = HostingEnvironment.MapPath("/Content/Images/Uploads/");
                string savedFileName = Path.Combine(filePathOriginal ?? throw new InvalidOperationException(), result);
                image.SaveAs(savedFileName);
                return $"/Content/Images/Uploads/{result}";
            }

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Practice()
        {
            Student student = new Student {
                Name = "Адольф",
                Age = 17,
                Date = new DateTime(1911, 4, 4),
                Group = "групаа",
                Expelled = false,
                Fotourl = "/Content/Images/Uploads/111.png",
           /*     University = new University
                {
                    Name = "Самарский университет",
                    City = "Самара"
                }*/
            };
            ViewBag.Message = "Самая трудная практика во всех жизнях";
            ViewBag.Username = "Сашечка";
           
            return View(student);
        }

        [HttpPost]
        public ActionResult Practice(Student student, HttpPostedFileBase imageData)
        {
            // 
            if (imageData!=null)
      //      if(ModelState.IsValid)
             {
                var filename = ImageSaveHelper.SaveImage(imageData);
                student.Fotourl = filename;
            }
            return View(student);

        }
    }
}