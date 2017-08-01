using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPOS
{
    class Product
    {
        private String productName;
        private double price;


        public Product()
        {
            productName = "";
            price = 0;
        }

        public Product(String productName, double price)
        {
            this.productName = productName;
            this.price = price;
        }

        public String getProductName()
        {
            return productName;
        }

        public double getPrice()
        {
            return price;
        }

        public void setProductName(String productName)
        {
            this.productName = productName;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }

        public String toString()
        {
            return "Product Name: " + productName + " Price: " + price;
        }
    }
}
