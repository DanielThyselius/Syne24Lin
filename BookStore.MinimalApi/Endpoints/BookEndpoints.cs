using BookStore.Lib;
using BookStore.MinimalApi.Services;
using FluentValidation;
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
                return service.GetBookById(id);
            });

            // Post
            // TODO: use a DTO instead of Book
            app.MapPost("api/books", (
                [FromBody] Book book,
                [FromServices] IBookService service) =>
            {
                var validator = new BookValidator();
                var result = validator.Validate(book);
                if (!result.IsValid)
                    return Results.BadRequest(result.Errors.Select(x => new { 
                        Field = x.PropertyName,
                        Message = x.ErrorMessage
                    }));

                var newId = service.Books.Max(x => x.Id) + 1;
                book.Id = newId;
                service.Books.Add(book);
                return Results.Created($"/api/books/{newId}", book);
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

    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("The book needs a title");
            RuleFor(x => x.Author).NotEmpty().WithMessage("The book needs an author");
        }
    }
}
