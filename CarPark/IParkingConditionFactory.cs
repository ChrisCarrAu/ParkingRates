namespace CarPark
{
    public interface IParkingConditionFactory
    {
        ParkingChargeCalculator GetParkingCalculator(Parking parking);
    }
}