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
    /// Interaction logic for CategoryUserControl.xaml
    /// </summary>
    public partial class CategoryUserControl : UserControl /////////////////////////
    {
        Context context = new Context();
        public CategoryUserControl()
        {
            InitializeComponent();
            CreateCategory_FillInventoryCombobox();
            //Loaded += CategoryUserControl_Loaded;
        }

        private void CategoryUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CreateCategory_FillInventoryCombobox();
        }

        private void CategoryPage_InventoryComboBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Category> Categories = CreateCategory_GetInventoryCategories();

            if (Categories != null)
            {
                CategoryListView.ItemsSource = Categories;
            }
        }

        private List<Category> CreateCategory_GetInventoryCategories()
        {
            Inventory inventory = CategoryPage_InventoryComboBx.SelectedItem as Inventory;

            if (inventory != null)
            {
                List<Category> categories = inventory.InventoryCategories.Select(ic => ic.Category).ToList();

                return categories;
            }

            return null;
        }

        private void CreateCategory_FillInventoryCombobox()
        {
            List<Inventory> inventories = context.Inventories
                .Include(i => i.InventoryCategories)
                .ThenInclude(ic => ic.Category)
                .ThenInclude(C => C.products)
                .ToList();

            Task.Run(() =>
            {
                List<Inventory> inventories = context.Inventories.ToList();
                this.BeginInvoke(() => CategoryPage_InventoryComboBx.ItemsSource = inventories);
            });
        }

        private void AddNewCategory_Click(object sender, RoutedEventArgs e)
        {
            Add_New_Category();
        }

        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            Update_Category();
        }

        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            Delete_Category();
        }

        private void Add_New_Category()
        {
            Inventory Inventory = CategoryPage_InventoryComboBx.SelectedItem as Inventory;

            if (Inventory == null || CategoryNameInCategoryPageTxtBx.Text == string.Empty)
            {
                MessageBox.Show("Please Select Inventory And Enter Category Name");
                return;
            }

            string name = CategoryNameInCategoryPageTxtBx.Text.Trim();

            if (Inventory.InventoryCategories != null)
            {
                foreach (var item in Inventory.InventoryCategories)
                {
                    if (item.Category.Name == name)
                    {
                        return;
                    }
                }
            }

            if (DoesCategoryExists(name))
            {
                Category currCategory = context.Categories.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());

                InventoryCategory inventoryCat = new InventoryCategory()
                {
                    Category = currCategory,
                    Inventory = Inventory,
                };

                context.InventoryCategories.Add(inventoryCat);

                context.SaveChanges();
            }
            else
            {
                Category category = new Category()
                {
                    Name = name,
                };
                InventoryCategory inventoryCat = new InventoryCategory()
                {
                    Category = category,
                    Inventory = Inventory,
                };

                context.InventoryCategories.Add(inventoryCat);

                context.SaveChanges();
            }

            CreateCategory_UpdateCategoryListView();
        }

        private void CreateCategory_UpdateCategoryListView()
        {
            List<Category> categories = CreateCategory_GetInventoryCategories();
            CategoryListView.ItemsSource = null;
            CategoryListView.ItemsSource = categories;
        }

        private bool DoesCategoryExists(string name)
        {
            foreach (Category category in context.Categories)
            {
                if (category.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void Update_Category()
        {
            Inventory inventory = CategoryPage_InventoryComboBx.SelectedItem as Inventory;
            Category category = CategoryListView.SelectedItem as Category;

            if (inventory == null
                || category == null
                || CategoryNameInCategoryPageTxtBx.Text == string.Empty)
            {
                MessageBox.Show("Please Select Inventory, Category And New Name");
                return;
            }

            string newName = CategoryNameInCategoryPageTxtBx.Text.Trim();

            if (DoesCategoryExists(newName))
            {
                Category oldCategory = context.Categories.Include(c => c.products).FirstOrDefault(c => c.Name == newName);

                if (category.products != null)
                {
                    oldCategory.products.AddRange(category.products);
                }
                if (category.InventoryCategories != null)
                {
                    oldCategory.InventoryCategories.AddRange(category.InventoryCategories);

                }
                context.Categories.Remove(category);

                if (inventory.InventoryCategories.Where(ic => ic.Category == category).Count() > 1)
                {
                    inventory.InventoryCategories.Remove(inventory.InventoryCategories.FirstOrDefault(ic => ic.Category == category));
                }
            }
            else
            {
                //Category SelectedCategory = context.Categories.FirstOrDefault(c => c.ID == category.ID);          ?????????????
                category.Name = newName;
            }

            context.SaveChanges();
            CreateCategory_UpdateCategoryListView();
        }

        private void Delete_Category()
        {
            Inventory inventory = CategoryPage_InventoryComboBx.SelectedItem as Inventory;
            Category category = CategoryListView.SelectedItem as Category;
            if (inventory == null
                || category == null)
            {
                MessageBox.Show("Please Select Category");
                return;
            }

            if (
                category.products != null
                )
            {
                if (category.products.Count > 0)
                {
                    MessageBox.Show("Category Is Not Empty");
                    return;
                }
            }

            var ICs = inventory.InventoryCategories.Where(ic => ic.Category == category);
            context.InventoryCategories.RemoveRange(ICs);

            CreateCategory_UpdateCategoryListView();

            context.SaveChanges();
        }
    }
}
