using System;
using System.Collections.Generic;

class Program
{
    public static Dictionary<int, int> Count(int[] arr)
    {
        var dict = new Dictionary<int, int>();
        
        foreach(var i in arr)
        {
            if (dict.ContainsKey(i)) dict[i]++;
            else dict[i] = 1;
        }
        
        return dict;
    }

    static void Main()
    {
        int[] input = { 1, 2, 6, 9, 1, 1, 9, 6, 1, 9  };

        var result = Count(input);

        foreach (var dicts in result)
        {
            Console.WriteLine($"dic[{dicts.Key}]={dicts.Value}");
        }
    }
}
