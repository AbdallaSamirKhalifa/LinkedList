using System;
using System.Collections.Generic;
using System.Dynamic;

internal class Program
{
    static void Main(string[] args)
    {


        DoublyLinkedList<int> list = new DoublyLinkedList<int>();

        list.AddLast(1);
        list.AddLast(2);
        //list.AddLast(3);
        list.AddFirst(0);

        Console.WriteLine("Forward traversal:");
        list.PrintForward();
        Console.WriteLine(list.Count);
        Console.WriteLine("\n\nBackward traversal:");
        list.PrintBackward();
        Console.WriteLine(list.Count);

        //list.AddAfter(list.Last, 500);

        Console.WriteLine("\n\nAfter inserting:");
        list.PrintForward();
        list.Reverse();

        list.PrintForward();

        Console.ReadKey();
    }
}

