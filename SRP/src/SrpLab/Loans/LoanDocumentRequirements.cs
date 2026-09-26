namespace OOP_Assignment_2.src.Loans
{
    public class LoanDocumentRequirements
    {
        private readonly LoanAssessment _loan;

        public LoanDocumentRequirements(LoanAssessment loan)
        {
            _loan = loan;
        }

        public IReadOnlyList<string> RequiredDocuments()
        {
            var docs = new List<string>
            {
                "National ID",
                "Proof of income (3 months)"
            };

            if (_loan.RequestedAmount > 40_000m)
                docs.Add("Bank statements (6 months)");

            if (_loan.HasCollateral)
                docs.Add("Collateral ownership deed");

            if (_loan.EmploymentMonths < 12)
                docs.Add("Employer letter");

            if (!_loan.IsEligible())
                docs.Add("Manual underwriter referral form");

            return docs;
        }
    }
}