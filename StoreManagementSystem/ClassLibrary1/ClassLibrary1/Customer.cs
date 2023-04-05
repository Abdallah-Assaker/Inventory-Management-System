using System.Collections.Generic;

namespace InventoryManagementSystem
{
	public class Customer
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public float Remain { get; set; }
		public virtual List<CustomerOrder> CustomerOrders { get; set; }
        public virtual List<ReturnSupplierOrder> ReturnSupplierOrder { get; set; }

    }


}
