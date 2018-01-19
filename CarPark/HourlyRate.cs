using System;

namespace CarPark
{
    public class HourlyRate : ParkingRate
    {
        private HourlyRates _hourlyRates;

        public HourlyRate(string friendlyName, HourlyRates hourlyRates) : base(friendlyName)
        {
            _hourlyRates = hourlyRates;
        }

        public override decimal Charge(Parking parking)
        {
            return _hourlyRates.Rate(parking.Hours);
        }
    }
}
