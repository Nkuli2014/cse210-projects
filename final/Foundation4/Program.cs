using System;
using System.Collections.Generic;

// Define the Product class with attributes (Abstraction).
public class Product
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; } // Fixed the error here

    public Product(string name, string description, decimal price, string category)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
    }
}

// Define the Inventory class for managing products (Encapsulation).
public class Inventory
{
    private List<Product> products;

    public Inventory()
    {
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void DisplayProducts()
    {
        foreach (Product product in products)
        {
            Console.WriteLine($"Name: {product.Name}, Description: {product.Description}, Price: {product.Price}, Category: {product.Category}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the Inventory class.
        Inventory inventory = new Inventory();

        // Add products to the inventory.
        Product product1 = new Product("Laptop", "High-performance laptop", 999.99m, "Electronics");
        Product product2 = new Product("T-shirt", "Cotton T-shirt", 19.99m, "Clothing");
        inventory.AddProduct(product1);
        inventory.AddProduct(product2);

        // Display the products in the inventory.
        Console.WriteLine("Products in Inventory:");
        inventory.DisplayProducts();
    }
}
