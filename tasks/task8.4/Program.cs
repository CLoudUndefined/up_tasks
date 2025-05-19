using System;

class Program
{
    static void SwapRows(int[,] a, int n)
    {
        if (n <= 0)
            throw new ArgumentException("Размер таблицы должен быть положительным");

        if (a.GetLength(0) != n || a.GetLength(1) != n)
            throw new ArgumentException("Таблица должна быть квадратной и размером n x n!");

        for (int i = 0; i < n - 1; i += 2)
        {
            for (int j = 0; j < n; j++)
            {
                // Очень важная магия обмена >.>
                int temp = a[i, j];
                a[i, j] = a[i + 1, j];
                a[i + 1, j] = temp;
            }
        }
    }

    static void PrintMatrix(int[,] a, string message)
    {
        Console.WriteLine(message);
        int n = a.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            int[] row = new int[n];
            for (int j = 0; j < n; j++)
                row[j] = a[i, j];
            Console.WriteLine("[" + string.Join(", ", row) + "]");
        }
    }

    static void RunTests()
    {
        static void Test(int[,] a, int n, int[,] expected, string testName, bool expectException)
        {
            try
            {
                SwapRows(a, n);

                bool passed = true;
                if (!expectException)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (i >= a.GetLength(0) || j >= a.GetLength(1) || a[i, j] != expected[i, j])
                            {
                                passed = false;
                                break;
                            }
                        }
                    }
                }

                Console.WriteLine($"--- Тест: {testName} ---");
                PrintMatrix(a, "Таблица после обмена:");
                Console.WriteLine(expectException
                    ? "❌ Не прошёл (ожидалось исключение, но его нет)"
                    : passed
                        ? "✅ Прошёл"
                        : $"❌ Не прошёл → Ожидалось: (см. выше для формата)");
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

        int[,] matrix1 = {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 }
        };
        int[,] expected1 = {
            { 5, 6, 7, 8 },
            { 1, 2, 3, 4 },
            { 13, 14, 15, 16 },
            { 9, 10, 11, 12 }
        };
        Test(matrix1, 4, expected1, "Позитивный тест (4x4)", false);

        int[,] matrix2 = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        int[,] expected2 = {
            { 4, 5, 6 },
            { 1, 2, 3 },
            { 7, 8, 9 }
        };
        Test(matrix2, 3, expected2, "Негативный тест (3x3, нечётное n)", false);

        int[,] matrix3 = { { 1 } };
        int[,] expected3 = { { 1 } };
        Test(matrix3, 1, expected3, "Пограничный тест (1x1)", false);

        int[,] matrix4 = { { 1, 2 }, { 3, 4 } };
        int[,] expected4 = { { 1, 2 }, { 3, 4 } };
        Test(matrix4, 0, expected4, "Исключительный тест (n = 0)", true);

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Введите размер таблицы n: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            if (!int.TryParse(input, out int n))
                throw new FormatException("Введено не число. Пожалуйста, введите целое число.");

            if (n <= 0)
                throw new ArgumentException("Размер таблицы должен быть положительным");

            int[,] a = new int[n, n];

            Console.WriteLine("Введите элементы таблицы по строкам:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                    string elementInput = Console.ReadLine() ?? "";
                    if (!int.TryParse(elementInput, out int elementValue))
                        throw new FormatException("Введено не число. Пожалуйста, введите целое число.");
                    a[i, j] = elementValue;
                }
            }

            PrintMatrix(a, "Исходная таблица:");
            SwapRows(a, n);
            PrintMatrix(a, "Таблица после обмена строк:");
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