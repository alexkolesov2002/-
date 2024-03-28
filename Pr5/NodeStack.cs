namespace Pr5;

public class NodeStack
{
    private Node? top;

    public void Push(int data)
    {
        var newNode = new Node(data);
        newNode.Next = top;
        top = newNode;
    }

    public int Pop()
    {
        if (top == null)
        {
            throw new InvalidOperationException("Стек пуст");
        }

        var data = top.Data;
        top = top.Next;
        return data;
    }

    public int Peek()
    {
        if (top == null)
        {
            throw new InvalidOperationException("Стек пуст");
        }

        return top.Data;
    }

    public int Count()
    {
        var count = 0;
        var current = top;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    public void PrintStack()
    {
        var current = top;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
    }
}