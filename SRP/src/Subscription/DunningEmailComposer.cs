namespace SrpLab;

public sealed class DunningEmailComposer
{
    private readonly SubscriptionBilling _billing;
    private readonly InvoiceNumberGenerator _invoiceNumbers;
    private readonly PaymentCollection _payments;

    public DunningEmailComposer(
        SubscriptionBilling billing,
        InvoiceNumberGenerator invoiceNumbers,
        PaymentCollection payments)
    {
        _billing = billing;
        _invoiceNumbers = invoiceNumbers;
        _payments = payments;
    }

    public string DunningEmail(
        string customerName,
        DateOnly asOf)
    {
        var amount =
            _billing.Prorate(_billing.PeriodStart);

        var invoice =
            _invoiceNumbers.NextInvoiceNumber(
                _billing.PeriodStart);

        var severity = _payments.FailedPayments switch
        {
            <= 1 => "friendly reminder",
            2 => "second notice",
            _ => "final notice before suspension"
        };

        return
            $"Subject: {severity} {invoice}\n" +
            $"Hi {customerName},\n" +
            $"Balance {amount:C} as of {asOf:o} " +
            $"({_payments.FailedPayments} failures).\n";
    }
}