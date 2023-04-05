using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ShowCustomersBillsUserControl.xaml
    /// </summary>
    public partial class ShowCustomersBillsUserControl : UserControl
    {
        Main_Window Main_Window;
        Context context = new Context();
        public ShowCustomersBillsUserControl()
        {
            InitializeComponent();
            Loaded += ShowCustomersBillsUserControl_Loaded;
        }

        private void ShowCustomersBillsUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Main_Window = new Main_Window();
            FillCustomersBillsCoboBox();
        }

        private void btnCustomersBillsShow_Click(object sender, RoutedEventArgs e)
        {
            CustomerOrder customerOrder = lvCustomersBills.SelectedItem as CustomerOrder;
            if (customerOrder != null)
            {
                Main_Window.window.Main.Content = new ShowCustomerBillDetailesUserControl(customerOrder);
            }
        }

        private void FillCustomersBillsCoboBox()
        {
            comboCustomersBills.ItemsSource = context.Customers.ToList();
            SetCustomersBillsComboBox();
            FillCustomersBillsListViewWithAllCustomersBills();
        }
        private void comboCustomersBills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeCustomersBillsListViewContent();
        }

        private void ChangeCustomersBillsListViewContent()
        {
            if ((bool)chkCustomersBills.IsChecked)
            {
                FillCustomersBillsListViewWithSingleCustomerBills();
            }
            else
            {
                FillCustomersBillsListViewWithAllCustomersBills();
            }
        }

        private void FillCustomersBillsListViewWithAllCustomersBills()
        {
            List<CustomerOrder> bills = context.CustomerOrders
                .Include(so => so.Customer)
                .Include(so => so.Inventory)
                .Include(so => so.User)
                .Include(so => so.CustomerProductBills)
                .ThenInclude(spb => spb.Product)
                .Include(so => so.ReturnCustomerOrders)
                .ThenInclude(rco => rco.ReturnCustomerProducts)
                .ToList();

            lvCustomersBills.ItemsSource = bills;
        }

        private void FillCustomersBillsListViewWithSingleCustomerBills()
        {
            Customer Customer = comboCustomersBills.SelectedItem as Customer;

            if (Customer != null)
            {
                List<CustomerOrder> bills = context.CustomerOrders
                    .Where(so => so.Customer == Customer)
                    .Include(so => so.Customer)
                    .Include(so => so.Inventory)
                    .Include(so => so.User)
                    .Include(so => so.CustomerProductBills)
                    .ThenInclude(spb => spb.Product)
                    .Include(so => so.ReturnCustomerOrders)
                    .ThenInclude(rco => rco.ReturnCustomerProducts)
                    .ToList();

                lvCustomersBills.ItemsSource = bills;
            }
        }

        private void chkCustomersBills_Checked(object sender, RoutedEventArgs e)
        {
            ChangeCustomersBillsListViewContent();
            SetCustomersBillsComboBox();
        }

        private void SetCustomersBillsComboBox()
        {
            if ((bool)chkCustomersBills.IsChecked)
            {
                comboCustomersBills.IsEnabled = true;
            }
            else
            {
                comboCustomersBills.IsEnabled = false;
            }
        }
    }
}
