using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace BikersBlog.Helpers
{
    public class ImageSaveHelper
    {
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
}