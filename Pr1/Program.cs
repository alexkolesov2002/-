namespace Pr1;

internal static class Program
{
    private static void Main()
    {
        Task3();
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

    private static void Task3()
    {
        var numbers = InputArray(true);

        var max = numbers[0];
        var min = numbers[0];
        var countMax = 1;
        var countMin = 1;

        for (var i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
                countMax = 1;
            }
            else if (numbers[i] == max)
            {
                countMax++;
            }

            if (numbers[i] < min)
            {
                min = numbers[i];
                countMin = 1;
            }
            else if (numbers[i] == min)
            {
                countMin++;
            }
        }
        Console.WriteLine($"Максимальное число: {max}, количество максимальных чисел: {countMax}");
        Console.WriteLine($"Минимальное число: {min}, количество минимальных чисел: {countMin}");
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
                numbers[i] = random.Next(-100,100);
            }
        }

        Console.WriteLine("Исходный массив /n");
        for (var i = 0; i < 4; i++)
        {
            Console.Write($"{numbers[i]};  ");
        }

        return numbers;
    }
}