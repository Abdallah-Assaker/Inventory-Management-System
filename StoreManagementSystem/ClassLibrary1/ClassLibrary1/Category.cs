using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
	public class Category
	{
		public int ID { get; set; } ////////////////////// modified
		public string Name { get; set; }
		public virtual List<Product> products { get; set; }
		public virtual List<InventoryCategory> InventoryCategories { get; set; }
	}
}
