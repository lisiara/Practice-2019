using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealBlog.Models.ViewModel
{
    public class LoginViewModel
    {

        

        [Display(Name="Псевдоним")]
        [Required(ErrorMessage="Ошибка в псевдониме"), MaxLength(20)]
        public string Nickname { get; set; }



        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Ошибка в пароле"), MaxLength(20)]
        public string Password { get; set; }

        [Display(Name = "Запомниить пароль")]
        public bool RememberMe { get; set; }


        
    }
}