using System;
using System.Collections.Generic;

class Program
{
    public static List<int> RemoveSelectedValue(List<int> input, int selected)
    {
        input.RemoveAll(x => x == selected);
        return input;
    }

    static void Main()
    {
        List<int> input = new List<int> { 1, 2, 4, 1, 9, 1, 6, 1, 5, 6, 8, 7 };

        RemoveSelectedValue(input, 1);

        Console.WriteLine(string.Join(", ", input));
    }
}
