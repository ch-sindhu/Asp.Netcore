using ConsoleAppcore.data;
using ConsoleAppcore.Models;
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
       public int AddnewBook(BookModel model)
        {
            var newbook = new Books()
            {
                Author=model.Author,
                CreatedOn=DateTime.UtcNow,
                Description=model.Description,
                Title=model.Title,
                TotalPages=model.TotalPages,
                UpdatedOn=DateTime.UtcNow
            };
            _context.Books.Add(newbook);
            _context.SaveChanges();
            return newbook.Id; 
        }
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
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
