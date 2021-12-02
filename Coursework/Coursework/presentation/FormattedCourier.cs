using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework.presentation
{
    /// <summary>
    /// View model class used for representing couriers in GUI
    /// </summary>
    public class FormattedCourier
    {
        /// <summary>
        /// Public properties
        /// Getter/setter
        /// </summary>
        public string Area { get; set; }
        public string Type { get; set; }
        public string Capacity { get; set; }
        public string CourierId { get; set; }
    }
}
