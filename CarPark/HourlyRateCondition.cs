using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    public class HourlyRateCondition : ParkingCondition
    {
        private HourlyRates _hourlyRates { get; set; }

        public HourlyRateCondition(HourlyRates hourlyRates)
        {
            _hourlyRates = hourlyRates;
        }

        public override bool Matches(Parking parking)
        {
            return parking.Hours <= _hourlyRates.MaximumHours;
        }
    }
}
