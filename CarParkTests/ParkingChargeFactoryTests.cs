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
            ParkingChargeFactory parkingChargeFactory = new ParkingChargeFactory();

            // 6:00am to 11:30pm, Friday, Flat Rate
            var parking = new Parking(new DateTime(2018, 1, 19, 6, 0, 0), new DateTime(2018, 1, 19, 23, 30, 0));
            var rate = parkingChargeFactory.GetCharge(parking);

            Assert.IsInstanceOfType(rate.Rate, typeof(FlatRateParkingChargeCalculator));
            Assert.IsTrue(rate.Charge == 13.00m);

            // 6:00am to 11:29:59pm, Friday, Flat Rate
            parking = new Parking(new DateTime(2018, 1, 19, 6, 0, 0), new DateTime(2018, 1, 19, 23, 29, 59));
            rate = parkingChargeFactory.GetCharge(parking);

            Assert.IsInstanceOfType(rate.Rate, typeof(FlatRateParkingChargeCalculator));
            Assert.IsTrue(rate.Charge == 13.00m);

            // 6:00:01am to 11:30:00pm, Friday, Flat Rate
            parking = new Parking(new DateTime(2018, 1, 19, 6, 0, 1), new DateTime(2018, 1, 19, 23, 30, 0));
            rate = parkingChargeFactory.GetCharge(parking);

            Assert.IsInstanceOfType(rate.Rate, typeof(FlatRateParkingChargeCalculator));
            Assert.IsTrue(rate.Charge == 13.00m);

            // 6:00pm Friday to 6:00am Saturday, Weekday Night Rate
            parking = new Parking(new DateTime(2018, 1, 19, 18, 0, 0), new DateTime(2018, 1, 20, 6, 0, 0));
            rate = parkingChargeFactory.GetCharge(parking);

            Assert.IsInstanceOfType(rate.Rate, typeof(FlatRateParkingChargeCalculator));
            Assert.IsTrue(rate.Charge == 6.50m);

            // 6:00pm Friday to 0:00am Saturday, Weekday Night Rate
            parking = new Parking(new DateTime(2018, 1, 19, 18, 0, 0), new DateTime(2018, 1, 20, 0, 0, 0));
            rate = parkingChargeFactory.GetCharge(parking);

            Assert.IsInstanceOfType(rate.Rate, typeof(FlatRateParkingChargeCalculator));
            Assert.IsTrue(rate.Charge == 6.50m);

            // 0:00pm Saturday to 0:00am Sunday, Weekend Rate
            parking = new Parking(new DateTime(2018, 1, 20, 0, 0, 0), new DateTime(2018, 1, 21, 0, 0, 0));
            rate = parkingChargeFactory.GetCharge(parking);

            Assert.IsInstanceOfType(rate.Rate, typeof(FlatRateParkingChargeCalculator));
            Assert.IsTrue(rate.Charge == 10.00m);
        }

        [TestMethod()]
        public void ParkingRateFactoryHourlyRateTest()
        {
            ParkingChargeFactory parkingChargeFactory = new ParkingChargeFactory();

            // 5:59:59am to 6:59:58am, Friday, Hourly Rate
            var parking = new Parking(new DateTime(2018, 1, 19, 5, 59, 59), new DateTime(2018, 1, 19, 6, 59, 58));
            var rate = parkingChargeFactory.GetCharge(parking);

            Assert.IsInstanceOfType(rate.Rate, typeof(HourlyRateParkingChargeCalculator));
            Assert.IsTrue(rate.Charge == 5.00m);

            // 5:59:59am to 6:59:59am, Friday, Hourly Rate
            parking = new Parking(new DateTime(2018, 1, 19, 5, 59, 59), new DateTime(2018, 1, 19, 6, 59, 59));
            rate = parkingChargeFactory.GetCharge(parking);

            Assert.IsInstanceOfType(rate.Rate, typeof(HourlyRateParkingChargeCalculator));
            Assert.IsTrue(rate.Charge == 10.00m);

            // 5:59:59am to 7:59:59am, Friday, Hourly Rate
            parking = new Parking(new DateTime(2018, 1, 19, 5, 59, 59), new DateTime(2018, 1, 19, 7, 59, 59));
            rate = parkingChargeFactory.GetCharge(parking);

            Assert.IsInstanceOfType(rate.Rate, typeof(HourlyRateParkingChargeCalculator));
            Assert.IsTrue(rate.Charge == 15.00m);

            // 5:59:59am to 8:59:58am, Friday, Hourly Rate
            parking = new Parking(new DateTime(2018, 1, 19, 5, 59, 59), new DateTime(2018, 1, 19, 8, 59, 58));
            rate = parkingChargeFactory.GetCharge(parking);

            Assert.IsInstanceOfType(rate.Rate, typeof(HourlyRateParkingChargeCalculator));
            Assert.IsTrue(rate.Charge == 15.00m);
        }
        [TestMethod()]
        public void ParkingRateFactoryDailyRateTest()
        {
            ParkingChargeFactory parkingChargeFactory = new ParkingChargeFactory();

            // 5:59:59am to 11:30:00pm, Friday, Daily Rate
            var parking = new Parking(new DateTime(2018, 1, 19, 5, 59, 59), new DateTime(2018, 1, 19, 23, 30, 0));
            var rate = parkingChargeFactory.GetCharge(parking);

            Assert.IsInstanceOfType(rate.Rate, typeof(DailyRateParkingChargeCalculator));
            Assert.IsTrue(rate.Charge == 20.00m);

            // 6:00am to 11:30:01pm, Friday, Daily Rate
            parking = new Parking(new DateTime(2018, 1, 19, 6, 0, 0), new DateTime(2018, 1, 19, 23, 30, 1));
            rate = parkingChargeFactory.GetCharge(parking);

            Assert.IsInstanceOfType(rate.Rate, typeof(DailyRateParkingChargeCalculator));
            Assert.IsTrue(rate.Charge == 20.00m);

            // 0:00am Friday to 0:00am Saturday, Daily Rate
            parking = new Parking(new DateTime(2018, 1, 19, 0, 0, 0), new DateTime(2018, 1, 20, 0, 0, 0));
            rate = parkingChargeFactory.GetCharge(parking);

            Assert.IsInstanceOfType(rate.Rate, typeof(DailyRateParkingChargeCalculator));
            Assert.IsTrue(rate.Charge == 40.00m);
        }
    }
}