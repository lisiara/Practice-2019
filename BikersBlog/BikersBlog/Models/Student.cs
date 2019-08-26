using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikersBlog.Models
{
    public class Student
    {
        [Display(Name="Имя")]
        [Required(ErrorMessage ="Имя не задано")]
        public string Name { get; set; }
        [Range(14,100, ErrorMessage = "Возраст от 14 до 100")]

        [Display(Name = "Возраст")]
        public int Age { get; set; }

        // дата родления - datetime
        // группа - String
        // Отчислен -bool
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime Date { get; set; }

        [MaxLength(5, ErrorMessage = "группа = 5 символов")]
        [Display(Name = "Группа")]
        public String Group { get; set; }

        [Display(Name = "Отчислен")]
        public bool Expelled { get; set; }

        [Required(ErrorMessage ="Изображение не задано")]
        public string Fotourl { get; set; }

        [Display(Name = "Университет")]
        public University University { get; set; }
    }
}