namespace OOP_Assignment_2.src.Loans
{
    public class UnderwriterCsvExporter
    {
        private readonly LoanAssessment _loan;

        public UnderwriterCsvExporter(LoanAssessment loan)
        {
            _loan = loan;
        }

        public string UnderwriterCsvRow(
            string applicationId)
        {
            return
                $"{applicationId}," +
                $"{_loan.CreditScore}," +
                $"{_loan.EmploymentMonths}," +
                $"{(_loan.HasCollateral ? 1 : 0)}," +
                $"{_loan.RiskScore():0.00}," +
                $"{(_loan.IsEligible() ? "Y" : "N")}";
        }
    }
}