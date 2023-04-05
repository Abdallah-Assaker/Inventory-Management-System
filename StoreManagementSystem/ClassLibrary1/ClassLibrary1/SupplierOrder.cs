using System.Collections.Generic;

namespace InventoryManagementSystem
{ 
    public class SupplierOrder : Order
	{
		public int? SupplierID { get; set; }
		public virtual Supplier Supplier { get; set; }

        public virtual List<SupplierProductBill> SupplierProductBills { get; set; }
        public virtual List<ReturnSupplierOrder> ReturnSupplierOrders { get; set; }

    }

}
