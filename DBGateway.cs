

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using NorthwindProject.Controllers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;
using NorthwindProject.Views.Home;

namespace NorthwindProject.Models
{
    public class DBGateway
    {

        public List<Product> GetProducts()
        {

            List<Product> listOfProducts = new List<Product>(); //ListofProducts list for putting the datas from database
            Product aProduct;  //parameter of Product


            long productId = 0;
            string productName = "n/a";   //Variable to put the data from database
            long supplierId = 0;
            long categoryId = 0;
            double unitPrice = 999999.99;

            //Make a connection with database
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();

            // Third, set up our SQL statement
            command.CommandText = "select productid, productname, supplierid, categoryid, unitprice from products;";

            // Forth run the sql statement
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())  //till the data is read
            {
                // Try to access the different columns in the reader
                // local variable name = (cast) reader ["database column name"];

                // The conversions are because the C# data types do not match the 
                // SQLite datatypes, they are from different companies
                productId = (long)reader["productId"];
                productName = (string)reader["productname"];
                supplierId = (long)reader["supplierid"];
                categoryId = (long)reader["categoryid"];
                unitPrice = Convert.ToDouble(reader["unitprice"]);

                aProduct = new Product(); //Creating a obj alike to put inside the list

                aProduct.ProductId = Convert.ToInt32(productId);
                aProduct.ProductName = productName;
                aProduct.SupplierId = Convert.ToInt32(supplierId); //Putting the value in the obj 
                aProduct.CategoryId = Convert.ToInt32(categoryId);
                aProduct.UnitPrice = unitPrice;

                // Every time we loop we will create one new product and add it to the list
                listOfProducts.Add(aProduct); //Add that all value into the list of Product

            }

            connection.Close();

            return listOfProducts; //returning the listofProducts

        }

        public List<Product> GetProductById(int aProductId)
        {

            List<Product> listOfProducts = new List<Product>();
            Product aProduct;


            long productId = 0;
            string productName = "n/a";
            long supplierId = 0;
            long categoryId = 0;
            double unitPrice = 999999.99;

            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();
            command.Parameters.Add("@productid", SqliteType.Integer).Value = aProductId;

            // Third, set up our SQL statement
          

            command.CommandText = "select productid, productname, supplierid, categoryid, unitprice " +
                "from products where productid = @productid";




            // Forth run the sql statement
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Try to access the different columns in the reader
                // local variable name = (cast) reader ["database column name"];

                // The conversions are because the C# data types do not match the 
                // SQLite datatypes, they are from different companies
                productId = (long)reader["productId"];
                productName = (string)reader["productname"];
                supplierId = (long)reader["supplierid"];
                categoryId = (long)reader["categoryid"];
                unitPrice = Convert.ToDouble(reader["unitprice"]);

                aProduct = new Product();

                aProduct.ProductId = Convert.ToInt32(productId);
                aProduct.ProductName = productName;
                aProduct.SupplierId = Convert.ToInt32(supplierId);
                aProduct.CategoryId = Convert.ToInt32(categoryId);
                aProduct.UnitPrice = unitPrice;

                // Every time we loop we will create one new product and add it to the list
                listOfProducts.Add(aProduct);

            }

            connection.Close();

