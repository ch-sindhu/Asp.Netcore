using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage ="PLEASE choose the language of your book")]
        public string Language { get; set; }
        [Required(ErrorMessage = "PLEASE choose the language of your book")]
        public List<string> MultiLanguage { get; set; }

        [Required(ErrorMessage = "please enter the total pages")]
        public int? TotalPages { get; set; }
    }
}
