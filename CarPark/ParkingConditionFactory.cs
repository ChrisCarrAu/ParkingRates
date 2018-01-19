using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPark
{
    public class ParkingConditionFactory
    {
        private Dictionary<IParkingCondition, ParkingChargeCalculator> _parkingRules = new Dictionary<IParkingCondition, ParkingChargeCalculator>();

        public ParkingConditionFactory()
        {
            _parkingRules.Add(
                    new FlatRateCondition(new TimeSpan(6, 0, 0), new TimeSpan(9, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(23, 30, 0)),
                    new FlatRateParkingChargeCalculator("Early Bird", 13.00m));

            _parkingRules.Add(
                    new FlatRateCondition(new TimeSpan(18, 0, 0), new TimeSpan(24, 0, 0), new TimeSpan(18, 0, 0), new TimeSpan(1, 6, 0, 0), ParkingCondition.WeekDays),
                    new FlatRateParkingChargeCalculator("Night Rate", 6.50m));

            _parkingRules.Add(
                    new FlatRateCondition(new TimeSpan(0, 0, 0), new TimeSpan(2, 0, 0, 0), new TimeSpan(0, 0, 0), new TimeSpan(2, 0, 0, 0), ParkingCondition.WeekEnd),
                    new FlatRateParkingChargeCalculator("Weekend Rate", 10.00m));

            HourlyChargeRates hourlyRates = new HourlyChargeRates();
            hourlyRates.Add(1, 5.00m);
            hourlyRates.Add(2, 10.00m);
            hourlyRates.Add(3, 15.00m);

            _parkingRules.Add(
                    new HourlyRateCondition(hourlyRates),
                    new HourlyRateParkingChargeCalculator("Hourly Rate", hourlyRates));

            _parkingRules.Add(
                    new DailyRateCondition(),
                    new DailyRateParkingChargeCalculator("Daily Rate", 20m));
        }

        public ParkingChargeCalculator GetParkingCalculator(Parking parking)
        {
            return _parkingRules.First(condition => condition.Key.Matches(parking)).Value;

        }
    }
}
