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
        /// A dictionary containing the maximum hours at which the rate is applied.
        /// </summary>
        private Dictionary<int, decimal> _rates = new Dictionary<int, decimal>();

        /// <summary>
        /// Returns the maximum number of hours for which an hourly rate applies
        /// </summary>
        public int MaximumHours
        {
            get
            {
                return _rates.Keys.Max();
            }
        }

        /// <summary>
        /// Adds the number of hours at which an hourly rate applies
        /// </summary>
        /// <param name="hourLimit">Maximum number of hours</param>
        /// <param name="rate">Rate to charge for this many hours of parking</param>
        public void Add(int hourLimit, decimal rate)
        {
            _rates.Add(hourLimit, rate);
        }

        public decimal Rate(int hours)
        {
            return _rates.First(rate => (rate.Key >= hours)).Value;

        }
    }
}
