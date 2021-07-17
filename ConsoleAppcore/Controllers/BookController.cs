﻿using ConsoleAppcore.Models;
using ConsoleAppcore.Repository;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult GetAllBooks()
        {
            var data=_bookRepository.GetAllBooks();
            return View(data);
        }
        [Route("book-details/{id}")]
        public ActionResult GetBook(int id)
        {
            var data= _bookRepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SearchBooks(string bookName,string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
        public ActionResult AddnewBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddnewBook(BookModel bookModel)
        {
            _bookRepository.AddnewBook(bookModel);
            return View();
        }
    }
}