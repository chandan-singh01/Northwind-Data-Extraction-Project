using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.Models
{
    // Represents a customer in the system
    public class Customer
    {
        // Fields initialized with default values to store customer details
        private string customerId = "*";
        private string companyName = "n/a";
        private string contactName = "n/a";
        private string contactTitle = "n/a";
        private string address = "n/a";
        private string city = "n/a";
        private string region = "n/a";
        private string postalCode = "n/a";
        private string country = "n/a";
        private string phone = "n/a";
        private string fax = "n/a";

        // Property to get or set the customer ID
        public string CustomerId
        {
            get { return this.customerId; }
            set
            {
                if (value == null)
                { this.customerId = "n/a"; }
                else
                { this.customerId = value; }
            }
        }

        // Properties to get or set customer details
        public string CompanyName
        {
            get { return this.companyName; }
            set { this.companyName = value; }
        }
        public string ContactName
        {
            get { return this.contactName; }
            set { this.contactName = value; }
        }
        public string ContactTitle
        {
            get { return this.contactTitle; }
            set { this.contactTitle = value; }
        }
        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }
        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }
        public string Region
        {
            get { return this.region; }
            set { this.region = value; }
        }
        public string PostalCode
        {
            get { return this.postalCode; }
            set { this.postalCode = value; }
        }
        public string Country
        {
            get { return this.country; }
            set { this.country = value; }
        }
        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }
        public string Fax
        {
            get { return this.fax; }
            set { this.fax = value; }
        }

        // Default constructor
        public Customer()
        {
        }

        // Constructor that initializes all fields with provided values
        public Customer(string aCustomerId, string aCompanyName, string aContactName, string aContactTitle, string aAddress, string aCity, string aRegion, string aPostalCode, string aCountry, string aPhone, string aFax)
        {
            CustomerId = aCustomerId;
            CompanyName = aCompanyName;
            ContactName = aContactName;
            ContactTitle = aContactTitle;
            Address = aAddress;
            City = aCity;
            Region = aRegion;
            PostalCode = aPostalCode;
            Country = aCountry;
            Phone = aPhone;
            Fax = aFax;
        }

        // Provides a string representation of the customer object, useful for debugging or logging
        public override string ToString()
        {
            string message = "";
            message += "Customer Id: " + this.CustomerId + "\n";
            message += "Company Name: " + this.CompanyName + "\n";
            message += "Fax: " + this.Fax + "\n";
            message += "Phone: " + this.Phone + "\n";
            message += "Region: " + this.Region + "\n";
            message += "Postal Code: " + this.PostalCode + "\n";
            message += "Country: " + this.Country + "\n";
            message += "Address: " + this.Address + "\n";
            message += "Contact Title: " + this.ContactTitle + "\n";
            message += "City: " + this.City + "\n";
            message += "Contact Name: " + this.ContactName + "\n";
            return message;
        }
    }
}
