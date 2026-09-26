namespace OOP_Assignment_2.src.Loans
{
    public class LoanDecisionLetter
    {
        private readonly LoanAssessment _loan;
        private readonly LoanDocumentRequirements _documents;

        public LoanDecisionLetter(
            LoanAssessment loan,
            LoanDocumentRequirements documents)
        {
            _loan = loan;
            _documents = documents;
        }

        public string DecisionLetter(string applicantName)
        {
            if (_loan.IsEligible())
            {
                return
                    $"Dear {applicantName},\n" +
                    $"Your request for {_loan.RequestedAmount:C} " +
                    $"is pre-approved (risk {_loan.RiskScore():0}).\n" +
                    $"Please upload: " +
                    $"{string.Join("; ", _documents.RequiredDocuments())}.\n";
            }

            return
                $"Dear {applicantName},\n" +
                $"We are unable to approve " +
                $"{_loan.RequestedAmount:C} at this time.\n" +
                $"Reference risk={_loan.RiskScore():0}. " +
                $"You may reapply after improving documentation.\n";
        }
    }
}