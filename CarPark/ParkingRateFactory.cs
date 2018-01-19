using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPark
{
    /// <summary>
    /// Returns the correct parking rate to apply to a given parking instance.
    /// </summary>
    public class ParkingRateFactory
    {
        private Dictionary<ParkingCondition, ParkingRate> _parkingRules = new Dictionary<ParkingCondition, ParkingRate>();

        public ParkingRateFactory()
        {
            _parkingRules.Add(
                    new FlatRateCondition(new TimeSpan(6, 0, 0), new TimeSpan(9, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(23, 30, 0)),
                    new FlatRate("Early Bird", 13.00m));

            _parkingRules.Add(
                    new FlatRateCondition(new TimeSpan(18, 0, 0), new TimeSpan(24, 0, 0), new TimeSpan(18, 0, 0), new TimeSpan(1, 6, 0, 0), ParkingCondition.WeekDays),
                    new FlatRate("Night Rate", 6.50m));

            _parkingRules.Add(
                    new FlatRateCondition(new TimeSpan(0, 0, 0), new TimeSpan(2, 0, 0, 0), new TimeSpan(0, 0, 0), new TimeSpan(2, 0, 0, 0), ParkingCondition.WeekEnd),
                    new FlatRate("Weekend Rate", 10.00m));

            HourlyRates hourlyRates = new HourlyRates();
            hourlyRates.Add(1, 5.00m);
            hourlyRates.Add(2, 10.00m);
            hourlyRates.Add(3, 15.00m);

            _parkingRules.Add(
                    new HourlyRateCondition(hourlyRates),
                    new HourlyRate("Hourly Rate", hourlyRates));

            _parkingRules.Add(
                    new DailyRateCondition(),
                    new DailyRate("Daily Rate", 20m));
        }

        public ParkingRate GetRate(Parking parking)
        {
            var rate = _parkingRules.First(condition => condition.Key.Matches(parking)).Value;

            return rate;
        }
    }
}
