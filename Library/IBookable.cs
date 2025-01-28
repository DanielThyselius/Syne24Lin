using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal interface IBookable
    {
        bool CreateBooking(string userName);
        void CancelBooking();
    }
}
