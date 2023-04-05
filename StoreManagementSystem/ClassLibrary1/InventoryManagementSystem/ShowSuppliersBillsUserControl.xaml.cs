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
    /// Interaction logic for ShowSuppliersBillsUserControl.xaml
    /// </summary>
    public partial class ShowSuppliersBillsUserControl : UserControl
    {
        Main_Window Main_Window;
        Context context = new Context();
        public ShowSuppliersBillsUserControl()
        {
            InitializeComponent();
            Loaded += ShowSuppliersBillsUserControl_Loaded;
        }

        private void ShowSuppliersBillsUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Main_Window = new Main_Window();
            FillSuppliersBillsCoboBox();
        }

        private void FillSuppliersBillsCoboBox()
        {
            comboSuppliersBills.ItemsSource = context.Suppliers.ToList();
            SetSuppliersBillsComboBox();
            FillSuppliersBillsListViewWithAllSuppliersBills();
        }
        private void btnSuppliersBillsShow_Click(object sender, RoutedEventArgs e)
        {
            SupplierOrder supplierOrder = lvSuppliersBills.SelectedItem as SupplierOrder;
            if (supplierOrder != null)
            {
                Main_Window.window.Main.Content = new ShowSupplierBillDetailsUserControl(supplierOrder);
            }
            
        }
        private void comboSuppliersBills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeSuppliersBillsListViewContent();
        }

        private void ChangeSuppliersBillsListViewContent()
        {
            if ((bool)chkSuppliersBills.IsChecked)
            {
                FillSuppliersBillsListViewWithSingleSupplierBills();
            }
            else
            {
                FillSuppliersBillsListViewWithAllSuppliersBills();
            }
        }

        private void FillSuppliersBillsListViewWithAllSuppliersBills()
        {
            List<SupplierOrder> bills = context.SupplierOrders
                .Include(so => so.Supplier)
                .Include(so => so.Inventory)
                .Include(so => so.User)
                .Include(so => so.SupplierProductBills)
                .ThenInclude(spb => spb.Product)
                .Include(so => so.ReturnSupplierOrders)
                .ThenInclude(rso => rso.ReturnSupplierProducts)
                .ToList();

            lvSuppliersBills.ItemsSource = bills;
        }

        private void FillSuppliersBillsListViewWithSingleSupplierBills()
        {
            Supplier supplier = comboSuppliersBills.SelectedItem as Supplier;

            if (supplier != null)
            {
                List<SupplierOrder> bills = context.SupplierOrders
                    .Where(so => so.Supplier == supplier)
                    .Include(so => so.Supplier)
                    .Include(so => so.Inventory)
                    .Include(so => so.User)
                    .Include(so => so.SupplierProductBills)
                    .ThenInclude(spb => spb.Product)
                    .Include(so => so.ReturnSupplierOrders)
                    .ThenInclude(rso => rso.ReturnSupplierProducts)
                    .ToList();

                lvSuppliersBills.ItemsSource = bills;
            }
        }

        private void chkSuppliersBills_Checked(object sender, RoutedEventArgs e)
        {
            ChangeSuppliersBillsListViewContent();
            SetSuppliersBillsComboBox();
        }

        private void SetSuppliersBillsComboBox()
        {
            if ((bool)chkSuppliersBills.IsChecked)
            {
                comboSuppliersBills.IsEnabled = true;
            }
            else
            {
                comboSuppliersBills.IsEnabled = false;
            }
        }
    }
}
