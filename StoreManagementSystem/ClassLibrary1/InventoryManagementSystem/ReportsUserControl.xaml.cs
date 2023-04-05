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
    /// Interaction logic for ReportsUserControl.xaml
    /// </summary>
    public partial class ReportsUserControl : UserControl
    {
        Context context = new Context();
        public ReportsUserControl()
        {
            InitializeComponent();
            Loaded += ReportsUserControl_Loaded;
        }

        private void ReportsUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillReportsInventoryComboBox();
            StartReports();
        }

        private void chkReportSelectInventory_Checked(object sender, RoutedEventArgs e)
        {
            SetReportsInventoryComboBox();
            StartReports();
        }


        private void comboReportInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StartReports();
        }

        private void FillReportsInventoryComboBox()
        {
            comboReportInventory.ItemsSource = context.Inventories.ToList();
            SetReportsInventoryComboBox();
        }

        private void StartReports()
        {
            if ((bool)chkReportSelectInventory.IsChecked)
            {
                DiplaySingleInventoryReports();
            }
            else
            {
                DiplayAllInventoriesReports();
            }
        }

        private void SetReportsInventoryComboBox()
        {
            if ((bool)chkReportSelectInventory.IsChecked)
            {
                comboReportInventory.IsEnabled = true;
            }
            else
            {
                comboReportInventory.IsEnabled = false;
            }
        }

        //All Inventories Reports

        private void DiplayAllInventoriesReports()
        {
            ReportTopSellingProductsAllInventories();
            ReportTopSuppliersAllInventories();
            ReportTopCustomersAllInventories();
            ReportLeastProductsQuantityAllInventories();
            RepotsHighestSupplierRemainingAllInventories();
            RepotsHighestCustomerRemainingAllInventories();
            RepotsTotlalSellingsAllInventories();
            RepotsTotlalPurchasesAllInventories();
        }

        private void RepotsTotlalPurchasesAllInventories()
        {
            lvRepotsTotlalPurchases.Items.Clear();

            //var totalPurchases = new
            //{
            //    Quantity = context.SupplierOrders.SelectMany(so => so.SupplierProductBills).Sum(spb => spb.Quantity),
            //    Total = context.SupplierOrders.Sum(so => so.TotalPrice)
            //};

            float TotalPaid = context.SupplierOrders.Sum(so => so.TotalPrice);

            float totaleturns = context.ReturnSupplierOrders.Sum(rso => rso.TotalPrice);

            int quantityIn = context.SupplierOrders.SelectMany(so => so.SupplierProductBills).Sum(spb => spb.Quantity);

            int quantityOut = context.ReturnSupplierOrders.SelectMany(rso => rso.ReturnSupplierProducts).Sum(rsp => rsp.Quantity);

            var totalPurchases = new
            {
                Quantity = quantityIn - quantityOut,
                Total = TotalPaid - totaleturns,
            };

            lvRepotsTotlalPurchases.Items.Add(totalPurchases);
        }

        private void RepotsTotlalSellingsAllInventories()
        {
            lvRepotsTotlalSellings.Items.Clear();

            //var totalSellings = new
            //{
            //    Quantity = context.CustomerOrders
            //                .SelectMany(co => co.CustomerProductBills)
            //                .Sum(cpb => cpb.Quantity),

            //    Total = context.CustomerOrders
            //                .Sum(co => co.TotalPrice),
            //};

            float TotalPaid = context.CustomerOrders.Sum(so => so.TotalPrice);

            float totaleturns = context.ReturnCustomerOrder.Sum(rso => rso.TotalPrice);

            int quantityIn = context.CustomerOrders.SelectMany(so => so.CustomerProductBills).Sum(spb => spb.Quantity);

            int quantityOut = context.ReturnCustomerOrder.SelectMany(rso => rso.ReturnCustomerProducts).Sum(rsp => rsp.Quantity);

            var totalSellings = new
            {
                Quantity = quantityIn - quantityOut,
                Total = TotalPaid - totaleturns,
            };

            lvRepotsTotlalSellings.Items.Add(totalSellings);
        }

        private void ReportLeastProductsQuantityAllInventories()
        {
            var ProQty = context.Products
                .GroupBy(p => p.Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Category = g.FirstOrDefault().Category.Name,
                    Quantity = g.Sum(p => p.Quantity),
                })
                .OrderBy(a => a.Quantity)
                .Take(3)
                .ToList();

            lvRepotsLeastProductsQuantity.ItemsSource = ProQty;
        }

        private void RepotsHighestSupplierRemainingAllInventories()
        {
            var highDeptSus = context.Suppliers
                .Select(s => new
                {
                    Name = s.Name,
                    Remain = s.Remain,
                    Bills = s.SupplierOrders.Count,
                })
                .OrderByDescending(a => a.Remain)
                .Take(3)
                .ToList();

            lvRepotsHighestSupplierRemaining.ItemsSource = highDeptSus;
        }

        private void RepotsHighestCustomerRemainingAllInventories()
        {
            var highDeptCus = context.Customers
                .Select(s => new
                {
                    Name = s.Name,
                    Remain = s.Remain,
                    Bills = s.CustomerOrders.Count,
                })
                .OrderByDescending(a => a.Remain)
                .Take(3)
                .ToList();

            lvRepotsHighestCustomerRemaining.ItemsSource = highDeptCus;
        }

        private void ReportTopCustomersAllInventories()
        {
            var customers = context.CustomerOrders
                .GroupBy(co => co.Customer)
                .Select(g => new
                {
                    Name = g.Key.Name,
                    Total = g.Sum(co => co.TotalPrice),
                    ProductQuantites = g.SelectMany(co => co.CustomerProductBills).Sum(cpb => cpb.Quantity),
                })
                .OrderByDescending(a => a.Total)
                .Take(3)
                .ToList();

            lvRepotsTopCustomers.ItemsSource = customers;
        }

        private void ReportTopSuppliersAllInventories()
        {
            var suppliers = context.SupplierOrders
                .GroupBy(so => so.Supplier)
                .Select(g => new
                {
                    Name = g.Key.Name,
                    Total = g.Sum(so => so.TotalPrice),
                    ProductQuantites = g.SelectMany(so => so.SupplierProductBills).Sum(spb => spb.Quantity),
                })
                .OrderByDescending(a => a.Total)
                .Take(3)
                .ToList();

            lvRepotsTopSuppliers.ItemsSource = suppliers;
        }

        private void ReportTopSellingProductsAllInventories()
        {
            var topProducts = context.CustomerOrders
                .SelectMany(co => co.CustomerProductBills)
                .GroupBy(cpb => cpb.Product.Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Category = g.Select(cpb => cpb.Product).FirstOrDefault().Category.Name,
                    Total = g.Sum(cpb => cpb.TotalPrice),
                    SoldQuantity = g.Sum(cpb => cpb.Quantity),
                    RemainingQuantity = g.Sum(cpb => cpb.Product.Quantity),
                })
                .OrderByDescending(a => a.Total)
                .Take(3)
                .ToList();

            lvRepotsTopSellingProducts.ItemsSource = topProducts;
        }

        //Single Inventory Reports

        private void DiplaySingleInventoryReports()
        {
            Inventory inventory = comboReportInventory.SelectedItem as Inventory;

            if (inventory != null)
            {
                ReportTopSellingProductsSingleInventory(inventory);
                ReportTopSuppliersSingleInventory(inventory);
                ReportTopCustomersSingleInventory(inventory);
                ReportLeastProductsQuantitySingleInventory(inventory);
                RepotsHighestSupplierRemainingSingeInventory(inventory);
                RepotsHighestCustomerRemainingSingleInventory(inventory);
                RepotsTotlalSellingsAllInventories(inventory);
                RepotsTotlalPurchasesAllInventories(inventory);
            }
        }

        private void RepotsTotlalPurchasesAllInventories(Inventory inventory)
        {
            lvRepotsTotlalPurchases.Items.Clear();

            //var totalPurchasesInventory = new
            //{
            //    Quantity = context.SupplierOrders
            //                .Where(so => so.Inventory == inventory)                                   //////// Insert Inventoryy HERE
            //                .SelectMany(so => so.SupplierProductBills)
            //                .Sum(spb => spb.Quantity),

            //    Total = context.SupplierOrders
            //                .Where(so => so.Inventory == inventory)                                   //////// Insert Inventoryy HERE
            //                .Sum(so => so.TotalPrice),
            //};

            //lvRepotsTotlalPurchases.Items.Add(totalPurchasesInventory);

            float TotalPaid = context.SupplierOrders.Where(so => so.Inventory == inventory).Sum(so => so.TotalPrice);

            float totaleturns = context.ReturnSupplierOrders.Where(rso => rso.SupplierOrder.Inventory == inventory).Sum(rso => rso.TotalPrice);

            int quantityIn = context.SupplierOrders.Where(so => so.Inventory == inventory).SelectMany(so => so.SupplierProductBills).Sum(spb => spb.Quantity);

            int quantityOut = context.ReturnSupplierOrders.Where(rso => rso.SupplierOrder.Inventory == inventory).SelectMany(rso => rso.ReturnSupplierProducts).Sum(rsp => rsp.Quantity);

            var totalPurchases = new
            {
                Quantity = quantityIn - quantityOut,
                Total = TotalPaid - totaleturns,
            };

            lvRepotsTotlalPurchases.Items.Add(totalPurchases);
        }

        private void RepotsTotlalSellingsAllInventories(Inventory inventory)
        {
            lvRepotsTotlalSellings.Items.Clear();

            //var totalSellingInventory = new
            //{
            //    Quantity = context.CustomerOrders
            //    .Where(co => co.Inventory == inventory)                                   //////// Insert Inventoryy HERE
            //    .SelectMany(co => co.CustomerProductBills)
            //    .Sum(cpb => cpb.Quantity),

            //    Total = context.CustomerOrders
            //    .Where(co => co.Inventory == inventory)                                   //////// Insert Inventoryy HERE
            //    .Sum(co => co.TotalPrice),
            //};

            //lvRepotsTotlalSellings.Items.Add(totalSellingInventory);

            float TotalPaid = context.CustomerOrders.Where(co => co.Inventory == inventory).Sum(so => so.TotalPrice);

            float totaleturns = context.ReturnCustomerOrder.Where(rco => rco.CustomerOrder.Inventory == inventory).Sum(rso => rso.TotalPrice);

            int quantityIn = context.CustomerOrders.Where(co => co.Inventory == inventory).SelectMany(so => so.CustomerProductBills).Sum(spb => spb.Quantity);

            int quantityOut = context.ReturnCustomerOrder.Where(rco => rco.CustomerOrder.Inventory == inventory).SelectMany(rso => rso.ReturnCustomerProducts).Sum(rsp => rsp.Quantity);

            var totalSellings = new
            {
                Quantity = quantityIn - quantityOut,
                Total = TotalPaid - totaleturns,
            };

            lvRepotsTotlalSellings.Items.Add(totalSellings);
        }

        private void ReportLeastProductsQuantitySingleInventory(Inventory inventory)
        {
            var ProQtyInventory = context.Products
                .Where(p => p.Inventory == inventory)                                   //////// Insert Inventoryy HERE
                .GroupBy(p => p.Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Category = g.FirstOrDefault().Category.Name,
                    Quantity = g.Sum(p => p.Quantity),
                })
                .OrderBy(a => a.Quantity)
                .Take(3)
                .ToList();

            lvRepotsLeastProductsQuantity.ItemsSource = ProQtyInventory;
        }

        private void RepotsHighestSupplierRemainingSingeInventory(Inventory inventory)
        {
            var highDeptSus = context.Suppliers
                .SelectMany(s => s.SupplierOrders)
                .Where(so => so.Inventory == inventory)
                .GroupBy(so => so.Supplier)
                .Select(g => new
                {
                    Name = g.Key.Name,
                    Remain = g.Key.Remain,
                    Bills = g.Count(),
                })
                .OrderByDescending(a => a.Remain)
                .Take(3)
                .ToList();

            lvRepotsHighestSupplierRemaining.ItemsSource = highDeptSus;
        }

        private void RepotsHighestCustomerRemainingSingleInventory(Inventory inventory)
        {
            var highDeptCus = context.Customers
                .SelectMany(c => c.CustomerOrders)
                .Where(co => co.Inventory == inventory)
                .GroupBy(co => co.Customer)
                .Select(g => new
                {
                    Name = g.Key.Name,
                    Remain = g.Key.Remain,
                    Bills = g.Count(),
                })
                .OrderByDescending(a => a.Remain)
                .Take(3)
                .ToList();

            lvRepotsHighestCustomerRemaining.ItemsSource = highDeptCus;
        }

        private void ReportTopCustomersSingleInventory(Inventory inventory)
        {
            var customer = context.CustomerOrders
                .Where(co => co.Inventory == inventory)                                    //////// Insert Inventoryy HERE
                .GroupBy(co => co.Customer)
                .Select(g => new
                {
                    Name = g.Key.Name,
                    Total = g.Sum(so => so.TotalPrice),
                    ProductQuantites = g.SelectMany(so => so.CustomerProductBills).Sum(spb => spb.Quantity),
                })
                .OrderByDescending(a => a.Total)
                .Take(3)
                .ToList();

            lvRepotsTopCustomers.ItemsSource = customer;
        }

        private void ReportTopSuppliersSingleInventory(Inventory inventory)
        {
            var supplier = context.SupplierOrders
                .Where(so => so.Inventory == inventory)                                   //////// Insert Inventoryy HERE
                .GroupBy(so => so.Supplier)
                .Select(g => new
                {
                    Name = g.Key.Name,
                    Total = g.Sum(so => so.TotalPrice),
                    ProductQuantites = g.SelectMany(so => so.SupplierProductBills).Sum(spb => spb.Quantity),
                })
                .OrderByDescending(a => a.Total)
                .Take(3)
                .ToList();

            lvRepotsTopSuppliers.ItemsSource = supplier;
        }

        private void ReportTopSellingProductsSingleInventory(Inventory inventory)
        {
            var topInventoryProducts = context.CustomerOrders
                .Where(co => co.Inventory == inventory)                                   //////// Insert Inventoryy HERE
                .SelectMany(co => co.CustomerProductBills)
                .GroupBy(cpb => cpb.Product.Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Category = g.Select(cpb => cpb.Product).FirstOrDefault().Category.Name,
                    Total = g.Sum(cpb => cpb.TotalPrice),
                    SoldQuantity = g.Sum(cpb => cpb.Quantity),
                    RemainingQuantity = g.Sum(cpb => cpb.Product.Quantity),
                })
                .OrderByDescending(a => a.Total)
                .Take(3)
                .ToList();

            lvRepotsTopSellingProducts.ItemsSource = topInventoryProducts;
        }

    }
}
