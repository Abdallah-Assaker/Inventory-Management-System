using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    public class ReturnProduct
    {
        public int ID { get; set; }
        public int? ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
    public class ReturnCustomerProduct : ReturnProduct 
    {
        public int ID { get; set; }
        public int ReturnCustomerOrderID { get; set; }
        public virtual ReturnCustomerOrder ReturnCustomerOrder { get; set; }
    }
    public class ReturnSupplierProduct : ReturnProduct
    {
        public int ID { get; set; }
        public int ReturnSupplierOrderID { get; set; }
        public virtual ReturnSupplierOrder ReturnSupplierOrder { get; set; }
    }
}
