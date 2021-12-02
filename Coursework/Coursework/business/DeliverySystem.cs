using System.Collections.Generic;
using System.Linq;

//Adds the data layer and exceptions
using Coursework.data;
using Coursework.exceptions;

namespace Coursework.business
{
    /// <summary>
    /// Class representing a parcel delivery system
    /// <para>Design pattern: Observer - subject</para>
    /// </summary>
    public class DeliverySystem : Subject
    {
        private Dictionary<string, Courier> _couriers;  //Data structure for storing couriers in the system
        private Dictionary<string, Parcel> _parcels;    //Data structure for storing parcels in the system

        private readonly Store _store;  // "Facade" class handling file I/O

        /// <summary>
        /// Public property for _parcels
        /// Getter only
        /// </summary>
        public Dictionary<string, Parcel> Parcels
        {
            get
            {
                return _parcels;
            }
        }

        /// <summary>
        /// Public property for _couriers
        /// Getter only
        /// </summary>
        public Dictionary<string,Courier> Couriers
        {
            get
            {
                return _couriers;
            }
        }
        
        /// <summary>
        /// <para>Constructor</para>
        /// <para>Defines attributes by calling import method</para>
        /// </summary>
        public DeliverySystem() : base()
        {
            _store = Store.GetInstance();
            ImportFromCSV();
        }
        /// <summary>
        /// <para>Calls export method from Store</para>
        /// </summary>
        public void ExportToCSV()
        {
            _store.Save(_couriers, _parcels);
        }

        /// <summary>
        /// <para>Calls import methods from Store</para>
        /// <para>Loads couriers, parcels and then links them together</para>
        /// </summary>
        public void ImportFromCSV()
        {
            _couriers = _store.LoadCouriers();
            _parcels = _store.LoadParcels();
            _store.LinkCourierAndParcel(ref _couriers, _parcels);
        }

        /// <summary>
        /// <para>Transfers a parcel between two couriers </para> 
        /// </summary>
        /// <param name="oldCourierId">Courier ID to transfer parcel from</param>
        /// <param name="newCourierId">Courier ID to transfer parcel to</param>
        /// <param name="parcelId">Parcel ID of parcel to be transferred</param>
        public void TransferParcel(string oldCourierId, string newCourierId, string parcelId)
        {
            _parcels[parcelId].ChangeCourier(newCourierId);
            try
            {
                _couriers[newCourierId].AddParcel(_parcels[parcelId]);
                _couriers[oldCourierId].RemoveParcel(_parcels[parcelId]);
            }
            catch (FullCourierException)
            {
                throw new FullCourierException();
            }
        }

        /// <summary>
        /// (Creates) and assigns a parcel to a courier
        /// </summary>
        /// <param name="area">Area of destination (first part of postcode) </param>
        /// <param name="deliveryId">Delivery ID of destionation (second part of postcode)</param>
        /// <param name="addressee">Addressee line of parcel</param>
        /// <param name="courierId">ID of courier to assign</param>
        public void AddParcel(string area, string deliveryId, string addressee, string courierId)
        {
            try
            {
                Parcel parcel = new Parcel(area.ToUpper(), deliveryId.ToUpper(), addressee, courierId);
                _couriers[courierId].AddParcel(parcel);
                _parcels.Add(parcel.Id, parcel);
            }
            catch (FullCourierException)
            {
                throw new FullCourierException();
            }
            catch (InvalidDeliveryIdException)
            {
                throw new InvalidDeliveryIdException();
            }

        }

        /// <summary>
        /// (Creates) and adds a courier to the delivery system
        /// </summary>
        /// <param name="type">Type of courier to be created</param>
        /// <param name="areas">Area(s) to be assigned to courier</param>
        public void AddCourier(string type, string areas)
        {
            string[] areaInput = areas.Split(',');
            switch (type)
            {
                case "Van":
                    try
                    {
                        VanCourier courier = new VanCourier(areaInput.ToList<string>(), _couriers);
                        _couriers.Add(courier.Id, courier);
                    }
                    catch (InvalidAreaException)
                    {
                        throw new InvalidAreaException();
                    }
                    break;
                case "Cycle":
                    if (areaInput.Length == 1)
                    {
                        try
                        {
                            CycleCourier courier = new CycleCourier(areaInput[0], _couriers);
                            _couriers.Add(courier.Id, courier);
                        }
                        catch (InvalidAreaException)
                        {
                            throw new InvalidAreaException();
                        }
                    } else
                    {
                        throw new TooManyAreasException();
                    }
                    break;
                case "Walking":
                    if (areaInput.Length == 1)
                    {
                        try
                        {
                            WalkingCourier courier = new WalkingCourier(areaInput[0], _couriers);
                            _couriers.Add(courier.Id, courier);
                        }
                        catch (InvalidAreaException)
                        {
                            throw new InvalidAreaException();
                        }
                    }
                    else
                    {
                        throw new TooManyAreasException();
                    }
                    break;
            }
        }

        /// <summary>
        /// <para>Notify method for DeliverySystem observers</para>
        /// <para>Notifies all observers whenever the method is called</para>
        /// </summary>
        public override void Notify()
        {
            base.Notify();
            ExportToCSV();
        }
    } 

}
