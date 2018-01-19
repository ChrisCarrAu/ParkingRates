using System;

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
            if (Entry > Exit)
            {
                throw new ArgumentException("Entry date must preceed exit date");
            }

            Entry = entry;
            Exit = exit;
        }
    }
}
