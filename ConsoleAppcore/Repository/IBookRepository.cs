using ConsoleAppcore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleAppcore.Repository
{
    public interface IBookRepository
    {
        Task<int> AddnewBook(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<List<BookModel>> GetTopBookAsync();
        List<BookModel> SearchBook(string title, string author);
        string GetAppName();
    }
}