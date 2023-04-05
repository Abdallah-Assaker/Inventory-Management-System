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
    /// Interaction logic for ReturnCustomerBillUserControl.xaml
    /// </summary>
    public partial class ReturnCustomerBillUserControl : UserControl
    {
        Context context = new Context();
        CustomerOrder customerOrder = new CustomerOrder();
        ReturnCustomerOrder returnCustomerOrder = new ReturnCustomerOrder();
        List<ReturnCustomerProduct> returnCustomerProducts = new List<ReturnCustomerProduct>();
        List<CustomerProductBill> customerProductBills = new List<CustomerProductBill>();
        public ReturnCustomerBillUserControl()
        {
            InitializeComponent();
        }
        private void SearchAboutBill_Click(object sender, RoutedEventArgs e)
        {
            if (ReturnBillId.Text == null)
            {
                MessageBox.Show("Please Write BillId");
                return;
            }

            ReturnBillId.IsEnabled = false;

            if (!int.TryParse(ReturnBillId.Text, out int BillId))
            {
                ReturnBillId.IsEnabled = false;
                return;
            }

            customerOrder = context.CustomerOrders
               .Include(co => co.Customer)
               .Include(co => co.Inventory)
               .Include(co => co.CustomerProductBills)
               .ThenInclude(cpb => cpb.Product)
               .FirstOrDefault(co => co.ID == BillId);
            if (customerOrder == null)
            {
                ReturnBillId.IsEnabled = true;
                MessageBox.Show("Please Write Valid ID");
                return;
            }

            double date = (DateTime.Now - customerOrder.OrderedOn).TotalDays;
            if (date > 14)
            {
                ReturnBillId.IsEnabled = true;
                MessageBox.Show("Sorry Date of This Order Expired");
                return;
            }
            OriginalBillsListView.ItemsSource = customerOrder.CustomerProductBills;
            InventoryBlock.Text = customerOrder.Inventory.Location;
            DateBlock.Text = customerOrder.OrderedOn.ToShortDateString();
            RemainBlock.Text = customerOrder.Customer.Remain.ToString();
            CustomerNameBlock.Text = customerOrder.Customer.Name;
            TotlPriceBlock.Text = customerOrder.TotalPrice.ToString();
        }

        private void OriginalBillsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomerProductBill customerProductBill = OriginalBillsListView.SelectedItem as CustomerProductBill;
            if (customerProductBill != null)
            {
                ProductNameBlock.Text = customerProductBill.Product.Name;
                QuantityBlock.Text = customerProductBill.Quantity.ToString();
            }
        }

        private void AddProductToReturnBill_Click(object sender, RoutedEventArgs e)
        {
            AddReturnProduct();
        }
        public void AddReturnProduct()
        {
            if (OriginalBillsListView.ItemsSource == null)
            {
                MessageBox.Show("Please Enter Valid Bill Id");
                return;
            }
            CustomerProductBill customerProductBill = OriginalBillsListView.SelectedItem as CustomerProductBill;
            if (customerProductBill == null)
            {
                MessageBox.Show("Please Choose Product From This Bill");
                return;
            }
            if (ReturnQuantityBox.Text == null)
            {
                MessageBox.Show("Please Write Quantity");
                return;
            }
            if (!int.TryParse(ReturnQuantityBox.Text, out int Q))
            {
                MessageBox.Show("Please Enter Valid Quantity");
                return;
            }
            int RQ = customerProductBill.Quantity - customerProductBill.ReturnQuantity;
            if (Q > RQ)
            {
                MessageBox.Show($"REturn Quantity is {Q} While The Customer Have {RQ} from This Product in this Bill");
                return;
            }
            customerProductBills.Add(customerProductBill);
            ReturnCustomerProduct returnCustProd = new ReturnCustomerProduct();
            returnCustProd.Quantity = Q;
            returnCustProd.ProductID = customerProductBill.ProductID;
            returnCustProd.Product = customerProductBill.Product;
            returnCustProd.Price = returnCustProd.Product.Price * returnCustProd.Quantity;

            //if (customerOrder.Net == 0)
            //{
            //    returnCustProd.Price = returnCustProd.Product.Price * returnCustProd.Quantity;
            //}
            if (customerOrder.Net > 0)
            {
                float moneyWillRemovedForPiece = 0;
                int AllQuantityProducts = 0;
                foreach (CustomerProductBill item in customerOrder.CustomerProductBills)
                {
                    AllQuantityProducts += item.Quantity;
                }
                moneyWillRemovedForPiece = customerOrder.Discount / AllQuantityProducts;
                returnCustProd.Price -= returnCustProd.Quantity * moneyWillRemovedForPiece;
            }
            //else
            //{
            //    MessageBox.Show("An Error Exist in Clculation of Net in Original Bill");
            //    return;
            //}
            returnCustProd.ReturnCustomerOrder = returnCustomerOrder;
            returnCustProd.ReturnCustomerOrderID = returnCustomerOrder.ID;
            returnCustomerProducts.Add(returnCustProd);

            ReturnCustomerBillView.ItemsSource = null;
            ReturnCustomerBillView.ItemsSource = returnCustomerProducts;

            ProductNameBlock.Text = string.Empty;
            QuantityBlock.Text = string.Empty;
        }

        private void ReturnCustomerBillView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReturnCustomerProduct returnCustomerProduct = ReturnCustomerBillView.SelectedItem as ReturnCustomerProduct;
            if (returnCustomerProduct != null)
            {
                ReturnCustomerProductNameBlock.Text = returnCustomerProduct.Product.Name;
                ReturnCustomerProductQuantityBlock.Text = returnCustomerProduct.Quantity.ToString();

            }
        }


        private void deleteReturnBill_Click(object sender, RoutedEventArgs e)
        {
            DeleteReturnBillView();
        }
        private void DeleteReturnBillView()
        {
            DeleteReturnProduct();
        }

        private void DeleteReturnProduct()
        {
            ReturnCustomerProduct returnCustomerProduct = ReturnCustomerBillView.SelectedItem as ReturnCustomerProduct;
            if (returnCustomerProduct == null)
            {
                MessageBox.Show("Please Select Item From Return Product List View");
                return;
            }
            returnCustomerProducts.Remove(returnCustomerProduct);
            ReturnCustomerBillView.ItemsSource = null;
            ReturnCustomerBillView.ItemsSource = returnCustomerProducts;
            ReturnCustomerProductNameBlock.Text = ReturnCustomerProductQuantityBlock.Text = null;
        }

        private void ResetREturnCustomerBillButton_Click(object sender, RoutedEventArgs e)
        {
            ResetReturnCustomerBill();
        }
        private void ResetReturnCustomerBill()
        {
            returnCustomerProducts.Clear();
            ClearAllFields();
        }
        private void ClearAllFields()
        {
            ReturnCustomerProductNameBlock.Text = ReturnCustomerProductQuantityBlock.Text = null;

            ReturnCustomerBillView.ItemsSource = null;
            ReturnCustomerBillView.ItemsSource = returnCustomerProducts;
        }
        public void SaveReturnBill()
        {
            if (!int.TryParse(ReturnBillId.Text, out int Id))
            {
                MessageBox.Show("Please Enter Valid Bill Id");
                return;
            }

            returnCustomerOrder.OrderedOn = DateTime.Now;
            returnCustomerOrder.CustomerOrderID = Id;
            returnCustomerOrder.CustomerOrder = customerOrder;
            returnCustomerOrder.ReturnCustomerProducts = new List<ReturnCustomerProduct>();
            returnCustomerOrder.ReturnCustomerProducts.AddRange(returnCustomerProducts);

            for (int i = 0; i < returnCustomerProducts.Count; i++)
            {
                CustomerProductBill orderProduct = customerProductBills[i];
                ReturnCustomerProduct returnedProduct = returnCustomerProducts[i];

                returnCustomerOrder.ReturnCustomerProducts.Add(returnedProduct);

                if (returnedProduct.Product.ReturnCustomerProducts == null)
                {
                    returnedProduct.Product.ReturnCustomerProducts = new List<ReturnCustomerProduct> { returnedProduct };
                }
                else
                {
                    returnedProduct.Product.ReturnCustomerProducts.Add(returnedProduct);
                }
                returnCustomerOrder.TotalPrice += returnedProduct.Price;
                orderProduct.ReturnQuantity += returnedProduct.Quantity;

                returnedProduct.Product.Inventory.AddProduct(returnedProduct.Product, returnedProduct.Quantity);
            }

            customerOrder.Customer.Remain -= returnCustomerOrder.TotalPrice;
            context.ReturnCustomerOrder.Add(returnCustomerOrder);
            context.SaveChanges();

            MessageBox.Show("Save Operation Secceded");

            ReturnCustomerBillView.ItemsSource = null;
            ReturnCustomerProductQuantityBlock.Text = null;
            ReturnCustomerProductQuantityBlock.Text = null;

            customerOrder = new CustomerOrder();
            returnCustomerOrder = new ReturnCustomerOrder();
            returnCustomerProducts = new List<ReturnCustomerProduct>();
            customerProductBills = new List<CustomerProductBill>();

        }

        private void SaveReturnCustBillButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReturnCustomerBillView.ItemsSource != null)
            {
                SaveReturnBill();
            }
            else
            {
                MessageBox.Show("Please Add Return Product Firstly Then Save The Return Bill");
            }
            /////////////////////////////////////////////
            returnCustomerOrder = new ReturnCustomerOrder();
        }
    }

}
