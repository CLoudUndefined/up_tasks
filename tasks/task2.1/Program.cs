using System;

class Program
{
    // Проверка условия а): максимальный элемент превышает минимальный не более чем на 25
    static bool CheckDifference(double max, double min)
    {
        return (max - min) <= 25;
    }

    // Проверка условия б): минимальный элемент меньше максимального более чем в два раза
    static bool CheckRatio(double max, double min)
    {
        if (min == 0) return false;
        return max / min > 2;
    }

    static void RunTests()
    {
        void Test(double[] values, bool expectedA, bool expectedB, string testName)
        {
            try
            {
                if (values.Length == 0)
                    throw new ArgumentException("Нет данных");

                double min = values[0];
                double max = values[0];

                for (int i = 1; i < values.Length; i++)
                {
                    if (values[i] < min) min = values[i];
                    if (values[i] > max) max = values[i];
                }

                bool resultA = CheckDifference(max, min);
                bool resultB = CheckRatio(max, min);

                string statusA = resultA == expectedA ? "✅ Прошёл" : $"❌ Не прошёл (ожидалось: {expectedA})";
                string statusB = resultB == expectedB ? "✅ Прошёл" : $"❌ Не прошёл (ожидалось: {expectedB})";

                Console.WriteLine($"{testName}: Введено: [{string.Join(", ", values)}]");
                Console.WriteLine($"  Минимум: {min}, Максимум: {max}");
                Console.WriteLine($"  Условие а): {resultA} → {statusA}");
                Console.WriteLine($"  Условие б): {resultB} → {statusB}");
                Console.WriteLine("-------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{testName}: Ошибка: {ex.Message}");
            }
        }

        Console.WriteLine("=== ТЕСТЫ для тестов ^-^ ===");

        Test(new double[] { 100.5, 120.0, 90.0 }, false, false, "Стандартный 1");
        Test(new double[] { 50.0, 75.0, 75.0 }, true, false, "Стандартный 2");
        Test(new double[] { 100.0, 125.0 }, true, false, "Пограничный разница=25");
        Test(new double[] { 100.0, 201.0 }, false, true, "Пограничный отношение=2.01");
        Test(new double[] { 100.0, 200.0 }, false, false, "Пограничный отношение=2.0");
        Test(new double[] { 100.0, 126.0 }, false, false, "За диапазоном разница>25");
        Test(new double[] { 100.0, 199.0 }, false, false, "За диапазоном отношение<2");
        Test(new double[] { 50.0 }, true, false, "Один элемент");
        Test(new double[] { 0.0, 100.0 }, false, false, "Ноль в массиве");

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Сколько чисел вы хотите ввести? ");
        int n = int.Parse(Console.ReadLine() ?? "");

        if (n <= 0)
        {
            Console.WriteLine("Количество чисел должно быть положительным.");
            return;
        }

        double min = 0;
        double max = 0;

        try
        {
            Console.WriteLine("Введите числа по одному:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Число {i + 1}: ");
                double num = double.Parse(Console.ReadLine() ?? "");

                if (i == 0)
                {
                    min = max = num;
                }
                else
                {
                    if (num < min) min = num;
                    if (num > max) max = num;
                }
            }

            bool conditionA = CheckDifference(max, min);
            bool conditionB = CheckRatio(max, min);

            Console.WriteLine($"\nМинимальное число: {min}");
            Console.WriteLine($"Максимальное число: {max}");
            Console.WriteLine($"Условие а) выполнено? → {conditionA}");
            Console.WriteLine($"Условие б) выполнено? → {conditionB}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введите корректные числа.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}