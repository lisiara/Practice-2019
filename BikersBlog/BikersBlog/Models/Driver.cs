using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikersBlog.Models
{
    public class Driver
    {

        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Имя не задана")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фамилия не задана")]
        public string Lastname { get; set; }



        public int Age { get; set; }

        public virtual Car Car { get; set; }

    }
}