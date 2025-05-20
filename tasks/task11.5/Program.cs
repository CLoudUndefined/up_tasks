using System;

class Program
{
    static int CountDigitsAndSigns(string s)
    {
        if (string.IsNullOrEmpty(s))
            throw new ArgumentException("Слово не может быть пустым");

        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]) || s[i] == '+' || s[i] == '-' || s[i] == '*')
                count++;
        }
        return count;
    }

    static void RunTests()
    {
        static void Test(string input, int expected, string testName, bool expectException)
        {
            try
            {
                int result = CountDigitsAndSigns(input);

                bool passed = !expectException && result == expected;

                Console.WriteLine($"--- Тест: {testName} ---");
                Console.WriteLine($"Входная строка: {input}");
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

        Test("a1b+2c-3d*4", 7, "Позитивный тест (цифры и знаки)", false);
        Test("abcde", 0, "Негативный тест (без цифр и знаков)", false);
        Test("1", 1, "Пограничный тест (один символ)", false);
        Test("", 0, "Исключительный тест (пустая строка)", true);

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Введите строку: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            int result = CountDigitsAndSigns(input);
            Console.WriteLine($"Входная строка: {input}");
            Console.WriteLine($"Результат: {result}");
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