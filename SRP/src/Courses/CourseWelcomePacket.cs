namespace OOP_Assignment_2.src.Courses
{
    internal class CourseWelcomePacket
    {
        private readonly CourseEnrollment _enrollment;

        public CourseWelcomePacket(
            CourseEnrollment enrollment)
        {
            _enrollment = enrollment;
        }

        public string WelcomePacketMarkdown(
            string studentEmail,
            string studentName)
        {
            var status = _enrollment.IsSeated(studentEmail)
                ? "confirmed seat"
                : $"waitlist #{_enrollment.WaitlistPosition(studentEmail)}";

            return
                $"# Welcome to {_enrollment.CourseCode}\n" +
                $"Hi {studentName},\n" +
                $"Your status: **{status}**.\n" +
                $"Bring a laptop. Discord onboarding link: " +
                $"https://example.invalid/{_enrollment.CourseCode.ToLowerInvariant()}\n";
        }
    }
}