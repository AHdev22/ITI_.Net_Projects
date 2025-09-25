using System;
using System.Collections.Generic;

public class FirstNonRepeatedChar
{
    public static int FirstUniqueChar(string s)
    {
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (charCount.ContainsKey(s[i]))
                charCount[s[i]]++;
            else
                charCount[s[i]] = 1;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (charCount[s[i]] == 1)
                return i;
        }

        return -1;
    }
}
