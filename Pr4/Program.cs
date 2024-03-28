using System.Diagnostics;

namespace Pr4;

internal static class Program
{
    private static void Main()
    {
        /*var numbers = InputArray(10);
        OutputArray(numbers);
        Search(numbers, 7);*/

        var text = "А можно я с тобой";
        var substring = "тобой";

        Console.WriteLine(SearchSubstring(text, substring)
            ? $"Подстрока \"{substring}\" найдена в строке {text}."
            : $"Подстрока \"{substring}\" не найдена в строке {text}.");
    }


    static bool SearchSubstring(string str, string sub)
    {
        for (var i = 0; i <= str.Length - sub.Length; i++)
        {
            int j;
            for (j = 0; j < sub.Length; j++)
            {
                if (str[i + j] != sub[j])
                {
                    break;
                }
            }

            if (j == sub.Length)
            {
                return true;
            }
        }

        return false;
    }

    private static void Search(int[] numbers, int target)
    {
        var indexes = new List<int>();
        for (var i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == target)
            {
                indexes.Add(i);
            }
        }

        if (indexes.Count > 0)
        {
            Console.Write($"Число {target} распологается на \n");
            foreach (var index in indexes)
            {
                Console.WriteLine($"{index}; ");
            }

            Console.WriteLine($"позициях");
        }
        else
        {
            Console.Write($"Число {target} не найдено в массиве");
        }
    }


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