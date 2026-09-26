namespace OOP_Assignment_2.src.Grades
{
    public class GradingPolicy
    {
        private readonly GradeBook _gradeBook;

        public GradingPolicy(GradeBook gradeBook)
        {
            _gradeBook = gradeBook;
        }

        public string Letter(string studentId)
        {
            var avg = _gradeBook.Average(studentId);

            if (avg >= 90) return "A";
            if (avg >= 80) return "B";
            if (avg >= 70) return "C";
            if (avg >= 60) return "D";

            return "F";
        }

        public bool MeetsHonorRoll(string studentId)
        {
            return _gradeBook.Average(studentId) >= 85
                && Letter(studentId) is "A" or "B";
        }
    }
}