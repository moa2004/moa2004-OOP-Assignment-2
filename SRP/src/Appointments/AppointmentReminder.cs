using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Assignment_2.src.Appointments
{
    internal class AppointmentReminder
    {
        public string SmsReminder(DateTimeOffset slot, string clinicPhone)
        {
            return $"Reminder: appointment {slot:MMM dd HH:mm}. Call {clinicPhone} to reschedule.";
        }
    }
}
