using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {

        // Run all tests
        TestBasicOperations();
        TestAddOperations();
        TestRemoveOperations();
        TestFindOperations();
        TestIndexOperations();
        TestSpecialOperations();
        TestCollectionInterface();
        TestEdgeCases();
        TestPerformance();

        Console.WriteLine("\nAll tests completed.");

        Console.ReadKey();
    }
    static void TestBasicOperations()
    {
        Console.WriteLine("--- Testing Basic Operations ---");

        var list = new DoublyLinkedList<int>();

        // Test initial state
        Console.WriteLine($"New list count: {list.Count} (Expected: 0)");
        Console.WriteLine($"IsReadOnly: {list.IsReadOnly} (Expected: False)");

        // Test Add
        list.Add(10);
        list.Add(20);
        list.Add(30);

        Console.WriteLine($"After adding 3 items, count: {list.Count} (Expected: 3)");
        Console.Write("Forward traversal: ");
        list.PrintForward();

        // Test Clear
        list.Clear();
        Console.WriteLine($"After Clear, count: {list.Count} (Expected: 0)");

        Console.WriteLine("Basic operations test completed.");
        Console.WriteLine();
    }

    static void TestAddOperations()
    {
        Console.WriteLine("--- Testing Add Operations ---");

        var list = new DoublyLinkedList<string>();

        // Test AddFirst
        list.AddFirst("World");
        list.AddFirst("Hello");
        Console.Write("After AddFirst operations: ");
        list.PrintForward();

        // Test AddLast
        list.Add("!");
        Console.Write("After AddLast: ");
        list.PrintForward();

        // Test AddAfter
        var node = list.Find("World");
        list.AddAfter(node, "Beautiful");
        Console.Write("After AddAfter 'World': ");
        list.PrintForward();

        // Test AddBefore
        node = list.Find("!");
        list.AddBefore(node, "Amazing");
        Console.Write("After AddBefore '!': ");
        list.PrintForward();

        Console.WriteLine("Add operations test completed.");
        Console.WriteLine();
    }

    static void TestRemoveOperations()
    {
        Console.WriteLine("--- Testing Remove Operations ---");

        var list = new DoublyLinkedList<int>();
        for (int i = 1; i <= 5; i++)
        {
            list.Add(i);
        }

        Console.Write("Initial list: ");
        list.PrintForward();

        // Test RemoveFirst
        list.RemoveFirst();
        Console.Write("After RemoveFirst: ");
        list.PrintForward();

        // Test RemoveLast
        list.RemoveLast();
        Console.Write("After RemoveLast: ");
        list.PrintForward();

        // Test Remove by value
        bool removed = list.Remove(3);
        Console.Write($"After Remove(3) - {removed}: ");
        list.PrintForward();

        // Test Remove by node
        var node = list.Find(2);
        list.Remove(node.Data);
        Console.Write("After Remove(node) where node.Data = 2: ");
        list.PrintForward();

        Console.WriteLine("Remove operations test completed.");
        Console.WriteLine();
    }

    static void TestFindOperations()
    {
        Console.WriteLine("--- Testing Find Operations ---");

        var list = new DoublyLinkedList<string>();
        string[] words = { "apple", "banana", "cherry", "date", "elderberry", "banana" };

        foreach (var word in words)
        {
            list.Add(word);
        }

        Console.Write("List: ");
        list.PrintForward();

        // Test Find
        var node = list.Find("banana");
        Console.WriteLine($"Find('banana') - Found: {node != null}, Value: {(node != null ? node.Data : "null")}");

        // Test FindLast
        node = list.FindLast("banana");
        Console.WriteLine($"FindLast('banana') - Found: {node != null}, Index: {list.IndexOf(node.Data)}");

        // Test Contains
        bool contains = list.Contains("date");
        Console.WriteLine($"Contains('date'): {contains} (Expected: True)");

        contains = list.Contains("fig");
        Console.WriteLine($"Contains('fig'): {contains} (Expected: False)");

        Console.WriteLine("Find operations test completed.");
        Console.WriteLine();
    }

    static void TestIndexOperations()
    {
        Console.WriteLine("--- Testing Index Operations ---");

        var list = new DoublyLinkedList<char>();
        char[] chars = { 'A', 'B', 'C', 'D', 'E' };

        foreach (var c in chars)
        {
            list.Add(c);
        }

        Console.Write("List: ");
        list.PrintForward();

        // Test IndexOf
        int index = list.IndexOf('C');
        Console.WriteLine($"IndexOf('C'): {index} (Expected: 2)");

        // Test GetNode
        var node = list.GetNode(3);
        Console.WriteLine($"GetNode(3).Data: {(node != null ? node.Data : 'X')} (Expected: D)");

        // Test GetItem
        char item = list.GetItem(1);
        Console.WriteLine($"GetItem(1): {item} (Expected: B)");

        // Test UpdateItem
        bool updated = list.UpdateItem(4, 'Z');
        Console.WriteLine($"UpdateItem(4, 'Z') success: {updated}");
        Console.Write("After update: ");
        list.PrintForward();

        Console.WriteLine("Index operations test completed.");
        Console.WriteLine();
    }

    static void TestSpecialOperations()
    {
        Console.WriteLine("--- Testing Special Operations ---");

        var list = new DoublyLinkedList<int>();
        for (int i = 1; i <= 5; i++)
        {
            list.Add(i);
        }

        Console.Write("Original list: ");
        list.PrintForward();

        // Test Reverse
        list.Reverse();
        Console.Write("After Reverse: ");
        list.PrintForward();
        Console.Write("Backward traversal: ");
        list.PrintBackward();

        Console.WriteLine("Special operations test completed.");
        Console.WriteLine();
    }

    static void TestCollectionInterface()
    {
        Console.WriteLine("--- Testing ICollection<T> Interface ---");

        // Create and populate the list
        DoublyLinkedList<int> list = new DoublyLinkedList<int>();
        for (int i = 0; i < 5; i++)
        {
            list.Add(i * 10);
        }

        Console.Write("List: ");
        list.PrintForward();

        // Test ICollection methods
        Console.WriteLine($"Count: {list.Count}");

        // Test enumeration
        Console.Write("Enumeration: ");
        foreach (int item in list)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();

        // Test CopyTo
        int[] array = new int[list.Count];
        list.CopyTo(array, 0);

        Console.Write("CopyTo array: ");
        foreach (int item in array)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();

        // Test LINQ compatibility
        Console.WriteLine($"LINQ Sum: {list.Sum()} (Expected: 100)");
        Console.WriteLine($"LINQ Where Count: {list.Where(x => x > 20).Count()} (Expected: 3)");

        Console.WriteLine("ICollection<T> interface test completed.");
        Console.WriteLine();
    }

    static void TestEdgeCases()
    {
        Console.WriteLine("--- Testing Edge Cases ---");

        var list = new DoublyLinkedList<int>();

        // Empty list operations
        Console.WriteLine($"Empty list count: {list.Count}");
        Console.WriteLine($"Empty list First: {(list.First == null ? "null" : list.First.Data.ToString())}");
        Console.WriteLine($"Empty list Last: {(list.Last == null ? "null" : list.Last.Data.ToString())}");

        // Operations on empty list
        bool removed = list.RemoveFirst();
        Console.WriteLine($"RemoveFirst on empty list: {removed} (Expected: False)");

        removed = list.RemoveLast();
        Console.WriteLine($"RemoveLast on empty list: {removed} (Expected: False)");

        int notFound = list.IndexOf(100);
        Console.WriteLine($"IndexOf on empty list: {notFound} (Expected: -1)");

        // Single item tests
        list.Add(999);
        Console.WriteLine($"Single item list count: {list.Count}");
        Console.WriteLine($"Single item First.Data: {list.First.Data}");
        Console.WriteLine($"Single item Last.Data: {list.Last.Data}");

        // Test removing the only item
        removed = list.Remove(999);
        Console.WriteLine($"Remove single item: {removed} (Expected: True)");
        Console.WriteLine($"Count after removal: {list.Count} (Expected: 0)");

        Console.WriteLine("Edge cases test completed.");
        Console.WriteLine();
    }

    //static void TestPerformance()
    //{
    //    Console.WriteLine("--- Testing Performance (Simple) ---");

    //    var list = new DoublyLinkedList<int>();
    //    int testSize = 10000;

    //    // Test adding many elements
    //    var sw = System.Diagnostics.Stopwatch.StartNew();

    //    for (int i = 0; i < testSize; i++)
    //    {
    //        list.Add(i);
    //    }

    //    sw.Stop();
    //    Console.WriteLine($"Adding {testSize} items: {sw.ElapsedMilliseconds}ms");

    //    // Test finding elements
    //    sw.Restart();
    //    var node = list.Find(testSize / 2);
    //    sw.Stop();
    //    Console.WriteLine($"Finding middle item: {sw.ElapsedMilliseconds}ms");

    //    // Test iterating
    //    sw.Restart();
    //    int sum = 0;
    //    foreach (var item in list)
    //    {
    //        sum += item;
    //    }
    //    sw.Stop();
    //    Console.WriteLine($"Iterating through {testSize} items: {sw.ElapsedMilliseconds}ms");

    //    // Test clearing
    //    sw.Restart();
    //    list.Clear();
    //    sw.Stop();
    //    Console.WriteLine($"Clearing {testSize} items: {sw.ElapsedMilliseconds}ms");

    //    Console.WriteLine("Performance test completed.");
    //    Console.WriteLine();
    ////}
    static void TestPerformance()
    {
        Console.WriteLine("--- Testing Performance (Improved) ---");

        int testSize = 1000000; // Increase to 1 million items

        var sw = System.Diagnostics.Stopwatch.StartNew();
        var list = new DoublyLinkedList<int>();

        // Test adding many elements
        for (int i = 0; i < testSize; i++)
        {
            list.Add(i);
        }

        sw.Stop();
        Console.WriteLine($"Adding {testSize} items: {sw.ElapsedMilliseconds}ms, {sw.ElapsedTicks} ticks");

        // Test finding elements with multiple searches
        sw.Restart();
        for (int i = 0; i < 1000; i++)
        {
            var randomIndex = new Random().Next(testSize);
            var node = list.Find(randomIndex);
        }
        sw.Stop();
        Console.WriteLine($"1000 random find operations: {sw.ElapsedMilliseconds}ms, {sw.ElapsedTicks} ticks");

        // Test accessing by index
        sw.Restart();
        for (int i = 0; i < 1000; i++)
        {
            var randomIndex = new Random().Next(list.Count);
            var item = list.GetItem(randomIndex);
        }
        sw.Stop();
        Console.WriteLine($"1000 random index accesses: {sw.ElapsedMilliseconds}ms, {sw.ElapsedTicks} ticks");

        // Test iteration
        sw.Restart();
        int sum = 0;
        foreach (var item in list)
        {
            sum += item;
        }
        sw.Stop();
        Console.WriteLine($"Iterating through {testSize} items: {sw.ElapsedMilliseconds}ms, {sw.ElapsedTicks} ticks");

        // Compare with List<T> for reference
        sw.Restart();
        var systemList = new List<int>(testSize);
        for (int i = 0; i < testSize; i++)
        {
            systemList.Add(i);
        }
        sw.Stop();
        Console.WriteLine($"Adding {testSize} items to List<T>: {sw.ElapsedMilliseconds}ms, {sw.ElapsedTicks} ticks");

        // Test clearing
        sw.Restart();
        list.Clear();
        sw.Stop();
        Console.WriteLine($"Clearing {testSize} items: {sw.ElapsedMilliseconds}ms, {sw.ElapsedTicks} ticks");

        Console.WriteLine("Performance test completed.");
        Console.WriteLine();
    }
}

