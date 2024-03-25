using System.Diagnostics;

namespace Pr1;

internal static class Program
{
    private static void Main()
    {
        var stopwatch = new Stopwatch();
        var numbers = InputArray();
        /*OutputArray(numbers);*/
        stopwatch.Start();
        BubbleSort(numbers);
        stopwatch.Stop();
        /*OutputArray(numbers);*/
        Console.WriteLine($"Время выполнения сортировки: {stopwatch.ElapsedMilliseconds} мс");
    }
    
    private static int[] InputArray()
    {
        var numbers = new int[50000];

        var random = new Random();
        for (var i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(0, 100);
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
    
    #region MyRegion
    private static int[] BubbleSort(int[] numbers)
    {
        for (var i = 0; i < numbers.Length - 1; i++)
        {
            for (var j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] > numbers[j])
                {
                    Thread.Sleep(5555);
                    int temp = numbers[i];
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
    
}