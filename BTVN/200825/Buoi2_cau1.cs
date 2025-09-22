using System;

class Program
{
    
    public static void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        
        for (int i = 1; i < n; i++)
        {
            int j = i;
            
            while (j > 0 && arr[i] < arr[j - 1]) --j;
            
            int tmp = arr[i];
            
            for (int k = i; k > j; k--)
                arr[k] = arr [k - 1];
                
            arr[j] = tmp;
        }
    }

    static void Main()
    {
        int[] input = { 1, 2, 4, 1, 9, 1, 6, 1, 5, 6, 8, 7 };

        InsertionSort(input);

        Console.WriteLine(string.Join(", ", input));
    }
}
