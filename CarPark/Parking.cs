using System;
using NUnit.Framework;

namespace CarPark
{
    /// <summary>
    /// Represents an instance of a parking space usage.
    /// Entry time should be before the exit time.
    /// </summary>
    public class Parking : IParking
    {
        /// <summary>
        /// Date & time of entry to the car park
        /// </summary>
        public DateTime Entry { get; private set; }

        /// <summary>
        /// Date & time of exit from the car park
        /// </summary>
        public DateTime Exit { get; private set; }

        /// <summary>
        /// The duration of this parking
        /// </summary>
        private TimeSpan Duration { get { return Exit.Subtract(Entry); } }

        /// <summary>
        /// The number of days (whole or partial) parking
        /// </summary>
        public int Days { get { return (int)(Duration.TotalDays) + 1; } }

        /// <summary>
        /// The number of hours (whole or partial) of parking
        /// </summary>
        public int Hours { get { return (int)(Duration.TotalHours) + 1; } }

        public Parking(DateTime entry, DateTime exit)
        {
            if (entry > exit)
            {
                throw new ArgumentException("Entry date must preceed exit date");
            }

            Entry = entry;
            Exit = exit;
        }
    }

    [TestFixture]
    public class ParkingTest
    {
        [Test]
        public void ParkingConstructor()
        {
            Assert.Throws<ArgumentException>(delegate { new Parking(new DateTime(2018, 1, 19, 0, 0, 0), new DateTime(2018, 1, 18, 0, 0, 0)); } );
        }

        [Test]
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

        [Test]
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
