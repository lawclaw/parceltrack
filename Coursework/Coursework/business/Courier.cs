using Coursework.exceptions;
using System;
using System.Collections.Generic;

namespace Coursework.business
{
    /// <summary>
    /// Abstract class representing a courier
    /// </summary>
    public abstract class Courier : IToCSV
    {
        private string _id; //Unique ID, identifying the Courier
        private List<Parcel> _parcels;  //List of parcels
        private List<string> _areas; //List of assigne areas
        protected List<string> _validAreas { get; } //List of valid areas 
        protected int _maxCapacity; //The maximum number of parcels the Courier can manage

        /// <summary>
        /// Public property for _maxCapacity
        /// Getter only
        /// </summary>
        public int MaxCapacity { get { return _maxCapacity; }}

        /// <summary>
        /// Public property for _id 
        /// Getter only
        /// </summary>
        public string Id { get { return _id; }}

        /// <summary>
        /// Public property for _areas
        /// Getter only
        /// </summary>
        public List<string> Areas { get { return _areas; }}

        /// <summary>
        /// Public property for _parcels
        /// Getter only
        /// </summary>
        public List<Parcel> Parcels {get { return _parcels; }}

        /// <summary>
        /// <para>Constructor used when creating a new Courier</para>
        /// <para>ID generated using Guid</para>
        /// </summary>
        /// <param name="couriers">Dictionary of pre-existing Couriers</param>
        public Courier(Dictionary<string, Courier> couriers) : this()
        {
            _id = Guid.NewGuid().ToString();
            while (couriers.ContainsKey(_id))   //Ensures that the newly generated id doesn't already exist
            {
                _id = Guid.NewGuid().ToString();
            }
        }

        /// <summary>
        /// Constructor used when importing Courier from CSV
        /// </summary>
        /// <param name="id">A string containing the ID of the Courier</param>
        public Courier(string id) : this()
        {
            _id = id;
        }

        /// <summary>
        /// Base constructor that defines all other class attributes
        /// </summary>
        public Courier()
        {
            _parcels = new List<Parcel>();
            _areas = new List<string>();
            _validAreas = new List<string>();

            for (int i = 0; i < 22; i++)
            {
                int j = i + 1;
                _validAreas.Add("EH" + j);
            }
        }


        /// <summary>
        /// Abstract method to check if Courier has reached its max capacity
        /// </summary>
        /// <returns>A boolean whether the Courier is "full" of parcels</returns>
        public abstract bool IsFull();

        /// <summary>
        /// Assigns an area to Courier
        /// </summary>
        /// <param name="area">The area</param>
        public void AddArea(string area)
        {
            _areas.Add(area);
        }

        /// <summary>
        /// Assigns a list of areas to Courier
        /// </summary>
        /// <param name="areas">The area</param>
        public void AddAreas(List<string> areas)
        {
            _areas = areas;
        }

        /// <summary>
        /// Adds a parcel to the parcel list
        /// </summary>
        /// <param name="p">Parcel to be added in the parcel list</param>
        public void AddParcel(Parcel p)
        {
            //Needs checking if it is EH1-EH4
            if (!IsFull())
            {
                _parcels.Add(p);
            }
            else
            {
                throw new FullCourierException();
            }
        }
        /// <summary>
        /// Removes a parcel from the parcel list
        /// </summary>
        /// <param name="p">Parcel to be remove from the parcel list</param>
        public void RemoveParcel(Parcel p)
        {
            //Needs checking if it is EH1-EH4
            if (_parcels.Count != 0)
            {
                _parcels.Remove(p);
            }
        }
        /// <summary>
        /// <para>Generates a string based on current instance, in CSV format</para>
        /// <para>CSV Format: Type, Id, Areas</para>
        /// </summary>
        /// <returns>String in CSV format</returns>
        public string ToCSV()
        {
            string output = $"{GetType().Name},{Id}";
            foreach (string area in _areas)
            {
                output = $"{output},{area}";
            }
            return output;
        }
        
    }
}
