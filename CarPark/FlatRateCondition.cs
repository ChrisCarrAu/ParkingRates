using System;

namespace CarPark
{
    /// <summary>
    /// Defines the conditions where a flat rate is used to charge for parking
    /// </summary>
    public class FlatRateCondition : ParkingCondition, IParkingCondition
    {
        private readonly TimeSpan _entryTimeStart;
        private readonly TimeSpan _entryTimeFinish;
        private readonly TimeSpan _exitTimeStart;
        private readonly TimeSpan _exitTimeFinish;
        private readonly DayOfWeek _permittedEntryDays;
        private readonly DayOfWeek _permittedExitdays;

        /// <summary>
        /// A flat rate is calculated where the carpark is entered within an entry period and exited within an exit period. This can be filtered further to specific days (for both entry and exit)
        /// </summary>
        /// <param name="entryTimeStart">Entry time period start</param>
        /// <param name="entryTimeFinish">Entry time period end</param>
        /// <param name="exitTimeStart">Exit time period start - this is relative to the entry time, so days must be added for days after entry day</param>
        /// <param name="exitTimeFinish">Exit time period end</param>
        /// <param name="daysToApply">The days on which a car must enter and exit for this calculation to apply. Default is every day</param>
        public FlatRateCondition(TimeSpan entryTimeStart, TimeSpan entryTimeFinish, TimeSpan exitTimeStart, TimeSpan exitTimeFinish, DayOfWeek permittedEntryDays = EveryDay, DayOfWeek permittedExitDays = EveryDay)
        {
            _entryTimeStart = entryTimeStart;
            _entryTimeFinish = entryTimeFinish;
            _exitTimeStart = exitTimeStart;
            _exitTimeFinish = exitTimeFinish;
            _permittedEntryDays = permittedEntryDays;
            _permittedExitdays = permittedExitDays;
        }

        /// <summary>
        /// Matches if the car entered and exited on the specified days and also if the entry and exit times are within entry/exit spans.
        /// </summary>
        /// <param name="parking">the parking usage instance</param>
        /// <returns></returns>
        public override bool Matches(Parking parking)
        {
            var entryTime = parking.Entry.TimeOfDay;
            var exitTime = parking.Exit.TimeOfDay;

            if (parking.Exit.Date > parking.Entry.Date)
            {
                // The parking was over more than one day. Add the number of days to the exitTime
                exitTime = exitTime.Add(parking.Exit.Date.Subtract(parking.Entry.Date));
            }

            // On which days did the car enter and exit parking?
            var entryDayOfWeek = GetDayOfWeek(parking.Entry);
            var exitDayOfWeek = GetDayOfWeek(parking.Exit);

            return ((entryDayOfWeek & _permittedEntryDays) == entryDayOfWeek)
                && ((exitDayOfWeek & _permittedExitdays) == exitDayOfWeek)
                && (_entryTimeStart <= entryTime) && (entryTime <= _entryTimeFinish)
                && (_exitTimeStart <= exitTime) && (exitTime <= _exitTimeFinish);
        }
    }
}
