using System;

class Program
{
    static int[] RemoveValue(int[] X, int P)
    {
        if (X.Length == 0)
            throw new ArgumentException("Массив не может быть пустым");

        for (int i = 1; i < X.Length; i++)
            if (X[i] < X[i - 1])
                throw new ArgumentException("Массив должен быть упорядочен по неубыванию");

        int left = 0, right = X.Length - 1;
        int leftBound = -1, rightBound = -1;

        // Нужно найти левую границу, где може встречаться первая p
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (X[mid] == P)
            {
                leftBound = mid;
                right = mid - 1;
            }
            else if (X[mid] < P)
                left = mid + 1;
            else
                right = mid - 1;
        }

        // А здесь Нужно найти правую границу, где може встречаться последняя P
        left = 0;
        right = X.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (X[mid] == P)
            {
                rightBound = mid;
                left = mid + 1;
            }
            else if (X[mid] < P)
                left = mid + 1;
            else
                right = mid - 1;
        }

        if (leftBound == -1)
            return (int[])X.Clone();

        int newSize = X.Length - (rightBound - leftBound + 1);
        int[] result = new int[newSize];
        int index = 0;

        for (int i = 0; i < leftBound; i++)
            result[index++] = X[i];

        for (int i = rightBound + 1; i < X.Length; i++)
            result[index++] = X[i];

        return result;
    }

    static void RunTests()
    {
        static void Test(int[] X, int P, int[] expected, string testName, bool expectException)
        {
            try
            {
                int[] result = RemoveValue(X, P);

                bool passed = !expectException && result.Length == expected.Length;
                if (passed)
                    for (int i = 0; i < result.Length; i++)
                        if (result[i] != expected[i])
                        {
                            passed = false;
                            break;
                        }

                Console.WriteLine($"--- Тест: {testName} ---");
                Console.WriteLine($"Массив X: [{string.Join(", ", X)}]");
                Console.WriteLine($"Значение P: {P}");
                Console.WriteLine($"Результат: [{string.Join(", ", result)}]");
                Console.WriteLine(expectException
                    ? "❌ Не прошёл (ожидалось исключение, но его нет)"
                    : passed
                        ? "✅ Прошёл"
                        : $"❌ Не прошёл → Ожидалось: [{string.Join(", ", expected)}]");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"--- Тест: {testName} ---");
                Console.WriteLine($"Массив X: [{string.Join(", ", X)}]");
                Console.WriteLine($"Значение P: {P}");
                Console.WriteLine(expectException
                    ? $"✅ Прошёл (исключение: {ex.Message})"
                    : $"❌ Не прошёл (выброшено исключение: {ex.Message})");
            }
        }

        Console.WriteLine("=== ТЕСТЫ для тестов ^-^ ===");

        Test(
            new int[] { 1, 2, 2, 3, 3, 3, 4 },
            3,
            new int[] { 1, 2, 2, 4 },
            "Позитивный тест (удаление нескольких 3)",
            false
        );

        Test(
            new int[] { 1, 2, 4, 5 },
            3,
            new int[] { 1, 2, 4, 5 },
            "Негативный тест (P отсутствует)",
            false
        );

        Test(
            new int[] { 1 },
            1,
            new int[] { },
            "Пограничный тест (один элемент, удаляется)",
            false
        );

        Test(
            new int[] { },
            1,
            new int[] { },
            "Исключительный тест (пустой массив)",
            true
        );

        Test(
            new int[] { 2, 1 },
            1,
            new int[] { },
            "Исключительный тест (неупорядоченный массив)",
            true
        );

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Введите длину массива: ");
        string nInput = Console.ReadLine() ?? "";
        Console.Write("Введите значение P: ");
        string pInput = Console.ReadLine() ?? "";

        try
        {
            if (!int.TryParse(nInput, out int n) || !int.TryParse(pInput, out int P))
                throw new FormatException("Некорректное число");

            if (n <= 0)
                throw new ArgumentException("Длина массива должна быть положительной");

            int[] X = new int[n];
            Console.WriteLine("Введите элементы массива X (в неубывающем порядке):");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"X[{i}]: ");
                string element = Console.ReadLine() ?? "";
                if (!int.TryParse(element, out X[i]))
                    throw new FormatException("Некорректное число");
            }

            int[] result = RemoveValue(X, P);
            Console.WriteLine($"Массив X: [{string.Join(", ", X)}]");
            Console.WriteLine($"Значение P: {P}");
            Console.WriteLine($"Результат: [{string.Join(", ", result)}]");
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