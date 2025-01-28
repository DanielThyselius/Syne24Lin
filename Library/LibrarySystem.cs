using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class LibrarySystem
    {
        internal List<Resource> Resources { get; set; } = new List<Resource>();

        public LibrarySystem()
        {
            // Add some demo resources to the library
            GetDemoResources();
            // Simulate a long running operation
            Task.Delay(2000).Wait();
        }

        internal Resource? GetResource(int id)
        {
            return Resources.FirstOrDefault(r => r.Id == id);
        }

        internal Resource? GetResource(string name)
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
                return bookable.CreateBooking(name);

            }
            return false;
        }

        public bool CancelBooking(int id)
        {
            var res = Resources.FirstOrDefault(r => r.Id == id);
            if (res is IBookable bookable)
            {
                bookable.CancelBooking();
                return true;
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
