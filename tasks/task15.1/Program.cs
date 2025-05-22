using System;

class Program
{
    static int ComputeF(int n_initial)
    {
        if (n_initial < 0)
            throw new ArgumentException("Неотрицательное число");

        if (n_initial == 0)
            return 0;

        // Поддерживаем инвариант: f(n_initial) = coeff_a * f(n_current) + coeff_b * f(n_current + 1)
        // (или похожий, в зависимости от чётности n_current на различных этапах цикла)
        // В конечном итоге, когда n_current = 0, f(n_initial) = coeff_a * f(0) + coeff_b * f(1) = coeff_b.
        int coeff_a = 1;
        int coeff_b = 0;
        int n_current = n_initial;

        while (n_current > 0)
        {
            if (n_current % 2 == 0) // n_current - чётное (n_current = 2k)
            {
                // f(n_initial) = coeff_a * f(2k) + coeff_b * f(2k + 1)
                //            = coeff_a * f(k) + coeff_b * (f(k) + f(k + 1))
                //            = (coeff_a + coeff_b) * f(k) + coeff_b * f(k + 1)
                // Обновляем: coeff_a_new = coeff_a + coeff_b, coeff_b_new = coeff_b, n_current_new = k
                coeff_a = coeff_a + coeff_b;
                n_current = n_current / 2;
            }
            else // n_current - нечётное (n_current = 2k + 1)
            {
                // f(n_initial) = coeff_a * f(2k + 1) + coeff_b * f(2k + 2)
                //            = coeff_a * (f(k) + f(k + 1)) + coeff_b * f(k + 1)
                //            = coeff_a * f(k) + (coeff_a + coeff_b) * f(k + 1)
                // Обновляем: coeff_a_new = coeff_a, coeff_b_new = coeff_a + coeff_b, n_current_new = k
                coeff_b = coeff_a + coeff_b;
                n_current = (n_current - 1) / 2;
            }
        }

        // Когда n_current = 0, инвариант становится:
        // f(n_initial) = coeff_a * f(0) + coeff_b * f(1)
        //            = coeff_a * 0 + coeff_b * 1
        //            = coeff_b
        return coeff_b;
    }

    static void RunTests()
    {
        static void Test(int input, int expected, string testName, bool expectException)
        {
            try
            {
                int result = ComputeF(input);

                bool passed = !expectException && result == expected;

                Console.WriteLine($"--- Тест: {testName} ---");
                Console.WriteLine($"Входное число: {input}");
                Console.WriteLine($"Результат: {result}");
                Console.WriteLine(expectException
                    ? "❌ Не прошёл (ожидалось исключение, но его нет)"
                    : passed
                        ? "✅ Прошёл"
                        : $"❌ Не прошёл → Ожидалось: {expected}");
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

        Test(6, 2, "Позитивный тест (n=6)", false);
        Test(2, 1, "Негативный тест (n=2)", false);
        Test(0, 0, "Пограничный тест (n=0)", false);
        Test(-1, 0, "Исключительный тест (n<0)", true);

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Введите n: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            if (!int.TryParse(input, out int n))
                throw new FormatException("Некорректное число");

            int result = ComputeF(n);
            Console.WriteLine($"Число: {n}");
            Console.WriteLine($"Результат: {result}");
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
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}