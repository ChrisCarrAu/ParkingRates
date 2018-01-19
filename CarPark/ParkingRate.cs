using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    public abstract class ParkingRate
    {
        public string FriendlyName { get; set; }

        public ParkingRate(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        public abstract decimal Charge(Parking parking);

    }
}
