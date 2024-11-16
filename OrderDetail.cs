

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.Models
{
    public class OrderDetail
    {
        private int orderId = -1;
        private int productId = -1;
        private double unitPrice = double.MaxValue;
        private int quantity = 0;
        private double discount = 0.0;

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
                {
                    this.orderId = value;
                } 
            }
        }
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
        public double UnitPrice
        {
            get { return this.unitPrice; }
            set 
            {
                if (value < 0.00)
                {
                    this.unitPrice = double.MaxValue;
                }
                    
                else
                {
                    this.unitPrice = value;
                }
                    
            }
        }
        public int Quantity
        {
            get { return this.quantity; }
            set 
            {
                if (value > 0)
                {
                    this.quantity = value;
                }    
                else
                {
                    this.quantity = 0;
                }
            }
        }
        public double Discount
        {
            get { return this.discount; }
            set 
            {
                if (value > 0.0)
                {
                    this.discount = value;
                }
                else
                {
                    this.discount = 0.0;
                }
            }
        }

        //Consructors
        public OrderDetail()
        {

        }

        //Methods
        public override string ToString()
        {
            string message = "";
            message = message + "OrderId: " + this.OrderId + "\n";
            message = message + "ProductId: " + this.ProductId + "\n";
            message = message + "UnitPrice: " + this.UnitPrice + "\n";
            message = message + "Quantity: " + this.Quantity + "\n";
            message = message + "Discount: " + this.Discount + "\n";
            return message;
        }
    }
}
