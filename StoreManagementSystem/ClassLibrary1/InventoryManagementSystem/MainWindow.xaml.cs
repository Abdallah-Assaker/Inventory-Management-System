using InventoryManagementSystem;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static MainWindow window;
        internal User User { get; set; }

        public MainWindow() { }
        public MainWindow(User user)
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            User = user;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            window = this;
        }

                                            /* --------------------------------------- 
                                               ---------SIDEBAR SECTION -------------*/


        /* --------------------------------------- 
           ---------INVENTORY SECTION ------------
           -------------------------------------*/
        private void Inventories_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new InventoryUserControl();
        }

        /* --------------------------------------- 
          ---------CATEGORY SECTION --------------
          ---------------------------------------*/
        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CategoryUserControl();
        }

        /* --------------------------------------- 
          ---------PRODUCT SECTION --------------
          ---------------------------------------*/
        private void Products_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ProductUserControl();

        }

        /* --------------------------------------- 
          ---------CUSTOMER SECTION --------------
          ---------------------------------------*/
        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDropDownList.Visibility == Visibility.Visible)
            {
                CustomerDropDownList.Visibility = Visibility.Collapsed;
            }
            else
            {
                CustomerDropDownList.Visibility = Visibility.Visible;
            }
        }
        /* --------------------------------------- 
          ---------CUSTOMER DETAILS --------------
          ---------------------------------------*/
        private void CustomerDetails_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CustomerUserControl();

        }
        /* --------------------------------------- 
         ---------CUSTOMERS ORDERS --------------
         ---------------------------------------*/
        private void CustomerOrder_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CustomerOrderProductsUserControl(User);
        }
        /* --------------------------------------- 
         --------- CUSTOMERS BILLS --------------
         ---------------------------------------*/
        private void ShowCustomersBills_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ShowCustomersBillsUserControl();
        }
        /* --------------------------------------- 
         --------- CUSTOMERS RETURNS --------------
         ---------------------------------------*/
        private void ReturnCustomers_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ReturnCustomerBillUserControl();
        }
        /* --------------------------------------- 
         --------- CUSTOMERS REMAIN --------------
         ---------------------------------------*/
        private void RemainCustomers_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CustomerRemainUserControl();
        }
        /* --------------------------------------- 
           ---------SUPPLIER SECTION --------------
           ---------------------------------------*/
        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            if (SupplierDropDownList.Visibility == Visibility.Visible)
            {
                SupplierDropDownList.Visibility = Visibility.Collapsed;
            }
            else
            {
                SupplierDropDownList.Visibility = Visibility.Visible;
            }
        }

        /* --------------------------------------- 
           ---------SUPPLIER DETAILS --------------
           ---------------------------------------*/
        private void SupplierDetails_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SupplierUserControl();
        }
        /* --------------------------------------- 
        ---------SUPPLIERS ORDERS --------------
        ---------------------------------------*/
        private void SupplierOrder_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SupplierProductBillsUserControl(User);

        }
        /* --------------------------------------- 
          --------- SUPPLIERS BILLS --------------
          ---------------------------------------*/
        private void ShowSupplierBills_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ShowSuppliersBillsUserControl();
        }
        /* --------------------------------------- 
         --------- SUPPLIERS RETURN --------------
         ---------------------------------------*/
        private void ReturnSupplier_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ReturnSypplierBillUserControl();
        }
        /* --------------------------------------- 
         --------- SUPPLIERS REMAIN --------------
         ---------------------------------------*/
        private void RemainSupplier_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SupplierRemainUserControl();
        }

        /* --------------------------------------- 
         --------- REPORTS --------------
         ---------------------------------------*/
        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ReportsUserControl();
        }
        /* --------------------------------------- 
          ---------MINIMIZE FORM --------------
          ---------------------------------------*/
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
           this.WindowState = WindowState.Minimized;
        }
        /* --------------------------------------- 
          ---------CLOSE FORM --------------
          ---------------------------------------*/
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
    }
}