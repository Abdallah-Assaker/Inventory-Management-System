using System.Collections.Generic;

namespace InventoryManagementSystem
{
	public class Product
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public float Price { get; set; }
		public float SellPrice { get; set; }
		public int Quantity { get; set; }
		public int? CategoryID { get; set; }
        public int? InventoryID { get; set; }
        public virtual Inventory Inventory { get; set; }
		public virtual Category Category { get; set; }
		public virtual List<CustomerProductBill> CustomerProductBills { get; set; }
        public virtual List<SupplierProductBill> SupplierProductBills { get; set; }
        public virtual List<ReturnCustomerProduct> ReturnCustomerProducts { get; set; }
        public virtual List<ReturnSupplierProduct> ReturnSupplierProducts { get; set; }


    }
}
