using System;

public class MyQueue<T>
{
	private T[] Values;
	private int Count;

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
			Array.Resize(ref Values, count);
            Values[Count-1] = element;
		}
		
	}

	public void Dequeue(T element) 
	{
		//element = Values.First
		
	}

}
