using Coursework.business;
using Coursework.data;
using Coursework.presentation;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for DeliveryList.xaml
    /// </summary>
    public partial class DeliveryList : Window
    {
        private DeliverySystem _deliverySystem; //Current delivery system

        private Logger _logger; //Current logger

        private List<FormattedCourier> _formattedCouriers;  //Data structure for storing formatted couriers
        private List<FormattedParcel> _formattedParcels;    //Data structure for storing formatted parcels

        /// <summary>
        /// Base constructor for DeliveryList window 
        /// </summary>
        public DeliveryList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for DeliveryList window
        /// </summary>
        /// <param name="deliverySystem">Current delivery system</param>
        /// <param name="logger">Current logger</param>
        public DeliveryList(DeliverySystem deliverySystem, Logger logger) : this()
        {
            _deliverySystem = deliverySystem;
            _logger = logger;

            _formattedCouriers = new List<FormattedCourier>();
            foreach (Courier c in _deliverySystem.Couriers.Values)
            {
                _formattedCouriers.Add(new FormattedCourier
                {
                    Area = String.Join(',', c.Areas),
                    Type = c.GetType().Name,
                    Capacity = $"{c.Parcels.Count}/{c.MaxCapacity}",
                    CourierId = c.Id
                });
            }
            lstCouriers.ItemsSource = _formattedCouriers;
        }

        /// <summary>
        /// Event handler for Generate List button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string selectedCourierId = _formattedCouriers[lstCouriers.SelectedIndex].CourierId;
            if (_deliverySystem.Couriers[selectedCourierId].Parcels.Count == 0)
            {
                MessageBox.Show("Empty parcel list.\n" +
                   "Choose a courier with parcels!", "Empty parcel list", MessageBoxButton.OK, MessageBoxImage.Error);
                _logger.AddEntry($"Exception: Courier {selectedCourierId} has no parcels to deliver");
            }
            else
            {
                _formattedParcels = new List<FormattedParcel>();
                foreach (Parcel p in _deliverySystem.Couriers[selectedCourierId].Parcels)
                {
                    _formattedParcels.Add(new FormattedParcel
                    {
                        Area = p.Area,
                        DeliveryId = p.DeliveryId,
                        Addressee = p.Addressee
                    });
                }
                _logger.AddEntry($"Generated delivery list for courier: {selectedCourierId}");
                lstDelivery.ItemsSource = _formattedParcels;
                btnGenerate.IsEnabled = false;
            }
            _deliverySystem.Notify();

        }

        /// <summary>
        /// Event handler for when a courier has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstCouriers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnGenerate.IsEnabled = true;
        }
    }
}
