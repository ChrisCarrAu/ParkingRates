using System.Collections.Generic;
using System.Linq;

namespace CarPark
{
    /// <summary>
    /// 
    /// </summary>
    public class HourlyChargeRates
    {
        /// <summary>
        /// A dictionary containing the maximum hours at which the rate is applied. Hours are stored in ascending order.
        /// </summary>
        private readonly SortedDictionary<int, decimal> _rates = new SortedDictionary<int, decimal>();

        /// <summary>
        /// Returns the maximum number of hours for which an hourly rate can apply
        /// </summary>
        public int MaximumHours => _rates.Keys.Max();

        /// <summary>
        /// Adds the number of hours at which an hourly rate applies.
        /// If an entry exists for the spcified hour limit, the rate is overwritten with the new rate.
        /// </summary>
        /// <param name="hourLimit">Maximum number of hours</param>
        /// <param name="rate">Rate to charge for this many hours of parking</param>
        public void Add(int hourLimit, decimal rate)
        {
            _rates[hourLimit] = rate;
        }

        /// <summary>
        /// Returns the Rate to pay for the specified number of hours.
        /// This is based off the smallest "hour" value in the internal dictionary that is larger than the hours passed in
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public decimal Rate(int hours)
        {
            return _rates.First(rate => (rate.Key >= hours)).Value;

        }
    }
}
