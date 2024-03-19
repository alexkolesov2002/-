namespace Pr1;

internal static class Program
{
    private static void Main()
    {
        Task1();
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