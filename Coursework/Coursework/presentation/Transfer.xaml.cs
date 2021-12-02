using Coursework.business;
using Coursework.data;
using Coursework.exceptions;
using Coursework.presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for Transfer.xaml
    /// </summary>
    public partial class Transfer : Window
    {
        private DeliverySystem _deliverySystem; //Current delivery system

        private Logger _logger; //Current logger

        private List<Parcel> _parcels; //Data structure storing all available parcels in the delivery system

        private List<FormattedParcel> _formattedParcels;    //Data structure storing formatted parcels

        private List<FormattedCourier> _formattedCouriers;  //Data structure storing formatted couriers

        /// <summary>
        /// Base constructor for Transfer window
        /// </summary>
        public Transfer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for Transfer window
        /// </summary>
        /// <param name="deliverySystem">Current delivery system</param>
        /// <param name="logger">Current logger</param>
        public Transfer(DeliverySystem deliverySystem, Logger logger) : this()
        {
            _deliverySystem = deliverySystem;
            _logger = logger;
            _parcels = _deliverySystem.Parcels.Values.ToList();
            _formattedParcels = new List<FormattedParcel>();
            foreach (Parcel p in _parcels)
            {
                _formattedParcels.Add(new FormattedParcel { ParcelId = p.Id, Area = p.Area, DeliveryId = p.DeliveryId, Addressee = p.Addressee, CourierId = p.CourierId });
            }
            lstFrom.ItemsSource = _formattedParcels;
        }

        /// <summary>
        /// Event handler for when check button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            string selectedArea = _formattedParcels[lstFrom.SelectedIndex].Area;
            string oldCourierId = _formattedParcels[lstFrom.SelectedIndex].CourierId;

            List<Courier> couriers = _deliverySystem.Couriers.Values.ToList();
            _formattedCouriers = new List<FormattedCourier>();
            foreach (Courier c in couriers)
            {
                if (!oldCourierId.Equals(c.Id))
                {
                    foreach (string area in c.Areas){
                        if (area.Equals(selectedArea))
                        {
                            _formattedCouriers.Add(new FormattedCourier
                            {
                                Area = String.Join(',', c.Areas),
                                Type = c.GetType().Name,
                                Capacity = $"{c.Parcels.Count}/{c.MaxCapacity}",
                                CourierId = c.Id
                            });
                        }
                    }

                }
            }
            lstTo.ItemsSource = _formattedCouriers;
            lstTo.IsEnabled = true;
        }

        /// <summary>
        /// Event handler for when transfer button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            string oldCourierId = _formattedParcels[lstFrom.SelectedIndex].CourierId;
            string newCourierId = _formattedCouriers[lstTo.SelectedIndex].CourierId;
            string parcelId = _formattedParcels[lstFrom.SelectedIndex].ParcelId;

            try
            {
                _deliverySystem.TransferParcel(oldCourierId, newCourierId, parcelId);
                MessageBox.Show("Transferred parcel", "Successful transfer", MessageBoxButton.OK, MessageBoxImage.Information);
                _logger.AddEntry($"Successful transfer of parcel: {parcelId}, from courier: {oldCourierId}, to courier: {newCourierId}");
                this.Close();
            }
            catch (FullCourierException)
            {
                MessageBox.Show("Fully occupied courier, please select another one", "Fully occupied courier", MessageBoxButton.OK, MessageBoxImage.Error);
                _logger.AddEntry($"Exception: FullCourier - Failed transfer of parcel:{parcelId} from courier:{oldCourierId} to courier:{newCourierId}");

            }
            finally
            {
                _deliverySystem.Notify();
            }
        }

        /// <summary>
        /// Event handler for when a parcel has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!btnCheck.IsEnabled)
            {
                btnCheck.IsEnabled = true;
            }
        }

        /// <summary>
        /// Event handler for when a courier has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!btnTransfer.IsEnabled)
            {
                btnTransfer.IsEnabled = true;
            }
        }
    }
}
