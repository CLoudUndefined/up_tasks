using System;

class Program
{
    static int SumDecade(int[] arr, int startDay, int daysCount)
    {
        int sum = 0;
        for (int i = startDay; i < startDay + daysCount; i++)
        {
            if (arr[i] < 0)
            {
                throw new ArgumentException($"Отрицательное значение осадков ({arr[i]}) недопустимо в день {i + 1}.");
            }
            sum += arr[i];
        }
        return sum;
    }

    static void RunTests()
    {
        void Test(int[] input, int start, int count, int expected, string testName, bool expectException)
        {
            try
            {
                int result = SumDecade(input, start, count);
                if (expectException)
                {
                    Console.WriteLine($"{testName}: [{string.Join(", ", input)}] → ❌ Не прошёл (ожидалось исключение, но его нет)");
                }
                else
                {
                    bool passed = result == expected;
                    Console.WriteLine($"{testName}: [{string.Join(", ", input)}], начиная с {start}, {count} дней → Результат: {result} → {(passed ? "✅ Прошёл" : $"❌ Не прошёл (ожидалось: {expected})")}");
                }
            }
            catch (ArgumentException)
            {
                if (expectException)
                {
                    Console.WriteLine($"{testName}: [{string.Join(", ", input)}] → ✅ Прошёл (исключение выброшено)");
                }
                else
                {
                    Console.WriteLine($"{testName}: [{string.Join(", ", input)}] → ❌ Не прошёл (выброшено исключение)");
                }
            }
        }

        Console.WriteLine("=== ТЕСТЫ для тестов ^-^ ===");

        Test(new int[] { 2, 3, 1, 0, 5, 4, 2, 3, 1, 0 }, 0, 10, 21, "Позитивный тест", false);
        Test(new int[] { -1, -2, -1, -3, -2, -1, -1, -2, -1, -2 }, 0, 10, -16, "Негативный тест", true);
        Test(new int[] { 7 }, 0, 1, 7, "Пограничный тест", false);
        Console.WriteLine("Исключительный тест: попытка ввести строку или пустое значение — будет обработано в Main");

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        const int daysInJune = 30;
        int[] rainfall = new int[daysInJune];

        Console.WriteLine("\nВведите количество осадков за каждый день июня:");

        try
        {
            for (int i = 0; i < daysInJune; i++)
            {
                Console.Write($"День {i + 1}: ");
                string input = Console.ReadLine() ?? "";
                if (!int.TryParse(input, out int value))
                    throw new FormatException("Введено не число. Пожалуйста, введите целое число.");
                rainfall[i] = value;
            }

            int decade1 = SumDecade(rainfall, 0, 10);
            int decade2 = SumDecade(rainfall, 10, 10);
            int decade3 = SumDecade(rainfall, 20, 10);

            Console.WriteLine("\nОбщее количество осадков:");
            Console.WriteLine($"Первая декада: {decade1} мм");
            Console.WriteLine($"Вторая декада: {decade2} мм");
            Console.WriteLine($"Третья декада: {decade3} мм");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}