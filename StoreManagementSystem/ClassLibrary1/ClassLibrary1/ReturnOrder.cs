using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    public class ReturnOrder
    {
        public int ID { get; set; }
        public DateTime OrderedOn { get; set; }
        public float TotalPrice { get; set; }
    }

    public class ReturnCustomerOrder : ReturnOrder
    {
        public int? CustomerOrderID { get; set; }
        public virtual CustomerOrder CustomerOrder { get; set; }
        public virtual List<ReturnCustomerProduct> ReturnCustomerProducts { get; set; }
    }
    public class ReturnSupplierOrder : ReturnOrder
    {
        public int? SupplierOrderID { get; set; }
        public virtual SupplierOrder SupplierOrder { get; set; }
        public virtual List<ReturnSupplierProduct> ReturnSupplierProducts { get; set; }
    }
}
