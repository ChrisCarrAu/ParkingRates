using System;

namespace CarPark
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingRateFactory = new ParkingChargeFactory();

            {
                var entry = new DateTime(2018, 1, 19, 6, 0, 0);
                var exit = new DateTime(2018, 1, 19, 23, 30, 0);
                var parking = new Parking(entry, exit);

                // Get the applicable parking rate for this period.
                var applicableParkingRate = parkingRateFactory.GetCharge(parking);
                WriteConsole(applicableParkingRate);
            }

            {
                var entry = new DateTime(2018, 1, 20, 6, 0, 0);
                var exit = new DateTime(2018, 1, 21, 23, 30, 1);
                var parking = new Parking(entry, exit);

                var applicableParkingRate = parkingRateFactory.GetCharge(parking);
                WriteConsole(applicableParkingRate);
            }
        }

        private static void WriteConsole(ParkingCharge applicableParkingRate)
        {

            Console.Out.WriteLine("PARKING CALCULATION");
            Console.Out.Write(" Entry: ");
            Console.Out.WriteLine(applicableParkingRate.Parking.Entry);
            Console.Out.Write(" Exit: ");
            Console.Out.WriteLine(applicableParkingRate.Parking.Exit);
            Console.Out.Write(" Parking Type: ");
            Console.Out.WriteLine(applicableParkingRate.Rate.FriendlyName);
            Console.Out.Write(" Charge: ");
            Console.Out.WriteLine(applicableParkingRate.Charge);
        }
    }
}
