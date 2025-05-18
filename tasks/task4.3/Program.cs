using System;

class Program
{
    static void ReverseArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n / 2; i++)
        {
            int temp = arr[i];
            arr[i] = arr[n - 1 - i];
            arr[n - 1 - i] = temp;
        }
    }

    static void PrintArray(int[] arr, string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("[" + string.Join(", ", arr) + "]");
    }

    static void RunTests()
    {
        void Test(int[] input, int[] expected, string testName)
        {
            Console.WriteLine($"--- Тест: {testName} ---");
            Console.WriteLine("До: [" + string.Join(", ", input) + "]");

            ReverseArray(input);

            bool passed = true;
            for (int i = 0; i < expected.Length; i++)
            {
                if (i >= input.Length || input[i] != expected[i])
                {
                    passed = false;
                    break;
                }
            }

            Console.WriteLine("После: [" + string.Join(", ", input) + "]");
            Console.WriteLine(passed ? "✅ Прошёл" : $"❌ Не прошёл → Ожидалось: [{string.Join(", ", expected)}]");
        }

        Console.WriteLine("=== ТЕСТЫ для тестов ^-^ ===");

        Test(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 }, "Нечётная длина");
        Test(new int[] { 10, 20, 30, 40 }, new int[] { 40, 30, 20, 10 }, "Чётная длина");
        Test(new int[] { 1 }, new int[] { 1 }, "Один элемент");
        Test(new int[] { 7, 8 }, new int[] { 8, 7 }, "Два элемента");
        Test(new int[] { }, new int[] { }, "Пустой массив");

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Введите количество элементов в массиве: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            int n = int.Parse(input);

            if (n <= 0)
            {
                Console.WriteLine("Количество элементов должно быть положительным.");
                return;
            }

            int[] numbers = new int[n];

            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                numbers[i] = int.Parse(Console.ReadLine() ?? "");
            }

            PrintArray(numbers, "Введённый массив:");
            ReverseArray(numbers);
            PrintArray(numbers, "Массив в обратном порядке:");

        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введите корректное число.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}