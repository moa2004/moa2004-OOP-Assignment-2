using OOP_Assignment_2.src.Appointments;
using OOP_Assignment_2.src.Checkout;
using OOP_Assignment_2.src.Courses;
using OOP_Assignment_2.src.Grades;
using OOP_Assignment_2.src.Kitchen;
using OOP_Assignment_2.src.Loans;
using SrpLab;

Console.WriteLine("======================================");
Console.WriteLine("        SRP REFACTORING RUNNER");
Console.WriteLine("======================================");

TestAppointments();
TestCheckout();
TestCourses();
TestGrades();
TestKitchen();
TestLoans();
TestSubscription();
TestSupport();
TestWard();
TestWarehouse();

Console.WriteLine();
Console.WriteLine("======================================");
Console.WriteLine("         ALL TESTS COMPLETED");
Console.WriteLine("======================================");


static void TestAppointments()
{
    Console.WriteLine("\n--- Appointments ---");

    var schedule = new AppointmentSchedule(
        new HashSet<DateTimeOffset>(),
        new TimeOnly(9, 0),
        new TimeOnly(17, 0),
        30);

    var booking = new AppointmentBooking(schedule);

    var slot = new DateTimeOffset(
        2026, 9, 26,
        10, 0, 0,
        TimeSpan.FromHours(3));

    Console.WriteLine(
        $"Book {slot}: {booking.TryBook(slot)}");

    Console.WriteLine(
        $"Book same slot again: {booking.TryBook(slot)}");

    var exporter =
        new AppointmentCalendarExporter(schedule);

    Console.WriteLine(exporter.ToIcs(slot, "Ahmed", "Dr. Smith"));
}


static void TestCheckout()
{
    Console.WriteLine("\n--- Checkout ---");

    var basket = new CheckoutBasket();

    basket.AddLine("LAPTOP", 25000m, 1);
    basket.AddLine("MOUSE", 1000m, 2);

    Console.WriteLine(
        $"Subtotal: {basket.SubTotal():0.00}");

    var coupon = new CouponDiscount(basket);

    coupon.ApplyCouponText("SAVE10");

    var payment = new PaymentAuthorization(basket, coupon);

    Console.WriteLine($"Total = {payment.GrandTotal()}");

    var gift = new GiftService(payment);

    Console.WriteLine(gift.GiftMessageCard("Moamen"));
}


static void TestCourses()
{
    Console.WriteLine("\n--- Courses ---");

    var enrollment =
        new CourseEnrollment(
            "CS101",
            2,
            5000m);

    Console.WriteLine(
        enrollment.Register("ali@example.com"));

    Console.WriteLine(
        enrollment.Register("omar@example.com"));

    Console.WriteLine(
        enrollment.Register("mohamed@example.com"));

    Console.WriteLine(
        $"Waitlist position: " +
        $"{enrollment.WaitlistPosition(
            "mohamed@example.com")}");

    var welcome =
        new CourseWelcomePacket(enrollment);

    Console.WriteLine(
        welcome.WelcomePacketMarkdown(
            "ali@example.com",
            "Ali"));

    var invoice =
        new TuitionInvoice(enrollment);

    Console.WriteLine(
        invoice.TuitionInvoiceLine(
            "ali@example.com"));
}


static void TestGrades()
{
    Console.WriteLine("\n--- Grades ---");

    var gradeBook = new GradeBook();

    gradeBook.Record("ST001", 90);
    gradeBook.Record("ST001", 85);
    gradeBook.Record("ST002", 70);

    var policy =
        new GradingPolicy(gradeBook);

    Console.WriteLine(
        $"ST001 Average: {gradeBook.Average("ST001")}");

    Console.WriteLine(
        $"ST001 Letter: {policy.Letter("ST001")}");

    Console.WriteLine(
        $"ST001 Honor Roll: " +
        $"{policy.MeetsHonorRoll("ST001")}");

    var report =
        new GradeReportExporter(
            gradeBook,
            policy);

    Console.WriteLine(
        report.TranscriptPlain(
            "ST001",
            "Ahmed"));

    Console.WriteLine(
        report.ExportCsv());
}


static void TestKitchen()
{
    Console.WriteLine("\n--- Kitchen ---");

    var order = new KitchenOrder();

    order.AddItem(
        "Burger",
        new[] { "beef", "cheese", "bread" },
        15);

    order.AddItem(
        "Fries",
        new[] { "potato", "oil" },
        8);

    var allergens =
        new AllergenDetector();

    Console.WriteLine(
        "Allergens: " +
        string.Join(
            ", ",
            allergens.DetectAllergens(order)));

    var estimator =
        new KitchenReadyTimeEstimator(allergens);

    Console.WriteLine(
        $"Ready in: " +
        $"{estimator.EstimatedReadyMinutes(order, 2)} minutes");

    var printer =
        new KitchenTicketPrinter(
            allergens,
            estimator);

    Console.WriteLine(
        printer.RenderThermalTicket(
            order,
            1001));

    var lane =
        new ExpoLaneSelector(
            allergens,
            estimator);

    Console.WriteLine(
        $"Expo Lane: {lane.ExpoLaneHint(order)}");
}


