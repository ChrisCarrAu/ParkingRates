using System;

namespace CarPark
{
    public class DailyRateParkingChargeCalculator : ParkingChargeCalculator
    {
        public decimal Rate { get; private set; }

        public DailyRateParkingChargeCalculator(string friendlyName, decimal rate) : base(friendlyName)
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
