using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.src
{
    public class Shelver : Staff
    {
        public string Section { get; private set; }
        public Shelver(
            string personID,
            string fullName,
            string phoneNumber,
            DateOnly hireDate,
            decimal monthlySalary,
            string section)
            : base(
                personID,
                fullName,
                phoneNumber,
                hireDate,
                monthlySalary,
                0m)
        {
            Section = section;
        }
        public void Reassign(string newSection)
        {
            if (newSection == null || newSection == "")
            {
                throw new ArgumentException("Section cannot be empty.");
            }

            Section = newSection;
        }
    }
}
