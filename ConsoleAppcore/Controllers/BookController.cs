using ConsoleAppcore.Models;
using ConsoleAppcore.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppcore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository  _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ActionResult> GetAllBooks()
        {
            var data=await _bookRepository.GetAllBooks();
            return View(data);
        }
        [Route("book-details/{id}",Name="bookDetilsStore")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data=await _bookRepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SearchBooks(string bookName,string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
        public async Task<ActionResult> AddnewBook(bool isSuccess=false,int bookid=0)
        {
            var model = new BookModel()
            {
                //Language = "2"
            };

            var languages =new SelectList(await _languageRepository.GetLanguages(),"Id","Name");
           
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookid;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddnewBook(BookModel bookModel)
        {
            if(ModelState.IsValid)
            {
                if(bookModel.Coverphoto!=null)
                {
                    string folder = "Books/cover";
                }
                    
                int id = await _bookRepository.AddnewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddnewBook), new { isSuccess = true, bookid = id });
                }
            }
            var languages = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            return View();
        }
     

    }
}
