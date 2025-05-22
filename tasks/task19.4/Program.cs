using System;

class Program
{
    static int[,] InsertZeroRows(int[,] A)
    {
        if (A.GetLength(0) != 5 || A.GetLength(1) != 8)
            throw new ArgumentException("Массив должен быть размером 5x8");

        int rowsToInsert = 0;
        for (int i = 0; i < 5; i++)
            if (A[i, 0] % 3 == 0)
                rowsToInsert++;

        int[,] result = new int[5 + rowsToInsert, 8];
        int currentRow = 0;

        for (int i = 0; i < 5; i++)
        {
            if (A[i, 0] % 3 == 0)
            {
                for (int j = 0; j < 8; j++)
                    result[currentRow, j] = 0;
                currentRow++;
            }
            for (int j = 0; j < 8; j++)
                result[currentRow, j] = A[i, j];
            currentRow++;
        }

        return result;
    }

    static void PrintMatrix(int[,] A)
    {
        Console.WriteLine("Массив:");
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int[] row = new int[A.GetLength(1)];
            for (int j = 0; j < A.GetLength(1); j++)
                row[j] = A[i, j];
            Console.WriteLine($"[{string.Join(", ", row)}]");
        }
    }

    static void RunTests()
    {
        static void Test(int[,] A, int[,] expected, string testName, bool expectException)
        {
            try
            {
                int[,] result = InsertZeroRows(A);

                bool passed = !expectException && result.GetLength(0) == expected.GetLength(0) &&
                             result.GetLength(1) == expected.GetLength(1);
                if (passed)
                {
                    for (int i = 0; i < result.GetLength(0); i++)
                        for (int j = 0; j < result.GetLength(1); j++)
                            if (result[i, j] != expected[i, j])
                            {
                                passed = false;
                                break;
                            }
                }

                Console.WriteLine($"--- Тест: {testName} ---");
                PrintMatrix(A);
                Console.WriteLine("Результат:");
                PrintMatrix(result);
                Console.WriteLine(expectException
                    ? "❌ Не прошёл (ожидалось исключение, но его нет)"
                    : passed
                        ? "✅ Прошёл"
                        : $"❌ Не прошёл → Ожидалось:");
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
            { 3, 1, 2, 3, 4, 5, 6, 7 },
            { 1, 2, 3, 4, 5, 6, 7, 8 },
            { 6, 1, 2, 3, 4, 5, 6, 7 },
            { 2, 2, 3, 4, 5, 6, 7, 8 },
            { 9, 1, 2, 3, 4, 5, 6, 7 }
        };
        int[,] expected1 = {
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 3, 1, 2, 3, 4, 5, 6, 7 },
            { 1, 2, 3, 4, 5, 6, 7, 8 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 6, 1, 2, 3, 4, 5, 6, 7 },
            { 2, 2, 3, 4, 5, 6, 7, 8 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 9, 1, 2, 3, 4, 5, 6, 7 }
        };
        Test(matrix1, expected1, "Позитивный тест (3 строки с первым элементом, делящимся на 3)", false);

        int[,] matrix2 = {
            { 1, 1, 2, 3, 4, 5, 6, 7 },
            { 2, 2, 3, 4, 5, 6, 7, 8 },
            { 4, 1, 2, 3, 4, 5, 6, 7 },
            { 5, 2, 3, 4, 5, 6, 7, 8 },
            { 7, 1, 2, 3, 4, 5, 6, 7 }
        };
        int[,] expected2 = {
            { 1, 1, 2, 3, 4, 5, 6, 7 },
            { 2, 2, 3, 4, 5, 6, 7, 8 },
            { 4, 1, 2, 3, 4, 5, 6, 7 },
            { 5, 2, 3, 4, 5, 6, 7, 8 },
            { 7, 1, 2, 3, 4, 5, 6, 7 }
        };
        Test(matrix2, expected2, "Негативный тест (нет строк с первым элементом, делящимся на 3)", false);

        int[,] matrix3 = {
            { 0, 1, 2, 3, 4, 5, 6, 7 },
            { 1, 2, 3, 4, 5, 6, 7, 8 },
            { 2, 1, 2, 3, 4, 5, 6, 7 },
            { 4, 2, 3, 4, 5, 6, 7, 8 },
            { 5, 1, 2, 3, 4, 5, 6, 7 }
        };
        int[,] expected3 = {
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 2, 3, 4, 5, 6, 7 },
            { 1, 2, 3, 4, 5, 6, 7, 8 },
            { 2, 1, 2, 3, 4, 5, 6, 7 },
            { 4, 2, 3, 4, 5, 6, 7, 8 },
            { 5, 1, 2, 3, 4, 5, 6, 7 }
        };
        Test(matrix3, expected3, "Пограничный тест (первый элемент 0, не вставляем строку)", false);

        int[,] matrix4 = {
            { 1, 2 },
            { 3, 4 }
        };
        int[,] expected4 = {
            { 1, 2 },
            { 3, 4 }
        };
        Test(matrix4, expected4, "Исключительный тест (неверный размер)", true);

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        const int M = 5;
        const int N = 8;
        int[,] A = new int[M, N];
        Random rand = new Random();

        Console.WriteLine("Заполнение массива случайными числами (1-100):");
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                A[i, j] = rand.Next(1, 101);
            }
        }

        try
        {
            PrintMatrix(A);
            int[,] result = InsertZeroRows(A);
            Console.WriteLine("Результат:");
            PrintMatrix(result);
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