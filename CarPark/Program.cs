using System;

namespace CarPark
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingRateFactory = new ParkingChargeFactory();

            {
                DateTime entry = new DateTime(2018, 1, 19, 6, 0, 0);
                DateTime exit = new DateTime(2018, 1, 19, 23, 30, 0);
                Parking parking = new Parking(entry, exit);

                // Get the applicable parking rate for this period.
                var applicableParkingRate = parkingRateFactory.GetCharge(parking);
                // Get the charge from this parking rate. - I don't like that the parking value is being passed in again.
                var charge = applicableParkingRate.Charge;
            }

            {
                DateTime entry = new DateTime(2018, 1, 20, 6, 0, 0);
                DateTime exit = new DateTime(2018, 1, 21, 23, 30, 1);
                Parking parking = new Parking(entry, exit);

                var parkingCharge = parkingRateFactory.GetCharge(parking);
                var charge = parkingCharge.Charge;
            }
        }
    }
}
