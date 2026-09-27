# OOP Assignment 2

This repository contains my solution for the second OOP assignment in the .NET Diploma at Simulation Academy.

The assignment focuses on four main topics:

- Single Responsibility Principle (SRP)
- Creational Design Patterns
- Inheritance and OOP Design
- Problem Solving using Sliding Window

My main goal while working on this assignment was not only to make the code work, but also to understand how to analyze a problem, separate responsibilities, choose a suitable design, and apply OOP concepts correctly.

---

## 1. Single Responsibility Principle

The first part contained 10 classes that violated the Single Responsibility Principle.

Before changing the code, I analyzed each class and tried to identify the different responsibilities inside it.

I documented this analysis in:

`SRP/Responsibilities.md`

After that, I refactored the classes by separating responsibilities into smaller and more focused classes.

The main idea I followed was:

> A class should have one clear responsibility and one reason to change.

I also tried to keep the original behavior working after the refactoring instead of changing what the application does.

### What I learned

This part helped me understand that SRP is not simply about making classes smaller. The important part is identifying different reasons a class might need to change and separating those responsibilities correctly.

---

## 2. Creational Design Patterns

The second part of the assignment contains three object-creation problems.

Instead of solving them with normal object creation, I applied three different creational design patterns.

### Singleton

The first problem was related to `AppConfig`.

Different services were creating different configuration objects, which meant they did not share the same state.

I used the Singleton pattern so the application works with one shared `AppConfig` instance.

The solution also prevents outside code from creating additional instances and ensures that the configuration loading process happens only once.

### Prototype

The second problem involved creating enemies such as Orcs and Elves.

Creating every enemy from scratch caused expensive model data to be loaded repeatedly.

I used the Prototype pattern so an existing enemy can be cloned instead of rebuilding everything again.

An important part of this solution was understanding the difference between shallow copy and deep copy.

The cloned enemy needed to be independent from the original, especially for objects such as its weapon and abilities.

### Builder

The third problem involved `CourseRegistration`.

The original design used a long constructor with many arguments, which made object creation difficult to read and easy to misuse.

I replaced this approach with the Builder pattern.

The Builder makes the creation steps clearer and validates the rules before creating the final registration.

For example:

- `LiveGroup` requires a GroupCode.
- `VideosOnly` must not have a GroupCode.

This made the object creation process easier to understand and moved the validation to the correct place.

---

## 3. Library System — Inheritance

This part was different because the requirements were written as a real business description instead of directly telling me which classes or methods to create.

I first analyzed the business rules before writing the code.

I identified the common data and behavior and then created the inheritance hierarchy.

The main hierarchy is:

```text
Person
├── Member
│   ├── StudentMember
│   └── PremiumMember
│
└── Staff
    ├── Librarian
    ├── Shelver
    └── HeadLibrarian

LibraryItem
├── Book
├── DVD
└── Magazine
```

A `Loan` connects one `Member` with one `LibraryItem`.

I created the UML class diagram before implementing the classes so I could decide where each responsibility and business rule belonged before writing the actual code.

### Members

All members share the borrowing behavior and loan history.

A `StudentMember` can have a maximum of 3 active loans and has no late-fee discount.

A `PremiumMember` can have up to 10 active loans, has a fixed late-fee discount, and earns 5 reading points for every returned loan.

The loan history is protected from direct modification. Outside code can read it, but new loans are added only through the borrowing process.

### Staff

All staff members share information such as hire date and monthly salary.

Salary cannot be changed directly. It can only be changed through the `GiveRaise` operation.

The staff types then add their own responsibilities:

- `Librarian` processes returns and marks loans as lost.
- `Shelver` manages its assigned section.
- `HeadLibrarian` manages item pricing and can withdraw or restore items.

The Head Librarian also receives a fixed responsibility allowance of 400.

### Library Items

The system supports three item types:

| Item | Loan Period | Late Fee |
|------|------------:|---------:|
| Book | 21 days | Base fee |
| DVD | 7 days | Base fee × 2 |
| Magazine | 3 days | Base fee × 0.5 |

Instead of checking the item type using `if` or `switch`, each child provides its values to the parent class.

This allows the rest of the system to work with `LibraryItem` without needing to know whether the object is a Book, DVD, or Magazine.

### Borrowing Rules

The borrowing process validates the business rules before creating a loan.

The system rejects a borrowing operation when:

- the item is withdrawn;
- the item is already on loan;
- the member has reached the maximum number of active loans.

When a valid loan is created, the item automatically becomes on loan.

### Loans

Each loan stores the member, item, loan ID, and borrow date.

The due date is not entered manually. It is calculated automatically using:

```text
Borrow Date + Item Loan Period
```

A loan can have one of three states:

```text
Borrowed
Returned
Lost
```

Only valid status changes are allowed.

For example, the system rejects:

```text
Returned → Returned
Returned → Lost
```

When an item is returned, the return date is recorded and the item becomes available again.

### Late Fee

The late fee is calculated automatically.

The calculation is based on:

```text
Late Days × Item Daily Late Fee
```

Then the member's discount is applied.

If the item is returned on time, the late fee is zero.

This means values such as the due date, late fee, and Premium Member reading points are calculated by the system instead of being manually entered.

### Testing the Business Rules

In `Program.cs`, I created different scenarios to prove that the rules work correctly.

I tested cases such as:

- trying to borrow a withdrawn item;
- trying to borrow an item that is already on loan;
- trying to give a Student Member a fourth active loan;
- calculating monthly pay for different staff types;
- calculating different loan periods and daily fees;
- returning a DVD five days late;
- calculating Premium Member reading points;
- trying to return the same loan twice;
- trying to mark a returned loan as lost.

Invalid operations throw exceptions with clear messages, which are caught and displayed in `Main`.

---

## 4. LeetCode — Sliding Window

The final part is LeetCode problem:

**1456. Maximum Number of Vowels in a Substring of Given Length**

I solved the problem using the Sliding Window technique.

Instead of counting all vowels again for every possible substring, I keep track of the current window.

When the window moves:

- the character leaving the window is removed from the count if it is a vowel;
- the new character entering the window is added if it is a vowel;
- the maximum vowel count is updated.

This avoids repeating the same work for every substring.

The solution is stored inside:

`LeetCode/1456_MaxVowelsInSubstring/`

The folder contains:

- `Solution.cs`
- `accepted_screenshot.png`
- `leetcode.md`

---

## Repository Structure

```text
.
├── SRP/
│   ├── Responsibilities.md
│   └── src/
│
├── DesignPatterns/
│   ├── linked.md
│   └── src/
│
├── Inheritance/
│   ├── ClassDiagram.png
│   └── src/
│
├── LeetCode/
│   └── 1456_MaxVowelsInSubstring/
│       ├── Solution.cs
│       ├── accepted_screenshot.png
│       └── leetcode.md
│
└── README.md
```

---

## What I Learned

The most important thing I learned from this assignment was how to move from requirements to design before starting to write code.

In the SRP part, I learned how to identify responsibilities and separate them.

In the Design Patterns part, I learned that different object-creation problems need different solutions instead of forcing everything into normal constructors.

In the Inheritance part, I practiced finding shared behavior, deciding what belongs in a parent class, deciding what each child should add, and protecting business rules using encapsulation.

Finally, the LeetCode problem helped me practice the Sliding Window technique and think about avoiding repeated work.

Overall, this assignment connected OOP design, clean code, design patterns, inheritance, and problem solving in one project.
