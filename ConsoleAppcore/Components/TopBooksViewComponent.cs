﻿using ConsoleAppcore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppcore.Components
{
    public class TopBooksViewComponent:ViewComponent
    {
        private readonly IBookRepository _bookRepository;
        public TopBooksViewComponent(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

     

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = await _bookRepository.GetTopBookAsync();
            return View(books);
        }

        
    }
}
