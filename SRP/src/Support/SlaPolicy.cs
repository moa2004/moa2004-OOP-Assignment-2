namespace SrpLab;

public sealed class SlaPolicy
{
    public DateTimeOffset SlaDeadline(
        SupportTicket ticket)
    {
        var hours = ticket.Priority switch
        {
            "P1" => 4,
            "P2" => 24,
            _ => 72
        };

        return ticket.OpenedAt.AddHours(hours);
    }

    public bool IsBreached(
        SupportTicket ticket,
        DateTimeOffset now)
    {
        return now > SlaDeadline(ticket);
    }
}