using System;

class Program
{
    static void FormArrayQ(int[] P, int[] Q)
    {
        if (P.Length != Q.Length)
            throw new ArgumentException("Массивы P и Q должны быть одинакового размера");

        for (int i = 0; i < P.Length; i++)
        {
            if (i >= 2 && i <= 9) // Отбираем как раз по заданию 3-й по 10-й элемент (индексы 2–9) для формулы >.>
                Q[i] = -P[i];
            else
                Q[i] = P[i] * i;
        }
    }

    static void PrintArray(int[] arr, string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("[" + string.Join(", ", arr) + "]");
    }

    static void RunTests()
    {
        static void Test(int[] P, int[] expectedQ, string testName, bool expectException)
        {
            try
            {
                // Очень пре очень важная логика здесь.
                // Для последнего теста нужно попробовать сделать массивы разной длины\
                // Так что мы это и делаем, хехе ^-^
                int[] Q = expectException 
                    ? new int[expectedQ.Length]  // Намеренно создаем Q другой длины
                    : new int[P.Length];         // Или же создаем Q той же длины что и P, если тест предполагает иное
                
                FormArrayQ(P, Q);

                bool passed = true;
                if (!expectException)
                {
                    for (int i = 0; i < expectedQ.Length; i++)
                    {
                        if (i >= Q.Length || Q[i] != expectedQ[i])
                        {
                            passed = false;
                            break;
                        }
                    }
                }

                Console.WriteLine($"--- Тест: {testName} ---");
                PrintArray(P, "Массив P:");
                PrintArray(Q, "Массив Q:");
                Console.WriteLine(expectException
                    ? "❌ Не прошёл (ожидалось исключение, но его нет)"
                    : passed
                        ? "✅ Прошёл"
                        : $"❌ Не прошёл → Ожидалось: [{string.Join(", ", expectedQ)}]");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"--- Тест: {testName} ---");
                PrintArray(P, "Массив P:");
                Console.WriteLine(expectException
                    ? $"✅ Прошёл (исключение: {ex.Message})"
                    : $"❌ Не прошёл (выброшено исключение: {ex.Message})");
            }
        }

        Console.WriteLine("=== ТЕСТЫ для тестов ^-^ ===");

        Test(
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
            new int[] { 0, 2, -3, -4, -5, -6, -7, -8, -9, -10, 110, 132 },
            "Позитивный тест (12 элементов)",
            false
        );

        Test(
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            "Негативный тест (все нули)",
            false
        );

        Test(
            new int[] { 1, 2, 3 },
            new int[] { 0, 2, -3 },
            "Пограничный тест (3 элемента)",
            false
        );

        Test(
            new int[] { 1, 2, 3 },
            new int[] { 1, 2 },
            "Исключительный тест (разные длины)",
            true
        );

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Введите размер массива: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            if (!int.TryParse(input, out int n))
                throw new FormatException("Введено не число. Пожалуйста, введите целое число.");

            if (n <= 0)
                throw new ArgumentException("Размер массива должен быть положительным");

            int[] P = new int[n];
            int[] Q = new int[n];

            Console.WriteLine("Введите элементы массива P:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                string elementInput = Console.ReadLine() ?? "";
                if (!int.TryParse(elementInput, out int elementValue))
                    throw new FormatException("Введено не число. Пожалуйста, введите целое число.");
                P[i] = elementValue;
            }

            FormArrayQ(P, Q);

            PrintArray(P, "Массив P:");
            PrintArray(Q, "Массив Q:");
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