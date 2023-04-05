using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClassLibrary1.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remain = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remain = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InventoryCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InventoryCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryCategories_Inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    SellPrice = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    InventoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Products_Inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    Net = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    OrderedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Paid = table.Column<float>(type: "real", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    Remain = table.Column<float>(type: "real", nullable: false),
                    InventoryID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SupplierOrders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    OrderedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Paid = table.Column<float>(type: "real", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    Remain = table.Column<float>(type: "real", nullable: false),
                    InventoryID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SupplierOrders_Inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SupplierOrders_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SupplierOrders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CustomerProductBills",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerOrderID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ReturnQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProductBills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerProductBills_CustomerOrders_CustomerOrderID",
                        column: x => x.CustomerOrderID,
                        principalTable: "CustomerOrders",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CustomerProductBills_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ReturnCustomerOrder",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerOrderID = table.Column<int>(type: "int", nullable: true),
                    InventoryID = table.Column<int>(type: "int", nullable: true),
                    OrderedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnCustomerOrder", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReturnCustomerOrder_CustomerOrders_CustomerOrderID",
                        column: x => x.CustomerOrderID,
                        principalTable: "CustomerOrders",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ReturnCustomerOrder_Inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ReturnSupplierOrders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierOrderID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    InventoryID = table.Column<int>(type: "int", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    OrderedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnSupplierOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReturnSupplierOrders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ReturnSupplierOrders_Inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ReturnSupplierOrders_SupplierOrders_SupplierOrderID",
                        column: x => x.SupplierOrderID,
                        principalTable: "SupplierOrders",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ReturnSupplierOrders_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SupplierProductBills",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierOrderID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ReturnQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProductBills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SupplierProductBills_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SupplierProductBills_SupplierOrders_SupplierOrderID",
                        column: x => x.SupplierOrderID,
                        principalTable: "SupplierOrders",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ReturnCustomerProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnCustomerOrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnCustomerProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReturnCustomerProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ReturnCustomerProducts_ReturnCustomerOrder_ReturnCustomerOrderID",
                        column: x => x.ReturnCustomerOrderID,
                        principalTable: "ReturnCustomerOrder",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnSupplierProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnSupplierOrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnSupplierProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReturnSupplierProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ReturnSupplierProducts_ReturnSupplierOrders_ReturnSupplierOrderID",
                        column: x => x.ReturnSupplierOrderID,
                        principalTable: "ReturnSupplierOrders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "TVs" },
                    { 2, "Phones" },
                    { 3, "TVs" },
                    { 4, "Phones" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Name", "Phone", "Remain" },
                values: new object[,]
                {
                    { 1, "Ahmed Mohammed", "01054987625", 0f },
                    { 2, "Hosam Mohammed", "01154980048", 0f }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "ID", "Location" },
                values: new object[,]
                {
                    { 1, "Sohag" },
                    { 2, "Asyut" },
                    { 3, "Cairo" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "ID", "Name", "Phone", "Remain" },
                values: new object[,]
                {
                    { 1, "Hassn Ahmed", "01479687625", 0f },
                    { 2, "Khaled Mohammed", "01287625738", 0f }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "InventoryID", "Name", "Price", "Quantity", "SellPrice" },
                values: new object[,]
                {
                    { 1, 2, 1, "Samsung", 1500f, 10, 2000f },
                    { 2, 2, 1, "IPone", 2000f, 15, 2300f },
                    { 3, 1, 1, "LG", 5000f, 50, 6000f },
                    { 4, 1, 2, "LG", 2000f, 15, 2300f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_CustomerID",
                table: "CustomerOrders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_InventoryID",
                table: "CustomerOrders",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_UserID",
                table: "CustomerOrders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProductBills_CustomerOrderID",
                table: "CustomerProductBills",
                column: "CustomerOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProductBills_ProductID",
                table: "CustomerProductBills",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCategories_CategoryID",
                table: "InventoryCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCategories_InventoryID",
                table: "InventoryCategories",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryID",
                table: "Products",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnCustomerOrder_CustomerOrderID",
                table: "ReturnCustomerOrder",
                column: "CustomerOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnCustomerOrder_InventoryID",
                table: "ReturnCustomerOrder",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnCustomerProducts_ProductID",
                table: "ReturnCustomerProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnCustomerProducts_ReturnCustomerOrderID",
                table: "ReturnCustomerProducts",
                column: "ReturnCustomerOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnSupplierOrders_CustomerID",
                table: "ReturnSupplierOrders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnSupplierOrders_InventoryID",
                table: "ReturnSupplierOrders",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnSupplierOrders_SupplierID",
                table: "ReturnSupplierOrders",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnSupplierOrders_SupplierOrderID",
                table: "ReturnSupplierOrders",
                column: "SupplierOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnSupplierProducts_ProductID",
                table: "ReturnSupplierProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnSupplierProducts_ReturnSupplierOrderID",
                table: "ReturnSupplierProducts",
                column: "ReturnSupplierOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrders_InventoryID",
                table: "SupplierOrders",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrders_SupplierID",
                table: "SupplierOrders",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrders_UserID",
                table: "SupplierOrders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProductBills_ProductID",
                table: "SupplierProductBills",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProductBills_SupplierOrderID",
                table: "SupplierProductBills",
                column: "SupplierOrderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProductBills");

            migrationBuilder.DropTable(
                name: "InventoryCategories");

            migrationBuilder.DropTable(
                name: "ReturnCustomerProducts");

            migrationBuilder.DropTable(
                name: "ReturnSupplierProducts");

            migrationBuilder.DropTable(
                name: "SupplierProductBills");

            migrationBuilder.DropTable(
                name: "ReturnCustomerOrder");

            migrationBuilder.DropTable(
                name: "ReturnSupplierOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "SupplierOrders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
