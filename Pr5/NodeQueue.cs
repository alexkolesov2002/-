namespace Pr5;

class NodeQueue
{
    private Node? front;
    private Node? rear;

    public NodeQueue()
    {
        front = null;
        rear = null;
    }

    public void Enqueue(int data)
    {
        var newNode = new Node(data);
        if (rear == null)
        {
            front = newNode;
            rear = newNode;
        }
        else
        {
            rear.Next = newNode;
            rear = newNode;
        }
    }

    public int Dequeue()
    {
        if (front == null)
        {
            Console.WriteLine("Очередь пуста");
            return -1;
        }

        var data = front.Data;
        front = front.Next;
        if (front == null)
        {
            rear = null;
        }

        return data;
    }

    public void DisplayQueue()
    {
        var current = front;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }

        Console.WriteLine();
    }
}

class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}