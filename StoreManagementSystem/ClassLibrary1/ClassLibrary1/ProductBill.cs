using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    public class ProductBill
    {
        public int ID { get; set; }
        public int? ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public int ReturnQuantity { get; set; }
        public float TotalPrice { get; set; }
    }
    public class CustomerProductBill : ProductBill
    {
        public int? CustomerOrderID { get; set; }
        public virtual CustomerOrder CustomerOrder { get; set; }
    }
    public class SupplierProductBill : ProductBill 
    {
        public int? SupplierOrderID { get; set; }
        public virtual SupplierOrder SupplierOrder { get; set; }
    }
}
