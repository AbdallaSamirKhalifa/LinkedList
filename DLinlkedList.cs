using System;
using System.Collections.Generic;
using System.Collections;






internal class DoublyLinkedList<T>:ICollection<T>
{

    internal class Node
    {
        public Node Next { get; set; }
        public Node Prev { get; set; }
        public T Data { get; set; }

        internal Node(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }



    }
    private Node _head;
    private Node _tail;


    public Node First => _head;
    public Node Last => _tail;
    public int Count { get; private set; }
    public bool IsReadOnly => false;

    /// <summary>
    /// Adds an element at the beginning of the linked list
    /// </summary>
    /// <param name="data">The data of the node</param>
    public void AddFirst(T data)
    {
        Node newNode = new Node (data);

        newNode.Prev = null;
        newNode.Next = _head;

        if (_head == null)
            _tail = newNode;

        if (_head != null)
            _head.Prev = newNode;

        _head = newNode;
        Count++;

    }

    private void _AddLast(T data)
    {
        Node newNode = new Node (data);

        if(_tail == null)
        {
            _head = newNode;
            _tail = newNode;
            Count++;
            return;
        }
        _tail.Next = newNode;
        newNode.Prev= _tail;
        _tail = newNode;
        Count++;
    }

    public void AddBefore(Node node,T data)
    {
        if (_head == null || _tail == null)
            return;

        if(node == _head)
        {
            AddFirst(data);
        }

        Node newNode = new Node(data);
        newNode.Prev = node.Prev;
        newNode.Next = node;
        node.Prev.Next = newNode;
        node.Prev = newNode;

        Count++;

    }

