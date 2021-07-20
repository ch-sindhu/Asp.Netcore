using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ConsoleAppcore.Enums;
using Microsoft.AspNetCore.Http;

namespace ConsoleAppcore.Models
{
    public class BookModel
    {
        [DataType(DataType.DateTime)]
        public string Myfield { get; set; }
        public int Id { get; set; }
        [StringLength(100,MinimumLength =5)]
        [Required(ErrorMessage ="please enter the title of book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "please enter the author name")]
        public string Author { get; set; }
        public  string Description { get; set; }
        public string Category { get; set; }
        //[Required(ErrorMessage ="PLEASE choose the language of your book")]
        public int LanguageId { get; set; }
        public string Language { set; get; }
        //[Required(ErrorMessage = "PLEASE choose the language of your book")]
        //public LanguageEnum LanguageEnum { get; set; }

        [Required(ErrorMessage = "please enter the total pages")]
        public int? TotalPages { get; set; }
        [Display(Name ="Choose the cover photo of your book")]
        [Required]
        public IFormFile Coverphoto { get; set; }
    }
}
