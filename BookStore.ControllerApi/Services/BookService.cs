using BookStore.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.ControllerApi.Services
{
    public interface IBookService
    {
        List<Book> Books { get; set; }
    }

    public class BookService : IBookService
    {
        public List<Book> Books { get; set; }
        public BookService()
        {
            Books = Book.GetSampleData();
        }
    }
}