    /// <summary>
    /// Adds an item to the end of the linked list
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
        _AddLast(item);
    }

    /// <summary>
    /// Reomves the First node that contains the Specified data
    /// </summary>
    /// <param name="data">The data</param>
    /// <returns>True if removed successfully</returns>
    public bool Remove(T data)
    {
        if (_head == null || _tail == null)
            return false;

        Node current = _head;

        if (current.Data.Equals(data))
        {
            RemoveFirst();
            current=null;
            return true;
        }
        Node last = _tail;

        if (last.Data.Equals(data))
        {
            RemoveLast();
            last = null;
            return true;
        }

        while (current.Next != null && !current.Data.Equals(data))
        { 
            current = current.Next;
        }

        if (!current.Data.Equals(data))
            return false;

        current.Prev.Next = current.Next;
        current.Next.Prev = current.Prev;
        current = null;
        Count--;

        return true;

    }



    /// <summary>
    /// Removes the First element in the linked list
    /// </summary>
    /// <returns>True if removed successfully</returns>
    public bool RemoveFirst()
    {
        if (_head == null)
            return false;
        _head = _head.Next;
        if (_head != null)
            _head.Prev = null;
        Count--;
        return true;
    }
    /// <summary>
    /// Removes the last element in the linked list
    /// </summary>
    /// <returns>True if removed successfully</returns>
    public bool RemoveLast()
    {
        if ( _tail ==null )
            return false;


        _tail.Prev.Next = null;
        _tail = _tail.Prev;

        Count--;
        return true;

    }

    /// <summary>
    /// Removes the last node with the specified value
    /// </summary>
    /// <param name="data"></param>
    /// <returns>True if removed successfully</returns>
    public bool RemoveLast(T data)
    {

        if (_tail==null||_head==null)
            return false;

        if(Count < 2)
        {
            Clear();
            return true;
        }

        if(_tail.Data.Equals(data))
        {
            _tail = _tail.Prev;
            _tail.Next = null;
            return true;
        }


        Node node=FindLast(data);
        if (node == null)
            return false;

        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
        return true;
        
    }

    /// <summary>
    /// Adds new node after a specified node.
    /// </summary>
    /// <param name="prev">The node specified node</param>
    /// <param name="data">The data of the new node</param>
    public void AddAfter(Node prev, T data)
    {
        if (prev == null)
            return;

        Node newNode = new Node(data);

        newNode.Next = prev.Next;
        newNode.Prev = prev;


        if (prev.Next != null)
        {
            prev.Next.Prev = newNode;
        }
        prev.Next = newNode;
        Count++;

        if(prev==_tail)
            _tail = newNode;

    }

    /// <summary>
    /// Finds the first node with the specified data
    /// </summary>
    /// <param name="data">Specified data</param>
    /// <returns>Returns the node that contains the data if exists</returns>
    public Node Find(T data)
    {

        Node current = _head;
        while (current != null)
        {
            if (current.Data.Equals(data))
                return current;

            current = current.Next;
        }
        return null;
    }

    /// <summary>
    /// Finds the last node with the specified data
    /// </summary>
    /// <param name="data">Specified data</param>
    /// <returns>Returns the node that contains the data if exists</returns>
    public Node FindLast(T data)
    {

        Node current = _tail;
        while (current != null)
        {
            if (current.Data.Equals(data))
                return current;

            current = current.Prev;
        }
        return null;
    }

    /// <summary>
    /// Prints the linked list elements from head to tail
    /// </summary>
    public void PrintForward()
    {

        Node current = _head;
        Console.Write("Null <-> ");

        while (current != null)
        {

            Console.Write($"{current.Data} <-> ");
            current = current.Next;
        }

        Console.WriteLine("Null");
    }

    /// <summary>
    /// Prints the linked list elements from tail to head
    /// </summary>
    public void PrintBackward()
    {

        Node current = _tail;
        Console.Write("Null <-> ");
        while (current != null)
        {

            Console.Write($"{current.Data} <-> ");
            current = current.Prev;
        }

        Console.WriteLine("Null");
    }

    
    /// <summary>
    /// The Standard clear (Sets the head and tail to null and resets the count to 0)
    /// 
    /// </summary>
    public void Clear()
    {
        _head = null;
        _tail = null;
        Count = 0;
    }

    /// <summary>
    /// Checks for specific element in the linked list.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public bool Contains(T data)
    {
        return Find(data) != null;
    }

    /// <summary>
    /// Returns the index for sepecific element in the linked list
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public int IndexOf(T data)
    {
        if(_head==null||_tail==null)
            return -1;

        if(_head.Data.Equals(data))
            return 0;
        if (_tail.Data.Equals(data))
            return Count - 1;

        Node current = _head;
        int index = 0;



        while (current != null)
        {
            if (current.Data.Equals(data))
                return index;
            index++;
            current = current.Next;
        }
        return -1;
    }

    /// <summary>
    /// Index based accessing for the linked list nodes.    
    /// </summary>
    /// <param name="index"></param>
    /// <returns>The full node of the specified index</returns>
    public Node GetNode(int index)
    {
          
          if (index >= Count || index < 0)
            return null;

        Node current;

        if (index >= Count / 2)
        {
            int stepsFromEnd = Count - 1 - index;
            current = _tail;

            for (int i = 0; i < stepsFromEnd; i++)
            {
                current = current.Prev;
            }
        }
        else
        {
            current = _head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
        }

        return current;
    }

    /// <summary>
    /// Index based accessing for the linked list items.
    /// </summary>
    /// <param name="index"></param>
    /// <returns>The item of the node at the specified index if found</returns>
    public T GetItem(int index)
    {
        Node node= GetNode(index);
        if (node == null)
            return default;
        else
            return node.Data;
    }

    /// <summary>
    /// Updates the item at the specified index
    /// </summary>
    /// <param name="index">Index of the item that needs to be updated</param>
    /// <param name="NewData">The new data</param>
    /// <returns></returns>
    public bool UpdateItem(int index, T NewData)
    {
        Node node= GetNode(index);
        if(node!=null)
        {
            node.Data = NewData;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Reverses the elements of the linked list
    /// </summary>
    public void Reverse()
    {

        // Store the previous pointer before we change it
        Node current = _head;
        Node temp = null;

        // Save the original head to become the new tail
        Node oldHead = _head;

        while (current != null)
        {
                temp = current.Prev;

            // Swap the previous and next pointers
            current.Prev = current.Next;
            current.Next = temp;

            // Move to the next node (which is now current.Prev after swapping)
            current = current.Prev;
         }

        // Update head and tail pointers
        _tail = oldHead;
    
        // The new head is the last node we processed (temp.Prev before the swap)
        if (temp != null)
            _head = temp.Prev;
        

    }

    public IEnumerator<T> GetEnumerator()
    {
        Node Current = _head;
        while (Current != null)
        {
            yield return Current.Data;
            Current = Current.Next;
        }
    }

  
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    /// <summary>
    /// Copies the elements the linked list to the array
    /// </summary>
    /// <param name="array">Array to copy the data to </param>
    /// <param name="index">Index of which to start to add the elements from</param>
    public void CopyTo(T[] array, int index)
    {
        if (array == null)
            return;

        Node Current = _head;

        while (Current != null)
        {
            array[index] = Current.Data;
            Current=Current.Next;
            index++;
        }
    }

}

