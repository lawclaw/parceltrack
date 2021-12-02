using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework.presentation
{
    /// <summary>
    /// View model class used for representing parcels in GUI
    /// </summary>
    public class FormattedParcel
    {
        /// <summary>
        /// Public properties
        /// Getter/setter
        /// </summary>
        public string ParcelId { get; set; }
        public string Area { get; set; }
        public string DeliveryId { get; set; }
        public string Addressee { get; set; }
        public string CourierId { get; set; }
    }
}
