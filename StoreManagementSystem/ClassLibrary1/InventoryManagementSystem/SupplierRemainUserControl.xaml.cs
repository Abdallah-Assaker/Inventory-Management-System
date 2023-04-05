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
    /// Interaction logic for SupplierRemainUserControl.xaml
    /// </summary>
    public partial class SupplierRemainUserControl : UserControl
    {
        Context context = new Context();
        public SupplierRemainUserControl()
        {
            InitializeComponent();
        }

        private void btnSearchForSupplier_Click(object sender, RoutedEventArgs e)
        {
            SearchBySupplierName();

        }

        private void SearchBySupplierName()
        {
            string SupplierName = txtSearchForSupplierName.Text.Trim();
            if (SupplierName == null)
            {
                MessageBox.Show("Please Enter Supplier Name");
                return;
            }

            List<Supplier> Suppliers = context.Suppliers
                .Where(s => s.Name.ToLower().Contains(SupplierName.ToLower()))
                .ToList();

            lvSearchForSupplier.ItemsSource = Suppliers;
        }
        private void lvSearchForSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Supplier Supplier = lvSearchForSupplier.SelectedItem as Supplier;

            if (Supplier == null)
            {
                return;
            }

            txtSearchForSupplierSelectedName.Text = Supplier.Name;
            txtSearchForSupplierSelectedRemain.Text = Supplier.Remain.ToString();
        }
        
    }
}
