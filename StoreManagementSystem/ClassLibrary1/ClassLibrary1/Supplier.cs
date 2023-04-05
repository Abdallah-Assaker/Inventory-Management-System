using System.Collections.Generic;

namespace InventoryManagementSystem
{
	public class Supplier
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public float Remain { get; set; }
		public virtual List<SupplierOrder> SupplierOrders { get; set; }
        public virtual List<ReturnSupplierOrder> ReturnSupplierOrder { get; set; }

    }


}
