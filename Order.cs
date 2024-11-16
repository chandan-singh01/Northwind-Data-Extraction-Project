
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.Models
{
    public class Order
    {
        private int orderId = -1;
        private string customerId = "n/a";
        private int employeeId = -1;
        private string orderDate = "n/a";
        private string requiredDate = "n/a";
        private string shippedDate = "n/a";
        private int shipVia = -1;
        private double freight = double.MaxValue;
        private string shipName = "n/a";
        private string shipAddress = "n/a";
        private string shipCity = "n/a";
        private string shipRegion = "n/a";
        private string shipPostalCode = "n/a";
        private string shipCountry = "n/a";

        public int OrderId
        {
            get { return this.orderId; }
            set
            {
                if (value < -1)
                {
                    this.orderId = -1;
                }
                else
                    this.orderId = value;
            }
        }
        public string CustomerId
        {
            get { return this.customerId; }
            set { this.customerId = value; }
        }
        public int EmployeeId
        {
            get { return this.employeeId; }
            set { this.employeeId = value; }
        }
        public string OrderDate
        {
            get { return this.orderDate; }
            set { this.orderDate = value; }
        }
        public string RequiredDate
        {
            get { return this.requiredDate; }
            set { this.requiredDate = value; }
        }
        public string ShippedDate
        {
            get { return this.shippedDate; }
            set { this.shippedDate = value; }
        }
        public int ShipVia
        {
            get { return this.shipVia; }
            set
            {
                if(value < -1)
                {
                    this.shipVia = -1;
                }
                else
                {
                    this.shipVia = value;
                }
            }
        }
        public double Freight
        {
            get { return this.freight; }
            set
            {
                if (value < 0)
                {
                    this.freight = double.MaxValue;
                }
                else
                {
                    this.freight = value;
                }
            }
        }
        public string ShipName
        {
            get { return this.shipName; }
            set { this.shipName = value; }
        }
        public string ShipAddress
        {
            get { return this.shipAddress; }
            set { this.shipAddress = value; }
        }
        public string ShipCity
        {
            get { return this.shipCity; }
            set { this.shipCity = value; }
        }
        public string ShipRegion
        {
            get { return this.shipRegion; }
            set { this.shipRegion = value; }
        }
        public string ShipPostalCode
        {
            get { return this.shipPostalCode; }
            set { this.shipPostalCode = value; }
        }
        public string ShipCountry
        {
            get { return this.shipCountry; }
            set { this.shipCountry = value; }
        }

        //Constructors

        public Order()
        {

        }
        //Methods
        public override string ToString()
        {
            string message = "";
            message = message + "OrderId: " + this.OrderId + "\n";
            message = message + "CustomerId: " + this.CustomerId + "\n";
            message = message + "EmployeeId: " + this.EmployeeId + "\n";
            message = message + "Order date: " + this.OrderDate + "\n";
            message = message + "Required date: " + this.RequiredDate + "\n";
            message = message + "Shipped date: " + this.ShippedDate + "\n";
            message = message + "Ship via: " + this.ShipVia + "\n";
            message = message + "Freight: " + this.Freight + "\n";
            message = message + "Ship Name: " + this.ShipName + "\n";
            message = message + "Ship Address: " + this.ShipAddress + "\n";
            message = message + "Ship City: " + this.ShipCity + "\n";
            message = message + "Ship Region: " + this.ShipRegion + "\n";
            message = message + "Ship Postal Code: " + this.ShipPostalCode + "\n";
            message = message + "Ship Country: " + this.ShipCountry + "\n";


            return message;
        }

    }
}
