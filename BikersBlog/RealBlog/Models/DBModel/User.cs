using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealBlog.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        

        [Display(Name = "Псевдоним")]
        [Required(ErrorMessage = "Псевдоним не задан")]
        [MaxLength(20, ErrorMessage = "Псевдоним до 20 символов")]
        [MinLength(3, ErrorMessage = "Псевдоним от 3 символов")]
        [RegularExpression(@"^(?=.*[A-Za-z])[A-Za-z\d_]{3,20}", ErrorMessage = "Псевдоним некорректен")]
        [Description("От 3 до 20 символов") ]
        public string Nickname { get; set; }



        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Пароль не задан")]
        [MaxLength(20, ErrorMessage = "Пароль до 20 символов")]
        [MinLength(6, ErrorMessage = "Пароль от 6 символов")]
        [RegularExpression(@"^(?=.*[A-Za-z])[A-Za-z\d_]{6,20}", ErrorMessage = "Пароль некорректен")]
        [Description("От 6 до 20 символов")]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Подтверждение пароля")]
        [MaxLength(20, ErrorMessage = "Пароль до 20 символов")]
        [MinLength(6, ErrorMessage = "Пароль от 6 символов")]
        public string PasswordConfirm { get; set; }

        [EmailAddress]
        [Display(Name = "Почта")]
        [Required(ErrorMessage = "Почта не задана")]
        [MaxLength(31, ErrorMessage = "Почта до 31 символов")]
        
        public string Email { get; set; }



        public string Photourl { get; set; }

        [Display(Name = "Имя")]
        [MaxLength(31, ErrorMessage = "Имя до 31 символов")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [MaxLength(31, ErrorMessage = "Фамилия до 31 символов")]
        public string LastName { get; set; }

      


        [Display(Name = "Контакты")]
        [MaxLength(255, ErrorMessage = "Контактная информация До 255 символов")]
        public string ContactInfo { get; set; }

        [Display(Name = "ТТх мотоцикла")]
        [MaxLength(255, ErrorMessage = "ТТХ До 255 символов")]
        public string BikeSpecifications { get; set; }

        [Display(Name = "Увлечения")]
        [MaxLength(255, ErrorMessage = "Хобби До 255 символов")]
        public string Hobbies { get; set; }

    }
}