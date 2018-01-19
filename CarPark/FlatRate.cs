using System;

namespace CarPark
{
    public class FlatRate : ParkingRate
    {
        private decimal _charge;

        public FlatRate(string friendlyName, decimal charge) : base(friendlyName)
        {
            _charge = charge;
        }

        public override decimal Charge(Parking parking)
        {
            return _charge;
        }
    }
}
