using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Interaction logic for CustomerRemainUserControl.xaml
    /// </summary>
    public partial class CustomerRemainUserControl : UserControl
    {
        Context context = new Context();
        public CustomerRemainUserControl()
        {
            InitializeComponent();
        }

        private void btnSearchForCustomer_Click(object sender, RoutedEventArgs e)
        {
            SearchByCustomerName();
        }

        private void SearchByCustomerName()
        {
            string customerName = txtSearchForCustomerName.Text.Trim();
            if (customerName == null)
            {
                MessageBox.Show("Please Enter Customer Name");
                return;
            }

            List<Customer> customers = context.Customers
                .Where(s => s.Name.ToLower().Contains(customerName.ToLower()))
                .ToList();

            lvSearchForCustomer.ItemsSource = customers;
        }
        private void lvSearchForCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer customer = lvSearchForCustomer.SelectedItem as Customer;

            if (customer == null)
            {
                return;
            }

            txtSearchForCustomerSelectedName.Text = customer.Name;
            txtSearchForCustomerSelectedRemain.Text = customer.Remain.ToString();
        }
    }
}
