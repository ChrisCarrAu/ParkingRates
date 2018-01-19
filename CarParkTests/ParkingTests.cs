using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarPark;

namespace CarParkTests
{
    [TestClass]
    public class ParkingTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParkingConstructor()
        {
            var parking = new Parking(new DateTime(2018, 1, 19, 0, 0, 0), new DateTime(2018, 1, 18, 0, 0, 0));
        }

        [TestMethod]
        public void ParkingHours()
        {
            // One second rounds up to one hour
            var parking = new Parking(new DateTime(2018, 1, 19, 0, 0, 0), new DateTime(2018, 1, 19, 0, 0, 1));
            Assert.AreEqual(parking.Hours, 1);

            // One second before one hour rounds up to one hour
            parking = new Parking(new DateTime(2018, 1, 19, 0, 0, 0), new DateTime(2018, 1, 19, 0, 59, 59));
            Assert.AreEqual(parking.Hours, 1);

            // One hour to the next is two hours (it's started the second hour)
            parking = new Parking(new DateTime(2018, 1, 19, 0, 0, 0), new DateTime(2018, 1, 19, 1, 0, 0));
            Assert.AreEqual(parking.Hours, 2);

            // One second less than one hour overnight - one hour
            parking = new Parking(new DateTime(2018, 1, 19, 23, 30, 0), new DateTime(2018, 1, 20, 0, 29, 59));
            Assert.AreEqual(parking.Hours, 1);

            // One hour to the next (overnight) is two hours (it's started the second hour)
            parking = new Parking(new DateTime(2018, 1, 19, 23, 30, 0), new DateTime(2018, 1, 20, 0, 30, 0));
            Assert.AreEqual(parking.Hours, 2);

        }

        [TestMethod]
        public void ParkingDays()
        {
            var parking = new Parking(new DateTime(2018, 1, 19, 0, 0, 0), new DateTime(2018, 1, 19, 0, 0, 1));
            Assert.AreEqual(parking.Days, 1);

            parking = new Parking(new DateTime(2018, 1, 19, 0, 0, 0), new DateTime(2018, 1, 19, 23, 59, 59));
            Assert.AreEqual(parking.Days, 1);

            parking = new Parking(new DateTime(2018, 1, 19, 0, 0, 0), new DateTime(2018, 1, 20, 0, 0, 0));
            Assert.AreEqual(parking.Days, 2);

            parking = new Parking(new DateTime(2018, 1, 19, 0, 0, 0), new DateTime(2018, 1, 22, 0, 0, 0));
            Assert.AreEqual(parking.Days, 4);
        }
    }
}
