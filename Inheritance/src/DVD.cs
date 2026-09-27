using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.src
{
    public class DVD : LibraryItem
    {
        private const int loanDays = 7;
        private const decimal feeMultiplier = 2m;
        public DVD(string catalogNumber,string title,decimal baseLateFeePerDay):base(catalogNumber,title,baseLateFeePerDay,loanDays,feeMultiplier)
        {
        }
    }
}
