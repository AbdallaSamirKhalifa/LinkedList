using System;




internal class Node<T>
{
    public Node<T> Next {  get; set; }
    public T Data { get; set; }
    
    public Node(T data)
    {
        Data = data;
        Next = null;
    }



}

internal class SinglyLinkedList<T>
{
    private Node<T> _head;

    public int Count { get; private set; }
    public void AddFirst(T data)
    {
        Node<T> newNode = new Node<T>(data);
        newNode.Next = _head;
        _head = newNode;
        Count++;
    }

    public void AddLast(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if(_head == null)
        {
            _head = newNode;
            Count++;
            return;
        }

        Node<T> current = _head;
        while(current.Next != null)
        {
            current = current.Next;


        }
        current.Next = newNode;
        Count++;
    }

    public void AddLastOptimized(T data)
    {
        if (_head.Next == null)
        {
            AddAfter(_head, data);

            return;
        }

        Node<T> current = _head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        AddAfter(current, data);
    }

    public bool Remove(T data)
    {
        if (_head == null)
            return false;

        Node<T> current=_head ,prev = _head;
        if (current.Data.Equals(data))
        {
            current = current.Next;
            Count--;
            return true;
        }

        while(current != null)
        {
            if (current.Data.Equals(data))
            {
                prev.Next = current.Next;
                Count--;
                return true;

            }
            prev = current;
            current = current.Next;
        }

        return false; 

    }

    public bool RemoveFirst()
    {
        if(_head == null)
            return false;
        _head= _head.Next;
        Count--;
        return true;
    }

    public bool RemoveLast()
    {
        if (_head == null)
            return false;

        Node<T> lastNode = _head, prev = _head;

        while(lastNode.Next!=null)
        {
            prev = lastNode;
            lastNode = lastNode.Next;
        }
        prev.Next = null;
        Count--;
        return true;

    }
    public void AddAfter(Node<T> prev,T data)
    {
        if(prev == null)
            return;

        Node<T> newNode = new Node<T>(data);

        newNode.Next = prev.Next;
        prev.Next = newNode;
        Count++;
        
    }

    public Node<T> Find(T data)
    {

        Node<T> current = _head;
        while(current != null)
        {
            if(current.Data.Equals(data))
                return current;

            current = current.Next;
        }
        return null;
    }

    public void PrintList()
    {

        Node<T> current = _head;
        while (current != null)
        {
            
            Console.Write($"{current.Data} -> ");
            current=current.Next;
        }

        Console.Write("Null");
    }


}

