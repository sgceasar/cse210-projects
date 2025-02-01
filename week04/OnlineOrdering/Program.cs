using System;
using System.Collections.Generic;

// Class Address
public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}

// Class Customer
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }
}

// Classe Product
public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }
     public string GetProductId()
    {
        return _productId;
    }
    public double GetPrice()
    {
        return _price;
    }
     public int GetQuantity()
    {
        return _quantity;
    }
}

// Class Order
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (var product in _products)
        {
            totalCost += product.GetTotalCost();
        }
        double shippingCost = _customer.IsInUSA() ? 5 : 35;
        return totalCost + shippingCost;
    }

     public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += $"Product: {product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
          return $"Shipping Label:\nCustomer: {_customer.GetName()}\nAddress:\n{_customer.GetAddress().GetFullAddress()}";
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        // Creating address
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Elm St", "Otherville", "ON", "Canada");

        // Creating clients
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Creating products
        Product product1 = new Product("Laptop", "LP123", 1200, 1);
        Product product2 = new Product("Mouse", "MS456", 25, 2);
        Product product3 = new Product("Keyboard", "KB789", 75, 1);
        Product product4 = new Product("Monitor", "MN012", 300, 1);
        Product product5 = new Product("Webcam", "WC345", 50, 1);
        
        // Creating orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);


        // Show informations first order
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost()}");

        Console.WriteLine();

        // Show informations second order
          Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
         Console.WriteLine($"Total Price: ${order2.CalculateTotalCost()}");
    }
}
