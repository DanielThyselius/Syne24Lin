using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    internal class Book : Resource, IBookable
    {
        public bool CreateBooking(string userName)
        {
            BookedBy = userName;
            IsAvailable = false;
            return true;
        }

        public void CancelBooking()
        {
            BookedBy = null;
            IsAvailable = true;
        }

    }
}
