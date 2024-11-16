

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.Models
{
    public class Product
    {
        private int productId = -1;
        private string productName = "n/a";
        private int supplierId = -1;
        private int categoryId = -1;
        private string quantityPerUnit = "n/a";
        private double unitPrice = double.MaxValue;
        private int unitInStock = -1;
        private int unitsOnOrder = -1;
        private int reOrderLevel = int.MaxValue;
        private bool discontinued = true;

        public int ProductId
        {
            get { return this.productId; }
            set 
            {
                if (value < -1)
                {
                    this.productId = -1;
                }
                else
                {
                    this.productId = value;
                }
            }
        }
        public string ProductName
        {
            get { return this.productName; }
            set { this.productName = value; }
        }
        public int SupplierId
        {
            get { return this.supplierId; }
            set
            {
                if (value < -1)
                {
                    this.supplierId = -1;
                }
                else
                {
                    this.supplierId = value;
                }
            }
        }
        public int CategoryId
        {
            get { return this.categoryId; }
            set
            {
                if (value < -1)
                {
                    this.categoryId = -1;
                }
                else
                {
                    this.categoryId = value;
                }
            }
        }
        public string QuantityPerUnit
        {
            get { return this.quantityPerUnit; }
            set { this.quantityPerUnit = value; }
        }
        public double UnitPrice
        {
            get { return this.unitPrice; }
            set
            {
                if (value < 0.0)
                {
                    this.unitPrice = double.MaxValue;
                }
                else
                {
                    this.unitPrice = value;
                }
            }
        }
        public int UnitInStock
        {
            get { return this.unitInStock; }
            set
            {
                if (value < -1)
                {
                    this.unitInStock = -1;
                }
                else
                {
                    this.unitInStock = value;
                }
            }
        }
        public int UnitsOnOrder
        {
            get { return this.unitsOnOrder; }
            set
            {
                if (value < -1)
                {
                    this.unitsOnOrder = -1;
                }
                else
                {
                    this.unitsOnOrder = value;
                }
            }
        }
        public int ReOrderLevel
        {
            get { return this.reOrderLevel; }
            set
            {
                if (value < 0.0)
                {
                    this.reOrderLevel = int.MaxValue;
                }
                else
                {
                    this.reOrderLevel = value;
                }
            }
        }
        public bool Discontinued
        {
            get { return this.discontinued; }
            set { this.discontinued = value; }
        }

        //Contructors
        public Product()
        {

        }
        //Methods
        public override string ToString()
        {
            string message = "";
            message = message + "Product Id: " + this.ProductId + "\n";
            message = message + "Product Name: " + this.ProductName + "\n";
            message = message + "Supplier Id: " + this.SupplierId + "\n";
            message = message + "Category Id: " + this.CategoryId + "\n";
            message = message + "Quantity Per Unit: " + this.QuantityPerUnit + "\n";
            message = message + "Unit Price: " + this.UnitPrice + "\n";
            message = message + "Units In Stock: " + this.UnitInStock + "\n";
            message = message + "Units On Order: " + this.UnitsOnOrder + "\n";
            message = message + "Reorder Level: " + this.ReOrderLevel + "\n";
            message = message + "Discontinued: " + this.Discontinued + "\n";
            return message;
        }
    }
}
