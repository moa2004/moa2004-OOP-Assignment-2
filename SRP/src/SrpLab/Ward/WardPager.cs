namespace SrpLab;

public class WardPager
{
    private readonly List<string> _pagerLog = new();

    public void Evaluate(
        int bed,
        int acuity)
    {
        if (acuity >= 8)
        {
            _pagerLog.Add(
                $"CODE-YELLOW bed={bed} " +
                $"at {DateTime.UtcNow:HH:mm}");
        }
    }

    public IReadOnlyList<string> DrainPagerLog()
    {
        var copy = _pagerLog.ToList();

        _pagerLog.Clear();

        return copy;
    }
}