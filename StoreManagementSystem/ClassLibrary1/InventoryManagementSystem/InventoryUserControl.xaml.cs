using InventoryManagementSystem;
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
    /// Interaction logic for InventoryUserControl.xaml
    /// </summary>
    public partial class InventoryUserControl : UserControl
    {
        Context context = new Context();

        public InventoryUserControl()
        {
            InitializeComponent();
            FillCombo();
            //Loaded += InventoryUserControl_Loaded;
        }

        //private void InventoryUserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //}
        public void FillCombo()
        {
            Task.Run(() =>
            {
                List<Inventory> inventories = context.Inventories.Include(i => i.InventoryCategories).ToList();
                this.BeginInvoke(() => InventoryListView.ItemsSource = inventories);
            });
        }

        private void AddNewInventory_Click(object sender, RoutedEventArgs e)
        {
            Add_New_Inventory();
        }

        private void EditInventory_Click(object sender, RoutedEventArgs e)
        {
            Update_Inventory();
        }

        private void DeleteInventory_Click(object sender, RoutedEventArgs e)
        {
            Delete_Inventory();
        }

        private void Add_New_Inventory()                                         //////////
        {
            if (InventoryNameTxtBx.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Inventory Name");
            }

            context.Inventories.Add(new Inventory() { Location = InventoryNameTxtBx.Text.Trim() });

            context.SaveChanges();

            FillInventoryListView();
        }

        private void Update_Inventory()                                              //////////
        {
            Inventory inventory = InventoryListView.SelectedItem as Inventory;

            if (inventory == null || InventoryNameTxtBx.Text == string.Empty)
            {
                MessageBox.Show("Please Select Inventory And Enter It's New Name");
                return;
            }

            inventory.Location = InventoryNameTxtBx.Text.Trim();
            context.SaveChanges();

            FillInventoryListView();
        }

        private void FillInventoryListView()                                                         //////////
        {
            InventoryListView.ItemsSource = null;
            InventoryListView.ItemsSource = context.Inventories.ToList();
        }

        private void Delete_Inventory()                                         //////////
        {
            Inventory SelectedInventory = InventoryListView.SelectedItem as Inventory;

            if (SelectedInventory == null)
            {
                MessageBox.Show("Please Select Inventory");
                return;
            }

            if (SelectedInventory.InventoryCategories != null)                                          //
            {                                                                                           //
                MessageBox.Show("Inventory Is not Empty");                                              //
                return;                                                                                 //
            }                                                                                           //

            //Inventory inventory = context.Inventories.FirstOrDefault(inv => inv.ID == SelectedInventory.ID);
            //context.Inventories.Remove(inventory);

            context.Inventories.Remove(SelectedInventory);

            context.SaveChanges();

            FillInventoryListView();
        }

    }
}
