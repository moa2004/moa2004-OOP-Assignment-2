using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Assignment_2.src.Appointments
{
    public class AppointmentCalendarExporter
    {
        private AppointmentSchedule schedule;

        public AppointmentCalendarExporter(AppointmentSchedule schedule)
        {
            this.schedule = schedule;
        }

        public int SlotMinutes { get; }
        public string ToIcs(DateTimeOffset slot, string patientName, string clinician)
        {
            var uid = Guid.NewGuid();
            var end = slot.AddMinutes(SlotMinutes);
            return "BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\n" +
                   $"UID:{uid}\nDTSTART:{slot:yyyyMMdd'T'HHmmss'Z'}\nDTEND:{end:yyyyMMdd'T'HHmmss'Z'}\n" +
                   $"SUMMARY:Visit {patientName} / {clinician}\nEND:VEVENT\nEND:VCALENDAR\n";
        }
    }
}
