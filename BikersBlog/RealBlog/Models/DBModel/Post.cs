using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealBlog.Models
{
    public class Post
    {
        //Ключ
        [Key]
        public int Id { get; set; }
        // дата публикации
        public DateTime Data { get; set; }
        //Текст
        [Display(Name = "Текст")]
        [Required(ErrorMessage ="Введите текст")]
        [MaxLength(4095, ErrorMessage = "4095 символов")]
        public string Text { get; set; }

        // Фото
        
        public string Photourl{ get; set; }
        //автор
        public virtual User Author { get; set; }




    }
}