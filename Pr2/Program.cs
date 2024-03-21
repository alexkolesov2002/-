namespace Pr1;

internal static class Program
{
    private static void Main()
    {
        Task3();
    }
    
    private static void Task3()
    {
        var matrix = new int[3, 4];
        var random = new Random();
        var count = 0;

      
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                matrix[i, j] = random.Next(-10, 11); // Генерируем числа от -10 до 10
            }
        }

     
        Console.WriteLine("Исходная матрица:");
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        for (var j = 0; j < 4; j++)
        {
            if (matrix[2, j] > -2 && matrix[2, j] < 2)
            {
                count++;
            }
        }

        Console.WriteLine($"Количество чисел больше -2, но меньше 2 в третьей строке: {count}");
    }
    private static void Task2()
    {
        var  numbers = new int[16];
        var random = new Random();
        
        for (var i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(-50, 51); 
        }

       
        Console.WriteLine("Исходный массив:");
        for (var i = 0; i < numbers.Length; i++)
        {
            var item = numbers[i];
            Console.Write(item + " ");
        }

        Console.WriteLine();
        
        Console.WriteLine("Положительные элементы:");
        for (var i = 0; i < numbers.Length; i++)
        {
            var item = numbers[i];
            if (item > 0)
            {
                Console.Write(item + " ");
            }
        }

        Console.WriteLine();

        // Выводим отрицательные элементы
        Console.WriteLine("Отрицательные элементы:");
        foreach (var item in numbers)
        {
            if (item < 0)
            {
                Console.Write(item + " ");
            }
        }
        Console.WriteLine();
    }
    
    private static void Task1()
    {
        var numbers = InputArray();
        
        var length = numbers.Length;
        for (var i = 0; i < length / 2; i++)
        {
            int temp = numbers[i];
            numbers[i] = numbers[length - i - 1];
            numbers[length - i - 1] = temp;
        }
        
        Console.WriteLine("Реверсированный массив:");
        for (var i = 0; i < numbers.Length; i++)
        {
            var item = numbers[i];
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }
    
    
    private static int[] InputArray(bool isRandom = false)
    {
        var numbers = new int[4];
        if (!isRandom)
        {
            for (var i = 0; i < 4; i++)
            {
                var validInput = false;
                while (!validInput)
                {
                    Console.Write($"Введите {i + 1}-е число: ");
                    var input = Console.ReadLine();
                    validInput = int.TryParse(input, out numbers[i]);

                    if (!validInput)
                    {
                        Console.WriteLine("Ошибка! Введите целое число.");
                    }
                }
            }
        }
        else
        {
            var random = new Random();
            for (var i = 0; i < 4; i++)
            {
                numbers[i] = random.Next(-100, 100);
            }
        }

        Console.WriteLine("Исходный массив");
        for (var i = 0; i < 4; i++)
        {
            Console.Write($"{numbers[i]};  ");
        }

        return numbers;
    }
}