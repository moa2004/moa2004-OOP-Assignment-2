using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.src
{
    public class Book : LibraryItem
    {
        private const int loanDays = 21;
        private const decimal feeMultiplier = 1m;
        public Book(
            string catalogNumber,
            string title,
            decimal baseLateFeePerDay)
            : base(
                catalogNumber,
                title,
                baseLateFeePerDay,
                loanDays,
                feeMultiplier)
        {
        }
    }
}
