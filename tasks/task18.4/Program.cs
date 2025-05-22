using System;

class Program
{
    static int FindBestAthlete(int[,] A, int M, int N)
    {
        if (M < 4 || N <= 0 || A.GetLength(0) != M || A.GetLength(1) != N)
            throw new ArgumentException("Некорректные размеры таблицы или недостаточно попыток");

        int maxJump = A[3, 0];
        int bestAthlete = 0;

        for (int j = 1; j < N; j++)
        {
            if (A[3, j] > maxJump)
            {
                maxJump = A[3, j];
                bestAthlete = j;
            }
        }

        return bestAthlete + 1;
    }

    static void RunTests()
    {
        static void Test(int[,] A, int M, int N, int expected, string testName, bool expectException)
        {
            try
            {
                int result = FindBestAthlete(A, M, N);

                bool passed = !expectException && result == expected;

                Console.WriteLine($"--- Тест: {testName} ---");
                Console.WriteLine($"M: {M}, N: {N}");
                Console.WriteLine("Таблица:");
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    int[] row = new int[A.GetLength(1)];
                    for (int j = 0; j < A.GetLength(1); j++)
                        row[j] = A[i, j];
                    Console.WriteLine($"[{string.Join(", ", row)}]");
                }
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

        int[,] matrix1 = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            { 10, 12, 11 },
            { 13, 14, 15 }
        };
        Test(matrix1, 5, 3, 2, "Позитивный тест (4-я попытка, max=12)", false);

        int[,] matrix2 = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            { 0, 0, 0 },
            { 10, 11, 12 }
        };
        Test(matrix2, 5, 3, 1, "Негативный тест (все нули в 4-й попытке)", false);

        int[,] matrix3 = {
            { 1 },
            { 2 },
            { 3 },
            { 4 },
            { 5 }
        };
        Test(matrix3, 5, 1, 1, "Пограничный тест (1 спортсмен)", false);

        int[,] matrix4 = {
            { 1, 2 },
            { 3, 4 },
            { 5, 6 }
        };
        Test(matrix4, 3, 2, 0, "Исключительный тест (M<4)", true);

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Введите количество попыток M: ");
        string mInput = Console.ReadLine() ?? "";
        Console.Write("Введите количество спортсменов N: ");
        string nInput = Console.ReadLine() ?? "";

        try
        {
            if (!int.TryParse(mInput, out int M) || !int.TryParse(nInput, out int N))
                throw new FormatException("Некорректное число");

            if (M <= 0 || N <= 0)
                throw new ArgumentException("Размеры таблицы должны быть положительными");

            int[,] A = new int[M, N];
            Console.WriteLine("Введите результаты прыжков:");
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"A[{i + 1},{j + 1}]: ");
                    string element = Console.ReadLine() ?? "";
                    if (!int.TryParse(element, out A[i, j]))
                        throw new FormatException("Некорректное число");
                }
            }

            int result = FindBestAthlete(A, M, N);
            Console.WriteLine("Таблица:");
            for (int i = 0; i < M; i++)
            {
                int[] row = new int[N];
                for (int j = 0; j < N; j++)
                    row[j] = A[i, j];
                Console.WriteLine($"[{string.Join(", ", row)}]");
            }
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