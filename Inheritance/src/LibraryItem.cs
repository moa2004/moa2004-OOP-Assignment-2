using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.src
{
    public class LibraryItem
    {
        private readonly decimal lateFeeMultiplier;
        public string CatalogNumber { get; }
        public string Title { get; }
        public decimal BaseLateFeePerDay { get; private set; }
        public bool IsWithdrawn { get; private set; }
        public bool IsOnLoan { get; private set; }
        public int LoanPeriodDays { get; }
        public decimal DailyLateFee
        {
            get { return BaseLateFeePerDay * lateFeeMultiplier; }
        }
        protected LibraryItem(
            string catalogNumber,
            string title,
            decimal baseLateFeePerDay,
            int loanPeriodDays,
            decimal feeMultiplier)
        {
            if (baseLateFeePerDay < 0)
            {
                throw new ArgumentException("Base late fee cannot be negative.");
            }
            CatalogNumber = catalogNumber;
            Title = title;
            BaseLateFeePerDay = baseLateFeePerDay;
            LoanPeriodDays = loanPeriodDays;
            lateFeeMultiplier = feeMultiplier;
            IsWithdrawn = false;
            IsOnLoan = false;
        }
        internal void ChangePricing(decimal newBaseFee)
        {
            if (newBaseFee < 0)
            {
                throw new ArgumentException("Base late fee cannot be negative.");
            }
            BaseLateFeePerDay = newBaseFee;
        }
        internal void Withdraw()
        {
            IsWithdrawn = true;
        }
        internal void Restore()
        {
            IsWithdrawn = false;
        }
        internal void MarkBorrowed()
        {
            if (IsWithdrawn)
            {
                throw new InvalidOperationException("A withdrawn item cannot be borrowed.");
            }
            if (IsOnLoan)
            {
                throw new InvalidOperationException("This item is already on loan.");
            }
            IsOnLoan = true;
        }
         internal void MarkReturned()
        {
            if (!IsOnLoan)
            {
                throw new InvalidOperationException("This item is not currently on loan.");
            }

            IsOnLoan = false;
        }
    }
}
