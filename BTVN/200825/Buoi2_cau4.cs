using System;
using System.Collections.Generic;

class Program
{
    public enum Movement
    {
        Forward,
        Back,
        Left,
        Right
    }

    static void Main()
    {
        string input = Console.ReadLine();
        
        if (Enum.TryParse(input, true, out Movement move))
        {
            switch (move)
            {
            case Movement.Forward:
                Console.WriteLine("Trước");
                break;
            case Movement.Back:
                Console.WriteLine("Sau");
                break;
            case Movement.Left:
                Console.WriteLine("Trái");
                break;
            case Movement.Right:
                Console.WriteLine("Phải");
                break;
            }   
        }
        else
        {
            Console.WriteLine("Giá trị không hợp lệ!");
        }
    }
}
