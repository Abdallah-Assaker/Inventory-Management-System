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
    /// Interaction logic for ShowSupplierBillDetailsUserControl.xaml
    /// </summary>
    public partial class ShowSupplierBillDetailsUserControl : UserControl
    {
        Main_Window Main_Window;
        private SupplierOrder SupplierOrder { get; set; }
        public ShowSupplierBillDetailsUserControl(SupplierOrder supplierOrder)
        {
            InitializeComponent();

            SupplierOrder = supplierOrder;
            Main_Window = new Main_Window();

            Loaded += ShowSupplierBillDetailsUserControl_Loaded;
        }

        private void ShowSupplierBillDetailsUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillSupplierBillPageDetails();
        }

        private void FillSupplierBillPageDetails()
        {
            txtShowSupplierBillID.Text = SupplierOrder.ID.ToString();
            txtShowSupplierBillInventory.Text = SupplierOrder.Inventory.Location;
            txtShowSupplierBillSupplier.Text = SupplierOrder.Supplier.Name;
            txtShowSupplierBillTotal.Text = SupplierOrder.TotalPrice.ToString();
            txtShowSupplierBillRemain.Text = SupplierOrder.Remain.ToString();
            txtShowSupplierBillDate.Text = SupplierOrder.OrderedOn.ToShortDateString();
            txtShowSupplierBillQty.Text = SupplierOrder.SupplierProductBills.Sum(cpb => cpb.Quantity).ToString();
            lvShowSupplierBill.ItemsSource = SupplierOrder.SupplierProductBills.ToList();
            //txtShowSupplierBillUser.Text = SupplierOrder.User.Namer;

            lvShowSupplierReturnBill.ItemsSource = SupplierOrder.ReturnSupplierOrders
                .SelectMany(rco => rco.ReturnSupplierProducts)
                .Select(rcp => new
                {
                    Name = rcp.Product.Name,
                    Quantity = rcp.Quantity,
                    OrderedOn = rcp.ReturnSupplierOrder.OrderedOn,
                })
                .ToList();
        }

        private void btnShowSupplierBillHide_Click(object sender, RoutedEventArgs e)
        {
            Main_Window.window.Main.Content = new ShowSuppliersBillsUserControl();
        }
    }
}
