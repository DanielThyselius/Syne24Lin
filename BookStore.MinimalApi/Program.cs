
using BookStore.MinimalApi.Endpoints;
using BookStore.MinimalApi.Services;
using Swashbuckle.AspNetCore.SwaggerUI;

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
            builder.Services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new()
                {
                    Title = "BookStore API",
                    Version = "v1.2",
                    Description = "A simple example book store api",
                    Contact = new() { Name = "Daniel" }
                });
                options.SwaggerDoc("v2", new()
                {
                    Title = "BookStore API",
                    Version = "v2",
                    Description = "A better example book store api",
                    Contact = new() { Name = "Daniel" }
                })
                ;
            });

            builder.Services.AddSingleton<IBookService, BookService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.DocExpansion(DocExpansion.List);
                    c.DefaultModelsExpandDepth(-1);
                });
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Map endpoints for books
            app.RegisterBookEndpoints();

            app.Run();
        }
    }
}
