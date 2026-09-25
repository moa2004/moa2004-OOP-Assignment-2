namespace SrpLab;

public sealed class PaymentCollection
{
    public int FailedPayments { get; private set; }

    public void RegisterFailedPayment()
    {
        FailedPayments++;
    }
}