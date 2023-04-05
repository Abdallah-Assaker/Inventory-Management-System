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
    /// Interaction logic for SupplierProductBillsUserControl.xaml
    /// </summary>
    public partial class SupplierProductBillsUserControl : UserControl
    {
        public List<SupplierProductBill> SupplierProductBills = new List<SupplierProductBill>();
        SupplierOrder SupplierOrder;
        float SupplierOrderTotalPrice = 0;
        Context context = new Context();
        User User { get; set; }
        public SupplierProductBillsUserControl(User user)
        {
            InitializeComponent();
            Loaded += SupplierProductBillsUserControl_Loaded;
            User = user;
        }

        private void SupplierProductBillsUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SupplierOrderDateTextBlock.Text = DateTime.Now.ToShortDateString();
            SupplierOrderInventoryComBox.ItemsSource = context.Inventories.ToList();
            SupplierOrderSupplierComBox.ItemsSource = context.Suppliers.ToList();
        }

        private void InventoryComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Inventory inventory = (Inventory)SupplierOrderInventoryComBox.SelectedItem;
            if (inventory != null)
                SupplierOrderProductComBox.ItemsSource = context.Products.Where(P => P.InventoryID == inventory.ID).ToList();//inventory.Products;

        }

        private void ProductComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product product = (Product)SupplierOrderProductComBox.SelectedItem;
            if (product != null)
                SupplierOrderPriceTextBlock.Text = product.Price.ToString();
        }

        private void SupplierOrder_AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProduct();
        }

        private void SupplierOrder_SaveProductBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveProduct();

        }

        private void SupplierOrder_DeleteProductBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteProduct();
        }

        private void AddProduct()
        {
            if (SupplierOrderProductComBox.SelectedItem == null)
            {
                MessageBox.Show("Please select product");
                return;
            }

            int.TryParse(SupplierOrderQuantityTextBox.Text, out int SupplierOrderQuantityTB);
            if (SupplierOrderQuantityTB < 1)
            {
                MessageBox.Show("Please enter valid quantity");
                return;
            }


            bool flag = false;



            foreach (SupplierProductBill SupplierProductBill in SupplierProductBills)
            {
                if (SupplierProductBill.Product.Name == ((Product)SupplierOrderProductComBox.SelectedItem).Name)
                {
                    flag = true;
                    SupplierProductBill.Quantity += SupplierOrderQuantityTB;
                    SupplierProductBill.TotalPrice = float.Parse(SupplierOrderPriceTextBlock.Text) * SupplierProductBill.Quantity;
                    SupplierOrderTotalPrice += SupplierProductBill.TotalPrice;
                }
            }


            if (flag == false)
            {
                SupplierProductBill SupplierProductBill = new SupplierProductBill
                {
                    Product = (Product)SupplierOrderProductComBox.SelectedItem,
                    Quantity = SupplierOrderQuantityTB,
                    TotalPrice = float.Parse(SupplierOrderPriceTextBlock.Text) * SupplierOrderQuantityTB

                };

                SupplierOrderTotalPrice += SupplierProductBill.TotalPrice;
                SupplierProductBills.Add(SupplierProductBill);

            }
            SupplierOrderProductListView.ItemsSource = null;
            SupplierOrderProductListView.ItemsSource = SupplierProductBills;
            SupplierOrderTotalTextBlock.Text = SupplierOrderTotalPrice.ToString();


        }

        private void SaveProduct()
        {
            if (SupplierOrderProductComBox.SelectedItem == null)
            {
                MessageBox.Show("Please select product");
                return;
            }

            int.TryParse(SupplierOrderQuantityTextBox.Text, out int SupplierOrderQuantityTB);
            if (SupplierOrderQuantityTB < 1)
            {
                MessageBox.Show("Please enter valid quantity");
                return;
            }


            foreach (SupplierProductBill item in SupplierProductBills)
            {
                if (item.Product.Name == ((SupplierProductBill)SupplierOrderProductListView.SelectedItem).Product.Name)
                {
                    SupplierOrderTotalPrice -= item.TotalPrice;
                    item.Product = (Product)SupplierOrderProductComBox.SelectedItem;
                    item.Quantity = SupplierOrderQuantityTB;
                    item.TotalPrice = float.Parse(SupplierOrderPriceTextBlock.Text) * SupplierOrderQuantityTB;

                    SupplierOrderTotalPrice += item.TotalPrice;
                    SupplierOrderTotalTextBlock.Text = SupplierOrderTotalPrice.ToString();
                }
            }
            SupplierOrderProductListView.ItemsSource = null;
            SupplierOrderProductListView.ItemsSource = SupplierProductBills;

        }

        private void DeleteProduct()
        {
            if (SupplierOrderProductListView.SelectedItem == null)
            {
                MessageBox.Show("Please select Product");
                return;
            }

            SupplierOrderTotalPrice -= ((SupplierProductBill)SupplierOrderProductListView.SelectedItem).TotalPrice;
            SupplierOrderTotalTextBlock.Text = SupplierOrderTotalPrice.ToString();

            SupplierProductBills.Remove((SupplierProductBill)SupplierOrderProductListView.SelectedItem);
            SupplierOrderProductListView.ItemsSource = null;
            SupplierOrderProductListView.ItemsSource = SupplierProductBills;

        }




        private void ProductListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (SupplierOrderProductListView.SelectedItem != null)
            {
                SupplierProductBill ListViewproduct = (SupplierProductBill)SupplierOrderProductListView.SelectedItem;
                for (int i = 0; i < SupplierOrderProductComBox.Items.Count; i++)
                {
                    if (((Product)SupplierOrderProductComBox.Items[i]).Name == ListViewproduct.Product.Name)
                    {
                        SupplierOrderProductComBox.SelectedIndex = i;
                    }
                }

                SupplierOrderQuantityTextBox.Text = ListViewproduct.Quantity.ToString();
                SupplierOrderPriceTextBlock.Text = (ListViewproduct.TotalPrice / ListViewproduct.Quantity).ToString();

            }
        }


        private void SupplierOrderAddBillBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBill();
        }

        private void SupplierOrderResetBillBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetBill();

        }



        private void AddBill()
        {
            if (SupplierOrderSupplierComBox.SelectedItem == null)
            {
                MessageBox.Show("Please select Supplier");
                return;
            }

            if (SupplierOrderInventoryComBox.SelectedItem == null)
            {
                MessageBox.Show("Please select Inventory");
                return;
            }
            if (SupplierProductBills.Count <= 0)
            {
                MessageBox.Show("Please Add Product");
                return;
            }

            float.TryParse(SupplierOrderPaidMoneyTextBox.Text, out float SupplierOrderPaidMoneyTB);
            if (SupplierOrderPaidMoneyTB <= 0 || SupplierOrderPaidMoneyTB > SupplierOrderTotalPrice)
            {
                MessageBox.Show("Please enter valid paid money");
                return;
            }



            SupplierOrder = new SupplierOrder(); // { User = new User()};
            Inventory Inventory = ((Inventory)SupplierOrderInventoryComBox.SelectedItem);
            SupplierOrder.InventoryID = Inventory.ID;
            Supplier Supplier = ((Supplier)SupplierOrderSupplierComBox.SelectedItem);
            SupplierOrder.SupplierID = Supplier.ID;
            //SupplierOrder.User.ID = User.ID;
            //SupplierOrder.User = User;
            SupplierOrder.OrderedOn = DateTime.Parse(SupplierOrderDateTextBlock.Text);
            SupplierOrder.TotalPrice = SupplierOrderTotalPrice;
            SupplierOrder.Paid = SupplierOrderPaidMoneyTB;
            SupplierOrder.Remain = SupplierOrder.TotalPrice - SupplierOrder.Paid;

            Supplier.Remain += SupplierOrder.Remain;
            context.SupplierOrders.Add(SupplierOrder);
            context.SaveChanges();
            SupplierOrderRemainTextBlock.Text = SupplierOrder.Remain.ToString();


            foreach (SupplierProductBill SupplierProductBill in SupplierProductBills)
            {
                SupplierProductBill.SupplierOrderID = SupplierOrder.ID;

                context.SupplierProductBills.Add(SupplierProductBill);

                Inventory.AddProduct(SupplierProductBill.Product, SupplierProductBill.Quantity);

            }
            context.SaveChanges();

            // Reset Bill After Adding
            SupplierProductBills = new List<SupplierProductBill>();
            SupplierOrderProductListView.ItemsSource = null;

            SupplierOrderInventoryComBox.SelectedIndex = -1;
            SupplierOrderProductComBox.ItemsSource = null;

            SupplierOrderSupplierComBox.SelectedIndex = -1;
            SupplierOrderQuantityTextBox.Text = 1.ToString();
            SupplierOrderPriceTextBlock.Text = 0.ToString();
            SupplierOrderProductListView.ItemsSource = null;
            SupplierOrderRemainTextBlock.Text = string.Empty;
            SupplierOrderTotalTextBlock.Text = string.Empty;
            SupplierOrderPaidMoneyTextBox.Text = string.Empty;

        }

        private void ResetBill()
        {
            SupplierProductBills = new List<SupplierProductBill>();
            SupplierOrderProductListView.ItemsSource = null;

            SupplierOrderInventoryComBox.SelectedIndex = -1;
            SupplierOrderProductComBox.ItemsSource = null;

            SupplierOrderSupplierComBox.SelectedIndex = -1;
            SupplierOrderQuantityTextBox.Text = 1.ToString();
            SupplierOrderPriceTextBlock.Text = 0.ToString();
            SupplierOrderProductListView.ItemsSource = null;
            SupplierOrderRemainTextBlock.Text = string.Empty;
            SupplierOrderTotalTextBlock.Text = string.Empty;
            SupplierOrderPaidMoneyTextBox.Text = string.Empty;

        }
    }
}