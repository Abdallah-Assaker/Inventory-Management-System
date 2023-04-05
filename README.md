# Inventory Management System

The Inventory Management System is a comprehensive software application that allows the user to manage the inventory of multiple stores. It has several modules such as login, inventory, category, product, customer, supplier, invoice, return, and report.

## System Architecture

The system is developed using a Two-layers architecture: presentation and business layer, Models and data access layer. The presentation and business layer is responsible for user interface, input validation, the business logic and is responsible for processing data. The data access layer is developed using Entity Framework Core and is responsible for database connectivity and data manipulation.

## System Modules

**Login Module**: This module allows the user to log in to the system as a system administrator.
**Inventory Module**: This module allows the user to manage multiple inventories or stores. The user can add, edit, and delete inventories or stores.
**Category Module**: This module allows the user to manage categories. The user can add, edit, and delete categories.
**Product Module**: This module allows the user to manage products. The user can add, edit, and delete products. The user can enter the product's bought price, selling price, quantity, and category. The user can also assign the product to a specific inventory or store.
**Customer Module**: This module allows the user to manage customers. The user can add, edit, and delete customers.
**Supplier Module**: This module allows the user to manage suppliers. The user can add, edit, and delete suppliers.
**Invoice Module**: This module allows the user to create invoices for customers and suppliers. The user can select the inventory, customer or supplier, and products with their quantities. The system automatically calculates the total amount.
**Return Module**: This module allows the user to manage returns for customers and suppliers. The user can select the related invoice and the products with their quantities. The system automatically updates the inventory or store quantity.
**Report Module**: This module allows the user to generate reports for all stores or specific stores. The system provides the following reports:
-Best Selling Products Report: This report shows the best selling products.
-Least Product Quantities Report: This report shows the products that are running out.
-Top Suppliers Report: This report shows the top suppliers.
-Top Customers Report: This report shows the top customers.
-Highest Suppliers Remaining Report: This report shows the suppliers who have the highest remaining amount.
-Highest Customers Remaining Report: This report shows the customers who have the highest remaining amount.
-Total Purchases Report: This report shows the total purchases.
-Total Sellings Report: This report shows the total sellings.

## Technologies Used

The system is developed using **C#**, **WPF**, **Entity Framework Core**, and **SQL**.
