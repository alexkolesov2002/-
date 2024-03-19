namespace Pr1;

internal static class Program
{
    private static void Main()
    {
        Task2();
    }


    private static void Task1()
    {
        var numbers = InputArray();

        var hasDuplicates = false;
        for (var i = 0; i < numbers.Length; i++)
        {
            for (var j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    hasDuplicates = true;
                    break;
                }
            }

            if (hasDuplicates)
            {
                break;
            }
        }

        Console.WriteLine(hasDuplicates
            ? "Среди введенных чисел есть одинаковые."
            : "Среди введенных чисел нет одинаковых.");
    }

    private static void Task2()
    {
        var numbers = InputArray();

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

        var thirdLargest = 0;
        var hasThirdNumber = false;
        if (numbers[0] == numbers[1] && numbers[1] == numbers[2])
        {
            hasThirdNumber = false;
        }
        else
        {
            if (numbers[0] != numbers[1] && numbers[1] != numbers[2])
            {
                thirdLargest = numbers[2];
                hasThirdNumber = true;
            }
            else if (numbers[1] != numbers[2] && numbers[2] != numbers[3])
            {
                thirdLargest = numbers[2];
                hasThirdNumber = true;
            }
            else if (numbers[1] == numbers[2] && numbers[2] != numbers[3])
            {
                thirdLargest = numbers[3];
                hasThirdNumber = true;
            }
        }

        Console.WriteLine(hasThirdNumber
            ? $"Третье по величине число: {thirdLargest}"
            : "Третье по величине число не существует.");
    }


    private static int[] InputArray()
    {
        var numbers = new int[4];

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

        return numbers;
    }
}