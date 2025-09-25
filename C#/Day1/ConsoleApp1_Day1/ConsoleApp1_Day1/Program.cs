using System.Reflection;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        //1.Program to take a character and display its ASCII code
        Console.Write("Enter a character: ");
        char ch = Console.ReadKey().KeyChar;
        Console.WriteLine($"\nThe ASCII code of '{ch}' is {(int)ch}");

        //2.Program to take an ASCII code and display the character
        Console.WriteLine("Enter The AsCII Code ");
        int code = int.Parse(Console.ReadLine());
        Console.WriteLine($"The character for ASCII code {code} is '{(char)code}'");

        //3.Program to check odd or even
        Console.WriteLine("Enter the Number ");
        int number = int.Parse(Console.ReadLine());
        if (number % 2 == 0)
        {
            Console.WriteLine("Number is even");
        }
        else { Console.WriteLine("Number is odd"); }

        //4.Program for sum, subtraction, multiplication
        Console.WriteLine("Enter the first number");
        int number1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second number");
        int number2 = int.Parse(Console.ReadLine());

        Console.WriteLine($"Sum of numbers is {number1 + number2}");
        Console.WriteLine($"subtraction of numbers is {number1 - number2}");
        Console.WriteLine($"multiplication of numbers is {number1 * number2}");


        //5.Program for student grade
        Console.Write("Enter student degree (0-100): ");
        int degree = int.Parse(Console.ReadLine());

        if (degree >= 90)
            Console.WriteLine("Grade: A");
        else if (degree >= 80 && degree < 90)
            Console.WriteLine("Grade: B");
        else if (degree >= 70 && degree < 80)
            Console.WriteLine("Grade: C");
        else if (degree >= 60 && degree < 70)
            Console.WriteLine("Grade: D");
        else
            Console.WriteLine("Grade: F");

        //6.Multiplication table
        Console.Write("Enter a number for multiplication table: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine($"Multiplication Table of {n}:");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{n} x {i} = {n * i}");
        }

    }
}

