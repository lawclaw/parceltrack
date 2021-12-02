using Coursework.exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Coursework.business
{
    /// <summary>
    /// <para>Class representing a cycling courier</para>
    /// <para>Base class: Courier</para>
    /// </summary>
    public class CycleCourier : Courier
    {
        /// <summary>
        /// <para>Constructor used when creating a new CycleCourier</para>
        /// </summary>
        /// <param name="area"></param>
        /// <param name="couriers"></param>
        public CycleCourier(string area, Dictionary<string, Courier> couriers) : base(couriers)
        {
            if (_validAreas.Any(a => a == area))
            {
                base.AddArea(area);
            } else
            {
                throw new InvalidAreaException();
            }
            _maxCapacity = 10;
        }

        /// <summary>
        /// <para>Constructor used when importing CycleCourier from CSV </para>
        /// <para>More specifically used with pre-determined ID and area</para>
        /// </summary>
        /// <param name="id">ID of CycleCourier</param>
        /// <param name="area">Assigned area of CycleCourier</param>
        public CycleCourier(string id, string area) : base (id)
        {
            base.AddArea(area);
            _maxCapacity = 10;
        }

        /// <summary>
        /// <para>Checks if CycleCourier has reached its max capacity for parcels</para>
        /// </summary>
        /// <returns>A boolean whether the CycleCourier is "full" of parcels</returns>
        public override bool IsFull()
        {
            return Parcels.Count >= _maxCapacity;
        }
    }
}
