namespace OOP_Assignment_2.src.Grades
{
    public class GradeReportExporter
    {
        private readonly GradeBook _gradeBook;
        private readonly GradingPolicy _gradingPolicy;

        public GradeReportExporter(
            GradeBook gradeBook,
            GradingPolicy gradingPolicy)
        {
            _gradeBook = gradeBook;
            _gradingPolicy = gradingPolicy;
        }

        public string TranscriptPlain(
            string studentId,
            string fullName)
        {
            return
                $"TRANSCRIPT\n" +
                $"Student: {fullName} ({studentId})\n" +
                $"Average: {_gradeBook.Average(studentId)}\n" +
                $"Letter: {_gradingPolicy.Letter(studentId)}\n" +
                $"Honor: {_gradingPolicy.MeetsHonorRoll(studentId)}\n";
        }

        public string ExportCsv()
        {
            var rows = new List<string>
            {
                "studentId,average,letter,honor"
            };

            foreach (var id in _gradeBook.StudentIds().OrderBy(x => x))
            {
                rows.Add(
                    $"{id}," +
                    $"{_gradeBook.Average(id)}," +
                    $"{_gradingPolicy.Letter(id)}," +
                    $"{(_gradingPolicy.MeetsHonorRoll(id) ? 1 : 0)}");
            }

            return string.Join('\n', rows);
        }
    }
}