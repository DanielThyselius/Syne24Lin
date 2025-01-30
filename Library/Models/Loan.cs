using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    class Loan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IBookable Resource { get; set; }
        public DateOnly LoanDate { get; set; }
        public DateOnly? ReturnDate { get; set; }

        // TODO: testa status
        public LoanStatus Status
        {
            get
            {
                // Implement
                return LoanStatus.Rented;
            }
        }


        // Skapa ett lån
        public Loan(IBookable resource, string name, DateOnly date)
        {
            Resource = resource;
            Name = name;
            LoanDate = date;
        }

        // Avsluta ett lån
        public int ReturnLoan(DateOnly returnDate)
        {
            // TODO: should we calculate fee here? 
            // Should we run Resource.CancelBooking()?
            // How do we test for that?
            ReturnDate = returnDate;

            return Resource.GetLateFee(0);
        }

        public enum LoanStatus
        {
            Rented,
            Overdue,
            Returned
        }
    }
}
