using System;

class Program
{
    static int ScalarProduct(int[] A, int[] B)
    {
        if (A.Length != B.Length || A.Length == 0)
            throw new ArgumentException("Массивы должны быть одинаковой длины и непустыми");

        int result = 0;
        for (int i = 0; i < A.Length; i++)
            result += A[i] * B[i];
        return result;
    }

    static void RunTests()
    {
        static void Test(int[] A, int[] B, int expected, string testName, bool expectException)
        {
            try
            {
                int result = ScalarProduct(A, B);

                bool passed = !expectException && result == expected;

                Console.WriteLine($"--- Тест: {testName} ---");
                Console.WriteLine($"Массив A: [{string.Join(", ", A)}]");
                Console.WriteLine($"Массив B: [{string.Join(", ", B)}]");
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
                Console.WriteLine($"Массив A: [{string.Join(", ", A)}]");
                Console.WriteLine($"Массив B: [{string.Join(", ", B)}]");
                Console.WriteLine(expectException
                    ? $"✅ Прошёл (исключение: {ex.Message})"
                    : $"❌ Не прошёл (выброшено исключение: {ex.Message})");
            }
        }

        Console.WriteLine("=== ТЕСТЫ для тестов ^-^ ===");

        Test(
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            32, // 1*4 + 2*5 + 3*6 = 4 + 10 + 18 = 32
            "Позитивный тест (3 элемента)",
            false
        );
        Test(
            new int[] { 0, 0, 0 },
            new int[] { 1, 2, 3 },
            0, // 0*1 + 0*2 + 0*3 = 0
            "Негативный тест (нулевой массив)",
            false
        );
        Test(
            new int[] { 1 },
            new int[] { 2 },
            2, // 1*2 = 2
            "Пограничный тест (1 элемент)",
            false
        );
        Test(
            new int[] { 1, 2 },
            new int[] { 1 },
            0,
            "Исключительный тест (разные длины)",
            true
        );

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Введите длину массивов: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            if (!int.TryParse(input, out int n))
                throw new FormatException("Некорректное число");

            if (n <= 0)
                throw new ArgumentException("Длина массивов должна быть положительной");

            int[] A = new int[n];
            int[] B = new int[n];

            Console.WriteLine("Введите элементы массива A:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"A[{i}]: ");
                string element = Console.ReadLine() ?? "";
                if (!int.TryParse(element, out A[i]))
                    throw new FormatException("Некорректное число");
            }

            Console.WriteLine("Введите элементы массива B:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"B[{i}]: ");
                string element = Console.ReadLine() ?? "";
                if (!int.TryParse(element, out B[i]))
                    throw new FormatException("Некорректное число");
            }

            int result = ScalarProduct(A, B);
            Console.WriteLine($"Массив A: [{string.Join(", ", A)}]");
            Console.WriteLine($"Массив B: [{string.Join(", ", B)}]");
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