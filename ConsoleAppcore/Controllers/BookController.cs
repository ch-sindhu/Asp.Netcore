using ConsoleAppcore.Models;
using ConsoleAppcore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppcore.Controllers
{
    [Route("[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IBookRepository  _bookRepository = null;
        private readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        public BookController(IBookRepository bookRepository, ILanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("all-books")]
        public async Task<ActionResult> GetAllBooks()
        {
            var data=await _bookRepository.GetAllBooks();
            return View(data);
        }
        [Route("~/book-details/{id:int:min(1)}",Name="bookDetilsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data=await _bookRepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SearchBooks(string bookName,string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
        [Authorize]
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
                    string folder = "Books/cover/";
                   bookModel.CoverImageUrl=await UploadImage(folder,bookModel.Coverphoto);
                }
                if (bookModel.GalleryFiles != null)
                {
                    string folder = "Books/gallery/";
                    bookModel.Gallery = new List<GalleryModel>();

                    foreach(var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name=file.FileName,
                            URL = await UploadImage(folder, file)



                         };
                        bookModel.Gallery.Add(gallery);
                    }
                    
                }
                if (bookModel.BookPdf != null)
                {
                    string folder = "Books/pdf/";
                    bookModel.BookPdfUrl = await UploadImage(folder, bookModel.BookPdf);
                }

                int id = await _bookRepository.AddnewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddnewBook), new { isSuccess = true, bookid = id });
                }
            }
            //var languages = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            return View();
        }

        private async Task<string> UploadImage(string folderpath,IFormFile file)
        {
           
            folderpath += Guid.NewGuid().ToString() + "_" + file.FileName;
            
            string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folderpath);
            await file.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
            return "/" + folderpath;
        }

    }
}
