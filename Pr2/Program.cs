namespace Pr1;

internal static class Program
{
    private static void Main()
    {
        Task7();
    }
    private static void Task7()
    {
        var allValues = new ushort[ushort.MaxValue];
        for (ushort i = 0; i < ushort.MaxValue; i++)
        {
            allValues[i] = i;
        }

        var array = new ushort[ushort.MaxValue - 1]; 
        var rand = new Random();
        var missingValueIndex = rand.Next(ushort.MaxValue - 1);
        
        for (var i = 0; i < missingValueIndex; i++)
        {
            array[i] = allValues[i];
        }
        for (var i = missingValueIndex; i < ushort.MaxValue - 1; i++)
        {
            array[i] = allValues[i + 1];
        }

        ulong sum = 0;
        foreach (var num in array)
        {
            sum += num;
        }

        var expectedSum = (ulong)(array.Length + 1) * (ulong)array.Length / 2;
        var missingValue = expectedSum - sum;
        Console.WriteLine($"Недостающее число: {missingValue}");
       
    }
    private static void Task6()
    {
        Console.Write("Введите значение N: ");
        var N = int.Parse(Console.ReadLine());
        Console.Write("Введите значение M: ");
        var M = int.Parse(Console.ReadLine());
        Console.Write("Введите количество единиц K: ");
        var K = int.Parse(Console.ReadLine());

        var A = new int[N, M];
        var rand = new Random();

        for (var i = 0; i < K; i++)
        {
            int x, y;
            do
            {
                x = rand.Next(N);
                y = rand.Next(M);
            } while (A[x, y] == 1);

            A[x, y] = 1;
        }

        Console.WriteLine("Исходный массив:");
        PrintArray(A, true);
        
        Console.WriteLine("Исходный массив:");
        PrintArray(A, false);

        Console.WriteLine("Зеркальное отображение:");
        PrintMirrors(A);
    }
    static void PrintArray(int[,] array, bool isNumbers)
    {
        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
            {
                if (!isNumbers)
                {
                    Console.Write(array[i, j] == 0 ? " " : "*");
                }
                else
                {
                    Console.Write(array[i, j] + " ");
                }
               
            }
            Console.WriteLine();
        }
    }
    static void PrintMirrors(int[,] array)
    {
        var rows = array.GetLength(0);
        var cols = array.GetLength(1);

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] == 0 ? " " : "*");
            }
            Console.Write(" | ");
            for (var j = cols - 1; j >= 0; j--)
            {
                Console.Write(array[i, j] == 0 ? " " : "*");
            }
            Console.WriteLine();
        }

        Console.WriteLine(new string('-', cols * 2 + 3));

        for (var i = rows - 1; i >= 0; i--)
        {
            for (var j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] == 0 ? " " : "*");
            }
            Console.Write(" | ");
            for (var j = cols - 1; j >= 0; j--)
            {
                Console.Write(array[i, j] == 0 ? " " : "*");
            }
            Console.WriteLine();
        }
    }

    
    private static void Task5()
    {
        var B = new int[4, 4];
        var rand = new Random();
        var minDiagonalElement = int.MaxValue;
        var rowWithMinElement = -1;
        var K = 10; 

       
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                B[i, j] = rand.Next(1, 30);
                if (i == j && B[i, j] < minDiagonalElement)
                {
                    minDiagonalElement = B[i, j];
                    rowWithMinElement = i;
                }
            }
        }

        Console.WriteLine("Матрица B(4,4):");
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                Console.Write(B[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Наименьший элемент на главной диагонали: " + minDiagonalElement);

        if (minDiagonalElement < K && rowWithMinElement != -1)
        {
            for (var j = 0; j < 4; j++)
            {
                B[rowWithMinElement, j]++;
            }

            Console.WriteLine("Матрица после увеличения элементов строки: ");
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
    
    private static void Task4()
    {
        var matrix = new int[5, 4];
        var rand = new Random();
        var count = 0;
        
        Console.WriteLine("Исходная матрица:");
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                matrix[i, j] = rand.Next(5, 30);
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        
        var K1 = 10; 
        var K2 = 20;
        
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                if ((K1 <= matrix[i, j] && matrix[i, j] <= K2) || matrix[i, j] > i + j)
                {
                    Console.WriteLine($"{matrix[i,j]}, i;j {i};{j}, {i+j}");
                    count++;
                }
            }
        }
        
        Console.WriteLine($"Количество элементов, удовлетворяющих условию: {count}");
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
                matrix[i, j] = random.Next(-10, 11); 
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
        
        Console.WriteLine("Отрицательные элементы:");
        for (var index = 0; index < numbers.Length; index++)
        {
            var item = numbers[index];
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
            var temp = numbers[i];
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