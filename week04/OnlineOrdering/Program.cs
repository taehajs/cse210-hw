using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Address
    {
        private string street;
        private string city;
        private string state;
        private string country;

        public Address(string street, string city, string state, string country)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.country = country;
        }

        public bool IsInUSA()
        {
            return country.Trim().ToUpper() == "USA";
        }

        public string GetFullAddress()
        {
            return $"{street}\n{city}, {state}\n{country}";
        }
    }

    public class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public string GetName()
        {
            return name;
        }

        public Address GetAddress()
        {
            return address;
        }

        public bool LivesInUSA()
        {
            return address.IsInUSA();
        }
    }

    public class Product
    {
        private string name;
        private string productId;
        private double price;
        private int quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
        }

        public double GetTotalCost()
        {
            return price * quantity;
        }

        public string GetProductInfo()
        {
            return $"{name} (ID: {productId})";
        }
    }

    public class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public double GetTotalCost()
        {
            double total = 0;
            foreach (Product p in products)
            {
                total += p.GetTotalCost();
            }
            total += customer.LivesInUSA() ? 5 : 35;
            return total;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (Product p in products)
            {
                label += " - " + p.GetProductInfo() + "\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
            Customer cust1 = new Customer("Alice etan Johnson", addr1);

            Address addr2 = new Address("456 Oxford Rd", "London", "London", "UK");
            Customer cust2 = new Customer("Bob hosh Smith", addr2);

            Order order1 = new Order(cust1);
            order1.AddProduct(new Product("Laptop", "A100", 1200.50, 1));
            order1.AddProduct(new Product("Mouse", "B200", 25.75, 2));

            Order order2 = new Order(cust2);
            order2.AddProduct(new Product("Headphones", "C300", 99.99, 1));
            order2.AddProduct(new Product("Microphone", "D400", 150.00, 1));
            order2.AddProduct(new Product("Webcam", "E500", 80.00, 1));

            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}\n");

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}\n");
        }
    }
}
