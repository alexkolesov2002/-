using System.Diagnostics;

namespace Pr3;

internal static class Program
{
    private static void Main()
    {
        var stopwatch = new Stopwatch();
        var numbers = InputArray(100000);
        /*OutputArray(numbers);*/
        stopwatch.Start();
        ShakerSort(numbers);
        stopwatch.Stop();
        /*OutputArray(numbers);*/
        Console.WriteLine($"Время выполнения сортировки: {stopwatch.ElapsedMilliseconds} мс");
    }
    
    #region ShakerSort

    private static int[] ShakerSort(int[] numbers)
    {
        for (var i = 0; i < numbers.Length / 2; i++)
        {
            var swapFlag = false;
           
            for (var j = i; j < numbers.Length - i - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    Swap(ref numbers[j], ref numbers[j + 1]);
                    swapFlag = true;
                }
            }
            
            for (var j = numbers.Length - 2 - i; j > i; j--)
            {
                if (numbers[j - 1] > numbers[j])
                {
                    Swap(ref numbers[j - 1], ref numbers[j]);
                    swapFlag = true;
                }
            }
            
            if (!swapFlag)
            {
                break;
            }
        }

        return numbers;
    }

    static void Swap(ref int number1, ref int number2)
    {
        var temp = number1;
        number1 = number2;
        number2 = temp;
    }
    #endregion
    
    
    #region SelectionSort

    private static int[] SelectionSort(int[] numbers)
    {
        for (var i = 0; i < numbers.Length - 1; i++)
        {
            var min=i;
            for (var j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] < numbers[min])
                {
                    min = j;
                }
            }
            
            var temp = numbers[min];
            numbers[min] = numbers[i];
            numbers[i] = temp;
        }
        return numbers;
    }

    #endregion
    
    #region InsertionSort

    private static int[] InsertionSort(int[] numbers)
    {
        for (var i = 1; i < numbers.Length; i++)
        {
            var val = numbers[i];
            for (var j = i - 1; j >= 0;)
            {
                if (val < numbers[j])
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                    numbers[j + 1] = val;
                }
                else
                {
                    break;
                }
            }
        }
        return numbers;
    }

    #endregion


    #region BubbleSort

    private static int[] BubbleSort(int[] numbers)
    {
        for (var i = 0; i < numbers.Length - 1; i++)
        {
            for (var j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] > numbers[j])
                {
                    Thread.Sleep(2000);
                    var temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                    DrawArray(numbers);
                }
            }
        }

        return numbers;
    }

    private static void DrawArray(int[] numbers)
    {
        Console.Clear();
        for (var i = 0; i < numbers.Length; i++)
        {
            WriteColoredText(numbers[i] + " ", ConsoleColor.Green);

            for (var j = 0; j < numbers[i]; j++)
            {
                WriteColoredText("*");
            }

            Console.WriteLine();
        }
    }

    private static void WriteColoredText(string text, ConsoleColor color = ConsoleColor.Yellow)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    #endregion

    
    private static int[] InputArray(int length = 100)
    {
        var numbers = new int[length];

        var random = new Random();
        for (var i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(0, length);
        }

        return numbers;
    }

    private static void OutputArray(int[] numbers)
    {
        Console.WriteLine("Массив:");
        for (var i = 0; i < numbers.Length; i++)
        {
            var number = numbers[i];
            Console.Write(number + " ");
        }
    }
}