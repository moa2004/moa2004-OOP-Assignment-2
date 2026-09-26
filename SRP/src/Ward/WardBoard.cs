namespace SrpLab;

public class WardBoard
{
    private readonly Dictionary<int, string> _bedPatient = new();
    private readonly Dictionary<int, int> _vitalsScore = new();

    private readonly AcuityScorer _acuityScorer;
    private readonly WardPager _wardPager;

    public WardBoard(
        AcuityScorer acuityScorer,
        WardPager wardPager)
    {
        _acuityScorer = acuityScorer;
        _wardPager = wardPager;
    }

    public void AssignBed(
        int bed,
        string patientId,
        int heartRate,
        int spo2)
    {
        if (bed <= 0)
            throw new ArgumentOutOfRangeException(nameof(bed));

        if (string.IsNullOrWhiteSpace(patientId))
            throw new ArgumentException("patient required");

        var patient =
            patientId.Trim().ToUpperInvariant();

        var acuity =
            _acuityScorer.ScoreAcuity(
                heartRate,
                spo2);

        _bedPatient[bed] = patient;
        _vitalsScore[bed] = acuity;

        _wardPager.Evaluate(
            bed,
            acuity);
    }

    public bool TryGetPatient(
        int bed,
        out string patient)
    {
        return _bedPatient.TryGetValue(
            bed,
            out patient!);
    }

    public int GetAcuity(int bed)
    {
        return _vitalsScore[bed];
    }

    public IEnumerable<int> GetBeds()
    {
        return _bedPatient.Keys;
    }
}