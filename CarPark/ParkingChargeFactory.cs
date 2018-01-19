namespace CarPark
{
    /// <summary>
    /// Returns the correct parking rate to apply to a given parking instance.
    /// </summary>
    public class ParkingChargeFactory
    {

        public ParkingCharge GetCharge(Parking parking)
        {
            ParkingConditionFactory parkingConditionFactory = new ParkingConditionFactory();

            var parkingCalculator = parkingConditionFactory.GetParkingCalculator(parking);

            return new ParkingCharge(parking, parkingCalculator, parkingCalculator.Charge(parking));
        }
    }
}