            return listOfProducts;

        }

        public List<Category> GetCategories()
        {

            List<Category> listOfCategories = new List<Category>();
            Category aCategory;


            long categoryId = 0;
            string categoryName = "n/a";
            string description = "n/a";


            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();

            // Third, set up our SQL statement
            command.CommandText = "select categoryid, categoryname, description from categories;";

            // Forth run the sql statement
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Try to access the different columns in the reader
                // local variable name = (cast) reader ["database column name"];

                // The conversions are because the C# data types do not match the 
                // SQLite datatypes, they are from different companies
                categoryId = (long)reader["categoryid"];
                categoryName = (string)reader["categoryname"];
                description = (string)reader["description"];


                aCategory = new Category();

                aCategory.CategoryId = Convert.ToInt32(categoryId);
                aCategory.CategoryName = categoryName;
                aCategory.Description = description;


                // Every time we loop we will create one new product and add it to the list
                listOfCategories.Add(aCategory);

            }

            connection.Close();

            return listOfCategories;

        }
        public Category GetCategoryById(int categoryId)
        {
            Category category = null;

            // Assuming you have a connection to your database (SQLite or any other)
            // Replace the connection string with your own
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            try
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.Parameters.Add("@categoryId", SqliteType.Integer).Value = categoryId;
                command.CommandText = "SELECT categoryId, categoryName, description FROM categories WHERE categoryId = @categoryId";

                SqliteDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int fetchedCategoryId = Convert.ToInt32(reader["categoryId"]);
                    string categoryName = reader["categoryName"].ToString();
                    string description = reader["description"].ToString();

                    category = new Category(fetchedCategoryId, categoryName, description);
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            finally
            {
                connection.Close();
            }

            return category;
        }


        public List<Supplier> GetSuppliers()
        {
            // Initialize a list to store supplier details
            List<Supplier> listOfSuppliers = new List<Supplier>();
            Supplier aSupplier;

            // Variables to store supplier details, initially set to default values
            long supplierId = 0;
            string companyName = "n/a";
            string contactName = "n/a";
            string contactTitle = "n/a";
            string address = "n/a";
            string city = "n/a";
            string region = "n/a";
            string postalCode = "n/a";
            string country = "n/a";
            string phone = "n/a";
            string fax = "n/a";

            // Set up the database connection
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            // Open the database connection
            connection.Open();

            // Create a command for the SQL query
            SqliteCommand command = connection.CreateCommand();

            // Define the SQL query to retrieve all suppliers
            command.CommandText = "SELECT supplierid, companyname, contactname, contacttitle, address, city, region, postalcode, country, phone, fax FROM suppliers";

            // Execute the SQL query and obtain a reader to process the results
            SqliteDataReader reader = command.ExecuteReader();

            // Iterate through each record in the results
            while (reader.Read())
            {
                // Retrieve each field from the database and handle potential null values
                supplierId = (long)reader["supplierid"];
                companyName = reader.IsDBNull(reader.GetOrdinal("companyname")) ? "n/a" : reader["companyname"].ToString();
                contactName = reader.IsDBNull(reader.GetOrdinal("contactname")) ? "n/a" : reader["contactname"].ToString();
                contactTitle = reader.IsDBNull(reader.GetOrdinal("contacttitle")) ? "n/a" : reader["contacttitle"].ToString();
                address = reader.IsDBNull(reader.GetOrdinal("address")) ? "n/a" : reader["address"].ToString();
                city = reader.IsDBNull(reader.GetOrdinal("city")) ? "n/a" : reader["city"].ToString();
                region = reader.IsDBNull(reader.GetOrdinal("region")) ? "n/a" : reader["region"].ToString();
                postalCode = reader.IsDBNull(reader.GetOrdinal("postalcode")) ? "n/a" : reader["postalcode"].ToString();
                country = reader.IsDBNull(reader.GetOrdinal("country")) ? "n/a" : reader["country"].ToString();
                phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? "n/a" : reader["phone"].ToString();
                fax = reader.IsDBNull(reader.GetOrdinal("fax")) ? "n/a" : reader["fax"].ToString();

                // Create a new Supplier object with the retrieved values
                aSupplier = new Supplier();
                aSupplier.SupplierId = Convert.ToInt32(supplierId);
                aSupplier.CompanyName = companyName;
                aSupplier.ContactName = contactName;
                aSupplier.ContactTitle = contactTitle;
                aSupplier.Address = address;
                aSupplier.City = city;
                aSupplier.Region = region;
                aSupplier.PostalCode = postalCode;
                aSupplier.Country = country;
                aSupplier.Phone = phone;
                aSupplier.Fax = fax;

                // Add the new Supplier object to the list
                listOfSuppliers.Add(aSupplier);
            }

            // Close the database connection
            connection.Close();

            // Return the complete list of suppliers
            return listOfSuppliers;
        }

        public Supplier GetSupplierById(int supplierId)
        {
            Supplier supplier = null; // Start with no supplier found

            // Set up the database connection. Change the file path to your database file.
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            try // Start of a block to try out the code that might cause an error
            {
                connection.Open(); // Open the connection to the database

                SqliteCommand command = connection.CreateCommand(); // Create a command to run a SQL query
                command.Parameters.Add("@supplierId", SqliteType.Integer).Value = supplierId; // Set the supplier ID to search for
                command.CommandText = "SELECT supplierId, companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax FROM suppliers WHERE supplierId = @supplierId"; // SQL query to find the supplier by ID

                SqliteDataReader reader = command.ExecuteReader(); // Run the command and get the results

                if (reader.Read()) // If there is at least one result, read the first one
                {
                    // Convert and store each column into variables
                    int SupplierId = Convert.ToInt32(reader["supplierId"]);
                    string companyName = reader["companyName"].ToString();
                    string contactName = reader["contactName"].ToString();
                    string contactTitle = reader["contactTitle"].ToString();
                    string address = reader["address"].ToString();
                    string city = reader["city"].ToString();
                    string region = reader["region"].ToString();
                    string postalCode = reader["postalCode"].ToString();
                    string country = reader["country"].ToString();
                    string phone = reader["phone"].ToString();
                    string fax = reader["fax"].ToString();

                    // Create a new Supplier object with the retrieved data
                    supplier = new Supplier(SupplierId, companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax);
                }
            }
            catch (Exception ex) // If there is an error, this block will handle it
            {
                // we might want to log the error or tell the user something went wrong
            }
            finally // This block runs no matter what happened before
            {
                connection.Close(); // Always close the connection to free up resources
            }

            return supplier; // Return the supplier found, or null if no supplier was found
        }


        public List<Category> InsertTest(string aName, string aDesc)
        {


            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();

            // Third, set up our SQL statement
            command.CommandText = "insert into categories(categoryName, description)values(@catname, @desc);";
            command.Parameters.Add("@catname", SqliteType.Text).Value = aName;
            command.Parameters.Add("@desc", SqliteType.Text).Value = aDesc;


            // Forth run the sql statement
            command.ExecuteNonQuery();




            // Then return the new List after the insertion
            List<Category> listOfCategories = GetCategories();

            return listOfCategories;
        }

        public List<Product> InsertAProduct(string aProductName, int aSupplierId, int aCategoryId, double aUnitPrice)
        {


            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();

            // Third, set up our SQL statement
            command.CommandText = "insert into products(productname, supplierid, categoryid, unitprice)values" +
                "(@productname, @supplierid, @categoryid, @unitprice);";


            command.Parameters.Add("@productname", SqliteType.Text).Value = aProductName;
            command.Parameters.Add("@supplierid", SqliteType.Integer).Value = aSupplierId;
            command.Parameters.Add("@categoryid", SqliteType.Integer).Value = aCategoryId;
            command.Parameters.Add("@unitprice", SqliteType.Real).Value = aUnitPrice;


            // Forth run the sql statement
            command.ExecuteNonQuery();

            // Then return the new List after the insertion
           List<Product> listOfProducts = this.GetProducts();

            return listOfProducts;
        }

        public List<Product> UpdateAProduct(int aProductId, string aProductName, int aSupplierId, int aCategoryId, double aUnitPrice)
        {


            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();

            // Third, set up our SQL statement
            command.CommandText = "update Products " +
                "set productname = @productname, " +
                "supplierId = @supplierid, " +
                "categoryId = @categoryid, " +
                "unitPrice=@unitprice " +
                "where productId = @productid;";

            command.Parameters.Add("@productid", SqliteType.Text).Value = aProductId;
            command.Parameters.Add("@productname", SqliteType.Text).Value = aProductName;
            command.Parameters.Add("@supplierid", SqliteType.Integer).Value = aSupplierId;
            command.Parameters.Add("@categoryid", SqliteType.Integer).Value = aCategoryId;
            command.Parameters.Add("@unitprice", SqliteType.Real).Value = aUnitPrice;


            // Forth run the sql statement
            command.ExecuteNonQuery();

            // Then I return the new List after the insertion
            List<Product> listOfProducts = this.GetProducts();

            return listOfProducts;
        }

        public List<Category> InsertACategory(string categoryName, string description)
        {
            // Create and open a connection to the database using a using statement to ensure resources are cleaned up properly
            using (SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                connection.Open();  // Open the database connection

                // Create another using statement for the SQL command to ensure the command object is disposed properly
                using (SqliteCommand command = connection.CreateCommand())
                {
                    // Set the command text to perform an INSERT operation into the categories table
                    command.CommandText = "INSERT INTO categories (categoryName, description) VALUES (@categoryName, @description)";

                    // Add parameters to prevent SQL injection and handle data directly
                    command.Parameters.AddWithValue("@categoryName", categoryName); // Set the category name parameter
                    command.Parameters.AddWithValue("@description", description); // Set the description parameter

                    // Execute the SQL command which will insert the new category into the database
                    command.ExecuteNonQuery();
                }
            }

            // After inserting the category, retrieve and return the updated list of all categories
            return GetCategories();
        }

        public List<Category> UpdateACategory(int categoryId, string categoryName, string description)
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE categories SET categoryName = @categoryName, description = @description WHERE categoryId = @categoryId";
                    command.Parameters.AddWithValue("@categoryName", categoryName);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@categoryId", categoryId);
                    command.ExecuteNonQuery();
                }
            }

            // Return the updated list of categories
            return GetCategories();
        }

        public List<Supplier> InsertASupplier(string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            if (string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(contactName) || string.IsNullOrEmpty(contactTitle) ||
                 string.IsNullOrEmpty(address) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(region) ||
                    string.IsNullOrEmpty(postalCode) || string.IsNullOrEmpty(country) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(fax))
            {
                // this is because we can handle the error or throw an exception
                throw new ArgumentException("One or more required parameters are null or empty.");
            }
            using (SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO suppliers (companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax) VALUES (@companyName, @contactName, @contactTitle, @address, @city, @region, @postalCode, @country, @phone, @fax)";
                    command.Parameters.AddWithValue("@companyName", companyName);
                    command.Parameters.AddWithValue("@contactName", contactName);
                    command.Parameters.AddWithValue("@contactTitle", contactTitle);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@region", region);
                    command.Parameters.AddWithValue("@postalCode", postalCode);
                    command.Parameters.AddWithValue("@country", country);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@fax", fax);
                    command.ExecuteNonQuery();
                }
            }

            // Return the updated list of suppliers
            return GetSuppliers();
        }

        public List<Supplier> UpdateASupplier(int supplierId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE suppliers SET companyName = @companyName, contactName = @contactName, contactTitle = @contactTitle, address = @address, city = @city, region = @region, postalCode = @postalCode, country = @country, phone = @phone, fax = @fax WHERE supplierId = @supplierId";
                    command.Parameters.AddWithValue("@companyName", companyName);
                    command.Parameters.AddWithValue("@contactName", contactName);
                    command.Parameters.AddWithValue("@contactTitle", contactTitle);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@region", region);
                    command.Parameters.AddWithValue("@postalCode", postalCode);
                    command.Parameters.AddWithValue("@country", country);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@fax", fax);
                    command.Parameters.AddWithValue("@supplierId", supplierId);
                    command.ExecuteNonQuery();
                }
            }

            // Return the updated list of suppliers
            return GetSuppliers();
        }

        
        public List<Customer> GetCustomers()
        {
            List<Customer> listOfCustomers = new List<Customer>();

            // Establish connection
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");
            connection.Open();

            // Create a command
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT customerId, companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax FROM customers;";

            // Execute the SQL statement
            SqliteDataReader reader = command.ExecuteReader();

            // Iterate over the reader and fill the list of customers
            while (reader.Read())
            {
                Customer aCustomer = new Customer
                {
                    CustomerId = reader["customerId"].ToString(),
                    CompanyName = reader["companyName"].ToString(),
                    ContactName = reader["contactName"].ToString(),
                    ContactTitle = reader["contactTitle"].ToString(),
                    Address = reader["address"].ToString(),
                    City = reader["city"].ToString(),
                    Region = reader["region"].ToString(),
                    PostalCode = reader["postalCode"].ToString(),
                    Country = reader["country"].ToString(),
                    Phone = reader["phone"].ToString(),
                    Fax = reader["fax"].ToString()
                };

                listOfCustomers.Add(aCustomer);
            }

            connection.Close();

            return listOfCustomers;
        }
        public List<Customer> InsertACustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                // Open the connection
                connection.Open();

                // Create a command
                using (SqliteCommand command = connection.CreateCommand())
                {
                    // Set up the SQL statement
                    command.CommandText = "INSERT INTO customers(customerId, companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax) VALUES " +
                        "(@customerId, @companyName, @contactName, @contactTitle, @address, @city, @region, @postalCode, @country, @phone, @fax);";

                    // Add parameters
                    command.Parameters.AddWithValue("@customerId", customerId ?? "");
                    command.Parameters.AddWithValue("@companyName", companyName ?? "");
                    command.Parameters.AddWithValue("@contactName", contactName ?? "");
                    command.Parameters.AddWithValue("@contactTitle", contactTitle ?? "");
                    command.Parameters.AddWithValue("@address", address ?? "");
                    command.Parameters.AddWithValue("@city", city ?? "");
                    command.Parameters.AddWithValue("@region", region ?? "");
                    command.Parameters.AddWithValue("@postalCode", postalCode ?? "");
                    command.Parameters.AddWithValue("@country", country ?? "");
                    command.Parameters.AddWithValue("@phone", phone ?? "");
                    command.Parameters.AddWithValue("@fax", fax ?? "");

                    // Execute the SQL statement
                    command.ExecuteNonQuery();
                }

                // Retrieve updated list of customers
                List<Customer> listOfCustomers = this.GetCustomers();

                // Return the updated list of customers
                return listOfCustomers;
            }
        }

        public List<Customer> GetCustomerById(string customerId)
        {
            // Initialize a list to store customer details
            List<Customer> customers = new List<Customer>();

            // Set up the database connection
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");
            try
            {
                // Open the database connection
                connection.Open();

                // Create a command for the SQL query
                SqliteCommand command = connection.CreateCommand();
                // Add parameter to the command to prevent SQL injection
                command.Parameters.Add("@customerId", SqliteType.Text).Value = customerId;

                // Define the SQL query to select a customer by ID
                command.CommandText = "SELECT customerId, companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax FROM customers WHERE customerId = @customerId";

                // Execute the command and obtain a reader for the result set
                SqliteDataReader reader = command.ExecuteReader();

                // Read each row in the result set
                while (reader.Read())
                {
                    // Create a new Customer object and populate it with data from the database
                    Customer customer = new Customer();
                    customer.CustomerId = reader["customerId"].ToString();
                    customer.CompanyName = reader["companyName"].ToString();
                    customer.ContactName = reader["contactName"].ToString();
                    customer.ContactTitle = reader["contactTitle"].ToString();
                    customer.Address = reader["address"].ToString();
                    customer.City = reader["city"].ToString();
                    customer.Region = reader["region"].ToString();
                    customer.PostalCode = reader["postalCode"].ToString();
                    customer.Country = reader["country"].ToString();
                    customer.Phone = reader["phone"].ToString();
                    customer.Fax = reader["fax"].ToString();

                    // Add the new customer to the list
                    customers.Add(customer);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
            }
            finally
            {
                // Ensure the database connection is closed even if an error occurs
                connection.Close();
            }
            // Return the list of customers matching the specified ID (typically one or none)
            return customers;
        }


        public List<Customer> UpdateACustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");
            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.CommandText = "UPDATE customers " +
                                  "SET companyName = @companyName, " +
                                  "contactName = @contactName, " +
                                  "contactTitle = @contactTitle, " +
                                  "address = @address, " +
                                  "city = @city, " +
                                  "region = @region, " +
                                  "postalCode = @postalCode, " +
                                  "country = @country, " +
                                  "phone = @phone, " +
                                  "fax = @fax " +
                                  "WHERE customerId = @customerId";

            command.Parameters.Add("@customerId", SqliteType.Text).Value = customerId;
            command.Parameters.Add("@companyName", SqliteType.Text).Value = companyName;
            command.Parameters.Add("@contactName", SqliteType.Text).Value = contactName;
            command.Parameters.Add("@contactTitle", SqliteType.Text).Value = contactTitle;
            command.Parameters.Add("@address", SqliteType.Text).Value = address;
            command.Parameters.Add("@city", SqliteType.Text).Value = city;
            command.Parameters.Add("@region", SqliteType.Text).Value = region;
            command.Parameters.Add("@postalCode", SqliteType.Text).Value = postalCode;
            command.Parameters.Add("@country", SqliteType.Text).Value = country;
            command.Parameters.Add("@phone", SqliteType.Text).Value = phone;
            command.Parameters.Add("@fax", SqliteType.Text).Value = fax;

            command.ExecuteNonQuery();
            connection.Close();

            return GetCustomers();

        }

        // for employees
        public List<Employee> GetEmployees()
        {
            List<Employee> listOfEmployees = new List<Employee>();

            // Establish connection with the database
            using (SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                connection.Open();

                // Create command
                using (SqliteCommand command = connection.CreateCommand())
                {
                    // Set up SQL statement
                    command.CommandText = "SELECT * FROM Employees";

                    // Execute SQL statement
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee();

                            // Map database columns to Employee properties
                            employee.EmployeeId = reader.GetInt32(0);
                            employee.LastName = reader.GetString(1);
                            employee.FirstName = reader.GetString(2);
                            employee.Title = reader.GetString(3);
                            employee.TitleOfCourtesy = reader.GetString(4);
                            employee.BirthDate = reader.GetString(5);
                            employee.HireDate = reader.GetString(6);
                            employee.Address = reader.GetString(7);
                            employee.City = reader.GetString(8);
                            if (!reader.IsDBNull(9))                             //// Check if the column is not null before assigning it
                            {
                                employee.Region = reader.GetString(9);
                            }
                            employee.PostalCode = reader.GetString(10);
                            employee.Country = reader.GetString(11);
                            employee.HomePhone = reader.GetString(12);
                            employee.Extension = reader.GetString(13);
                            if (!reader.IsDBNull(14))
                            {
                                employee.Notes = reader.GetString(14);
                            }

                            employee.ReportsTo = reader.GetInt32(15);

                            listOfEmployees.Add(employee);
                        }
                    }
                }

                connection.Close();
            }

            return listOfEmployees;
        }
        //for Shipper
        public List<Shipper> GetShippers()
        {
            List<Shipper> listOfShippers = new List<Shipper>();

            using (SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Shippers";

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Shipper shipper = new Shipper();

                            shipper.ShipperId = reader.GetInt32(0);
                            shipper.CompanyName = reader.GetString(1);
                            shipper.Phone = reader.GetString(2);

                            listOfShippers.Add(shipper);
                        }
                    }
                }

                connection.Close();
            }

            return listOfShippers;
        }
        // for order
        public List<Order> GetOrders()
        {
            List<Order> listOfOrders = new List<Order>();  // List of Orders for storing data from database
            Order anOrder;  // Variable for Order

            int orderId = 0;
            string customerId = "n/a";
            int employeeId = 0;
            string orderDate = "n/a";
            string requiredDate = "n/a";
            string shippedDate = "n/a";
            int shipVia = 0;
            double freight = 999999.99;
            string shipName = "n/a";
            string shipAddress = "n/a";
            string shipCity = "n/a";
            string shipRegion = "n/a";
            string shipPostalCode = "n/a";
            string shipCountry = "n/a";

            // Make a connection with the database
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();

            // Third, set up our SQL statement
            command.CommandText = "SELECT orderId, customerId, employeeId, orderDate, requiredDate, shippedDate, shipVia, freight, shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry FROM orders;";

            // Fourth run the SQL statement
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())  // Till the data is read
            {
                // Try to access the different columns in the reader
                // local variable name = (cast) reader["database column name"];
                orderId = Convert.ToInt32(reader["orderId"]);
                customerId = reader["customerId"].ToString();
                employeeId = Convert.ToInt32(reader["employeeId"]);
                orderDate = reader["orderDate"].ToString();
                requiredDate = reader["requiredDate"].ToString();
                shippedDate = reader["shippedDate"].ToString();
                shipVia = Convert.ToInt32(reader["shipVia"]);
                freight = Convert.ToDouble(reader["freight"]);
                shipName = reader["shipName"].ToString();
                shipAddress = reader["shipAddress"].ToString();
                shipCity = reader["shipCity"].ToString();
                shipRegion = reader["shipRegion"].ToString();
                shipPostalCode = reader["shipPostalCode"].ToString();
                shipCountry = reader["shipCountry"].ToString();

                anOrder = new Order();  // Creating an object to put inside the list

                // Setting the values to the object
                anOrder.OrderId = orderId;
                anOrder.CustomerId = customerId;
                anOrder.EmployeeId = employeeId;
                anOrder.OrderDate = orderDate;
                anOrder.RequiredDate = requiredDate;
                anOrder.ShippedDate = shippedDate;
                anOrder.ShipVia = shipVia;
                anOrder.Freight = freight;
                anOrder.ShipName = shipName;
                anOrder.ShipAddress = shipAddress;
                anOrder.ShipCity = shipCity;
                anOrder.ShipRegion = shipRegion;
                anOrder.ShipPostalCode = shipPostalCode;
                anOrder.ShipCountry = shipCountry;

                // Every time we loop we will create one new order and add it to the list
                listOfOrders.Add(anOrder);  // Add that all value into the list of Order
            }

            connection.Close();  // Close the connection

            return listOfOrders;  // Returning the listOfOrders
        }

        //for OrderDetails
        public List<OrderDetail> GetOrderDetails()
        {
            List<OrderDetail> listOfOrderDetails = new List<OrderDetail>();

            using (SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM 'order details';";

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderDetail orderDetail = new OrderDetail();

                            orderDetail.OrderId = reader.GetInt32(0);
                            orderDetail.ProductId = reader.GetInt32(1);
                            orderDetail.UnitPrice = reader.GetDouble(2);
                            orderDetail.Quantity = reader.GetInt32(3);
                            orderDetail.Discount = reader.GetDouble(4);

                            listOfOrderDetails.Add(orderDetail);
                        }
                    }
                }

                connection.Close();
            }

            return listOfOrderDetails;
        }

        // Inserts for Employees:
        public List<Employee> InsertAnEmployee(string lastName, string firstName, string title, string titleOfCourtesy, string birthDate, string hireDate, string address, string city, string region, string postalCode, string country, string homePhone, string extension, string notes, int reportsTo)
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                // Open the connection
                connection.Open();

                // Create a command
                using (SqliteCommand command = connection.CreateCommand())
                {
                    // Set up the SQL statement
                    command.CommandText = "INSERT INTO Employees(LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo) VALUES (@lastName, @firstName, @title, @titleOfCourtesy, @birthDate, @hireDate, @address, @city, @region, @postalCode, @country, @homePhone, @extension, @notes, @reportsTo);";

                    // Add parameters
                    command.Parameters.AddWithValue("@lastName", lastName ?? "");
                    command.Parameters.AddWithValue("@firstName", firstName ?? "");
                    command.Parameters.AddWithValue("@title", title ?? "");
                    command.Parameters.AddWithValue("@titleOfCourtesy", titleOfCourtesy ?? "");
                    command.Parameters.AddWithValue("@birthDate", birthDate ?? "");
                    command.Parameters.AddWithValue("@hireDate", hireDate ?? "");
                    command.Parameters.AddWithValue("@address", address ?? "");
                    command.Parameters.AddWithValue("@city", city ?? "");
                    command.Parameters.AddWithValue("@region", region ?? "");
                    command.Parameters.AddWithValue("@postalCode", postalCode ?? "");
                    command.Parameters.AddWithValue("@country", country ?? "");
                    command.Parameters.AddWithValue("@homePhone", homePhone ?? "");
                    command.Parameters.AddWithValue("@extension", extension ?? "");
                    command.Parameters.AddWithValue("@notes", notes ?? "");
                    command.Parameters.AddWithValue("@reportsTo", reportsTo);

                    // Execute the SQL statement
                    command.ExecuteNonQuery();
                }

                // Retrieve updated list of employees
                List<Employee> listOfEmployees = GetEmployees();

                // Return the updated list of employees
                return listOfEmployees;
            }
        }
        // for shippers insert
        public List<Shipper> InsertAShipper(int shipperId, string companyName, string phone)
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Shippers(ShipperId, CompanyName, Phone) VALUES (@shipperId,@companyName, @phone);";

                    command.Parameters.AddWithValue("@shipperId", shipperId);
                    command.Parameters.AddWithValue("@companyName", companyName ?? "");
                    command.Parameters.AddWithValue("@phone", phone ?? "");

                    command.ExecuteNonQuery();
                }

                List<Shipper> listOfShippers = this.GetShippers();

                // Return the updated list of employees
                return listOfShippers;
            }
        }
        //insertfor Orders
        public List<Order> InsertAnOrder(string customerId, int employeeId, string orderDate, string requiredDate, string shippedDate, int shipVia, double freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();

            // Third, set up our SQL statement
            command.CommandText = "INSERT INTO orders(customerId, employeeId, orderDate, requiredDate, shippedDate, shipVia, freight, shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry) VALUES " +
                "(@customerId, @employeeId, @orderDate, @requiredDate, @shippedDate, @shipVia, @freight, @shipName, @shipAddress, @shipCity, @shipRegion, @shipPostalCode, @shipCountry);";

            // Setting up parameters to prevent SQL Injection
            command.Parameters.Add("@customerId", SqliteType.Text).Value = customerId;
            command.Parameters.Add("@employeeId", SqliteType.Integer).Value = employeeId;
            command.Parameters.Add("@orderDate", SqliteType.Text).Value = orderDate;
            command.Parameters.Add("@requiredDate", SqliteType.Text).Value = requiredDate;
            command.Parameters.Add("@shippedDate", SqliteType.Text).Value = shippedDate;
            command.Parameters.Add("@shipVia", SqliteType.Integer).Value = shipVia;
            command.Parameters.Add("@freight", SqliteType.Real).Value = freight;
            command.Parameters.Add("@shipName", SqliteType.Text).Value = shipName;
            command.Parameters.Add("@shipAddress", SqliteType.Text).Value = shipAddress;
            command.Parameters.Add("@shipCity", SqliteType.Text).Value = shipCity;
            command.Parameters.Add("@shipRegion", SqliteType.Text).Value = shipRegion;
            command.Parameters.Add("@shipPostalCode", SqliteType.Text).Value = shipPostalCode;
            command.Parameters.Add("@shipCountry", SqliteType.Text).Value = shipCountry;

            // Fourth, run the SQL statement
            command.ExecuteNonQuery();

            // Close the connection
            connection.Close();

            // Then return the new list after the insertion
            return GetOrders(); // Assuming GetOrders fetches all orders
        }
        //inserts for orderdetails
        public List<OrderDetail> InsertAnOrderDetails(int orderId, int productId, double unitPrice, int quantity, double discount)
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO  \"order details\"(OrderId, ProductId, UnitPrice, Quantity, Discount) VALUES (@orderId, @productId, @unitPrice, @quantity, @discount);";

                    command.Parameters.AddWithValue("@orderId", orderId);
                    command.Parameters.AddWithValue("@productId", productId);
                    command.Parameters.AddWithValue("@unitPrice", unitPrice);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@discount", discount);

                    command.ExecuteNonQuery();
                }

                List<OrderDetail> listOfOrderDetails = this.GetOrderDetails();

                return listOfOrderDetails;
            }
        }
       //updates of employees
        public List<Employee> GetEmployeeById(int employeeId)
        {
            List<Employee> listOfEmployees = new List<Employee>();

            using (SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Employees WHERE EmployeeId = @employeeId";
                    command.Parameters.AddWithValue("@employeeId", employeeId);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee
                            {
                                EmployeeId = reader.GetInt32(0),
                                LastName = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                Title = reader.GetString(3),
                                TitleOfCourtesy = reader.GetString(4),
                                BirthDate = reader.GetString(5),
                                HireDate = reader.GetString(6),
                                Address = reader.GetString(7),
                                City = reader.GetString(8),
                                Region = reader.GetString(9),
                                PostalCode = reader.GetString(10),
                                Country = reader.GetString(11),
                                HomePhone = reader.GetString(12),
                                Extension = reader.GetString(13),
                                Notes = reader.IsDBNull(14) ? null : reader.GetString(14), // Correctly handling NULL for Notes
                                ReportsTo = reader.IsDBNull(15) ? -1 : reader.GetInt32(15) // Handle nullable reportsTo field
                            };

                            listOfEmployees.Add(employee);
                        }
                    }
                }
            }

            return listOfEmployees;
        }
        public List<Employee> UpdateAnEmployee(int employeeId, string lastName, string firstName, string title, string titleOfCourtesy, string birthDate,
                                     string hireDate, string address, string city, string region, string postalCode, string country,
                                     string homePhone, string extension, string notes, int reportsTo)
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE Employees 
                                    SET LastName = @lastName, 
                                        FirstName = @firstName, 
                                        Title = @title, 
                                        TitleOfCourtesy = @titleOfCourtesy, 
                                        BirthDate = @birthDate, 
                                        HireDate = @hireDate, 
                                        Address = @address, 
                                        City = @city, 
                                        Region = @region, 
                                        PostalCode = @postalCode, 
                                        Country = @country, 
                                        HomePhone = @homePhone, 
                                        Extension = @extension, 
                                        Notes = @notes, 
                                        ReportsTo = @reportsTo 
                                    WHERE EmployeeId = @employeeId";

                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@titleOfCourtesy", titleOfCourtesy);
                    command.Parameters.AddWithValue("@birthDate", birthDate);
                    command.Parameters.AddWithValue("@hireDate", hireDate);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@region", region);
                    command.Parameters.AddWithValue("@postalCode", postalCode);
                    command.Parameters.AddWithValue("@country", country);
                    command.Parameters.AddWithValue("@homePhone", homePhone);
                    command.Parameters.AddWithValue("@extension", extension);
                    command.Parameters.AddWithValue("@notes", notes ?? string.Empty);
                    command.Parameters.AddWithValue("@reportsTo", reportsTo);
                    command.Parameters.AddWithValue("@employeeId", employeeId);

                    command.ExecuteNonQuery();
                }
            }

            // Return the updated list of employees
            return GetEmployees();
        }

        //update for shipper

        public List<Shipper> GetShipperById(int shipperId)
        {
            // Initialize a list to store the shipper details
            List<Shipper> listOfShippers = new List<Shipper>();

            // Create a connection to the database using a using statement to ensure it is disposed of properly
            using (var connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                // Open the database connection
                connection.Open();

                // Create a SQL command to select a shipper by ID
                using (var command = new SqliteCommand("SELECT shipperId, companyName, phone FROM shippers WHERE shipperId = @shipperId", connection))
                {
                    // Add the shipperId parameter to the command to prevent SQL injection
                    command.Parameters.Add(new SqliteParameter("@shipperId", shipperId));

                    // Execute the command and use a reader to process the results
                    using (var reader = command.ExecuteReader())
                    {
                        // Read each row in the result set
                        while (reader.Read())
                        {
                            // Create a new Shipper object and populate it with data from the database
                            var shipper = new Shipper()
                            {
                                ShipperId = Convert.ToInt32(reader["shipperId"]),
                                CompanyName = reader["companyName"].ToString(),
                                Phone = reader["phone"].ToString()
                            };

                            // Add the new Shipper object to the list of shippers
                            listOfShippers.Add(shipper);
                        }
                    }
                }
            }
            // Return the list containing the shipper(s) that match the given ID (typically one or none)
            return listOfShippers;
        }

        public void UpdateAShipper(int shipperId, string companyName, string phone)
        {
            using (var connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db"))
            {
                connection.Open();
                using (var command = new SqliteCommand("UPDATE shippers SET companyName = @companyName, phone = @phone WHERE shipperId = @shipperId", connection))
                {
                    command.Parameters.AddWithValue("@shipperId", shipperId);
                    command.Parameters.AddWithValue("@companyName", companyName);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.ExecuteNonQuery();
                }
            }
        }

        //update for Order
        public List<Order> GetOrderById(int orderId)
        {
            List<Order> listOfOrders = new List<Order>();
            Order anOrder;

            int oId = 0;
            string customerId = "n/a";
            int employeeId = -1;
            string orderDate = "n/a";
            string requiredDate = "n/a";
            string shippedDate = "n/a";
            int shipVia = -1;
            double freight = double.MaxValue;
            string shipName = "n/a";
            string shipAddress = "n/a";
            string shipCity = "n/a";
            string shipRegion = "n/a";
            string shipPostalCode = "n/a";
            string shipCountry = "n/a";

            // Make a connection with the database
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();
            command.Parameters.Add("@orderId", SqliteType.Integer).Value = orderId;

            // Third, set up our SQL statement
            command.CommandText = "SELECT orderId, customerId, employeeId, orderDate, requiredDate, shippedDate, shipVia, freight, shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry " +
                                  "FROM orders WHERE orderId = @orderId ";

            // Fourth run the SQL statement
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Try to access the different columns in the reader
                oId = Convert.ToInt32(reader["orderId"]);
                customerId = reader["customerId"].ToString();
                employeeId = Convert.ToInt32(reader["employeeId"]);
                orderDate = reader["orderDate"].ToString();
                requiredDate = reader["requiredDate"].ToString();
                shippedDate = reader["shippedDate"].ToString();
                shipVia = Convert.ToInt32(reader["shipVia"]);
                freight = Convert.ToDouble(reader["freight"]);
                shipName = reader["shipName"].ToString();
                shipAddress = reader["shipAddress"].ToString();
                shipCity = reader["shipCity"].ToString();
                shipRegion = reader["shipRegion"].ToString();
                shipPostalCode = reader["shipPostalCode"].ToString();
                shipCountry = reader["shipCountry"].ToString();

                anOrder = new Order();

                anOrder.OrderId = oId;
                anOrder.CustomerId = customerId;
                anOrder.EmployeeId = employeeId;
                anOrder.OrderDate = orderDate;
                anOrder.RequiredDate = requiredDate;
                anOrder.ShippedDate = shippedDate;
                anOrder.ShipVia = shipVia;
                anOrder.Freight = freight;
                anOrder.ShipName = shipName;
                anOrder.ShipAddress = shipAddress;
                anOrder.ShipCity = shipCity;
                anOrder.ShipRegion = shipRegion;
                anOrder.ShipPostalCode = shipPostalCode;
                anOrder.ShipCountry = shipCountry;

                // Every time we loop we will create one new order and add it to the list
                listOfOrders.Add(anOrder);
            }

            connection.Close();

            return listOfOrders;
        }

        public List<Order> UpdateAnOrder(int orderId, string customerId, int employeeId, string orderDate, string requiredDate, string shippedDate, int shipVia, double freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();

            // Third, set up our SQL statement
            command.CommandText = "UPDATE orders SET " +
                "customerId = @customerId, " +
                "employeeId = @employeeId, " +
                "orderDate = @orderDate, " +
                "requiredDate = @requiredDate, " +
                "shippedDate = @shippedDate, " +
                "shipVia = @shipVia, " +
                "freight = @freight, " +
                "shipName = @shipName, " +
                "shipAddress = @shipAddress, " +
                "shipCity = @shipCity, " +
                "shipRegion = @shipRegion, " +
                "shipPostalCode = @shipPostalCode, " +
                "shipCountry = @shipCountry " +
                "WHERE orderId = @orderId  ;";

            // Setting up parameters to prevent SQL Injection
            command.Parameters.Add("@orderId", SqliteType.Integer).Value = orderId;
            command.Parameters.Add("@customerId", SqliteType.Text).Value = customerId;
            command.Parameters.Add("@employeeId", SqliteType.Integer).Value = employeeId;
            command.Parameters.Add("@orderDate", SqliteType.Text).Value = orderDate;
            command.Parameters.Add("@requiredDate", SqliteType.Text).Value = requiredDate;
            command.Parameters.Add("@shippedDate", SqliteType.Text).Value = shippedDate;
            command.Parameters.Add("@shipVia", SqliteType.Integer).Value = shipVia;
            command.Parameters.Add("@freight", SqliteType.Real).Value = freight;
            command.Parameters.Add("@shipName", SqliteType.Text).Value = shipName;
            command.Parameters.Add("@shipAddress", SqliteType.Text).Value = shipAddress;
            command.Parameters.Add("@shipCity", SqliteType.Text).Value = shipCity;
            command.Parameters.Add("@shipRegion", SqliteType.Text).Value = shipRegion;
            command.Parameters.Add("@shipPostalCode", SqliteType.Text).Value = shipPostalCode;
            command.Parameters.Add("@shipCountry", SqliteType.Text).Value = shipCountry;

            // Fourth, run the SQL statement
            command.ExecuteNonQuery();

            // Close the connection
            connection.Close();

            // Then return the new list after the update
            return GetOrders(); // Assuming GetOrders fetches all orders
        }

        // update for order details
        public List<OrderDetail> GetOrderDetailsById(int orderId)
        {
            List<OrderDetail> listOfOrderDetails = new List<OrderDetail>();
            OrderDetail anOrderDetail;

            int orderID = -1;
            int productID = -1;
            double unitPrice = double.MaxValue;
            int quantity = 0;
            double discount = 0.0;

            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();
            command.Parameters.Add("@orderId", SqliteType.Integer).Value = orderId;

            // Third, set up our SQL statement
            command.CommandText = "SELECT orderId, productId, unitPrice, quantity, discount " +
                      "FROM \"order details\" WHERE orderId = @orderId";


            // Forth run the SQL statement
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Try to access the different columns in the reader
                // local variable name = (cast) reader ["database column name"];

                // The conversions are because the C# data types do not match the 
                // SQLite datatypes, they are from different companies
                orderID = Convert.ToInt32(reader["orderId"]);
                productID = Convert.ToInt32(reader["productId"]);
                unitPrice = Convert.ToDouble(reader["unitPrice"]);
                quantity = Convert.ToInt32(reader["quantity"]);
                discount = Convert.ToDouble(reader["discount"]);

                anOrderDetail = new OrderDetail();

                anOrderDetail.OrderId = orderID;
                anOrderDetail.ProductId = productID;
                anOrderDetail.UnitPrice = unitPrice;
                anOrderDetail.Quantity = quantity;
                anOrderDetail.Discount = discount;

                // Every time we loop, we will create one new order detail and add it to the list
                listOfOrderDetails.Add(anOrderDetail);
            }

            connection.Close();

            return listOfOrderDetails;
        }
        public List<OrderDetail> UpdateAnOrderDetail(int orderId, int productId, double unitPrice, int quantity, double discount)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\singh\\source\\repos\\NorthwindProject\\Northwind4SQLite.db");

            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();

            // Third, set up our SQL statement
            command.CommandText = "UPDATE \"order details\"" +
                                  "SET unitPrice = @unitPrice, " +
                                  "quantity = @quantity, " +
                                  "discount = @discount " +
                                  "WHERE orderId = @orderId AND productId = @productId;";

            command.Parameters.Add("@orderId", SqliteType.Integer).Value = orderId;
            command.Parameters.Add("@productId", SqliteType.Integer).Value = productId;
            command.Parameters.Add("@unitPrice", SqliteType.Real).Value = unitPrice;
            command.Parameters.Add("@quantity", SqliteType.Integer).Value = quantity;
            command.Parameters.Add("@discount", SqliteType.Real).Value = discount;

            // Forth run the sql statement
            command.ExecuteNonQuery();

            // Then I return the new List after the update
            List<OrderDetail> listOfOrderDetails = this.GetOrderDetails();

            return listOfOrderDetails;
        }
    }
}