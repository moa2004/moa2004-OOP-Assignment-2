using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.src
{
    public class Loan
    {
        public string LoanID { get; }
        public DateOnly BorrowDate { get; }
        public DateOnly DueDate { get; }
        public DateOnly? ReturnDate { get; private set; }
        public LoanStatus Status { get; private set; }
        public Member Member { get; }
        public LibraryItem Item { get; }
        internal Loan(
            string loanID,
            Member member,
            LibraryItem item,
            DateOnly borrowDate)
        {
            LoanID = loanID;
            Member = member;
            Item = item;
            BorrowDate = borrowDate;
            DueDate = borrowDate.AddDays(item.LoanPeriodDays);
            ReturnDate = null;
            Status = LoanStatus.Borrowed;
        }
        internal void MarkReturned(DateOnly returnDate)
        {
            if (Status == LoanStatus.Returned)
            {
                throw new InvalidOperationException("This loan has already been returned.");
            }
            if (returnDate < BorrowDate)
            {
                throw new ArgumentException("Return date cannot be before borrow date.");
            }
            ReturnDate = returnDate;
            Status = LoanStatus.Returned;
            Item.MarkReturned();
        }
        internal void MarkLost()
        {
            if (Status == LoanStatus.Returned)
            {
                throw new InvalidOperationException("A returned loan cannot be marked as lost.");
            }
            if (Status == LoanStatus.Lost)
            {
                throw new InvalidOperationException("This loan is already marked as lost.");
            }
            Status = LoanStatus.Lost;
        }
        public decimal CalculateLateFee()
        {
            if (Status != LoanStatus.Returned || ReturnDate == null)
            {
                throw new InvalidOperationException("Late fee can be calculated after the item is returned.");
            }
            if (ReturnDate.Value <= DueDate)
            {
                return 0m;
            }
            int lateDays = ReturnDate.Value.DayNumber - DueDate.DayNumber;
            decimal feeBeforeDiscount = lateDays * Item.DailyLateFee;
            decimal discountAmount =
                feeBeforeDiscount * Member.LateFeeDiscountPercent / 100m;
            return feeBeforeDiscount - discountAmount;
        }
    }
    public enum LoanStatus
    {
        Borrowed,
        Returned,
        Lost
    }
}
