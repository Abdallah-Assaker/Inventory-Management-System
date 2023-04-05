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
    /// Interaction logic for CustomerOrderProductsUserControl.xaml
    /// </summary>
    public partial class CustomerOrderProductsUserControl : UserControl
    {
        public List<CustomerProductBill> CustomerProductBills = new List<CustomerProductBill>();
        CustomerOrder CustomerOrder;
        float CustomerOrderTotalPrice = 0;
        Context context = new Context();
        User user { get; set; }
        public CustomerOrderProductsUserControl(User user)
        {
            InitializeComponent();
            Loaded += CustomerOrderProductsUserControl_Loaded;
            this.user = user;
        }

        private void CustomerOrderProductsUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CustomerOrderDateTextBlock.Text = DateTime.Now.ToShortDateString();

            CustomerOrderInventoryComBox.ItemsSource = context.Inventories.ToList();//.Include(I => I.Products).ToList();
            CustomerOrderCustomerComBox.ItemsSource = context.Customers.ToList();
        }


        private void InventoryComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Inventory inventory = (Inventory)CustomerOrderInventoryComBox.SelectedItem;
            if (inventory != null)
                CustomerOrderProductComBox.ItemsSource = context.Products.Where(P => P.InventoryID == inventory.ID).ToList();//inventory.Products;

        }


        private void ProductComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product product = (Product)CustomerOrderProductComBox.SelectedItem;
            if (product != null)
                CustomerOrderPriceTextBlock.Text = product.Price.ToString();
        }



        private void CustomerOrder_AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProduct();
        }

        private void CustomerOrder_SaveProductBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveProduct();

        }

        private void CustomerOrder_DeleteProductBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteProduct();
        }



        private void AddProduct()
        {
            if (CustomerOrderProductComBox.SelectedItem == null)
            {
                MessageBox.Show("Please select product");
                return;
            }

            int.TryParse(CustomerOrderQuantityTextBox.Text, out int CustomerOrderQuantityTB);
            if (CustomerOrderQuantityTB < 1)
            {
                MessageBox.Show("Please enter valid quantity");
                return;
            }
            if (CustomerOrderQuantityTB > ((Product)CustomerOrderProductComBox.SelectedItem).Quantity)
            {
                MessageBox.Show("The specified quantity is not available in stock");
                return;
            }

            bool flag = false;



            foreach (CustomerProductBill CustomerProductBill in CustomerProductBills)
            {
                if (CustomerProductBill.Product.Name == ((Product)CustomerOrderProductComBox.SelectedItem).Name)
                {
                    flag = true;
                    CustomerProductBill.Quantity += CustomerOrderQuantityTB;
                    CustomerProductBill.TotalPrice = float.Parse(CustomerOrderPriceTextBlock.Text) * CustomerProductBill.Quantity;
                    CustomerOrderTotalPrice += CustomerProductBill.TotalPrice;
                }
            }


            if (flag == false)
            {
                CustomerProductBill CustomerProductBill = new CustomerProductBill
                {
                    Product = (Product)CustomerOrderProductComBox.SelectedItem,
                    Quantity = int.Parse(CustomerOrderQuantityTextBox.Text),
                    TotalPrice = float.Parse(CustomerOrderPriceTextBlock.Text) * CustomerOrderQuantityTB
                };

                CustomerOrderTotalPrice += CustomerProductBill.TotalPrice;
                CustomerProductBills.Add(CustomerProductBill);

            }
            CustomerOrderProductListView.ItemsSource = null;
            CustomerOrderProductListView.ItemsSource = CustomerProductBills;
            CustomerOrderTotalTextBlock.Text = CustomerOrderTotalPrice.ToString();

        }

        private void SaveProduct()
        {
            if (CustomerOrderProductComBox.SelectedItem == null)
            {
                MessageBox.Show("Please select product");
                return;
            }

            int.TryParse(CustomerOrderQuantityTextBox.Text, out int CustomerOrderQuantityTB);
            if (CustomerOrderQuantityTB < 1)
            {
                MessageBox.Show("Please enter valid quantity");
                return;
            }
            if (CustomerOrderQuantityTB > ((Product)CustomerOrderProductComBox.SelectedItem).Quantity)
            {
                MessageBox.Show("The specified quantity is not available in stock");
                return;
            }

            foreach (CustomerProductBill item in CustomerProductBills)
            {
                if (item.Product.Name == ((CustomerProductBill)CustomerOrderProductListView.SelectedItem).Product.Name)
                {
                    CustomerOrderTotalPrice -= item.TotalPrice;
                    item.Product = (Product)CustomerOrderProductComBox.SelectedItem;
                    item.Quantity = CustomerOrderQuantityTB;
                    item.TotalPrice = float.Parse(CustomerOrderPriceTextBlock.Text) * CustomerOrderQuantityTB;

                    CustomerOrderTotalPrice += item.TotalPrice;
                    CustomerOrderTotalTextBlock.Text = CustomerOrderTotalPrice.ToString();
                }
            }
            CustomerOrderProductListView.ItemsSource = null;
            CustomerOrderProductListView.ItemsSource = CustomerProductBills;

        }

        private void DeleteProduct()
        {

            if (CustomerOrderProductListView.SelectedItem == null)
            {
                MessageBox.Show("Please select Product");
                return;
            }

            CustomerOrderTotalPrice -= ((CustomerProductBill)CustomerOrderProductListView.SelectedItem).TotalPrice;
            CustomerOrderTotalTextBlock.Text = CustomerOrderTotalPrice.ToString();

            CustomerProductBills.Remove((CustomerProductBill)CustomerOrderProductListView.SelectedItem);
            CustomerOrderProductListView.ItemsSource = null;
            CustomerOrderProductListView.ItemsSource = CustomerProductBills;

        }




        private void ProductListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomerOrderProductListView.SelectedItem != null)
            {
                CustomerProductBill ListViewproduct = (CustomerProductBill)CustomerOrderProductListView.SelectedItem;
                for (int i = 0; i < CustomerOrderProductComBox.Items.Count; i++)
                {
                    if (((Product)CustomerOrderProductComBox.Items[i]).Name == ListViewproduct.Product.Name)
                    {
                        CustomerOrderProductComBox.SelectedIndex = i;
                    }
                }

                CustomerOrderQuantityTextBox.Text = ListViewproduct.Quantity.ToString();
                CustomerOrderPriceTextBlock.Text = (ListViewproduct.TotalPrice / ListViewproduct.Quantity).ToString();

            }
        }


        private void CustomerOrderAddBillBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBill();
        }

        private void CustomerOrderResetBillBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetBill();
        }





        private void AddBill()
        {
            if (CustomerOrderCustomerComBox.SelectedItem == null)
            {
                MessageBox.Show("Please select Customer");
                return;
            }

            if (CustomerOrderInventoryComBox.SelectedItem == null)
            {
                MessageBox.Show("Please select Inventory");
                return;
            }
            if (CustomerProductBills.Count <= 0)
            {
                MessageBox.Show("Please Add Product");
                return;
            }

            float.TryParse(CustomerOrderPaidMoneyTextBox.Text, out float CustomerOrderPaidMoneyTB);
            if (CustomerOrderPaidMoneyTB <= 0 || CustomerOrderPaidMoneyTB > CustomerOrderTotalPrice)
            {
                MessageBox.Show("Please enter valid paid money");
                return;
            }

            float.TryParse(CustomerOrderDiscountMoneyTextBox.Text, out float CustomerOrderDiscountTB);
            if (CustomerOrderDiscountTB < 0 || CustomerOrderDiscountTB > CustomerOrderTotalPrice / 2.0)
            {
                MessageBox.Show("Please enter valid discount");
                return;
            }

            if (CustomerOrderCustomerComBox.SelectedItem != null && CustomerOrderInventoryComBox.SelectedItem != null && CustomerProductBills.Count > 0 && decimal.Parse(CustomerOrderPaidMoneyTextBox.Text) > 0)
            {
                CustomerOrder = new CustomerOrder();
                //CustomerOrder.ID = 1;
                Inventory Inventory = ((Inventory)CustomerOrderInventoryComBox.SelectedItem);
                CustomerOrder.InventoryID = Inventory.ID;
                Customer Customer = ((Customer)CustomerOrderCustomerComBox.SelectedItem);
                CustomerOrder.CustomerID = Customer.ID;
                //CustomerOrder.User = user;
                CustomerOrder.OrderedOn = DateTime.Parse(CustomerOrderDateTextBlock.Text);
                CustomerOrder.TotalPrice = float.Parse(CustomerOrderTotalTextBlock.Text);
                CustomerOrder.Paid = CustomerOrderPaidMoneyTB;

                CustomerOrder.Discount = CustomerOrderDiscountTB;
                if (CustomerOrder.Discount > 0)
                {

                    CustomerOrder.Net = CustomerOrder.TotalPrice - CustomerOrder.Discount;
                    CustomerOrder.Remain = CustomerOrder.Net - CustomerOrder.Paid;

                }
                else
                {
                    CustomerOrder.Net = 0;
                    CustomerOrder.Remain = CustomerOrder.TotalPrice - CustomerOrder.Paid;

                }

                Customer.Remain += CustomerOrder.Remain;
                CustomerOrderNetTextBlock.Text = CustomerOrder.Net.ToString();
                CustomerOrderRemainTextBlock.Text = CustomerOrder.Remain.ToString();

                context.CustomerOrders.Add(CustomerOrder);
                context.SaveChanges();


                foreach (CustomerProductBill CustomerProductBill in CustomerProductBills)
                {
                    CustomerProductBill.CustomerOrderID = CustomerOrder.ID;
                    context.CustomerProductBills.Add(CustomerProductBill);

                    Inventory.RemoveProduct(CustomerProductBill.Product, CustomerProductBill.Quantity);

                }
                context.SaveChanges();



                // After add Bill
                CustomerProductBills = new List<CustomerProductBill>();
                CustomerOrderProductListView.ItemsSource = null;

                CustomerOrderInventoryComBox.SelectedIndex = -1;
                CustomerOrderProductComBox.ItemsSource = null;

                CustomerOrderCustomerComBox.SelectedIndex = -1;
                CustomerOrderQuantityTextBox.Text = 1.ToString();
                CustomerOrderPriceTextBlock.Text = 0.ToString();
                CustomerOrderProductListView.ItemsSource = null;
                CustomerOrderRemainTextBlock.Text = string.Empty;
                CustomerOrderNetTextBlock.Text = string.Empty;
                CustomerOrderTotalTextBlock.Text = string.Empty;
                CustomerOrderPaidMoneyTextBox.Text = string.Empty;


            }

        }


        private void ResetBill()
        {
            CustomerProductBills = new List<CustomerProductBill>();
            CustomerOrderProductListView.ItemsSource = null;

            CustomerOrderInventoryComBox.SelectedIndex = -1;
            CustomerOrderProductComBox.ItemsSource = null;

            CustomerOrderCustomerComBox.SelectedIndex = -1;
            CustomerOrderQuantityTextBox.Text = 1.ToString();
            CustomerOrderPriceTextBlock.Text = 0.ToString();
            CustomerOrderProductListView.ItemsSource = null;
            CustomerOrderRemainTextBlock.Text = string.Empty;
            CustomerOrderNetTextBlock.Text = string.Empty;
            CustomerOrderTotalTextBlock.Text = string.Empty;
            CustomerOrderPaidMoneyTextBox.Text = string.Empty;
        }


    }
}