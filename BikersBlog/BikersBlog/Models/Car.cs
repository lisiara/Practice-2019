using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikersBlog.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Модель не задана")]
        public string Modelname { get; set; }

        [Range(100, 400, ErrorMessage = "Скорость от 100 до 400")]
        public int Maxspeed { get; set; }

    }
}