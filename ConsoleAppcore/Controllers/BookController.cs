using ConsoleAppcore.Models;
using ConsoleAppcore.Repository;
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
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
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
        public ActionResult AddnewBook(bool isSuccess=false,int bookid=0)
        {
            var model = new BookModel()
            {
                Language = "2"
            };
           

            ViewBag.Language = new List<SelectListItem>()
            {
                new SelectListItem{Text="Hindi",Value="1"},
                new SelectListItem{Text="English",Value="2"},
                new SelectListItem{Text="Telugu",Value="3"},
                new SelectListItem{Text="Tamil",Value="4"},
                new SelectListItem{Text="urbu",Value="5"},
                new SelectListItem{Text="Arabi",Value="6"},
            };
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookid;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddnewBook(BookModel bookModel)
        {
            if(ModelState.IsValid)
            {
                int id = await _bookRepository.AddnewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddnewBook), new { isSuccess = true, bookid = id });
                }
            }
            ViewBag.Language = new List<SelectListItem>()
            {
                new SelectListItem{Text="Hindi",Value="1"},
                new SelectListItem{Text="English",Value="2"},
                new SelectListItem{Text="Telugu",Value="3"},
                new SelectListItem{Text="Tamil",Value="4"},
                new SelectListItem{Text="urbu",Value="5"},
                new SelectListItem{Text="Arabi",Value="6"},
            };
            return View();
        }
        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){Id=1,Text="Hindi"},
                new LanguageModel(){Id=1,Text="Hindi"},
                new LanguageModel(){Id=1,Text="Hindi"},
            };
        }

    }
}
