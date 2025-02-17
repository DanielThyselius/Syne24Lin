using BookStore.ControllerApi.Services;
using BookStore.Lib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.ControllerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [AllowAnonymous]
        [HttpGet]
        public List<Book> GetAllBooks()
        {
            return _bookService.Books;
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            var newId = _bookService.Books.Max(x => x.Id) + 1;
            book.Id = newId;
            _bookService.Books.Add(book);
            return Created($"api/books/{newId}", book);
        }

        // TODO:
        // - Get single book by Id
        // - Update a book (PUT)
        // - Update only review of book (PATCH)
        // - Do this in a separate project as a minimal API (keep going on friday exercise)
        // - Add Author and endpoints in this Controller.Api project
        
    }
}
