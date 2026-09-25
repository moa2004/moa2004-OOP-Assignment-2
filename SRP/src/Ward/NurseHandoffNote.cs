namespace SrpLab;

public sealed class NurseHandoffNote
{
    public string BuildHandoffNote(
        WardBoard ward,
        int bed)
    {
        if (!ward.TryGetPatient(
                bed,
                out var patient))
        {
            return $"Bed {bed}: empty";
        }

        var acuity =
            ward.GetAcuity(bed);

        var tone =
            acuity >= 8
                ? "ESCALATE"
                : acuity >= 4
                    ? "WATCH"
                    : "STABLE";

        return
            $"[HANDOFF {DateTime.UtcNow:yyyy-MM-dd}] " +
            $"Bed {bed} · {patient} · " +
            $"acuity={acuity} · {tone}";
    }
}