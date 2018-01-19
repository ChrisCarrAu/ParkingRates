using System;
using System.Collections.Generic;

namespace CarPark
{
    public abstract class ParkingCondition
    {
        [Flags]
        public enum DayOfWeek
        {
            Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
        }
        public const DayOfWeek WeekDays = DayOfWeek.Monday | DayOfWeek.Tuesday | DayOfWeek.Wednesday | DayOfWeek.Thursday | DayOfWeek.Friday;
        public const DayOfWeek WeekEnd = DayOfWeek.Saturday | DayOfWeek.Sunday;
        public const DayOfWeek EveryDay = WeekDays | WeekEnd;

        /// <summary>
        /// Evaluates a DateTime and returns the Day of the ParkingCondition.DayOfWeek from it.
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public DayOfWeek GetDayOfWeek(DateTime day)
        {
            Dictionary<System.DayOfWeek, ParkingCondition.DayOfWeek> dayOfWeekMap = new Dictionary<System.DayOfWeek, DayOfWeek>();
            dayOfWeekMap.Add(System.DayOfWeek.Sunday, DayOfWeek.Sunday);
            dayOfWeekMap.Add(System.DayOfWeek.Monday, DayOfWeek.Monday);
            dayOfWeekMap.Add(System.DayOfWeek.Tuesday, DayOfWeek.Tuesday);
            dayOfWeekMap.Add(System.DayOfWeek.Wednesday, DayOfWeek.Wednesday);
            dayOfWeekMap.Add(System.DayOfWeek.Thursday, DayOfWeek.Thursday);
            dayOfWeekMap.Add(System.DayOfWeek.Friday, DayOfWeek.Friday);
            dayOfWeekMap.Add(System.DayOfWeek.Saturday, DayOfWeek.Saturday);

            return dayOfWeekMap[day.DayOfWeek];
        }

        /// <summary>
        /// Returns true if the parking entry and exit times match this parking condition.
        /// </summary>
        /// <param name="entryTime"></param>
        /// <param name="exitTime"></param>
        /// <returns></returns>
        public abstract bool Matches(Parking parking);
    }
}
