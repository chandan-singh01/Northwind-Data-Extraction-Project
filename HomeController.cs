using Microsoft.AspNetCore.Mvc;
using NorthwindProject.Models;
using System.Diagnostics;
using System.Net;

namespace NorthwindProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {


            return View();
        }

        //[Route("/GetProducts")]
        public IActionResult GetProducts()
        {
            DBGateway aGateway = new DBGateway();

            List<Product> aListOfProducts = aGateway.GetProducts();

            ViewBag.ListOfProducts = aListOfProducts;

            return View();
        }
        public IActionResult GetProductById(int aProductId)
        {
            DBGateway aGateway = new DBGateway();

            List<Product> aListOfProducts = aGateway.GetProductById(aProductId);

            ViewBag.ListOfProducts = aListOfProducts;

            return View();
        }


        //[Route("/GetCategories")]
        public IActionResult GetCategories()
        {
            DBGateway aGateway = new DBGateway();
            List<Category> aListOfCategories = aGateway.GetCategories();

            ViewBag.ListOfCategories = aListOfCategories;
            return View();
        }
        public IActionResult GetCategoryById(int categoryId)
        {
            DBGateway aGateway = new DBGateway();

            Category category = aGateway.GetCategoryById(categoryId);

            if (category != null)
            {
                ViewBag.Category = category;
                return View();
            }
            else
            {
                // Handle case where category with the specified ID is not found
                return NotFound();
            }
        }



        //[Route("/GetSuppliers")]
        public IActionResult GetSuppliers()
        {
            DBGateway aGateway = new DBGateway();
            List<Supplier> aListOfSuppliers = aGateway.GetSuppliers();

            ViewBag.ListOfSuppliers = aListOfSuppliers;
            return View();
        }

        public IActionResult GetSupplierById(int supplierId)
        {
            DBGateway aGateway = new DBGateway();

            Supplier supplier = aGateway.GetSupplierById(supplierId);

            if (supplier != null)
            {
                ViewBag.Supplier = supplier;
                return View();
            }
            else
            {
                // Handle case where supplier with the specified ID is not found
                return NotFound();
            }
        }

        //[Route("/InsertAProductForm")]
        public IActionResult InsertAProductForm()
        {
            DBGateway aGateway = new DBGateway();

            List<Supplier> aListOfSuppliers = aGateway.GetSuppliers();
            List<Category> aListOfCategories = aGateway.GetCategories();

            ViewBag.ListOfSuppliers = aListOfSuppliers;
            ViewBag.ListOfCategories = aListOfCategories;

            return View();
        }


        public IActionResult InsertTest()
        {
            DBGateway aGateway = new DBGateway();

            aGateway.InsertTest("boo", "boo bah");


            List<Category> aListOfCategories = aGateway.GetCategories();

            ViewBag.ListOfCategories = aListOfCategories;

            return View("GetCategories");
        }

        public IActionResult InsertAProduct(string productName, int supplierId, int categoryId, double unitPrice)
        {

            DBGateway aGateway = new DBGateway();

            aGateway.InsertAProduct(productName, supplierId, categoryId, unitPrice);


            List<Product> aListOfProducts = aGateway.GetProducts();

            ViewBag.ListOfProducts = aListOfProducts;


            // the reason we are returning GetProducts is because if you are an employee and you
            // insert a Product, you will probably want to see it was actually added
            // so I am returning them to the GetProducts View
            return View("GetProducts");
        }



        public IActionResult UpdateAProductForm(int aProductId)
        {
            DBGateway aGateway = new DBGateway();
            List<Product> aListOfProducts = new List<Product>();
            List<Supplier> aListOfSuppliers = aGateway.GetSuppliers();
            List<Category> aListOfCategories = aGateway.GetCategories();

            aListOfProducts = aGateway.GetProductById(aProductId);


            ViewBag.ListOfSuppliers = aListOfSuppliers;
            ViewBag.ListOfCategories = aListOfCategories;
            ViewBag.ListOfProducts = aListOfProducts;

            return View();
        }
        

        public IActionResult UpdateAProduct(int productId, string productName, int supplierId, int categoryId, double unitPrice)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateAProduct(productId, productName, supplierId, categoryId, unitPrice);

            List<Product> aListOfProducts = new List<Product>();
            ViewBag.ListOfProducts = aGateway.GetProducts();
            return View("GetProducts");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //I did
        public IActionResult InsertACategoryForm()
        {
            return View();
        }
        public IActionResult InsertACategory(string categoryName, string description)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.InsertACategory(categoryName, description);

            List<Category> aListOfCategories = aGateway.GetCategories();
            ViewBag.ListOfCategories = aListOfCategories;

            return View("GetCategories");
        }
        public IActionResult UpdateACategoryForm(int categoryId)
        {
            DBGateway aGateway = new DBGateway();
            Category category = aGateway.GetCategoryById(categoryId);
            List<Category> aListOfCategories = aGateway.GetCategories();
            ViewBag.ListOfCategories = aListOfCategories;

            return View();

        }

        public IActionResult UpdateACategory(int categoryId, string categoryName, string description)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateACategory(categoryId, categoryName, description);

            List<Category> aListOfCategories = aGateway.GetCategories();
            ViewBag.ListOfCategories = aListOfCategories;

            return View("GetCategories");
        }
        
        public IActionResult UpdateASupplierForm(int supplierId)
        {
            DBGateway aGateway = new DBGateway();
            Supplier supplier = aGateway.GetSupplierById(supplierId);
            List<Supplier> aListOfSuppliers = aGateway.GetSuppliers();
            //Supplier supplier = aGateway.GetSupplierById(supplierId);

            ViewBag.ListOfSuppliers = aListOfSuppliers;
            if (supplier == null)
           {
                // Handle the case where the supplier with the given ID is not found
               return NotFound();
           }

            return View();
        }


        public IActionResult UpdateASupplier(int supplierId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateASupplier(supplierId, companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax);

            List<Supplier> aListOfSuppliers = aGateway.GetSuppliers();
            ViewBag.ListOfSuppliers = aListOfSuppliers;

            return View("GetSuppliers");
        }


        public IActionResult InsertASupplierForm()
        {
            return View();
        }
        public IActionResult InsertASupplier(string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            
            DBGateway aGateway = new DBGateway();
            aGateway.InsertASupplier(companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax);

            List<Supplier> aListOfSuppliers = aGateway.GetSuppliers();
            ViewBag.ListOfSuppliers = aListOfSuppliers;

            return View("GetSuppliers");
        }

        public IActionResult GetCustomers()
        {
            DBGateway aGateway = new DBGateway();
            List<Customer> listOfCustomers = aGateway.GetCustomers();
            ViewBag.ListOfCustomers = listOfCustomers;
            return View();
        }
        public IActionResult InsertACustomerForm()
        {
            return View();
        }
        public IActionResult InsertACustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.InsertACustomer(customerId, companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax);

            List<Customer> listOfCustomers = aGateway.GetCustomers();
            ViewBag.ListOfCustomers = listOfCustomers;

            return View("GetCustomers");
        }
        
        public IActionResult GetCustomerById(string customerId)
        {
            DBGateway aGateway = new DBGateway();

            List<Customer> aListOfCustomers = aGateway.GetCustomerById(customerId);
            ViewBag.ListOfCustomers = aListOfCustomers;
            return View();
            
        }

        // Method to display the update form for a customer
        public IActionResult UpdateACustomerForm(string customerId)
        {
            DBGateway aGateway = new DBGateway();
            List<Customer> aListOfCustomers = new List<Customer>();
            aListOfCustomers = aGateway.GetCustomerById(customerId);


            ViewBag.ListOfCustomers = aListOfCustomers;

            return View();
        }

        // Method to update a customer
        public IActionResult UpdateACustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateACustomer(customerId, companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax);
            List<Customer> aListOfCustomers = new List<Customer>();
            // Redirect to the customer details page after updating
            //return RedirectToAction("GetCustomerById", new { customerId = customerId });

            ViewBag.ListOfCustomers = aGateway.GetCustomers();
            return View("GetCustomers");

        }
        
        //for employees
        public IActionResult GetEmployees()
        {
            DBGateway aGateway = new DBGateway();
            List<Employee> listOfEmployees = aGateway.GetEmployees();
            ViewBag.ListOfEmployees = listOfEmployees;
            return View();
        }

        //for shippers
        public IActionResult GetShippers()
        {
            DBGateway aGateway = new DBGateway();
            List<Shipper> listOfShippers = aGateway.GetShippers();
            ViewBag.ListOfShippers = listOfShippers;
            return View();
        }

        //for Order
        public IActionResult GetOrders()
        {
            DBGateway aGateway = new DBGateway();  // Creating an instance of your database gateway

            List<Order> aListOfOrders = aGateway.GetOrders();  // Calling the method to get all orders from the database

            ViewBag.ListOfOrders = aListOfOrders;  // Storing the list of orders in the ViewBag to pass it to the view

            return View();  // Returning the corresponding view which should display the orders
        }

        //for orderdetails
        public IActionResult GetOrderDetails()
        {
            DBGateway aGateway = new DBGateway();
            List<OrderDetail> listOfOrderDetails = aGateway.GetOrderDetails();
            ViewBag.listOfOrderDetails = listOfOrderDetails;
            return View();
        }

        //for filtered products-4/16/2024(by budaaaaaaa)
       
        //insert for employee
        public IActionResult InsertAnEmployeeForm()
        {
            return View();
        }

        public IActionResult InsertAnEmployee(string lastName, string firstName, string title, string titleOfCourtesy, string birthDate, string hireDate, string address, string city, string region, string postalCode, string country, string homePhone, string extension, string notes, int reportsTo)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.InsertAnEmployee(lastName, firstName, title, titleOfCourtesy, birthDate, hireDate, address, city, region, postalCode, country, homePhone, extension, notes, reportsTo);

            List <Employee> listOfEmployees = aGateway.GetEmployees();
            ViewBag.ListOfEmployees = listOfEmployees;

            return View("GetEmployees");
        }
        //insert for shipper
        public IActionResult InsertAShipperForm()
        {
            return View();
        }
        public IActionResult InsertAShipper(int shipperId,string companyName, string phone)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.InsertAShipper(shipperId,companyName, phone);

            List<Shipper> listOfShippers = aGateway.GetShippers();
            ViewBag.ListOfShippers = listOfShippers;

            return View("GetShippers");
        }

        //for orders
        public IActionResult InsertAnOrderForm()
        {
            DBGateway aGateway = new DBGateway();

            // Fetch lists of employees and customers for the order form
            List<Employee> aListOfEmployees = aGateway.GetEmployees();  // Method to fetch all employees
            List<Customer> aListOfCustomers = aGateway.GetCustomers();  // Method to fetch all customers

            // Store these lists in the ViewBag for access in the view
            ViewBag.ListOfEmployees = aListOfEmployees;
            ViewBag.ListOfCustomers = aListOfCustomers;

            return View();  // Returning the view that contains the form for inserting a new order
        }
        public IActionResult InsertAnOrder(string customerId, int employeeId, string orderDate, string requiredDate, string shippedDate, int shipVia, double freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            DBGateway aGateway = new DBGateway();

            // Insert the new order using the provided details
            aGateway.InsertAnOrder(customerId, employeeId, orderDate, requiredDate, shippedDate, shipVia, freight, shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry);

            // Fetch all orders to show the updated list, including the newly inserted order
            List<Order> aListOfOrders = aGateway.GetOrders();

            ViewBag.ListOfOrders = aListOfOrders;

            // Return the user to the GetOrders view to confirm the order was added
            return View("GetOrders");
        }

        //for order details
        public IActionResult InsertAnOrderDetailsForm()

        {
            DBGateway aGateway = new DBGateway();

            // Fetch lists of employees and customers for the order form
            List<Product> aListOfProducts = aGateway.GetProducts();  // Method to fetch all employees
            List<Order> aListOfOrders = aGateway.GetOrders();  // Method to fetch all customers

            // Store these lists in the ViewBag for access in the view
            ViewBag.ListOfProducts = aListOfProducts;
            ViewBag.ListOfOrders = aListOfOrders;

            return View();
        }
        public IActionResult InsertAnOrderDetails(int orderId, int productId, double unitPrice, int quantity, double discount)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.InsertAnOrderDetails(orderId, productId, unitPrice, quantity, discount);

            List<OrderDetail> listOfOrderDetails = aGateway.GetOrderDetails();
            ViewBag.ListOfOrderDetails = listOfOrderDetails;
            return View("GetOrderDetails");
        }

        //update of employees
        public IActionResult GetEmployeeById(int employeeId)
        {
            DBGateway aGateway = new DBGateway(); // Initialize our gateway

            // Retrieve employee information by ID
            List<Employee> aListOfEmployees = aGateway.GetEmployeeById(employeeId);

            // Pass the retrieved employee information to the view
            ViewBag.ListOfEmployees = aListOfEmployees;

            return View();
        }
        public IActionResult UpdateAnEmployeeForm(int employeeId)
        {
            DBGateway aGateway = new DBGateway();
            List<Employee> aListOfEmployees = new List<Employee>();
            //List<Category> aListOfCategories = aGateway.GetCategories();

            aListOfEmployees = aGateway.GetEmployeeById(employeeId);

            //ViewBag.ListOfCategories = aListOfCategories;
            ViewBag.ListOfEmployees = aListOfEmployees;

            return View();
        }
        public IActionResult UpdateAnEmployee(int employeeId, string lastName, string firstName, string title, string titleOfCourtesy, string birthDate, string hireDate, string address, string city, string region, string postalCode, string country, string homePhone, string extension, string notes, int reportsTo)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateAnEmployee(employeeId, lastName, firstName, title, titleOfCourtesy, birthDate, hireDate, address, city, region, postalCode, country, homePhone, extension, notes, reportsTo);

            List<Employee> aListOfEmployees = new List<Employee>();
            ViewBag.ListOfEmployees = aGateway.GetEmployees();
            return View("GetEmployees");
        }

        //update for shipper
        public IActionResult GetShipperById(int shipperId)
        {
            DBGateway aGateway = new DBGateway();
            List<Shipper> aListOfShippers = aGateway.GetShipperById(shipperId);
            ViewBag.ListOfShippers = aListOfShippers;
            return View();
        }

        public IActionResult UpdateAShipperForm(int shipperId)
        {
            DBGateway aGateway = new DBGateway();
            List<Shipper> aListOfShippers = new List<Shipper>();
            aListOfShippers = aGateway.GetShipperById(shipperId);
            ViewBag.ListOfShippers = aListOfShippers;
            return View();
        }

        public IActionResult UpdateAShipper(int shipperId, string companyName, string phone)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateAShipper(shipperId, companyName, phone);
            List<Shipper> aListOfShippers = new List<Shipper>();
            ViewBag.ListOfShippers = aGateway.GetShippers(); ;
            
            return View("GetShippers");
        }
        //update for order
        public IActionResult GetOrderById(int orderId)
        {
            DBGateway aGateway = new DBGateway();

            // Fetch the specific order using the provided order ID
            List<Order> listOfOrders = aGateway.GetOrderById(orderId);

            // Store the order in the ViewBag to pass it to the view
            ViewBag.ListOfOrders = listOfOrders;

            // Return the view that will display the order details
            return View();  // This will use the default view associated with this action
        }

        public IActionResult UpdateAnOrderForm(int orderId)
        {
            DBGateway aGateway = new DBGateway();
            List<Order> aListOfOrders = new List<Order>();
            List<Employee> aListOfEmployees = aGateway.GetEmployees();  // Assuming you need employee info for dropdowns
            List<Customer> aListOfCustomers = aGateway.GetCustomers();  // Assuming you need customer info for dropdowns

            aListOfOrders = aGateway.GetOrderById(orderId);

            ViewBag.ListOfEmployees = aListOfEmployees;
            ViewBag.ListOfCustomers = aListOfCustomers;
            ViewBag.ListOfOrders = aListOfOrders;

            return View();  // Return the view used for updating an order
        }

        public IActionResult UpdateAnOrder(int orderId, string customerId, int employeeId, string orderDate, string requiredDate, string shippedDate, int shipVia, double freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateAnOrder(orderId, customerId, employeeId, orderDate, requiredDate, shippedDate, shipVia, freight, shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry);

            List<Order> aListOfOrders = new List<Order>();
            ViewBag.ListOfOrders = aGateway.GetOrders();
            return View("GetOrders");  // Assuming there is a view that lists all orders
        }

        // for order details
        public IActionResult GetOrderDetailsById(int orderId)
        {
            DBGateway gateway = new DBGateway();

            List<OrderDetail> orderDetails = gateway.GetOrderDetailsById(orderId);

            ViewBag.ListOfOrderDetails = orderDetails;

            return View();
        }
        public IActionResult UpdateAnOrderDetailForm(int orderId)
        {
            DBGateway aGateway = new DBGateway();
            List<OrderDetail> aListOfOrderDetails = new List<OrderDetail>();
            List<Product> aListOfProducts = aGateway.GetProducts();  // Assuming we need customer info for dropdowns

            

            
            aListOfOrderDetails = aGateway.GetOrderDetailsById(orderId);
            ViewBag.ListOfProducts = aListOfProducts;
            ViewBag.ListOfOrderDetails = aListOfOrderDetails;

            return View();
        }


        public IActionResult UpdateAnOrderDetail(int orderId, int productId, double unitPrice, int quantity, double discount)
        {
           
            DBGateway aGateway = new DBGateway();

             aGateway.UpdateAnOrderDetail(orderId, productId, unitPrice, quantity, discount);

            ViewBag.ListOfOrderDetails = aGateway.GetOrderDetails();
           

            return View("GetOrderDetails");
        }

        public IActionResult FilterProducts(string productName, double? minPrice, double? maxPrice)
        {
            List<Product> listOfProducts;
            List<Product> filteredListOfProducts;

            DBGateway gateway = new DBGateway();
            listOfProducts = gateway.GetProducts();

            // Check if all filter parameters are null or empty
            if (string.IsNullOrWhiteSpace(productName) && !minPrice.HasValue && !maxPrice.HasValue)
            {
                // If all filter parameters are empty, return the full list of products
                ViewBag.ListOfProducts = listOfProducts;
            }
            else
            {
                // Normalize filter inputs by removing spaces and converting to lowercase
                string normalizedProductName = productName?.Replace(" ", "")?.ToLower();

                // Apply filters using LINQ
                filteredListOfProducts = listOfProducts
                    .Where(p =>
                        (string.IsNullOrWhiteSpace(normalizedProductName) || p.ProductName.ToLower().Replace(" ", "").Contains(normalizedProductName)) &&
                        (!minPrice.HasValue || p.UnitPrice >= minPrice) &&
                        (!maxPrice.HasValue || p.UnitPrice <= maxPrice))
                    .OrderBy(p => p.ProductName) // Order by product name in ascending order
                    .ToList();

                ViewBag.ListOfProducts = filteredListOfProducts;
            }

            return View("GetProducts");
        }

        public IActionResult FilterCategories(string categoryName, string categoryDescription)
        {
            List<Category> listOfCategories;
            List<Category> filteredListOfCategories;

            DBGateway gateway = new DBGateway();
            listOfCategories = gateway.GetCategories();

            // Normalize filter inputs by removing spaces and converting to lowercase
            string normalizedCategoryName = categoryName?.Replace(" ", "")?.ToLower();
            string normalizedCategoryDescription = categoryDescription?.Replace(" ", "")?.ToLower();

            // Apply filter using LINQ
            filteredListOfCategories = listOfCategories
                .Where(c =>
                    (string.IsNullOrWhiteSpace(normalizedCategoryName) || c.CategoryName.ToLower().Replace(" ", "").Contains(normalizedCategoryName)) &&
                    (string.IsNullOrWhiteSpace(normalizedCategoryDescription) || c.Description.ToLower().Replace(" ", "").Contains(normalizedCategoryDescription)))
                .OrderBy(c => c.CategoryName) // Order by category name in ascending order
                .ToList();

            // Check if all filter parameters are null or empty
            if (string.IsNullOrWhiteSpace(categoryName) && string.IsNullOrWhiteSpace(categoryDescription))
            {
                // If all filter parameters are empty, return the full list of categories
                ViewBag.ListOfCategories = listOfCategories;
            }
            else
            {
                ViewBag.ListOfCategories = filteredListOfCategories;
            }

            return View("GetCategories");
        }


        public IActionResult FilterSuppliers(string companyName, string city, string country)
        {
            List<Supplier> listOfSuppliers;
            List<Supplier> filteredListOfSuppliers;

            DBGateway gateway = new DBGateway();
            listOfSuppliers = gateway.GetSuppliers();

            // Normalize filter inputs by removing spaces and converting to lowercase
            string normalizedCompanyName = companyName?.Replace(" ", "")?.ToLower();
            string normalizedCity = city?.Replace(" ", "")?.ToLower();
            string normalizedCountry = country?.Replace(" ", "")?.ToLower();

            // Check if all filter parameters are null or empty
            if (string.IsNullOrWhiteSpace(normalizedCompanyName) && string.IsNullOrWhiteSpace(normalizedCity) && string.IsNullOrWhiteSpace(normalizedCountry))
            {
                // If all filter parameters are empty, return the full list of suppliers
                ViewBag.ListOfSuppliers = listOfSuppliers;
            }
            else
            {
                // Apply filters using LINQ
                filteredListOfSuppliers = listOfSuppliers
                    .Where(s =>
                        (string.IsNullOrWhiteSpace(normalizedCompanyName) || s.CompanyName.ToLower().Replace(" ", "").Contains(normalizedCompanyName)) &&
                        (string.IsNullOrWhiteSpace(normalizedCity) || s.City.ToLower().Replace(" ", "").Contains(normalizedCity)) &&
                        (string.IsNullOrWhiteSpace(normalizedCountry) || s.Country.ToLower().Replace(" ", "").Contains(normalizedCountry)))
                    .ToList();

                ViewBag.ListOfSuppliers = filteredListOfSuppliers;
            }

            return View("GetSuppliers");
        }


        public IActionResult FilterCustomers(string companyName, string contactName, string city, string region, string country, string postalCode, string phone, string fax)
        {
            List<Customer> listOfCustomers;
            List<Customer> filteredListOfCustomers;

            DBGateway gateway = new DBGateway();
            listOfCustomers = gateway.GetCustomers();

            // Normalize filter inputs by removing spaces and converting to lowercase
            string normalizedCompanyName = companyName?.Replace(" ", "")?.ToLower();
            string normalizedContactName = contactName?.Replace(" ", "")?.ToLower();
            string normalizedCity = city?.Replace(" ", "")?.ToLower();
            string normalizedRegion = region?.Replace(" ", "")?.ToLower();
            string normalizedCountry = country?.Replace(" ", "")?.ToLower();
            string normalizedPostalCode = postalCode?.Replace(" ", "")?.ToLower();
            string normalizedPhone = phone?.Replace(" ", "")?.ToLower();
            string normalizedFax = fax?.Replace(" ", "")?.ToLower();

            // Check if all filter parameters are null or empty
            if (string.IsNullOrWhiteSpace(normalizedCompanyName) &&
                string.IsNullOrWhiteSpace(normalizedContactName) &&
                string.IsNullOrWhiteSpace(normalizedCity) &&
                string.IsNullOrWhiteSpace(normalizedRegion) &&
                string.IsNullOrWhiteSpace(normalizedCountry) &&
                string.IsNullOrWhiteSpace(normalizedPostalCode) &&
                string.IsNullOrWhiteSpace(normalizedPhone) &&
                string.IsNullOrWhiteSpace(normalizedFax))
            {
                // If all filter parameters are empty, return the full list of customers
                ViewBag.ListOfCustomers = listOfCustomers;
            }
            else
            {
                // Apply filters using LINQ
                filteredListOfCustomers = listOfCustomers
                    .Where(c =>
                        (string.IsNullOrWhiteSpace(normalizedCompanyName) || c.CompanyName.ToLower().Contains(normalizedCompanyName)) &&
                        (string.IsNullOrWhiteSpace(normalizedContactName) || c.ContactName.ToLower().Contains(normalizedContactName)) &&
                        (string.IsNullOrWhiteSpace(normalizedCity) || c.City.ToLower().Contains(normalizedCity)) &&
                        (string.IsNullOrWhiteSpace(normalizedRegion) || c.Region.ToLower().Contains(normalizedRegion)) &&
                        (string.IsNullOrWhiteSpace(normalizedCountry) || c.Country.ToLower().Contains(normalizedCountry)) &&
                        (string.IsNullOrWhiteSpace(normalizedPostalCode) || c.PostalCode.ToLower().Contains(normalizedPostalCode)) &&
                        (string.IsNullOrWhiteSpace(normalizedPhone) || c.Phone.ToLower().Contains(normalizedPhone)) &&
                        (string.IsNullOrWhiteSpace(normalizedFax) || c.Fax.ToLower().Contains(normalizedFax)))
                    .OrderBy(c => c.CompanyName) // Order by company name in ascending order
                    .ToList();

                ViewBag.ListOfCustomers = filteredListOfCustomers;
            }

            return View("GetCustomers");
        }


        public IActionResult FilterEmployees(string lastName, string firstName, string title)
        {
            List<Employee> listOfEmployees;
            List<Employee> filteredListOfEmployees;

            DBGateway gateway = new DBGateway();
            listOfEmployees = gateway.GetEmployees();

            // Normalize filter inputs by removing spaces and converting to lowercase
            string normalizedLastName = lastName?.Replace(" ", "")?.ToLower();
            string normalizedFirstName = firstName?.Replace(" ", "")?.ToLower();
            string normalizedTitle = title?.Replace(" ", "")?.ToLower();

            // Check if all filter parameters are null or empty
            if (string.IsNullOrWhiteSpace(normalizedLastName) && string.IsNullOrWhiteSpace(normalizedFirstName) && string.IsNullOrWhiteSpace(normalizedTitle))
            {
                // If all filter parameters are empty, return the full list of employees
                ViewBag.ListOfEmployees = listOfEmployees;
            }
            else
            {
                // Apply filters using LINQ
                filteredListOfEmployees = listOfEmployees
                    .Where(e =>
                        (string.IsNullOrWhiteSpace(normalizedLastName) || e.LastName.ToLower().Replace(" ", "").Contains(normalizedLastName)) &&
                        (string.IsNullOrWhiteSpace(normalizedFirstName) || e.FirstName.ToLower().Replace(" ", "").Contains(normalizedFirstName)) &&
                        (string.IsNullOrWhiteSpace(normalizedTitle) || e.Title.ToLower().Replace(" ", "").Contains(normalizedTitle)))
                    .ToList();

                ViewBag.ListOfEmployees = filteredListOfEmployees;
            }

            return View("GetEmployees");
        }

        public IActionResult FilterShippers(string companyName, string phone)
        {
            List<Shipper> listOfShippers;
            List<Shipper> filteredListOfShippers;

            DBGateway gateway = new DBGateway();
            listOfShippers = gateway.GetShippers();

            // Normalize filter inputs by removing spaces and converting to lowercase
            string normalizedCompanyName = companyName?.Replace(" ", "")?.ToLower();
            string normalizedPhone = phone?.Replace(" ", "")?.ToLower();

            // Check if all filter parameters are null or empty
            if (string.IsNullOrWhiteSpace(normalizedCompanyName) && string.IsNullOrWhiteSpace(normalizedPhone))
            {
                // If all filter parameters are empty, return the full list of shippers
                ViewBag.ListOfShippers = listOfShippers;
            }
            else
            {
                // Apply filters using LINQ
                filteredListOfShippers = listOfShippers
                    .Where(s =>
                        (string.IsNullOrWhiteSpace(normalizedCompanyName) || s.CompanyName.ToLower().Replace(" ", "").Contains(normalizedCompanyName)) &&
                        (string.IsNullOrWhiteSpace(normalizedPhone) || s.Phone.ToLower().Replace(" ", "").Contains(normalizedPhone)))
                    .ToList();

                ViewBag.ListOfShippers = filteredListOfShippers;
            }

            return View("GetShippers");
        }


        public IActionResult FilterOrders(string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            List<Order> listOfOrders;
            List<Order> filteredListOfOrders;

            DBGateway gateway = new DBGateway();
            listOfOrders = gateway.GetOrders();

            // Normalize filter inputs by removing spaces and converting to lowercase
            string normalizedShipName = shipName?.Replace(" ", "")?.ToLower();
            string normalizedShipAddress = shipAddress?.Replace(" ", "")?.ToLower();
            string normalizedShipCity = shipCity?.Replace(" ", "")?.ToLower();
            string normalizedShipRegion = shipRegion?.Replace(" ", "")?.ToLower();
            string normalizedShipPostalCode = shipPostalCode?.Replace(" ", "")?.ToLower();
            string normalizedShipCountry = shipCountry?.Replace(" ", "")?.ToLower();

            // Check if all filter parameters are null or empty
            if (string.IsNullOrWhiteSpace(normalizedShipName) &&
                string.IsNullOrWhiteSpace(normalizedShipAddress) &&
                string.IsNullOrWhiteSpace(normalizedShipCity) &&
                string.IsNullOrWhiteSpace(normalizedShipRegion) &&
                string.IsNullOrWhiteSpace(normalizedShipPostalCode) &&
                string.IsNullOrWhiteSpace(normalizedShipCountry))
            {
                // If all filter parameters are empty, return the full list of orders
                ViewBag.ListOfOrders = listOfOrders;
            }
            else
            {
                filteredListOfOrders = listOfOrders
                    .Where(o =>
                        (string.IsNullOrWhiteSpace(normalizedShipName) || o.ShipName.ToLower().Replace(" ", "").Contains(normalizedShipName)) &&
                        (string.IsNullOrWhiteSpace(normalizedShipAddress) || o.ShipAddress.ToLower().Replace(" ", "").Contains(normalizedShipAddress)) &&
                        (string.IsNullOrWhiteSpace(normalizedShipCity) || (o.ShipCity != null && o.ShipCity.ToLower().Replace(" ", "").Contains(normalizedShipCity))) &&
                        (string.IsNullOrWhiteSpace(normalizedShipRegion) || (o.ShipRegion != null && o.ShipRegion.ToLower().Replace(" ", "").Contains(normalizedShipRegion))) &&
                        (string.IsNullOrWhiteSpace(normalizedShipPostalCode) || (o.ShipPostalCode != null && o.ShipPostalCode.ToLower().Replace(" ", "").Contains(normalizedShipPostalCode))) &&
                        (string.IsNullOrWhiteSpace(normalizedShipCountry) || (o.ShipCountry != null && o.ShipCountry.ToLower().Replace(" ", "").Contains(normalizedShipCountry))))
                    .ToList();


                ViewBag.ListOfOrders = filteredListOfOrders;
            }

            return View("GetOrders");
        }

        public IActionResult FilterOrderDetails(string orderId, string productId, string unitPrice, string quantity, string discount)
        {
            List<OrderDetail> listOfOrderDetails;
            List<OrderDetail> filteredListOfOrderDetails;

            DBGateway gateway = new DBGateway();
            listOfOrderDetails = gateway.GetOrderDetails();

            // Normalize filter inputs by removing spaces and converting to lowercase
            string normalizedOrderId = orderId?.Replace(" ", "")?.ToLower();
            string normalizedProductId = productId?.Replace(" ", "")?.ToLower();
            string normalizedUnitPrice = unitPrice?.Replace(" ", "")?.ToLower();
            string normalizedQuantity = quantity?.Replace(" ", "")?.ToLower();
            string normalizedDiscount = discount?.Replace(" ", "")?.ToLower();

            // Apply filters using LINQ
            // Apply filters using LINQ and sort in ascending order
            filteredListOfOrderDetails = listOfOrderDetails
                .Where(detail =>
                    (string.IsNullOrWhiteSpace(normalizedOrderId) || detail.OrderId.ToString().ToLower().Contains(normalizedOrderId)) &&
                    (string.IsNullOrWhiteSpace(normalizedProductId) || detail.ProductId.ToString().ToLower().Contains(normalizedProductId)) &&
                    (string.IsNullOrWhiteSpace(normalizedUnitPrice) || detail.UnitPrice.ToString().ToLower().Contains(normalizedUnitPrice)) &&
                    (string.IsNullOrWhiteSpace(normalizedQuantity) || detail.Quantity.ToString().ToLower().Contains(normalizedQuantity)) &&
                    (string.IsNullOrWhiteSpace(normalizedDiscount) || detail.Discount.ToString().ToLower().Contains(normalizedDiscount)))
                .OrderBy(detail => detail.OrderId)
                .ToList();

            ViewBag.ListOfOrderDetails = filteredListOfOrderDetails;

            return View("GetOrderDetails");
        }


    }
}