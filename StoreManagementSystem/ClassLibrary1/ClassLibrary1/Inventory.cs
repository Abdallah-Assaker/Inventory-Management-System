using System.Collections.Generic;

namespace InventoryManagementSystem
{
	public class Inventory
	{
        public int ID { get; set; }
		public string Location { get; set; }
		public virtual List<InventoryCategory> InventoryCategories { get; set; }
		public virtual List<Product> Products { get; set; }
		public virtual List<SupplierOrder> SupplierOrders { get; set; }
		public virtual List<CustomerOrder> CustomerOrder { get; set; }
        public virtual List<ReturnSupplierOrder> ReturnSupplierOrder { get; set; }
        public virtual List<ReturnCustomerOrder> ReturnCustomerOrder { get; set; }


        //public void AddCategory(Category category)
        //{
        //	foreach (Category cat in Categories)
        //	{
        //		if (cat.Name.ToLower() == category.Name.ToLower())
        //		{
        //			return;
        //		}
        //	}

        //	Categories.Add(category);
        //}


        public void AddProduct(Product product, int quantity)
        {
            if (ProductExist(product))
            {
                IncreaseProductQuantity(product, quantity);
            }
            else
            {
                AddNewProduct(product, quantity);
            }
        }

        private bool ProductExist(Product product)
        {
            foreach (Product item in Products)
            {
                if (item.Name == product.Name)
                {
                    return true;
                }
            }
            return false;
        }

        private void IncreaseProductQuantity(Product product, int qunatity)
        {
            foreach (Product item in Products)
            {
                if (item.Name == product.Name)
                {
                    item.Quantity += qunatity;
                }
            }
        }
        private void AddNewProduct(Product product, int Quantity)
        {
            if (product == null)
            { product = new Product(); }
            Products.Add(product);
        }
        public void RemoveProduct(Product product, int quantity)
        {
            foreach (Product item in Products)
            {
                if (product.Name == item.Name)
                {
                    if (product.Quantity >= item.Quantity)
                    {
                        item.Quantity -= quantity;
                    }
                }
            }
        }

    }

    public class InventoryCategory
	{
		public int ID { get; set; }
		public virtual Inventory Inventory { get; set; }
		public virtual Category Category { get; set; }
	}
}
