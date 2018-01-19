namespace CarPark
{
    public abstract class ParkingChargeCalculator : IParkingType, IParkingCalculator
    {
        public string FriendlyName { get; set; }

        public ParkingChargeCalculator(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        public abstract decimal Charge(Parking parking);
    }
}
