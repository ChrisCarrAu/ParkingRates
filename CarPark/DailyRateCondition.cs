using System;

namespace CarPark
{
    public class DailyRateCondition : ParkingCondition
    {
        public override bool Matches(Parking parking)
        {
            return true;
        }
    }
}
