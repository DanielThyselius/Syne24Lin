
using BookStore.Lib;
using BookStore.MinimalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.MinimalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IBookService, BookService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Map endpoints for books
            // Get All
            app.MapGet("/api/books", (IBookService service) => service.Books);

            // Get by Id
            app.MapGet("/api/books/{id}", (int id, IBookService service) =>
            {
                return service.Books.Find(x => x.Id == id);
            });

            // Post
            app.MapPost("api/books", (
                [FromBody] Book book,
                [FromServices] IBookService service) =>
            {
                var newId = service.Books.Max(x => x.Id) + 1;
                book.Id = newId;
                service.Books.Add(book);
            });

            // Put
            app.MapPut("api/books/{id}", (int id, Book book, IBookService service) =>
            {
                var oldBook = service.Books.Find(x => x.Id == id);
                if (oldBook is null)
                    return Results.NotFound(id);

                book.Id = id; // avoid changing Ids, could be handled better
                oldBook.Title = book.Title;
                oldBook.Author = book.Author;
                oldBook.Description = book.Description;
                oldBook.Review = book.Review;

                return Results.Ok();
            });


            // Delete
            app.MapDelete("api/books/{id}", (int id, IBookService service) =>
            {
                var book = service.Books.Find(x => x.Id == id);

                return service.Books.Remove(book) ? Results.NoContent() : Results.NotFound(id);
            });


            app.Run();
        }
    }
}
