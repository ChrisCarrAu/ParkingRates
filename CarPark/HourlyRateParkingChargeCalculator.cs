using System;

namespace CarPark
{
    /// <summary>
    /// An hourly parking rate defines the rate to charge for hourly increments (up to maximum hours)
    /// </summary>
    public class HourlyRateParkingChargeCalculator : ParkingChargeCalculator
    {
        private HourlyChargeRates _hourlyRates;

        public HourlyRateParkingChargeCalculator(string friendlyName, HourlyChargeRates hourlyRates) : base(friendlyName)
        {
            _hourlyRates = hourlyRates;
        }

        public override decimal Charge(Parking parking)
        {
            return _hourlyRates.Rate(parking.Hours);
        }
    }
}
