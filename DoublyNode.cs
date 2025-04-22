using System;




internal class DoublyNode<T>
{
    public DoublyNode<T> Next { get; set; }
    public DoublyNode<T> Prev { get; set; }
    public T Data { get; set; }

    public DoublyNode(T data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }



}

internal class DoublyLinkedList<T>
{
    private DoublyNode<T> _head;
    private DoublyNode<T> _tail;


    public DoublyNode<T>First { get { return _head; }  }
    public DoublyNode<T>Last { get { return _tail; }  }
    public int Count { get; private set; }
    public void AddFirst(T data)
    {
        DoublyNode<T> newNode = new DoublyNode<T>(data);

        newNode.Prev = null;
        newNode.Next = _head;

        if (_head == null)
            _tail = newNode;

        if (_head != null)
            _head.Prev = newNode;

        _head = newNode;
        Count++;

    }

    public void AddLast(T data)
    {
        DoublyNode<T> newNode = new DoublyNode<T>(data);

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

   

    public bool Remove(T data)
    {
        if (_head == null || _tail == null)
            return false;

        DoublyNode<T> current = _head;
        DoublyNode<T> last = _tail;

        if (current.Data.Equals(data))
        {
            RemoveFirst();
            current=null;
            return true;
        }

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

        return false;

    }

    public bool RemoveFirst()
    {
        if (_head == null)
            return false;
        _head = _head.Next;
        Count--;
        return true;
    }

    public bool RemoveLast()
    {
        if ( _tail ==null )
            return false;


        _tail.Prev.Next = null;
        _tail = _tail.Prev;

        Count--;
        return true;

    }
    public void AddAfter(DoublyNode<T> prev, T data)
    {
        if (prev == null)
            return;

        DoublyNode<T> newNode = new DoublyNode<T>(data);

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

    public DoublyNode<T> Find(T data)
    {

        DoublyNode<T> current = _head;
        while (current != null)
        {
            if (current.Data.Equals(data))
                return current;

            current = current.Next;
        }
        return null;
    }

    public void PrintForward()
    {

        DoublyNode<T> current = _head;
        Console.Write("Null <-> ");

        while (current != null)
        {

            Console.Write($"{current.Data} <-> ");
            current = current.Next;
        }

        Console.WriteLine("Null");
    }
    public void PrintBackward()
    {

        DoublyNode<T> current = _tail;
        Console.Write("Null <-> ");
        while (current != null)
        {

            Console.Write($"{current.Data} <-> ");
            current = current.Prev;
        }

        Console.WriteLine("Null");
    }

    public void Clear()
    {
        while (Count > 0)
            RemoveFirst();
    }

    public bool Contains(T data)
    {
        return Find(data) != null;
    }

    public int IndexOf(T data)
    {
        if(_head.Data.Equals(data))
            return 0;
        if (_tail.Data.Equals(data))
            return Count - 1;

        DoublyNode<T> current = _head;
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

    public DoublyNode<T> GetNode(int index)
    {
        if (index> Count - 1 || index < 0)
            return null;

        
        DoublyNode<T> current = _head;
        while (current.Next != null && current != null)
        {
            if (index == 0)
                break;
            current = current.Next;
            index--;
        }
        return current;
    } 

    public T GetItem(int index)
    {
        DoublyNode<T> node= GetNode(index);
        if (node == null)
            return default;
        else
            return node.Data;
    }

    public bool UpdateItem(int index, T NewData)
    {
        DoublyNode<T>node= GetNode(index);
        if(node!=null)
        {
            node.Data = NewData;
            return true;
        }
        return false;
    }
    public void Reverse()
    {

        // Store the previous pointer before we change it
        DoublyNode<T> current = _head;
        DoublyNode<T> temp = null;

        // Save the original head to become the new tail
        DoublyNode<T> oldHead = _head;

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
}

