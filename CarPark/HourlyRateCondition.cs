namespace CarPark
{
    /// <summary>
    /// Defines the conditions where an hourly rate is used to charge for parking
    /// </summary>
    public class HourlyRateCondition : ParkingCondition, IParkingCondition
    {
        private HourlyChargeRates HourlyRates { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="hourlyRates">Hourly rates must be supplied</param>
        public HourlyRateCondition(HourlyChargeRates hourlyRates)
        {
            HourlyRates = hourlyRates;
        }

        public override bool Matches(Parking parking)
        {
            return parking.Hours <= HourlyRates.MaximumHours;
        }
    }
}
