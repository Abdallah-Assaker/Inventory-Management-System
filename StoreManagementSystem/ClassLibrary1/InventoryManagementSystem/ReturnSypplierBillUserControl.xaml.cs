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
    /// Interaction logic for ReturnSypplierBillUserControl.xaml
    /// </summary>
    public partial class ReturnSypplierBillUserControl : UserControl
    {
        List<ReturnSupplierProduct> ReturnedProductsToDisplay = new List<ReturnSupplierProduct>();
        List<SupplierProductBill> SelectedProductsToReturn = new List<SupplierProductBill>();

        Context context = new Context();
        public ReturnSypplierBillUserControl()
        {
            InitializeComponent();
        }

        private void btnReturnBillSearch_Click(object sender, RoutedEventArgs e)
        {
            if (ReturnBillIdSearch.Text == null)
            {
                MessageBox.Show("Please Enter Bill ID Quantity");
                return;
            }

            ReturnBillIdSearch.IsEnabled = false;

            if (!int.TryParse(ReturnBillIdSearch.Text, out int Id))
            {
                MessageBox.Show("Please Enter Valid Bill ID");
                return;
            }

            SupplierOrder order = context.SupplierOrders
                .Include(so => so.Supplier)
                .Include(so => so.Inventory)
                .Include(so => so.SupplierProductBills)
                .ThenInclude(spb => spb.Product)
                .FirstOrDefault(so => so.ID == Id);

            if (order == null)
            {
                MessageBox.Show("Bill Not Found");
                ReturnBillIdSearch.IsEnabled = true;
                return;
            }

            if (DateTime.Now.Day - order.OrderedOn.Day > 14)                                /////Date Validation
            {
                MessageBox.Show("Bill Expired");
                ReturnBillIdSearch.IsEnabled = true;
                return;
            }

            ReturnBillSupplerName.Text = order.Supplier.Name;
            ReturnBillInventory.Text = order.Inventory.Location;
            ReturnBillQty.Text = order.SupplierProductBills.Sum(spb => spb.Quantity).ToString();
            ReturnBillDate.Text = order.OrderedOn.ToShortDateString();
            ReturnBillTotal.Text = order.TotalPrice.ToString();

            lvReturnBillCurrentProducts.ItemsSource = order.SupplierProductBills;
        }
        //عايز اعرض التوتال برايس
        private void btnReturnBillSelectedQty_Click(object sender, RoutedEventArgs e)
        {
            SupplierProductBill spb = lvReturnBillCurrentProducts.SelectedItem as SupplierProductBill;
            if (txtReturnBillQty.Text == null || spb == null)
            {
                MessageBox.Show("Please Select A Product and Enter Quantity");
                return;
            }

            if (!int.TryParse(txtReturnBillQty.Text, out int Q))
            {
                MessageBox.Show("Please Enter Valid Quantity");
                return;
            }

            if (Q > spb.Quantity - spb.ReturnQuantity)
            {
                MessageBox.Show("Please Enter Valid Quantity");
                return;
            }

            if (Q > spb.Product.Quantity)
            {
                MessageBox.Show("No Enough Quantity In The Stock");
                return;
            }

            ReturnSupplierProduct returnedProduct = new()
            {
                Product = spb.Product,
                Quantity = Q,
                Price = Q * spb.Product.Price,
            };

            if (ReturnBillReturnedTotal.Text == string.Empty)
            {
                ReturnBillReturnedTotal.Text = returnedProduct.Price.ToString();
            }
            else
            {
                ReturnBillReturnedTotal.Text = (int.Parse(ReturnBillReturnedTotal.Text) + returnedProduct.Price).ToString();
            }

            ReturnedProductsToDisplay.Add(returnedProduct);
            SelectedProductsToReturn.Add(spb);
            UpdateSelectedProductsListView();
        }

        private void UpdateSelectedProductsListView()
        {
            lvReturnBillSelectedProducts.ItemsSource = null;
            lvReturnBillSelectedProducts.ItemsSource = ReturnedProductsToDisplay;
        }

        private void ReturnBillRemove_Click(object sender, RoutedEventArgs e)
        {
            ReturnSupplierProduct returnedProduct = lvReturnBillSelectedProducts.SelectedItem as ReturnSupplierProduct;
            if (returnedProduct == null)
            {
                MessageBox.Show("Please Select A Product To Remove");
                return;
            }

            ReturnedProductsToDisplay.Remove(returnedProduct);
            UpdateSelectedProductsListView();
        }

        private void ReturnBillReset_Click(object sender, RoutedEventArgs e)
        {
            ReturnBillClearAllFields();
            ReturnedProductsToDisplay.Clear();
            UpdateSelectedProductsListView();
        }

        private void ReturnBillClearAllFields()
        {

            ReturnBillSupplerName.Text = ReturnBillInventory.Text = ReturnBillQty.Text = ReturnBillDate.Text = ReturnBillTotal.Text = string.Empty;
            lvReturnBillCurrentProducts.ItemsSource = lvReturnBillSelectedProducts.ItemsSource = null;
        }

        private void ReturnBillConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(ReturnBillIdSearch.Text, out int Id))
            {
                return;
            }

            SupplierOrder mainOrder = context.SupplierOrders.Include(so => so.Supplier).FirstOrDefault(so => so.ID == Id);

            if (mainOrder == null)
            {
                return;
            }

            ReturnSupplierOrder returnedOrder = new()
            {
                OrderedOn = DateTime.Now,
                ReturnSupplierProducts = ReturnedProductsToDisplay,
                SupplierOrderID = Id,
                SupplierOrder = mainOrder,
            };

            for (int i = 0; i < ReturnedProductsToDisplay.Count; i++)
            {
                SupplierProductBill orderProduct = SelectedProductsToReturn[i];
                ReturnSupplierProduct returnedProduct = ReturnedProductsToDisplay[i];
                //returnedOrder.ReturnSupplierProducts.Add(returnedProduct);

                if (returnedProduct.Product.ReturnSupplierProducts == null)
                {
                    returnedProduct.Product.ReturnSupplierProducts = new List<ReturnSupplierProduct> { returnedProduct };
                }
                else
                {
                    returnedProduct.Product.ReturnSupplierProducts.Add(returnedProduct);
                }

                returnedOrder.TotalPrice += ReturnedProductsToDisplay[i].Price;

                orderProduct.ReturnQuantity += returnedProduct.Quantity;
                returnedProduct.Product.Inventory.RemoveProduct(returnedProduct.Product, returnedProduct.Quantity);
            }

            mainOrder.Supplier.Remain -= returnedOrder.TotalPrice;
            context.ReturnSupplierOrders.Add(returnedOrder);

            context.SaveChanges();

            SelectedProductsToReturn.Clear();
            ReturnedProductsToDisplay.Clear();
            ReturnBillClearAllFields();
        }
    }
}
