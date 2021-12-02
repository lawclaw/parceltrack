using Coursework.exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Coursework.business
{
    /// <summary>
    /// <para>Class representing a walking courier</para>
    /// <para>Base class: Courier</para>
    /// </summary>
    public class WalkingCourier: Courier
    {
        /// <summary>
        /// <para>Constructor used when creating a new WalkingCourier</para>
        /// </summary>
        /// <param name="area"></param>
        /// <param name="couriers"></param>
        public WalkingCourier(string area, Dictionary<string, Courier> couriers) : base(couriers)
        {
            //Needs checking if it is EH1-EH4
            if (_validAreas.GetRange(0,4).Any(a => a == area))
            {
                base.AddArea(area);
            }
            else
            {
                throw new InvalidAreaException();
            }
            _maxCapacity = 5;

        }

        /// <summary>
        /// <para>Constructor used when importing WalkingCourier from CSV </para>
        /// <para>More specifically used with pre-determined ID and area</para>
        /// </summary>
        /// <param name="id">ID of WalkingCourier</param>
        /// <param name="area">Assigned area of WalkingCourier</param>
        public WalkingCourier(string id, string area) : base(id)
        {
            base.AddArea(area);
            _maxCapacity = 5;

        }

        /// <summary>
        /// <para>Checks if WalkingCourier has reached its max capacity for parcels</para>
        /// </summary>
        /// <returns>A boolean whether the WalkingCourier is "full" of parcels</returns>
        public override bool IsFull()
        {
            return Parcels.Count >= _maxCapacity;
        }
    }
}
