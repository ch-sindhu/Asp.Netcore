using ConsoleAppcore.data;
using ConsoleAppcore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ConsoleAppcore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;
        private readonly IConfiguration _configuration;

        public BookRepository(BookStoreContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<int> AddnewBook(BookModel model)
        {
            var newbook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl

            };
            newbook.bookGallery = new List<BookGallery>();
            foreach (var file in model.Gallery)
            {
                newbook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });

            }


            await _context.Books.AddAsync(newbook);
            await _context.SaveChangesAsync();
            return newbook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books
            .Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Id = book.Id,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                Title = book.Title,
                TotalPages = book.TotalPages,
                CoverImageUrl = book.CoverImageUrl
            }).ToListAsync();
        }
        public async Task<List<BookModel>> GetTopBookAsync()
        {
            return await _context.Books
            .Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Id = book.Id,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                Title = book.Title,
                TotalPages = book.TotalPages,
                CoverImageUrl = book.CoverImageUrl
            }).ToListAsync();
        }

        public async Task<BookModel> GetBookById(int id)
        {

            return await _context.Books.Where(x => x.Id == id).Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Id = book.Id,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                Title = book.Title,
                TotalPages = book.TotalPages,
                CoverImageUrl = book.CoverImageUrl,
                Gallery = book.bookGallery.Select(g => new GalleryModel()
                {
                    id = g.Id,
                    Name = g.Name,
                    URL = g.URL

                }).ToList(),
                BookPdfUrl = book.BookPdfUrl


            }).FirstOrDefaultAsync();


            //return DataSource().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public List<BookModel> SearchBook(string title, string author)
        {
            return null;
        }
       
        public string GetAppName()
        {
            return _configuration["AppName"];
        }
    }
}
