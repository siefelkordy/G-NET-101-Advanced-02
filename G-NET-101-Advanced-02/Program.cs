
using System;
using System.Collections.Generic;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}

class Program
{
    // Task 01: Smart Product Search
    static List<Product> SearchProducts(
        List<Product> products,
        Func<Product, bool> filter)
    {
        List<Product> result = new List<Product>();

        foreach (Product p in products)
        {
            if (filter(p))
            {
                result.Add(p);
            }
        }

        return result;
    }

    // Task 03.1: Custom Report Generator
    static void PrintReport(
        List<Product> products,
        Action<Product> printAction)
    {
        foreach (Product p in products)
        {
            printAction(p);
        }
    }

    static void Main()
    {
        // Product catalog
        List<Product> catalog = new()
        {
            new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
            new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
            new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
            new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
            new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
            new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
            new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
            new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
            new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
            new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
        };

        // ============================
        // TASK 01: SMART PRODUCT SEARCH
        // ============================

        // 1. All Electronics products
        List<Product> electronics = SearchProducts(
            catalog, p => p.Category == "Electronics");

        // 2. Products cheaper than $50
        List<Product> cheapProducts = SearchProducts(
            catalog, p => p.Price < 50);

        // 3. Products that are in stock
        List<Product> inStock = SearchProducts(
            catalog, p => p.Stock > 0);

        // 4. Clothing products under $100
        List<Product> cheapClothing = SearchProducts(
            catalog,
            p => p.Category == "Clothing" && p.Price < 100);

        Console.WriteLine("===== TASK 01: PRODUCT SEARCH =====");

        Console.WriteLine("\n--- Electronics Products ---");
        PrintReport(electronics,
            p => Console.WriteLine($"{p.Name} - ${p.Price}"));

        Console.WriteLine("\n--- Products Cheaper Than $50 ---");
        PrintReport(cheapProducts,
            p => Console.WriteLine($"{p.Name} - ${p.Price}"));

        Console.WriteLine("\n--- Products In Stock ---");
        PrintReport(inStock,
            p => Console.WriteLine($"{p.Name} - Stock: {p.Stock}"));

        Console.WriteLine("\n--- Clothing Under $100 ---");
        PrintReport(cheapClothing,
            p => Console.WriteLine($"{p.Name} - ${p.Price}"));

        // ===================================
        // TASK 03.1: CUSTOM REPORT GENERATOR
        // ===================================

        Console.WriteLine("\n===== TASK 03.1: CUSTOM REPORTS =====");

        // Scenario 1: Short Report
        Console.WriteLine("\n--- Short Report ---");

        PrintReport(catalog,
            p => Console.WriteLine($"{p.Name} - ${p.Price}"));

        // Scenario 2: Detailed Report
        Console.WriteLine("\n--- Detailed Report ---");

        PrintReport(catalog,
            p => Console.WriteLine(
                $"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));
    }
}
