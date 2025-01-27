using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    internal class Computer : Resource, IBookable
    {
        public bool Book(string userName)
        {
            throw new NotImplementedException();
        }

        public void CancelBooking()
        {
            throw new NotImplementedException();
        }

        public bool CheckAvailability()
        {
            throw new NotImplementedException();
        }
    }
}
