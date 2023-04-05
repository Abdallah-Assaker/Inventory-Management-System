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
    /// Interaction logic for ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl             //////////////////////////////
    {
        Context context = new Context();
        public ProductUserControl()
        {
            InitializeComponent();
            Loaded += ProductUserControl_Loaded;
        }

        private void ProductUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //FillCreateProductInventoryComboBox();
            CreateProduct_FillInventoryComboBox();
        }

        private void btnNewProduct_Click(object sender, RoutedEventArgs e)
        {
            CreateProduct_CreateNewProduct();
            CreateProduct_EmptyCreateProductsInputFields();
        }

        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            CreateProduct_UpdateProductItem();
            CreateProduct_EmptyCreateProductsInputFields();
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            CreateProduct_DeleteProductItem();
            CreateProduct_EmptyCreateProductsInputFields();
        }

        private void comboProductInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateProduct_FillListViewWithInventoryProducts();
        }

        private void listProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateProduct_AttachListViewProductToInputs();
        }

        private void comboProductCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateProduct_FillListViewWithCategoryProducts();
            CreateProduct_EmptyCreateProductsInputFields();
        }

        private void CreateProduct_CreateNewProduct() // modified
        {
            if (
                txtProductName.Text == string.Empty
                || txtProductSellPrice.Text == string.Empty
                || txtProductQuantity.Text == string.Empty
                || txtProductPrice.Text == string.Empty
                )
            {
                MessageBox.Show("Please Enter Product Details");
                return;
            }

            string productName = txtProductName.Text;

            if (
                 int.TryParse(txtProductQuantity.Text, out int quantity)
                || float.TryParse(txtProductPrice.Text, out float price)
                || float.TryParse(txtProductSellPrice.Text, out float sellPrice)
                )
            {
                MessageBox.Show("Please Enter Valid Numbers");
                return;
            }

            if (quantity < 0)
            {
                quantity = 0;
            }

            if (price < 0)
            {
                price = 0;
            }


            Category category = comboProductCategory.SelectedItem as Category;
            Inventory Inventory = comboProductInventory.SelectedItem as Inventory;

            if (
                 category == null
                || Inventory == null
                )
            {
                MessageBox.Show("Please Select Inventory And Category");
                return;
            }

            Product product = new Product()
            {
                Name = productName,
                Quantity = quantity,
                Price = price,
                SellPrice = sellPrice,
                Category = category,
                Inventory = Inventory,
                SupplierProductBills = new List<SupplierProductBill>(),
                CustomerProductBills = new List<CustomerProductBill>(),
            };

            context.Products.Add(product);

            context.SaveChanges();
            UpdateProductsListView();
            CreateProduct_EmptyCreateProductsInputFields();
        }

        private void UpdateProductsListView()
        {
            List<Product> products = CreateProduct_GetCategoryOrInventoryProducts();
            listProducts.ItemsSource = products;
        }

        private List<Product> CreateProduct_GetCategoryOrInventoryProducts()
        {
            Inventory Inventory = comboProductInventory.SelectedItem as Inventory;
            Category category = comboProductCategory.SelectedItem as Category;

            if (Inventory == null)
            {
                return null;
            }

            if (category != null)
            {
                return Inventory.Products.Where(P => P.Category == category).ToList();
            }
            else
            {
                return Inventory.Products;
            }
        }

        private void CreateProduct_UpdateProductItem()            //modified
        {
            if (
                txtProductName.Text == string.Empty
                || txtProductSellPrice.Text == string.Empty
                || txtProductQuantity.Text == string.Empty
                || txtProductPrice.Text == string.Empty
                )
            {
                MessageBox.Show("Please Enter Product Details");
                return;
            }

            Inventory inventory = comboProductInventory.SelectedItem as Inventory;
            Product product = listProducts.SelectedItem as Product;
            Category category = comboProductCategory.SelectedItem as Category;

            if (
                product == null
                || category == null
                || inventory == null
                )
            {
                MessageBox.Show("Please Select Product, Inventory And Category");
                return;
            }

            if (
                 int.TryParse(txtProductQuantity.Text, out int quantity)
                || float.TryParse(txtProductPrice.Text, out float price)
                || float.TryParse(txtProductSellPrice.Text, out float sellPrice)
                )
            {
                MessageBox.Show("Please Enter Valid Numbers");
                return;
            }

            product.Name = txtProductName.Text.Trim();
            product.SellPrice = sellPrice;
            product.Quantity = quantity;
            product.Price = price;
            product.Category = category;
            product.Inventory = inventory;

            context.SaveChanges();
            UpdateProductsListView();
            CreateProduct_EmptyCreateProductsInputFields();
        }

        private void CreateProduct_DeleteProductItem()
        {
            Inventory inventory = comboProductInventory.SelectedItem as Inventory;
            Product product = listProducts.SelectedItem as Product;
            if (product == null || inventory == null)
            {
                MessageBox.Show("Please Select Product");
                return;

            }

            product.Quantity = 0;

            context.SaveChanges();

            //UpdateProductsListView();
            CreateProduct_EmptyCreateProductsInputFields();
        }

        private void CreateProduct_FillListViewWithInventoryProducts()
        {
            Inventory inventory = comboProductInventory.SelectedItem as Inventory;

            if (inventory != null)
            {
                List<Category> categories = inventory.InventoryCategories.Select(c => c.Category).ToList();
                comboProductCategory.ItemsSource = categories;
                UpdateProductsListView();
            }
        }

        private void CreateProduct_AttachListViewProductToInputs()
        {
            Product product = listProducts.SelectedItem as Product;

            if (product == null)
            {
                return;
            }

            txtProductName.Text = product.Name;
            txtProductPrice.Text = product.Price.ToString();
            txtProductQuantity.Text = product.Quantity.ToString();
            txtProductSellPrice.Text = product.SellPrice.ToString();

            foreach (Inventory item in comboProductInventory.Items)
            {
                if (item == product.Inventory)
                {
                    comboProductInventory.SelectedItem = item;
                }
            }

            foreach (Category item in comboProductCategory.Items)
            {
                if (item == product.Category)
                {
                    comboProductCategory.SelectedItem = item;
                }
            }
        }

        private void CreateProduct_FillListViewWithCategoryProducts()
        {
            Category category = comboProductCategory.SelectedItem as Category;

            if (category != null)
            {
                UpdateProductsListView();
            }
        }

        private async void CreateProduct_FillInventoryComboBox()
        {
            List<Inventory> inventories = context.Inventories
                .Include(i => i.InventoryCategories)
                .ThenInclude(ic => ic.Category)
                .Include(i => i.Products)
                .ThenInclude(p => p.Category)
                .ToList();

            await Task.Run(() =>
            {
                List<Inventory> inventories = context.Inventories.ToList();
                this.BeginInvoke(() => comboProductInventory.ItemsSource = inventories);
            });
        }

        private void CreateProduct_EmptyCreateProductsInputFields()
        {
            txtProductName.Text = txtProductQuantity.Text = txtProductPrice.Text = txtProductSellPrice.Text = string.Empty;
        }
    }
}

