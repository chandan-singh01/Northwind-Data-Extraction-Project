

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace NorthwindProject.Models
{
    public class Shipper
    {
        private int shipperId = -1;
        private string companyName = "n/a";
        private string phone = "n/a";

        public int ShipperId
        {
            get { return this.shipperId; }
            set
            {
                if (value < -1)
                {
                    this.shipperId = -1;
                }
                else
                    this.shipperId = value;
            }

        }
        public string CompanyName
        {
            get { return this.companyName; }
            set { this.companyName = value; }
        }
        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        //Methods
        public override string ToString()
        {
            string message = "";
            message = message + "Shipper Id: " + this.ShipperId + "\n";
            message = message + "Company Phone: " + this.CompanyName + "\n";
            message = message + "Phone: " + this.Phone + "\n";
            return message;
        }
    }
}
