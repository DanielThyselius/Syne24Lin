using BookStore.Lib;

namespace BookStore.MinimalApi.Services;

public interface IBookService
{
    List<Book> Books { get; set; }

    Book GetBookById(int id);
}

public class BookService : IBookService
{
    public List<Book> Books { get; set; }
    public BookService()
    {
        Books = Book.GetSampleData();
    }


    public Book GetBookById(int id) {
        var book = Books.Find(x => x.Id == id);
        if (book is null)
        {
            // Maybe not the correct exception to throw, but it's just an example
            throw new KeyNotFoundException($"Book with id {id} not found");
        }
        return book;
    
    }
}
