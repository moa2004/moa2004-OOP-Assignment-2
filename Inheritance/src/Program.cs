using LibrarySystem.src;

namespace Inheritance
{
    class Program
    {
        static void Main()
        {
            StudentMember student = new StudentMember("M001", "Ali Hassan", "01011111111");
            HeadLibrarian head = new HeadLibrarian("S001", "Sara Ahmed", "01022222222", new DateOnly(2020, 1, 1), 10000);
            Librarian librarian = new Librarian("S002", "Ahmed Samir", "01033333333", new DateOnly(2022, 1, 1), 8000);
            Shelver shelver = new Shelver("S003", "Omar Ali", "01044444444", new DateOnly(2023, 1, 1), 6000, "Fiction");
            Console.WriteLine("=== Borrow Withdrawn Item ===");
            Book withdrawnBook = new Book("B001", "Withdrawn Book", 10);
            head.WithdrawItem(withdrawnBook);
            try
            {
                student.Borrow(withdrawnBook, new DateOnly(2026, 9, 1), "L001");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\n=== Item Already On Loan ===");
            Book sharedBook = new Book("B002", "Shared Book", 10);
            StudentMember student2 = new StudentMember("M002", "Omar Adel", "01055555555");
            student.Borrow(sharedBook, new DateOnly(2026, 9, 1), "L002");
            try
            {
                student2.Borrow(sharedBook, new DateOnly(2026, 9, 2), "L003");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\n=== Student 4th Item ===");
            StudentMember limitStudent = new StudentMember("M003", "Mona Ali", "01066666666");
            Book book1 = new Book("B003", "Book 1", 5);
            Book book2 = new Book("B004", "Book 2", 5);
            Book book3 = new Book("B005", "Book 3", 5);
            Book book4 = new Book("B006", "Book 4", 5);
            limitStudent.Borrow(book1, new DateOnly(2026, 9, 1), "L004");
            limitStudent.Borrow(book2, new DateOnly(2026, 9, 1), "L005");
            limitStudent.Borrow(book3, new DateOnly(2026, 9, 1), "L006");
            try
            {
                limitStudent.Borrow(book4, new DateOnly(2026, 9, 1), "L007");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\n=== Staff Monthly Pay ===");
            List<Staff> staffMembers = new List<Staff>();
            staffMembers.Add(librarian);
            staffMembers.Add(head);
            staffMembers.Add(shelver);
            foreach (Staff staffMember in staffMembers)
            {
                Console.WriteLine(staffMember.FullName + " - Monthly Pay: " + staffMember.MonthlyPay);
            }
            Console.WriteLine("\n=== Library Items ===");
            Book book = new Book("B007", "Clean Code", 10);
            DVD dvd = new DVD("D001", "Interstellar", 10);
            Magazine magazine = new Magazine("MG001", "Science Magazine", 10);
            List<LibraryItem> items = new List<LibraryItem>();
            items.Add(book);
            items.Add(dvd);
            items.Add(magazine);
            foreach (LibraryItem item in items)
            {
                Console.WriteLine(item.Title + " - Loan Period: " + item.LoanPeriodDays + " days - Daily Late Fee: " + item.DailyLateFee);
            }
            Console.WriteLine("\n=== Premium Late DVD Return ===");
            PremiumMember premium = new PremiumMember("M004", "Youssef Ahmed", "01077777777", 20);
            DVD lateDvd = new DVD("D002", "The Matrix", 10);
            DateOnly borrowDate = new DateOnly(2026, 9, 1);
            Loan premiumLoan = premium.Borrow(lateDvd, borrowDate, "L008");
            DateOnly returnDate = premiumLoan.DueDate.AddDays(5);
            librarian.ProcessReturn(premiumLoan, returnDate);
            Console.WriteLine("Due Date: " + premiumLoan.DueDate);
            Console.WriteLine("Late Fee: " + premiumLoan.CalculateLateFee());
            Console.WriteLine("Reading Points: " + premium.ReadingPoints);
            Console.WriteLine("\n=== Return Same Loan Twice ===");
            try
            {
                librarian.ProcessReturn(premiumLoan, returnDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n=== Mark Returned Loan As Lost ===");
            try
            {
                librarian.MarkItemLost(premiumLoan);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}