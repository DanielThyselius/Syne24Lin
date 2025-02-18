using BookStore.Lib;
using BookStore.MinimalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.MinimalApi.Endpoints
{
    public static class BookEndpoints
    {
        // models
        record UpdateBookRequest(string Description, string Review);

        // endpoints
        public static void RegisterBookEndpoints(this IEndpointRouteBuilder app)
        {
            // Get All
            app.MapGet("/api/books", (IBookService service) => service.Books);

            // Get by Id
            app.MapGet("/api/books/{id}", (int id, IBookService service) =>
            {
                return service.Books.Find(x => x.Id == id);
            });

            // Post
            // TODO: use a DTO instead of Book
            app.MapPost("api/books", (
                [FromBody] Book book,
                [FromServices] IBookService service) =>
            {
                var newId = service.Books.Max(x => x.Id) + 1;
                book.Id = newId;
                service.Books.Add(book);
            });

            // PATCH
            app.MapPatch("api/books/{id}", (int id, UpdateBookRequest request, IBookService service) =>
            {
                var oldBook = service.Books.Find(x => x.Id == id);
                if (oldBook is null)
                    return Results.NotFound(id);

                oldBook.Description = request.Description;
                oldBook.Review = request.Review;

                return Results.Ok();
            });


            // Delete
            app.MapDelete("api/books/{id}", (int id, IBookService service) =>
            {
                var book = service.Books.Find(x => x.Id == id);

                return service.Books.Remove(book) ? Results.NoContent() : Results.NotFound(id);
            });
        }
    }
}
