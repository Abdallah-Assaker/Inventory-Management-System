using MahApps.Metro.Controls;
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
    /// Interaction logic for SupplierUserControl.xaml
    /// </summary>
    public partial class SupplierUserControl : UserControl
    {
        Context context = new Context();
        public SupplierUserControl()
        {
            InitializeComponent();
            Loaded += SupplierUserControl_Loaded;
        }

        private void SupplierUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SupplierPage_FillSuppliersListView();        
        }
        private async void SupplierPage_FillSuppliersListView()
        {
            await Task.Run(() =>
            {
                List<Supplier> suppliers = context.Suppliers.ToList();
                this.BeginInvoke(() => lvSuppliersPage.ItemsSource = suppliers);
            });

        }
        private void lvSuppliersPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SupplierPage_SelectSupplier();
        }
        private void SupplierPage_SelectSupplier()
        {
            Supplier supplier = lvSuppliersPage.SelectedItem as Supplier;

            if (supplier != null)
            {
                txtSupplierPageName.Text = supplier.Name;
                txtSupplierPhone.Text = supplier.Phone;
            }
        }
        private void btnAddSupplierPage_Click(object sender, RoutedEventArgs e)
        {
            AddSupplier();
        }

        private void btnUpdateSupplierPage_Click(object sender, RoutedEventArgs e)
        {
            UpdateSupplier();
        }

        private void btnDelSupplierPage_Click(object sender, RoutedEventArgs e)
        {
            DeleteSupplier();
        }
        private void AddSupplier()
        {
            if (txtSupplierPageName.Text != string.Empty && txtSupplierPhone.Text != string.Empty)
            {
                Supplier supplier = new Supplier()
                {
                    Name = txtSupplierPageName.Text,
                    Phone = txtSupplierPhone.Text,
                };

                context.Suppliers.Add(supplier);
                context.SaveChanges();
                SupplierPage_FillSuppliersListView();
                SuppliersPage_EmptyInputs();
            }
        }

        private void UpdateSupplier()
        {
            Supplier supplier = lvSuppliersPage.SelectedItem as Supplier;
            if (supplier == null)
            {
                return;
            }

            if (txtSupplierPageName.Text != string.Empty && txtSupplierPhone.Text != string.Empty)
            {
                supplier.Name = txtSupplierPageName.Text;
                supplier.Phone = txtSupplierPhone.Text;

                context.SaveChanges();
                SupplierPage_FillSuppliersListView();
                SuppliersPage_EmptyInputs();
            }
        }
        private void DeleteSupplier()
        {
            Supplier supplier = lvSuppliersPage.SelectedItem as Supplier;

            if (supplier != null)
            {
                context.Suppliers.Remove(supplier);
                context.SaveChanges();
                SupplierPage_FillSuppliersListView();
                SuppliersPage_EmptyInputs();
            }
        }

        private void SuppliersPage_EmptyInputs()
        {
            txtSupplierPhone.Text = txtSupplierPageName.Text = string.Empty;
        }

        
    }
}
