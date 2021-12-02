using System;
using System.Windows;
using System.Windows.Controls;

using Coursework.business;
using Coursework.data;
using Coursework.exceptions;
using Coursework.presentation;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for AddCourier.xaml
    /// </summary>
    public partial class AddCourier : Window, IWindowManagement
    {
        private DeliverySystem _deliverySystem; //Current delivery system

        private Logger _logger; //Current logger

        /// <summary>
        /// Base constructor for AddCourier window
        /// </summary>
        public AddCourier()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for AddCourier window
        /// </summary>
        /// <param name="deliverySystem">Current delivery system</param>
        /// <param name="logger">Current logger</param>
        public AddCourier(DeliverySystem deliverySystem, Logger logger) : this()
        {
           _deliverySystem = deliverySystem;
            _logger = logger;
        }

        /// <summary>
        /// Event handler for when Submit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _deliverySystem.AddCourier(comboType.Text, txtAreas.Text.ToUpper());
                MessageBox.Show($"Added {comboType.Text} courier", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Information);
                _logger.AddEntry($"Added courier - type: {comboType.Text}");
                ResetWindow();
            }
            catch (InvalidAreaException)
            {
                MessageBox.Show("Invalid areas", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
                _logger.AddEntry($"Exception: InvalidAreaException - invalid area entered \"{txtAreas.Text}\"");
            }
            catch (TooManyAreasException)
            {
                MessageBox.Show("Input one area", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
                _logger.AddEntry($"Exception: TooManyAreasException - too many areas entered \"{txtAreas.Text}\"");

            }
            finally
            {
                _deliverySystem.Notify();
            }
        }
        /// <summary>
        /// Event handler for when combobox selection is changed (closed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboType_DropDownClosed(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboType.Text))
            {
                txtAreas.IsEnabled = true;
                labelArea.IsEnabled = true;
            } 
        }

        /// <summary>
        /// Event handler for when text is entered into textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAreas_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboType.Text) || string.IsNullOrEmpty(txtAreas.Text))
            {
                btnAdd.IsEnabled = false;
            } else
            {
                btnAdd.IsEnabled = true;
            }
        }

        /// <summary>
        /// Maintenance method which resets the window to its original state
        /// </summary>
        public void ResetWindow()
        {
            txtAreas.Text = String.Empty;
            btnAdd.IsEnabled = false;
            comboType.SelectedIndex = -1;
        }
    }
}
