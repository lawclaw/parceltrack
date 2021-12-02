using Coursework.business;
using Coursework.presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for ShowCourier.xaml
    /// </summary>
    public partial class ShowCourier : Window
    {
        private DeliverySystem _deliverySystem; //Current delivery system

        /// <summary>
        /// Base constructor for ShowCourier window
        /// </summary>
        public ShowCourier()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for ShowCourier window
        /// </summary>
        /// <param name="deliverySystem">Current delivery system</param>
        public ShowCourier(DeliverySystem deliverySystem) : this()
        {
            _deliverySystem = deliverySystem;
        }

        /// <summary>
        /// Event handler for when update button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            List<Courier> couriers = _deliverySystem.Couriers.Values.ToList();
            List<FormattedCourier> formatted = new List<FormattedCourier>();
            foreach (Courier c in couriers)
            {
                formatted.Add(new FormattedCourier 
                { 
                    Area = String.Join(',', c.Areas), 
                    Type = c.GetType().Name, 
                    Capacity = $"{c.Parcels.Count}/{c.MaxCapacity}",
                    CourierId = c.Id
                });
            }
            lstShow.ItemsSource = formatted;
            lstShow.IsEnabled = true;

            btnUpdate.IsEnabled = false;
        }
    }
}
