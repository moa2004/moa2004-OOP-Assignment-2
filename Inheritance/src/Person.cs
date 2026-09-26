using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.src
{
    public class Person
    {
        public string PersonID { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }
        protected Person(string personID, string fullName, string phoneNumber)
        {
            PersonID = personID;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }
    }
}
