using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Assignment 1 - Console .NET");

        // 1. Optimized Bubble Sort
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        BubbleSortOptimized.Sort(arr);
        Console.WriteLine("Sorted array using Optimized Bubble Sort: " + string.Join(", ", arr));

        // 2. Range<T>
        Range<int> range = new Range<int>(10, 20);
        Console.WriteLine("Is 15 in range (10-20)? " + range.IsInRange(15));
        Console.WriteLine("Length of range (10-20): " + range.Length());

        // 3. Reverse ArrayList
        ArrayList list = new ArrayList() { 1, 2, 3, 4, 5 };
        ReverseArrayList.Reverse(list);
        Console.WriteLine("Reversed ArrayList: " + string.Join(", ", list.ToArray()));

        // 4. Even Numbers Filter
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
        List<int> evens = EvenNumbersFilter.GetEvenNumbers(numbers);
        Console.WriteLine("Even numbers: " + string.Join(", ", evens));

        // 5. FixedSizeList<T>
        FixedSizeList<string> fixedList = new FixedSizeList<string>(2);
        fixedList.Add("Hello");
        fixedList.Add("World");
        Console.WriteLine("FixedSizeList item at index 1: " + fixedList.Get(1));

        try
        {
            fixedList.Add("Extra");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        // 6. First Non-Repeated Character
        string s = "swiss";
        int index = FirstNonRepeatedChar.FirstUniqueChar(s);
        Console.WriteLine($"First non-repeated character in '{s}' is at index: {index}");
    }
}
