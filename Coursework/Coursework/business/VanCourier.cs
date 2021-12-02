using Coursework.exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Coursework.business
{
    /// <summary>
    /// Class representing a van courier
    /// </summary>
    public class VanCourier: Courier
    {
        /// <summary>
        /// <para>Constructor used when creating a new VanCourier</para>
        /// </summary>
        /// <param name="areas">Area(s) to be assigned to courier</param>
        /// <param name="couriers">Pre-existing couriers</param>
        public VanCourier(List<string> areas, Dictionary<string, Courier> couriers) : base (couriers)
        {
            bool validAreasEntered = true;
            foreach (string area in areas)
            {
                if (!_validAreas.Any(a => a == area))
                {
                    validAreasEntered = false;
                }

            }
            if (validAreasEntered)
            {
                base.AddAreas(areas);
            }
            else
            {
                throw new InvalidAreaException();
            }
            _maxCapacity = 100;

        }
        /// <summary>
        /// <para>Constructor used when importing VanCourier from CSV </para>
        /// <para>More specifically used with pre-determined ID and area(s)</para>
        /// </summary>
        /// <param name="id">ID of VanCourier</param>
        /// <param name="area">Assigned area(s) of VanCourier</param>
        public VanCourier(string id, List<string> areas) : base (id)
        {
            AddAreas(areas);
            _maxCapacity = 100;

        }

        /// <summary>
        /// <para>Checks if VanCourier has reached its max capacity for parcels</para>
        /// </summary>
        /// <returns>A boolean whether the VanCourier is "full" of parcels</returns>
        public override bool IsFull()
        {
            return Parcels.Count >= _maxCapacity;
        }
    }
}
