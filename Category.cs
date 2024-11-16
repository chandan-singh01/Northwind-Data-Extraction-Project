using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.Models
{
    // Represents a category of products
    public class Category
    {
        // Fields to store the category's ID, name, and description with default values
        private int categoryId = 0;
        private string categoryName = "n/a";
        private string description = "n/a";

        // Property to get and set the CategoryId
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        // Property to get and set the CategoryName
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        // Property to get and set the Description of the category
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // Default constructor initializing the Category to default values
        public Category() : this(0, "n/a", "n/a")
        {
        }

        // Constructor that initializes a new instance of the Category class with specified values
        public Category(int aCategoryId, string aCategoryName, string aDescription)
        {
            this.CategoryId = aCategoryId;
            this.CategoryName = aCategoryName;
            this.Description = aDescription;
        }

        // Method to provide a string representation of the category object, useful for debugging
        public override string ToString()
        {
            string message = "";
            message += "CategoryId = " + this.CategoryId + "<br />";
            message += "CategoryName = " + this.CategoryName + "<br />";
            message += "Description = " + this.Description + "<br />";
            return message;
        }
    }
}
