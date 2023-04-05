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
    /// Interaction logic for ShowCustomerBillDetailesUserControl.xaml
    /// </summary>
    public partial class ShowCustomerBillDetailesUserControl : UserControl
    {
        private Main_Window Main_Window;
        private CustomerOrder CustomerOrder { get; set; }
        public ShowCustomerBillDetailesUserControl(CustomerOrder customerOrder)
        {
            InitializeComponent();
            Main_Window = new Main_Window();
            CustomerOrder = customerOrder;

            Loaded += ShowCustomerBillDetailesUserControl_Loaded;
        }

        private void ShowCustomerBillDetailesUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillCustomerBillPageDetails();
        }

        private void FillCustomerBillPageDetails()
        {
            txtShowCustomerBillID.Text = CustomerOrder.ID.ToString();
            txtShowCustomerBillInventory.Text = CustomerOrder.Inventory.Location;
            txtShowCustomerBillCustomer.Text = CustomerOrder.Customer.Name;
            txtShowCustomerBillTotal.Text = CustomerOrder.TotalPrice.ToString();
            txtShowCustomerBillRemain.Text = CustomerOrder.Remain.ToString();
            txtShowCustomerBillDate.Text = CustomerOrder.OrderedOn.ToShortDateString();
            txtShowCustomerBillQty.Text = CustomerOrder.CustomerProductBills.Sum(cpb => cpb.Quantity).ToString();
            //txtShowCustomerBillUser.Text = CustomerOrder.User.Namer;
            lvShowCustomerBill.ItemsSource = CustomerOrder.CustomerProductBills.ToList();

            lvShowCustomerReturnBill.ItemsSource = CustomerOrder.ReturnCustomerOrders
                .SelectMany(rco => rco.ReturnCustomerProducts)
                .Select(rcp => new
                {
                    Name = rcp.Product.Name,
                    Quantity = rcp.Quantity,
                    OrderedOn = rcp.ReturnCustomerOrder.OrderedOn,
                })
                .ToList();
        }

        private void btnShowCustomerBillHide_Click(object sender, RoutedEventArgs e)
        {
            Main_Window.window.Main.Content = new ShowCustomersBillsUserControl();

        }
    }
}