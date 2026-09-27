using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.src
{
    public class Librarian : Staff
    {
        public Librarian(
            string personID,
            string fullName,
            string phoneNumber,
            DateOnly hireDate,
            decimal monthlySalary)
            : base(
                personID,
                fullName,
                phoneNumber,
                hireDate,
                monthlySalary,
                0m)
        {
        }
        public void ProcessReturn(Loan loan, DateOnly returnDate)
        {
            if (loan == null)
            {
                throw new ArgumentException("Loan cannot be null.");
            }
            loan.MarkReturned(returnDate);
        }
        public void MarkItemLost(Loan loan)
        {
            if (loan == null)
            {
                throw new ArgumentException("Loan cannot be null.");
            }

            loan.MarkLost();
        }
    }
}
