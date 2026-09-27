using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.src
{
    public class Staff : Person
    {
        private readonly decimal responsibilityAllowance;
        public DateOnly HireDate { get; }
        public decimal MonthlySalary { get; private set; }
        public decimal MonthlyPay
        {
            get { return MonthlySalary + responsibilityAllowance; }
        }
        protected Staff(
            string personID,
            string fullName,
            string phoneNumber,
            DateOnly hireDate,
            decimal monthlySalary,
            decimal allowance)
            : base(personID, fullName, phoneNumber)
        {
            if (monthlySalary < 0)
            {
                throw new ArgumentException("Monthly salary cannot be negative.");
            }

            HireDate = hireDate;
            MonthlySalary = monthlySalary;
            responsibilityAllowance = allowance;
        }
        public void GiveRaise(decimal percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException("Raise percent must be greater than zero.");
            }

            MonthlySalary = MonthlySalary + (MonthlySalary * percent / 100m);
        }
    }
}
