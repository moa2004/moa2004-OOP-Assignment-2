using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.src
{
    public class PremiumMember : Member
    {
        private const int premiumLoanLimit = 10;
        public int ReadingPoints
        {
            get
            {
                int returnedLoans = 0;
                foreach (Loan loan in LoanHistory)
                {
                    if (loan.Status == LoanStatus.Returned)
                    {
                        returnedLoans++;
                    }
                }
                return returnedLoans * 5;
            }
        }
        public PremiumMember(
            string personID,
            string fullName,
            string phoneNumber,
            decimal discountPercent)
            : base(
                personID,
                fullName,
                phoneNumber,
                premiumLoanLimit,
                discountPercent)
        {
        }
    }
}
