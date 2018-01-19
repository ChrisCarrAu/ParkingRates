using System;

namespace CarPark
{
    public class DailyRate : ParkingRate
    {
        public decimal Rate { get; private set; }

        public DailyRate(string friendlyName, decimal rate) : base(friendlyName)
        {
            Rate = rate;
        }

        public override decimal Charge(Parking parking)
        {
            int totalDays = parking.Days;

            return totalDays * Rate;
        }
    }
}
