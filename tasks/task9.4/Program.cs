using System;

class Program
{
    static void FormMaxAbsArray(int[,] a, int[] result)
    {
        int rows = a.GetLength(0);
        int cols = a.GetLength(1);

        if (rows != 5 || cols != 6 || result.Length != 6)
            throw new ArgumentException("Размер матрицы должен быть 5x6, а результирующий массив — длиной 6");

        for (int j = 0; j < cols; j++)
        {
            int maxAbs = Math.Abs(a[0, j]);
            
            for (int i = 1; i < rows; i++)
            {
                if (Math.Abs(a[i, j]) > maxAbs)
                    maxAbs = Math.Abs(a[i, j]);
            }
            
            result[j] = maxAbs;
        }
    }

    static void PrintMatrix(int[,] a)
    {
        Console.WriteLine("Исходная матрица:");
        int n = a.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            int[] row = new int[a.GetLength(1)];
            for (int j = 0; j < a.GetLength(1); j++)
                row[j] = a[i, j];
            Console.WriteLine("[" + string.Join(", ", row) + "]");
        }
    }

    static void PrintArray(int[] arr)
    {
        Console.WriteLine("Результирующий массив:");
        Console.WriteLine("[" + string.Join(", ", arr) + "]");
    }

    static void RunTests()
    {
        static void Test(int[,] a, int[] expected, string testName, bool expectException)
        {
            try
            {
                int[] result = new int[6];
                FormMaxAbsArray(a, result);

                bool passed = true;
                if (!expectException)
                {
                    for (int i = 0; i < expected.Length; i++)
                    {
                        if (i >= result.Length || result[i] != expected[i])
                        {
                            passed = false;
                            break;
                        }
                    }
                }

                Console.WriteLine($"--- Тест: {testName} ---");
                PrintMatrix(a);
                PrintArray(result);
                Console.WriteLine(expectException
                    ? "❌ Не прошёл (ожидалось исключение, но его нет)"
                    : passed
                        ? "✅ Прошёл"
                        : $"❌ Не прошёл → Ожидалось: [{string.Join(", ", expected)}]");
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
            { 1, -2, 3, 4, -5, 6 },
            { -7, 8, -9, 1, 2, -3 },
            { 4, -5, 6, -7, 8, 9 },
            { -1, 2, -3, 4, -5, 6 },
            { 7, -8, 9, -1, 2, -3 }
        };
        int[] expected1 = { 7, 8, 9, 7, 8, 9 };
        Test(matrix1, expected1, "Позитивный тест (5x6)", false);

        int[,] matrix2 = {
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0 }
        };
        int[] expected2 = { 0, 0, 0, 0, 0, 0 };
        Test(matrix2, expected2, "Негативный тест (все нули)", false);

        int[,] matrix3 = {
            { -1, 2, -3, 4, -5, 6 },
            { 1, -2, 3, -4, 5, -6 },
            { -1, 2, -3, 4, -5, 6 },
            { 1, -2, 3, -4, 5, -6 },
            { -1, 2, -3, 4, -5, 6 }
        };
        int[] expected3 = { 1, 2, 3, 4, 5, 6 };
        Test(matrix3, expected3, "Пограничный тест (одинаковые по модулю)", false);

        int[,] matrix4 = { { 1, 2 }, { 3, 4 } };
        int[] expected4 = { 1, 2 };
        Test(matrix4, expected4, "Исключительный тест (не 5x6)", true);

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        const int rows = 5;
        const int cols = 6;
        int[,] a = new int[rows, cols];
        int[] result = new int[cols];

        Console.WriteLine("Введите элементы таблицы 5x6 по строкам:");
        try
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                    string input = Console.ReadLine() ?? "";
                    if (!int.TryParse(input, out int value))
                        throw new FormatException("Введено не число. Пожалуйста, введите целое число.");
                    a[i, j] = value;
                }
            }

            FormMaxAbsArray(a, result);
            PrintMatrix(a);
            PrintArray(result);
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