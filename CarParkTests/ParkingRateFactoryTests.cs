using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarPark.Tests
{
    [TestClass()]
    public class ParkingRateFactoryTests
    {
        [TestMethod()]
        public void ParkingRateFactoryFlatRateTest()
        {
            ParkingRateFactory parkingRateFactory = new ParkingRateFactory();

            // 6:00am to 11:30pm, Friday, Flat Rate
            Parking parking = new Parking(new DateTime(2018, 1, 19, 6, 0, 0), new DateTime(2018, 1, 19, 23, 30, 0));
            ParkingRate rate = parkingRateFactory.GetRate(parking);

            Assert.IsInstanceOfType(rate, typeof(FlatRate));
            Assert.IsTrue(rate.Charge(parking) == 13.00m);

            // 6:00am to 11:29:59pm, Friday, Flat Rate
            parking = new Parking(new DateTime(2018, 1, 19, 6, 0, 0), new DateTime(2018, 1, 19, 23, 29, 59));
            rate = parkingRateFactory.GetRate(parking);

            Assert.IsInstanceOfType(rate, typeof(FlatRate));
            Assert.IsTrue(rate.Charge(parking) == 13.00m);

            // 6:00:01am to 11:30:00pm, Friday, Flat Rate
            parking = new Parking(new DateTime(2018, 1, 19, 6, 0, 1), new DateTime(2018, 1, 19, 23, 30, 0));
            rate = parkingRateFactory.GetRate(parking);

            Assert.IsInstanceOfType(rate, typeof(FlatRate));
            Assert.IsTrue(rate.Charge(parking) == 13.00m);

            // 6:00pm Friday to 6:00am Saturday, Weekday Night Rate
            parking = new Parking(new DateTime(2018, 1, 19, 18, 0, 0), new DateTime(2018, 1, 20, 6, 0, 0));
            rate = parkingRateFactory.GetRate(parking);

            Assert.IsInstanceOfType(rate, typeof(FlatRate));
            Assert.IsTrue(rate.Charge(parking) == 6.50m);

            // 6:00pm Friday to 0:00am Saturday, Weekday Night Rate
            parking = new Parking(new DateTime(2018, 1, 19, 18, 0, 0), new DateTime(2018, 1, 20, 0, 0, 0));
            rate = parkingRateFactory.GetRate(parking);

            Assert.IsInstanceOfType(rate, typeof(FlatRate));
            Assert.IsTrue(rate.Charge(parking) == 6.50m);

            // 0:00pm Saturday to 0:00am Sunday, Weekend Rate
            parking = new Parking(new DateTime(2018, 1, 20, 0, 0, 0), new DateTime(2018, 1, 21, 0, 0, 0));
            rate = parkingRateFactory.GetRate(parking);

            Assert.IsInstanceOfType(rate, typeof(FlatRate));
            Assert.IsTrue(rate.Charge(parking) == 10.00m);
        }

        [TestMethod()]
        public void ParkingRateFactoryHourlyRateTest()
        {
            ParkingRateFactory parkingRateFactory = new ParkingRateFactory();

            // 5:59:59am to 6:59:58am, Friday, Hourly Rate
            Parking parking = new Parking(new DateTime(2018, 1, 19, 5, 59, 59), new DateTime(2018, 1, 19, 6, 59, 58));
            ParkingRate rate = parkingRateFactory.GetRate(parking);

            Assert.IsInstanceOfType(rate, typeof(HourlyRate));
            Assert.IsTrue(rate.Charge(parking) == 5.00m);

            // 5:59:59am to 6:59:59am, Friday, Hourly Rate
            parking = new Parking(new DateTime(2018, 1, 19, 5, 59, 59), new DateTime(2018, 1, 19, 6, 59, 59));
            rate = parkingRateFactory.GetRate(parking);

            Assert.IsInstanceOfType(rate, typeof(HourlyRate));
            Assert.IsTrue(rate.Charge(parking) == 10.00m);

            // 5:59:59am to 7:59:59am, Friday, Hourly Rate
            parking = new Parking(new DateTime(2018, 1, 19, 5, 59, 59), new DateTime(2018, 1, 19, 7, 59, 59));
            rate = parkingRateFactory.GetRate(parking);

            Assert.IsInstanceOfType(rate, typeof(HourlyRate));
            Assert.IsTrue(rate.Charge(parking) == 15.00m);

            // 5:59:59am to 8:59:58am, Friday, Hourly Rate
            parking = new Parking(new DateTime(2018, 1, 19, 5, 59, 59), new DateTime(2018, 1, 19, 8, 59, 58));
            rate = parkingRateFactory.GetRate(parking);

            Assert.IsInstanceOfType(rate, typeof(HourlyRate));
            Assert.IsTrue(rate.Charge(parking) == 15.00m);
        }
        [TestMethod()]
        public void ParkingRateFactoryDailyRateTest()
        {
            ParkingRateFactory parkingRateFactory = new ParkingRateFactory();

            // 5:59:59am to 11:30:00pm, Friday, Daily Rate
            Parking parking = new Parking(new DateTime(2018, 1, 19, 5, 59, 59), new DateTime(2018, 1, 19, 23, 30, 0));
            ParkingRate rate = parkingRateFactory.GetRate(parking);

            Assert.IsInstanceOfType(rate, typeof(DailyRate));
            Assert.IsTrue(rate.Charge(parking) == 20.00m);

            // 6:00am to 11:30:01pm, Friday, Daily Rate
            parking = new Parking(new DateTime(2018, 1, 19, 6, 0, 0), new DateTime(2018, 1, 19, 23, 30, 1));
            rate = parkingRateFactory.GetRate(parking);

            Assert.IsInstanceOfType(rate, typeof(DailyRate));
            Assert.IsTrue(rate.Charge(parking) == 20.00m);
        }
    }
}