using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    public class User
    {
        public int ID { get; set; }
        public string Namer { get; set; }
        public string Password { get; set; }
        public List<CustomerOrder> CustomerOrders { get; set; }
        public List<SupplierOrder> SupplierOrders { get; set; }
    }
}
