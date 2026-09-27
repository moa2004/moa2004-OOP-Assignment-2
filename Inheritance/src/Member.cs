using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.src
{
    public class Member : Person
    {
        private List<Loan> loanHistory = new List<Loan>();

        public IReadOnlyList<Loan> LoanHistory
        {
            get { return loanHistory.AsReadOnly(); }
        }

        public int MaxConcurrentLoans { get; }
        public decimal LateFeeDiscountPercent { get; }

        public int CurrentActiveLoans
        {
            get
            {
                int count = 0;

                foreach (Loan loan in loanHistory)
                {
                    if (loan.Status != LoanStatus.Returned)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        protected Member(
            string personID,
            string fullName,
            string phoneNumber,
            int maxLoans,
            decimal discountPercent)
            : base(personID, fullName, phoneNumber)
        {
            if (maxLoans <= 0)
            {
                throw new ArgumentException("Maximum loans must be greater than zero.");
            }

            if (discountPercent < 0 || discountPercent > 100)
            {
                throw new ArgumentException("Discount percent must be between 0 and 100.");
            }

            MaxConcurrentLoans = maxLoans;
            LateFeeDiscountPercent = discountPercent;
        }

        public Loan Borrow(LibraryItem item, DateOnly borrowDate, string loanID)
        {
            if (item == null)
            {
                throw new ArgumentException("Item cannot be null.");
            }

            if (item.IsWithdrawn)
            {
                throw new InvalidOperationException("A withdrawn item cannot be borrowed.");
            }

            if (item.IsOnLoan)
            {
                throw new InvalidOperationException("This item is already on loan.");
            }

            if (CurrentActiveLoans >= MaxConcurrentLoans)
            {
                throw new InvalidOperationException("The member has reached the loan limit.");
            }
            Loan loan = new Loan(loanID, this, item, borrowDate);
            item.MarkBorrowed();
            loanHistory.Add(loan);

            return loan;
        }
    }
}
