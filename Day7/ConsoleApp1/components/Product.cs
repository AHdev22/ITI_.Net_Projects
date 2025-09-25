using System;

public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

    public static object CreateProduct(string name, double price)
    {
        return new { Name = name, Price = price };
    }
}
