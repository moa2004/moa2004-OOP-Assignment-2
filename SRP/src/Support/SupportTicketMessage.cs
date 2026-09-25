namespace SrpLab;

public sealed class SupportTicketMessage
{
    private readonly SlaPolicy _slaPolicy;

    public SupportTicketMessage(
        SlaPolicy slaPolicy)
    {
        _slaPolicy = slaPolicy;
    }

    public string DraftPublicReply(
        SupportTicket ticket,
        string agentName)
    {
        var apology =
            ticket.Priority == "P1"
                ? "We are treating this as a critical incident."
                : "Thanks for reaching out.";

        return
            $"Hi,\n" +
            $"{apology}\n" +
            $"Ticket {ticket.Id} is with {agentName}. " +
            $"Next update before " +
            $"{_slaPolicy.SlaDeadline(ticket):u}.\n";
    }

    public string InternalEscalationBlurb(
        SupportTicket ticket)
    {
        return
            $"ESCALATE {ticket.Id} " +
            $"priority={ticket.Priority} " +
            $"breachAt={_slaPolicy.SlaDeadline(ticket):u} " +
            $"keywords-scanned=yes";
    }
}