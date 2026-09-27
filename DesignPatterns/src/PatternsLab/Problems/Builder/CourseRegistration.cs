namespace PatternsLab.Problems.Builder;

public sealed class CourseRegistration
{
    public string StudentEmail { get; }
    public string CourseCode { get; }
    public string AccessMode { get; }
    public string? GroupCode { get; }
    public string? DiscountCode { get; }
    public bool SendWhatsApp { get; }
    public bool SendWelcomeEmail { get; }
    public string? MentorNote { get; }
    public DateOnly? PreferredStartDate { get; }

    internal CourseRegistration(
        string studentEmail,
        string courseCode,
        string accessMode,
        string? groupCode,
        string? discountCode,
        bool sendWhatsApp,
        bool sendWelcomeEmail,
        string? mentorNote,
        DateOnly? preferredStartDate)
    {
        if (string.IsNullOrWhiteSpace(studentEmail))
            throw new ArgumentException("Student email is required.");

        if (string.IsNullOrWhiteSpace(courseCode))
            throw new ArgumentException("Course code is required.");

        if (accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(groupCode))
            throw new InvalidOperationException(
                "LiveGroup registration requires a GroupCode.");

        if (accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(groupCode))
            throw new InvalidOperationException(
                "VideosOnly registration cannot have a GroupCode.");

        StudentEmail = studentEmail;
        CourseCode = courseCode;
        AccessMode = accessMode;
        GroupCode = groupCode;
        DiscountCode = discountCode;
        SendWhatsApp = sendWhatsApp;
        SendWelcomeEmail = sendWelcomeEmail;
        MentorNote = mentorNote;
        PreferredStartDate = preferredStartDate;
    }

    public override string ToString()
    {
        return
            $"{StudentEmail} → {CourseCode} [{AccessMode}] " +
            $"group={GroupCode ?? "-"} " +
            $"discount={DiscountCode ?? "-"} " +
            $"whatsapp={SendWhatsApp} " +
            $"email={SendWelcomeEmail}";
    }
}


public sealed class CourseRegistrationBuilder
{
    private readonly string _studentEmail;
    private readonly string _courseCode;
    private readonly string _accessMode;
    private readonly bool _sendWhatsApp;
    private readonly bool _sendWelcomeEmail;

    private string? _groupCode;
    private string? _discountCode;
    private string? _mentorNote;
    private DateOnly? _preferredStartDate;

    public CourseRegistrationBuilder(
        string studentEmail,
        string courseCode,
        string accessMode,
        bool sendWhatsApp,
        bool sendWelcomeEmail)
    {
        _studentEmail = studentEmail;
        _courseCode = courseCode;
        _accessMode = accessMode;
        _sendWhatsApp = sendWhatsApp;
        _sendWelcomeEmail = sendWelcomeEmail;
    }

    public CourseRegistrationBuilder WithGroupCode(string groupCode)
    {
        _groupCode = groupCode;
        return this;
    }

    public CourseRegistrationBuilder WithDiscountCode(string discountCode)
    {
        _discountCode = discountCode;
        return this;
    }

    public CourseRegistrationBuilder WithMentorNote(string mentorNote)
    {
        _mentorNote = mentorNote;
        return this;
    }

    public CourseRegistrationBuilder WithPreferredStartDate(DateOnly preferredStartDate)
    {
        _preferredStartDate = preferredStartDate;
        return this;
    }

    public CourseRegistration Build()
    {
        return new CourseRegistration(
            _studentEmail,
            _courseCode,
            _accessMode,
            _groupCode,
            _discountCode,
            _sendWhatsApp,
            _sendWelcomeEmail,
            _mentorNote,
            _preferredStartDate);
    }
}