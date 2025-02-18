using BookStore.Lib;

namespace BookStore.MinimalApi.Services;

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
