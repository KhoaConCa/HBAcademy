using System;
using System.Collections.Generic;

class Program
{
    public static int[] UniqueRandom(int n)
    {
        Random rand = new();
        HashSet<int> unique = new();
        
        while (unique.Count < n)
        {
            int number = rand.Next(1, n + 1);
            unique.Add(number);
        }
        
        int[] arr = new int[n];
        unique.CopyTo(arr);
        return arr;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        
        int[] result = UniqueRandom(n);
        
        Console.WriteLine(string.Join(", ", result));
    }
}
