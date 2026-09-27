using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Assignment_2.src.Appointments
{
    public class AppointmentSchedule
    {
        private readonly HashSet<DateTimeOffset> _booked = new();
        public TimeOnly Open { get; }
        public TimeOnly Close { get; }
        public int SlotMinutes { get; }

        public AppointmentSchedule(HashSet<DateTimeOffset> booked, TimeOnly open, TimeOnly close, int slotMinutes)
        {
            _booked = booked;
            Open = open;
            Close = close;
            SlotMinutes = slotMinutes;
        }

        
        public bool IsWithinBusinessHours(DateTimeOffset when)
        {
            if (when.DayOfWeek is DayOfWeek.Friday or DayOfWeek.Saturday) return false;
            var t = TimeOnly.FromDateTime(when.DateTime);
            return t >= Open && t.AddMinutes(SlotMinutes) <= Close;
        }

        public DateTimeOffset? FindNextSlot(DateTimeOffset from, int searchHours)
        {
            var cursor = Align(from);
            var end = from.AddHours(searchHours);
            while (cursor < end)
            {
                if (IsWithinBusinessHours(cursor) && !_booked.Contains(cursor))
                    return cursor;
                cursor = cursor.AddMinutes(SlotMinutes);
            }
            return null;
        }
        private DateTimeOffset Align(DateTimeOffset from)
        {
            var minutes = from.Minute - (from.Minute % SlotMinutes);
            return new DateTimeOffset(from.Year, from.Month, from.Day, from.Hour, minutes, 0, from.Offset);
        }
    }
}
