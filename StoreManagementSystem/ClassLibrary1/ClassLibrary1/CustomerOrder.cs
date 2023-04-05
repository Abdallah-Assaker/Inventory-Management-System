using System.Collections.Generic;

namespace InventoryManagementSystem
{
	public class CustomerOrder : Order
	{
		public int? CustomerID { get; set; }
		public virtual Customer Customer { get; set; }
		public float Net { get; set; }
		public float Discount { get; set; }
		public virtual List<CustomerProductBill> CustomerProductBills { get; set; }
		public virtual List<ReturnCustomerOrder> ReturnCustomerOrders { get; set; }

    }


}
