using InventoryManagementSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
	public class Context : DbContext
	{
		public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InventoryCategory> InventoryCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierOrder> SupplierOrders { get; set; }
        public DbSet<ReturnSupplierOrder> ReturnSupplierOrders { get; set; }
        public DbSet<SupplierProductBill> SupplierProductBills { get; set; }
        public DbSet<ReturnSupplierProduct> ReturnSupplierProducts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CustomerProductBill> CustomerProductBills { get; set; }
        public DbSet<ReturnCustomerOrder> ReturnCustomerOrder { get; set; }
        public DbSet<ReturnCustomerProduct> ReturnCustomerProducts { get; set; }
        public DbSet<User> Users { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
					.UseSqlServer(@"Data source=DESKTOP-M0HL8AK; initial catalog = InventoriesManagementSystem; Integrated Security=True; trust server certificate = true");


			//base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

            modelBuilder.Entity<Inventory>().ToTable("Inventories");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Customer>().ToTable("Customers");


            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    ID = 1,
                    Location = "Sohag",
                },
                new Inventory
                {
                    ID = 2,
                    Location = "Asyut",
                },
                new Inventory
                {
                    ID = 3,
                    Location = "Cairo",
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    ID = 1,
                    Name= "TVs",
                    
                },
                new Category
                {
                    ID = 2,
                    Name = "Phones",
                   
                },
                new Category
                {
                    ID = 3,
                    Name = "TVs",
                    
                },
                new Category
                {
                    ID = 4,
                    Name = "Phones",
                    
                }
            );



            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name = "Samsung",
                    Price = 1500,
                    SellPrice=2000,
                    Quantity=10,
                    CategoryID=2,
                    InventoryID=1,
                },
                new Product
                {
                    ID = 2,
                    Name = "IPone",
                    Price = 2000,
                    SellPrice = 2300,
                    Quantity = 15,
                    CategoryID = 2,
                    InventoryID = 1,
                },
                new Product
                {
                    ID = 3,
                    Name = "LG",
                    Price = 5000,
                    SellPrice = 6000,
                    Quantity = 50,
                    CategoryID = 1,
                    InventoryID = 1,
                },
                new Product
                {
                    ID = 4,
                    Name = "LG",
                    Price = 2000,
                    SellPrice = 2300,
                    Quantity = 15,
                    CategoryID = 1,
                    InventoryID = 2,
                }
            );




            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                   ID=1,
                   Name="Ahmed Mohammed",
                   Phone="01054987625",
                   Remain=0
                },
                new Customer
                {
                    ID = 2,
                    Name = "Hosam Mohammed",
                    Phone = "01154980048",
                    Remain = 0
                }
            );

            modelBuilder.Entity<Supplier>().HasData(
               new Supplier
               {
                   ID = 1,
                   Name = "Hassn Ahmed",
                   Phone = "01479687625",
                   Remain = 0
               },
               new Supplier
               {
                   ID = 2,
                   Name = "Khaled Mohammed",
                   Phone = "01287625738",
                   Remain = 0
               }
           );




            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //	relationship.DeleteBehavior = DeleteBehavior.NoAction;
            //}

            //modelBuilder.Entity<Inventory>().HasData(SampleData.Inventories[0]);
            //modelBuilder.Entity<Inventory>().HasData(SampleData.Inventories[1]);

            //modelBuilder.Entity<Supplier>().HasData(SampleData.Suppliers[0]);
            //modelBuilder.Entity<Supplier>().HasData(SampleData.Suppliers[1]);

            //modelBuilder.Entity<Customer>().HasData(SampleData.Customers[0]);
            //modelBuilder.Entity<Customer>().HasData(SampleData.Customers[1]);

            //modelBuilder.Entity<CustomerBill>().HasData(SampleData.CustomerBill1);
            //modelBuilder.Entity<CustomerBill>().HasData(SampleData.CustomerBill2);



            //base.OnModelCreating(modelBuilder);
        }




    }
}
