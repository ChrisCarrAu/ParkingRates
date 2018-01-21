namespace CarPark
{
    /// <summary>
    /// A parking charge calculator calculates a charge for parking of a specified type
    /// </summary>
    public abstract class ParkingChargeCalculator : IParkingType, IParkingCalculator
    {
        public string FriendlyName { get; set; }

        protected ParkingChargeCalculator(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        public abstract decimal Charge(Parking parking);
    }
}
