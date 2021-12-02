using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.business
{
    /// <summary>
    /// <para>Abstract base class for Observer pattern - Observer</para>
    /// <para>Design Pattern: Observer</para>
    /// </summary>
    public abstract class Observer
    {
        /// <summary>
        /// Abstract method for updating once the observer is notifed
        /// </summary>
        public abstract void Update();
    }
}
