using System;

namespace CarPark
{
    public class FlatRateParkingChargeCalculator : ParkingChargeCalculator
    {
        private decimal _charge;

        public FlatRateParkingChargeCalculator(string friendlyName, decimal charge) : base(friendlyName)
        {
            _charge = charge;
        }

        public override decimal Charge(Parking parking)
        {
            return _charge;
        }
    }
}
