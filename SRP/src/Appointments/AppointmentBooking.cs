using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Assignment_2.src.Appointments
{
    public class AppointmentBooking
    {
        private readonly HashSet<DateTimeOffset> _booked = new();
        private readonly AppointmentSchedule _appointmentSchedule;
        public AppointmentBooking(AppointmentSchedule appointmentSchedule)
        {
            _appointmentSchedule = appointmentSchedule;
        }
        public bool TryBook(DateTimeOffset slot)
        {
            if (!_appointmentSchedule.IsWithinBusinessHours(slot) || _booked.Contains(slot)) return false;
            _booked.Add(slot);
            return true;
        }
    }
}
