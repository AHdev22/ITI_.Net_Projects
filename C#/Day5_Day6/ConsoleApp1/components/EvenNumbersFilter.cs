using System;
using System.Collections.Generic;

public class EvenNumbersFilter
{
    public static List<int> GetEvenNumbers(List<int> numbers)
    {
        List<int> evens = new List<int>();
        foreach (int num in numbers)
        {
            if (num % 2 == 0)
                evens.Add(num);
        }
        return evens;
    }
}
