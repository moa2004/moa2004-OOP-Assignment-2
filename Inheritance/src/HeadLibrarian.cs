using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.src
{
    public class HeadLibrarian : Staff
    {
        private const decimal headAllowance = 400m;
        public HeadLibrarian(
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
                headAllowance)
        {
        }
        public void ChangeLateFeePrice(LibraryItem item, decimal newBaseFee)
        {
            if (item == null)
            {
                throw new ArgumentException("Item cannot be null.");
            }
            item.ChangePricing(newBaseFee);
        }
        public void WithdrawItem(LibraryItem item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item cannot be null.");
            }
            item.Withdraw();
        }
        public void RestoreItem(LibraryItem item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item cannot be null.");
            }

            item.Restore();
        }
    }
}
