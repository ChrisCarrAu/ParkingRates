using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    public class FlatRateCondition : ParkingCondition
    {
        private TimeSpan _entryTimeStart;
        private TimeSpan _entryTimeFinish;
        private TimeSpan _exitTimeStart;
        private TimeSpan _exitTimeFinish;
        private DayOfWeek _daysToApply;

        public FlatRateCondition(TimeSpan entryTimeStart, TimeSpan entryTimeFinish, TimeSpan exitTimeStart, TimeSpan exitTimeFinish, DayOfWeek daysToApply = EveryDay)
        {
            _entryTimeStart = entryTimeStart;
            _entryTimeFinish = entryTimeFinish;
            _exitTimeStart = exitTimeStart;
            _exitTimeFinish = exitTimeFinish;
            _daysToApply = daysToApply;
        }

        public override bool Matches(Parking parking)
        {
            TimeSpan entryTime = parking.Entry.TimeOfDay;
            TimeSpan exitTime = parking.Exit.TimeOfDay;

            if (parking.Exit.Date > parking.Entry.Date)
            {
                // The parking was over more than one day. Add the number of days to the exitTime
                exitTime = exitTime.Add(parking.Exit.Date.Subtract(parking.Entry.Date));
            }

            var entryDayOfWeek = GetDayOfWeek(parking.Entry);

            return ((entryDayOfWeek & _daysToApply) == entryDayOfWeek)
                && (_entryTimeStart <= entryTime) && (entryTime <= _entryTimeFinish)
                && (_exitTimeStart <= exitTime) && (exitTime <= _exitTimeFinish);
        }
    }
}
