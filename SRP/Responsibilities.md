# Responsibilities

## 1. AppointmentDesk
**Responsibilities found:**
- Checking clinic business hours and slot rules.
- Searching for the next available appointment slot.
- Booking a slot and keeping track of booked appointments.
- Generating an ICS calendar event.
- Creating SMS reminder text.

**Why this is a problem:**  
These responsibilities can change for different reasons. Clinic working-hour or booking rules may change without any change to the calendar format or reminder message. Keeping all of them in one class means a change in scheduling, calendar export, or messaging requires changing the same class.

## 2. CheckoutBasket
**Responsibilities found:**
- Storing basket items and calculating the subtotal.
- Reading coupon text and calculating discounts.
- Applying the gift-wrap fee.
- Creating the gift message card.
- Producing a payment authorization code.

**Why this is a problem:**  
Basket calculations, marketing coupon rules, gift-message wording, and payment authorization are separate concerns. For example, a new coupon rule or payment system should not require changing the class that manages basket totals.

## 3. CourseEnrollmentDesk
**Responsibilities found:**
- Registering students and managing course capacity.
- Managing the waitlist and student positions.
- Promoting students from the waitlist.
- Generating the welcome packet.
- Creating tuition invoice information and VAT calculations.

**Why this is a problem:**  
Enrollment rules can change independently from marketing content and finance rules. A change to the welcome message or invoice format should not affect the code responsible for seats and the waitlist.

## 4. GradeBook
**Responsibilities found:**
- Recording student scores and calculating averages.
- Converting averages into letter grades.
- Checking honor-roll eligibility.
- Generating a transcript.
- Exporting grade information as CSV.

**Why this is a problem:**  
Score calculations, academic grading policies, honor-roll rules, and document/export formats have different reasons to change. Putting them together makes changes to academic policy or reporting affect the same class.

## 5. KitchenTicket
**Responsibilities found:**
- Storing ordered kitchen items and their ingredients.
- Detecting allergens.
- Estimating preparation time.
- Deciding the expo lane.
- Formatting a thermal-printer ticket.

**Why this is a problem:**  
Allergen rules, kitchen timing rules, routing rules, and printer formatting can all change independently. A new printer layout, for example, should not require modifying the same class that contains food-safety rules.

## 6. LoanDesk
**Responsibilities found:**
- Calculating the applicant's risk score.
- Deciding loan eligibility.
- Determining required documents.
- Writing the applicant decision letter.
- Exporting underwriting information as a CSV row.

**Why this is a problem:**  
Risk rules, compliance document requirements, customer communication, and analytics/export formats are controlled by different concerns. Changing a letter template should not risk affecting the loan eligibility logic.

## 7. SubscriptionBilling
**Responsibilities found:**
- Calculating prorated subscription charges.
- Generating invoice numbers.
- Tracking failed payments.
- Creating dunning/collection emails.
- Generating accounting ledger data.

**Why this is a problem:**  
Pricing rules, invoice-number rules, collection communication, and accounting exports change independently. Combining them gives the class several unrelated reasons to change and also mixes side effects such as generating invoice numbers with email creation.

## 8. SupportTicket
**Responsibilities found:**
- Storing and updating ticket/customer-message information.
- Determining priority from keywords in the ticket text.
- Calculating SLA deadlines and checking SLA breaches.
- Creating public reply text.
- Creating internal escalation information.

**Why this is a problem:**  
Priority-detection rules, SLA policy, customer-facing wording, and internal escalation formatting can evolve separately. Keeping them in one class couples support policy with communication and presentation logic.

## 9. WardBoard
**Responsibilities found:**
- Assigning patients to beds and tracking ward state.
- Calculating patient acuity from vital signs.
- Deciding when a pager alert should be created.
- Building nurse handoff notes.
- Managing the pager log.
- Exporting the ward census as CSV.

**Why this is a problem:**  
Bed management, clinical scoring, paging policy, handoff presentation, and export formatting have different reasons to change. A change in the CSV format or handoff wording should not require touching clinical scoring code.

## 10. WarehousePickList
**Responsibilities found:**
- Storing requested warehouse items.
- Allocating available stock to requested quantities.
- Calculating the warehouse walking/picking order.
- Producing instructions and shortage warnings for the picker.
- Creating an XML batch for the WMS.

**Why this is a problem:**  
Stock-allocation rules, route planning, picker UX, and the external WMS integration can change independently. Keeping them together makes the class depend on several unrelated business and integration concerns.

## Summary
Each class currently has more than one reason to change. This goes against the Single Responsibility Principle (SRP). The goal of the refactoring should be to separate responsibilities that change for different reasons, while keeping related behavior together.
