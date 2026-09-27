using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.src
{
    public class Magazine : LibraryItem
    {
        private const int loanDays = 3;
        private const decimal feeMultiplier = 0.5m;
        public Magazine(
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
