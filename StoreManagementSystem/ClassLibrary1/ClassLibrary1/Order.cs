using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
	public class Order
	{
		public int ID { get; set; }
		public DateTime OrderedOn { get; set; }
		public float Paid { get; set; }
		public float TotalPrice { get; set; }
		public float Remain { get; set; }
		public int? InventoryID { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }
		public virtual Inventory Inventory { get; set; }
	}
}
