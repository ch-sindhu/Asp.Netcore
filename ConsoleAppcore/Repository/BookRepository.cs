using ConsoleAppcore.data;
using ConsoleAppcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ConsoleAppcore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
       public async Task<int> AddnewBook(BookModel model)
        {
            var newbook = new Books()
            {
                Author=model.Author,
                CreatedOn=DateTime.UtcNow,
                Description=model.Description,
                Title=model.Title,
                Language=model.Language,
                TotalPages = model.TotalPages.HasValue?model.TotalPages.Value:0,
                UpdatedOn=DateTime.UtcNow
            };
            await  _context.Books.AddAsync(newbook);
            await  _context.SaveChangesAsync();
            return newbook.Id; 
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any()==true)
            {
                foreach(var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category=book.Category,
                        Description=book.Description,
                        Id=book.Id,
                        Language=book.Language,
                        Title=book.Title,
                        TotalPages=book.TotalPages,
                    }); 
                        

                    
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
           
            var book = await _context.Books.FindAsync(id);
            if(book!=null)
            {
                var bookDetails = new BookModel()
                {
                    Author=book.Author,
                    Category=book.Category,
                    Description=book.Description,
                    Id=book.Id,
                    Language=book.Language,
                    Title=book.Title,
                    TotalPages=book.TotalPages,

                };
                return bookDetails;
            }
            return null;
            //return DataSource().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public List<BookModel> SearchBook(string title,string author)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(author)).ToList();
        }
        public List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){ Id=1,Title="MVC",Author="sindhu",Description="This is the description for MVC book",Category="Programming",Language="English",TotalPages=456},
                new BookModel(){ Id=2,Title="core",Author="nitish",Description="This is the description for  dot net Core book",Category="Framework",Language="English",TotalPages=486},
                new BookModel(){ Id=3,Title="c#",Author="mounika",Description="This is the description for C# book",Category="Developer",Language="English",TotalPages=267},
                new BookModel(){ Id=4,Title="java",Author="nitish",Description="This is the description for java book",Category="OOPs",Language="English",TotalPages=460},
                new BookModel(){ Id=5,Title="deveops",Author="mounika",Description="This is the description for Deveops book",Category="Deveops",Language="English",TotalPages=529},


            };
        }
    }
}
