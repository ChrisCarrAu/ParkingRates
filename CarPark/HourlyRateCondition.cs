namespace CarPark
{
    /// <summary>
    /// Defines the conditions where an hourly rate is used to charge for parking
    /// </summary>
    public class HourlyRateCondition : ParkingCondition, IParkingCondition
    {
        private HourlyChargeRates _hourlyRates { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="hourlyRates">Hourly rates must be supplied</param>
        public HourlyRateCondition(HourlyChargeRates hourlyRates)
        {
            _hourlyRates = hourlyRates;
        }

        public override bool Matches(Parking parking)
        {
            return parking.Hours <= _hourlyRates.MaximumHours;
        }
    }
}
