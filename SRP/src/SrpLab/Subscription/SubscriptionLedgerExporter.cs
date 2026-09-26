namespace SrpLab;

public class SubscriptionLedgerExporter
{
    private readonly SubscriptionBilling _billing;
    private readonly InvoiceNumberGenerator _invoiceNumbers;

    public SubscriptionLedgerExporter(
        SubscriptionBilling billing,
        InvoiceNumberGenerator invoiceNumbers)
    {
        _billing = billing;
        _invoiceNumbers = invoiceNumbers;
    }

    public string LedgerJournalLine(
        DateOnly activeFrom)
    {
        var invoice =
            _invoiceNumbers.NextInvoiceNumber(
                _billing.PeriodStart);

        var amount =
            _billing.Prorate(activeFrom);

        return
            $"{_billing.CustomerId}," +
            $"{invoice}," +
            $"{amount:0.00}," +
            $"AR-SUB";
    }
}