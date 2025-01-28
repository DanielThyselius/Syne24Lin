using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Fixtures
{
    public class LibraryFixture : IDisposable
    {
        public LibrarySystem Library { get; set; }
        public LibrarySystem BigLibrary { get; set; }

        public LibraryFixture()
        {
            Library = new LibrarySystem();
            BigLibrary = new LibrarySystem();

            BigLibrary.Resources.Add(new Book { Id = 1, Name = "Book 1" });
            BigLibrary.Resources.Add(new Book { Id = 2, Name = "Book 2" });
            BigLibrary.Resources.Add(new Book { Id = 3, Name = "Book 3" });
            BigLibrary.BookResource(1, "John");


        }

        public void Dispose()
        {
            // Clean up code
        }
    }
}
