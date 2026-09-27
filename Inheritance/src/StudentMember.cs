using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.src
{
    public class StudentMember : Member
    {
        private const int studentLoanLimit = 3;
        private const decimal studentDiscount = 0m;
        public StudentMember(
            string personID,
            string fullName,
            string phoneNumber)
            : base(
                personID,
                fullName,
                phoneNumber,
                studentLoanLimit,
                studentDiscount)
        {
        }
    }
}
