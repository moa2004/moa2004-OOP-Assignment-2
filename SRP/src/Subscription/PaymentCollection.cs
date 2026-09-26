namespace SrpLab;

public class PaymentCollection
{
    public int FailedPayments { get; private set; }

    public void RegisterFailedPayment()
    {
        FailedPayments++;
    }
}