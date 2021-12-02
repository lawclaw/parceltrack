using System.Windows;

using Coursework.business;
using Coursework.data;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DeliverySystem _deliverySystem; //Current Delivery system instance

        private Logger _logger; //Current logger instance

        /// <summary>
        /// <para>Base constructor for MainWindow</para>
        /// <para>Defines attributes</para>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _deliverySystem = new DeliverySystem();
            _logger = Logger.GetInstance(_deliverySystem);
            _deliverySystem.Attach(_logger);
        }

        /// <summary>
        /// Event handler for when AddCourier button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCourier_Click(object sender, RoutedEventArgs e)
        {
            AddCourier addCourier = new AddCourier(_deliverySystem, _logger);
            addCourier.ShowDialog();
        }

        /// <summary>
        /// Event handler for when Transfer button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            Transfer transfer = new Transfer(_deliverySystem, _logger);
            transfer.ShowDialog();
        }

        /// <summary>
        /// Event handler for when AddParcel button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddParcel_Click(object sender, RoutedEventArgs e)
        {
            AddParcel addParcel = new AddParcel(_deliverySystem, _logger);
            addParcel.ShowDialog();
        }

        /// <summary>
        /// Event handler for when DeliveryList button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeliveryList_Click(object sender, RoutedEventArgs e)
        {
            DeliveryList deliveryList = new DeliveryList(_deliverySystem, _logger);
            deliveryList.ShowDialog();
        }

        /// <summary>
        /// Event handler for when Show status button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            ShowCourier showCourier = new ShowCourier(_deliverySystem);
            showCourier.ShowDialog();
        }

        /// <summary>
        /// Event handler for when Save button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _deliverySystem.ExportToCSV();
            MessageBox.Show("Saved to CSV file", "Save to CSV", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Event handler for when Load button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            _deliverySystem.ImportFromCSV();
            MessageBox.Show("Loaded from CSV file", "Load from CSV", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
