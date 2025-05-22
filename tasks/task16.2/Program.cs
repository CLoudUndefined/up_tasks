using System;

class Program
{
    static double ComputeProduct(int n)
    {
        if (n <= 0)
            throw new ArgumentException("Число должно быть натуральным");

        double product = 1.0;
        for (int i = 1; i <= n; i++)
        {
            double factorial = 1.0;
            for (int j = 1; j <= i; j++)
                factorial *= j;
            double term = 2.0 + 1.0 / factorial;
            product *= term;
        }
        return product;
    }

    static void RunTests()
    {
        static void Test(int input, double expected, string testName, bool expectException)
        {
            try
            {
                double result = ComputeProduct(input);

                // Учитываем погрешность для double
                bool passed = !expectException && Math.Abs(result - expected) < 1e-10;

                Console.WriteLine($"--- Тест: {testName} ---");
                Console.WriteLine($"Входное число: {input}");
                Console.WriteLine($"Результат: {result:F10}");
                Console.WriteLine(expectException
                    ? "❌ Не прошёл (ожидалось исключение, но его нет)"
                    : passed
                        ? "✅ Прошёл"
                        : $"❌ Не прошёл → Ожидалось: {expected:F10}");
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

        Test(2, 7.5, "Позитивный тест (n=2)", false); // (2 + 1/1!)(2 + 1/2!) = (2 + 1)(2 + 0.5) = 3 * 2.5 = 5
        Test(3, 16.25, "Позитивный тест (n=3)", false); // (2 + 1)(2 + 0.5)(2 + 1/6) ≈ 15.5
        Test(1, 3.0, "Пограничный тест (n=1)", false); // 2 + 1/1! = 3
        Test(0, 0.0, "Исключительный тест (n=0)", true);

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Введите число n: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            if (!int.TryParse(input, out int n))
                throw new FormatException("Введено не число. Пожалуйста, введите целое число.");

            double result = ComputeProduct(n);
            Console.WriteLine($"Входное число: {n}");
            Console.WriteLine($"Результат: {result:F10}");
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