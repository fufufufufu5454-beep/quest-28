using System;
using System.Collections.Generic;

public abstract class Product
{
    private static int _count = 0;

    public string Name { get; set; }
    public decimal Price { get; set; }

    public static int Count => _count;

    protected Product(string name, decimal price)
    {
        Name = name;
        Price = price;
        _count++;
    }

    public abstract void PrintInfo();
}

public class ElectronicProduct : Product
{
    public int WarrantyPeriod { get; set; }

    public ElectronicProduct(string name, decimal price, int warrantyPeriod)
        : base(name, price)
    {
        WarrantyPeriod = warrantyPeriod;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"[Electronic] {Name} | Price: {Price} | Warranty: {WarrantyPeriod} months | Total products: {Count}");
    }
}

public class ClothingProduct : Product
{
    public string Size { get; set; }

    public ClothingProduct(string name, decimal price, string size)
        : base(name, price)
    {
        Size = size;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"[Clothing] {Name} | Price: {Price} | Size: {Size} | Total products: {Count}");
    }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new ElectronicProduct("Laptop", 29999.99m, 24),
            new ElectronicProduct("Phone", 14999.99m, 12),
            new ClothingProduct("T-Shirt", 499.99m, "M"),
            new ClothingProduct("Jeans", 1299.99m, "L")
        };

        foreach (Product p in products)
        {
            p.PrintInfo();
        }

        Console.WriteLine($"\nTotal products created: {Product.Count}");
    }
}
