using System;

public class MyQueue<T>
{
    private T[] Values;
    private int Count = 0;

    public void Enqueue(T element)
    {
        if (Values == null)
        {
            Values = new T[1];
            Values[0] = element;
            Count++;
        }
        else
        {
            Array.Resize(ref Values, Count + 1);
            Values[Count] = element;
            Count++;
        }

    }

    public void Dequeue()
    {
        if (Values == null)
        {
            Console.WriteLine("There is no any values in queue");
        }
        else
        {
            Array.Reverse<T>(Values);
            Array.Resize(ref Values, Count - 1);
            Array.Reverse<T>(Values);
            Count--;
        }
    }

    public void Print()
    {
        if (Values != null)
        {
            foreach (T element in Values)
            {
                Console.WriteLine(element);
            }
        }
        else
        {
            Console.WriteLine("There is no any elements in Queue");
        }
    }

    public void Clear()
    {
        Values = null;
        Count = 0;
    }

    public bool IsEmplty()
    {
        if (Count == 0) return true;
        else return false;
    }

    public void Peek()
    {
        if (Values != null)
        {
            Console.WriteLine(Values[0]);
        }
        else
        {
            Console.WriteLine("There is no elements in Queue");
        }
        
    }
}
