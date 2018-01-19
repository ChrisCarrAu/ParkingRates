namespace CarPark
{
    /// <summary>
    /// Given a parking usage instance, returns the charge.
    /// </summary>
    interface IParkingCalculator
    {
        decimal Charge(Parking parking);
    }
}
