namespace OOP_Assignment_2.src.Courses
{
    internal class TuitionInvoice
    {
        private readonly CourseEnrollment _enrollment;

        public TuitionInvoice(
            CourseEnrollment enrollment)
        {
            _enrollment = enrollment;
        }

        public string TuitionInvoiceLine(
            string studentEmail)
        {
            if (!_enrollment.IsSeated(studentEmail))
            {
                return
                    $"{_enrollment.CourseCode},WAITLIST,0.00";
            }

            var vat =
                Math.Round(_enrollment.Tuition * 0.14m, 2);

            return
                $"{_enrollment.CourseCode}," +
                $"TUITION," +
                $"{_enrollment.Tuition:0.00}," +
                $"VAT,{vat:0.00}," +
                $"TOTAL,{(_enrollment.Tuition + vat):0.00}";
        }
    }
}