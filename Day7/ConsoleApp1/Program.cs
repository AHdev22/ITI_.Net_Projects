using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Assignment 2 - Console .NET");

        // Anonymous product object
        var product = Product.CreateProduct("Laptop", 1500.99);
        Console.WriteLine($"Product Details: Name = {product.GetType().GetProperty("Name").GetValue(product)}, Price = {product.GetType().GetProperty("Price").GetValue(product)}");

        // Extension method: Word count
        string sentence = "Hello, world!";
        Console.WriteLine($"Word count in '{sentence}': {sentence.WordCount()}");

        // Extension method: IsEven
        int number = 42;
        Console.WriteLine($"{number} is even? {number.IsEven()}");

        // Extension method: CalculateAge
        DateTime birthDate = new DateTime(2000, 5, 15);
        Console.WriteLine($"Age for birthdate {birthDate.ToShortDateString()}: {birthDate.CalculateAge()}");

        // Extension method: ReverseString
        string text = "hello";
        Console.WriteLine($"Reversed '{text}': {text.ReverseString()}");
    }
}
