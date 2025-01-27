using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class LibrarySystem
    {
        public List<Resource> Resources { get; set; } = new List<Resource>();

        public LibrarySystem()
        {
            // Add some demo resources to the library
            GetDemoResources();
        }

        public Resource? GetResource(int id)
        {
            return Resources.FirstOrDefault(r => r.Id == id);
        }

        public Resource? GetResource(string name)
        {
            return Resources.FirstOrDefault(r => r.Name == name);
        }

        public bool BookResource(int id, string name)
        {
            var resource = Resources.FirstOrDefault(r => r.Id == id);
            if (resource == null)
            {
                return false;
            }

            if (resource is IBookable bookable)
            {
                return bookable.Book(name);
                
            }
            return false;
        }

            private void GetDemoResources()
        {
            Resources.Add(new Book()
            {
                Id = 1,
                Name = "Clean Code"
            });
            Resources.Add(new Computer()
            {
                Id = 2,
                Name = "Dell XPS 13"
            });
            Resources.Add(new Room()
            {
                Id = 3,
                Name = "Room 1"
            });
            Resources.Add(new Book()
            {
                Id = 4,
                Name = "The Pragmatic Programmer"
            });
        }
    }
}
