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


    private static int[] BubbleSort(int[] numbers)
    {
        for (var i = 0; i < numbers.Length - 1; i++)
        {
            for (var j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] > numbers[j])
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                }
                
            }
        }

        return numbers;
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
}