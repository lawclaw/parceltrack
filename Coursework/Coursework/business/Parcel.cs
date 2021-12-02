using Coursework.exceptions;
using System;

namespace Coursework.business
{
    /// <summary>
    /// Class representing a parcel
    /// </summary>
    public class Parcel : IToCSV
    {
        private string _id;         //Unique ID for parcel
        private string _area;       //Destination area
        private string _deliveryId; //Destination delivery ID

        private string _addressee;  //Addressee line of parcel

        private string _courierId;  //Assigned courier (ID)

        /// <summary>
        /// <para>Constructor used when creating a new parcel</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="area"></param>
        /// <param name="deliveryId"></param>
        /// <param name="addressee"></param>
        /// <param name="courierId"></param>
        public Parcel(string area, string deliveryId, string addressee, string courierId)
        {
            char[] deliveryIdChars = deliveryId.ToCharArray();
            if (deliveryIdChars.Length == 3 && 
                Char.IsDigit(deliveryIdChars[0]) &&
                Char.IsLetter(deliveryIdChars[1]) &&
                Char.IsLetter(deliveryIdChars[2]))
            {
                _deliveryId = deliveryId;
            } 
            else
            {
                throw new InvalidDeliveryIdException();
            }

            _id = Guid.NewGuid().ToString();
            _area = area;
            _addressee = addressee;
            _courierId = courierId;
        }

        /// <summary>
        /// Constructor used when importing a parcel from CSV
        /// </summary>
        /// <param name="id">Id of parcel</param>
        /// <param name="area">Area of parcel destination (first part of postcode)</param>
        /// <param name="deliveryId">Delivery ID of parcel destination (second part of postcode)</param>
        /// <param name="addressee">Addressee line of parcel</param>
        /// <param name="courierId">ID of assigned courier</param>
        public Parcel(string id, string area, string deliveryId, string addressee, string courierId)
        {
            _id = id;
            _area = area;
            _deliveryId = deliveryId;
            _addressee = addressee;
            _courierId = courierId;
        }

        /// <summary>
        /// Public property for _id 
        /// Getter only
        /// </summary>
        public string Id { get { return _id; }}

        /// <summary>
        /// Public property for _area
        /// Getter only
        /// </summary>
        public string Area { get { return _area; }}

        /// <summary>
        /// Public property for _deliveryId 
        /// Getter only
        /// </summary>
        public string DeliveryId { get { return _deliveryId; }}

        /// <summary>
        /// Public property for _courierId 
        /// Getter only
        /// </summary>
        public string CourierId { get { return _courierId; }}

        /// <summary>
        /// Public property for _addressee
        /// Getter only
        /// </summary>
        public string Addressee { get { return _addressee; }}

        /// <summary>
        /// <para>Generates a string based on current instance, in CSV format</para>
        /// <para>CSV Format: ID, Area, DeliveryId, Addressee, Courier ID</para>
        /// </summary>
        /// <returns>String in CSV format</returns>
        public string ToCSV()
        {
            return $"{_id},{_area},{_deliveryId},\"{_addressee}\",{_courierId}";
        }

        /// <summary>
        /// Changes assigned courier of parcel
        /// </summary>
        /// <param name="courierId">Courier ID of the new courier</param>
        public void ChangeCourier(string courierId)
        {
            _courierId = courierId;
        }
    }
}
