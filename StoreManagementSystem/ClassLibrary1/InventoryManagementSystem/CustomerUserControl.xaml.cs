using MahApps.Metro.Controls;
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
    /// Interaction logic for CustomerUserControl.xaml
    /// </summary>
    public partial class CustomerUserControl : UserControl
    {
        Context context = new Context();
        public CustomerUserControl()
        {
            InitializeComponent();
            Loaded += CustomerUserControl_Loaded;
        }

        private void CustomerUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CustomersPage_FillCustomersListView();
        }

        private async void CustomersPage_FillCustomersListView()
        {
            await Task.Run(() =>
            {
                List<Customer> customers = context.Customers.ToList();
                this.BeginInvoke(() => lvCustomersPage.ItemsSource = customers);
            });
        }
        private void lvCustomersPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomerPage_SelectSupplier();
        }
        private void CustomerPage_SelectSupplier()
        {
            Customer customer = lvCustomersPage.SelectedItem as Customer;

            if (customer != null)
            {
                txtCustomerPageName.Text = customer.Name;
                txtCustomerPhone.Text = customer.Phone;
            }
        }
        private void btnAddCustomerPage_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer();
        }

        private void btnUpdateCustomerPage_Click(object sender, RoutedEventArgs e)
        {
            UpdateCustomer();
        }

        private void btnDelCusomerPage_Click(object sender, RoutedEventArgs e)
        {
            DeleteCustomer();
        }

        private void AddCustomer()
        {
            if (txtCustomerPageName.Text != string.Empty && txtCustomerPhone.Text != string.Empty)
            {
                Customer customer = new Customer()
                {
                    Name = txtCustomerPageName.Text,
                    Phone = txtCustomerPhone.Text,
                };

                context.Customers.Add(customer);
                context.SaveChanges();
                CustomersPage_FillCustomersListView();
                CustomersPage_EmptyInputs();
            }
        }

        private void UpdateCustomer()
        {
            Customer customer = lvCustomersPage.SelectedItem as Customer;
            if (customer == null)
            {
                return;
            }

            if (txtCustomerPageName.Text != string.Empty && txtCustomerPhone.Text != string.Empty)
            {
                customer.Name = txtCustomerPageName.Text;
                customer.Phone = txtCustomerPhone.Text;

                context.SaveChanges();
                CustomersPage_FillCustomersListView();
                CustomersPage_EmptyInputs();
            }
        }

        private void DeleteCustomer()
        {
            Customer Customer = lvCustomersPage.SelectedItem as Customer;

            if (Customer != null)
            {
                context.Customers.Remove(Customer);
                context.SaveChanges();
                CustomersPage_FillCustomersListView();
                CustomersPage_EmptyInputs();
            }
        }

        private void CustomersPage_EmptyInputs()
        {
            txtCustomerPhone.Text = txtCustomerPageName.Text = string.Empty;
        }

    }
}