static void TestLoans()
{
    Console.WriteLine("\n--- Loans ---");

    var assessment =
        new LoanAssessment(
            50000m,
            720,
            24,
            true);

    Console.WriteLine(
        $"Risk Score: {assessment.RiskScore():0.00}");

    Console.WriteLine(
        $"Eligible: {assessment.IsEligible()}");

    var documents =
        new LoanDocumentRequirements(
            assessment);

    Console.WriteLine(
        "Documents: " +
        string.Join(
            ", ",
            documents.RequiredDocuments()));

    var letter =
        new LoanDecisionLetter(
            assessment,
            documents);

    Console.WriteLine(
        letter.DecisionLetter("Ahmed"));

    var csv =
        new UnderwriterCsvExporter(
            assessment);

    Console.WriteLine(
        csv.UnderwriterCsvRow("APP-001"));
}


static void TestSubscription()
{
    Console.WriteLine("\n--- Subscription ---");

    var billing =
        new SubscriptionBilling(
            "CUS-001",
            1000m,
            new DateOnly(2026, 9, 1),
            new DateOnly(2026, 10, 1));

    Console.WriteLine(
        $"Prorated amount: " +
        $"{billing.Prorate(
            new DateOnly(2026, 9, 10)):0.00}");

    var invoiceNumbers =
        new InvoiceNumberGenerator();

    var payments =
        new PaymentCollection();

    payments.RegisterFailedPayment();
    payments.RegisterFailedPayment();

    var dunning =
        new DunningEmailComposer(
            billing,
            invoiceNumbers,
            payments);

    Console.WriteLine(
        dunning.DunningEmail(
            "Ahmed",
            new DateOnly(2026, 9, 26)));

    var ledger =
        new SubscriptionLedgerExporter(
            billing,
            invoiceNumbers);

    Console.WriteLine(
        ledger.LedgerJournalLine(
            new DateOnly(2026, 9, 10)));
}


static void TestSupport()
{
    Console.WriteLine("\n--- Support ---");

    var ticket =
        new SupportTicket(
            "T-1001",
            "Website is down",
            "Users cannot login",
            DateTimeOffset.UtcNow);

    var classifier =
        new TicketPriorityClassifier();

    classifier.Recalculate(ticket);

    Console.WriteLine(
        $"Priority: {ticket.Priority}");

    var sla =
        new SlaPolicy();

    Console.WriteLine(
        $"SLA Deadline: " +
        $"{sla.SlaDeadline(ticket):u}");

    Console.WriteLine(
        $"Breached: " +
        $"{sla.IsBreached(
            ticket,
            DateTimeOffset.UtcNow)}");

    var messages =
        new SupportTicketMessage(sla);

    Console.WriteLine(
        messages.DraftPublicReply(
            ticket,
            "Support Agent"));

    Console.WriteLine(
        messages.InternalEscalationBlurb(ticket));
}


static void TestWard()
{
    Console.WriteLine("\n--- Ward ---");

    var acuity =
        new AcuityScorer();

    var pager =
        new WardPager();

    var ward =
        new WardBoard(
            acuity,
            pager);

    ward.AssignBed(
        101,
        "PAT-001",
        130,
        88);

    Console.WriteLine(
        $"Patient in bed 101: " +
        $"{ward.TryGetPatient(
            101,
            out var patient)} -> {patient}");

    Console.WriteLine(
        $"Acuity: {ward.GetAcuity(101)}");

    var handoff =
        new NurseHandoffNote();

    Console.WriteLine(
        handoff.BuildHandoffNote(
            ward,
            101));

    var census =
        new WardCensusExporter();

    Console.WriteLine(
        census.ExportCensusCsv(ward));

    Console.WriteLine(
        "Pager:");

    foreach (var message in pager.DrainPagerLog())
    {
        Console.WriteLine(message);
    }
}


static void TestWarehouse()
{
    Console.WriteLine("\n--- Warehouse ---");

    var pickList =
        new WarehousePickList();

    pickList.AddNeed(
        "SKU-001",
        "A",
        10,
        5,
        10);

    pickList.AddNeed(
        "SKU-002",
        "B",
        5,
        8,
        3);

    var allocator =
        new StockAllocator();

    var allocations =
        allocator.Allocate(pickList);

    foreach (var allocation in allocations)
    {
        Console.WriteLine(
            $"{allocation.Sku}: " +
            $"{allocation.Allocated}");
    }

    var route =
        new WarehouseWalkingRoute();

    var instruction =
        new PickerInstruction(
            route,
            allocator);

    Console.WriteLine(
        instruction.PickerScript(
            pickList));

    var wms =
        new WmsXmlExporter(
            allocator);

    Console.WriteLine(
        wms.WmsXmlBatch(
            pickList,
            "BATCH-001"));
}