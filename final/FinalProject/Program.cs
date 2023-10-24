using System;
using System.Collections.Generic;

// Principle: Abstraction
// Divide the program into classes with a single responsibility.
class Program
{
    static void Main(string[] args)
    {
        InventorySystem.Run();
    }
}

public class Product
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }

    public Product(string name, string description, decimal price, string category)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
    }
}

public abstract class InventoryItem
{
    public abstract void DisplayDetails();
}

public class Electronics : InventoryItem
{
    public Product Product { get; set; }

    public Electronics(Product product)
    {
        Product = product;
    }

    // Principle: Polymorphism
    // Method overriding is used where appropriate.
    public override void DisplayDetails()
    {
        Console.WriteLine("Category: Electronics");
        Console.WriteLine($"Name: {Product.Name}, Description: {Product.Description}, Price: {Product.Price}, Category: {Product.Category}");
    }
}

public class Clothing : InventoryItem
{
    public Product Product { get; set; }

    public Clothing(Product product)
    {
        Product = product;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("Category: Clothing");
        Console.WriteLine($"Name: {Product.Name}, Description: {Product.Description}, Price: {Product.Price}, Category: {Product.Category}");
    }
}

public class Inventory
{
    private List<InventoryItem> items;

    public Inventory()
    {
        items = new List<InventoryItem>();
    }

    public void AddItem(InventoryItem item)
    {
        items.Add(item);
    }

    // Principle: Encapsulation
    // All member variables are private, and public methods are defined for necessary behaviors.
    public void DisplayItems()
    {
        foreach (var item in items)
        {
            item.DisplayDetails();
        }
    }
}

public static class InventorySystem
{
    public static void Run()
    {
        // Create an instance of the Inventory class.
        Inventory inventory = new Inventory();

        // Add products to the inventory.
        Product product1 = new Product("Laptop", "High-Performance laptop", 999.99m, "Electronics");
        Product product2 = new Product("T-shirt", "Cotton T-shirt", 19.99m, "Clothing");

        InventoryItem electronicsItem = new Electronics(product1);
        InventoryItem clothingItem = new Clothing(product2);

        inventory.AddItem(electronicsItem);
        inventory.AddItem(clothingItem);

        // Display the items in the inventory.
        Console.WriteLine("Inventory Items:");
        inventory.DisplayItems();
    }
}
