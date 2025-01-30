using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    internal class Book : Resource, IBookable
    {
        public int MaxLendDays { get; } = 21;
        public int LateFee { get; } = 10;
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

        public int GetLateFee(int days)
        {
            if (days < MaxLendDays)
                return 0;

            var lateDays = days - MaxLendDays;

            return Math.Min(lateDays * LateFee, 300);
        }
    }
}
