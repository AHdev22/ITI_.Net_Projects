using System;
using System.Collections;

public class ReverseArrayList
{
    public static void Reverse(ArrayList list)
    {
        int n = list.Count;
        for (int i = 0; i < n / 2; i++)
        {
            object temp = list[i];
            list[i] = list[n - i - 1];
            list[n - i - 1] = temp;
        }
    }
}
