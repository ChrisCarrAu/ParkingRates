namespace CarPark
{
    /// <summary>
    /// The resulting charge for parking usage
    /// </summary>
    public class ParkingCharge
    {
        public Parking Parking { get; private set; }
        public IParkingType Rate { get; private set; }
        public decimal Charge { get; private set; }

        public ParkingCharge(Parking parking, IParkingType rate, decimal charge)
        {
            Parking = parking;
            Rate = rate;
            Charge = charge;
        }
    }
}
