using Coursework.business;
using Coursework.data;
using Coursework.exceptions;
using Coursework.presentation;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for AddParcel.xaml
    /// </summary>
    public partial class AddParcel : Window, IWindowManagement
    {
        private DeliverySystem _deliverySystem; //Current delivery system

        private Logger _logger; //Current logger

        private List<FormattedCourier> _availableCouriers;

        /// <summary>
        /// Base constructor for  AddParcel window
        /// </summary>
        public AddParcel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for AddParcel window
        /// </summary>
        /// <param name="deliverySystem">Current delivery system</param>
        /// <param name="logger">Current logger</param>
        public AddParcel(DeliverySystem deliverySystem, Logger logger) : this()
        {
            _deliverySystem = deliverySystem;
            _logger = logger;
            _availableCouriers = new List<FormattedCourier>();
        }


        /// <summary>
        /// Event handler for Add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAddressee.Text) && 
                !string.IsNullOrEmpty(txtArea.Text) && 
                !string.IsNullOrEmpty(txtDeliveryId.Text))
            {
                if (_availableCouriers.Count != 0)
                {
                    lstCouriers.ItemsSource = _availableCouriers;
                    lstCouriers.IsEnabled = true;
                } else
                {
                    MessageBox.Show("No courier available for entered area.\n" +
                        "Please ensure that the correct area has been entered (ex. EH4)", "No courier available", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                MessageBox.Show("Enter all the details!!");
            }
        }

        /// <summary>
        /// Event handler for when area and delivery id has been entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPostcode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtArea.Text))
            {
                _availableCouriers.Clear();
                foreach (Courier courier in _deliverySystem.Couriers.Values)
                {
                    foreach (string area in courier.Areas)
                    {
                        if (area.Equals(txtArea.Text.ToUpper()))
                        {
                            _availableCouriers.Add(new FormattedCourier
                            {
                                Type = courier.GetType().Name,
                                Capacity = $"{courier.Parcels.Count}/{courier.MaxCapacity}",
                                CourierId = courier.Id
                            });
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for confirm button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            //Check
            if (!string.IsNullOrEmpty(txtAddressee.Text) 
                && !string.IsNullOrEmpty(txtArea.Text)
                && !string.IsNullOrEmpty(txtDeliveryId.Text))
            {
                try
                {
                    //Add parcel, add entry to log and notify the logger to save. 
                    _deliverySystem.AddParcel(txtArea.Text.ToUpper(), txtDeliveryId.Text.ToUpper(), txtAddressee.Text, _availableCouriers[lstCouriers.SelectedIndex].CourierId);
                    MessageBox.Show("Added parcel", "Successful insert", MessageBoxButton.OK, MessageBoxImage.Information);
                    _logger.AddEntry($"Added new parcel: {txtArea.Text.ToUpper()} {txtDeliveryId.Text.ToUpper()}, {txtAddressee.Text}, assigned to courier: {_availableCouriers[lstCouriers.SelectedIndex].CourierId}");
                    ResetWindow();
                }
                catch (FullCourierException)
                {
                    MessageBox.Show("Fully occupied courier, please select another one", "Fully occupied courier", MessageBoxButton.OK, MessageBoxImage.Error);
                    _logger.AddEntry($"Exception: FullCourierException - Failed to add parcel to courier: {_availableCouriers[lstCouriers.SelectedIndex].CourierId}");

                }
                catch (InvalidDeliveryIdException)
                {
                    MessageBox.Show("Invalid Delivery Id. \n " +
                   "Insert a valid id with 1 number and 2 letters (ex. 2DY)", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
                    _logger.AddEntry($"Exception: InvalidDeliveryIdException - Invalid delivery id entered: {txtDeliveryId.Text}");

                }
                finally
                {
                    _deliverySystem.Notify();
                }
            }

        }

        /// <summary>
        /// Event handler for when courier has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstCouriers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnConfirm.IsEnabled = true;
        }

        /// <summary>
        /// Maintenance method which resets the window to its original state
        /// </summary>
        public void ResetWindow()
        {
            txtAddressee.Clear();
            txtArea.Clear();
            txtDeliveryId.Clear();
            lstCouriers.IsEnabled = false;
            lstCouriers.ItemsSource = null;
            btnConfirm.IsEnabled = false;
        }
    }
}
