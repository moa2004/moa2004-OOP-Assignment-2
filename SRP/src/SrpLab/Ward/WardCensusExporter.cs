namespace SrpLab;

public class WardCensusExporter
{
    public string ExportCensusCsv(
        WardBoard ward)
    {
        var lines =
            new List<string>
            {
                "bed,patient,acuity"
            };

        foreach (var bed in
                 ward.GetBeds().OrderBy(x => x))
        {
            ward.TryGetPatient(
                bed,
                out var patient);

            lines.Add(
                $"{bed}," +
                $"{patient}," +
                $"{ward.GetAcuity(bed)}");
        }

        return string.Join(
            '\n',
            lines);
    }
}