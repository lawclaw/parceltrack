using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.business
{
    /// <summary>
    /// <para>Abstract base class for Observer pattern - Subject</para>
    /// <para>Design Pattern: Observer</para>    
    /// </summary>
    public abstract class Subject
    {

        private List<Observer> _observers;  //Data structure to store observers

        /// <summary>
        /// <para>Constructor</para>
        /// <para>Defines attributes</para>
        /// </summary>
        public Subject()
        {
            _observers = new List<Observer>();
        }

        /// <summary>
        /// <para>Adds observer to subject</para>
        /// </summary>
        /// <param name="observer"></param>
        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        /// <summary>
        /// <para>Removes observer from subject</para>
        /// </summary>
        /// <param name="observer">Observer to be removed from subject</param>
        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        /// <summary>
        /// <para>Notify method</para>
        /// <para>Notifies all observers whenever the method is called</para>
        /// </summary>
        public virtual void Notify()
        {
            foreach (Observer o in _observers)
            {
                o.Update();
            }
        }

    }
}
