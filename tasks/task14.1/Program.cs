using System;

class Program
{
    static (int total, int even) CountDivisors(int n)
    {
        if (n <= 0)
            throw new ArgumentException("Число должно быть натуральным");

        int totalDivisors = 0;
        int evenDivisors = 0;

        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                totalDivisors++;
                if (i % 2 == 0)
                    evenDivisors++;
            }
        }

        return (totalDivisors, evenDivisors);
    }

    static void RunTests()
    {
        static void Test(int input, (int total, int even) expected, string testName, bool expectException)
        {
            try
            {
                var result = CountDivisors(input);

                bool passed = !expectException && result.total == expected.total && result.even == expected.even;

                Console.WriteLine($"--- Тест: {testName} ---");
                Console.WriteLine($"Входное число: {input}");
                Console.WriteLine($"Результат: Всего делителей: {result.total}, Чётных делителей: {result.even}");
                Console.WriteLine(expectException
                    ? "❌ Не прошёл (ожидалось исключение, но его нет)"
                    : passed
                        ? "✅ Прошёл"
                        : $"❌ Не прошёл → Ожидалось: Всего делителей: {expected.total}, Чётных делителей: {expected.even}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"--- Тест: {testName} ---");
                Console.WriteLine(expectException
                    ? $"✅ Прошёл (исключение: {ex.Message})"
                    : $"❌ Не прошёл (выброшено исключение: {ex.Message})");
            }
        }

        Console.WriteLine("=== ТЕСТЫ для тестов ^-^ ===");

        Test(12, (6, 4), "Позитивный тест (n=12)", false);
        Test(7, (2, 0), "Негативный тест (простое число, n=7)", false);
        Test(1, (1, 0), "Пограничный тест (n=1)", false);
        Test(0, (0, 0), "Исключительный тест (n=0)", true);

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Введите натуральное число: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            if (!int.TryParse(input, out int n))
                throw new FormatException("Введено не число. Пожалуйста, введите целое число.");

            var result = CountDivisors(n);
            Console.WriteLine($"Входное число: {n}");
            Console.WriteLine($"Результат: Всего делителей: {result.total}, Чётных делителей: {result.even}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла неожиданная ошибка: {ex.Message}");
        }
    }
}