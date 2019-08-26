using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikersBlog.Models
{
    public class University
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }


        [Display(Name = "Город")]
        public string City { get; set; }
    }
}