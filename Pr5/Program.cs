namespace Pr5;

internal static class Program
{
    private static void Main()
    {
        var stack = new NodeStack();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        stack.PrintStack();

        Console.WriteLine("Достали объект: " + stack.Pop());
        stack.PrintStack();

        Console.WriteLine("Последний объект: " + stack.Peek());
        
        stack.Push(40);
        stack.Push(50);
        stack.Push(60); 
    }
    
    public class Stack
    {
        private int[] array;
        private int top;
        private int capacity;

        public Stack(int size)
        {
            capacity = size;
            array = new int[size];
            top = -1;
        }

        public void Push(int item)
        {
            if (top == capacity - 1)
            {
                Console.WriteLine("Stack overflow (стек переполнен - легендарный сайт)");
                return;
            }
        
            top++;
            array[top] = item;
        }

        public int Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Стек пуст");
                return -1;
            }

            var poppedItem = array[top];
            top--;
            return poppedItem;
        }

        public int Peek()
        {
            if (top == -1)
            {
                Console.WriteLine("Стек пуст");
                return -1;
            }

            return array[top];
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public void PrintStack()
        {
            if (top == -1)
            {
                Console.WriteLine("Стек пуст");
                return;
            }

            Console.Write("Стэк: ");
            for (var i = 0; i <= top; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
    
    class Queue
    {
        private int[] array;
        private int front;
        private int rear;
        private int capacity;
        private int count;

        public Queue(int size)
        {
            capacity = size;
            array = new int[size];
            front = 0;
            rear = -1;
            count = 0;
        }

        public void Enqueue(int item)
        {
            if (count == capacity)
            {
                Console.WriteLine("Очередь переполнена. Невозможно добавить элемент.");
                return;
            }

            rear = (rear + 1) % capacity;
            array[rear] = item;
            count++;
        }

        public int Dequeue()
        {
            if (count == 0)
            {
                Console.WriteLine("Очередь пуста. Невозможно извлечь элемент.");
                return -1;
            }

            var item = array[front];
            front = (front + 1) % capacity;
            count--;
            return item;
        }

        public void DisplayQueue()
        {
            if (count == 0)
            {
                Console.WriteLine("Очередь пуста.");
                return;
            }

            Console.Write("Элементы очереди: ");
            for (var i = 0; i < count; i++)
            {
                Console.Write(array[(front + i) % capacity] + " ");
            }
            Console.WriteLine();
        }
    }
}